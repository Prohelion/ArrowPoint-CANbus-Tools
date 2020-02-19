using ArrowPointCANBusTool.Model;
using System;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class CanbusDashboardForm : Form
    {
        private readonly CarData carData;
        private Timer timer;

        public CanbusDashboardForm(CarData carData)
        {
            InitializeComponent();

            this.carData = carData;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            this.tbRpmPercentage.Text = carData.rpmPercentage.ToString();
            this.pbRpmPecentage.Value = ConvertFloatToPercent(carData.rpmPercentage);

            this.tbCurrentPercentage.Text   = carData.currentPercentage.ToString();
            this.pbCurrentPercentage.Value = ConvertFloatToPercent(carData.currentPercentage);

            this.tbBusCurrentPercentage.Text = carData.busCurrentPercentage.ToString();
            this.pbBusCurrentPercentage.Value = ConvertFloatToPercent(carData.busCurrentPercentage);

            this.tbThrottlePercentage.Text = carData.throttlePercentage.ToString();
            this.pbThrottlePercentage.Value = ConvertFloatToPercent(carData.throttlePercentage);

            this.tbRegenPercentage.Text = carData.regenPercentage.ToString();
            this.pbRegenPercentage.Value = ConvertFloatToPercent(carData.regenPercentage);

            this.tbErrorMode.Text = carData.errorMode.ToString();
            this.tbDriveMode.Text = carData.driveMode.ToString();
            this.tbCruiseMode.Text = carData.cruiseMode.ToString();
            this.tbFlashMode.Text = carData.flashMode.ToString();
        }

        private int ConvertFloatToPercent(float value) {
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

        private void CanbusDashboardForm_Load(object sender, EventArgs e)
        {
            timer = new Timer
            {
                Interval = (200)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        private void CanbusDashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}
