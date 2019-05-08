using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    class CMU : CanModel
    {

        private int baseAddress = 0;
        private int addressRange = 3;
        private int topAddress = 0;

        public double CellTemp { get; set; }
        public double PCBTemp { get; set; }
        public int SerialNumber { get; set; }
        public double Cell0mV { get; set; }
        public double Cell1mV { get; set; }
        public double Cell2mV { get; set; }
        public double Cell3mV { get; set; }
        public double Cell4mV { get; set; }
        public double Cell5mV { get; set; }
        public double Cell6mV { get; set; }
        public double Cell7mV { get; set; }
        public double Cell8mV { get; set; }

        public int[] CellVoltage = new int[8];
        
        public CMU(int baseAddress)
        {
            this.baseAddress = baseAddress;
            this.topAddress = baseAddress + addressRange - 1;
        }

        public int GetCellVoltage(int cellNo)
        {
            return (CellVoltage[cellNo]);
        }

        public void SetCellVoltage(int cellNo, int mv)
        {
            CellVoltage[cellNo] = mv;
        }

        public Boolean InRange(CanPacket packet)
        {
            if (packet.canIdBase10 >= baseAddress && packet.canIdBase10 <= topAddress)
                return (true);
            else
                return (false);
        }
        
        public void Update(CanPacket packet)
        {
            
            // Only try and update if it is in range of this device
            if (!InRange(packet)) return;

            int canOffset = packet.getCanIdBase10() - baseAddress;

            switch (canOffset) {
                case 0: // 601
                    CellTemp = (double)packet.getInt16(3) / 10;
                    PCBTemp = (double)packet.getInt16(2) / 10;
                    SerialNumber = packet.getInt32(0);
                    break;
                case 1: // 602
                    Cell3mV = (double)packet.getUInt16(3) / 1000;
                    Cell2mV = (double)packet.getUInt16(2) / 1000;
                    Cell1mV = (double)packet.getUInt16(1) / 1000;
                    Cell0mV = (double)packet.getUInt16(0) / 1000;                    
                    break;
                case 2: // 603
                    Cell7mV = (double)packet.getUInt16(3) / 1000;
                    Cell6mV = (double)packet.getUInt16(2) / 1000;
                    Cell5mV = (double)packet.getUInt16(1) / 1000;
                    Cell4mV = (double)packet.getUInt16(0) / 1000;
                    break;
                default: break;
            }

        }    

    }
}
