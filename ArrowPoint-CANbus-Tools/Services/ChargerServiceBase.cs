
using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using System;
using System.Diagnostics;
using static ArrowPointCANBusTool.Services.CanService;

namespace ArrowPointCANBusTool.Services
{
    public abstract class ChargerServiceBase : CanReceivingNode, IChargerInterface
    {
        private const uint VALID_MILLI = 1000;

        public float ChargerVoltage { get; protected set; }
        public float ChargerCurrent { get; protected set; }   
        public uint ChargerStatus { get; protected set; }

        public abstract float ChargerVoltageLimit { get; protected set; }
        public abstract float ChargerCurrentLimit { get; protected set; }
        public abstract float ChargerPowerLimit { get; protected set; }
        public abstract float ChargerEfficiency { get; }

        public abstract bool IsHardwareOk { get; }
        public abstract bool IsTempOk { get; }
        public abstract bool IsCommsOk { get; }
        public abstract bool IsACOk { get; }
        public abstract bool IsDCOk { get; }
        public abstract bool IsCharging { get; }

        private float voltageRequested;
        private float currentRequested;
        private float supplyVoltageLimit;
        private float supplyCurrentLimit;

        public float VoltageRequested
        {
            get { return voltageRequested; }
            set
            {
                voltageRequested = value;
                if (voltageRequested > ChargerVoltageLimit)
                    ChargerVoltage = ChargerVoltageLimit;
                else
                    ChargerVoltage = value;                
            }
        }
        public float CurrentRequested
        {
            get { return currentRequested;  }
            set
            {
                currentRequested = value;
                if (currentRequested > ChargerCurrentLimit)
                    ChargerCurrent = ChargerCurrentLimit;
                else
                    ChargerCurrent = value;
            }
        }
        
        public float SupplyVoltageLimit
        {
            get { return supplyVoltageLimit; }
            set
            {
                supplyVoltageLimit = value;
                if (supplyVoltageLimit < ChargerVoltageLimit) ChargerVoltageLimit = SupplyVoltageLimit;
                ChangeSupplyCurrentOrVoltageLimit(SupplyCurrentLimit, SupplyVoltageLimit);
            }
        }

        public float SupplyCurrentLimit
        {
            get
            {
                return supplyCurrentLimit;
            }
            set
            {
                supplyCurrentLimit = value;
                if (supplyCurrentLimit < ChargerCurrentLimit) ChargerCurrentLimit = SupplyCurrentLimit;
                ChangeSupplyCurrentOrVoltageLimit(SupplyCurrentLimit, SupplyVoltageLimit);
            }
        }

        public ChargerServiceBase(uint baseAddress, uint highAddress) : base(baseAddress, highAddress, VALID_MILLI, false)
        {            
            SupplyVoltageLimit = 0;
            SupplyCurrentLimit = 0;
        }

        public ChargerServiceBase(uint baseAddress, uint highAddress, float supplyVoltageLimit, float supplyCurrentLimit)  : base(baseAddress, highAddress, VALID_MILLI, false)
        {            
            SupplyVoltageLimit = supplyVoltageLimit;
            SupplyCurrentLimit = supplyCurrentLimit;
        }

        public void ChangeSupplyCurrentOrVoltageLimit(float supplyCurrentLimit, float supplyVoltageLimit)
        {
            
            ChargerPowerLimit = SupplyVoltageLimit * SupplyCurrentLimit;
            if (ChargerPowerLimit > ChargerPowerLimit)
            {
                ChargerPowerLimit = ChargerPowerLimit;
            }

            // Derate maximum power by the chargers efficiency
            ChargerPowerLimit *= ChargerEfficiency;
        }

        public abstract void StartCharge();
        public abstract void StopCharge();
    }
}
