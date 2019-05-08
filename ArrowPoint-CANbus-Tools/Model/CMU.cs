using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowWareDiagnosticTool.Model
{
    class CMU : CanModel
    {

        private int baseAddress = 0;
        private int addressRange = 3;
        private int topAddress = 0;

        public int CellTemperature { get; set; }
        public int PCBTemperature { get; set; }
        public int SerialNumber { get; set; }

        public int[] CellVoltage = new int[8];
        
        public CMU(int baseAddress)
        {
            this.baseAddress = baseAddress;
            this.topAddress = baseAddress + addressRange;
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
                    CellTemperature = packet.getInt16(6);
                    PCBTemperature = packet.getInt16(4);
                    SerialNumber = packet.getInt32(0);
                    break;
                case 1: // 602
                    CellVoltage[3] = packet.getInt16(6);
                    CellVoltage[2] = packet.getInt16(4);
                    CellVoltage[1] = packet.getInt16(2);
                    CellVoltage[0] = packet.getInt16(0);
                    break;
                case 2: // 603
                    CellVoltage[3] = packet.getInt16(6);
                    CellVoltage[2] = packet.getInt16(4);
                    CellVoltage[1] = packet.getInt16(2);
                    CellVoltage[0] = packet.getInt16(0);
                    break;
                default: break;
            }

        }    

    }
}
