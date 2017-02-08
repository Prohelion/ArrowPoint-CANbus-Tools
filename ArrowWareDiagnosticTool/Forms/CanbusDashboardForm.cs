using ArrowWareDiagnosticTool.Canbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool.Forms
{
    public partial class CanbusDashboardForm : Form
    {
        private CarData carData;

        public CanbusDashboardForm(CarData carData)
        {
            InitializeComponent();

            this.carData = carData;

            // Move this logic to the reciever
            Timer timer = new Timer();
            timer.Interval = (200);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            this.tbRpmPercentage.Text = carData.rpmPercentage.ToString();
            this.pbRpmPecentage.Value = convertFloatToPercent(carData.rpmPercentage);

            this.tbCurrentPercentage.Text   = carData.currentPercentage.ToString();
            this.pbCurrentPercentage.Value = convertFloatToPercent(carData.currentPercentage);

            this.tbBusCurrentPercentage.Text = carData.busCurrentPercentage.ToString();
            this.pbBusCurrentPercentage.Value = convertFloatToPercent(carData.busCurrentPercentage);

            this.tbThrottlePercentage.Text = carData.throttlePercentage.ToString();
            this.pbThrottlePercentage.Value = convertFloatToPercent(carData.throttlePercentage);

            this.tbRegenPercentage.Text = carData.regenPercentage.ToString();
            this.pbRegenPercentage.Value = convertFloatToPercent(carData.regenPercentage);

            this.tbErrorMode.Text = carData.errorMode.ToString();
            this.tbDriveMode.Text = carData.driveMode.ToString();
            this.tbCruiseMode.Text = carData.cruiseMode.ToString();
            this.tbFlashMode.Text = carData.flashMode.ToString();
        }

        private int convertFloatToPercent(float value) {
            int percentage = (int)(value * 100);

            if (percentage > 100)
            {
                return 100;
            }
            else if (percentage < 0) {
                return 0;
            }

            return percentage;
        }
    }
}
