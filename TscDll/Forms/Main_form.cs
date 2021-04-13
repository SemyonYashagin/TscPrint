﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;
using System.Drawing;
using TscDll.Extensions;
using System.Threading.Tasks;

namespace TscDll.Forms
{
    public partial class Main_form : Form
    {
        //List<MarkPrintUnit> markPrints = new List<MarkPrintUnit>();
        private Settings settings;
        SimplePrint marks = new SimplePrint();

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
        //public void InputToGV(List<MarkPrintUnit> units)
        //{
        //    gridControl1.DataSource = ObjectExtensions.ToDataTable(units);
        //    markPrints = units;
        //}

        public void InputToGV(SimplePrint units)
        {
            gridControl1.DataSource = ObjectExtensions.ToDataTable(units);
            marks = units;
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
            if (TscHelper.Printer_status())
            {
                tB_PrinterStatus.Text = "Готов к работе";
                tB_PrinterStatus.BackColor = Color.FromArgb(192, 255, 192);
                cb_sizes.Enabled = true;
                but_UpdatePrinterStatus.Enabled = false;
            }
            else
            {
                tB_PrinterStatus.Text = "Ошибка инициализации";
                tB_PrinterStatus.BackColor = Color.FromArgb(255, 192, 192);
                cb_sizes.Enabled = false;
                but_UpdatePrinterStatus.Enabled = true;
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
            cb_sizes.Items.Add("SGTIN");
            cb_sizes.Items.Add("SSCC");
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
        //private void ButtonPrint_Click(object sender, EventArgs e)
        //{
        //    if (cb_sizes.SelectedItem.ToString() == "SGTIN")//print sgtins
        //    {
        //        List<Tuple<string, List<string>>> sgtins = GetSgtins(markPrints);

        //        if(sgtins.Count!=0)
        //        {
        //            Settings set = XMLHelper.GetSettings();
        //            SgtinHelper.Init_printer(set.SgtinSize.Width, set.SgtinSize.Height);
        //            SgtinHelper.PrintSgtins(set.SgtinSize.Width, set.SgtinSize.Height, sgtins);
        //        }
        //        else AutoClosingMessageBox.Show("Выберите хотя бы один элемент для печати", "Ошибка", 1500);

        //    }
        //    else//print sscces
        //    {
        //        List<Tuple<string, string>> sscces = GetSsccs(markPrints);
        //        if (sscces.Count!=0)
        //        {
        //            Settings set = XMLHelper.GetSettings();
        //            SgtinHelper.Init_printer(set.SsccSize.Width, set.SsccSize.Height);
        //            SsccHelper.PrintSsccs(set.SsccSize.Width, set.SsccSize.Height, sscces);
        //        }
        //        else AutoClosingMessageBox.Show("Выберите хотя бы один элемент для печати", "Ошибка", 1500);
        //    }
        //}

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            if (cb_sizes.SelectedItem.ToString() == "SGTIN")//print sgtins
            {
                if (marks.sgtins.Count != 0)
                {
                    Settings set = XMLHelper.GetSettings();
                    SgtinHelper.Init_printer(set.SgtinSize.Width, set.SgtinSize.Height);
                    SgtinHelper.PrintSgtins(set.SgtinSize.Width, set.SgtinSize.Height, marks);
                }
                else AutoClosingMessageBox.Show("Выберите хотя бы один элемент для печати", "Ошибка", 1500);

            }
            else//print sscces
            {
                if (marks.SSCCs.Count != 0)
                {
                    Settings set = XMLHelper.GetSettings();
                    SgtinHelper.Init_printer(set.SsccSize.Width, set.SsccSize.Height);
                    SsccHelper.PrintSsccs(set.SsccSize.Width, set.SsccSize.Height, marks);
                }
                else AutoClosingMessageBox.Show("Выберите хотя бы один элемент для печати", "Ошибка", 1500);
            }
        }

        /// <summary>
        /// Метод для взятия Sgtin-ов из объекта List<MarkPrintUnit>
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        private List<Tuple<string, List<string>>> GetSgtins(List<MarkPrintUnit> units)
        {
            List<Tuple<string, List<string>>> partyIdSgtins = new List<Tuple<string, List<string>>>();

            int[] selectedIndex = gridView1.GetSelectedRows();

            for (int i = 0; i < selectedIndex.Length; i++)
            {
                List<Tuple<string, List<string>>> sgtins1 = new List<Tuple<string, List<string>>>();
                int index = selectedIndex[i];
                sgtins1.Clear();
                List<Tuple<string, List<string>>> sgtins2 = GetSgtinsRecur(sgtins1, units[index].Units, units[index]);

                foreach (Tuple<string, List<string>> sgtins in sgtins2)
                    partyIdSgtins.Add(sgtins);
            }
            return partyIdSgtins;
        }

        /// <summary>
        /// Метод для рекурсивного взятия Sgtin-ов из объекта Unit
        /// </summary>
        /// <param name="All_Sgtin"></param>
        /// <param name="unit"></param>
        private List<Tuple<string, List<string>>> GetSgtinsRecur(List<Tuple<string, List<string>>> All_Sgtin, Unit unit, MarkPrintUnit units)
        {
            if (unit.Units != null)
            {
                if (unit.Sgtins != null)
                {
                    string uniqueNumber = "";
                    if(unit.parentId == 0)
                        uniqueNumber = "x" + "|" + units.PartyId;
                    else
                        uniqueNumber = unit.parentId.ToString() + "|" + units.PartyId;

                    Tuple<string, List<string>> temp = new Tuple<string, List<string>>(uniqueNumber, unit.Sgtins);
                    All_Sgtin.Add(temp);
                }
                foreach (Unit item_sscc in unit.Units)
                {
                    GetSgtinsRecur(All_Sgtin, item_sscc, units);
                }
            }
            if (unit.Units == null)
            {
                string uniqueNumber = "";
                if (unit.parentId == 0)
                    uniqueNumber = "x" + "|" + units.PartyId;
                else
                    uniqueNumber = unit.parentId.ToString() + "|" + units.PartyId;

                Tuple<string, List<string>> temp = new Tuple<string, List<string>>(uniqueNumber, unit.Sgtins);
                All_Sgtin.Add(temp);
            }
            return All_Sgtin;
        }

        /// <summary>
        /// Метод для взятия Sscc из объекта List<MarkPrintUnit>
        /// </summary>
        /// <param name="sscces"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        private List<Tuple<string, string>> GetSsccs(List<MarkPrintUnit> units)
        {
            List<Tuple<string, string>> Sscces = new List<Tuple<string, string>>();

            int[] selectedIndex = gridView1.GetSelectedRows();

            for (int i = 0; i < selectedIndex.Length; i++)
            {
                int index = selectedIndex[i];
                GetSsccsRecur(Sscces, units[index].Units, units[index]);
            }

            return Sscces;
        }

        /// <summary>
        /// Метод для рекурсивного взятия Sscc из объекта Unit
        /// </summary>
        /// <param name="All_Sscc"></param>
        /// <param name="unit"></param>
        private List<Tuple<string, string>> GetSsccsRecur(List<Tuple<string, string>> All_Sscc, Unit unit, MarkPrintUnit units)
        {
            if (unit.Units != null)
            {
                foreach (Unit item_sscc in unit.Units)
                {
                    GetSsccsRecur(All_Sscc, item_sscc, units);
                }
            }

            if (unit.SsccValue != null)
            {
                string uniqueNumber="";
                if (unit.parentId == 0)
                    uniqueNumber = "x" + "/" + unit.Id.ToString() + "|" + units.PartyId;
                else
                    uniqueNumber = unit.parentId.ToString() + "/" + unit.Id.ToString() + "|" + units.PartyId;
                Tuple<string, string> temp = new Tuple<string, string>(uniqueNumber, unit.SsccValue);
                All_Sscc.Add(temp);
            }
            return All_Sscc;
        }

        private void But_UpdatePrinterStatus_Click(object sender, EventArgs e)
        {
            UpdateFields();
        }

        private void Cb_sizes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Cb_sizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object selectedItem = cb_sizes.SelectedItem;
            Settings set = XMLHelper.GetSettings();
            buttonPrint.Enabled = false;

            if (selectedItem != null)
            {
                string message = "Вы уверены что установлен рулон этикеток для печати " + selectedItem.ToString() + "?";
                const string caption = "Проверка";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (selectedItem.ToString() == "SGTIN")
                {
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Вставьте рулон для " + selectedItem.ToString());
                        buttonPrint.Enabled = false;
                        //buttonPrint.Enabled = true;
                        cb_sizes.Text = null;
                    }
                    else
                    {
                        if (TscHelper.PrinterConnection(set.SgtinSize.Height))
                        {
                            AutoClosingMessageBox.Show("Проверка этикетки выполнена успешно. Можете печатать!", "Успешно", 1500);
                            buttonPrint.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Выбранный Вами рулон этикеток и рулон установленный в принтере не совпадают!");
                            buttonPrint.Enabled = false;
                            cb_sizes.Text = null;
                        }
                    }
                }
                if (selectedItem.ToString() == "SSCC")
                {
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Вставьте рулон для " + selectedItem.ToString());
                        buttonPrint.Enabled = false;
                        //buttonPrint.Enabled = true;
                        cb_sizes.Text = null;
                    }
                    else
                    {
                        if (TscHelper.PrinterConnection(set.SsccSize.Height))
                        {
                            AutoClosingMessageBox.Show("Проверка этикетки выполнена успешно. Можете печатать!", "Успешно", 1500);
                            buttonPrint.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("Выбранный Вами рулон этикеток и рулон установленный в принтере не совпадают!");
                            buttonPrint.Enabled = false;
                            cb_sizes.Text = null;
                        }
                    }
                }
            }            
        }
    }
}
