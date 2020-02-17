using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ArrowPointCANBusTool.Utilities.Validators
{
    public static class TextValidator
    {        

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            if (String.IsNullOrEmpty(nameOrAddress))
                return false;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
       

        private static bool IsError(TextBox textbox, ToolTip tooltip, string errorMessage)
        {
            textbox.BackColor = Color.LightSalmon;
            tooltip.SetToolTip(textbox, errorMessage);
            return false;
        }

        private static bool IsOk(TextBox textbox, ToolTip tooltip)
        {
            textbox.BackColor = default;
            tooltip.SetToolTip(textbox, null);
            return true;
        }

        public static bool IsValidHost(TextBox textbox, ToolTip tooltip, string errorMessage)
        {
            if (!PingHost(textbox.Text))
                return IsError(textbox, tooltip, errorMessage);
            else
                return IsOk(textbox, tooltip);
        }

        public static bool IsValidDirectory(TextBox textbox, ToolTip tooltip, string errorMessage)
        {
            if (!Directory.Exists(textbox.Text))
                return IsError(textbox, tooltip, errorMessage);
            else
                return IsOk(textbox, tooltip);
        }

        public static bool IsValidText(TextBox textbox, ToolTip tooltip, string errorMessage)
        {
            if (String.IsNullOrEmpty(textbox.Text) || String.IsNullOrWhiteSpace(textbox.Text))
                return IsError(textbox, tooltip, errorMessage);
            else
                return IsOk(textbox, tooltip);
        }

        public static bool IsValidInteger(TextBox textbox, ToolTip tooltip, string errorMessage)
        {
            if (!IsValidText(textbox, tooltip, errorMessage))
                return false;

            if (!int.TryParse(textbox.Text, out _))
                return IsError(textbox, tooltip, errorMessage);
            else
                return IsOk(textbox, tooltip);
        }

    }
}
