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
            this.BMUdataGridView = new System.Windows.Forms.DataGridView();
            this.MinmV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Min_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_mV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pack_mA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePositive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceNegative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMU_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.BMUdataGridView)).BeginInit();
            this.cmuTelemetry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CMUdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmuDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bmuTelemetry
            // 
            this.bmuTelemetry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bmuTelemetry.AutoSize = true;
            this.bmuTelemetry.Controls.Add(this.BMUdataGridView);
            this.bmuTelemetry.Location = new System.Drawing.Point(12, 10);
            this.bmuTelemetry.Name = "bmuTelemetry";
            this.bmuTelemetry.Size = new System.Drawing.Size(1118, 184);
            this.bmuTelemetry.TabIndex = 0;
            this.bmuTelemetry.TabStop = false;
            this.bmuTelemetry.Text = "BMU Telemetry";
            // 
            // BMUdataGridView
            // 
            this.BMUdataGridView.AllowUserToAddRows = false;
            this.BMUdataGridView.AllowUserToDeleteRows = false;
            this.BMUdataGridView.AllowUserToResizeColumns = false;
            this.BMUdataGridView.AllowUserToResizeRows = false;
            this.BMUdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BMUdataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.BMUdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BMUdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MinmV,
            this.Max_mV,
            this.Min_C,
            this.Max_C,
            this.Pack_mV,
            this.Pack_mA,
            this.BalancePositive,
            this.BalanceNegative,
            this.CMU_Count});
            this.BMUdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BMUdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.BMUdataGridView.EnableHeadersVisualStyles = false;
            this.BMUdataGridView.Location = new System.Drawing.Point(3, 16);
            this.BMUdataGridView.MultiSelect = false;
            this.BMUdataGridView.Name = "BMUdataGridView";
            this.BMUdataGridView.ReadOnly = true;
            this.BMUdataGridView.RowHeadersWidth = 100;
            this.BMUdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.BMUdataGridView.Size = new System.Drawing.Size(1112, 165);
            this.BMUdataGridView.TabIndex = 3;
            // 
            // MinmV
            // 
            this.MinmV.HeaderText = "Min mV";
            this.MinmV.Name = "MinmV";
            this.MinmV.ReadOnly = true;
            this.MinmV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Max_mV
            // 
            this.Max_mV.HeaderText = "Max mV";
            this.Max_mV.Name = "Max_mV";
            this.Max_mV.ReadOnly = true;
            this.Max_mV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Min_C
            // 
            this.Min_C.HeaderText = "Min C";
            this.Min_C.Name = "Min_C";
            this.Min_C.ReadOnly = true;
            this.Min_C.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Max_C
            // 
            this.Max_C.HeaderText = "Max C";
            this.Max_C.Name = "Max_C";
            this.Max_C.ReadOnly = true;
            this.Max_C.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Pack_mV
            // 
            this.Pack_mV.HeaderText = "Pack mV";
            this.Pack_mV.Name = "Pack_mV";
            this.Pack_mV.ReadOnly = true;
            this.Pack_mV.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Pack_mA
            // 
            this.Pack_mA.HeaderText = "Pack mA";
            this.Pack_mA.Name = "Pack_mA";
            this.Pack_mA.ReadOnly = true;
            this.Pack_mA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BalancePositive
            // 
            this.BalancePositive.HeaderText = "Balance +";
            this.BalancePositive.Name = "BalancePositive";
            this.BalancePositive.ReadOnly = true;
            this.BalancePositive.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BalanceNegative
            // 
            this.BalanceNegative.HeaderText = "Balance -";
            this.BalanceNegative.Name = "BalanceNegative";
            this.BalanceNegative.ReadOnly = true;
            this.BalanceNegative.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CMU_Count
            // 
            this.CMU_Count.HeaderText = "CMU Count";
            this.CMU_Count.Name = "CMU_Count";
            this.CMU_Count.ReadOnly = true;
            this.CMU_Count.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cmuTelemetry
            // 
            this.cmuTelemetry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmuTelemetry.AutoSize = true;
            this.cmuTelemetry.Controls.Add(this.CMUdataGridView);
            this.cmuTelemetry.Location = new System.Drawing.Point(12, 197);
            this.cmuTelemetry.Name = "cmuTelemetry";
            this.cmuTelemetry.Size = new System.Drawing.Size(1118, 266);
            this.cmuTelemetry.TabIndex = 1;
            this.cmuTelemetry.TabStop = false;
            this.cmuTelemetry.Text = "CMU Telemetry";
            // 
            // CMUdataGridView
            // 
            this.CMUdataGridView.AllowUserToAddRows = false;
            this.CMUdataGridView.AllowUserToDeleteRows = false;
            this.CMUdataGridView.AllowUserToResizeColumns = false;
            this.CMUdataGridView.AllowUserToResizeRows = false;
            this.CMUdataGridView.AutoGenerateColumns = false;
            this.CMUdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CMUdataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CMUdataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
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
            this.CMUdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.CMUdataGridView.EnableHeadersVisualStyles = false;
            this.CMUdataGridView.Location = new System.Drawing.Point(3, 16);
            this.CMUdataGridView.MultiSelect = false;
            this.CMUdataGridView.Name = "CMUdataGridView";
            this.CMUdataGridView.ReadOnly = true;
            this.CMUdataGridView.RowHeadersWidth = 100;
            this.CMUdataGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;
            this.CMUdataGridView.RowTemplate.ReadOnly = true;
            this.CMUdataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CMUdataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CMUdataGridView.Size = new System.Drawing.Size(1112, 247);
            this.CMUdataGridView.TabIndex = 3;
            this.CMUdataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CMUdataGridView_DataBindingComplete);
            // 
            // Serial
            // 
            this.Serial.DataPropertyName = "SerialNumber";
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            this.Serial.ReadOnly = true;
            this.Serial.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PCBTemperature
            // 
            this.PCBTemperature.DataPropertyName = "PCBTemp";
            this.PCBTemperature.HeaderText = "PCB (C)";
            this.PCBTemperature.Name = "PCBTemperature";
            this.PCBTemperature.ReadOnly = true;
            this.PCBTemperature.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CellTemperature
            // 
            this.CellTemperature.DataPropertyName = "CellTemp";
            this.CellTemperature.HeaderText = "Cell (C)";
            this.CellTemperature.Name = "CellTemperature";
            this.CellTemperature.ReadOnly = true;
            this.CellTemperature.Resizable = System.Windows.Forms.DataGridViewTriState.False;
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
            this.CellVoltage0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell1Voltage
            // 
            this.Cell1Voltage.DataPropertyName = "Cell1mV";
            this.Cell1Voltage.HeaderText = "Cell 1 mV";
            this.Cell1Voltage.Name = "Cell1Voltage";
            this.Cell1Voltage.ReadOnly = true;
            this.Cell1Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell2Voltage
            // 
            this.Cell2Voltage.DataPropertyName = "Cell2mV";
            this.Cell2Voltage.HeaderText = "Cell 2 mV";
            this.Cell2Voltage.Name = "Cell2Voltage";
            this.Cell2Voltage.ReadOnly = true;
            this.Cell2Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell3Voltage
            // 
            this.Cell3Voltage.DataPropertyName = "Cell3mV";
            this.Cell3Voltage.HeaderText = "Cell 3 mV";
            this.Cell3Voltage.Name = "Cell3Voltage";
            this.Cell3Voltage.ReadOnly = true;
            this.Cell3Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell4Voltage
            // 
            this.Cell4Voltage.DataPropertyName = "Cell4mV";
            this.Cell4Voltage.HeaderText = "Cell 4 mV";
            this.Cell4Voltage.Name = "Cell4Voltage";
            this.Cell4Voltage.ReadOnly = true;
            this.Cell4Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell5Voltage
            // 
            this.Cell5Voltage.DataPropertyName = "Cell5mV";
            this.Cell5Voltage.HeaderText = "Cell 5 mV";
            this.Cell5Voltage.Name = "Cell5Voltage";
            this.Cell5Voltage.ReadOnly = true;
            this.Cell5Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell6Voltage
            // 
            this.Cell6Voltage.DataPropertyName = "Cell6mV";
            this.Cell6Voltage.HeaderText = "Cell 6 mV";
            this.Cell6Voltage.Name = "Cell6Voltage";
            this.Cell6Voltage.ReadOnly = true;
            this.Cell6Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Cell7Voltage
            // 
            this.Cell7Voltage.DataPropertyName = "Cell7mV";
            this.Cell7Voltage.HeaderText = "Cell 7 mV";
            this.Cell7Voltage.Name = "Cell7Voltage";
            this.Cell7Voltage.ReadOnly = true;
            this.Cell7Voltage.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // BatteryViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 475);
            this.Controls.Add(this.cmuTelemetry);
            this.Controls.Add(this.bmuTelemetry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatteryViewerForm";
            this.Text = "Battery Viewer";
            this.bmuTelemetry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BMUdataGridView)).EndInit();
            this.cmuTelemetry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CMUdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmuDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox bmuTelemetry;
        private System.Windows.Forms.GroupBox cmuTelemetry;
        private System.Windows.Forms.DataGridView CMUdataGridView;
        private System.Windows.Forms.DataGridView BMUdataGridView;
        private System.Windows.Forms.BindingSource cmuDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinmV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Min_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_C;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_mV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pack_mA;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePositive;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceNegative;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMU_Count;
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