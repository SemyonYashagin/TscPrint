﻿
namespace TscDll.Forms
{
    partial class AddNewSizeGS128_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_PutNewSize = new System.Windows.Forms.Button();
            this.tB_newSizeHeight = new System.Windows.Forms.TextBox();
            this.tB_newSizeWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_PutNewSize);
            this.groupBox1.Controls.Add(this.tB_newSizeHeight);
            this.groupBox1.Controls.Add(this.tB_newSizeWidth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 113);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавление нового размера этикетки";
            // 
            // button_PutNewSize
            // 
            this.button_PutNewSize.Location = new System.Drawing.Point(55, 77);
            this.button_PutNewSize.Name = "button_PutNewSize";
            this.button_PutNewSize.Size = new System.Drawing.Size(116, 23);
            this.button_PutNewSize.TabIndex = 1;
            this.button_PutNewSize.Text = "Добавить";
            this.button_PutNewSize.UseVisualStyleBackColor = true;
            this.button_PutNewSize.Click += new System.EventHandler(this.button_PutNewSize_Click);
            // 
            // tB_newSizeHeight
            // 
            this.tB_newSizeHeight.Location = new System.Drawing.Point(94, 51);
            this.tB_newSizeHeight.Name = "tB_newSizeHeight";
            this.tB_newSizeHeight.ShortcutsEnabled = false;
            this.tB_newSizeHeight.Size = new System.Drawing.Size(100, 20);
            this.tB_newSizeHeight.TabIndex = 3;
            this.tB_newSizeHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_newSizeHeight_KeyPress);
            // 
            // tB_newSizeWidth
            // 
            this.tB_newSizeWidth.Location = new System.Drawing.Point(95, 20);
            this.tB_newSizeWidth.Name = "tB_newSizeWidth";
            this.tB_newSizeWidth.ShortcutsEnabled = false;
            this.tB_newSizeWidth.Size = new System.Drawing.Size(100, 20);
            this.tB_newSizeWidth.TabIndex = 2;
            this.tB_newSizeWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tB_newSizeWidth_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Высота (мм)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ширина (мм)";
            // 
            // AddNewSizeGS128_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 140);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNewSizeGS128_Form";
            this.Text = "Новый размер";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_PutNewSize;
        private System.Windows.Forms.TextBox tB_newSizeHeight;
        private System.Windows.Forms.TextBox tB_newSizeWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}