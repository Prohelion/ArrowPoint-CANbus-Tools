using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;

namespace ArrowPointCANBusTool.Model
{
    public class Battery : CanReceivingNode
    {

        public const string BATTERY_ID = "BATTERY";

        private const uint VALID_MILLI = 1000;
        

        private readonly List<BMU> bmus = new List<BMU>();
        public BatteryTwelveVolt BatteryTwelveVolt { get; private set; }
        public int ParallelStrings { get; set; } = 3;

        public Battery(bool timeoutApplies) : base(0, 0, VALID_MILLI, false)
        {
            bmus.Add(new BMU(0x600, timeoutApplies));
            bmus.Add(new BMU(0x200, timeoutApplies));
            BatteryTwelveVolt = new BatteryTwelveVolt(0x100, timeoutApplies);            
        }

        public override string ComponentID => BATTERY_ID;

        public List<BMU> GetBMUs()
        {
            return bmus;
        }        

        public List<BMU> GetActiveBMUs()
        {
            List<BMU> activeBmus = new List<BMU>();

            foreach (BMU bmu in bmus)
            {
                if (bmu.State != CanReceivingNode.STATE_NA) activeBmus.Add(bmu);
            }                

            return activeBmus;
        }

        public BMU GetBMU(int index)
        {
            if (bmus == null) return null;
            if (bmus.Count-1 < index) return null;

            return ((BMU)bmus[index]);
        }

        public override void CanPacketReceived(CanPacket canPacket)
        {
            throw new NotImplementedException();
        }

        public override uint State
        {
            get
            {
                uint state = CanReceivingNode.STATE_NA;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.State > state)
                        state = bmu.State;
                }

                return state;
            }
        }


        public uint PreChargeState
        {
            get
            {
                uint prechargeState = BMU.PRECHARGE_STATUS_ERROR;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.PrechargeState > prechargeState)
                        prechargeState = bmu.PrechargeState;
                }

                return prechargeState;
            }
        }

        public new string StateMessage
        {
            get
            {
                string stateMessage = "";
                int i = 1;

                foreach (BMU bmu in bmus)
                {
                    if (stateMessage.Length > 0) stateMessage += ", ";
                    stateMessage = stateMessage + "BMU " + i + " - " + bmu.StateMessage;
                    i++;
                }

                return stateMessage;
            }
        }

        public uint ExtendedStatus
        {
            get {
                uint status = 0;

                foreach (BMU bmu in bmus)
                {
                    status |= bmu.ExtendedStausFlag;
                }

                return status;
            }
        }

        public bool IsPackReady {
            get
            {                
                foreach (BMU bmu in bmus)
                {                    
                    // Double negative is used here to catch any variation across any bmu that is not right to go.
                    if (bmu.PrechargeState != BMU.PRECHARGE_STATUS_RUN || !bmu.Contactor1DriverOutput)
                        return false;
                }

                return true;
            }
        }

        public int MinChargeCellVoltageError
        {
            get
            {
                int minCellError = int.MaxValue;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.ChargeCellVoltageError < minCellError)
                        minCellError = bmu.ChargeCellVoltageError;
                }

                return minCellError;
            }
        }

        public int MinCellTempMargin
        {
            get
            {

                int minCellTempMargin = int.MaxValue;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.CellTempMargin < minCellTempMargin)
                        minCellTempMargin = (int)bmu.CellTempMargin;
                }

                return minCellTempMargin;
            }
        }


        public int MinDischargeCellVoltageError
        {
            get
            {
                int minCellError = int.MaxValue;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.DischargeCellVoltageError < minCellError)
                        minCellError = bmu.DischargeCellVoltageError;
                }

                return minCellError;
            }
        }

        public int BatteryCurrent
        {
            get
            {
                int batteryCurrent = 0;

                foreach (BMU bmu in bmus)
                {
                    batteryCurrent += bmu.BatteryCurrent;
                }

                return batteryCurrent;
            }
        }

        public uint BatteryVoltage
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                return bmus[0].BatteryVoltage;
            }
        }


        public uint MinCellVoltage
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                uint minCellVoltage = int.MaxValue;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.MinCellVoltage < minCellVoltage)
                        minCellVoltage = bmu.MinCellVoltage;
                }

                return minCellVoltage;
            }
        }


        public uint MaxCellVoltage
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                uint maxCellVoltage = 0;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.MaxCellVoltage > maxCellVoltage)
                        maxCellVoltage = bmu.MaxCellVoltage;
                }

                return maxCellVoltage;
            }
        }


        public uint MinCellTemp
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                uint minCellTemp = int.MaxValue;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.MinCellTemp < minCellTemp)
                        minCellTemp = bmu.MinCellTemp;
                }

                return minCellTemp;
            }
        }


        public uint MaxCellTemp
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                uint maxCellTemp = 0;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.MaxCellTemp > maxCellTemp)
                        maxCellTemp = bmu.MaxCellTemp;
                }

                return maxCellTemp;
            }
        }


        public uint BalanceVoltageThresholdFalling
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                uint balanceVoltageThresholdFalling = int.MaxValue;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.BalanceVoltageThresholdFalling < balanceVoltageThresholdFalling)
                        balanceVoltageThresholdFalling = bmu.BalanceVoltageThresholdFalling;
                }

                return balanceVoltageThresholdFalling;
            }
        }

        private uint CheckVoltage(uint? cellVoltage, uint minVoltageRange, uint maxVoltageRange)
        {
            // The CMU can show null in a number of different situations.
            // This function attemps to make reading it as safe as is possible.
            try
            {
                if (!cellVoltage.HasValue) return 0;

                if (cellVoltage.HasValue && cellVoltage != null && cellVoltage >= minVoltageRange && cellVoltage <= maxVoltageRange)
                    return (uint)cellVoltage;

                return 0;
            } catch
            {
                return 0;
            }
        }

        public int EstimatePackVoltageFromCMUs
        {
            get
            {
                uint totalVoltage = 0;

                if (GetActiveBMUs() == null || GetActiveBMUs().Count == 0)
                    return 0;

                // Active BMUs can change as they timeout so we take a marker here
                int activeBMUs = GetActiveBMUs().Count;
                if (activeBMUs == 0) return 0;

                foreach (BMU bmu in GetActiveBMUs())
                {

                    uint maxVoltageRange = 4500;
                    uint minVoltageRange = 0;

                    foreach (CMU cmu in bmu.GetActiveCMUs())
                    {                    
                        totalVoltage += CheckVoltage(cmu.Cell0mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell1mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell2mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell3mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell4mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell5mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell6mV, minVoltageRange, maxVoltageRange);
                        totalVoltage += CheckVoltage(cmu.Cell7mV, minVoltageRange, maxVoltageRange);                        
                    }
                }

                // Divide by the number of parallel strings in the pack
                totalVoltage = (uint)(totalVoltage / ParallelStrings);

                return Convert.ToInt32(totalVoltage / activeBMUs);
            }
        }

        public uint BalanceVoltageThresholdRising
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                uint balanceVoltageThresholdRising = 0;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.BalanceVoltageThresholdRising > balanceVoltageThresholdRising)
                        balanceVoltageThresholdRising = bmu.BalanceVoltageThresholdRising;
                }

                return balanceVoltageThresholdRising;
            }
        }


        public float SOCPercentage
        {
            get
            {
                if (bmus.Count == 0)
                    return 0;

                float socPercentage = 1;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.SOCPercentage > socPercentage)
                        socPercentage = bmu.SOCPercentage;
                }

                return socPercentage;
            }
        }
        
    }
}
