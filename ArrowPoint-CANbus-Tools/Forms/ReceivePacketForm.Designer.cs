namespace ArrowPointCANBusTool
{
    partial class ReceivePacketForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceivePacketForm));
            this.canPacketGridView = new System.Windows.Forms.DataGridView();
            this.packet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.float1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.float0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbBigEndian = new System.Windows.Forms.CheckBox();
            this.cbAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.SendCan = new System.Windows.Forms.Button();
            this.toTb = new System.Windows.Forms.TextBox();
            this.toLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.fromTb = new System.Windows.Forms.TextBox();
            this.filterCheckBox = new System.Windows.Forms.CheckBox();
            this.clearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canPacketGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canPacketGridView
            // 
            this.canPacketGridView.AllowUserToAddRows = false;
            this.canPacketGridView.AllowUserToDeleteRows = false;
            this.canPacketGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canPacketGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.canPacketGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.canPacketGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.canPacketGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.packet,
            this.canId,
            this.flags,
            this.byte7,
            this.byte6,
            this.byte5,
            this.byte4,
            this.byte3,
            this.byte2,
            this.byte1,
            this.byte0,
            this.int3,
            this.int2,
            this.int1,
            this.int0,
            this.float1,
            this.float0});
            this.canPacketGridView.Location = new System.Drawing.Point(2, 1);
            this.canPacketGridView.Margin = new System.Windows.Forms.Padding(2);
            this.canPacketGridView.Name = "canPacketGridView";
            this.canPacketGridView.ReadOnly = true;
            this.canPacketGridView.RowHeadersVisible = false;
            this.canPacketGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.canPacketGridView.RowTemplate.Height = 28;
            this.canPacketGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.canPacketGridView.Size = new System.Drawing.Size(1074, 196);
            this.canPacketGridView.TabIndex = 4;
            this.canPacketGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView1_CellValueNeeded);
            // 
            // packet
            // 
            this.packet.HeaderText = "packet";
            this.packet.Name = "packet";
            this.packet.ReadOnly = true;
            // 
            // canId
            // 
            this.canId.HeaderText = "canId";
            this.canId.Name = "canId";
            this.canId.ReadOnly = true;
            // 
            // flags
            // 
            this.flags.HeaderText = "flags";
            this.flags.Name = "flags";
            this.flags.ReadOnly = true;
            // 
            // byte7
            // 
            this.byte7.HeaderText = "byte7";
            this.byte7.Name = "byte7";
            this.byte7.ReadOnly = true;
            // 
            // byte6
            // 
            this.byte6.HeaderText = "byte6";
            this.byte6.Name = "byte6";
            this.byte6.ReadOnly = true;
            // 
            // byte5
            // 
            this.byte5.HeaderText = "byte5";
            this.byte5.Name = "byte5";
            this.byte5.ReadOnly = true;
            // 
            // byte4
            // 
            this.byte4.HeaderText = "byte4";
            this.byte4.Name = "byte4";
            this.byte4.ReadOnly = true;
            // 
            // byte3
            // 
            this.byte3.HeaderText = "byte3";
            this.byte3.Name = "byte3";
            this.byte3.ReadOnly = true;
            // 
            // byte2
            // 
            this.byte2.HeaderText = "byte2";
            this.byte2.Name = "byte2";
            this.byte2.ReadOnly = true;
            // 
            // byte1
            // 
            this.byte1.HeaderText = "byte1";
            this.byte1.Name = "byte1";
            this.byte1.ReadOnly = true;
            // 
            // byte0
            // 
            this.byte0.HeaderText = "byte0";
            this.byte0.Name = "byte0";
            this.byte0.ReadOnly = true;
            // 
            // int3
            // 
            this.int3.HeaderText = "int3";
            this.int3.Name = "int3";
            this.int3.ReadOnly = true;
            // 
            // int2
            // 
            this.int2.HeaderText = "int2";
            this.int2.Name = "int2";
            this.int2.ReadOnly = true;
            // 
            // int1
            // 
            this.int1.HeaderText = "int1";
            this.int1.Name = "int1";
            this.int1.ReadOnly = true;
            // 
            // int0
            // 
            this.int0.HeaderText = "int0";
            this.int0.Name = "int0";
            this.int0.ReadOnly = true;
            // 
            // float1
            // 
            this.float1.HeaderText = "float1";
            this.float1.Name = "float1";
            this.float1.ReadOnly = true;
            // 
            // float0
            // 
            this.float0.HeaderText = "float0";
            this.float0.Name = "float0";
            this.float0.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbBigEndian);
            this.panel1.Controls.Add(this.cbAutoScroll);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.SendCan);
            this.panel1.Controls.Add(this.toTb);
            this.panel1.Controls.Add(this.toLbl);
            this.panel1.Controls.Add(this.fromLbl);
            this.panel1.Controls.Add(this.fromTb);
            this.panel1.Controls.Add(this.filterCheckBox);
            this.panel1.Controls.Add(this.clearBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 197);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1078, 39);
            this.panel1.TabIndex = 5;
            // 
            // cbBigEndian
            // 
            this.cbBigEndian.AutoSize = true;
            this.cbBigEndian.Location = new System.Drawing.Point(728, 15);
            this.cbBigEndian.Name = "cbBigEndian";
            this.cbBigEndian.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbBigEndian.Size = new System.Drawing.Size(77, 17);
            this.cbBigEndian.TabIndex = 6;
            this.cbBigEndian.Text = "Big Endian";
            this.cbBigEndian.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbBigEndian.UseVisualStyleBackColor = true;
            // 
            // cbAutoScroll
            // 
            this.cbAutoScroll.AutoSize = true;
            this.cbAutoScroll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAutoScroll.Location = new System.Drawing.Point(628, 15);
            this.cbAutoScroll.Margin = new System.Windows.Forms.Padding(2);
            this.cbAutoScroll.Name = "cbAutoScroll";
            this.cbAutoScroll.Size = new System.Drawing.Size(77, 17);
            this.cbAutoScroll.TabIndex = 8;
            this.cbAutoScroll.Text = "Auto Scroll";
            this.cbAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(2, 4);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(80, 33);
            this.btnPause.TabIndex = 7;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // SendCan
            // 
            this.SendCan.Location = new System.Drawing.Point(171, 4);
            this.SendCan.Margin = new System.Windows.Forms.Padding(2);
            this.SendCan.Name = "SendCan";
            this.SendCan.Size = new System.Drawing.Size(110, 33);
            this.SendCan.TabIndex = 6;
            this.SendCan.Text = "Send Can Message";
            this.SendCan.UseVisualStyleBackColor = true;
            this.SendCan.Click += new System.EventHandler(this.Button1_Click);
            // 
            // toTb
            // 
            this.toTb.Location = new System.Drawing.Point(543, 12);
            this.toTb.Margin = new System.Windows.Forms.Padding(2);
            this.toTb.Name = "toTb";
            this.toTb.Size = new System.Drawing.Size(68, 20);
            this.toTb.TabIndex = 5;
            this.toTb.Leave += new System.EventHandler(this.ToTb_Leave);
            // 
            // toLbl
            // 
            this.toLbl.AutoSize = true;
            this.toLbl.Location = new System.Drawing.Point(491, 15);
            this.toLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.toLbl.Name = "toLbl";
            this.toLbl.Size = new System.Drawing.Size(51, 13);
            this.toLbl.TabIndex = 4;
            this.toLbl.Text = "To (Hex):";
            // 
            // fromLbl
            // 
            this.fromLbl.AutoSize = true;
            this.fromLbl.Location = new System.Drawing.Point(357, 15);
            this.fromLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fromLbl.Name = "fromLbl";
            this.fromLbl.Size = new System.Drawing.Size(61, 13);
            this.fromLbl.TabIndex = 3;
            this.fromLbl.Text = "From (Hex):";
            // 
            // fromTb
            // 
            this.fromTb.Location = new System.Drawing.Point(419, 12);
            this.fromTb.Margin = new System.Windows.Forms.Padding(2);
            this.fromTb.Name = "fromTb";
            this.fromTb.Size = new System.Drawing.Size(68, 20);
            this.fromTb.TabIndex = 2;
            this.fromTb.Leave += new System.EventHandler(this.FromTb_Leave);
            // 
            // filterCheckBox
            // 
            this.filterCheckBox.AutoSize = true;
            this.filterCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.filterCheckBox.Location = new System.Drawing.Point(305, 14);
            this.filterCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.filterCheckBox.Name = "filterCheckBox";
            this.filterCheckBox.Size = new System.Drawing.Size(48, 17);
            this.filterCheckBox.TabIndex = 1;
            this.filterCheckBox.Text = "Filter";
            this.filterCheckBox.UseVisualStyleBackColor = true;
            this.filterCheckBox.CheckedChanged += new System.EventHandler(this.FilterCheckBox_CheckedChanged);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(87, 4);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(80, 33);
            this.clearBtn.TabIndex = 0;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // ReceivePacketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1078, 236);
            this.Controls.Add(this.canPacketGridView);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1053, 53);
            this.Name = "ReceivePacketForm";
            this.Text = "Receive CanPackets";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReceivePacketForm_FormClosing);
            this.Load += new System.EventHandler(this.ReceivePacketForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canPacketGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView canPacketGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox toTb;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label fromLbl;
        private System.Windows.Forms.TextBox fromTb;
        private System.Windows.Forms.CheckBox filterCheckBox;
        private System.Windows.Forms.Button SendCan;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.CheckBox cbAutoScroll;
        private System.Windows.Forms.CheckBox cbBigEndian;
        private System.Windows.Forms.DataGridViewTextBoxColumn packet;
        private System.Windows.Forms.DataGridViewTextBoxColumn canId;
        private System.Windows.Forms.DataGridViewTextBoxColumn flags;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte7;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte6;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte5;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte4;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte3;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte2;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte1;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte0;
        private System.Windows.Forms.DataGridViewTextBoxColumn int3;
        private System.Windows.Forms.DataGridViewTextBoxColumn int2;
        private System.Windows.Forms.DataGridViewTextBoxColumn int1;
        private System.Windows.Forms.DataGridViewTextBoxColumn int0;
        private System.Windows.Forms.DataGridViewTextBoxColumn float1;
        private System.Windows.Forms.DataGridViewTextBoxColumn float0;
    }
}

