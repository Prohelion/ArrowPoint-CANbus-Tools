﻿using ArrowPointCANBusTool.Charger;
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

        private UdpService udpService;
        private ChargeService chargeService;

        public ChargerControlForm(UdpService udpService)
        {
            InitializeComponent();
            this.udpService = udpService;

            this.chargeService = new ChargeService(udpService);

        }

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
            this.chargerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.chargeToPercentage = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.maxChargeCurrent = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.maxSocketCurrent = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Battery = new System.Windows.Forms.ProgressBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.startDischarge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.chargeBar = new System.Windows.Forms.ProgressBar();
            this.dischargeBar = new System.Windows.Forms.ProgressBar();
            this.logView = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.batteryStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.chargerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dischargerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeVoltage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.chargerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeToPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeCurrent)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startCharge
            // 
            this.startCharge.Location = new System.Drawing.Point(48, 227);
            this.startCharge.Name = "startCharge";
            this.startCharge.Size = new System.Drawing.Size(126, 47);
            this.startCharge.TabIndex = 0;
            this.startCharge.Text = "Start Charge";
            this.startCharge.UseVisualStyleBackColor = true;
            this.startCharge.Click += new System.EventHandler(this.startCharge_Click);
            // 
            // maxChargeVoltage
            // 
            this.maxChargeVoltage.Location = new System.Drawing.Point(115, 54);
            this.maxChargeVoltage.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.maxChargeVoltage.Name = "maxChargeVoltage";
            this.maxChargeVoltage.Size = new System.Drawing.Size(76, 20);
            this.maxChargeVoltage.TabIndex = 3;
            this.maxChargeVoltage.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Max Charge Voltage";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chargerLayoutPanel);
            this.groupBox1.Controls.Add(this.startCharge);
            this.groupBox1.Location = new System.Drawing.Point(5, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 280);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Charger";
            // 
            // chargerLayoutPanel
            // 
            this.chargerLayoutPanel.ColumnCount = 3;
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.4359F));
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.5641F));
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.chargerLayoutPanel.Controls.Add(this.chargeToPercentage, 1, 3);
            this.chargerLayoutPanel.Controls.Add(this.label5, 0, 3);
            this.chargerLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.chargerLayoutPanel.Controls.Add(this.label4, 0, 2);
            this.chargerLayoutPanel.Controls.Add(this.maxChargeVoltage, 1, 1);
            this.chargerLayoutPanel.Controls.Add(this.maxChargeCurrent, 1, 2);
            this.chargerLayoutPanel.Controls.Add(this.label6, 2, 0);
            this.chargerLayoutPanel.Controls.Add(this.label7, 2, 1);
            this.chargerLayoutPanel.Controls.Add(this.label8, 2, 2);
            this.chargerLayoutPanel.Controls.Add(this.label9, 2, 3);
            this.chargerLayoutPanel.Controls.Add(this.maxSocketCurrent, 1, 0);
            this.chargerLayoutPanel.Controls.Add(this.label3, 0, 0);
            this.chargerLayoutPanel.Location = new System.Drawing.Point(9, 33);
            this.chargerLayoutPanel.Name = "chargerLayoutPanel";
            this.chargerLayoutPanel.RowCount = 4;
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.67442F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.32558F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.chargerLayoutPanel.Size = new System.Drawing.Size(216, 188);
            this.chargerLayoutPanel.TabIndex = 11;
            // 
            // chargeToPercentage
            // 
            this.chargeToPercentage.Location = new System.Drawing.Point(115, 155);
            this.chargeToPercentage.Name = "chargeToPercentage";
            this.chargeToPercentage.Size = new System.Drawing.Size(76, 20);
            this.chargeToPercentage.TabIndex = 10;
            this.chargeToPercentage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Charge To Percentage";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Charge Current";
            // 
            // maxChargeCurrent
            // 
            this.maxChargeCurrent.Location = new System.Drawing.Point(115, 111);
            this.maxChargeCurrent.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.maxChargeCurrent.Name = "maxChargeCurrent";
            this.maxChargeCurrent.Size = new System.Drawing.Size(76, 20);
            this.maxChargeCurrent.TabIndex = 7;
            this.maxChargeCurrent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "V";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(197, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "%";
            // 
            // maxSocketCurrent
            // 
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
            this.maxSocketCurrent.Location = new System.Drawing.Point(115, 3);
            this.maxSocketCurrent.Name = "maxSocketCurrent";
            this.maxSocketCurrent.Size = new System.Drawing.Size(76, 21);
            this.maxSocketCurrent.TabIndex = 16;
            this.maxSocketCurrent.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Max Wall Current";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Controls.Add(this.Battery);
            this.groupBox2.Location = new System.Drawing.Point(299, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 280);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Battery";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(24, 72);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(206, 100);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // Battery
            // 
            this.Battery.Enabled = false;
            this.Battery.Location = new System.Drawing.Point(24, 19);
            this.Battery.Name = "Battery";
            this.Battery.Size = new System.Drawing.Size(206, 47);
            this.Battery.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Battery.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.startDischarge);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Location = new System.Drawing.Point(616, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 280);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Discharge";
            // 
            // startDischarge
            // 
            this.startDischarge.Location = new System.Drawing.Point(46, 227);
            this.startDischarge.Name = "startDischarge";
            this.startDischarge.Size = new System.Drawing.Size(132, 47);
            this.startDischarge.TabIndex = 9;
            this.startDischarge.Text = "Discharge";
            this.startDischarge.UseVisualStyleBackColor = true;
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
            this.chargeBar.Location = new System.Drawing.Point(242, 9);
            this.chargeBar.Name = "chargeBar";
            this.chargeBar.Size = new System.Drawing.Size(51, 280);
            this.chargeBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.chargeBar.TabIndex = 9;
            this.chargeBar.Value = 99;
            this.chargeBar.Visible = false;
            // 
            // dischargeBar
            // 
            this.dischargeBar.BackColor = System.Drawing.Color.Red;
            this.dischargeBar.ForeColor = System.Drawing.Color.Red;
            this.dischargeBar.Location = new System.Drawing.Point(559, 9);
            this.dischargeBar.Name = "dischargeBar";
            this.dischargeBar.Size = new System.Drawing.Size(51, 280);
            this.dischargeBar.TabIndex = 10;
            this.dischargeBar.Value = 99;
            this.dischargeBar.Visible = false;
            // 
            // logView
            // 
            this.logView.Location = new System.Drawing.Point(5, 295);
            this.logView.Name = "logView";
            this.logView.Size = new System.Drawing.Size(835, 157);
            this.logView.TabIndex = 11;
            this.logView.UseCompatibleStateImageBehavior = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batteryStatusLabel,
            this.chargerStatusLabel,
            this.dischargerStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(848, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // batteryStatusLabel
            // 
            this.batteryStatusLabel.Name = "batteryStatusLabel";
            this.batteryStatusLabel.Size = new System.Drawing.Size(44, 17);
            this.batteryStatusLabel.Text = "Battery";
            // 
            // chargerStatusLabel
            // 
            this.chargerStatusLabel.Name = "chargerStatusLabel";
            this.chargerStatusLabel.Size = new System.Drawing.Size(49, 17);
            this.chargerStatusLabel.Text = "Charger";
            // 
            // dischargerStatusLabel
            // 
            this.dischargerStatusLabel.Name = "dischargerStatusLabel";
            this.dischargerStatusLabel.Size = new System.Drawing.Size(63, 17);
            this.dischargerStatusLabel.Text = "Discharger";
            // 
            // ChargerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 498);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.logView);
            this.Controls.Add(this.dischargeBar);
            this.Controls.Add(this.chargeBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChargerControlForm";
            this.Text = "Charger Control";
            this.Load += new System.EventHandler(this.ChargerControlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeVoltage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.chargerLayoutPanel.ResumeLayout(false);
            this.chargerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chargeToPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxChargeCurrent)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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

        private void startCharge_Click(object sender, EventArgs e)
        {
            if (chargeService.IsCharging())
            {
                chargeService.StopCharge();
                startCharge.Text = "Start Charge";
                chargeBar.Visible = false;
            }
            else
            {                
                chargeService.RequestedCurrent = float.Parse(maxChargeCurrent.Value.ToString());
                chargeService.RequestedVoltage = float.Parse(maxChargeVoltage.Value.ToString());
                chargeService.SupplyCurrentLimit = float.Parse(maxSocketCurrent.SelectedItem.ToString());
                chargeService.StartCharge();
                startCharge.Text = "Stop Charge";
                chargeBar.Visible = true;
            }
        }

        #endregion

        private System.Windows.Forms.Button startCharge;
        private System.Windows.Forms.NumericUpDown maxChargeVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar Battery;
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel batteryStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel chargerStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel dischargerStatusLabel;
        private System.Windows.Forms.Button startDischarge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private ComboBox maxSocketCurrent;
    }
}