using ArrowPointCANBusTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ContactorsButton_Click(object sender, EventArgs e)
        {
            if (batteryService.IsContactorsEngaged)
            {
                batteryService.DisengageContactors();
            }
            else
            {
                batteryService.DisengageContactors();
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
