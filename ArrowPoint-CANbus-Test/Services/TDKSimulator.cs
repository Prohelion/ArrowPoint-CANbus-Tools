using System;
using System.Collections.Generic;
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

        private float outputVoltage = 0;
        private float outputCurrent = 0;
        private float actualVoltage = 0;
        private float actualCurrent = 0;
        private int address = 5;
        private bool outputState = false;

        public void StartSimulator()
        {
            if (listenerCts == null || listenerCts.IsCancellationRequested)
            {
                listenerCts = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(new WaitCallback(Simulator), listenerCts.Token);
            }
        }

        public void StopSimulator()
        {            
            listenerCts?.Cancel();
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

                        TcpClient client = server.AcceptTcpClient();

                        data = null;

                        // Get a stream object for reading and writing
                        NetworkStream stream = client.GetStream();

                        int i;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            // Process the data sent by the client.
                            data = data.ToUpper();

                            string response = "ERROR";
                            string format = "{0:000.00;-000.00;000.00}";

                            string indexString = data;
                            string dataString = "";
                            if (indexString.IndexOf(' ') > -1)
                            {
                                indexString = data.Substring(0, data.IndexOf(' '));
                                dataString = data.Substring(data.IndexOf(' ')+1);
                            }                                

                            switch (indexString)
                            {
                                case "RMT?": response = "LOC"; break;
                                case "IDN?": response = "LAMBDA"; break;
                                case "OUT?": if (outputState) response = "ON"; else response = "OFF"; break;
                                // Actual output current
                                case "PC?": response = string.Format(format, outputCurrent); break;
                                // Actual output voltage
                                case "PV?": response = string.Format(format, outputVoltage); break;
                                // Actual output current
                                case "MC?": response = string.Format(format, actualCurrent); break;
                                // Actual output voltage
                                case "MV?": response = string.Format(format, actualVoltage); break;

                                // Reset
                                case "RST": outputCurrent = 0; outputVoltage = 0;
                                            actualCurrent = 0; actualVoltage = 0;
                                            outputState = false; break;

                                case "ADR": address = int.Parse(dataString);
                                            response = RESPONSE_OK; break;

                                case "PV":  outputVoltage = float.Parse(dataString);
                                            actualVoltage = outputVoltage;
                                            response = RESPONSE_OK; break;

                                case "PC":  outputCurrent = float.Parse(dataString);
                                            actualCurrent = outputCurrent;
                                            response = RESPONSE_OK; break;

                                case "OUT": outputState = int.Parse(dataString) == 1;
                                            response = RESPONSE_OK; break;



                            }

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                        }

                        // Shutdown and end connection
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
                server.Stop();
            }
        }

    }
}
