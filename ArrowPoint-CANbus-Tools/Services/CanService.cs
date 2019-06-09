using ArrowPointCANBusTool.Canbus;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ArrowPointCANBusTool.Services
{

    public delegate void RequestConnectionStatusChangeDelegate(bool connected);
    public delegate void CanUpdateEventHandler(CanReceivedEventArgs e);

    public class CanService
    {

        private readonly object sendLock = new object();
        private readonly object updateLock = new object();

        public event RequestConnectionStatusChangeDelegate RequestConnectionStatusChange;
        public event CanUpdateEventHandler CanUpdateEventHandler;

        private ICanTrafficInterface canConnection;

        private ConcurrentQueue<CanPacket> CanQueue = new ConcurrentQueue<CanPacket>();
        private Hashtable canOn10Hertz = new Hashtable();
        private Hashtable LastCanPacket = new Hashtable();

        private Thread CanSenderThread;
        private Thread CanUpdateThread;
              
        // Connect via Local loopback (used for test purposes only)
        public Boolean ConnectViaLoopBack()
        {
            canConnection = new CanLoopback(ReceivedCanPacketCallBack);
            return PostConnect();
        }    

        public Boolean Connect(string ip, int port)
        {            
            canConnection = new CanOverEthernet(ip,port,ReceivedCanPacketCallBack);
            return PostConnect();
        }

        private Boolean PostConnect()
        {
            StartBackgroundThreads();

            Boolean result = canConnection.Connect();
            if (result) RequestConnectionStatusChange?.Invoke(true);
            return result;
        }

        public void Disconnect()
        {
            StopBackgroundThreads();
            canConnection?.Disconnect();
            RequestConnectionStatusChange?.Invoke(false);
        }

        public Boolean IsConnected()
        {
            if (canConnection == null)
                return false;

            return canConnection.IsConnected();
        }

        public Boolean LoopStarted()
        {
            if (CanSenderThread == null)
                return false;

            return CanSenderThread.IsAlive;
        }

        private void ClearCanQueue()
        {
            CanQueue = new ConcurrentQueue<CanPacket>();
        }

        public void ClearLastCanPacket()
        {
            LastCanPacket.Clear();
        }

        public void SetCanToSendAt10Hertz(CanPacket canPacket)
        {
            if (canOn10Hertz.ContainsKey(canPacket.CanIdBase10))
            {
                canOn10Hertz.Remove(canPacket.CanIdBase10);
            }

            canOn10Hertz.Add(canPacket.CanIdBase10, canPacket);
        }

        public void StopSendingCanAt10Hertz(CanPacket canPacket)
        {
            if (canOn10Hertz.ContainsKey(canPacket.CanIdBase10))
            {
                canOn10Hertz.Remove(canPacket.CanIdBase10);
            }
        }
        
        public int SendMessage(CanPacket canPacket)
        {
            if(IsConnected()) {
                return canConnection.SendMessage(canPacket);
            }

            return -1;
        }

        public CanPacket LastestCanPacket(uint canId)
        {
            if (LastCanPacket == null)
                return null;

            return (CanPacket)LastCanPacket[canId];
        }

        private void ReceivedCanPacketCallBack(CanPacket canPacket)
        {
            CanQueue.Enqueue(canPacket);
            if (LastCanPacket.ContainsKey(canPacket.CanId))
            {
                LastCanPacket.Remove(canPacket.CanId);
            }
            LastCanPacket.Add(canPacket.CanId, canPacket);
        }
       
        private Boolean StartBackgroundThreads()
        {

            try
            {
                CanSenderThread = new Thread(CanSenderLoop);
                CanSenderThread.Start();

                CanUpdateThread = new Thread(CanUpdateLoop);
                CanUpdateThread.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void StopBackgroundThreads()
        {
            CanSenderThread?.Abort();
            CanUpdateThread?.Abort();
        }

        // This method mainly exists to enable testing
        // as it is very difficult to test threads it forces
        // the behaviour of the thread.
        public void CanSenderLoopInner()
        {
            if (IsConnected())
            {
                // Just to capture issues where we add or remove from canOn10Hertz during this loop
                // Not a major issue, but we don't want to throw exceptions because of it
                lock (sendLock)
                {
                   foreach (DictionaryEntry s in canOn10Hertz)
                   {
                        CanPacket canPacket = (CanPacket)s.Value;
                        canConnection.SendMessage(canPacket);
                   }
                }
            }
        }

        private void CanSenderLoop()
        {
            while (true)
            {
                try
                {
                    // Wait 1/10th of a second
                    // Hence this loop runs at ~10hz.                
                    CanSenderLoopInner();
                    Thread.Sleep(100);
                } catch (System.Threading.ThreadAbortException) { };
            }
        }

        private void CanUpdateLoop()
        {
            while (true)
            {
                if (IsConnected())
                {
                    try
                    {
                        lock (updateLock)
                        {
                            while (CanQueue.TryDequeue(out CanPacket canPacket))
                            {
                                CanUpdateEventHandler?.Invoke(new CanReceivedEventArgs(canPacket));
                            }

                        }
                        Thread.Sleep(100);
                    }
                    catch (System.Threading.ThreadAbortException) { };
                }
            }
        }   
    }
}
