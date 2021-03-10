using System;
using System.Drawing;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class PrintGS128_Form : Form
    {
        Bitmap gs128;
        private Settings settings;
        public PrintGS128_Form()
        {
            InitializeComponent();
            button_PrintGS128.Enabled = false;
            UpdatePrinterStatus();
            UpdateFields();          
        }
        /// <summary>
        /// Метод для обновления статуса принтера, при закрывании форма Настройки
        /// </summary>
        private void UpdatePrinterStatus()
        {
            settings = XMLHelper.GetSettings();
        }

        /// <summary>
        /// Метод для взятия объекта Bitmap из класса Print
        /// </summary>
        /// <param name="bitmap">GS128 в формате Bitmap</param>
        public void GetBitmap(Bitmap bitmap)
        {
            gs128 = bitmap;
        }
        /// <summary>
        /// Метод для обновления данных на форме
        /// </summary>
        private void UpdateFields()
        {
            settings = XMLHelper.GetSettings();
            if (TscHelper.Printer_status())
            {
                tB_PrinterStatus.Text = "Готов к работе";
                tB_PrinterStatus.BackColor = Color.FromArgb(192, 255, 192);
            }
            else
            {
                tB_PrinterStatus.Text = "Ошибка";
                tB_PrinterStatus.BackColor = Color.FromArgb(255, 192, 192);
                button_PrintGS128.Enabled = false;
            }

            if (XMLHelper.FileExist() && settings.Gs128Size != null)
            {

                tB_Gs128Size.Text = settings.Gs128Size.Size;
            }

            if (tB_PrinterStatus.Text == "Готов к работе" && tB_Gs128Size.Text != "")
                button_PrintGS128.Enabled = true;
        }

        private void Button_SettingsGS128_Click(object sender, EventArgs e)
        {
            Gs128Settings gssetting = new Gs128Settings();
            gssetting.ShowDialog();
            UpdateFields();
        }

        private void Button_PrintGS128_Click(object sender, EventArgs e)
        {
            ResponseData response = GS128Helper.CheckGS128(gs128);
            if (response.IsSuccess) AutoClosingMessageBox.Show("Печать прошла успешна", "Успешно", 1500);
            else AutoClosingMessageBox.Show(response.ErrorMessage, "Ошибка", 1500);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            UpdateFields();
        }
    }
}
