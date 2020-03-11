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
    public class CMU : CanReceivingNode
    {
        private const uint ADDRESS_RANGE = 3;
        public const string CMU_ID = "CMU";
        private const uint VALID_MILLI = 5000;

        public double? CellTemp { get { CanPacket latestPacket = LatestPacket(0); if (latestPacket != null) return (double)latestPacket.UShort16Pos3 / 10; else return null; } }
        public double? PCBTemp { get { CanPacket latestPacket = LatestPacket(0); if (latestPacket != null) return (double)latestPacket.UShort16Pos2 / 10; else return null; } }
        public int? SerialNumber { get { CanPacket latestPacket = LatestPacket(0); if (latestPacket != null) return latestPacket.Int32Pos0; else return null; } }
        public uint? Cell0mV { get { CanPacket latestPacket = LatestPacket(1); if (latestPacket != null) return latestPacket.UShort16Pos0; else return null; } }
        public uint? Cell1mV { get { CanPacket latestPacket = LatestPacket(1); if (latestPacket != null) return latestPacket.UShort16Pos1; else return null; } }
        public uint? Cell2mV { get { CanPacket latestPacket = LatestPacket(1); if (latestPacket != null) return latestPacket.UShort16Pos2; else return null; } }
        public uint? Cell3mV { get { CanPacket latestPacket = LatestPacket(1); if (latestPacket != null) return latestPacket.UShort16Pos3; else return null; } }
        public uint? Cell4mV { get { CanPacket latestPacket = LatestPacket(2); if (latestPacket != null) return latestPacket.UShort16Pos0; else return null; } }
        public uint? Cell5mV { get { CanPacket latestPacket = LatestPacket(2); if (latestPacket != null) return latestPacket.UShort16Pos1; else return null; } }
        public uint? Cell6mV { get { CanPacket latestPacket = LatestPacket(2); if (latestPacket != null) return latestPacket.UShort16Pos2; else return null; } }
        public uint? Cell7mV { get { CanPacket latestPacket = LatestPacket(2); if (latestPacket != null) return latestPacket.UShort16Pos3; else return null; } }
        public override string ComponentID => CMU_ID;        
        public CMU(uint baseAddress, bool timeoutApplies) : base(baseAddress, baseAddress + ADDRESS_RANGE, timeoutApplies ? VALID_MILLI : 0, true) { }
        public override void CanPacketReceived(CanPacket canPacket) { }
    }
}
