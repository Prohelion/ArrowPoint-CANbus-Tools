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
    public partial class NetworkSignalForm : Form
    {

        public bool IsOk { get; set; } = false;
        public string SignalName { get { return SignalNameTextBox.Text; } }

        public NetworkSignalForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (SignalNameTextBox.Text.Length > 0) IsOk = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }
    }
}
