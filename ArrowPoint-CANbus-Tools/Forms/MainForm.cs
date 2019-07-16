using ArrowPointCANBusTool.Canbus;
using ArrowPointCANBusTool.Configuration;
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
        private CarData carData;        
        private NetworkDefinitionForm networkDefinitionForm;

        public FormMain()
        {
            InitializeComponent();            
        }

        private void RawDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceivePacketForm ReceivePacketForm = new ReceivePacketForm()
            {
                MdiParent = this
            };
            ReceivePacketForm.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CanService.Instance.Disconnect();
            Application.Exit();
        }

        private void ConnectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowConnectionForm();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CanService.Instance.RequestConnectionStatusChange += FormMain_RequestConnectionStatusChange;

            // Setup as initially not connected
            FormMain_RequestConnectionStatusChange(false);

            this.carData = new CarData();

            ShowConnectionForm();

            if (UpdateService.Instance.IsUpdateAvailable)
                new NewReleaseForm(UpdateService.Instance).ShowDialog();                
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
                MenuStrip.Items.Find("LoadConfigurationToolStripMenuItem", true)[0].Enabled = true;
                MenuStrip.Items.Find("SaveConfigurationToolStripMenuItem", true)[0].Enabled = true;
            } else
            {
                connectedStatusLabel.Text = "Not Connected";
                connectedStatusLabel.BackColor = Color.Red;
                MenuStrip.Items.Find("dashboardToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("monitoringToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("simulatorsToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("batteryToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("LoadConfigurationToolStripMenuItem", true)[0].Enabled = false;
                MenuStrip.Items.Find("SaveConfigurationToolStripMenuItem", true)[0].Enabled = false;
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

            ConnectForm settingsForm = new ConnectForm()
            {
                MdiParent = this
            };
            settingsForm.Show();
        }

        private void SendPacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm endPacketForm = new SendPacketForm()
            {
                MdiParent = this
            };
            endPacketForm.Show();
        }

        private void SendCanPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm sendPacketForm = new SendPacketForm()
            {
                MdiParent = this
            };
            sendPacketForm.Show();
        }

        private void MotorControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotorControllerSimulatorForm motorControllerSimulatorForm = new MotorControllerSimulatorForm()
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
            DriverControllerSimulatorForm driverControllerSimulatorForm = new DriverControllerSimulatorForm()
            {
                MdiParent = this
            };
            driverControllerSimulatorForm.Show();
        }

        private void DataLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLoggerForm dataLoggerForm = new DataLoggerForm()
            {
                MdiParent = this
            };
            dataLoggerForm.Show();
        }

        private void LogReplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLogReplayerForm dataLogReplayerForm = new DataLogReplayerForm()
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
            ChargerControlForm chargerControlForm = new ChargerControlForm()
            {
                MdiParent = this
            };
            chargerControlForm.Show();
        }

        private void BatteryViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatteryViewerForm batteryViewerForm = new BatteryViewerForm()
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
            CanService.Instance.Disconnect();
            Application.Exit();
        }

        private void LoadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog;

            openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 2
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (networkDefinitionForm == null)
                    networkDefinitionForm = new NetworkDefinitionForm()
                    {
                       MdiParent = this
                       // Dock = DockStyle.Left
                    };
                networkDefinitionForm.LoadConfig(openFileDialog.FileName);
                networkDefinitionForm.Show();
                //networkDefinitionForm.SendToBack();
            }
        }

        private void SaveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                RestoreDirectory = true,
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 2
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ConfigService.Instance.SaveConfig(saveFileDialog.FileName);
            }
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void BatteryControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BatteryControllerForm batteryControlForm = new BatteryControllerForm()
            {
                MdiParent = this
            };
            batteryControlForm.Show();
        }
    }
}
