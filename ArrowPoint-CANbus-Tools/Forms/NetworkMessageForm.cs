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
    public partial class NetworkMessageForm : Form
    {
        public bool IsOk { get; set; } = false;
        public string MessageName { get { return MessageNameTextBox.Text; } }

        public NetworkMessageForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (MessageNameTextBox.Text.Length > 0) IsOk = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            IsOk = false;
            this.Close();
        }
    }
}
