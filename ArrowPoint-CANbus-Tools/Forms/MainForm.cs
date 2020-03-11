using ArrowPointCANBusTool.CanLibrary;
using ArrowPointCANBusTool.Configuration;
using ArrowPointCANBusTool.Forms;
using ArrowPointCANBusTool.Model;
using ArrowPointCANBusTool.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    public partial class MainForm : Form
    {                
        private CarData carData;
        private ConnectForm settingsForm;
        private ReceivePacketForm receivePacketForm;
        private NewReleaseForm newReleaseForm;
        private SendPacketForm sendPacketForm;
        private MotorControllerSimulatorForm motorControllerSimulatorForm;
        private AboutBox aboutBox;
        private DriverControllerSimulatorForm driverControllerSimulatorForm;
        private DataLoggerForm dataLoggerForm;
        private CanbusDashboardForm canbusDashboardForm;
        private DataLogReplayerForm dataLogReplayerForm;
        private BatteryChargerForm chargerControlForm;
        private BatteryViewerForm batteryViewerForm;
        private BatteryControllerForm batteryControlForm;
        private NetworkDefinitionForm networkDefinitionForm;
        private ErrorFinderForm errorFinderForm;

        public MainForm()
        {
            InitializeComponent();            
        }

        private void RawDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            receivePacketForm = new ReceivePacketForm()
            {
                MdiParent = this
            };
            receivePacketForm.Show();
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
            {
                newReleaseForm = new NewReleaseForm(UpdateService.Instance);
                newReleaseForm.ShowDialog();
            }
                
        }

        private void FormMain_RequestConnectionStatusChange(bool connected)
        {
            /* These features are currently disabled until they have been better tested */
            MenuStrip.Items.Find("simulatorsToolStripMenuItem", true)[0].Visible = false;
            MenuStrip.Items.Find("dashboardToolStripMenuItem", true)[0].Visible = false;
            MenuStrip.Items.Find("configurationToolStripMenuItem", true)[0].Visible = false;

            if (connected)
            {
                connectedStatusLabel.Text = "Connected";
                connectedStatusLabel.BackColor = Color.DarkGreen;                
                MenuStrip.Items.Find("monitoringToolStripMenuItem", true)[0].Enabled = true;                
                MenuStrip.Items.Find("batteryToolStripMenuItem", true)[0].Enabled = true;
                /* These features are currently disabled until they have been better tested
                 * MenuStrip.Items.Find("simulatorsToolStripMenuItem", true)[0].Enabled = true;
                 * MenuStrip.Items.Find("dashboardToolStripMenuItem", true)[0].Enabled = true;
                 * MenuStrip.Items.Find("configurationToolStripMenuItem", true)[0].Enabled = true;
                 */
            }
            else
            {
                connectedStatusLabel.Text = "Not Connected";
                connectedStatusLabel.BackColor = Color.Red;                
                MenuStrip.Items.Find("monitoringToolStripMenuItem", true)[0].Enabled = false;                
                MenuStrip.Items.Find("batteryToolStripMenuItem", true)[0].Enabled = false;

                /* These features are currently disabled until they have been better tested
                 * MenuStrip.Items.Find("simulatorsToolStripMenuItem", true)[0].Enabled = false;
                 * MenuStrip.Items.Find("dashboardToolStripMenuItem", true)[0].Enabled = false;
                 * MenuStrip.Items.Find("coadConfigurationToolStripMenuItem", true)[0].Enabled = false;                 
                 */
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

            settingsForm = new ConnectForm()
            {
                MdiParent = this
            };
            settingsForm.Show();
        }

        private void SendCanPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendPacketForm = new SendPacketForm()
            {
                MdiParent = this
            };
            sendPacketForm.Show();
        }

        private void MotorControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            motorControllerSimulatorForm = new MotorControllerSimulatorForm()
            {
                MdiParent = this
            };
            motorControllerSimulatorForm.Show();
        }

        private void CanbusOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canbusDashboardForm = new CanbusDashboardForm(this.carData)
            {
                MdiParent = this
            };
            canbusDashboardForm.Show();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutBox = new AboutBox
            {
                MdiParent = this
            };
            aboutBox.Show();
        }

        private void DriverControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            driverControllerSimulatorForm = new DriverControllerSimulatorForm()
            {
                MdiParent = this
            };
            driverControllerSimulatorForm.Show();
        }

        private void DataLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataLoggerForm = new DataLoggerForm()
            {
                MdiParent = this
            };
            dataLoggerForm.Show();
        }

        private void LogReplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataLogReplayerForm = new DataLogReplayerForm()
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
            chargerControlForm = new BatteryChargerForm()
            {
                MdiParent = this
            };
            chargerControlForm.Show();
        }

        private void BatteryViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batteryViewerForm = new BatteryViewerForm()
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
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*",
                FilterIndex = 2
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
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
            using SaveFileDialog saveFileDialog = new SaveFileDialog
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
            batteryControlForm = new BatteryControllerForm()
            {
                MdiParent = this
            };
            batteryControlForm.Show();
        }

        private void ErrorTracerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorFinderForm = new ErrorFinderForm()
            {
                MdiParent = this
            };
            errorFinderForm.Show();
        }
    }
}
