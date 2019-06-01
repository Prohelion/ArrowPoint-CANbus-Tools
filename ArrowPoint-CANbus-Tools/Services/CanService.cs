using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{

    public delegate void RequestConnectionStatusChangeDelegate(bool connected);
    public delegate void CanUpdateEventHandler(CanReceivedEventArgs e);

    public class CanService
    {

        public event RequestConnectionStatusChangeDelegate RequestConnectionStatusChange;
        public event CanUpdateEventHandler CanUpdateEventHandler;
        public List<CanPacket> CanList = new List<CanPacket>();

        private ICanInterface canConnection;
        private Hashtable canOn10Hertz = new Hashtable();
        private Hashtable LastCanPacket = new Hashtable();
        private Thread UdpSenderThread;
        private System.Timers.Timer aTimer;

        public CanService()
        {
        }
              
        internal void Close()
        {
            canConnection.Disconnect();
            RequestConnectionStatusChange(false);
        }

        public Boolean Connect(string ip, int port)
        {
            // Create this early as the event registrations occur prior to a connection
            canConnection = new CanOverEthernet(ip,port,ReceivedCanPacketCallBack);
            StartTimer();

            Boolean result = canConnection.Connect();            
            if (result) RequestConnectionStatusChange(true);
            return result;
        }

        public void Disconnect()
        {
            canConnection.Disconnect();
            RequestConnectionStatusChange(false);
        }

        public Boolean IsConnected()
        {
            if (canConnection == null)
                return false;

            return canConnection.IsConnected();
        }

        public void ClearCanList()
        {
            CanList.Clear();
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
            return canConnection.SendMessage(canPacket);
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

        private void StartTimer()
        {
            aTimer = new System.Timers.Timer
            {
                Interval = 100,
                AutoReset = true,
                Enabled = true                
            };

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // We take a copy so that if all this eventing is taking too long we are not adding more items to the list
            // Fix This.
            CanPacket[] canPacketListCopy = new CanPacket[CanList.Count];
            CanList.GetRange(0,canPacketListCopy.Length).CopyTo(canPacketListCopy, 0);
            ClearCanList();

            foreach (CanPacket canPacket in canPacketListCopy)
            {
                CanUpdateEventHandler?.Invoke(new CanReceivedEventArgs(canPacket));
            }        
        }

        private Boolean StartSender()
        {

            try
            {
                UdpSenderThread = new Thread(CanSenderLoop);
                UdpSenderThread.Start();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void StopSender()
        {
            UdpSenderThread.Abort();
        }

        private void CanSenderLoop()
        {
            while (this.IsConnected())
            {
                // Wait 1/10th of a second
                // Hence this loop runs at ~10hz.
                System.Threading.Thread.Sleep(100);

                try
                {
                    foreach (DictionaryEntry s in canOn10Hertz)
                    {
                        CanPacket canPacket = (CanPacket)s.Value;
                        canConnection.SendMessage(canPacket);
                    }
                }
                catch
                {
                    // Caught a big one!
                }
            }
        }

    }
}
