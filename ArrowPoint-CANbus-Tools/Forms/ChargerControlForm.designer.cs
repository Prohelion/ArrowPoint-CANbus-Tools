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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChargerControlForm));
            this.startCharge = new System.Windows.Forms.Button();
            this.RequestedChargeVoltage = new System.Windows.Forms.NumericUpDown();
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
            this.RequestedChargeCurrent = new System.Windows.Forms.NumericUpDown();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.SOCText = new System.Windows.Forms.Label();
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.batteryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.chargerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dischargerStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SaveData = new System.Windows.Forms.Button();
            this.ClearData = new System.Windows.Forms.Button();
            this.ChargeChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeVoltage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.chargerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeToPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeCurrent)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChargeChart)).BeginInit();
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
            this.startCharge.Click += new System.EventHandler(this.StartCharge_Click);
            // 
            // RequestedChargeVoltage
            // 
            this.RequestedChargeVoltage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RequestedChargeVoltage.Location = new System.Drawing.Point(126, 41);
            this.RequestedChargeVoltage.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.RequestedChargeVoltage.Name = "RequestedChargeVoltage";
            this.RequestedChargeVoltage.Size = new System.Drawing.Size(55, 20);
            this.RequestedChargeVoltage.TabIndex = 3;
            this.RequestedChargeVoltage.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.RequestedChargeVoltage.ValueChanged += new System.EventHandler(this.RequestedChargeVoltage_ValueChanged);
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
            this.chargerLayoutPanel.Controls.Add(this.RequestedChargeVoltage, 1, 1);
            this.chargerLayoutPanel.Controls.Add(this.RequestedChargeCurrent, 1, 2);
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
            this.chargeToPercentage.ValueChanged += new System.EventHandler(this.ChargeToPercentage_ValueChanged);
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
            // RequestedChargeCurrent
            // 
            this.RequestedChargeCurrent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RequestedChargeCurrent.Location = new System.Drawing.Point(126, 75);
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
            this.maxSocketCurrent.SelectedIndexChanged += new System.EventHandler(this.MaxSocketCurrent_SelectedIndexChanged);
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
            this.startDischarge.Click += new System.EventHandler(this.StartDischarge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Discharge to (%)";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(106, 53);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.SOCText);
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Location = new System.Drawing.Point(335, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 320);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Battery";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(29, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(95, 39);
            this.label22.TabIndex = 13;
            this.label22.Text = "SOC";
            // 
            // SOCText
            // 
            this.SOCText.AutoSize = true;
            this.SOCText.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SOCText.Location = new System.Drawing.Point(130, 30);
            this.SOCText.Name = "SOCText";
            this.SOCText.Size = new System.Drawing.Size(69, 39);
            this.SOCText.TabIndex = 12;
            this.SOCText.Text = "0%";
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
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batteryStatusLabel,
            this.chargerStatusLabel,
            this.dischargerStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 565);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(883, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // batteryStatusLabel
            // 
            this.batteryStatusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.batteryStatusLabel.Name = "batteryStatusLabel";
            this.batteryStatusLabel.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.batteryStatusLabel.Size = new System.Drawing.Size(64, 17);
            this.batteryStatusLabel.Text = "Battery";
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
            this.dischargerStripStatusLabel.Size = new System.Drawing.Size(63, 17);
            this.dischargerStripStatusLabel.Text = "Discharger";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SaveData);
            this.groupBox5.Controls.Add(this.ClearData);
            this.groupBox5.Controls.Add(this.ChargeChart);
            this.groupBox5.Location = new System.Drawing.Point(6, 337);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(869, 225);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            // 
            // SaveData
            // 
            this.SaveData.Location = new System.Drawing.Point(752, 173);
            this.SaveData.Name = "SaveData";
            this.SaveData.Size = new System.Drawing.Size(104, 36);
            this.SaveData.TabIndex = 17;
            this.SaveData.Text = "Save";
            this.SaveData.UseVisualStyleBackColor = true;
            // 
            // ClearData
            // 
            this.ClearData.Location = new System.Drawing.Point(751, 131);
            this.ClearData.Name = "ClearData";
            this.ClearData.Size = new System.Drawing.Size(105, 36);
            this.ClearData.TabIndex = 16;
            this.ClearData.Text = "Clear Data";
            this.ClearData.UseVisualStyleBackColor = true;
            // 
            // ChargeChart
            // 
            this.ChargeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChargeChart.BackColor = System.Drawing.SystemColors.Control;
            this.ChargeChart.BorderlineColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea1.Name = "ChartArea1";
            this.ChargeChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChargeChart.Legends.Add(legend1);
            this.ChargeChart.Location = new System.Drawing.Point(6, 10);
            this.ChargeChart.Name = "ChargeChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.Name = "Voltage";
            series1.XValueMember = "DateTime";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "PackV";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "SOC";
            series2.XValueMember = "DateTime";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "SOCAsInt";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Current";
            series3.XValueMember = "DateTime";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.YValueMembers = "ChargeCurrentA";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.Name = "Max Cell Temp";
            series4.XValueMember = "DateTime";
            series4.YValueMembers = "MaxCellTempC";
            this.ChargeChart.Series.Add(series1);
            this.ChargeChart.Series.Add(series2);
            this.ChargeChart.Series.Add(series3);
            this.ChargeChart.Series.Add(series4);
            this.ChargeChart.Size = new System.Drawing.Size(857, 209);
            this.ChargeChart.TabIndex = 15;
            this.ChargeChart.Text = "chart1";
            // 
            // ChargerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 587);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChargerControlForm";
            this.Text = "Charger Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChargerControlForm_FormClosing);
            this.Load += new System.EventHandler(this.ChargerControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeVoltage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.chargerLayoutPanel.ResumeLayout(false);
            this.chargerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeToPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestedChargeCurrent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ChargeChart)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar BatterySOC;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown RequestedChargeCurrent;
        private System.Windows.Forms.NumericUpDown chargeToPercentage;
        private System.Windows.Forms.TableLayoutPanel chargerLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
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
        private Label SOCText;
        private StatusStrip statusStrip;
        private Label label22;
        private ToolStripStatusLabel batteryStatusLabel;
        private ToolStripStatusLabel chargerStatusLabel;
        private ToolStripStatusLabel dischargerStripStatusLabel;
        private GroupBox groupBox5;
        private Button SaveData;
        private Button ClearData;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChargeChart;
    }
}