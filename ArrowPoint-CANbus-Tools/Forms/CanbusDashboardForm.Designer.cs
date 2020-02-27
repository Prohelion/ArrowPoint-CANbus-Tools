namespace ArrowPointCANBusTool.Forms
{
    partial class CanbusDashboardForm
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
                timer.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanbusDashboardForm));
            this.tbRpmPercentage = new System.Windows.Forms.TextBox();
            this.tbCurrentPercentage = new System.Windows.Forms.TextBox();
            this.tbBusCurrentPercentage = new System.Windows.Forms.TextBox();
            this.gbDC = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFlashMode = new System.Windows.Forms.TextBox();
            this.pbRegenPercentage = new System.Windows.Forms.ProgressBar();
            this.pbThrottlePercentage = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbThrottlePercentage = new System.Windows.Forms.TextBox();
            this.tbRegenPercentage = new System.Windows.Forms.TextBox();
            this.lblErrorMode = new System.Windows.Forms.Label();
            this.tbErrorMode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDriveMode = new System.Windows.Forms.TextBox();
            this.lblCruiseMode = new System.Windows.Forms.Label();
            this.tbCruiseMode = new System.Windows.Forms.TextBox();
            this.pbBusCurrentPercentage = new System.Windows.Forms.ProgressBar();
            this.pbCurrentPercentage = new System.Windows.Forms.ProgressBar();
            this.pbRpmPecentage = new System.Windows.Forms.ProgressBar();
            this.lblBusCurrentPercentage = new System.Windows.Forms.Label();
            this.lblCurrentPercentage = new System.Windows.Forms.Label();
            this.lblRpmPercentage = new System.Windows.Forms.Label();
            this.gbDC.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRpmPercentage
            // 
            this.tbRpmPercentage.Enabled = false;
            this.tbRpmPercentage.Location = new System.Drawing.Point(220, 52);
            this.tbRpmPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.tbRpmPercentage.Name = "tbRpmPercentage";
            this.tbRpmPercentage.Size = new System.Drawing.Size(56, 20);
            this.tbRpmPercentage.TabIndex = 0;
            // 
            // tbCurrentPercentage
            // 
            this.tbCurrentPercentage.Enabled = false;
            this.tbCurrentPercentage.Location = new System.Drawing.Point(220, 70);
            this.tbCurrentPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurrentPercentage.Name = "tbCurrentPercentage";
            this.tbCurrentPercentage.Size = new System.Drawing.Size(56, 20);
            this.tbCurrentPercentage.TabIndex = 1;
            // 
            // tbBusCurrentPercentage
            // 
            this.tbBusCurrentPercentage.Enabled = false;
            this.tbBusCurrentPercentage.Location = new System.Drawing.Point(220, 89);
            this.tbBusCurrentPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.tbBusCurrentPercentage.Name = "tbBusCurrentPercentage";
            this.tbBusCurrentPercentage.Size = new System.Drawing.Size(56, 20);
            this.tbBusCurrentPercentage.TabIndex = 2;
            // 
            // gbDC
            // 
            this.gbDC.Controls.Add(this.label4);
            this.gbDC.Controls.Add(this.tbFlashMode);
            this.gbDC.Controls.Add(this.pbRegenPercentage);
            this.gbDC.Controls.Add(this.pbThrottlePercentage);
            this.gbDC.Controls.Add(this.label2);
            this.gbDC.Controls.Add(this.label3);
            this.gbDC.Controls.Add(this.tbThrottlePercentage);
            this.gbDC.Controls.Add(this.tbRegenPercentage);
            this.gbDC.Controls.Add(this.lblErrorMode);
            this.gbDC.Controls.Add(this.tbErrorMode);
            this.gbDC.Controls.Add(this.label1);
            this.gbDC.Controls.Add(this.tbDriveMode);
            this.gbDC.Controls.Add(this.lblCruiseMode);
            this.gbDC.Controls.Add(this.tbCruiseMode);
            this.gbDC.Controls.Add(this.pbBusCurrentPercentage);
            this.gbDC.Controls.Add(this.pbCurrentPercentage);
            this.gbDC.Controls.Add(this.pbRpmPecentage);
            this.gbDC.Controls.Add(this.lblBusCurrentPercentage);
            this.gbDC.Controls.Add(this.lblCurrentPercentage);
            this.gbDC.Controls.Add(this.lblRpmPercentage);
            this.gbDC.Controls.Add(this.tbRpmPercentage);
            this.gbDC.Controls.Add(this.tbBusCurrentPercentage);
            this.gbDC.Controls.Add(this.tbCurrentPercentage);
            this.gbDC.Location = new System.Drawing.Point(7, 7);
            this.gbDC.Margin = new System.Windows.Forms.Padding(2);
            this.gbDC.Name = "gbDC";
            this.gbDC.Padding = new System.Windows.Forms.Padding(2);
            this.gbDC.Size = new System.Drawing.Size(339, 111);
            this.gbDC.TabIndex = 3;
            this.gbDC.TabStop = false;
            this.gbDC.Text = "Sabre Board";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Flash Mode";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFlashMode
            // 
            this.tbFlashMode.Enabled = false;
            this.tbFlashMode.Location = new System.Drawing.Point(74, 70);
            this.tbFlashMode.Margin = new System.Windows.Forms.Padding(2);
            this.tbFlashMode.Name = "tbFlashMode";
            this.tbFlashMode.Size = new System.Drawing.Size(56, 20);
            this.tbFlashMode.TabIndex = 21;
            // 
            // pbRegenPercentage
            // 
            this.pbRegenPercentage.Location = new System.Drawing.Point(278, 36);
            this.pbRegenPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.pbRegenPercentage.Name = "pbRegenPercentage";
            this.pbRegenPercentage.Size = new System.Drawing.Size(55, 12);
            this.pbRegenPercentage.TabIndex = 20;
            // 
            // pbThrottlePercentage
            // 
            this.pbThrottlePercentage.Location = new System.Drawing.Point(278, 18);
            this.pbThrottlePercentage.Margin = new System.Windows.Forms.Padding(2);
            this.pbThrottlePercentage.Name = "pbThrottlePercentage";
            this.pbThrottlePercentage.Size = new System.Drawing.Size(55, 12);
            this.pbThrottlePercentage.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Regen (%)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Throttle (%)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbThrottlePercentage
            // 
            this.tbThrottlePercentage.Enabled = false;
            this.tbThrottlePercentage.Location = new System.Drawing.Point(220, 16);
            this.tbThrottlePercentage.Margin = new System.Windows.Forms.Padding(2);
            this.tbThrottlePercentage.Name = "tbThrottlePercentage";
            this.tbThrottlePercentage.Size = new System.Drawing.Size(56, 20);
            this.tbThrottlePercentage.TabIndex = 15;
            // 
            // tbRegenPercentage
            // 
            this.tbRegenPercentage.Enabled = false;
            this.tbRegenPercentage.Location = new System.Drawing.Point(220, 34);
            this.tbRegenPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.tbRegenPercentage.Name = "tbRegenPercentage";
            this.tbRegenPercentage.Size = new System.Drawing.Size(56, 20);
            this.tbRegenPercentage.TabIndex = 16;
            // 
            // lblErrorMode
            // 
            this.lblErrorMode.AutoSize = true;
            this.lblErrorMode.Location = new System.Drawing.Point(3, 16);
            this.lblErrorMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorMode.Name = "lblErrorMode";
            this.lblErrorMode.Size = new System.Drawing.Size(59, 13);
            this.lblErrorMode.TabIndex = 14;
            this.lblErrorMode.Text = "Error Mode";
            this.lblErrorMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbErrorMode
            // 
            this.tbErrorMode.Enabled = false;
            this.tbErrorMode.Location = new System.Drawing.Point(74, 15);
            this.tbErrorMode.Margin = new System.Windows.Forms.Padding(2);
            this.tbErrorMode.Name = "tbErrorMode";
            this.tbErrorMode.Size = new System.Drawing.Size(56, 20);
            this.tbErrorMode.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Drive Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDriveMode
            // 
            this.tbDriveMode.Enabled = false;
            this.tbDriveMode.Location = new System.Drawing.Point(74, 34);
            this.tbDriveMode.Margin = new System.Windows.Forms.Padding(2);
            this.tbDriveMode.Name = "tbDriveMode";
            this.tbDriveMode.Size = new System.Drawing.Size(56, 20);
            this.tbDriveMode.TabIndex = 11;
            // 
            // lblCruiseMode
            // 
            this.lblCruiseMode.AutoSize = true;
            this.lblCruiseMode.Location = new System.Drawing.Point(3, 54);
            this.lblCruiseMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCruiseMode.Name = "lblCruiseMode";
            this.lblCruiseMode.Size = new System.Drawing.Size(66, 13);
            this.lblCruiseMode.TabIndex = 10;
            this.lblCruiseMode.Text = "Cruise Mode";
            this.lblCruiseMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCruiseMode
            // 
            this.tbCruiseMode.Enabled = false;
            this.tbCruiseMode.Location = new System.Drawing.Point(74, 52);
            this.tbCruiseMode.Margin = new System.Windows.Forms.Padding(2);
            this.tbCruiseMode.Name = "tbCruiseMode";
            this.tbCruiseMode.Size = new System.Drawing.Size(56, 20);
            this.tbCruiseMode.TabIndex = 9;
            // 
            // pbBusCurrentPercentage
            // 
            this.pbBusCurrentPercentage.Location = new System.Drawing.Point(278, 90);
            this.pbBusCurrentPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.pbBusCurrentPercentage.Name = "pbBusCurrentPercentage";
            this.pbBusCurrentPercentage.Size = new System.Drawing.Size(55, 12);
            this.pbBusCurrentPercentage.TabIndex = 8;
            // 
            // pbCurrentPercentage
            // 
            this.pbCurrentPercentage.Location = new System.Drawing.Point(278, 72);
            this.pbCurrentPercentage.Margin = new System.Windows.Forms.Padding(2);
            this.pbCurrentPercentage.Name = "pbCurrentPercentage";
            this.pbCurrentPercentage.Size = new System.Drawing.Size(55, 12);
            this.pbCurrentPercentage.TabIndex = 7;
            // 
            // pbRpmPecentage
            // 
            this.pbRpmPecentage.Location = new System.Drawing.Point(278, 54);
            this.pbRpmPecentage.Margin = new System.Windows.Forms.Padding(2);
            this.pbRpmPecentage.Name = "pbRpmPecentage";
            this.pbRpmPecentage.Size = new System.Drawing.Size(55, 12);
            this.pbRpmPecentage.TabIndex = 6;
            // 
            // lblBusCurrentPercentage
            // 
            this.lblBusCurrentPercentage.AutoSize = true;
            this.lblBusCurrentPercentage.Location = new System.Drawing.Point(133, 90);
            this.lblBusCurrentPercentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBusCurrentPercentage.Name = "lblBusCurrentPercentage";
            this.lblBusCurrentPercentage.Size = new System.Drawing.Size(79, 13);
            this.lblBusCurrentPercentage.TabIndex = 5;
            this.lblBusCurrentPercentage.Text = "Bus Current (%)";
            this.lblBusCurrentPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPercentage
            // 
            this.lblCurrentPercentage.AutoSize = true;
            this.lblCurrentPercentage.Location = new System.Drawing.Point(154, 71);
            this.lblCurrentPercentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentPercentage.Name = "lblCurrentPercentage";
            this.lblCurrentPercentage.Size = new System.Drawing.Size(58, 13);
            this.lblCurrentPercentage.TabIndex = 4;
            this.lblCurrentPercentage.Text = "Current (%)";
            this.lblCurrentPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRpmPercentage
            // 
            this.lblRpmPercentage.AutoSize = true;
            this.lblRpmPercentage.Location = new System.Drawing.Point(168, 53);
            this.lblRpmPercentage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRpmPercentage.Name = "lblRpmPercentage";
            this.lblRpmPercentage.Size = new System.Drawing.Size(46, 13);
            this.lblRpmPercentage.TabIndex = 3;
            this.lblRpmPercentage.Text = "Rpm (%)";
            this.lblRpmPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CanbusDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 122);
            this.Controls.Add(this.gbDC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CanbusDashboardForm";
            this.Text = "Canbus Dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CanbusDashboardForm_FormClosing);
            this.Load += new System.EventHandler(this.CanbusDashboardForm_Load);
            this.gbDC.ResumeLayout(false);
            this.gbDC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbRpmPercentage;
        private System.Windows.Forms.TextBox tbCurrentPercentage;
        private System.Windows.Forms.TextBox tbBusCurrentPercentage;
        private System.Windows.Forms.GroupBox gbDC;
        private System.Windows.Forms.ProgressBar pbBusCurrentPercentage;
        private System.Windows.Forms.ProgressBar pbCurrentPercentage;
        private System.Windows.Forms.ProgressBar pbRpmPecentage;
        private System.Windows.Forms.Label lblBusCurrentPercentage;
        private System.Windows.Forms.Label lblCurrentPercentage;
        private System.Windows.Forms.Label lblRpmPercentage;
        private System.Windows.Forms.Label lblCruiseMode;
        private System.Windows.Forms.TextBox tbCruiseMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDriveMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFlashMode;
        private System.Windows.Forms.ProgressBar pbRegenPercentage;
        private System.Windows.Forms.ProgressBar pbThrottlePercentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbThrottlePercentage;
        private System.Windows.Forms.TextBox tbRegenPercentage;
        private System.Windows.Forms.Label lblErrorMode;
        private System.Windows.Forms.TextBox tbErrorMode;
    }
}