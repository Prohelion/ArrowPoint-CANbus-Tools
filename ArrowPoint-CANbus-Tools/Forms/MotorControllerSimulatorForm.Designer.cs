namespace ArrowPointCANBusTool.Forms
{
    partial class MotorControllerSimulatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotorControllerSimulatorForm));
            this.btnStartStopSim = new System.Windows.Forms.Button();
            this.tbMotorVelocity = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRegen = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMotorTemp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbControllerTemp = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBatteryCurrent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBatteryVoltage = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNeutral = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartStopSim
            // 
            this.btnStartStopSim.Location = new System.Drawing.Point(278, 170);
            this.btnStartStopSim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartStopSim.Name = "btnStartStopSim";
            this.btnStartStopSim.Size = new System.Drawing.Size(82, 35);
            this.btnStartStopSim.TabIndex = 0;
            this.btnStartStopSim.Text = "Start";
            this.btnStartStopSim.UseVisualStyleBackColor = true;
            this.btnStartStopSim.Click += new System.EventHandler(this.BtnStartStopSim_Click);
            // 
            // tbMotorVelocity
            // 
            this.tbMotorVelocity.Location = new System.Drawing.Point(104, 16);
            this.tbMotorVelocity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMotorVelocity.Name = "tbMotorVelocity";
            this.tbMotorVelocity.Size = new System.Drawing.Size(70, 20);
            this.tbMotorVelocity.TabIndex = 100;
            this.tbMotorVelocity.Leave += new System.EventHandler(this.TbMotorVelocity_Leave);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(5, 16);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(74, 13);
            this.label28.TabIndex = 101;
            this.label28.Text = "Motor Velocity";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.tbMotorVelocity);
            this.groupBox1.Location = new System.Drawing.Point(5, 47);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(176, 38);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MC_VELOCITY (0x403)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbRegen);
            this.groupBox2.Location = new System.Drawing.Point(5, 88);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(176, 38);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MC_I_VECTOR (0x406)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 101;
            this.label2.Text = "Regen";
            // 
            // tbRegen
            // 
            this.tbRegen.Location = new System.Drawing.Point(104, 16);
            this.tbRegen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbRegen.Name = "tbRegen";
            this.tbRegen.Size = new System.Drawing.Size(70, 20);
            this.tbRegen.TabIndex = 100;
            this.tbRegen.Leave += new System.EventHandler(this.TbRegen_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tbMotorTemp);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tbControllerTemp);
            this.groupBox3.Location = new System.Drawing.Point(184, 88);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(176, 79);
            this.groupBox3.TabIndex = 106;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MC_TEMP1 (0x40B)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Motor Temp";
            // 
            // tbMotorTemp
            // 
            this.tbMotorTemp.Location = new System.Drawing.Point(104, 40);
            this.tbMotorTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbMotorTemp.Name = "tbMotorTemp";
            this.tbMotorTemp.Size = new System.Drawing.Size(70, 20);
            this.tbMotorTemp.TabIndex = 102;
            this.tbMotorTemp.Leave += new System.EventHandler(this.TbMotorTemp_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 101;
            this.label1.Text = "Controller Temp";
            // 
            // tbControllerTemp
            // 
            this.tbControllerTemp.Location = new System.Drawing.Point(104, 16);
            this.tbControllerTemp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbControllerTemp.Name = "tbControllerTemp";
            this.tbControllerTemp.Size = new System.Drawing.Size(70, 20);
            this.tbControllerTemp.TabIndex = 100;
            this.tbControllerTemp.Leave += new System.EventHandler(this.TbControllerTemp_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbBatteryCurrent);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbBatteryVoltage);
            this.groupBox4.Location = new System.Drawing.Point(184, 7);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(176, 78);
            this.groupBox4.TabIndex = 107;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "MC_BUS (0x402)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "Battery Current";
            // 
            // tbBatteryCurrent
            // 
            this.tbBatteryCurrent.Location = new System.Drawing.Point(104, 38);
            this.tbBatteryCurrent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbBatteryCurrent.Name = "tbBatteryCurrent";
            this.tbBatteryCurrent.Size = new System.Drawing.Size(70, 20);
            this.tbBatteryCurrent.TabIndex = 102;
            this.tbBatteryCurrent.Leave += new System.EventHandler(this.TbBatteryCurrent_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 101;
            this.label5.Text = "Battery Voltage";
            // 
            // tbBatteryVoltage
            // 
            this.tbBatteryVoltage.Location = new System.Drawing.Point(104, 16);
            this.tbBatteryVoltage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbBatteryVoltage.Name = "tbBatteryVoltage";
            this.tbBatteryVoltage.Size = new System.Drawing.Size(70, 20);
            this.tbBatteryVoltage.TabIndex = 100;
            this.tbBatteryVoltage.Leave += new System.EventHandler(this.TbBatteryVoltage_Leave);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.tbNeutral);
            this.groupBox5.Location = new System.Drawing.Point(5, 7);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(176, 38);
            this.groupBox5.TabIndex = 108;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "MC_LIMITS (0x401)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 101;
            this.label6.Text = "Neutral";
            // 
            // tbNeutral
            // 
            this.tbNeutral.Location = new System.Drawing.Point(104, 16);
            this.tbNeutral.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNeutral.Name = "tbNeutral";
            this.tbNeutral.Size = new System.Drawing.Size(70, 20);
            this.tbNeutral.TabIndex = 100;
            this.tbNeutral.Leave += new System.EventHandler(this.TbNeutral_Leave);
            // 
            // MotorControllerSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 210);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStartStopSim);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MotorControllerSimulatorForm";
            this.Text = "Motor Controller Simulator";
            this.Load += new System.EventHandler(this.MotorControllerSimulatorForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartStopSim;
        private System.Windows.Forms.TextBox tbMotorVelocity;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRegen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMotorTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbControllerTemp;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbBatteryCurrent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBatteryVoltage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNeutral;
    }
}