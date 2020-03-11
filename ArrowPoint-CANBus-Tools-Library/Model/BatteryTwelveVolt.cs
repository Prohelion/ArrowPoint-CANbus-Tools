using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using Prohelion.CanLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class BatteryTwelveVolt : CanReceivingNode
    {
        private const uint ADDRESS_RANGE = 6;
        public const string CMU_ID = "BATTERY12V";
        private const uint VALID_MILLI = 5000;

        public const uint FLAG_OV = 0x0001;	//Cell over voltage
        public const uint FLAG_UV = 0x0002;	//Cell under voltage
        public const uint FLAG_OT = 0x0004;	//Cell over temperature
        public const uint FLAG_BAL = 0x0008; //Atleast 1 Cell is balancing
        public const uint FLAG_BMU_TOUT = 0x0010;	//Havent received telemetry from the BMU
        public const uint FLAG_ESTOP = 0x0020;	//The Estop circuit is open (Estop button pressed)

        public int? SerialNumber { get { if (LatestPacket(0) != null) return LatestPacket(0).Int32Pos1; else return null; } }
        public int? DeviceId { get { if (LatestPacket(0) != null) return LatestPacket(0).Int32Pos0; else return null; } }

        public double? CellTemp { get { if (LatestPacket(3) != null) return (double)LatestPacket(3).UShort16Pos0 / 10; else return null; } }

        public uint? Cell3mV { get { if (LatestPacket(4) != null) return LatestPacket(4).UShort16Pos3; else return null; } }
        public uint? Cell2mV { get { if (LatestPacket(4) != null) return LatestPacket(4).UShort16Pos2; else return null; } }
        public uint? Cell1mV { get { if (LatestPacket(4) != null) return LatestPacket(4).UShort16Pos1; else return null; } }
        public uint? Cell0mV { get { if (LatestPacket(4) != null) return LatestPacket(4).UShort16Pos0; else return null; } }

        public uint? Net12vCurrent { get { if (LatestPacket(5) != null) return LatestPacket(5).UShort16Pos1; else return null; } }
        public uint? HVDc2DcCurrent { get { if (LatestPacket(5) != null) return LatestPacket(5).UShort16Pos0; else return null; } }
        
        public uint? StatusFlags { get { if (LatestPacket(6) != null) return LatestPacket(6).UShort16Pos1; else return null; } }
        public uint? StatusEvents { get { if (LatestPacket(6) != null) return LatestPacket(6).UShort16Pos0; else return null; } }
        
        public override string ComponentID => CMU_ID;

        public BatteryTwelveVolt(uint baseAddress, bool timeoutApplies) : base(baseAddress, baseAddress + ADDRESS_RANGE, timeoutApplies ? VALID_MILLI : 0, true) { }

        public override void CanPacketReceived(CanPacket canPacket) {  }
    }
}
