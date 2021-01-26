
namespace TscDll.Forms
{
    partial class PrintSettings
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
            this.tB_PrinterName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Button_Synch = new System.Windows.Forms.Button();
            this.cB_SgtinSize = new System.Windows.Forms.ComboBox();
            this.cB_SsccSize = new System.Windows.Forms.ComboBox();
            this.numericSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericDensity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensity)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_PrinterName
            // 
            this.tB_PrinterName.Location = new System.Drawing.Point(76, 25);
            this.tB_PrinterName.Name = "tB_PrinterName";
            this.tB_PrinterName.Size = new System.Drawing.Size(191, 20);
            this.tB_PrinterName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование принтера";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Насыщенность печати";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размер этикеток для печати SGTIN-ов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Размер этикеток для печати SSCC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Скорость печати";
            // 
            // Button_Synch
            // 
            this.Button_Synch.Location = new System.Drawing.Point(49, 278);
            this.Button_Synch.Name = "Button_Synch";
            this.Button_Synch.Size = new System.Drawing.Size(185, 23);
            this.Button_Synch.TabIndex = 12;
            this.Button_Synch.Text = "Сохранить";
            this.Button_Synch.UseVisualStyleBackColor = true;
            this.Button_Synch.Click += new System.EventHandler(this.Button_Synch_Click);
            // 
            // cB_SgtinSize
            // 
            this.cB_SgtinSize.FormattingEnabled = true;
            this.cB_SgtinSize.Location = new System.Drawing.Point(76, 79);
            this.cB_SgtinSize.Name = "cB_SgtinSize";
            this.cB_SgtinSize.Size = new System.Drawing.Size(191, 21);
            this.cB_SgtinSize.TabIndex = 13;
            // 
            // cB_SsccSize
            // 
            this.cB_SsccSize.FormattingEnabled = true;
            this.cB_SsccSize.Location = new System.Drawing.Point(76, 135);
            this.cB_SsccSize.Name = "cB_SsccSize";
            this.cB_SsccSize.Size = new System.Drawing.Size(191, 21);
            this.cB_SsccSize.TabIndex = 14;
            // 
            // numericSpeed
            // 
            this.numericSpeed.Location = new System.Drawing.Point(76, 190);
            this.numericSpeed.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericSpeed.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericSpeed.Name = "numericSpeed";
            this.numericSpeed.ReadOnly = true;
            this.numericSpeed.Size = new System.Drawing.Size(191, 20);
            this.numericSpeed.TabIndex = 15;
            this.numericSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericDensity
            // 
            this.numericDensity.Location = new System.Drawing.Point(76, 242);
            this.numericDensity.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericDensity.Name = "numericDensity";
            this.numericDensity.ReadOnly = true;
            this.numericDensity.Size = new System.Drawing.Size(191, 20);
            this.numericDensity.TabIndex = 16;
            // 
            // PrintSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 313);
            this.Controls.Add(this.numericDensity);
            this.Controls.Add(this.numericSpeed);
            this.Controls.Add(this.cB_SsccSize);
            this.Controls.Add(this.cB_SgtinSize);
            this.Controls.Add(this.Button_Synch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_PrinterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PrintSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки принтера";
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tB_PrinterName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Button_Synch;
        private System.Windows.Forms.ComboBox cB_SgtinSize;
        private System.Windows.Forms.ComboBox cB_SsccSize;
        private System.Windows.Forms.NumericUpDown numericSpeed;
        private System.Windows.Forms.NumericUpDown numericDensity;
    }
}