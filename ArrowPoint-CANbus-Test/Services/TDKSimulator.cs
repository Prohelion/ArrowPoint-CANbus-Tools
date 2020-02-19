using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrowPointCANBusTest.Services
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    class TDKSimulator
    {
        private CancellationTokenSource listenerCts = null;

        private const string RESPONSE_OK = "OK";

        public string SimulatorIpAddress { get; set; } = "127.0.0.1";
        public int SimulatorIpPort { get; set; } = 13000;

        public float OutputVoltage { get; set; } = 0;
        public float OutputCurrent { get; set; } = 0;
        public float ActualVoltage { get; set; } = 0;
        public float ActualCurrent { get; set; } = 0;
        public string RMT { get; set; } = "LOC";
        public int Address { get; set; } = 5;
        private bool outputState = false;
        private bool setupDone = false;

        public bool BatteryConnected { get; set; } = false;

        public void StartSimulator()
        {
            ResetValues();
            Debug.WriteLine("Start Simulator");
            if (listenerCts == null || listenerCts.IsCancellationRequested)
            {
                listenerCts = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(new WaitCallback(Simulator), listenerCts.Token);
            }            
        }

        public void StopSimulator()
        {
            Debug.WriteLine("Stop Simulator");
            listenerCts?.Cancel();
        }


        public void ResetValues()
        {
            OutputVoltage = 0;
            OutputCurrent = 0;
            ActualVoltage = 0;
            ActualCurrent = 0;
            RMT = "LOC";
            Address = 5;
            outputState = false;
            setupDone = false;
            BatteryConnected = false;
        }

        private void Simulator(object obj)
        {
            CancellationToken token = (CancellationToken)obj;

            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse(SimulatorIpAddress);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, SimulatorIpPort);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    if (token.IsCancellationRequested) break;

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    if (server.Pending())
                    {

                        Debug.WriteLine("Accepting Connection");

                        TcpClient client = server.AcceptTcpClient();

                        data = null;

                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i = 0;

                        try
                        {
                            i = stream.Read(bytes, 0, bytes.Length);
                        } catch (IOException)
                        {
                            i = 0;
                        }

                        if (i != 0)
                        {

                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            // Strip the carrage return and line feed
                            data = data.Replace("\r\n", string.Empty);
                            data = data.Replace("\r", string.Empty);

                            // Process the data sent by the client.
                            data = data.ToUpper();

                            Debug.WriteLine("Received : " + data);

                            string response = "ERROR";
                            string format = "{0:000.00;-000.00;000.00}";

                            string indexString = data;
                            string dataString = "";
                            if (indexString.IndexOf(' ') > -1)
                            {
                                indexString = data.Substring(0, data.IndexOf(' '));
                                dataString = data.Substring(data.IndexOf(' ') + 1);
                            }

                            Debug.WriteLine("Index : " + indexString);
                            Debug.WriteLine("Data : " + dataString);

                            if (!indexString.Equals("ADR") && !setupDone)
                                response = "E01";
                            else
                                switch (indexString)
                                {
                                    case "RMT?": response = RMT; break;
                                    case "IDN?": response = "LAMBDA"; break;
                                    case "OUT?": if (outputState) response = "ON"; else response = "OFF"; break;
                                    // Actual output current
                                    case "PC?": response = string.Format(format, OutputCurrent); break;
                                    // Actual output voltage
                                    case "PV?": response = string.Format(format, OutputVoltage); break;
                                    // Actual output current
                                    case "MC?": if (BatteryConnected) response = string.Format(format, ActualCurrent); else
                                                response = string.Format(format, 0); 
                                                break;
                                    // Actual output voltage
                                    case "MV?": response = string.Format(format, ActualVoltage); break;

                                    // Reset
                                    case "RST":
                                        OutputCurrent = 0; OutputVoltage = 0;
                                        ActualCurrent = 0; ActualVoltage = 0;
                                        outputState = false; break;

                                    case "ADR":
                                        Address = int.Parse(dataString);
                                        response = RESPONSE_OK;
                                        setupDone = true; break;

                                    case "PV":
                                        OutputVoltage = float.Parse(dataString);
                                        ActualVoltage = OutputVoltage;
                                        response = RESPONSE_OK; break;

                                    case "PC":
                                        OutputCurrent = float.Parse(dataString);
                                        ActualCurrent = OutputCurrent;
                                        response = RESPONSE_OK; break;

                                    case "OUT":
                                        outputState = int.Parse(dataString) == 1;
                                        response = RESPONSE_OK; break;

                                    case "RMT":
                                        RMT = dataString;
                                        response = RESPONSE_OK; break;

                                }

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(response + '\r');

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);

                            Debug.WriteLine("Response : " + response);
                        }

                        // Shutdown and end connection
                        Debug.WriteLine("Shutting client connection");
                        client.Close();
                    }
                }
            }
            catch (SocketException e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                // Stop listening for new clients.
                Debug.WriteLine("Shutting server");                
                server.Stop();
            }
        }

    }
}
