using System;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class PrintSettings : Form
    {

        Settings settings = TscHelper.GetSettings();
        public PrintSettings()
        {
            InitializeComponent();
            cB_SgtinSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cB_SsccSize.DropDownStyle = ComboBoxStyle.DropDownList;

            if (settings != null)
            {
                UpdateFields();
            }
            else MessageBox.Show("Исходные данные не найдены");

        }

        private void Button_Synch_Click(object sender, EventArgs e)
        {
            if (TscHelper.FileExist() && cB_SgtinSize.Text!="" && cB_SsccSize.Text!="" && tB_PrinterName.Text!="")
            {
                Settings newset = TscHelper.GetSettings();

                newset.PrinterName = tB_PrinterName.Text;
                newset.SgtinSize = new Intvalue
                {
                    Size = cB_SgtinSize.Text,
                    Width = GetValue(newset, cB_SgtinSize.Text).Width,
                    Height = GetValue(newset, cB_SgtinSize.Text).Height
                };
                newset.SsccSize = new Intvalue
                {
                    Size = cB_SsccSize.Text,
                    Width = GetValue(newset, cB_SsccSize.Text).Width,
                    Height = GetValue(newset, cB_SsccSize.Text).Height
                };
                newset.Speed = numericSpeed.Value;
                newset.Density = numericDensity.Value;

                ResponseData response = TscHelper.SaveSettings(newset);

                if (response.IsSuccess)
                {
                    MessageBox.Show("Данные загружены");
                    TscHelper.GetSettings();
                    Close();
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage);
                }
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private Intvalue GetValue(Settings set, string size)
        {
            foreach (Intvalue value in set.SgtinList)
            {
                if (size == value.Size)
                    return value;
            }
            return null;
        }

        private void Button_AddNewSize_Click(object sender, EventArgs e)
        {
            Adding_NewSize newSize = new Adding_NewSize();
            newSize.ShowDialog();
            UpdateFields();
        }
        private void UpdateFields()
        {
            if (TscHelper.FileExist())
            {
                Settings settings = TscHelper.GetSettings();
                cB_SgtinSize.Items.Clear();
                cB_SsccSize.Items.Clear();
                tB_PrinterName.Text = settings.PrinterName;
                if (settings.Speed < 2 || settings.Speed > 12)
                    numericSpeed.Value = numericSpeed.Minimum;
                else
                    numericSpeed.Value = settings.Speed;

                if (settings.Density > 15)
                    numericDensity.Value = numericDensity.Maximum;
                else
                    numericDensity.Value = settings.Density;

                foreach (Intvalue sgtin in settings.SgtinList)
                {
                    cB_SgtinSize.Items.Add(sgtin.Size);
                }
                foreach (Intvalue sscc in settings.SsccList)
                {
                    cB_SsccSize.Items.Add(sscc.Size);
                }
            }
        }
    }
}
