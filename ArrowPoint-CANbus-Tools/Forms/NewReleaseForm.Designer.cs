namespace ArrowPointCANBusTool.Forms
{
    partial class NewReleaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewReleaseForm));
            this.Btn_Close = new System.Windows.Forms.Button();
            this.Btn_GetRelease = new System.Windows.Forms.Button();
            this.TxtDetails = new System.Windows.Forms.Label();
            this.TxtReleaseNumber = new System.Windows.Forms.Label();
            this.LblIntroduction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Close
            // 
            this.Btn_Close.Location = new System.Drawing.Point(388, 213);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(123, 39);
            this.Btn_Close.TabIndex = 0;
            this.Btn_Close.Text = "&Close";
            this.Btn_Close.UseVisualStyleBackColor = true;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Btn_GetRelease
            // 
            this.Btn_GetRelease.Location = new System.Drawing.Point(202, 213);
            this.Btn_GetRelease.Name = "Btn_GetRelease";
            this.Btn_GetRelease.Size = new System.Drawing.Size(164, 38);
            this.Btn_GetRelease.TabIndex = 1;
            this.Btn_GetRelease.Text = "&Get the new release";
            this.Btn_GetRelease.UseVisualStyleBackColor = true;
            this.Btn_GetRelease.Click += new System.EventHandler(this.Btn_GetRelease_Click);
            // 
            // TxtDetails
            // 
            this.TxtDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtDetails.Location = new System.Drawing.Point(12, 77);
            this.TxtDetails.Name = "TxtDetails";
            this.TxtDetails.Size = new System.Drawing.Size(499, 122);
            this.TxtDetails.TabIndex = 3;
            this.TxtDetails.Text = "Details";
            // 
            // TxtReleaseNumber
            // 
            this.TxtReleaseNumber.AutoSize = true;
            this.TxtReleaseNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtReleaseNumber.Location = new System.Drawing.Point(12, 46);
            this.TxtReleaseNumber.Name = "TxtReleaseNumber";
            this.TxtReleaseNumber.Size = new System.Drawing.Size(128, 20);
            this.TxtReleaseNumber.TabIndex = 4;
            this.TxtReleaseNumber.Text = "Release Number";
            // 
            // LblIntroduction
            // 
            this.LblIntroduction.AutoSize = true;
            this.LblIntroduction.Location = new System.Drawing.Point(12, 18);
            this.LblIntroduction.Name = "LblIntroduction";
            this.LblIntroduction.Size = new System.Drawing.Size(159, 13);
            this.LblIntroduction.TabIndex = 5;
            this.LblIntroduction.Text = "There is a new release available";
            // 
            // NewReleaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 264);
            this.Controls.Add(this.LblIntroduction);
            this.Controls.Add(this.TxtReleaseNumber);
            this.Controls.Add(this.TxtDetails);
            this.Controls.Add(this.Btn_GetRelease);
            this.Controls.Add(this.Btn_Close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewReleaseForm";
            this.Text = "New Release Available";
            this.Load += new System.EventHandler(this.NewReleaseForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Close;
        private System.Windows.Forms.Button Btn_GetRelease;
        private System.Windows.Forms.Label TxtDetails;
        private System.Windows.Forms.Label TxtReleaseNumber;
        private System.Windows.Forms.Label LblIntroduction;
    }
}