using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class ChargeData
    {
        public DateTime DateTime { get; set; }
        public float SOC { get; set; }
        public int SOCAsInt { get { return Convert.ToInt32(SOC * 100); } }
        public float ChargeCurrentmA { get; set; }
        public float ChargeCurrentA { get { return ChargeCurrentmA / 1000; } }
        public float ChargeVoltagemV { get; set; }
        public float ChargeVoltageV { get { return ChargeVoltagemV / 1000; } }
        public int PackmA { get; set; }
        public uint PackmV { get; set; }
        public float PackA { get { return PackmA / 1000; } }
        public float PackV { get { return PackmV / 1000; } }
        public uint MinCellmV { get; set; }
        public uint MaxCellmV { get; set; }
        public uint MinCellTemp { get; set; }
        public uint MaxCellTemp { get; set; }
        public uint MinCellTempC { get { return MinCellTemp / 10; } }
        public uint MaxCellTempC { get { return MaxCellTemp / 10; } }
        public uint BalanceVoltageThresholdFalling { get; set; }
        public uint BalanceVoltageThresholdRising { get; set; }
        public int ChargeCellVoltageError { get; set; }
        public int DischargeCellVoltageError { get; set; }
    }
}
