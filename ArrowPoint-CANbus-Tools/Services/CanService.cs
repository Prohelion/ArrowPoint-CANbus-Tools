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

    public sealed class CanService
    {

        private static readonly CanService instance = new CanService();

        private readonly object sendLock = new object();
        private readonly object updateLock = new object();

        private CancellationTokenSource senderCts = null;
        private CancellationTokenSource listenerCts = null;

        public event RequestConnectionStatusChangeDelegate RequestConnectionStatusChange;
        public event CanUpdateEventHandler CanUpdateEventHandler;

        public Hashtable LatestCanPacket { get; private set; } = new Hashtable();

        private ICanTrafficInterface canConnection;
        private List<string> selectedInterfaces;

        private ConcurrentQueue<CanPacket> CanQueue = new ConcurrentQueue<CanPacket>();
        private Hashtable canOn10Hertz = new Hashtable();        

        private Boolean sendImmediateMode = false;

        static CanService()
        {
        }

        public static CanService Instance
        {
            get
            {
                return instance;
            }
        }

        private CanService()
        {
        }

        // Connect via Local loopback (used for test purposes only)
        public Boolean ConnectViaLoopBack()
        {
            canConnection = new CanLoopback()
            {
                ReceivedCanPacketCallBack = ReceivedCanPacketCallBack,
                SelectedInterfaces = selectedInterfaces
            };
            sendImmediateMode = true;
            return PostConnect();
        }    

        public Boolean Connect(string ip, int port)
        {
            CanOverEthernet ethernetCanConnection = new CanOverEthernet()
            {
                Ip = ip,
                Port = port,
                ReceivedCanPacketCallBack = ReceivedCanPacketCallBack,
                SelectedInterfaces = selectedInterfaces
            };
            canConnection = (ICanTrafficInterface)ethernetCanConnection;
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
            canConnection?.Disconnect();
            StopBackgroundThreads();            
            RequestConnectionStatusChange?.Invoke(false);
        }

        public Boolean IsConnected()
        {
            if (canConnection == null)
                return false;

            return canConnection.IsConnected();
        }

        public Dictionary<string, string> AvailableInterfaces
        {
            get
            {
                if (canConnection != null)
                    return canConnection.AvailableInterfaces;
                else
                    return new CanOverEthernet().AvailableInterfaces;
            }
        }

        public List<string> SelectedInterfaces {
            get
            {
                if (canConnection != null)
                    return canConnection.SelectedInterfaces;
                else
                    return selectedInterfaces;
            }
            set
            {
                selectedInterfaces = value;

                if (canConnection != null)
                {                    
                    canConnection.SelectedInterfaces = selectedInterfaces;                    
                }
                    
            }
        }

        private void ClearCanQueue()
        {
            CanQueue = new ConcurrentQueue<CanPacket>();
        }

        public void ClearLastCanPacket()
        {
            LatestCanPacket.Clear();
        }

        public void SetCanToSendAt10Hertz(CanPacket canPacket)
        {
            if (canOn10Hertz.ContainsKey(canPacket.CanId))
            {
                canOn10Hertz.Remove(canPacket.CanId);
            }

            canOn10Hertz.Add(canPacket.CanId, canPacket);

            if (sendImmediateMode)
            {
                CanSenderLoopInner();
                CanUpdateLoopInner();
            }
        }

        public void StopSendingCanAt10Hertz(CanPacket canPacket)
        {
            StopSendingCanAt10Hertz(canPacket.CanId);
        }

        public void StopSendingCanAt10Hertz(uint canId)
        {
            if (canOn10Hertz.ContainsKey(canId))
            {
                canOn10Hertz.Remove(canId);
            }
        }

        public bool IsPacketCurrent(uint canId, uint milliseconds)
        {
            CanPacket canPacket = LastestCanPacketById(canId);
            if (canPacket == null) return (false);

            return canPacket.MilisecondsSinceReceived <= milliseconds;
        }

        public int SendMessage(CanPacket canPacket)
        {
            if(IsConnected()) {

                int result = canConnection.SendMessage(canPacket);
                if (sendImmediateMode)
                {
                    CanSenderLoopInner();
                    CanUpdateLoopInner();
                }

                return result;
            }

            return -1;
        }

        public CanPacket LastestCanPacketById(uint canId)
        {
            if (LatestCanPacket == null)
                return null;

            return (CanPacket)LatestCanPacket[canId];
        }

        private void ReceivedCanPacketCallBack(CanPacket canPacket)
        {
            CanQueue.Enqueue(canPacket);
            if (LatestCanPacket.ContainsKey(canPacket.CanId))
            {
                LatestCanPacket.Remove(canPacket.CanId);
            }
            LatestCanPacket.Add(canPacket.CanId, canPacket);
        }
       
        private Boolean StartBackgroundThreads()
        {
            try
            {
                // If the threads are already going, don't restart them
                if (senderCts == null || senderCts.IsCancellationRequested)
                {
                    senderCts = new CancellationTokenSource();

                    // Pass the token to the cancelable operation.
                    ThreadPool.QueueUserWorkItem(new WaitCallback(CanSenderLoop), senderCts.Token);                    
                }

                if (listenerCts == null || listenerCts.IsCancellationRequested)
                {
                    listenerCts = new CancellationTokenSource();

                    ThreadPool.QueueUserWorkItem(new WaitCallback(CanUpdateLoop), listenerCts.Token);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void StopBackgroundThreads()
        {
            senderCts?.Cancel();
            listenerCts?.Cancel();
        }

        // This method mainly exists to enable testing
        // as it is very difficult to test threads it forces
        // the behaviour of the thread.
        private void CanSenderLoopInner()
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

        private void CanSenderLoop(object obj)
        {
            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                try
                {
                    if (token.IsCancellationRequested) break;                    
                    
                    // Wait 1/10th of a second
                    // Hence this loop runs at ~10hz.                
                    CanSenderLoopInner();
                    Thread.Sleep(100);
                } catch (System.Threading.ThreadAbortException) { };
            }
        }

        // This method mainly exists to enable testing
        // as it is very difficult to test threads it forces
        // the behaviour of the thread.
        private void CanUpdateLoopInner() {
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

        private void CanUpdateLoop(object obj)
        {

            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                if (token.IsCancellationRequested) break;

                if (IsConnected())
                {
                    CanUpdateLoopInner();
                }
            }
        }   
    }
}
