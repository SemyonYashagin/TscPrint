using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TscDll.Entities;

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
            comboBox1.Items.Clear();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("SGTIN (43*25 mm)");
            comboBox1.Items.Add("SSCC (100*50 mm)");
        }

        private void comboBox1_TextChanged_1(object sender, EventArgs e)
        {
            Object selectedItem = comboBox1.SelectedItem;
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
    }
}
