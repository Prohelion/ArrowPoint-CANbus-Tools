
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

        public float ActualVoltage { get; protected set; }
        public float ActualCurrent { get; protected set; }   
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

        public float RequestedVoltage
        {
            get { return voltageRequested; }
            set
            {
                voltageRequested = value;
                if (voltageRequested > ChargerVoltageLimit)
                    ActualVoltage = ChargerVoltageLimit;
                else
                    ActualVoltage = value;                
            }
        }
        public float RequestedCurrent
        {
            get { return currentRequested;  }
            set
            {
                currentRequested = value;
                if (currentRequested > ChargerCurrentLimit)
                    ActualCurrent = ChargerCurrentLimit;
                else
                    ActualCurrent = value;
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
        { }

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

        // Artifact of our structure that this exists, but it should never be used as the TDK is not can enabled
        // TDK Charger uses a timer instead
        public override void CanPacketReceived(CanPacket canPacket)
        {
            throw new NotImplementedException();
        }

        public abstract void StartCharge();
        public abstract void StopCharge();

    }
}
