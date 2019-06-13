using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class CMU : CanReceivingComponent
    {
        private const uint ADDRESS_RANGE = 3;
        public const string CMU_ID = "CMU";

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

        public override uint State => CanReceivingComponent.STATE_NA;
        public override string StateMessage => STATE_NA_TEXT;

        public int[] CellVoltage = new int[8];
        
        public CMU(CanService canService, uint baseAddress) : base(canService, baseAddress, baseAddress + ADDRESS_RANGE, true )
        {
        }

        public override string ComponentID => CMU_ID;

        public int GetCellVoltage(int cellNo)
        {
            return (CellVoltage[cellNo]);
        }

        public void SetCellVoltage(int cellNo, int mv)
        {
            CellVoltage[cellNo] = mv;
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {
            
            long canOffset = canPacket.CanIdBase10 - BaseAddress;

            switch (canOffset) {
                case 0: // 601
                    CellTemp = (double)canPacket.GetInt16(3) / 10;
                    PCBTemp = (double)canPacket.GetInt16(2) / 10;
                    SerialNumber = canPacket.GetInt32(0);
                    break;
                case 1: // 602
                    Cell3mV = (double)canPacket.GetUInt16(3);
                    Cell2mV = (double)canPacket.GetUInt16(2);
                    Cell1mV = (double)canPacket.GetUInt16(1);
                    Cell0mV = (double)canPacket.GetUInt16(0);           
                    break;
                case 2: // 603
                    Cell7mV = (double)canPacket.GetUInt16(3);
                    Cell6mV = (double)canPacket.GetUInt16(2);
                    Cell5mV = (double)canPacket.GetUInt16(1);
                    Cell4mV = (double)canPacket.GetUInt16(0);
                    break;
                default: break;
            }
        }        
    }
}
