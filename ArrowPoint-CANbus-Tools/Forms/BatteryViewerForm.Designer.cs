namespace ArrowPointCANBusTool.Forms
{
    partial class BatteryViewerForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatteryViewerForm));
            this.bmuTelemetry = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.bmuDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmuTelemetry = new System.Windows.Forms.GroupBox();
            this.CMUdataGridView = new System.Windows.Forms.DataGridView();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PCBTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellTemperature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellVoltage0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell1Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell2Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell3Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell4Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell5Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell6Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cell7Voltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmuDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bmuTelemetry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmuDataBindingSource)).BeginInit();
            this.cmuTelemetry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMUdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmuDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bmuTelemetry
            // 
            this.bmuTelemetry.Controls.Add(this.dataGridView2);
            this.bmuTelemetry.Location = new System.Drawing.Point(12, 10);
            this.bmuTelemetry.Name = "bmuTelemetry";
            this.bmuTelemetry.Size = new System.Drawing.Size(1058, 181);
            this.bmuTelemetry.TabIndex = 0;
            this.bmuTelemetry.TabStop = false;
            this.bmuTelemetry.Text = "BMU Telemetry";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.DataSource = this.bmuDataBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1052, 162);
            this.dataGridView2.TabIndex = 3;
            // 
            // cmuTelemetry
            // 
            this.cmuTelemetry.Controls.Add(this.CMUdataGridView);
            this.cmuTelemetry.Location = new System.Drawing.Point(12, 197);
            this.cmuTelemetry.Name = "cmuTelemetry";
            this.cmuTelemetry.Size = new System.Drawing.Size(1058, 317);
            this.cmuTelemetry.TabIndex = 1;
            this.cmuTelemetry.TabStop = false;
            this.cmuTelemetry.Text = "CMU Telemetry";
            // 
            // CMUdataGridView
            // 
            this.CMUdataGridView.AllowUserToAddRows = false;
            this.CMUdataGridView.AllowUserToDeleteRows = false;
            this.CMUdataGridView.AutoGenerateColumns = false;
            this.CMUdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CMUdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CMUdataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.CMUdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CMUdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serial,
            this.PCBTemperature,
            this.CellTemperature,
            this.CellVoltage0,
            this.Cell1Voltage,
            this.Cell2Voltage,
            this.Cell3Voltage,
            this.Cell4Voltage,
            this.Cell5Voltage,
            this.Cell6Voltage,
            this.Cell7Voltage});
            this.CMUdataGridView.DataSource = this.cmuDataBindingSource;
            this.CMUdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CMUdataGridView.Location = new System.Drawing.Point(3, 16);
            this.CMUdataGridView.Name = "CMUdataGridView";
            this.CMUdataGridView.ReadOnly = true;
            this.CMUdataGridView.Size = new System.Drawing.Size(1052, 298);
            this.CMUdataGridView.TabIndex = 3;
            this.CMUdataGridView.RowHeadersWidth = 100;            
            this.CMUdataGridView.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.CMUdataGridView_RowValidated);
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "SerialNumber";
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            // 
            // PCBTemperature
            // 
            this.PCBTemperature.DataPropertyName = "PCBTemp";
            this.PCBTemperature.HeaderText = "PCB (C)";
            this.PCBTemperature.Name = "PCBTemperature";
            this.PCBTemperature.ReadOnly = true;
            // 
            // CellTemperature
            // 
            this.CellTemperature.DataPropertyName = "CellTemp";
            this.CellTemperature.HeaderText = "Cell (C)";
            this.CellTemperature.Name = "CellTemperature";
            this.CellTemperature.ReadOnly = true;
            // 
            // CellVoltage0
            // 
            this.CellVoltage0.DataPropertyName = "Cell0mV";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.CellVoltage0.DefaultCellStyle = dataGridViewCellStyle2;
            this.CellVoltage0.HeaderText = "Cell 0 mV";
            this.CellVoltage0.Name = "CellVoltage0";
            this.CellVoltage0.ReadOnly = true;
            // 
            // Cell1Voltage
            // 
            this.Cell1Voltage.DataPropertyName = "Cell1mV";
            this.Cell1Voltage.HeaderText = "Cell 1 mV";
            this.Cell1Voltage.Name = "Cell1Voltage";
            this.Cell1Voltage.ReadOnly = true;
            // 
            // Cell2Voltage
            // 
            this.Cell2Voltage.DataPropertyName = "Cell2mV";
            this.Cell2Voltage.HeaderText = "Cell 2 mV";
            this.Cell2Voltage.Name = "Cell2Voltage";
            this.Cell2Voltage.ReadOnly = true;
            // 
            // Cell3Voltage
            // 
            this.Cell3Voltage.DataPropertyName = "Cell3mV";
            this.Cell3Voltage.HeaderText = "Cell 3 mV";
            this.Cell3Voltage.Name = "Cell3Voltage";
            this.Cell3Voltage.ReadOnly = true;
            // 
            // Cell4Voltage
            // 
            this.Cell4Voltage.DataPropertyName = "Cell4mV";
            this.Cell4Voltage.HeaderText = "Cell 4 mV";
            this.Cell4Voltage.Name = "Cell4Voltage";
            this.Cell4Voltage.ReadOnly = true;
            // 
            // Cell5Voltage
            // 
            this.Cell5Voltage.DataPropertyName = "Cell5mV";
            this.Cell5Voltage.HeaderText = "Cell 5 mV";
            this.Cell5Voltage.Name = "Cell5Voltage";
            this.Cell5Voltage.ReadOnly = true;
            // 
            // Cell6Voltage
            // 
            this.Cell6Voltage.DataPropertyName = "Cell6mV";
            this.Cell6Voltage.HeaderText = "Cell 6 mV";
            this.Cell6Voltage.Name = "Cell6Voltage";
            this.Cell6Voltage.ReadOnly = true;
            // 
            // Cell7Voltage
            // 
            this.Cell7Voltage.DataPropertyName = "Cell7mV";
            this.Cell7Voltage.HeaderText = "Cell 7 mV";
            this.Cell7Voltage.Name = "Cell7Voltage";
            this.Cell7Voltage.ReadOnly = true;
            // 
            // BatteryViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 526);
            this.Controls.Add(this.cmuTelemetry);
            this.Controls.Add(this.bmuTelemetry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatteryViewerForm";
            this.Text = "Battery Viewer";
            this.bmuTelemetry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bmuDataBindingSource)).EndInit();
            this.cmuTelemetry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CMUdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmuDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox bmuTelemetry;
        private System.Windows.Forms.GroupBox cmuTelemetry;
        private System.Windows.Forms.DataGridView CMUdataGridView;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource bmuDataBindingSource;
        private System.Windows.Forms.BindingSource cmuDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn PCBTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellTemperature;
        private System.Windows.Forms.DataGridViewTextBoxColumn CellVoltage0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell1Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell2Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell3Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell4Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell5Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell6Voltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cell7Voltage;
    }
}