using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.CanLibrary
{
    class CanIds
    {
        public const int DC_BASE    = 1280; // 0x500
        public const int DC_DRIVE   = 1; // 0x01
        public const int DC_POWER   = 2; // 0x02
        public const int DC_SWITCH  = 5; // 0x05
        public const int DC_CRUISE1 = 7; // 0x07
        public const int DC_CRUISE2 = 8; // 0x08
        public const int DC_DEBUG = 13; // 0x08        
    }
}
