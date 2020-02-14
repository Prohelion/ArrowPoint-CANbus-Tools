using ArrowPointCANBusTool.Services;
using System;
using System.Windows.Forms;

namespace ArrowPointCANBusTool.Forms
{
    partial class ChargerControlForm : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChargerControlForm));
            this.startCharge = new System.Windows.Forms.Button();
            this.RequestedChargeVoltage = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.ChargerComboBox = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HW_Ok = new System.Windows.Forms.Label();
            this.Temp_Ok = new System.Windows.Forms.Label();
            this.Comms_Ok = new System.Windows.Forms.Label();
            this.AC_Ok = new System.Windows.Forms.Label();
            this.DC_Ok = new System.Windows.Forms.Label();
            this.chargerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ActualVoltageTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RequestedChargeCurrent = new System.Windows.Forms.NumericUpDown();
            this.maxSocketCurrent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ActualCurrentTxt = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.startDischarge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.chargerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dischargerStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeVoltage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.chargerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeCurrent)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // startCharge
            // 
            this.startCharge.Location = new System.Drawing.Point(64, 260);
            this.startCharge.Name = "startCharge";
            this.startCharge.Size = new System.Drawing.Size(126, 47);
            this.startCharge.TabIndex = 0;
            this.startCharge.Text = "Start Charge";
            this.startCharge.UseVisualStyleBackColor = true;
            this.startCharge.Click += new System.EventHandler(this.StartCharge_ClickAsync);
            // 
            // RequestedChargeVoltage
            // 
            this.RequestedChargeVoltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RequestedChargeVoltage.Location = new System.Drawing.Point(126, 45);
            this.RequestedChargeVoltage.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RequestedChargeVoltage.Name = "RequestedChargeVoltage";
            this.RequestedChargeVoltage.Size = new System.Drawing.Size(55, 20);
            this.RequestedChargeVoltage.TabIndex = 3;
            this.RequestedChargeVoltage.Value = new decimal(new int[] {
            34,
            0,
            0,
            0});
            this.RequestedChargeVoltage.ValueChanged += new System.EventHandler(this.RequestedChargeVoltage_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Charge Voltage (V):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel4);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.chargerLayoutPanel);
            this.groupBox1.Controls.Add(this.startCharge);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 323);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charger";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label23, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.ChargerComboBox, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(9, 33);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(247, 40);
            this.tableLayoutPanel4.TabIndex = 13;
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(73, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 13);
            this.label23.TabIndex = 0;
            this.label23.Text = "Charger:";
            // 
            // ChargerComboBox
            // 
            this.ChargerComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ChargerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChargerComboBox.FormattingEnabled = true;
            this.ChargerComboBox.Items.AddRange(new object[] {
            "Elcon",
            "TDK"});
            this.ChargerComboBox.Location = new System.Drawing.Point(126, 9);
            this.ChargerComboBox.Name = "ChargerComboBox";
            this.ChargerComboBox.Size = new System.Drawing.Size(118, 21);
            this.ChargerComboBox.TabIndex = 1;
            this.ChargerComboBox.SelectedIndexChanged += new System.EventHandler(this.ChargerComboBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.HW_Ok, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Temp_Ok, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Comms_Ok, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.AC_Ok, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DC_Ok, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 199);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 45);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // HW_Ok
            // 
            this.HW_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HW_Ok.AutoSize = true;
            this.HW_Ok.Location = new System.Drawing.Point(17, 4);
            this.HW_Ok.Name = "HW_Ok";
            this.HW_Ok.Size = new System.Drawing.Size(47, 13);
            this.HW_Ok.TabIndex = 0;
            this.HW_Ok.Text = "HW_OK";
            // 
            // Temp_Ok
            // 
            this.Temp_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Temp_Ok.AutoSize = true;
            this.Temp_Ok.Location = new System.Drawing.Point(94, 4);
            this.Temp_Ok.Name = "Temp_Ok";
            this.Temp_Ok.Size = new System.Drawing.Size(58, 13);
            this.Temp_Ok.TabIndex = 1;
            this.Temp_Ok.Text = "TEMP_OK";
            // 
            // Comms_Ok
            // 
            this.Comms_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Comms_Ok.AutoSize = true;
            this.Comms_Ok.Location = new System.Drawing.Point(171, 4);
            this.Comms_Ok.Name = "Comms_Ok";
            this.Comms_Ok.Size = new System.Drawing.Size(68, 13);
            this.Comms_Ok.TabIndex = 2;
            this.Comms_Ok.Text = "COMMS_OK";
            // 
            // AC_Ok
            // 
            this.AC_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AC_Ok.AutoSize = true;
            this.AC_Ok.Location = new System.Drawing.Point(20, 27);
            this.AC_Ok.Name = "AC_Ok";
            this.AC_Ok.Size = new System.Drawing.Size(42, 13);
            this.AC_Ok.TabIndex = 3;
            this.AC_Ok.Text = "AC_OK";
            // 
            // DC_Ok
            // 
            this.DC_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DC_Ok.AutoSize = true;
            this.DC_Ok.Location = new System.Drawing.Point(101, 27);
            this.DC_Ok.Name = "DC_Ok";
            this.DC_Ok.Size = new System.Drawing.Size(43, 13);
            this.DC_Ok.TabIndex = 4;
            this.DC_Ok.Text = "DC_OK";
            // 
            // chargerLayoutPanel
            // 
            this.chargerLayoutPanel.ColumnCount = 3;
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.Controls.Add(this.ActualVoltageTxt, 2, 1);
            this.chargerLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.chargerLayoutPanel.Controls.Add(this.label4, 0, 2);
            this.chargerLayoutPanel.Controls.Add(this.RequestedChargeVoltage, 1, 1);
            this.chargerLayoutPanel.Controls.Add(this.RequestedChargeCurrent, 1, 2);
            this.chargerLayoutPanel.Controls.Add(this.maxSocketCurrent, 1, 0);
            this.chargerLayoutPanel.Controls.Add(this.label3, 0, 0);
            this.chargerLayoutPanel.Controls.Add(this.ActualCurrentTxt, 2, 2);
            this.chargerLayoutPanel.Location = new System.Drawing.Point(9, 80);
            this.chargerLayoutPanel.Name = "chargerLayoutPanel";
            this.chargerLayoutPanel.RowCount = 3;
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.Size = new System.Drawing.Size(247, 112);
            this.chargerLayoutPanel.TabIndex = 11;
            // 
            // ActualVoltageTxt
            // 
            this.ActualVoltageTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ActualVoltageTxt.Location = new System.Drawing.Point(187, 45);
            this.ActualVoltageTxt.Name = "ActualVoltageTxt";
            this.ActualVoltageTxt.ReadOnly = true;
            this.ActualVoltageTxt.Size = new System.Drawing.Size(57, 20);
            this.ActualVoltageTxt.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Charge Current (A):";
            // 
            // RequestedChargeCurrent
            // 
            this.RequestedChargeCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RequestedChargeCurrent.Location = new System.Drawing.Point(126, 83);
            this.RequestedChargeCurrent.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.RequestedChargeCurrent.Name = "RequestedChargeCurrent";
            this.RequestedChargeCurrent.Size = new System.Drawing.Size(55, 20);
            this.RequestedChargeCurrent.TabIndex = 7;
            this.RequestedChargeCurrent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RequestedChargeCurrent.ValueChanged += new System.EventHandler(this.RequestedChargeCurrent_ValueChanged);
            // 
            // maxSocketCurrent
            // 
            this.maxSocketCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxSocketCurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxSocketCurrent.FormattingEnabled = true;
            this.maxSocketCurrent.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "30",
            "31",
            "32",
            "33",
            "34"});
            this.maxSocketCurrent.Location = new System.Drawing.Point(126, 8);
            this.maxSocketCurrent.Name = "maxSocketCurrent";
            this.maxSocketCurrent.Size = new System.Drawing.Size(55, 21);
            this.maxSocketCurrent.TabIndex = 16;
            this.maxSocketCurrent.SelectedIndexChanged += new System.EventHandler(this.MaxSocketCurrent_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max Wall Current (A):";
            // 
            // ActualCurrentTxt
            // 
            this.ActualCurrentTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ActualCurrentTxt.Location = new System.Drawing.Point(187, 83);
            this.ActualCurrentTxt.Name = "ActualCurrentTxt";
            this.ActualCurrentTxt.ReadOnly = true;
            this.ActualCurrentTxt.Size = new System.Drawing.Size(57, 20);
            this.ActualCurrentTxt.TabIndex = 17;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startDischarge);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(278, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(165, 323);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contactor";
            // 
            // startDischarge
            // 
            this.startDischarge.Location = new System.Drawing.Point(18, 257);
            this.startDischarge.Name = "startDischarge";
            this.startDischarge.Size = new System.Drawing.Size(132, 47);
            this.startDischarge.TabIndex = 9;
            this.startDischarge.Text = "Engage Contactor";
            this.startDischarge.UseVisualStyleBackColor = true;
            this.startDischarge.Click += new System.EventHandler(this.StartDischarge_ClickAsync);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerStatusLabel,
            this.dischargerStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 340);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(455, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // chargerStatusLabel
            // 
            this.chargerStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.chargerStatusLabel.Name = "chargerStatusLabel";
            this.chargerStatusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.chargerStatusLabel.Size = new System.Drawing.Size(69, 17);
            this.chargerStatusLabel.Text = "Charger";
            // 
            // dischargerStripStatusLabel
            // 
            this.dischargerStripStatusLabel.Name = "dischargerStripStatusLabel";
            this.dischargerStripStatusLabel.Size = new System.Drawing.Size(103, 17);
            this.dischargerStripStatusLabel.Text = "Contactor Control";
            // 
            // ChargerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 362);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChargerControlForm";
            this.Text = "Charger Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChargerControlForm_FormClosingAsync);
            this.Load += new System.EventHandler(this.ChargerControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeVoltage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.chargerLayoutPanel.ResumeLayout(false);
            this.chargerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeCurrent)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        #endregion

        private System.Windows.Forms.Button startCharge;
        private System.Windows.Forms.NumericUpDown RequestedChargeVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RequestedChargeCurrent;
        private System.Windows.Forms.TableLayoutPanel chargerLayoutPanel;
        private System.Windows.Forms.Button startDischarge;
        private System.Windows.Forms.Label label3;
        private ComboBox maxSocketCurrent;
        private TableLayoutPanel tableLayoutPanel1;
        private Label HW_Ok;
        private Label Temp_Ok;
        private Label Comms_Ok;
        private Label AC_Ok;
        private Label DC_Ok;
        private TextBox ActualVoltageTxt;
        private TextBox ActualCurrentTxt;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel chargerStatusLabel;
        private ToolStripStatusLabel dischargerStripStatusLabel;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label23;
        private ComboBox ChargerComboBox;
    }
}