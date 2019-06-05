using ArrowPointCANBusTool.CanBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Model
{
    public class ChargeDataReceivedEventArgs : EventArgs
    {
        public ChargeData Message { get; set; }

        public ChargeDataReceivedEventArgs(ChargeData Message)
        {
            this.Message = Message;
        }
    }
}
