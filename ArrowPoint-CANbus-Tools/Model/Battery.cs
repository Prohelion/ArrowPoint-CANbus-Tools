using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrowPointCANBusTool.CanBus;
using System.Collections;

namespace ArrowWareDiagnosticTool.Model
{
    class Battery : CanModel
    {

        ArrayList bmus = new ArrayList();

        public Battery()
        {
            bmus.Add(new BMU("600"));
            bmus.Add(new BMU("200"));
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

        public void Update(CanPacket packet)
        {
            // Check to see if it is actually CMU data
            foreach (BMU bmu in bmus)
            {
                if (bmu.InRange(packet))
                {
                    // If it is update the CMU and then return as it will not be a BMU packet and doesn
                    // require any futher processing
                    bmu.Update(packet);
                    return;
                }
            }
        }
    }
}
