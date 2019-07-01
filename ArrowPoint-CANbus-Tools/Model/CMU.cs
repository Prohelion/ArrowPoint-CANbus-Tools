using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class CMU : CanReceivingNode
    {
        private const uint ADDRESS_RANGE = 3;
        public const string CMU_ID = "CMU";
        private const uint VALID_MILLI = 5000;

        public double? CellTemp { get { if (LatestPacket(0) != null) return (double)LatestPacket(0).Uint16Pos3 / 10; else return null; } }
        public double? PCBTemp { get { if (LatestPacket(0) != null) return (double)LatestPacket(0).Uint16Pos2 / 10; else return null; } }
        public int? SerialNumber { get { if (LatestPacket(0) != null) return LatestPacket(0).Int32Pos0; else return null; } }
        public uint? Cell0mV { get { if (LatestPacket(1) != null) return LatestPacket(1).Uint16Pos0; else return null; } }
        public uint? Cell1mV { get { if (LatestPacket(1) != null) return LatestPacket(1).Uint16Pos1; else return null; } }
        public uint? Cell2mV { get { if (LatestPacket(1) != null) return LatestPacket(1).Uint16Pos2; else return null; } }
        public uint? Cell3mV { get { if (LatestPacket(1) != null) return LatestPacket(1).Uint16Pos3; else return null; } }
        public uint? Cell4mV { get { if (LatestPacket(2) != null) return LatestPacket(2).Uint16Pos0; else return null; } }
        public uint? Cell5mV { get { if (LatestPacket(2) != null) return LatestPacket(2).Uint16Pos1; else return null; } }
        public uint? Cell6mV { get { if (LatestPacket(2) != null) return LatestPacket(2).Uint16Pos2; else return null; } }
        public uint? Cell7mV { get { if (LatestPacket(2) != null) return LatestPacket(2).Uint16Pos3; else return null; } }

        public override string ComponentID => CMU_ID;

        public CMU(uint baseAddress, bool timeoutApplies) : base(baseAddress, baseAddress + ADDRESS_RANGE, timeoutApplies ? VALID_MILLI : 0, true) { }

        public override void CanPacketReceived(CanPacket canPacket) { }
    }
}
