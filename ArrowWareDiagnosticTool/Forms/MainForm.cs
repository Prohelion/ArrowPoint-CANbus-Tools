using ArrowWareDiagnosticTool.Forms;
using System;
using System.Windows.Forms;

namespace ArrowWareDiagnosticTool
{
    public partial class FormMain : Form
    {
        private UdpReciever udpReciever;
        private UdpSender udpSender;

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
            SendPacketForm endPacketForm = new SendPacketForm(this.udpReciever, this.udpSender);
            endPacketForm.MdiParent = this;
            endPacketForm.Show();
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void sendCanPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPacketForm sendPacketForm = new SendPacketForm(this.udpReciever, this.udpSender);
            sendPacketForm.MdiParent = this;
            sendPacketForm.Show();
        }
    }
}
