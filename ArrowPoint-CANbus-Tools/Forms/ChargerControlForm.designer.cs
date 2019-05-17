using ArrowPointCANBusTool.Charger;
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
            this.startCharge = new System.Windows.Forms.Button();
            this.maxChargeVoltage = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.HW_Ok = new System.Windows.Forms.Label();
            this.Temp_Ok = new System.Windows.Forms.Label();
            this.Comms_Ok = new System.Windows.Forms.Label();
            this.AC_Ok = new System.Windows.Forms.Label();
            this.DC_Ok = new System.Windows.Forms.Label();
            this.chargerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ActualVoltageTxt = new System.Windows.Forms.TextBox();
            this.chargeToPercentage = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxChargeCurrent = new System.Windows.Forms.NumericUpDown();
            this.maxSocketCurrent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ActualCurrentTxt = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.BatterySOC = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.startDischarge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.chargeBar = new System.Windows.Forms.ProgressBar();
            this.dischargeBar = new System.Windows.Forms.ProgressBar();
            this.logView = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.BatteryPackMaTxt = new System.Windows.Forms.TextBox();
            this.BatteryPackMvTxt = new System.Windows.Forms.TextBox();
            this.BatteryCellMinMvTxt = new System.Windows.Forms.TextBox();
            this.BatteryCellMaxMvTxt = new System.Windows.Forms.TextBox();
            this.BatteryMinCTxt = new System.Windows.Forms.TextBox();
            this.BatteryMaxCTxt = new System.Windows.Forms.TextBox();
            this.BatteryBalancePositiveTxt = new System.Windows.Forms.TextBox();
            this.BatteryBalanceNegativeTxt = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeVoltage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.chargerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeToPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeCurrent)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
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
            this.startCharge.Click += new System.EventHandler(this.startCharge_Click);
            // 
            // maxChargeVoltage
            // 
            this.maxChargeVoltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxChargeVoltage.Location = new System.Drawing.Point(126, 41);
            this.maxChargeVoltage.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.maxChargeVoltage.Name = "maxChargeVoltage";
            this.maxChargeVoltage.Size = new System.Drawing.Size(55, 20);
            this.maxChargeVoltage.TabIndex = 3;
            this.maxChargeVoltage.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Charge Voltage (V):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 178);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(247, 66);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // HW_Ok
            // 
            this.HW_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HW_Ok.AutoSize = true;
            this.HW_Ok.Location = new System.Drawing.Point(17, 10);
            this.HW_Ok.Name = "HW_Ok";
            this.HW_Ok.Size = new System.Drawing.Size(47, 13);
            this.HW_Ok.TabIndex = 0;
            this.HW_Ok.Text = "HW_OK";
            // 
            // Temp_Ok
            // 
            this.Temp_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Temp_Ok.AutoSize = true;
            this.Temp_Ok.Location = new System.Drawing.Point(94, 10);
            this.Temp_Ok.Name = "Temp_Ok";
            this.Temp_Ok.Size = new System.Drawing.Size(58, 13);
            this.Temp_Ok.TabIndex = 1;
            this.Temp_Ok.Text = "TEMP_OK";
            // 
            // Comms_Ok
            // 
            this.Comms_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Comms_Ok.AutoSize = true;
            this.Comms_Ok.Location = new System.Drawing.Point(171, 10);
            this.Comms_Ok.Name = "Comms_Ok";
            this.Comms_Ok.Size = new System.Drawing.Size(68, 13);
            this.Comms_Ok.TabIndex = 2;
            this.Comms_Ok.Text = "COMMS_OK";
            // 
            // AC_Ok
            // 
            this.AC_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AC_Ok.AutoSize = true;
            this.AC_Ok.Location = new System.Drawing.Point(20, 43);
            this.AC_Ok.Name = "AC_Ok";
            this.AC_Ok.Size = new System.Drawing.Size(42, 13);
            this.AC_Ok.TabIndex = 3;
            this.AC_Ok.Text = "AC_OK";
            // 
            // DC_Ok
            // 
            this.DC_Ok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DC_Ok.AutoSize = true;
            this.DC_Ok.Location = new System.Drawing.Point(101, 43);
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
            this.chargerLayoutPanel.Controls.Add(this.chargeToPercentage, 1, 3);
            this.chargerLayoutPanel.Controls.Add(this.label5, 0, 3);
            this.chargerLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.chargerLayoutPanel.Controls.Add(this.label4, 0, 2);
            this.chargerLayoutPanel.Controls.Add(this.maxChargeVoltage, 1, 1);
            this.chargerLayoutPanel.Controls.Add(this.maxChargeCurrent, 1, 2);
            this.chargerLayoutPanel.Controls.Add(this.maxSocketCurrent, 1, 0);
            this.chargerLayoutPanel.Controls.Add(this.label3, 0, 0);
            this.chargerLayoutPanel.Controls.Add(this.ActualCurrentTxt, 2, 2);
            this.chargerLayoutPanel.Location = new System.Drawing.Point(9, 33);
            this.chargerLayoutPanel.Name = "chargerLayoutPanel";
            this.chargerLayoutPanel.RowCount = 4;
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chargerLayoutPanel.Size = new System.Drawing.Size(247, 139);
            this.chargerLayoutPanel.TabIndex = 11;
            // 
            // ActualVoltageTxt
            // 
            this.ActualVoltageTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ActualVoltageTxt.Location = new System.Drawing.Point(187, 41);
            this.ActualVoltageTxt.Name = "ActualVoltageTxt";
            this.ActualVoltageTxt.ReadOnly = true;
            this.ActualVoltageTxt.Size = new System.Drawing.Size(57, 20);
            this.ActualVoltageTxt.TabIndex = 13;
            // 
            // chargeToPercentage
            // 
            this.chargeToPercentage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chargeToPercentage.Location = new System.Drawing.Point(126, 110);
            this.chargeToPercentage.Name = "chargeToPercentage";
            this.chargeToPercentage.Size = new System.Drawing.Size(55, 20);
            this.chargeToPercentage.TabIndex = 10;
            this.chargeToPercentage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Charge To (%):";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Charge Current (A):";
            // 
            // maxChargeCurrent
            // 
            this.maxChargeCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.maxChargeCurrent.Location = new System.Drawing.Point(126, 75);
            this.maxChargeCurrent.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.maxChargeCurrent.Name = "maxChargeCurrent";
            this.maxChargeCurrent.Size = new System.Drawing.Size(55, 20);
            this.maxChargeCurrent.TabIndex = 7;
            this.maxChargeCurrent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // maxSocketCurrent
            // 
            this.maxSocketCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
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
            this.maxSocketCurrent.Location = new System.Drawing.Point(126, 6);
            this.maxSocketCurrent.Name = "maxSocketCurrent";
            this.maxSocketCurrent.Size = new System.Drawing.Size(55, 21);
            this.maxSocketCurrent.TabIndex = 16;
            this.maxSocketCurrent.Text = "8";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max Wall Current (A):";
            // 
            // ActualCurrentTxt
            // 
            this.ActualCurrentTxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ActualCurrentTxt.Location = new System.Drawing.Point(187, 75);
            this.ActualCurrentTxt.Name = "ActualCurrentTxt";
            this.ActualCurrentTxt.ReadOnly = true;
            this.ActualCurrentTxt.Size = new System.Drawing.Size(57, 20);
            this.ActualCurrentTxt.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Controls.Add(this.BatterySOC);
            this.groupBox2.Location = new System.Drawing.Point(335, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 320);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Battery";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 7);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 95);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(242, 219);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pack mA:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Pack mV:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Min mV:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Max mV:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Min C";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Max C";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 162);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Balance +";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Balance -";
            // 
            // BatterySOC
            // 
            this.BatterySOC.Enabled = false;
            this.BatterySOC.Location = new System.Drawing.Point(6, 30);
            this.BatterySOC.Name = "BatterySOC";
            this.BatterySOC.Size = new System.Drawing.Size(242, 47);
            this.BatterySOC.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BatterySOC.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startDischarge);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Location = new System.Drawing.Point(652, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 323);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Discharge";
            // 
            // startDischarge
            // 
            this.startDischarge.Location = new System.Drawing.Point(46, 260);
            this.startDischarge.Name = "startDischarge";
            this.startDischarge.Size = new System.Drawing.Size(132, 47);
            this.startDischarge.TabIndex = 9;
            this.startDischarge.Text = "Discharge";
            this.startDischarge.UseVisualStyleBackColor = true;
            this.startDischarge.Click += new System.EventHandler(this.startDischarge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discharge to";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(98, 53);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown2.TabIndex = 0;
            // 
            // chargeBar
            // 
            this.chargeBar.Location = new System.Drawing.Point(278, 12);
            this.chargeBar.Name = "chargeBar";
            this.chargeBar.Size = new System.Drawing.Size(51, 320);
            this.chargeBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.chargeBar.TabIndex = 9;
            this.chargeBar.Value = 99;
            this.chargeBar.Visible = false;
            // 
            // dischargeBar
            // 
            this.dischargeBar.BackColor = System.Drawing.Color.Red;
            this.dischargeBar.ForeColor = System.Drawing.Color.Red;
            this.dischargeBar.Location = new System.Drawing.Point(595, 9);
            this.dischargeBar.Name = "dischargeBar";
            this.dischargeBar.Size = new System.Drawing.Size(51, 323);
            this.dischargeBar.TabIndex = 10;
            this.dischargeBar.Value = 99;
            this.dischargeBar.Visible = false;
            // 
            // logView
            // 
            this.logView.Location = new System.Drawing.Point(5, 338);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(871, 124);
            this.logView.TabIndex = 11;
            this.logView.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Controls.Add(this.progressBar1);
            this.groupBox4.Location = new System.Drawing.Point(335, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 320);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Battery";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label16, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label18, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label20, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label21, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.BatteryPackMaTxt, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.BatteryPackMvTxt, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.BatteryCellMinMvTxt, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.BatteryCellMaxMvTxt, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.BatteryMinCTxt, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.BatteryMaxCTxt, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.BatteryBalancePositiveTxt, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.BatteryBalanceNegativeTxt, 1, 7);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 95);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(242, 219);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(65, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Pack mA:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(65, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Pack mV:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(73, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Min mV:";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(70, 88);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Max mV:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(81, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 13);
            this.label18.TabIndex = 4;
            this.label18.Text = "Min C:";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(78, 142);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "Max C:";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(63, 169);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 13);
            this.label20.TabIndex = 6;
            this.label20.Text = "Balance +";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(66, 197);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 13);
            this.label21.TabIndex = 7;
            this.label21.Text = "Balance -";
            // 
            // BatteryPackMaTxt
            // 
            this.BatteryPackMaTxt.Location = new System.Drawing.Point(124, 3);
            this.BatteryPackMaTxt.Name = "BatteryPackMaTxt";
            this.BatteryPackMaTxt.ReadOnly = true;
            this.BatteryPackMaTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryPackMaTxt.TabIndex = 8;
            // 
            // BatteryPackMvTxt
            // 
            this.BatteryPackMvTxt.Location = new System.Drawing.Point(124, 30);
            this.BatteryPackMvTxt.Name = "BatteryPackMvTxt";
            this.BatteryPackMvTxt.ReadOnly = true;
            this.BatteryPackMvTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryPackMvTxt.TabIndex = 9;
            // 
            // BatteryCellMinMvTxt
            // 
            this.BatteryCellMinMvTxt.Location = new System.Drawing.Point(124, 57);
            this.BatteryCellMinMvTxt.Name = "BatteryCellMinMvTxt";
            this.BatteryCellMinMvTxt.ReadOnly = true;
            this.BatteryCellMinMvTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryCellMinMvTxt.TabIndex = 10;
            // 
            // BatteryCellMaxMvTxt
            // 
            this.BatteryCellMaxMvTxt.Location = new System.Drawing.Point(124, 84);
            this.BatteryCellMaxMvTxt.Name = "BatteryCellMaxMvTxt";
            this.BatteryCellMaxMvTxt.ReadOnly = true;
            this.BatteryCellMaxMvTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryCellMaxMvTxt.TabIndex = 11;
            // 
            // BatteryMinCTxt
            // 
            this.BatteryMinCTxt.Location = new System.Drawing.Point(124, 111);
            this.BatteryMinCTxt.Name = "BatteryMinCTxt";
            this.BatteryMinCTxt.ReadOnly = true;
            this.BatteryMinCTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryMinCTxt.TabIndex = 12;
            // 
            // BatteryMaxCTxt
            // 
            this.BatteryMaxCTxt.Location = new System.Drawing.Point(124, 138);
            this.BatteryMaxCTxt.Name = "BatteryMaxCTxt";
            this.BatteryMaxCTxt.ReadOnly = true;
            this.BatteryMaxCTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryMaxCTxt.TabIndex = 13;
            // 
            // BatteryBalancePositiveTxt
            // 
            this.BatteryBalancePositiveTxt.Location = new System.Drawing.Point(124, 165);
            this.BatteryBalancePositiveTxt.Name = "BatteryBalancePositiveTxt";
            this.BatteryBalancePositiveTxt.ReadOnly = true;
            this.BatteryBalancePositiveTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryBalancePositiveTxt.TabIndex = 14;
            // 
            // BatteryBalanceNegativeTxt
            // 
            this.BatteryBalanceNegativeTxt.Location = new System.Drawing.Point(124, 192);
            this.BatteryBalanceNegativeTxt.Name = "BatteryBalanceNegativeTxt";
            this.BatteryBalanceNegativeTxt.ReadOnly = true;
            this.BatteryBalanceNegativeTxt.Size = new System.Drawing.Size(100, 20);
            this.BatteryBalanceNegativeTxt.TabIndex = 15;
            // 
            // progressBar1
            // 
            this.progressBar1.Enabled = false;
            this.progressBar1.Location = new System.Drawing.Point(6, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(242, 47);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            // 
            // ChargerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 472);
            this.Controls.Add(this.logView);
            this.Controls.Add(this.dischargeBar);
            this.Controls.Add(this.chargeBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChargerControlForm";
            this.Text = "Charger Control";
            this.Load += new System.EventHandler(this.ChargerControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeVoltage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.chargerLayoutPanel.ResumeLayout(false);
            this.chargerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeToPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeCurrent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.NumericUpDown maxChargeVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar BatterySOC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown maxChargeCurrent;
        private System.Windows.Forms.NumericUpDown chargeToPercentage;
        private System.Windows.Forms.ProgressBar chargeBar;
        private System.Windows.Forms.ProgressBar dischargeBar;
        private System.Windows.Forms.TableLayoutPanel chargerLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListView logView;
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
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private GroupBox groupBox4;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private TextBox BatteryPackMaTxt;
        private TextBox BatteryPackMvTxt;
        private TextBox BatteryCellMinMvTxt;
        private TextBox BatteryCellMaxMvTxt;
        private TextBox BatteryMinCTxt;
        private TextBox BatteryMaxCTxt;
        private TextBox BatteryBalancePositiveTxt;
        private TextBox BatteryBalanceNegativeTxt;
        private ProgressBar progressBar1;
    }
}