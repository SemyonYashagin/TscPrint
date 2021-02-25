
namespace TscDll.Forms
{
    partial class Gs128Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gs128Settings));
            this.cB_GS128Size = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_AddNewSize = new System.Windows.Forms.Button();
            this.Button_SaveNewSettings = new System.Windows.Forms.Button();
            this.cB_PrinterName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cB_GS128Size
            // 
            this.cB_GS128Size.FormattingEnabled = true;
            this.cB_GS128Size.Location = new System.Drawing.Point(14, 64);
            this.cB_GS128Size.Name = "cB_GS128Size";
            this.cB_GS128Size.Size = new System.Drawing.Size(150, 21);
            this.cB_GS128Size.TabIndex = 17;
            this.cB_GS128Size.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_GS128Size_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Размер этикеток для GS128";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Наименование принтера";
            // 
            // Button_AddNewSize
            // 
            this.Button_AddNewSize.Image = global::TscDll.Properties.Resources.add;
            this.Button_AddNewSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_AddNewSize.Location = new System.Drawing.Point(12, 91);
            this.Button_AddNewSize.Name = "Button_AddNewSize";
            this.Button_AddNewSize.Size = new System.Drawing.Size(152, 26);
            this.Button_AddNewSize.TabIndex = 19;
            this.Button_AddNewSize.Text = "Новый размер";
            this.Button_AddNewSize.UseVisualStyleBackColor = true;
            this.Button_AddNewSize.Click += new System.EventHandler(this.Button_AddNewSize_Click);
            // 
            // Button_SaveNewSettings
            // 
            this.Button_SaveNewSettings.Location = new System.Drawing.Point(13, 123);
            this.Button_SaveNewSettings.Name = "Button_SaveNewSettings";
            this.Button_SaveNewSettings.Size = new System.Drawing.Size(151, 22);
            this.Button_SaveNewSettings.TabIndex = 18;
            this.Button_SaveNewSettings.Text = "Сохранить";
            this.Button_SaveNewSettings.UseVisualStyleBackColor = true;
            this.Button_SaveNewSettings.Click += new System.EventHandler(this.Button_SaveNewSettings_Click);
            // 
            // cB_PrinterName
            // 
            this.cB_PrinterName.FormattingEnabled = true;
            this.cB_PrinterName.Location = new System.Drawing.Point(15, 24);
            this.cB_PrinterName.Name = "cB_PrinterName";
            this.cB_PrinterName.Size = new System.Drawing.Size(149, 21);
            this.cB_PrinterName.TabIndex = 20;
            this.cB_PrinterName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_PrinterName_KeyPress);
            // 
            // Gs128Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 155);
            this.Controls.Add(this.cB_PrinterName);
            this.Controls.Add(this.Button_AddNewSize);
            this.Controls.Add(this.Button_SaveNewSettings);
            this.Controls.Add(this.cB_GS128Size);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gs128Settings";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cB_GS128Size;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_AddNewSize;
        private System.Windows.Forms.Button Button_SaveNewSettings;
        private System.Windows.Forms.ComboBox cB_PrinterName;
    }
}