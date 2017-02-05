namespace ArrowWareDiagnosticTool.Forms
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
            this.lblCruiseMode = new System.Windows.Forms.Label();
            this.tbCruiseMode = new System.Windows.Forms.TextBox();
            this.pbBusCurrentPercentage = new System.Windows.Forms.ProgressBar();
            this.pbCurrentPercentage = new System.Windows.Forms.ProgressBar();
            this.pbRpmPecentage = new System.Windows.Forms.ProgressBar();
            this.lblBusCurrentPercentage = new System.Windows.Forms.Label();
            this.lblCurrentPercentage = new System.Windows.Forms.Label();
            this.lblRpmPercentage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDriveMode = new System.Windows.Forms.TextBox();
            this.gbDC.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRpmPercentage
            // 
            this.tbRpmPercentage.Enabled = false;
            this.tbRpmPercentage.Location = new System.Drawing.Point(167, 32);
            this.tbRpmPercentage.Name = "tbRpmPercentage";
            this.tbRpmPercentage.Size = new System.Drawing.Size(100, 29);
            this.tbRpmPercentage.TabIndex = 0;
            // 
            // tbCurrentPercentage
            // 
            this.tbCurrentPercentage.Enabled = false;
            this.tbCurrentPercentage.Location = new System.Drawing.Point(167, 65);
            this.tbCurrentPercentage.Name = "tbCurrentPercentage";
            this.tbCurrentPercentage.Size = new System.Drawing.Size(100, 29);
            this.tbCurrentPercentage.TabIndex = 1;
            // 
            // tbBusCurrentPercentage
            // 
            this.tbBusCurrentPercentage.Enabled = false;
            this.tbBusCurrentPercentage.Location = new System.Drawing.Point(167, 100);
            this.tbBusCurrentPercentage.Name = "tbBusCurrentPercentage";
            this.tbBusCurrentPercentage.Size = new System.Drawing.Size(100, 29);
            this.tbBusCurrentPercentage.TabIndex = 2;
            // 
            // gbDC
            // 
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
            this.gbDC.Location = new System.Drawing.Point(13, 13);
            this.gbDC.Name = "gbDC";
            this.gbDC.Size = new System.Drawing.Size(1300, 175);
            this.gbDC.TabIndex = 3;
            this.gbDC.TabStop = false;
            this.gbDC.Text = "Sabre Board";
            // 
            // lblCruiseMode
            // 
            this.lblCruiseMode.AutoSize = true;
            this.lblCruiseMode.Location = new System.Drawing.Point(379, 68);
            this.lblCruiseMode.Name = "lblCruiseMode";
            this.lblCruiseMode.Size = new System.Drawing.Size(124, 25);
            this.lblCruiseMode.TabIndex = 10;
            this.lblCruiseMode.Text = "Cruise Mode";
            this.lblCruiseMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCruiseMode
            // 
            this.tbCruiseMode.Enabled = false;
            this.tbCruiseMode.Location = new System.Drawing.Point(509, 66);
            this.tbCruiseMode.Name = "tbCruiseMode";
            this.tbCruiseMode.Size = new System.Drawing.Size(100, 29);
            this.tbCruiseMode.TabIndex = 9;
            // 
            // pbBusCurrentPercentage
            // 
            this.pbBusCurrentPercentage.Location = new System.Drawing.Point(273, 103);
            this.pbBusCurrentPercentage.Name = "pbBusCurrentPercentage";
            this.pbBusCurrentPercentage.Size = new System.Drawing.Size(100, 23);
            this.pbBusCurrentPercentage.TabIndex = 8;
            // 
            // pbCurrentPercentage
            // 
            this.pbCurrentPercentage.Location = new System.Drawing.Point(273, 68);
            this.pbCurrentPercentage.Name = "pbCurrentPercentage";
            this.pbCurrentPercentage.Size = new System.Drawing.Size(100, 23);
            this.pbCurrentPercentage.TabIndex = 7;
            // 
            // pbRpmPecentage
            // 
            this.pbRpmPecentage.Location = new System.Drawing.Point(273, 35);
            this.pbRpmPecentage.Name = "pbRpmPecentage";
            this.pbRpmPecentage.Size = new System.Drawing.Size(100, 23);
            this.pbRpmPecentage.TabIndex = 6;
            // 
            // lblBusCurrentPercentage
            // 
            this.lblBusCurrentPercentage.AutoSize = true;
            this.lblBusCurrentPercentage.Location = new System.Drawing.Point(8, 102);
            this.lblBusCurrentPercentage.Name = "lblBusCurrentPercentage";
            this.lblBusCurrentPercentage.Size = new System.Drawing.Size(153, 25);
            this.lblBusCurrentPercentage.TabIndex = 5;
            this.lblBusCurrentPercentage.Text = "Bus Current (%)";
            this.lblBusCurrentPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPercentage
            // 
            this.lblCurrentPercentage.AutoSize = true;
            this.lblCurrentPercentage.Location = new System.Drawing.Point(47, 67);
            this.lblCurrentPercentage.Name = "lblCurrentPercentage";
            this.lblCurrentPercentage.Size = new System.Drawing.Size(114, 25);
            this.lblCurrentPercentage.TabIndex = 4;
            this.lblCurrentPercentage.Text = "Current (%)";
            this.lblCurrentPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRpmPercentage
            // 
            this.lblRpmPercentage.AutoSize = true;
            this.lblRpmPercentage.Location = new System.Drawing.Point(72, 34);
            this.lblRpmPercentage.Name = "lblRpmPercentage";
            this.lblRpmPercentage.Size = new System.Drawing.Size(89, 25);
            this.lblRpmPercentage.TabIndex = 3;
            this.lblRpmPercentage.Text = "Rpm (%)";
            this.lblRpmPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Drive Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDriveMode
            // 
            this.tbDriveMode.Enabled = false;
            this.tbDriveMode.Location = new System.Drawing.Point(509, 32);
            this.tbDriveMode.Name = "tbDriveMode";
            this.tbDriveMode.Size = new System.Drawing.Size(100, 29);
            this.tbDriveMode.TabIndex = 11;
            // 
            // CanbusDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 200);
            this.Controls.Add(this.gbDC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CanbusDashboardForm";
            this.Text = "Canbus Dashboard";
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
    }
}