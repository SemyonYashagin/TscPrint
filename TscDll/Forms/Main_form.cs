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
            List<MarkPrintUnit> printUnits = new List<MarkPrintUnit>();
            UnitsInitialize(printUnits);
            buttonPrint.Enabled = false;
            gridControl1.DataSource = ObjectExtensions.ToDataTable(printUnits);
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
            if(TscHelper.Printer_status(settings))
            {
                tB_PrinterStatus.Text = "Готов к работе";
                tB_PrinterStatus.BackColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                tB_PrinterStatus.Text = "Ошибка инициализации";
                tB_PrinterStatus.BackColor = Color.FromArgb(255, 192, 192);
            }
           
            if (TscHelper.FileExist())
            {
                tB_Sgtin.Text = settings.SgtinSize;
                tB_Sscc.Text = settings.SsccSize;
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
                }
            }
            else
            {
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Вставьте рулон для " + selectedItem.ToString());
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

        private void UnitsInitialize(List<MarkPrintUnit> printUnits)
        {
            printUnits.Add(new MarkPrintUnit
            {
                NomenProduct = "Сыр",
                Gtin = "04630030160342",
                PartyId = 1,
                Units = new Unit
                {
                    SsccValue = "46500997801035207",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035208",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02" }
                                 },

                       new Unit {
                                    SsccValue = "46500997801035209",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                 }
                    }
                }

                
            });

            printUnits.Add(new MarkPrintUnit
            {
                NomenProduct = "Молоко",
                Gtin = "04630030160343",
                PartyId = 1,
                Units = new Unit
                {
                    SsccValue = "46500997801035207",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035208",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02", "010463003016034221641556169149391EE02" }
                                 },

                       new Unit {
                                    SsccValue = "46500997801035209",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                },
                       new Unit {
                                    SsccValue = "46500997801035209",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                 }

                    }
                }
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adding_NewSize newSize = new Adding_NewSize();
            newSize.ShowDialog();
        }
    }


}
