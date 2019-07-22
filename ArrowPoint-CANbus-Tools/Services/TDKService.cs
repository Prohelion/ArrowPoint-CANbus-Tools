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

        private static readonly Object comms_locker = new Object();

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
        public int ChargerId { get; set; } = 5;
        private bool ChargerInitialised = false;

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

        public static TDKService NewInstance
        {
            get
            {
                return new TDKService();
            }
        }

        private TDKService() : base(0, 0)
        {
            if (listenerCts == null || listenerCts.IsCancellationRequested)
            {
                listenerCts = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(new WaitCallback(Update), listenerCts.Token);
            }
        }

        public override uint State
        {
            get
            {
                return state;
            }
        }

        public override string StateMessage
        {
            get
            {
                return stateMessage;
            }
        }

        private string SendMessageGetResponseInner(String message)
        {

            lock (comms_locker)
            {

                TcpClient client = null;
                NetworkStream stream = null;

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
                while (delayed < 2000)
                {
                    char finalChar = ' ';

                    if (responseData != null && responseData != String.Empty)
                        finalChar = responseData[responseData.Length - 1];

                    if (finalChar != '\r')
                    {
                        Int32 bytes = stream.Read(data, 0, data.Length);
                        responseData = responseData + System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    }
                    else break;
                    Thread.Sleep(10);
                    delayed = delayed + 10;
                }

                if (responseData != String.Empty)
                {
                    responseData = responseData.Replace("\r\n", string.Empty);
                    responseData = responseData.Replace("\r", string.Empty);
                }

                // Close everything.
                stream?.Close();
                client?.Close();

                return responseData;
            }
        }


        public string SendMessageGetResponse(String message)
        {
            try
            {
                if (!ChargerInitialised)
                {
                    if (!SendMessageGetResponseInner("ADR " + ChargerId).Equals("OK"))
                        return ("ERROR");
                    ChargerInitialised = true;
                }

                string response = SendMessageGetResponseInner(message);
                if (response == null)
                    response = SendMessageGetResponseInner(message);
                return response;
            } catch
            {
                return null;
            }
        }        

        private void UpdateStatus()
        {
            string chargerId = SendMessageGetResponse(TDK_GET_CHARGER_ID);

            if (chargerId == null)
            {
                state = CanReceivingNode.STATE_NA;
                stateMessage = "N/A - No TDK data";
                return;
            }

            uint finalState = CanReceivingNode.STATE_NA;
            string finalStateMessage = "";

            string outputState = SendMessageGetResponse(TDK_GET_CHARGER_OUTPUT_STATE);

            if (outputState == null)
            {
                finalState = CanReceivingNode.STATE_NA;
            } else
            if (outputState.Equals("ON"))
            {
                finalState = CanReceivingNode.STATE_ON;
                finalStateMessage = CanReceivingNode.STATE_ON_TEXT;
            }
            else
            {
                finalState = CanReceivingNode.STATE_IDLE;
                finalStateMessage = CanReceivingNode.STATE_IDLE_TEXT;
            }

            state = finalState;
            stateMessage = finalStateMessage;
        }

        public void ChargerUpdateInner()
        {
            if (float.TryParse(SendMessageGetResponse(TDK_GET_CHARGER_VOLTAGE), out float returnChargerVoltage) &&
                  float.TryParse(SendMessageGetResponse(TDK_GET_CHARGER_CURRENT), out float returnChargerCurrent))
            {

                ActualVoltage = returnChargerVoltage;
                ActualCurrent = returnChargerCurrent;

                // Calculate and send updated dynamic current limit based on pack voltage
                if (ActualVoltage > 0.0f)
                {
                    ChargerCurrentLimit = ChargerPowerLimit / ActualVoltage;

                    if (ChargerCurrentLimit > TDK_CURRENT_LIMIT)
                    {
                        ChargerCurrentLimit = TDK_CURRENT_LIMIT;
                    }
                }

                if (chargeOutputOn)
                {
                    // We use the receipt of the update request to send the charger the latest power details

                    // Update voltage requested by the ChargeService
                    SendMessageGetResponse(TDK_SET_CHARGER_VOLTAGE + RequestedVoltage);

                    // Update current requested by the ChargeService
                    SendMessageGetResponse(TDK_SET_CHARGER_CURRENT + RequestedCurrent);

                }
            }

            UpdateStatus();
        }

        private void Update(object obj)
        {
            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                if (token.IsCancellationRequested) break;
                if (chargeOutputOn) ChargerUpdateInner();
                UpdateStatus();
                Thread.Sleep(1000);
            }
        }

        public override void StartCharge()
        {
            chargeOutputOn = true;

            SendMessageGetResponse(TDK_SET_CHARGER_STATE_ON);
            // Update voltage requested by the ChargeService
            SendMessageGetResponse(TDK_SET_CHARGER_VOLTAGE + RequestedVoltage);
            // Update current requested by the ChargeService
            SendMessageGetResponse(TDK_SET_CHARGER_CURRENT + RequestedCurrent);

            string chargeState = SendMessageGetResponse(TDK_GET_CHARGER_OUTPUT_STATE);

            UpdateStatus();

        }

        public override void StopCharge()
        {

            chargeOutputOn = false;

            SendMessageGetResponse(TDK_SET_CHARGER_STATE_OFF);

            UpdateStatus();
        }
    }
}
