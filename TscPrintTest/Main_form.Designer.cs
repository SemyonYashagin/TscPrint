
namespace TscPrintTest
{
    partial class Main_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_form));
            this.DGV_Name_Gtin = new System.Windows.Forms.DataGridView();
            this.Item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.But_SGTIN_print = new System.Windows.Forms.Button();
            this.But_SSCC_print = new System.Windows.Forms.Button();
            this.DGV_Sgtin_Sscc = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Name_Gtin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Sgtin_Sscc)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_Name_Gtin
            // 
            this.DGV_Name_Gtin.AllowUserToAddRows = false;
            this.DGV_Name_Gtin.AllowUserToDeleteRows = false;
            this.DGV_Name_Gtin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Name_Gtin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_name,
            this.GTIN});
            this.DGV_Name_Gtin.Location = new System.Drawing.Point(12, 106);
            this.DGV_Name_Gtin.Name = "DGV_Name_Gtin";
            this.DGV_Name_Gtin.ReadOnly = true;
            this.DGV_Name_Gtin.Size = new System.Drawing.Size(244, 179);
            this.DGV_Name_Gtin.TabIndex = 1;
            this.DGV_Name_Gtin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Name_Gtin_CellClick);
            // 
            // Item_name
            // 
            this.Item_name.HeaderText = "Item_name";
            this.Item_name.Name = "Item_name";
            this.Item_name.ReadOnly = true;
            // 
            // GTIN
            // 
            this.GTIN.HeaderText = "GTIN";
            this.GTIN.Name = "GTIN";
            this.GTIN.ReadOnly = true;
            // 
            // But_SGTIN_print
            // 
            this.But_SGTIN_print.Location = new System.Drawing.Point(351, 308);
            this.But_SGTIN_print.Name = "But_SGTIN_print";
            this.But_SGTIN_print.Size = new System.Drawing.Size(112, 30);
            this.But_SGTIN_print.TabIndex = 2;
            this.But_SGTIN_print.Text = "Печать SGTIN\'ов";
            this.But_SGTIN_print.UseVisualStyleBackColor = true;
            this.But_SGTIN_print.Click += new System.EventHandler(this.But_SGTIN_print_Click);
            // 
            // But_SSCC_print
            // 
            this.But_SSCC_print.Location = new System.Drawing.Point(469, 308);
            this.But_SSCC_print.Name = "But_SSCC_print";
            this.But_SSCC_print.Size = new System.Drawing.Size(126, 30);
            this.But_SSCC_print.TabIndex = 3;
            this.But_SSCC_print.Text = "Печать SSCC";
            this.But_SSCC_print.UseVisualStyleBackColor = true;
            this.But_SSCC_print.Click += new System.EventHandler(this.But_SSCC_print_Click);
            // 
            // DGV_Sgtin_Sscc
            // 
            this.DGV_Sgtin_Sscc.AllowUserToAddRows = false;
            this.DGV_Sgtin_Sscc.AllowUserToDeleteRows = false;
            this.DGV_Sgtin_Sscc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Sgtin_Sscc.Location = new System.Drawing.Point(262, 106);
            this.DGV_Sgtin_Sscc.Name = "DGV_Sgtin_Sscc";
            this.DGV_Sgtin_Sscc.ReadOnly = true;
            this.DGV_Sgtin_Sscc.Size = new System.Drawing.Size(245, 179);
            this.DGV_Sgtin_Sscc.TabIndex = 4;
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(607, 350);
            this.Controls.Add(this.DGV_Sgtin_Sscc);
            this.Controls.Add(this.But_SSCC_print);
            this.Controls.Add(this.But_SGTIN_print);
            this.Controls.Add(this.DGV_Name_Gtin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_form";
            this.Text = "Печать";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Name_Gtin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Sgtin_Sscc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DGV_Name_Gtin;
        internal System.Windows.Forms.Button But_SGTIN_print;
        private System.Windows.Forms.Button But_SSCC_print;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN;
        private System.Windows.Forms.DataGridView DGV_Sgtin_Sscc;
    }
}

