using ArrowPointCANBusTool.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Controls
{
    public class CanTreeTag
    {
        public const int BUS = 1;
        public const int NODE = 2;
        public const int MESSAGE = 3;
        public const int SIGNAL = 4;

        public int NodeType { get; set; }
        public Configuration.Bus Bus { get; set; }
        public Configuration.Node Node { get; set; }
        public Configuration.Message Message { get; set; }
        public Configuration.Signal Signal { get; set; }        

    }
}
