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
        private void UpdatePrinterStatus()
        {
            settings = TscHelper.GetSettings();
        }

        public void GetBitmap(Bitmap bitmap)
        {
            gs128 = bitmap;
        }

        private void UpdateFields()
        {            
            if (TscHelper.Printer_status(settings))
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

            if (TscHelper.FileExist() && settings.Gs128Size != null)
            {

                tB_Gs128Size.Text = settings.Gs128Size.Size;
            }

            if (tB_PrinterStatus.Text == "Готов к работе" && tB_Gs128Size.Text != "")
                button_PrintGS128.Enabled = true;
        }

        private void button_SettingsGS128_Click(object sender, EventArgs e)
        {
            Gs128Settings gssetting = new Gs128Settings();
            gssetting.ShowDialog();
            UpdateFields();
        }

        private void button_PrintGS128_Click(object sender, EventArgs e)
        {
            ResponseData response = TscHelper.CheckGS128(gs128);
            if (response.IsSuccess) MessageBox.Show("Печать прошла успешна");
            else MessageBox.Show(response.ErrorMessage);
        }
    }
}
