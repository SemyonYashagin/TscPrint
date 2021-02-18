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
        List<MarkPrintUnit> markPrints = new List<MarkPrintUnit>();
        private Settings settings;
        public Main_form()
        {
            InitializeComponent();
            UpdatePrinterStatus();
            UpdateFields();
            buttonPrint.Enabled = false;
           
        }
        /// <summary>
        /// Метод для вставки данные в GridView
        /// </summary>
        /// <param name="units">Список объектов MarkPrintUnit</param>
        public void InputToGV(List<MarkPrintUnit> units)
        {
            gridControl1.DataSource = ObjectExtensions.ToDataTable(units);
            markPrints = units;
        }
        
        /// <summary>
        /// Обновление статуса принтера
        /// </summary>
        private void UpdatePrinterStatus()
        {
            this.settings = XMLHelper.GetSettings();
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

            if (XMLHelper.FileExist() && settings.SgtinSize!= null && settings.SsccSize!= null)
            {

                tB_Sgtin.Text = settings.SgtinSize.Size;
                tB_Sscc.Text = settings.SsccSize.Size;
                tB_PrinterMode.Text = settings.PrinterMode;
            }
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            cb_sizes.Items.Clear();
            cb_sizes.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_sizes.Items.Add("SGTIN");
            cb_sizes.Items.Add("SSCC");
        }

        private void ComboBox1_TextChanged_1(object sender, EventArgs e)
        {
            Object selectedItem = cb_sizes.SelectedItem;
            Settings set = XMLHelper.GetSettings();
            buttonPrint.Enabled = false;

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
                    if (TscHelper.PrinterConnection(set.SgtinSize.Height))
                    {
                        AutoClosingMessageBox.Show("Проверка этикетки выполнена успешно. Можете печатать!", "Успешно", 2000);
                        buttonPrint.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Выбранный Вами рулон этикеток и рулон установленный в принтере не совпадают!");
                        buttonPrint.Enabled = false;
                    }
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
                    if (TscHelper.PrinterConnection(set.SsccSize.Height))
                    {
                        AutoClosingMessageBox.Show("Проверка этикетки выполнена успешно. Можете печатать!", "Успешно", 2000);
                        buttonPrint.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Выбранный Вами рулон этикеток и рулон установленный в принтере не совпадают!");
                        buttonPrint.Enabled = false;
                    }

                    //buttonPrint.Enabled = true;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var frm = new PrintSettings();
            frm.ShowDialog();
            UpdatePrinterStatus();
            UpdateFields();
        }

        /// <summary>
        /// Кнопка для печати SGTIN-ов или SSCC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            if (cb_sizes.SelectedItem.ToString() == "SGTIN")//print sgtins
            {
                List<string> sgtins = new List<string>();
                sgtins = GetSgtin(sgtins, markPrints);
                Settings set = XMLHelper.GetSettings();
                SgtinHelper.Init_printer(set.SgtinSize.Width, set.SgtinSize.Height);
                SgtinHelper.PrintSgtins(set.SgtinSize.Width, set.SgtinSize.Height, sgtins);
                //TscHelper.FakePrinting();

            }
            else//print sscces
            {
                List<string> sscces = new List<string>();
                sscces = GetSscc(sscces, markPrints);
                Settings set = XMLHelper.GetSettings();
                SgtinHelper.Init_printer(set.SsccSize.Width, set.SsccSize.Height);
                ResponseData response = SsccHelper.PrintSscc(set.SsccSize.Width, set.SsccSize.Height, sscces);
                if (response.IsSuccess)
                    MessageBox.Show("Напечатано");
                else MessageBox.Show(response.ErrorMessage);
            }
        }

        /// <summary>
        /// Метод для взятия Sgtin-ов из объекта List<MarkPrintUnit>
        /// </summary>
        /// <param name="sgtins"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        private List<string> GetSgtin(List<string> sgtins, List<MarkPrintUnit> units)
        {
            foreach (MarkPrintUnit unit in units)
            {
                GetSgtinRecur(sgtins, unit.Units);
            }

            return sgtins;
        }

        /// <summary>
        /// Метод для рекурсивного взятия Sgtin-ов из объекта Unit
        /// </summary>
        /// <param name="All_Sgtin"></param>
        /// <param name="unit"></param>
        private void GetSgtinRecur(List<string> All_Sgtin, Unit unit)
        {
            if (unit.Units != null)
            {
                foreach (Unit item_sscc in unit.Units)
                {
                    GetSgtinRecur(All_Sgtin, item_sscc);
                }
            }
            if (unit.Units == null)
            {
                foreach (string sgtin in unit.Sgtins)
                {
                    All_Sgtin.Add(sgtin);
                }
            }
        }

        /// <summary>
        /// Метод для взятия Sscc из объекта List<MarkPrintUnit>
        /// </summary>
        /// <param name="sscces"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        private List<string> GetSscc(List<string> sscces, List<MarkPrintUnit> units)
        {
            foreach (MarkPrintUnit unit in units)
            {
                GetSsccRecur(sscces, unit.Units);
            }

            return sscces;
        }

        /// <summary>
        /// Метод для рекурсивного взятия Sscc из объекта Unit
        /// </summary>
        /// <param name="All_Sscc"></param>
        /// <param name="unit"></param>
        private void GetSsccRecur(List<string> All_Sscc, Unit unit)
        {
            if (unit.Units != null)
            {
                foreach (Unit item_sscc in unit.Units)
                {
                    GetSsccRecur(All_Sscc, item_sscc);
                }
            }
            if(unit.SsccValue!=null) All_Sscc.Add(unit.SsccValue);
        }
    }
}
