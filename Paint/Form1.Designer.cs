namespace Paint
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxColors = new System.Windows.Forms.ComboBox();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.trackBarContrast = new System.Windows.Forms.TrackBar();
            this.buttonTurnLeft = new System.Windows.Forms.Button();
            this.buttonTurnRight = new System.Windows.Forms.Button();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.labelAngle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxColors
            // 
            this.comboBoxColors.FormattingEnabled = true;
            this.comboBoxColors.Items.AddRange(new object[] {
            "0x0..1",
            "0x0..2",
            "0x0..4"});
            this.comboBoxColors.Location = new System.Drawing.Point(35, 37);
            this.comboBoxColors.Name = "comboBoxColors";
            this.comboBoxColors.Size = new System.Drawing.Size(121, 21);
            this.comboBoxColors.TabIndex = 0;
            this.comboBoxColors.TabStop = false;
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Location = new System.Drawing.Point(35, 95);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(104, 45);
            this.trackBarBrightness.TabIndex = 1;
            this.trackBarBrightness.TabStop = false;
            this.trackBarBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarBrightness.Value = 50;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.Location = new System.Drawing.Point(35, 146);
            this.trackBarContrast.Maximum = 500;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(104, 45);
            this.trackBarContrast.TabIndex = 2;
            this.trackBarContrast.TabStop = false;
            this.trackBarContrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarContrast.Value = 50;
            this.trackBarContrast.Scroll += new System.EventHandler(this.trackBarContrast_Scroll);
            // 
            // buttonTurnLeft
            // 
            this.buttonTurnLeft.Location = new System.Drawing.Point(35, 188);
            this.buttonTurnLeft.Name = "buttonTurnLeft";
            this.buttonTurnLeft.Size = new System.Drawing.Size(75, 23);
            this.buttonTurnLeft.TabIndex = 3;
            this.buttonTurnLeft.Text = "Turn left";
            this.buttonTurnLeft.UseVisualStyleBackColor = true;
            this.buttonTurnLeft.Click += new System.EventHandler(this.buttonTurnLeft_Click);
            // 
            // buttonTurnRight
            // 
            this.buttonTurnRight.Location = new System.Drawing.Point(35, 230);
            this.buttonTurnRight.Name = "buttonTurnRight";
            this.buttonTurnRight.Size = new System.Drawing.Size(75, 23);
            this.buttonTurnRight.TabIndex = 4;
            this.buttonTurnRight.Text = "Turn right";
            this.buttonTurnRight.UseVisualStyleBackColor = true;
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxAngle.Location = new System.Drawing.Point(116, 211);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(40, 20);
            this.textBoxAngle.TabIndex = 5;
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(162, 211);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(11, 13);
            this.labelAngle.TabIndex = 6;
            this.labelAngle.Text = "°";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.labelAngle);
            this.Controls.Add(this.textBoxAngle);
            this.Controls.Add(this.buttonTurnRight);
            this.Controls.Add(this.buttonTurnLeft);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.comboBoxColors);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxColors;
        private System.Windows.Forms.TrackBar trackBarBrightness;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.Button buttonTurnLeft;
        private System.Windows.Forms.Button buttonTurnRight;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.Label labelAngle;
    }
}

