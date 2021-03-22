
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Button_SaveNewSettings = new System.Windows.Forms.Button();
            this.cB_SgtinSize = new System.Windows.Forms.ComboBox();
            this.cB_SsccSize = new System.Windows.Forms.ComboBox();
            this.numericSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericDensity = new System.Windows.Forms.NumericUpDown();
            this.Button_AddNewSize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cB_PrintMode = new System.Windows.Forms.ComboBox();
            this.cB_PrinterName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensity)).BeginInit();
            this.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(13, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Насыщенность печати";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(13, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размер этикеток для печати SGTIN-ов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Размер этикеток для печати SSCC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Скорость печати";
            // 
            // Button_SaveNewSettings
            // 
            this.Button_SaveNewSettings.Location = new System.Drawing.Point(16, 283);
            this.Button_SaveNewSettings.Name = "Button_SaveNewSettings";
            this.Button_SaveNewSettings.Size = new System.Drawing.Size(190, 22);
            this.Button_SaveNewSettings.TabIndex = 12;
            this.Button_SaveNewSettings.Text = "Сохранить";
            this.Button_SaveNewSettings.UseVisualStyleBackColor = true;
            this.Button_SaveNewSettings.Click += new System.EventHandler(this.Button_Synch_Click);
            // 
            // cB_SgtinSize
            // 
            this.cB_SgtinSize.FormattingEnabled = true;
            this.cB_SgtinSize.Location = new System.Drawing.Point(15, 64);
            this.cB_SgtinSize.Name = "cB_SgtinSize";
            this.cB_SgtinSize.Size = new System.Drawing.Size(191, 21);
            this.cB_SgtinSize.TabIndex = 13;
            this.cB_SgtinSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_SgtinSize_KeyPress);
            // 
            // cB_SsccSize
            // 
            this.cB_SsccSize.FormattingEnabled = true;
            this.cB_SsccSize.Location = new System.Drawing.Point(15, 104);
            this.cB_SsccSize.Name = "cB_SsccSize";
            this.cB_SsccSize.Size = new System.Drawing.Size(191, 21);
            this.cB_SsccSize.TabIndex = 14;
            this.cB_SsccSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_SsccSize_KeyPress);
            // 
            // numericSpeed
            // 
            this.numericSpeed.Location = new System.Drawing.Point(15, 144);
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
            this.numericDensity.Location = new System.Drawing.Point(15, 183);
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
            // Button_AddNewSize
            // 
            this.Button_AddNewSize.Image = global::TscDll.Properties.Resources.add;
            this.Button_AddNewSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_AddNewSize.Location = new System.Drawing.Point(15, 251);
            this.Button_AddNewSize.Name = "Button_AddNewSize";
            this.Button_AddNewSize.Size = new System.Drawing.Size(191, 26);
            this.Button_AddNewSize.TabIndex = 17;
            this.Button_AddNewSize.Text = "Новый размер";
            this.Button_AddNewSize.UseVisualStyleBackColor = true;
            this.Button_AddNewSize.Click += new System.EventHandler(this.Button_AddNewSize_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Режим печати";
            // 
            // cB_PrintMode
            // 
            this.cB_PrintMode.FormattingEnabled = true;
            this.cB_PrintMode.Items.AddRange(new object[] {
            "Пакетный режим",
            "Режим смотчика"});
            this.cB_PrintMode.Location = new System.Drawing.Point(16, 224);
            this.cB_PrintMode.Name = "cB_PrintMode";
            this.cB_PrintMode.Size = new System.Drawing.Size(190, 21);
            this.cB_PrintMode.TabIndex = 19;
            this.cB_PrintMode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_PrintMode_KeyPress);
            // 
            // cB_PrinterName
            // 
            this.cB_PrinterName.FormattingEnabled = true;
            this.cB_PrinterName.Location = new System.Drawing.Point(16, 26);
            this.cB_PrinterName.Name = "cB_PrinterName";
            this.cB_PrinterName.Size = new System.Drawing.Size(190, 21);
            this.cB_PrinterName.TabIndex = 20;
            this.cB_PrinterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_PrinterName_KeyPress);
            // 
            // PrintSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 317);
            this.Controls.Add(this.cB_PrinterName);
            this.Controls.Add(this.cB_PrintMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Button_AddNewSize);
            this.Controls.Add(this.numericDensity);
            this.Controls.Add(this.numericSpeed);
            this.Controls.Add(this.cB_SsccSize);
            this.Controls.Add(this.cB_SgtinSize);
            this.Controls.Add(this.Button_SaveNewSettings);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PrintSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.numericSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Button_SaveNewSettings;
        private System.Windows.Forms.ComboBox cB_SgtinSize;
        private System.Windows.Forms.ComboBox cB_SsccSize;
        private System.Windows.Forms.NumericUpDown numericSpeed;
        private System.Windows.Forms.NumericUpDown numericDensity;
        private System.Windows.Forms.Button Button_AddNewSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cB_PrintMode;
        private System.Windows.Forms.ComboBox cB_PrinterName;
    }
}