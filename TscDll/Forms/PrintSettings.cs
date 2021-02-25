using System;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class PrintSettings : Form
    {

        Settings settings = XMLHelper.GetSettings();
        public PrintSettings()
        {
            InitializeComponent();
            UpdateFields();

        }
        /// <summary>
        /// Сохранение новых настроек принтера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Synch_Click(object sender, EventArgs e)
        {
            if (XMLHelper.FileExist() && cB_SgtinSize.Text!="" && cB_SsccSize.Text!="" && cB_PrinterName.Text != "" && cB_PrintMode.Text!="")
            {
                Settings newset = XMLHelper.GetSettings();

                newset.PrinterName = cB_PrinterName.Text;
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
                newset.PrinterMode = cB_PrintMode.Text;

                ResponseData response = XMLHelper.SaveSettings(newset);

                if (response.IsSuccess)
                {
                    AutoClosingMessageBox.Show("Данные загружены", "Успешно", 1500);
                    XMLHelper.GetSettings();
                    Close();
                }
                else
                {
                    AutoClosingMessageBox.Show(response.ErrorMessage, "Ошибка", 1500);
                }
            }
            else
            {
                AutoClosingMessageBox.Show("Введите данные", "Ошибка", 1500);
            }
        }
        /// <summary>
        /// Метод для взтия объекта Intvalue из объекта класса Settings
        /// </summary>
        /// <param name="set">объект класса Settings</param>
        /// <param name="size">новый размер</param>
        /// <returns>возвращает объект Intvalue</returns>
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
        /// <summary>
        /// Обновление полей
        /// </summary>
        private void UpdateFields()
        {

            cB_PrinterName.Items.Clear();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cB_PrinterName.Items.Add(printer);
            }

            if (XMLHelper.FileExist())
            {
                Settings settings = XMLHelper.GetSettings();
                cB_SgtinSize.Items.Clear();
                cB_SsccSize.Items.Clear();
                cB_PrinterName.Text = settings.PrinterName;

                if (settings.SsccSize != null && settings.SgtinSize != null && settings.PrinterMode != null)
                {
                    cB_SgtinSize.Text = settings.SgtinSize.Size;
                    cB_SsccSize.Text = settings.SsccSize.Size;
                    cB_PrintMode.Text = settings.PrinterMode;
                }

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

        private void cB_SgtinSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cB_SsccSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cB_PrintMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cB_PrinterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
