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
    public partial class NewReleaseForm : Form
    {

        UpdateService updateService;

        public NewReleaseForm(UpdateService updateService)
        {
            InitializeComponent();
            this.updateService = updateService;
        }

        private void Btn_GetRelease_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(UpdateService.RELEASE_URL);
        }

        private void NewReleaseForm_Load(object sender, EventArgs e)
        {
            if (updateService != null)
            {
                TxtReleaseNumber.Text = updateService.ReleaseName + " : " + updateService.ReleaseNumber;
                TxtDetails.Text = updateService.ReleaseDesc;
            }
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
