namespace ArrowPointCANBusTool.Forms
{
    partial class BatteryControllerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryControllerForm));
            this.ContactorsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ContactorsButton
            // 
            this.ContactorsButton.Location = new System.Drawing.Point(12, 12);
            this.ContactorsButton.Name = "ContactorsButton";
            this.ContactorsButton.Size = new System.Drawing.Size(254, 156);
            this.ContactorsButton.TabIndex = 0;
            this.ContactorsButton.Text = "Engage Contactors";
            this.ContactorsButton.UseVisualStyleBackColor = true;
            this.ContactorsButton.Click += new System.EventHandler(this.ContactorsButton_ClickAsync);
            // 
            // BatteryControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 179);
            this.Controls.Add(this.ContactorsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatteryControllerForm";
            this.Text = "Battery Controller";
            this.Load += new System.EventHandler(this.BatteryControllerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ContactorsButton;
    }
}