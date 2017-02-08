using ArrowWareDiagnosticTool.Canbus;
using ArrowWareDiagnosticTool.Forms;
using System;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool
{
    public partial class FormMain : Form
    {
        private UdpReciever udpReciever;
        private UdpSender udpSender;
        private CarData carData;

        public FormMain()
        {
            InitializeComponent();
        }

        private void rawDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReceivePacketForm ReceivePacketForm = new ReceivePacketForm(this.udpReciever, this.udpSender);
            ReceivePacketForm.MdiParent = this;
            ReceivePacketForm.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.udpReciever.close();
            this.udpSender.close();

            Application.Exit();
        }

        private void connectionSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSettingsForm();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.udpSender = new UdpSender();
            this.udpReciever = new UdpReciever();
            this.carData = new CarData(this.udpReciever);

            showSettingsForm();
        }

        private void showSettingsForm()
        {
             foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == typeof(SettingsForm))
                {
                    form.Activate();
                    return;
                }
            }

            SettingsForm settingsForm = new SettingsForm(this.udpReciever, this.udpSender);
            settingsForm.MdiParent = this;
            settingsForm.Show();
        }

        private void sendPacketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm endPacketForm = new SendPacketForm(this.udpSender);
            endPacketForm.MdiParent = this;
            endPacketForm.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sendCanPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm sendPacketForm = new SendPacketForm(this.udpSender);
            sendPacketForm.MdiParent = this;
            sendPacketForm.Show();
        }

        private void motorControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MotorControllerSimulatorForm motorControllerSimulatorForm = new MotorControllerSimulatorForm(this.udpSender);
            motorControllerSimulatorForm.MdiParent = this;
            motorControllerSimulatorForm.Show();
        }

        private void canbusOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanbusDashboardForm canbusDashboardForm = new CanbusDashboardForm(this.carData);
            canbusDashboardForm.MdiParent = this;
            canbusDashboardForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.MdiParent = this;
            aboutBox.Show();
        }

        private void driverControllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverControllerSimulatorForm driverControllerSimulatorForm = new DriverControllerSimulatorForm(this.udpSender);
            driverControllerSimulatorForm.MdiParent = this;
            driverControllerSimulatorForm.Show();
        }

        private void dataLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLoggerForm dataLoggerForm = new DataLoggerForm(this.udpReciever);
            dataLoggerForm.MdiParent = this;
            dataLoggerForm.Show();
        }

        private void logReplayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataLogReplayerForm dataLogReplayerForm = new DataLogReplayerForm(this.udpSender);
            dataLogReplayerForm.MdiParent = this;
            dataLogReplayerForm.Show();
        }
    }
}
