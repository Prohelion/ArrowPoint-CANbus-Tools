using ArrowPointCANBusTool.Services;
using System;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class BatteryControllerForm : Form
    {

        private BatteryService batteryService;
        private Timer timer;

        public BatteryControllerForm()
        {
            InitializeComponent();

            batteryService = BatteryService.Instance;
        }

        private async void ContactorsButton_ClickAsync(object sender, EventArgs e)
        {
            if (batteryService.IsContactorsEngaged)
            {
                batteryService.DisengageContactors();
            }
            else
            {
                await batteryService.EngageContactors();
            }

            UpdateButtonText();
        }

        private void UpdateButtonText()
        {
            if (batteryService.IsContactorsEngaged)
            {
                ContactorsButton.Text = "Disengage Contactors";                
            }
            else
            {
                ContactorsButton.Text = "Engage Contactors";
            }
        }

        private void TimerTick(object sender, EventArgs e)
        {
            UpdateButtonText();
        }

        private void BatteryControllerForm_Load(object sender, EventArgs e)
        {
            timer = new Timer
            {
                Interval = (100)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

    }
}
