using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Canbus;
using System.Text.RegularExpressions;

namespace ArrowPointCANBusTool.Services
{
    public class TDKService : ChargerServiceBase
    {
        private static readonly TDKService instance = new TDKService();

        public override string ComponentID => "TDK";

        private const float TDK_VOLTAGE_LIMIT = 300.0f;
        private const float TDK_CURRENT_LIMIT = 5.0f;
        private const float TDK_POWER_LIMIT = 1500.0f;

        private const string TDK_GET_CHARGER_VOLTAGE = "MV?";
        private const string TDK_GET_CHARGER_CURRENT = "MC?";
        private const string TDK_GET_CHARGER_OUTPUT_STATE = "OUT?";
        private const string TDK_GET_CHARGER_ID = "IDN?";        
        private const string TDK_SET_CHARGER_VOLTAGE = "PV ";
        private const string TDK_SET_CHARGER_CURRENT = "PC ";
        private const string TDK_SET_CHARGER_STATE_ON = "OUT 1";
        private const string TDK_SET_CHARGER_STATE_OFF = "OUT 0";

        public string ChargerIpAddress { get; set; }
        public int ChargerIpPort { get; set; }

        public override float ChargerVoltageLimit { get; protected set; } = TDK_VOLTAGE_LIMIT;
        public override float ChargerCurrentLimit { get; protected set; } = TDK_CURRENT_LIMIT;
        public override float ChargerPowerLimit { get; protected set; } = TDK_POWER_LIMIT;
        public override float ChargerEfficiency => 0.9f;

        public override bool IsHardwareOk => true;
        public override bool IsTempOk => true;
        public override bool IsCommsOk => true;
        public override bool IsACOk => true;
        public override bool IsDCOk => true;

        public override bool IsCharging
        {
            get
            {
                UpdateStatus();
                return (state == CanReceivingNode.STATE_ON);
            }
        }

        private Boolean chargeOutputOn = false;
        private uint state = CanReceivingNode.STATE_NA;
        private string stateMessage = CanReceivingNode.STATE_NA_TEXT;

        private CancellationTokenSource listenerCts;

        static TDKService()
        {
        }

        public static TDKService Instance
        {
            get
            {
                return instance;
            }
        }

        private TDKService() : base(0,0)
        {
        }

        public string SendMessageGetResponse(String message)
        {

            if (ChargerIpAddress == null || ChargerIpAddress.Length == 0) return "";

            TcpClient client = null;
            NetworkStream stream = null;

            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.                
                client = new TcpClient(ChargerIpAddress, ChargerIpPort);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message + "\r\n");

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                stream = client.GetStream();

                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                int delayed = 0;

                // Read the first batch of the TcpServer response bytes.
                while (delayed < 5000)
                { 
                    if (stream.DataAvailable)
                    {
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        responseData = responseData.Replace("\r\n", string.Empty);
                        responseData = responseData.Replace("\r", string.Empty);
                        break;
                    }
                    Thread.Sleep(10);
                    delayed = delayed + 10;
                }

                // Close everything.
                stream?.Close();
                client?.Close();

                return responseData;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            } finally
            {
                // Close everything.
                stream?.Close();
                client?.Close();
            }

            return null;
            
        }

        // Artifact of our structure that this exists, but it should never be used as the TDK is not can enabled
        // TDK Charger uses a timer instead
        public override void CanPacketReceived(CanPacket canPacket)
        {
            throw new NotImplementedException();
        }

        private void UpdateStatus()
        {
            state = CanReceivingNode.STATE_NA;
            stateMessage = "";

            if (SendMessageGetResponse(TDK_GET_CHARGER_ID) == null)
            {
                state = CanReceivingNode.STATE_NA;
                stateMessage = "N/A - No TDK data";
                return;
            }
            
            if (SendMessageGetResponse(TDK_GET_CHARGER_OUTPUT_STATE).Equals("ON"))
            {
                state = CanReceivingNode.STATE_ON;
                stateMessage = CanReceivingNode.STATE_ON_TEXT;
            }
            else
            {
                state = CanReceivingNode.STATE_IDLE;
                stateMessage = CanReceivingNode.STATE_IDLE_TEXT;
            }
        }

        public new uint State
        {
            get
            {
                UpdateStatus();
                return state;
            }
        }

        public new string StateMessage
        {
            get
            {
                UpdateStatus();
                return stateMessage;
            }
        }


        public void UpdateInner()
        {
            if (float.TryParse(SendMessageGetResponse(TDK_GET_CHARGER_VOLTAGE), out float returnChargerVoltage) &&
                  float.TryParse(SendMessageGetResponse(TDK_GET_CHARGER_CURRENT), out float returnChargerCurrent))
            {

                ChargerVoltage = returnChargerVoltage;
                ChargerCurrent = returnChargerCurrent;

                // Calculate and send updated dynamic current limit based on pack voltage
                if (ChargerVoltage > 0.0f)
                {
                    ChargerCurrentLimit = ChargerPowerLimit / ChargerVoltage;

                    if (ChargerCurrentLimit > TDK_CURRENT_LIMIT)
                    {
                        ChargerCurrentLimit = TDK_CURRENT_LIMIT;
                    }
                }

                if (chargeOutputOn)
                {
                    // We use the receipt of the update request to send the charger the latest power details

                    // Update voltage requested by the ChargeService
                    SendMessageGetResponse(TDK_SET_CHARGER_VOLTAGE + VoltageRequested);

                    // Update current requested by the ChargeService
                    SendMessageGetResponse(TDK_SET_CHARGER_CURRENT + CurrentRequested);

                }
                UpdateStatus();
            }
        }

        private void Update(object obj)
        {
            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                if (token.IsCancellationRequested) break;
                UpdateInner();
            }
        }

        public override void StartCharge()
        {
            chargeOutputOn = true;

            SendMessageGetResponse(TDK_SET_CHARGER_STATE_ON);

            if (SendMessageGetResponse(TDK_GET_CHARGER_OUTPUT_STATE).Equals("ON"))
            {
                if (listenerCts == null || listenerCts.IsCancellationRequested)
                {
                    listenerCts = new CancellationTokenSource();

                    ThreadPool.QueueUserWorkItem(new WaitCallback(Update), listenerCts.Token);
                }
            }

        }

        public override void StopCharge()
        {
            SendMessageGetResponse(TDK_SET_CHARGER_STATE_OFF);

            listenerCts?.Cancel();            
        }
    }
}
