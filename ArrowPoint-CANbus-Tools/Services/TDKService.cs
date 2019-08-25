using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ArrowPointCANBusTool.Canbus;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ArrowPointCANBusTool.Services
{
    public class TDKService : ChargerServiceBase
    {
        private static readonly TDKService instance = new TDKService();

        private static readonly Object comms_locker = new Object();
        private static readonly Object update_locker = new Object();

        public override string ComponentID => "TDK";
        private const string ERROR_STR = "ERROR";

        private bool stateUpdated = false;

        private const float TDK_VOLTAGE_LIMIT = 300.0f;
        private const float TDK_CURRENT_LIMIT = 10.0f;
        private const float TDK_POWER_LIMIT = 3000.0f;

        private const string TDK_GET_CHARGER_VOLTAGE = "MV?";
        private const string TDK_GET_CHARGER_CURRENT = "MC?";
        private const string TDK_GET_CHARGER_OUTPUT_STATE = "OUT?";
        private const string TDK_GET_CHARGER_ID = "IDN?";
        private const string TDK_SET_CHARGER_VOLTAGE = "PV ";
        private const string TDK_SET_CHARGER_CURRENT = "PC ";
        private const string TDK_SET_CHARGER_STATE_ON = "OUT 1";
        private const string TDK_SET_CHARGER_STATE_OFF = "OUT 0";

        public string ChargerIpAddress { get; private set; }
        public int ChargerIpPort { get; private set; }
        public int ChargerId { get; set; } = 5;
        private bool ChargerInitialised = false;

        private TcpClient client = null;

        public override float ChargerVoltageLimit { get; protected set; } = TDK_VOLTAGE_LIMIT;
        public override float ChargerCurrentLimit { get; protected set; } = TDK_CURRENT_LIMIT;
        public override float ChargerPowerLimit { get; protected set; } = TDK_POWER_LIMIT;
        public override float ChargerEfficiency => 0.9f;

        public override bool IsHardwareOk => true;
        public override bool IsTempOk => true;
        public override bool IsCommsOk => true;
        public override bool IsACOk => true;
        public override bool IsDCOk {
            get
            {
                if (RequestedCurrent > 0 && ActualCurrent == 0)
                    return false;
                else return true;
            }
        }

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
        }

        public void Connect(string ipAddress, int port)
        {
            this.ChargerIpAddress = ipAddress;
            this.ChargerIpPort = port;

            UpdateStatus();

            if (listenerCts == null || listenerCts.IsCancellationRequested)
            {
                listenerCts = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(new WaitCallback(Update), listenerCts.Token);
            }
        }

        public void Disconnect()
        {
            StopCharge();
            listenerCts?.Cancel();
        }

        public override uint State
        {
            get
            {
                if (!stateUpdated) UpdateStatus();
                return state;
            }
        }

        public override string StateMessage
        {
            get
            {
                if (!stateUpdated) UpdateStatus();
                return stateMessage;
            }
        }

        private string SendMessageGetResponseInner(String message)
        {

            if (ChargerIpAddress == null || ChargerIpPort == 0) return (ERROR_STR);            

            lock (comms_locker)
            {
                NetworkStream stream = null;

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message + "\r\n");

                // Get a client stream for reading and writing, we try to reuse them so only do this if necessary
                if (client == null || client.Connected == false)
                {
                    client = new TcpClient
                    {
                        ReceiveTimeout = 500
                    };
                    client.ConnectAsync(ChargerIpAddress, ChargerIpPort).Wait(500);
                }

                if (client == null || client.Connected == false) return (ERROR_STR);

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
                while (delayed < 1000)
                {
                    char finalChar = ' ';

                    if (responseData != null && responseData != String.Empty)
                        finalChar = responseData[responseData.Length - 1];

                    if (finalChar != '\r')
                    {
                        Int32 bytes = 0;

                        try
                        {
                            bytes = stream.Read(data, 0, data.Length);
                            responseData = responseData + System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                        }
                        catch
                        {
                            // Read error, lets leave the loop
                            break;
                        }
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
                        return (ERROR_STR);
                    ChargerInitialised = true;
                }

                string response = SendMessageGetResponseInner(message);

                // Try again on an error
                if (response == null || response.Equals(ERROR_STR))
                    response = SendMessageGetResponseInner(message);
                return response;
            }
            catch
            {
                return ERROR_STR;
            }
        }

        private void UpdateStatus()
        {

            stateUpdated = true;

            string chargerId = SendMessageGetResponse(TDK_GET_CHARGER_ID);

            if (chargerId == null || chargerId.Equals("") || chargerId == "ERROR_STR")
            {
                state = CanReceivingNode.STATE_NA;
                stateMessage = "N/A - No TDK data";
                ChargerInitialised = false;
                return;
            }

            uint finalState = CanReceivingNode.STATE_NA;
            string finalStateMessage = "";

            string outputState = SendMessageGetResponse(TDK_GET_CHARGER_OUTPUT_STATE);

            if (outputState == null || outputState == "ERROR")
            {
                finalState = CanReceivingNode.STATE_NA;
                ChargerInitialised = false;
            }
            else
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

        private async void Update(object obj)
        {
            CancellationToken token = (CancellationToken)obj;

            while (true)
            {
                if (token.IsCancellationRequested) break;
                if (chargeOutputOn) ChargerUpdateInner();
                UpdateStatus();
                await Task.Delay(1000);
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
