﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Services;
using System.Collections;
using Prohelion.CanLibrary;

namespace ArrowPointCANBusTool.CanLibrary
{
   
    abstract public class CanReceivingNode
    {
        private readonly Hashtable latestCanPackets;

        public const uint STATE_NA = 0;
        public const uint STATE_OFF = 1;
        public const uint STATE_IDLE = 2;
        public const uint STATE_ON = 3;
        public const uint STATE_WARNING = 4;
        public const uint STATE_FAILURE = 5;        

        public const string STATE_NA_TEXT = "N/A";
        public const string STATE_OFF_TEXT = "OFF";
        public const string STATE_IDLE_TEXT = "IDLE";
        public const string STATE_ON_TEXT = "ON";
        public const string STATE_WARNING_TEXT = "WARNING";
        public const string STATE_FAILURE_TEXT = "FAILURE";

        public CanService ComponentCanService { get; set; }
        public uint BaseAddress { get; } = 0;
        public uint HighAddress { get; } = 0;
        public uint AddressRange { get { return HighAddress - BaseAddress; } }
        public uint MilliValid { get; } = 0;

        public abstract string ComponentID { get; }

        public CanReceivingNode(uint baseAddress, uint highAddress, uint milliValid, bool startReceiver)
        {
            this.BaseAddress = baseAddress;
            this.HighAddress = highAddress;
            this.MilliValid = milliValid;

            ComponentCanService = CanService.Instance;
            latestCanPackets = new Hashtable();

            if (startReceiver) StartReceivingCan();
        }

        public virtual uint State
        {
            get
            {
                // Look for the packet at the base address as this is the marker we use 
                // for tracking if the device is on or not
                if (LatestPacket(0) == null)
                    return STATE_NA;
                else
                    return STATE_ON;
            }
        }

        public virtual string StateMessage
        {
            get
            {
                return GetStatusText(State);
            }
        }
    
        public void StartReceivingCan()
        {
            this.ComponentCanService.CanUpdateEventHandler += new CanUpdateEventHandler(CanPacketReceivedInternal);
        }

        public void StopReceivingCan()
        {
            ComponentCanService.CanUpdateEventHandler -= new CanUpdateEventHandler(CanPacketReceivedInternal);
        }

        public bool InRange(CanPacket canPacket)
        {
            if (canPacket == null) throw new ArgumentNullException(nameof(canPacket));

            if (canPacket.CanId >= BaseAddress && canPacket.CanId <= HighAddress)
                return true;

            return false;
        }

        private void CanPacketReceivedInternal(CanReceivedEventArgs e)
        {
            CanPacket canPacket = e.Message;

            uint canIdOffset = canPacket.CanId - BaseAddress;

            if (latestCanPackets.ContainsKey(canIdOffset)) latestCanPackets.Remove(canIdOffset);
            latestCanPackets.Add(canIdOffset, canPacket);

            if (InRange(canPacket)) CanPacketReceived(canPacket);
        }

        // Used for testing only
        public void TestCanPacketReceived(CanPacket canPacket)
        {
            CanPacketReceivedInternal(new CanReceivedEventArgs(canPacket));
        }

        public abstract void CanPacketReceived(CanPacket canPacket);

        public static Boolean IdMatch(string HexId, int canOffset)
        {
            int hexIdAsInt = int.Parse(HexId, System.Globalization.NumberStyles.HexNumber);
            return (hexIdAsInt == canOffset);
        }
        
        public CanPacket LatestPacket(uint canIdOffset)
        {
            CanPacket canPacket = (CanPacket)latestCanPackets[canIdOffset];

            if (canPacket == null) return null;
            if (MilliValid != 0 && canPacket.MilisecondsSinceReceived > MilliValid) return null;

            return canPacket;
        }

        public static Color GetStatusColour(uint state)
        {
            switch (state)
            {
                case STATE_NA: return Color.LightGray;
                case STATE_OFF: return Color.DarkGray;
                case STATE_IDLE: return Color.DarkSalmon;
                case STATE_ON: return Color.Green;
                case STATE_WARNING: return Color.Orange;
                case STATE_FAILURE: return Color.Red;
                default: return Color.LightGray;
            }
        }

        public static string GetStatusText(uint state)
        {
            switch (state)
            {
                case STATE_NA: return STATE_NA_TEXT;
                case STATE_OFF: return STATE_OFF_TEXT;
                case STATE_IDLE: return STATE_IDLE_TEXT;
                case STATE_ON: return STATE_ON_TEXT;
                case STATE_WARNING: return STATE_WARNING_TEXT;
                case STATE_FAILURE: return STATE_FAILURE_TEXT;
                default: return STATE_NA_TEXT;
            }
        }

    }
}
