namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTeikou = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.numericUpDownStdCal = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStdMeas = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDmmCal = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.labelGpib = new System.Windows.Forms.Label();
            this.numericUpDownGpib = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStdCal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStdMeas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDmmCal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGpib)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTeikou
            // 
            this.labelTeikou.AutoSize = true;
            this.labelTeikou.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTeikou.Location = new System.Drawing.Point(204, 23);
            this.labelTeikou.Name = "labelTeikou";
            this.labelTeikou.Size = new System.Drawing.Size(378, 16);
            this.labelTeikou.TabIndex = 6;
            this.labelTeikou.Text = "標準器校正値　　　　DMM測定値　　　　　　DMM校正比";
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.PortName = "COM6";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(20, 182);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(147, 325);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStart.Location = new System.Drawing.Point(21, 23);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(148, 61);
            this.buttonStart.TabIndex = 9;
            this.buttonStart.Text = "CAL START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStop.Location = new System.Drawing.Point(20, 90);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(148, 61);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "CAL STOP";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // numericUpDownStdCal
            // 
            this.numericUpDownStdCal.DecimalPlaces = 2;
            this.numericUpDownStdCal.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownStdCal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownStdCal.Location = new System.Drawing.Point(207, 42);
            this.numericUpDownStdCal.Maximum = new decimal(new int[] {
            110000,
            0,
            0,
            0});
            this.numericUpDownStdCal.Name = "numericUpDownStdCal";
            this.numericUpDownStdCal.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownStdCal.TabIndex = 15;
            this.numericUpDownStdCal.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // numericUpDownStdMeas
            // 
            this.numericUpDownStdMeas.DecimalPlaces = 2;
            this.numericUpDownStdMeas.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownStdMeas.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownStdMeas.Location = new System.Drawing.Point(344, 42);
            this.numericUpDownStdMeas.Maximum = new decimal(new int[] {
            110000000,
            0,
            0,
            0});
            this.numericUpDownStdMeas.Name = "numericUpDownStdMeas";
            this.numericUpDownStdMeas.ReadOnly = true;
            this.numericUpDownStdMeas.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownStdMeas.TabIndex = 16;
            // 
            // numericUpDownDmmCal
            // 
            this.numericUpDownDmmCal.DecimalPlaces = 6;
            this.numericUpDownDmmCal.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.numericUpDownDmmCal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownDmmCal.Location = new System.Drawing.Point(491, 42);
            this.numericUpDownDmmCal.Maximum = new decimal(new int[] {
            110000000,
            0,
            0,
            0});
            this.numericUpDownDmmCal.Name = "numericUpDownDmmCal";
            this.numericUpDownDmmCal.ReadOnly = true;
            this.numericUpDownDmmCal.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownDmmCal.TabIndex = 17;
            this.numericUpDownDmmCal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(207, 71);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(404, 436);
            this.richTextBoxOutput.TabIndex = 19;
            this.richTextBoxOutput.Text = "";
            // 
            // labelGpib
            // 
            this.labelGpib.AutoSize = true;
            this.labelGpib.Location = new System.Drawing.Point(22, 159);
            this.labelGpib.Name = "labelGpib";
            this.labelGpib.Size = new System.Drawing.Size(67, 12);
            this.labelGpib.TabIndex = 21;
            this.labelGpib.Text = "GPIB ADDR";
            this.labelGpib.Click += new System.EventHandler(this.labelGpib_Click);
            // 
            // numericUpDownGpib
            // 
            this.numericUpDownGpib.Location = new System.Drawing.Point(95, 157);
            this.numericUpDownGpib.Name = "numericUpDownGpib";
            this.numericUpDownGpib.Size = new System.Drawing.Size(72, 19);
            this.numericUpDownGpib.TabIndex = 22;
            this.numericUpDownGpib.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 519);
            this.Controls.Add(this.numericUpDownGpib);
            this.Controls.Add(this.labelGpib);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.numericUpDownDmmCal);
            this.Controls.Add(this.numericUpDownStdMeas);
            this.Controls.Add(this.numericUpDownStdCal);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelTeikou);
            this.Name = "Form1";
            this.Text = "SELF CALBRATION";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStdCal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStdMeas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDmmCal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGpib)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTeikou;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.NumericUpDown numericUpDownStdCal;
        private System.Windows.Forms.NumericUpDown numericUpDownStdMeas;
        private System.Windows.Forms.NumericUpDown numericUpDownDmmCal;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Label labelGpib;
        private System.Windows.Forms.NumericUpDown numericUpDownGpib;
    }
}

