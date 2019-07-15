using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Services
{
    class TDKLambdaService : IChargerInterface
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        public float VoltageRequested { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float CurrentRequested { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float ChargerVoltage => throw new NotImplementedException();

        public float ChargerCurrent => throw new NotImplementedException();

        public uint ChargerStatus => throw new NotImplementedException();

        public float SupplyVoltageLimit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float SupplyCurrentLimit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public float ChargerVoltageLimit => throw new NotImplementedException();

        public float ChargerCurrentLimit => throw new NotImplementedException();

        public float ChargerPowerLimit => throw new NotImplementedException();

        public float ChargerEfficiency => throw new NotImplementedException();

        public bool IsHardwareOk => throw new NotImplementedException();

        public bool IsTempOk => throw new NotImplementedException();

        public bool IsCommsOk => throw new NotImplementedException();

        public bool IsACOk => throw new NotImplementedException();

        public bool IsDCOk => throw new NotImplementedException();

        public bool IsCharging => throw new NotImplementedException();

        public uint State => throw new NotImplementedException();

        public string StateMessage => throw new NotImplementedException();

        public string ComponentID => throw new NotImplementedException();

        public void StartCharge()
        {
            clientSocket.Connect("127.0.0.1", 8888);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("TEST");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
        }

        public void StopCharge()
        {
            clientSocket.Close();
        }
    }
}
