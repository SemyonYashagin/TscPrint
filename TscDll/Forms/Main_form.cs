using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;
using System.Drawing;
using TscDll.Extensions;
using System.Xml.Serialization;
using TSCSDK;
using System.Data;

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

        }

        private void UpdatePrinterStatus()
        {
            this.settings = TscHelper.GetSettings();
        }

        private void UpdateFields()
        {
            tB_PrinterStatus.Text = TscHelper.Printer_status(settings).ToString();
            tB_PrinterStatus.Text = TscHelper.Printer_status(settings).ToString();
            if (tB_PrinterStatus.Text == "Готов к работе") tB_PrinterStatus.BackColor = Color.Green;
            else tB_PrinterStatus.BackColor = Color.Red;
            tB_Sgtin.Text = settings.SgtinSizes;
            tB_Sscc.Text = settings.SsccSizes;
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            cb_sizes.Items.Clear();
            cb_sizes.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_sizes.Items.Add("SGTIN (43*25 mm)");
            cb_sizes.Items.Add("SSCC (100*50 mm)");

        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            Object selectedItem = cb_sizes.SelectedItem;
            string message = "Вы уверены что установлен рулон этикеток: " + selectedItem.ToString() + "?";
            const string caption = "Проверка";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (selectedItem.ToString() == "SGTIN (43*25 mm)")
            {
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Вставьте рулон " + selectedItem.ToString());
                }
            }
            else
            {
                if (result == DialogResult.No)
                {
                    MessageBox.Show("Вставьте рулон " + selectedItem.ToString());
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adding_NewSize newSize = new Adding_NewSize();
            newSize.ShowDialog();
        }
    }
}
