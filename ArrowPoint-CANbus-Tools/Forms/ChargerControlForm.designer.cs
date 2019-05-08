using ArrowPointCANBusTool.Charger;
using ArrowPointCANBusTool.Service;
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chargerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.runTests = new System.Windows.Forms.Button();
            this.testList = new System.Windows.Forms.ListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.chargerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(120, 40);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 37);
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
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.chargerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.chargerLayoutPanel.Controls.Add(this.numericUpDown5, 1, 3);
            this.chargerLayoutPanel.Controls.Add(this.numericUpDown3, 1, 0);
            this.chargerLayoutPanel.Controls.Add(this.label5, 0, 3);
            this.chargerLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.chargerLayoutPanel.Controls.Add(this.label4, 0, 2);
            this.chargerLayoutPanel.Controls.Add(this.numericUpDown1, 1, 1);
            this.chargerLayoutPanel.Controls.Add(this.numericUpDown4, 1, 2);
            this.chargerLayoutPanel.Controls.Add(this.label3, 0, 0);
            this.chargerLayoutPanel.Controls.Add(this.label6, 2, 0);
            this.chargerLayoutPanel.Controls.Add(this.label7, 2, 1);
            this.chargerLayoutPanel.Controls.Add(this.label8, 2, 2);
            this.chargerLayoutPanel.Controls.Add(this.label9, 2, 3);
            this.chargerLayoutPanel.Location = new System.Drawing.Point(9, 45);
            this.chargerLayoutPanel.Name = "chargerLayoutPanel";
            this.chargerLayoutPanel.RowCount = 4;
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.67442F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.32558F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.chargerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.chargerLayoutPanel.Size = new System.Drawing.Size(200, 157);
            this.chargerLayoutPanel.TabIndex = 11;            
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(120, 124);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown5.TabIndex = 10;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(120, 3);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown3.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Charge To Percentage";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Charge Current";            
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(120, 80);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown4.TabIndex = 7;
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(183, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "V";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(183, 121);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "%";
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
            this.statusStrip1.Size = new System.Drawing.Size(1067, 22);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.runTests);
            this.groupBox4.Controls.Add(this.testList);
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(846, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 449);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Test Suite";
            // 
            // runTests
            // 
            this.runTests.Location = new System.Drawing.Point(134, 21);
            this.runTests.Name = "runTests";
            this.runTests.Size = new System.Drawing.Size(72, 30);
            this.runTests.TabIndex = 2;
            this.runTests.Text = "Run Tests";
            this.runTests.UseVisualStyleBackColor = true;
            // 
            // testList
            // 
            this.testList.FormattingEnabled = true;
            this.testList.Location = new System.Drawing.Point(6, 21);
            this.testList.Name = "testList";
            this.testList.Size = new System.Drawing.Size(126, 30);
            this.testList.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 66);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(200, 377);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // ChargerControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 498);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.logView);
            this.Controls.Add(this.dischargeBar);
            this.Controls.Add(this.chargeBar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChargerControlForm";
            this.Text = "Charger Control";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.chargerLayoutPanel.ResumeLayout(false);
            this.chargerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
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
                chargeService.StartCharge();
                startCharge.Text = "Stop Charge";
                chargeBar.Visible = true;
            }
        }

        #endregion

        private System.Windows.Forms.Button startCharge;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ProgressBar Battery;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button runTests;
        private System.Windows.Forms.ListBox testList;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}