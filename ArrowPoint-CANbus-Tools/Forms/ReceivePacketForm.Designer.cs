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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceivePacketForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAutoScroll = new System.Windows.Forms.CheckBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toTb = new System.Windows.Forms.TextBox();
            this.toLbl = new System.Windows.Forms.Label();
            this.fromLbl = new System.Windows.Forms.Label();
            this.fromTb = new System.Windows.Forms.TextBox();
            this.filterCheckBox = new System.Windows.Forms.CheckBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.canPacketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.packetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanIdBase10DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flagsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte7DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte6DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte5DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte4DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.byte0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.int0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.float1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.float0DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rawBytesStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canPacketBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.packetDataGridViewTextBoxColumn,
            this.canIdDataGridViewTextBoxColumn,
            this.CanIdBase10DataGridViewTextBoxColumn,
            this.flagsDataGridViewTextBoxColumn,
            this.byte7DataGridViewTextBoxColumn,
            this.byte6DataGridViewTextBoxColumn,
            this.byte5DataGridViewTextBoxColumn,
            this.byte4DataGridViewTextBoxColumn,
            this.byte3DataGridViewTextBoxColumn,
            this.byte2DataGridViewTextBoxColumn,
            this.byte1DataGridViewTextBoxColumn,
            this.byte0DataGridViewTextBoxColumn,
            this.int3DataGridViewTextBoxColumn,
            this.int2DataGridViewTextBoxColumn,
            this.int1DataGridViewTextBoxColumn,
            this.int0DataGridViewTextBoxColumn,
            this.float1DataGridViewTextBoxColumn,
            this.float0DataGridViewTextBoxColumn,
            this.rawBytesStrDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.canPacketBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1078, 197);
            this.dataGridView1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbAutoScroll);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 4);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "Copy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
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
            // canPacketBindingSource
            // 
            this.canPacketBindingSource.DataSource = typeof(ArrowPointCANBusTool.CanBus.CanPacket);
            // 
            // packetDataGridViewTextBoxColumn
            // 
            this.packetDataGridViewTextBoxColumn.DataPropertyName = "PacketIndex";
            this.packetDataGridViewTextBoxColumn.HeaderText = "packet";
            this.packetDataGridViewTextBoxColumn.Name = "packetDataGridViewTextBoxColumn";
            this.packetDataGridViewTextBoxColumn.ReadOnly = true;
            this.packetDataGridViewTextBoxColumn.Width = 65;
            // 
            // canIdDataGridViewTextBoxColumn
            // 
            this.canIdDataGridViewTextBoxColumn.DataPropertyName = "CanIdAsHex";
            this.canIdDataGridViewTextBoxColumn.HeaderText = "canId";
            this.canIdDataGridViewTextBoxColumn.Name = "canIdDataGridViewTextBoxColumn";
            this.canIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.canIdDataGridViewTextBoxColumn.Width = 59;
            // 
            // CanIdBase10DataGridViewTextBoxColumn
            // 
            this.CanIdBase10DataGridViewTextBoxColumn.DataPropertyName = "CanIdBase10";
            this.CanIdBase10DataGridViewTextBoxColumn.HeaderText = "CanIdBase10";
            this.CanIdBase10DataGridViewTextBoxColumn.Name = "CanIdBase10DataGridViewTextBoxColumn";
            this.CanIdBase10DataGridViewTextBoxColumn.ReadOnly = true;
            this.CanIdBase10DataGridViewTextBoxColumn.Width = 96;
            // 
            // flagsDataGridViewTextBoxColumn
            // 
            this.flagsDataGridViewTextBoxColumn.DataPropertyName = "Flags";
            this.flagsDataGridViewTextBoxColumn.HeaderText = "flags";
            this.flagsDataGridViewTextBoxColumn.Name = "flagsDataGridViewTextBoxColumn";
            this.flagsDataGridViewTextBoxColumn.ReadOnly = true;
            this.flagsDataGridViewTextBoxColumn.Width = 54;
            // 
            // byte7DataGridViewTextBoxColumn
            // 
            this.byte7DataGridViewTextBoxColumn.DataPropertyName = "Byte7AsHex";
            this.byte7DataGridViewTextBoxColumn.HeaderText = "byte7";
            this.byte7DataGridViewTextBoxColumn.Name = "byte7DataGridViewTextBoxColumn";
            this.byte7DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte7DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte6DataGridViewTextBoxColumn
            // 
            this.byte6DataGridViewTextBoxColumn.DataPropertyName = "Byte6AsHex";
            this.byte6DataGridViewTextBoxColumn.HeaderText = "byte6";
            this.byte6DataGridViewTextBoxColumn.Name = "byte6DataGridViewTextBoxColumn";
            this.byte6DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte6DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte5DataGridViewTextBoxColumn
            // 
            this.byte5DataGridViewTextBoxColumn.DataPropertyName = "Byte5AsHex";
            this.byte5DataGridViewTextBoxColumn.HeaderText = "byte5";
            this.byte5DataGridViewTextBoxColumn.Name = "byte5DataGridViewTextBoxColumn";
            this.byte5DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte5DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte4DataGridViewTextBoxColumn
            // 
            this.byte4DataGridViewTextBoxColumn.DataPropertyName = "Byte4AsHex";
            this.byte4DataGridViewTextBoxColumn.HeaderText = "byte4";
            this.byte4DataGridViewTextBoxColumn.Name = "byte4DataGridViewTextBoxColumn";
            this.byte4DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte4DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte3DataGridViewTextBoxColumn
            // 
            this.byte3DataGridViewTextBoxColumn.DataPropertyName = "Byte3AsHex";
            this.byte3DataGridViewTextBoxColumn.HeaderText = "byte3";
            this.byte3DataGridViewTextBoxColumn.Name = "byte3DataGridViewTextBoxColumn";
            this.byte3DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte3DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte2DataGridViewTextBoxColumn
            // 
            this.byte2DataGridViewTextBoxColumn.DataPropertyName = "Byte2AsHex";
            this.byte2DataGridViewTextBoxColumn.HeaderText = "byte2";
            this.byte2DataGridViewTextBoxColumn.Name = "byte2DataGridViewTextBoxColumn";
            this.byte2DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte2DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte1DataGridViewTextBoxColumn
            // 
            this.byte1DataGridViewTextBoxColumn.DataPropertyName = "Byte1AsHex";
            this.byte1DataGridViewTextBoxColumn.HeaderText = "byte1";
            this.byte1DataGridViewTextBoxColumn.Name = "byte1DataGridViewTextBoxColumn";
            this.byte1DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte1DataGridViewTextBoxColumn.Width = 58;
            // 
            // byte0DataGridViewTextBoxColumn
            // 
            this.byte0DataGridViewTextBoxColumn.DataPropertyName = "Byte0AsHex";
            this.byte0DataGridViewTextBoxColumn.HeaderText = "byte0";
            this.byte0DataGridViewTextBoxColumn.Name = "byte0DataGridViewTextBoxColumn";
            this.byte0DataGridViewTextBoxColumn.ReadOnly = true;
            this.byte0DataGridViewTextBoxColumn.Width = 58;
            // 
            // int3DataGridViewTextBoxColumn
            // 
            this.int3DataGridViewTextBoxColumn.DataPropertyName = "Int3";
            this.int3DataGridViewTextBoxColumn.HeaderText = "int3";
            this.int3DataGridViewTextBoxColumn.Name = "int3DataGridViewTextBoxColumn";
            this.int3DataGridViewTextBoxColumn.ReadOnly = true;
            this.int3DataGridViewTextBoxColumn.Width = 49;
            // 
            // int2DataGridViewTextBoxColumn
            // 
            this.int2DataGridViewTextBoxColumn.DataPropertyName = "Int2";
            this.int2DataGridViewTextBoxColumn.HeaderText = "int2";
            this.int2DataGridViewTextBoxColumn.Name = "int2DataGridViewTextBoxColumn";
            this.int2DataGridViewTextBoxColumn.ReadOnly = true;
            this.int2DataGridViewTextBoxColumn.Width = 49;
            // 
            // int1DataGridViewTextBoxColumn
            // 
            this.int1DataGridViewTextBoxColumn.DataPropertyName = "Int1";
            this.int1DataGridViewTextBoxColumn.HeaderText = "int1";
            this.int1DataGridViewTextBoxColumn.Name = "int1DataGridViewTextBoxColumn";
            this.int1DataGridViewTextBoxColumn.ReadOnly = true;
            this.int1DataGridViewTextBoxColumn.Width = 49;
            // 
            // int0DataGridViewTextBoxColumn
            // 
            this.int0DataGridViewTextBoxColumn.DataPropertyName = "Int0";
            this.int0DataGridViewTextBoxColumn.HeaderText = "int0";
            this.int0DataGridViewTextBoxColumn.Name = "int0DataGridViewTextBoxColumn";
            this.int0DataGridViewTextBoxColumn.ReadOnly = true;
            this.int0DataGridViewTextBoxColumn.Width = 49;
            // 
            // float1DataGridViewTextBoxColumn
            // 
            this.float1DataGridViewTextBoxColumn.DataPropertyName = "Float1";
            this.float1DataGridViewTextBoxColumn.HeaderText = "float1";
            this.float1DataGridViewTextBoxColumn.Name = "float1DataGridViewTextBoxColumn";
            this.float1DataGridViewTextBoxColumn.ReadOnly = true;
            this.float1DataGridViewTextBoxColumn.Width = 58;
            // 
            // float0DataGridViewTextBoxColumn
            // 
            this.float0DataGridViewTextBoxColumn.DataPropertyName = "Float0";
            this.float0DataGridViewTextBoxColumn.HeaderText = "float0";
            this.float0DataGridViewTextBoxColumn.Name = "float0DataGridViewTextBoxColumn";
            this.float0DataGridViewTextBoxColumn.ReadOnly = true;
            this.float0DataGridViewTextBoxColumn.Width = 58;
            // 
            // rawBytesStrDataGridViewTextBoxColumn
            // 
            this.rawBytesStrDataGridViewTextBoxColumn.DataPropertyName = "RawBytesString";
            this.rawBytesStrDataGridViewTextBoxColumn.HeaderText = "rawBytesStr";
            this.rawBytesStrDataGridViewTextBoxColumn.Name = "rawBytesStrDataGridViewTextBoxColumn";
            this.rawBytesStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.rawBytesStrDataGridViewTextBoxColumn.Width = 88;
            // 
            // ReceivePacketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1078, 236);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1053, 53);
            this.Name = "ReceivePacketForm";
            this.Text = "Receive CanPackets";
            this.Load += new System.EventHandler(this.ReceivePacketForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canPacketBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox toTb;
        private System.Windows.Forms.Label toLbl;
        private System.Windows.Forms.Label fromLbl;
        private System.Windows.Forms.TextBox fromTb;
        private System.Windows.Forms.CheckBox filterCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.BindingSource canPacketBindingSource;
        private System.Windows.Forms.CheckBox cbAutoScroll;
        private System.Windows.Forms.DataGridViewTextBoxColumn packetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn canIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanIdBase10DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn flagsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte7DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte6DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte5DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte4DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn byte0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn int3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn int2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn int1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn int0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn float1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn float0DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rawBytesStrDataGridViewTextBoxColumn;
    }
}

