using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Forms;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArrowPointCANBusTool
{
    public partial class FormMain : Form
    {
        private CanService canService;        
        private CarData carData;
        private UpdateService updateService;

        public FormMain()
        {
            InitializeComponent();
            updateService = new UpdateService();
        }

        private void RawDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceivePacketForm ReceivePacketForm = new ReceivePacketForm(this.canService)
            {
                MdiParent = this
            };
            ReceivePacketForm.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            canService.Disconnect();
            Application.Exit();
        }

        private void ConnectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.canService = new CanService();
            canService.RequestConnectionStatusChange += FormMain_RequestConnectionStatusChange;

            // Setup as initially not connected
            FormMain_RequestConnectionStatusChange(false);

            this.carData = new CarData(this.canService);

            ShowConnectionForm();

            if (updateService.IsUpdateAvailable)
                MessageBox.Show(
                    "A newer release of this software is available, please go to " + UpdateService.RELEASE_URL,
                    "Download new version",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void FormMain_RequestConnectionStatusChange(bool connected)
        {
            if (connected)
            {
                connectedStatusLabel.Text = "Connected";
                connectedStatusLabel.BackColor = Color.DarkGreen;
                MenuStrip.Items.Find("dashboardToolStripMenuItem", true)[0].Enabled = true;
                MenuStrip.Items.Find("monitoringToolStripMenuItem", true)[0].Enabled = true;
                MenuStrip.Items.Find("simulatorsToolStripMenuItem", true)[0].Enabled = true;
                MenuStrip.Items.Find("batteryToolStripMenuItem", true)[0].Enabled = true;
            } else
            {
                connectedStatusLabel.Text = "Not Connected";
                connectedStatusLabel.BackColor = Color.Red;
                MenuStrip.Items.Find("dashboardToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("monitoringToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("simulatorsToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("batteryToolStripMenuItem", true)[0].Enabled = false;
            }
        }

        private void ShowConnectionForm()
        {
             foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(ConnectForm))
                {
                    form.Activate();
                    return;
                }
            }

            ConnectForm settingsForm = new ConnectForm(this.canService)
            {
                MdiParent = this
            };
            settingsForm.Show();
        }

        private void SendPacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm endPacketForm = new SendPacketForm(this.canService)
            {
                MdiParent = this
            };
            endPacketForm.Show();
        }

        private void SendCanPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm sendPacketForm = new SendPacketForm(this.canService)
            {
                MdiParent = this
            };
            sendPacketForm.Show();
        }

        private void MotorControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotorControllerSimulatorForm motorControllerSimulatorForm = new MotorControllerSimulatorForm(this.canService)
            {
                MdiParent = this
            };
            motorControllerSimulatorForm.Show();
        }

        private void CanbusOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanbusDashboardForm canbusDashboardForm = new CanbusDashboardForm(this.carData)
            {
                MdiParent = this
            };
            canbusDashboardForm.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox
            {
                MdiParent = this
            };
            aboutBox.Show();
        }

        private void DriverControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverControllerSimulatorForm driverControllerSimulatorForm = new DriverControllerSimulatorForm(this.canService)
            {
                MdiParent = this
            };
            driverControllerSimulatorForm.Show();
        }

        private void DataLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLoggerForm dataLoggerForm = new DataLoggerForm(this.canService)
            {
                MdiParent = this
            };
            dataLoggerForm.Show();
        }

        private void LogReplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLogReplayerForm dataLogReplayerForm = new DataLogReplayerForm(this.canService)
            {
                MdiParent = this
            };
            dataLogReplayerForm.Show();
        }

        private void ConnectedStatusLabel_Click(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void BatteryChargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChargerControlForm chargerControlForm = new ChargerControlForm(this.canService)
            {
                MdiParent = this
            };
            chargerControlForm.Show();
        }

        private void BatteryViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatteryViewerForm batteryViewerForm = new BatteryViewerForm(this.canService)
            {
                MdiParent = this
            };
            batteryViewerForm.Show();
        }

        private void ConnectDisconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canService.Disconnect();
            Application.Exit();
        }
    }
}
