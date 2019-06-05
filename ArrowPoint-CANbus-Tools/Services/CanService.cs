using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ArrowPointCANBusTool.Services
{

    public delegate void RequestConnectionStatusChangeDelegate(bool connected);
    public delegate void CanUpdateEventHandler(CanReceivedEventArgs e);

    public class CanService
    {

        public event RequestConnectionStatusChangeDelegate RequestConnectionStatusChange;
        public event CanUpdateEventHandler CanUpdateEventHandler;

        private ICanInterface canConnection;

        private List<CanPacket> CanList = new List<CanPacket>();
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

        private void ClearCanList()
        {
            CanList.Clear();
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
            CanList.Add(canPacket);
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
                try
                {
                    foreach (DictionaryEntry s in canOn10Hertz)
                    {
                        CanPacket canPacket = (CanPacket)s.Value;
                        canConnection.SendMessage(canPacket);
                    }
                }
                catch { };
            }
        }

        private void CanSenderLoop()
        {            

            while (true)
            {
                // Wait 1/10th of a second
                // Hence this loop runs at ~10hz.
                Thread.Sleep(100);
                CanSenderLoopInner();
            }
        }

        private void CanUpdateLoop()
        {
            while (true)
            {
                Thread.Sleep(100);

                // We take a copy so that if all this eventing is taking too long we are not adding more items to the list
                // Fix This.
                if (IsConnected())
                {
                    CanPacket[] canPacketListCopy = new CanPacket[CanList.Count];
                    CanList.GetRange(0, canPacketListCopy.Length).CopyTo(canPacketListCopy, 0);
                    ClearCanList();

                    foreach (CanPacket canPacket in canPacketListCopy)
                    {
                        CanUpdateEventHandler?.Invoke(new CanReceivedEventArgs(canPacket));
                    }
                }
            }
        }
    }
}
