
namespace TscDll.Forms
{
    partial class PrintGS128_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintGS128_Form));
            this.button_PrintGS128 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tB_Gs128Size = new System.Windows.Forms.TextBox();
            this.tB_PrinterStatus = new System.Windows.Forms.TextBox();
            this.button_SettingsGS128 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_PrintGS128
            // 
            this.button_PrintGS128.Location = new System.Drawing.Point(120, 126);
            this.button_PrintGS128.Name = "button_PrintGS128";
            this.button_PrintGS128.Size = new System.Drawing.Size(92, 40);
            this.button_PrintGS128.TabIndex = 0;
            this.button_PrintGS128.Text = "Печать";
            this.button_PrintGS128.UseVisualStyleBackColor = true;
            this.button_PrintGS128.Click += new System.EventHandler(this.button_PrintGS128_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cостояние \r\n принтера";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tB_Gs128Size);
            this.groupBox1.Controls.Add(this.tB_PrinterStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 108);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Принтер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = " Размер \r\nэтикетки";
            // 
            // tB_Gs128Size
            // 
            this.tB_Gs128Size.Location = new System.Drawing.Point(76, 70);
            this.tB_Gs128Size.Name = "tB_Gs128Size";
            this.tB_Gs128Size.ReadOnly = true;
            this.tB_Gs128Size.Size = new System.Drawing.Size(100, 20);
            this.tB_Gs128Size.TabIndex = 3;
            // 
            // tB_PrinterStatus
            // 
            this.tB_PrinterStatus.Location = new System.Drawing.Point(76, 33);
            this.tB_PrinterStatus.Name = "tB_PrinterStatus";
            this.tB_PrinterStatus.ReadOnly = true;
            this.tB_PrinterStatus.Size = new System.Drawing.Size(100, 20);
            this.tB_PrinterStatus.TabIndex = 2;
            // 
            // button_SettingsGS128
            // 
            this.button_SettingsGS128.Location = new System.Drawing.Point(12, 126);
            this.button_SettingsGS128.Name = "button_SettingsGS128";
            this.button_SettingsGS128.Size = new System.Drawing.Size(92, 40);
            this.button_SettingsGS128.TabIndex = 3;
            this.button_SettingsGS128.Text = "Настройки";
            this.button_SettingsGS128.UseVisualStyleBackColor = true;
            this.button_SettingsGS128.Click += new System.EventHandler(this.button_SettingsGS128_Click);
            // 
            // PrintGS128_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 186);
            this.Controls.Add(this.button_SettingsGS128);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_PrintGS128);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintGS128_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Печать GS128";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_PrintGS128;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tB_Gs128Size;
        private System.Windows.Forms.TextBox tB_PrinterStatus;
        private System.Windows.Forms.Button button_SettingsGS128;
    }
}