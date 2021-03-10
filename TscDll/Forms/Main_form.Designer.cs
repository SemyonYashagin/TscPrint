
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
            this.Button_PrinterSettings = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tB_Sscc = new System.Windows.Forms.TextBox();
            this.tB_Sgtin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.but_UpdatePrinterStatus = new System.Windows.Forms.Button();
            this.tB_PrinterMode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.Button_PrinterSettings);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tB_Sscc);
            this.groupBox1.Controls.Add(this.tB_Sgtin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Размеры этикеток";
            // 
            // Button_PrinterSettings
            // 
            this.Button_PrinterSettings.Location = new System.Drawing.Point(249, 25);
            this.Button_PrinterSettings.Name = "Button_PrinterSettings";
            this.Button_PrinterSettings.Size = new System.Drawing.Size(140, 37);
            this.Button_PrinterSettings.TabIndex = 4;
            this.Button_PrinterSettings.Text = "Настройки";
            this.Button_PrinterSettings.UseVisualStyleBackColor = true;
            this.Button_PrinterSettings.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
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
            this.tB_Sscc.Size = new System.Drawing.Size(170, 20);
            this.tB_Sscc.TabIndex = 7;
            // 
            // tB_Sgtin
            // 
            this.tB_Sgtin.Location = new System.Drawing.Point(75, 22);
            this.tB_Sgtin.Name = "tB_Sgtin";
            this.tB_Sgtin.ReadOnly = true;
            this.tB_Sgtin.Size = new System.Drawing.Size(170, 20);
            this.tB_Sgtin.TabIndex = 6;
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
            // tB_PrinterStatus
            // 
            this.tB_PrinterStatus.BackColor = System.Drawing.SystemColors.Control;
            this.tB_PrinterStatus.Location = new System.Drawing.Point(85, 22);
            this.tB_PrinterStatus.Name = "tB_PrinterStatus";
            this.tB_PrinterStatus.ReadOnly = true;
            this.tB_PrinterStatus.Size = new System.Drawing.Size(202, 20);
            this.tB_PrinterStatus.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
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
            this.cb_sizes.SelectedIndexChanged += new System.EventHandler(this.Cb_sizes_SelectedIndexChanged);
            this.cb_sizes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cb_sizes_KeyPress);
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
            this.label3.Location = new System.Drawing.Point(18, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Печать:";
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(235, 6);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(166, 23);
            this.buttonPrint.TabIndex = 5;
            this.buttonPrint.Text = "Печать";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(420, 306);
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
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ProductName
            // 
            this.ProductName.Caption = "Наименование";
            this.ProductName.FieldName = "ProductName";
            this.ProductName.Name = "ProductName";
            this.ProductName.OptionsColumn.AllowMove = false;
            this.ProductName.Visible = true;
            this.ProductName.VisibleIndex = 1;
            this.ProductName.Width = 90;
            // 
            // Gtin
            // 
            this.Gtin.Caption = "GTIN";
            this.Gtin.FieldName = "Gtin";
            this.Gtin.Name = "Gtin";
            this.Gtin.OptionsColumn.AllowMove = false;
            this.Gtin.Visible = true;
            this.Gtin.VisibleIndex = 2;
            this.Gtin.Width = 96;
            // 
            // SgtinCount
            // 
            this.SgtinCount.Caption = "Кол-во SGTIN-ов";
            this.SgtinCount.FieldName = "SgtinCount";
            this.SgtinCount.Name = "SgtinCount";
            this.SgtinCount.OptionsColumn.AllowMove = false;
            this.SgtinCount.Visible = true;
            this.SgtinCount.VisibleIndex = 3;
            this.SgtinCount.Width = 92;
            // 
            // SsccCount
            // 
            this.SsccCount.Caption = "Кол-во SSCC";
            this.SsccCount.FieldName = "SsccCount";
            this.SsccCount.Name = "SsccCount";
            this.SsccCount.OptionsColumn.AllowMove = false;
            this.SsccCount.Visible = true;
            this.SsccCount.VisibleIndex = 4;
            this.SsccCount.Width = 94;
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
            this.splitContainer.SplitterDistance = 178;
            this.splitContainer.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.but_UpdatePrinterStatus);
            this.groupBox2.Controls.Add(this.tB_PrinterMode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tB_PrinterStatus);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 76);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Принтер";
            // 
            // but_UpdatePrinterStatus
            // 
            this.but_UpdatePrinterStatus.Location = new System.Drawing.Point(293, 21);
            this.but_UpdatePrinterStatus.Name = "but_UpdatePrinterStatus";
            this.but_UpdatePrinterStatus.Size = new System.Drawing.Size(75, 23);
            this.but_UpdatePrinterStatus.TabIndex = 6;
            this.but_UpdatePrinterStatus.Text = "Обновить";
            this.but_UpdatePrinterStatus.UseVisualStyleBackColor = true;
            this.but_UpdatePrinterStatus.Click += new System.EventHandler(this.But_UpdatePrinterStatus_Click);
            // 
            // tB_PrinterMode
            // 
            this.tB_PrinterMode.Location = new System.Drawing.Point(85, 50);
            this.tB_PrinterMode.Name = "tB_PrinterMode";
            this.tB_PrinterMode.ReadOnly = true;
            this.tB_PrinterMode.Size = new System.Drawing.Size(283, 20);
            this.tB_PrinterMode.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Режим печати";
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
            this.Text = "Печать SGTIN и SSCC";
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
        private System.Windows.Forms.Button Button_PrinterSettings;
        private System.Windows.Forms.TextBox tB_PrinterStatus;
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
        public DevExpress.XtraGrid.Columns.GridColumn ProdName;
        private System.Windows.Forms.TextBox tB_PrinterMode;
        private System.Windows.Forms.Label label5;
        public DevExpress.XtraGrid.Columns.GridColumn ProductName;
        private System.Windows.Forms.Button but_UpdatePrinterStatus;
    }
}