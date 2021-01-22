using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;
using TscDll.Extensions;

namespace TscDll.Forms
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }

        private void Main_form_Load(object sender, EventArgs e)
        {
            cb_sizes.Items.Clear();
            cb_sizes.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_sizes.Items.Add("SGTIN (43*25 mm)");
            cb_sizes.Items.Add("SSCC (100*50 mm)");

            GetSettings();
        }

        private void GetSettings()
        {
            string set = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter\printerSettings.xml");
            var settings = set.ParseXML(typeof(Settings), System.Text.Encoding.UTF8);
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
        }
    }
}
