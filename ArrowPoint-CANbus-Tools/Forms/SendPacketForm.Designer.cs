namespace ArrowPointCANBusTool
{
    partial class SendPacketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendPacketForm));
            this.tbRawData = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbExtended = new System.Windows.Forms.CheckBox();
            this.cbRtr = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbIdBase10 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tbFloat0 = new System.Windows.Forms.TextBox();
            this.tbFloat1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tbInt0 = new System.Windows.Forms.TextBox();
            this.tbInt1 = new System.Windows.Forms.TextBox();
            this.tbInt2 = new System.Windows.Forms.TextBox();
            this.tbInt3 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbByte0 = new System.Windows.Forms.TextBox();
            this.tbByte1 = new System.Windows.Forms.TextBox();
            this.tbByte3 = new System.Windows.Forms.TextBox();
            this.tbByte4 = new System.Windows.Forms.TextBox();
            this.tbByte2 = new System.Windows.Forms.TextBox();
            this.tbByte5 = new System.Windows.Forms.TextBox();
            this.tbByte6 = new System.Windows.Forms.TextBox();
            this.tbByte7 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbLoopRate = new System.Windows.Forms.TextBox();
            this.btnLoop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRawData
            // 
            this.tbRawData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRawData.Location = new System.Drawing.Point(6, 22);
            this.tbRawData.Margin = new System.Windows.Forms.Padding(2);
            this.tbRawData.Name = "tbRawData";
            this.tbRawData.Size = new System.Drawing.Size(462, 23);
            this.tbRawData.TabIndex = 98;
            this.tbRawData.Leave += new System.EventHandler(this.TbRawData_Leave);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(6, 252);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(104, 38);
            this.btnReset.TabIndex = 22;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(376, 252);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(104, 38);
            this.btnSend.TabIndex = 19;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbRawData);
            this.groupBox1.Location = new System.Drawing.Point(7, 194);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(475, 54);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Raw UDP Packet Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbExtended);
            this.groupBox2.Controls.Add(this.cbRtr);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.tbIdBase10);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(475, 55);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CAN Header";
            // 
            // cbExtended
            // 
            this.cbExtended.AutoSize = true;
            this.cbExtended.Location = new System.Drawing.Point(179, 34);
            this.cbExtended.Margin = new System.Windows.Forms.Padding(2);
            this.cbExtended.Name = "cbExtended";
            this.cbExtended.Size = new System.Drawing.Size(15, 14);
            this.cbExtended.TabIndex = 3;
            this.cbExtended.UseVisualStyleBackColor = true;
            this.cbExtended.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CbExtended_MouseClick);
            // 
            // cbRtr
            // 
            this.cbRtr.AutoSize = true;
            this.cbRtr.Location = new System.Drawing.Point(266, 35);
            this.cbRtr.Margin = new System.Windows.Forms.Padding(2);
            this.cbRtr.Name = "cbRtr";
            this.cbRtr.Size = new System.Drawing.Size(15, 14);
            this.cbRtr.TabIndex = 4;
            this.cbRtr.UseVisualStyleBackColor = true;
            this.cbRtr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CbRtr_MouseClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(263, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 99;
            this.label12.Text = "RTR";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(177, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 99;
            this.label11.Text = "Extended";
            // 
            // tbIdBase10
            // 
            this.tbIdBase10.Location = new System.Drawing.Point(93, 31);
            this.tbIdBase10.Margin = new System.Windows.Forms.Padding(2);
            this.tbIdBase10.MaxLength = 10;
            this.tbIdBase10.Name = "tbIdBase10";
            this.tbIdBase10.Size = new System.Drawing.Size(71, 20);
            this.tbIdBase10.TabIndex = 2;
            this.tbIdBase10.Leave += new System.EventHandler(this.TbIdBase10_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base 10 ID";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(7, 31);
            this.tbId.Margin = new System.Windows.Forms.Padding(2);
            this.tbId.MaxLength = 8;
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(56, 20);
            this.tbId.TabIndex = 1;
            this.tbId.Leave += new System.EventHandler(this.TbId_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "ID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.tbFloat0);
            this.groupBox3.Controls.Add(this.tbFloat1);
            this.groupBox3.Controls.Add(this.label28);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tbInt0);
            this.groupBox3.Controls.Add(this.tbInt1);
            this.groupBox3.Controls.Add(this.tbInt2);
            this.groupBox3.Controls.Add(this.tbInt3);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbByte0);
            this.groupBox3.Controls.Add(this.tbByte1);
            this.groupBox3.Controls.Add(this.tbByte3);
            this.groupBox3.Controls.Add(this.tbByte4);
            this.groupBox3.Controls.Add(this.tbByte2);
            this.groupBox3.Controls.Add(this.tbByte5);
            this.groupBox3.Controls.Add(this.tbByte6);
            this.groupBox3.Controls.Add(this.tbByte7);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(7, 64);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(475, 127);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CAN Data";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(233, 89);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 13);
            this.label24.TabIndex = 99;
            this.label24.Text = "Float 0";
            // 
            // tbFloat0
            // 
            this.tbFloat0.Location = new System.Drawing.Point(238, 104);
            this.tbFloat0.Margin = new System.Windows.Forms.Padding(2);
            this.tbFloat0.Name = "tbFloat0";
            this.tbFloat0.Size = new System.Drawing.Size(230, 20);
            this.tbFloat0.TabIndex = 18;
            this.tbFloat0.Leave += new System.EventHandler(this.TbFloat1_Leave);
            // 
            // tbFloat1
            // 
            this.tbFloat1.Location = new System.Drawing.Point(7, 104);
            this.tbFloat1.Margin = new System.Windows.Forms.Padding(2);
            this.tbFloat1.Name = "tbFloat1";
            this.tbFloat1.Size = new System.Drawing.Size(230, 20);
            this.tbFloat1.TabIndex = 17;
            this.tbFloat1.Leave += new System.EventHandler(this.TbFloat0_Leave);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(4, 89);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 13);
            this.label28.TabIndex = 99;
            this.label28.Text = "Float 1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(351, 54);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 13);
            this.label14.TabIndex = 99;
            this.label14.Text = "Int 0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(235, 54);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(28, 13);
            this.label16.TabIndex = 99;
            this.label16.Text = "Int 1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(123, 54);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 13);
            this.label18.TabIndex = 99;
            this.label18.Text = "Int 2";
            // 
            // tbInt0
            // 
            this.tbInt0.Location = new System.Drawing.Point(353, 69);
            this.tbInt0.Margin = new System.Windows.Forms.Padding(2);
            this.tbInt0.Name = "tbInt0";
            this.tbInt0.Size = new System.Drawing.Size(114, 20);
            this.tbInt0.TabIndex = 16;
            this.tbInt0.Leave += new System.EventHandler(this.TbInt3_Leave);
            // 
            // tbInt1
            // 
            this.tbInt1.Location = new System.Drawing.Point(238, 69);
            this.tbInt1.Margin = new System.Windows.Forms.Padding(2);
            this.tbInt1.Name = "tbInt1";
            this.tbInt1.Size = new System.Drawing.Size(114, 20);
            this.tbInt1.TabIndex = 15;
            this.tbInt1.Leave += new System.EventHandler(this.TbInt2_Leave);
            // 
            // tbInt2
            // 
            this.tbInt2.Location = new System.Drawing.Point(122, 69);
            this.tbInt2.Margin = new System.Windows.Forms.Padding(2);
            this.tbInt2.Name = "tbInt2";
            this.tbInt2.Size = new System.Drawing.Size(114, 20);
            this.tbInt2.TabIndex = 14;
            this.tbInt2.Leave += new System.EventHandler(this.TbInt1_Leave);
            // 
            // tbInt3
            // 
            this.tbInt3.Location = new System.Drawing.Point(6, 69);
            this.tbInt3.Margin = new System.Windows.Forms.Padding(2);
            this.tbInt3.Name = "tbInt3";
            this.tbInt3.Size = new System.Drawing.Size(114, 20);
            this.tbInt3.TabIndex = 13;
            this.tbInt3.Leave += new System.EventHandler(this.TbInt0_Leave);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 54);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 13);
            this.label20.TabIndex = 99;
            this.label20.Text = "Int 3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(409, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 99;
            this.label10.Text = "Byte 7";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(351, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 99;
            this.label9.Text = "Byte 6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 99;
            this.label8.Text = "Byte 5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(235, 19);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 99;
            this.label7.Text = "Byte 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 19);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 99;
            this.label6.Text = "Byte 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 19);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Byte 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Byte 1";
            // 
            // tbByte0
            // 
            this.tbByte0.Location = new System.Drawing.Point(411, 34);
            this.tbByte0.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte0.MaxLength = 2;
            this.tbByte0.Name = "tbByte0";
            this.tbByte0.Size = new System.Drawing.Size(56, 20);
            this.tbByte0.TabIndex = 12;
            this.tbByte0.Leave += new System.EventHandler(this.TbByte7_Leave);
            // 
            // tbByte1
            // 
            this.tbByte1.Location = new System.Drawing.Point(353, 34);
            this.tbByte1.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte1.MaxLength = 2;
            this.tbByte1.Name = "tbByte1";
            this.tbByte1.Size = new System.Drawing.Size(56, 20);
            this.tbByte1.TabIndex = 11;
            this.tbByte1.Leave += new System.EventHandler(this.TbByte6_Leave);
            // 
            // tbByte3
            // 
            this.tbByte3.Location = new System.Drawing.Point(238, 34);
            this.tbByte3.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte3.MaxLength = 2;
            this.tbByte3.Name = "tbByte3";
            this.tbByte3.Size = new System.Drawing.Size(56, 20);
            this.tbByte3.TabIndex = 9;
            this.tbByte3.Leave += new System.EventHandler(this.TbByte4_Leave);
            // 
            // tbByte4
            // 
            this.tbByte4.Location = new System.Drawing.Point(180, 34);
            this.tbByte4.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte4.MaxLength = 2;
            this.tbByte4.Name = "tbByte4";
            this.tbByte4.Size = new System.Drawing.Size(56, 20);
            this.tbByte4.TabIndex = 8;
            this.tbByte4.Leave += new System.EventHandler(this.TbByte3_Leave);
            // 
            // tbByte2
            // 
            this.tbByte2.Location = new System.Drawing.Point(296, 34);
            this.tbByte2.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte2.MaxLength = 2;
            this.tbByte2.Name = "tbByte2";
            this.tbByte2.Size = new System.Drawing.Size(56, 20);
            this.tbByte2.TabIndex = 10;
            this.tbByte2.Leave += new System.EventHandler(this.TbByte5_Leave);
            // 
            // tbByte5
            // 
            this.tbByte5.Location = new System.Drawing.Point(122, 34);
            this.tbByte5.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte5.MaxLength = 2;
            this.tbByte5.Name = "tbByte5";
            this.tbByte5.Size = new System.Drawing.Size(56, 20);
            this.tbByte5.TabIndex = 7;
            this.tbByte5.Leave += new System.EventHandler(this.TbByte2_Leave);
            // 
            // tbByte6
            // 
            this.tbByte6.Location = new System.Drawing.Point(64, 34);
            this.tbByte6.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte6.MaxLength = 2;
            this.tbByte6.Name = "tbByte6";
            this.tbByte6.Size = new System.Drawing.Size(56, 20);
            this.tbByte6.TabIndex = 6;
            this.tbByte6.Leave += new System.EventHandler(this.TbByte1_Leave);
            // 
            // tbByte7
            // 
            this.tbByte7.Location = new System.Drawing.Point(7, 34);
            this.tbByte7.Margin = new System.Windows.Forms.Padding(2);
            this.tbByte7.MaxLength = 2;
            this.tbByte7.Name = "tbByte7";
            this.tbByte7.Size = new System.Drawing.Size(56, 20);
            this.tbByte7.TabIndex = 5;
            this.tbByte7.Leave += new System.EventHandler(this.TbByte0_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Byte 0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(184, 252);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 99;
            this.label13.Text = "Loop Rate (ms)";
            // 
            // tbLoopRate
            // 
            this.tbLoopRate.Location = new System.Drawing.Point(182, 268);
            this.tbLoopRate.Margin = new System.Windows.Forms.Padding(2);
            this.tbLoopRate.Name = "tbLoopRate";
            this.tbLoopRate.Size = new System.Drawing.Size(84, 20);
            this.tbLoopRate.TabIndex = 20;
            // 
            // btnLoop
            // 
            this.btnLoop.Location = new System.Drawing.Point(268, 252);
            this.btnLoop.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoop.Name = "btnLoop";
            this.btnLoop.Size = new System.Drawing.Size(104, 38);
            this.btnLoop.TabIndex = 21;
            this.btnLoop.Text = "Loop";
            this.btnLoop.UseVisualStyleBackColor = true;
            this.btnLoop.Click += new System.EventHandler(this.BtnLoop_Click);
            // 
            // SendPacketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 304);
            this.Controls.Add(this.btnLoop);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tbLoopRate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 343);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(506, 343);
            this.Name = "SendPacketForm";
            this.Text = "Send CanPacket";
            this.Load += new System.EventHandler(this.SendPacketForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRawData;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbExtended;
        private System.Windows.Forms.CheckBox cbRtr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbIdBase10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbByte0;
        private System.Windows.Forms.TextBox tbByte1;
        private System.Windows.Forms.TextBox tbByte3;
        private System.Windows.Forms.TextBox tbByte4;
        private System.Windows.Forms.TextBox tbByte2;
        private System.Windows.Forms.TextBox tbByte5;
        private System.Windows.Forms.TextBox tbByte6;
        private System.Windows.Forms.TextBox tbByte7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbLoopRate;
        private System.Windows.Forms.Button btnLoop;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tbFloat0;
        private System.Windows.Forms.TextBox tbFloat1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbInt0;
        private System.Windows.Forms.TextBox tbInt1;
        private System.Windows.Forms.TextBox tbInt2;
        private System.Windows.Forms.TextBox tbInt3;
        private System.Windows.Forms.Label label20;
    }
}