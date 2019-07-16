using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArrowPointCANBusTest.Services
{
    class TDKSimulator
    {

        private CancellationTokenSource listenerCts = null;

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

        static void Simulator(object obj)
        {

            CancellationToken token = (CancellationToken)obj;

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");

            TcpListener listener = new TcpListener(ipAddress, 500);

            TcpListener serverSocket = new TcpListener(ipAddress, 18342);
            int requestCount = 0;
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();            
            clientSocket = serverSocket.AcceptTcpClient();
            requestCount = 0;

            while ((true))
            {
                if (token.IsCancellationRequested) break;

                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[10025];
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));                    
                    string serverResponse = "NOTHING";

                    switch (dataFromClient.ToUpper())
                    {
                        case "IDN?": serverResponse = "LAMBDA"; break;
                    }

                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }

        public void Dispose()
        {
            listenerCts?.Cancel();
            listenerCts?.Dispose();
        }
    }
}
