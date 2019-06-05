using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class CMU : ICanInterface
    {

        private int BaseAddress { get; set; } = 0;
        private const int AddressRange = 3;
        private int TopAddress { get; set; } = 0;

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
            this.BaseAddress = baseAddress;
            this.TopAddress = baseAddress + AddressRange - 1;
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
            if (packet.CanIdBase10 >= BaseAddress && packet.CanIdBase10 <= TopAddress)
                return (true);
            else
                return (false);
        }
        
        public void Update(CanPacket packet)
        {
            
            // Only try and update if it is in range of this device
            if (!InRange(packet)) return;

            int canOffset = (int)packet.CanIdBase10 - BaseAddress;

            switch (canOffset) {
                case 0: // 601
                    CellTemp = (double)packet.GetInt16(3) / 10;
                    PCBTemp = (double)packet.GetInt16(2) / 10;
                    SerialNumber = packet.GetInt32(0);
                    break;
                case 1: // 602
                    Cell3mV = (double)packet.GetUInt16(3);
                    Cell2mV = (double)packet.GetUInt16(2);
                    Cell1mV = (double)packet.GetUInt16(1);
                    Cell0mV = (double)packet.GetUInt16(0);           
                    break;
                case 2: // 603
                    Cell7mV = (double)packet.GetUInt16(3);
                    Cell6mV = (double)packet.GetUInt16(2);
                    Cell5mV = (double)packet.GetUInt16(1);
                    Cell4mV = (double)packet.GetUInt16(0);
                    break;
                default: break;
            }

        }    

    }
}
