using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ArrowPointCANBusTool.Canbus;

namespace ArrowPointCANBusTool.Model
{
    class Battery : ICanComponent
    {

        ArrayList bmus = new ArrayList();

        public Battery()
        {
            bmus.Add(new BMU("600"));
            bmus.Add(new BMU("200"));
        }

        public ArrayList GetBMUs()
        {
            return bmus;
        }        

        public BMU GetBMU(int index)
        {
            if (bmus == null) return null;
            if (bmus.Count-1 < index) return null;

            return ((BMU)bmus[index]);
        }

        public bool InRange(CanPacket packet)
        {
            foreach (BMU bmu in bmus)
            {
                if (bmu.InRange(packet))
                {                    
                    return true;
                }
            }
            return false;
        }

        public uint Status
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

        public bool IsPackInRunState {
            get
            {                
                foreach (BMU bmu in bmus)
                {
                    if (bmu.PrechargeState != BMU.PRECHARGE_STATUS_RUN)
                        return false;
                }

                return true;
            }
        }

        public int State => CanReceivingComponent.STATE_ON;

        public string StateMessage => "OK";

        public void CanPacketReceived(CanPacket packet)
        {
            // Check to see if it is actually CMU data
            foreach (BMU bmu in bmus)
            {
                if (bmu.InRange(packet))
                {                    

                    // If it is update the CMU and then return as it will not be a BMU packet and doesn
                    // require any futher processing
                    bmu.CanPacketReceived(packet);
                    return;
                }
            }
        }
    }
}
