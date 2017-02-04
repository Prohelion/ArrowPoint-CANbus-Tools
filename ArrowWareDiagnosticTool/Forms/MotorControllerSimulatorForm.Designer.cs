namespace ArrowWareDiagnosticTool.Forms
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
            this.btnSendVelocity = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendVelocity
            // 
            this.btnSendVelocity.Location = new System.Drawing.Point(59, 47);
            this.btnSendVelocity.Name = "btnSendVelocity";
            this.btnSendVelocity.Size = new System.Drawing.Size(427, 129);
            this.btnSendVelocity.TabIndex = 0;
            this.btnSendVelocity.Text = "btnSendVelocity";
            this.btnSendVelocity.UseVisualStyleBackColor = true;
            this.btnSendVelocity.Click += new System.EventHandler(this.btnSendVelocity_Click);
            // 
            // MotorControllerSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 335);
            this.Controls.Add(this.btnSendVelocity);
            this.Name = "MotorControllerSimulatorForm";
            this.Text = "MotorControllerSimulatorForm";
            this.Load += new System.EventHandler(this.MotorControllerSimulatorForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendVelocity;
    }
}