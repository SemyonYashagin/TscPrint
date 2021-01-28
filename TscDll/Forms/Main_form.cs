using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;
using System.Drawing;
using TscDll.Extensions;

namespace TscDll.Forms
{

    public partial class Main_form : Form
    {
        private Settings settings;
        public Main_form()
        {
            InitializeComponent();
            UpdatePrinterStatus();
            UpdateFields();
            buttonPrint.Enabled = false;
           
        }

        public void InputToGV(List<MarkPrintUnit> units)
        {
            gridControl1.DataSource = ObjectExtensions.ToDataTable(units);
        }
        
        /// <summary>
        /// Обновление статуса принтера
        /// </summary>
        private void UpdatePrinterStatus()
        {
            this.settings = TscHelper.GetSettings();
        }
        /// <summary>
        /// Обновление полей Main_form формы
        /// </summary>
        private void UpdateFields()
        {
            if (TscHelper.Printer_status(settings))
            {
                tB_PrinterStatus.Text = "Готов к работе";
                tB_PrinterStatus.BackColor = Color.FromArgb(192, 255, 192);
                cb_sizes.Enabled = true;
            }
            else
            {
                tB_PrinterStatus.Text = "Ошибка инициализации";
                tB_PrinterStatus.BackColor = Color.FromArgb(255, 192, 192);
                cb_sizes.Enabled = false;
            }

            if (TscHelper.FileExist() && settings.SgtinSize!= null && settings.SsccSize!= null)
            {

                tB_Sgtin.Text = settings.SgtinSize.Size;
                tB_Sscc.Text = settings.SsccSize.Size;
            }
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            cb_sizes.Items.Clear();
            cb_sizes.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_sizes.Items.Add("SGTIN");
            cb_sizes.Items.Add("SSCC");

        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            Object selectedItem = cb_sizes.SelectedItem;
            string message = "Вы уверены что установлен рулон этикеток для печати " + selectedItem.ToString() + "?";
            const string caption = "Проверка";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (selectedItem.ToString() == "SGTIN")
            {
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Вставьте рулон для " + selectedItem.ToString());
                    buttonPrint.Enabled = false;
                }
                else
                {
                    buttonPrint.Enabled = true;
                }
            }
            if (selectedItem.ToString() == "SSCC")
            {
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Вставьте рулон для " + selectedItem.ToString());
                    buttonPrint.Enabled = false;
                }
                else
                {
                    buttonPrint.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frm = new PrintSettings();
            frm.ShowDialog();
            UpdatePrinterStatus();
            UpdateFields();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adding_NewSize newSize = new Adding_NewSize();
            newSize.ShowDialog();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if(cb_sizes.SelectedItem.ToString() == "SGTIN")//print sgtins
            {
                Settings set = TscHelper.GetSettings();
                TscHelper.Init_printer(set.SgtinSize.Width, set.SgtinSize.Height);
                //TscHelper.PrintSgtins(set.SgtinSize.Width, set.SgtinSize.Height, )
                
                
                

            }
            else//print sscces
            {

            }
        }
    }
}
