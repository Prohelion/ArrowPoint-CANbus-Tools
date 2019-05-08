using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowWareDiagnosticTool.Model
{
    interface CanModel
    {
        Boolean InRange(CanPacket packet);
        void Update(CanPacket packet);
    }
}
