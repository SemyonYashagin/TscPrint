
namespace TscDll.Forms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_Sscc = new System.Windows.Forms.TextBox();
            this.tB_Sgtin = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tB_PrinterStatus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_sizes = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Gtin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SgtinCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SsccCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tB_Sscc);
            this.groupBox1.Controls.Add(this.tB_Sgtin);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размеры этикеток";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SSCC";
            // 
            // tB_Sscc
            // 
            this.tB_Sscc.Location = new System.Drawing.Point(75, 46);
            this.tB_Sscc.Name = "tB_Sscc";
            this.tB_Sscc.ReadOnly = true;
            this.tB_Sscc.Size = new System.Drawing.Size(132, 20);
            this.tB_Sscc.TabIndex = 7;
            // 
            // tB_Sgtin
            // 
            this.tB_Sgtin.Location = new System.Drawing.Point(75, 22);
            this.tB_Sgtin.Name = "tB_Sgtin";
            this.tB_Sgtin.ReadOnly = true;
            this.tB_Sgtin.Size = new System.Drawing.Size(132, 20);
            this.tB_Sgtin.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Image = global::TscDll.Properties.Resources.add;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(213, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(156, 37);
            this.button3.TabIndex = 5;
            this.button3.Text = "Новый размер";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SGTIN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Настройки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tB_PrinterStatus
            // 
            this.tB_PrinterStatus.Location = new System.Drawing.Point(75, 37);
            this.tB_PrinterStatus.Name = "tB_PrinterStatus";
            this.tB_PrinterStatus.ReadOnly = true;
            this.tB_PrinterStatus.Size = new System.Drawing.Size(132, 20);
            this.tB_PrinterStatus.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Состояние \r\n принтера";
            // 
            // cb_sizes
            // 
            this.cb_sizes.FormattingEnabled = true;
            this.cb_sizes.Location = new System.Drawing.Point(97, 8);
            this.cb_sizes.Name = "cb_sizes";
            this.cb_sizes.Size = new System.Drawing.Size(132, 21);
            this.cb_sizes.TabIndex = 1;
            this.cb_sizes.TextChanged += new System.EventHandler(this.comboBox1_TextChanged_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonPrint);
            this.panel2.Controls.Add(this.cb_sizes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 488);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 37);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Режим печати:";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(235, 6);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(166, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Печать";
            this.buttonPrint.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(420, 276);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ProductName,
            this.Gtin,
            this.SgtinCount,
            this.SsccCount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Наименование";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 0;
            // 
            // Gtin
            // 
            this.Gtin.Caption = "GTIN";
            this.Gtin.FieldName = "Gtin";
            this.Gtin.Name = "Gtin";
            this.Gtin.Visible = true;
            this.Gtin.VisibleIndex = 1;
            // 
            // SgtinCount
            // 
            this.SgtinCount.Caption = "Кол-во SGTIN";
            this.SgtinCount.FieldName = "SgtinCount";
            this.SgtinCount.Name = "SgtinCount";
            this.SgtinCount.Visible = true;
            this.SgtinCount.VisibleIndex = 2;
            // 
            // SsccCount
            // 
            this.SsccCount.Caption = "Кол-во SSCC";
            this.SsccCount.FieldName = "SsccCount";
            this.SsccCount.Name = "SsccCount";
            this.SsccCount.Visible = true;
            this.SsccCount.VisibleIndex = 3;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer.Size = new System.Drawing.Size(420, 488);
            this.splitContainer.SplitterDistance = 208;
            this.splitContainer.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tB_PrinterStatus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 82);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Принтер";
            // 
            // Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 525);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Печать этикеток";
            this.Load += new System.EventHandler(this.Main_form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ComboBox cb_sizes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tB_PrinterStatus;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraGrid.Columns.GridColumn Gtin;
        private DevExpress.XtraGrid.Columns.GridColumn SgtinCount;
        private DevExpress.XtraGrid.Columns.GridColumn SsccCount;
        private System.Windows.Forms.TextBox tB_Sscc;
        private System.Windows.Forms.TextBox tB_Sgtin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        public DevExpress.XtraGrid.Columns.GridColumn ProductName;
    }
}