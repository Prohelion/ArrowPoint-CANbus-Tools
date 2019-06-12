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
    public class Battery : CanReceivingComponent
    {

        public const string BATTERY_ID = "BATTERY";

        List<BMU> bmus = new List<BMU>();
        
        public Battery(CanService canService) : base(canService, 0, 0, false)
        {
            bmus.Add(new BMU(ComponentCanService, 0x600));
            bmus.Add(new BMU(ComponentCanService, 0x200));
        }

        public override string ComponentID => BATTERY_ID;

        public List<BMU> GetBMUs()
        {
            return bmus;
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
                uint state = CanReceivingComponent.STATE_NA;

                foreach (BMU bmu in bmus)
                {
                    if (bmu.State > state)
                        state = bmu.State;
                }

                return state;
            }
        }

        public override string StateMessage
        {
            get
            {
                string stateMessage = "";
                int i = 1;

                foreach (BMU bmu in bmus)
                {
                    if (stateMessage.Length > 0) stateMessage = stateMessage + ", ";
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
                    status = status | bmu.ExtendedStausFlag;
                }

                return status;
            }
        }

        public bool IsPackReady {
            get
            {                
                foreach (BMU bmu in bmus)
                {
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
                    batteryCurrent = batteryCurrent + bmu.BatteryCurrent;
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
