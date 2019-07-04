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
        private Configuration.Message message;

        public bool IsOk { get; set; } = false;
        public Configuration.Message Message
        {
            get
            {
                message.name = MessageNameTextBox.Text;
                message.id = CanIdTextBox.Text;
                return message;
            }
        }
        
        public NetworkMessageForm()
        {
            InitializeComponent();
        }

        public NetworkMessageForm(Configuration.Message message)
        {
            InitializeComponent();
            
            this.message = message;
            MessageNameTextBox.Text = message.name;
            CanIdTextBox.Text = message.id;
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
