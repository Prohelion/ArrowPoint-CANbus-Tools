using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Services;
using ArrowPointCANBusTool.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ArrowPointCANBusTool.Forms
{
    public partial class ChargerControlForm : Form
    {

        private Timer timer;

        public IChargerInterface ChargerService { get; private set; }
        public Boolean IsPrecharging { get; private set; } = false;


        public ChargerControlForm()
        {
            InitializeComponent();            
            maxSocketCurrent.SelectedIndex = maxSocketCurrent.FindStringExact("10");
            ChargerComboBox.SelectedIndex = 0;
            RequestedChargeCurrent.Maximum = 10;
        }

        private void StartCharge_ClickAsync(object sender, EventArgs e)
        {
            startCharge.Enabled = false;

            if (ChargerService.IsCharging)
               ChargerService.StopCharge();
            else
            {
                startDischarge.Enabled = false;
                

                if (ChargerService.State == CanReceivingNode.STATE_WARNING || ChargerService.State == CanReceivingNode.STATE_ON || ChargerService.State == CanReceivingNode.STATE_IDLE)
                {                    
                    ChargerService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
                    ChargerService.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
                    ChargerService.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                    ChargerService.StartCharge();
                }
                else
                    MessageBox.Show("Charger of battery is currently in an invalid state to start charging",
                     "Check Battery and Charger",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

            }
                
            UpdateStartStopDetails();
        }

        private async void StartDischarge_ClickAsync(object sender, EventArgs e)
        {

            startDischarge.Enabled = false;

            // This should never happen.  It is a safety just in case
            if (ChargerService.IsCharging)
            {
                ContactorService.Instance.DisengageContactor();
                return;
            }

            if (ContactorService.Instance.IsContactorsEngaged())
            {
                ContactorService.Instance.DisengageContactor();
                startDischarge.Text = "Engage Contactors";
            }
            else
            {
                startCharge.Enabled = false;
                await ContactorService.Instance.EngageContactor().ConfigureAwait(false);
                startDischarge.Text = "Disengage Contactor";
            }
        }


        private void ChargerControlForm_Load(object sender, EventArgs e)
        {
            ChargerService = ElconService.Instance;
            
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void ChargerControlForm_FormClosingAsync(object sender, FormClosingEventArgs e)
        {            
            timer.Stop();
            ChargerService.StopCharge();
        }

        private void UpdateStartStopDetails()
        {

            if (IsPrecharging)
            {
                startDischarge.Enabled = false;
                startCharge.Enabled = false;
                startCharge.Text = "Precharging";
                maxSocketCurrent.Enabled = false;            
            } else if (ChargerService.IsCharging)
            {
                startDischarge.Enabled = false;
                startCharge.Enabled = true;
                startCharge.Text = "Disengage Contactors";
                maxSocketCurrent.Enabled = false;
            }
            else
            {
                ActualVoltageTxt.Text = "";
                ActualCurrentTxt.Text = "";
                
                startCharge.Text = "Start Charge";
                maxSocketCurrent.Enabled = true;

                if (!ContactorService.Instance.IsContactorsEngaged()) startDischarge.Enabled = true;
            }

            if (ContactorService.Instance.IsContactorsEngaged())
            {
                startCharge.Enabled = false;
                startDischarge.Text = "Disengage Contactors";
            } else
            {
                if (!ChargerService.IsCharging && !IsPrecharging) startCharge.Enabled = true;
                startDischarge.Text = "a Contactors";
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {

            ActualVoltageTxt.Text = String.Format(string.Format("{0:0.00}", ChargerService.ActualVoltage));
            ActualCurrentTxt.Text = String.Format(string.Format("{0:0.00}", ChargerService.ActualCurrent));

            // Ensures that the user does not select a value less than the voltage of the pack            
            if (!ChargerService.IsCommsOk) Comms_Ok.ForeColor = Color.Red; else Comms_Ok.ForeColor = Color.Green;
            if (!ChargerService.IsACOk) AC_Ok.ForeColor = Color.Red; else AC_Ok.ForeColor = Color.Green;
            if (!ChargerService.IsDCOk) DC_Ok.ForeColor = Color.Red; else DC_Ok.ForeColor = Color.Green;
            if (!ChargerService.IsTempOk) Temp_Ok.ForeColor = Color.Red; else Temp_Ok.ForeColor = Color.Green;
            if (!ChargerService.IsHardwareOk) HW_Ok.ForeColor = Color.Red; else HW_Ok.ForeColor = Color.Green;

            chargerStatusLabel.Text = "Charger - " + CanReceivingNode.GetStatusText(ChargerService.State);
            chargerStatusLabel.ToolTipText = ChargerService.StateMessage;
            chargerStatusLabel.BackColor = CanReceivingNode.GetStatusColour(ChargerService.State);
            dischargerStripStatusLabel.Text = "Contactor - " + CanReceivingNode.GetStatusText(ContactorService.Instance.State);
            dischargerStripStatusLabel.BackColor = CanReceivingNode.GetStatusColour(ContactorService.Instance.State);
            chargerStatusLabel.ToolTipText = ContactorService.Instance.StateMessage;

            UpdateStartStopDetails();
        }


        private void RequestedChargeCurrent_ValueChanged(object sender, EventArgs e)
        {
            ChargerService.RequestedCurrent = float.Parse(RequestedChargeCurrent.Value.ToString());
        }

        private void MaxSocketCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            RequestedChargeCurrent.Maximum = decimal.Parse(maxSocketCurrent.SelectedItem.ToString());
        }

        private void RequestedChargeVoltage_ValueChanged(object sender, EventArgs e)
        {
            ChargerService.RequestedVoltage = float.Parse(RequestedChargeVoltage.Value.ToString());
        }

        private void ChargerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChargerComboBox.SelectedIndex == 0)
            {
                // Elcon
                ChargerService = ElconService.Instance;
            }
            else
            if (ChargerComboBox.SelectedIndex == 1)
            {
                // TDK                
                ChargerService = TDKService.Instance;
                TDKService.Instance.Connect("192.168.20.35", 100);
            }
        }

    }
}
