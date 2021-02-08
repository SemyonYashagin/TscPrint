using System;
using System.Windows.Forms;
using TSCSDK;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Settings cur_settings = TscHelper.GetSettings();
            driver driver = new driver();
            PausePrinting(driver, cur_settings);
            Checking(driver, cur_settings);
            
        }

        /// <summary>
        /// Выбор между дейсвиями: продолжнить печати или отмена печати (перезагрузка принтера)
        /// </summary>
        /// <param name="driver">Объект класса driver</param>
        /// <param name="settings">Объект класса Settings, настройки принтера взятые из XML</param>
        public void Checking(driver driver, Settings settings)
        {
            string message = "Продолжить?";
            const string caption = "Проверка";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            driver.openport(settings.PrinterName);

            if (result == DialogResult.OK)//continue
            {
                driver.sendcommand_hex("1B214F");
            }
            else// cancel printing
            {
                driver.sendcommand_hex("1B2143");//reboot the printer
                Close();
            }
            driver.closeport();
        }

        /// <summary>
        /// Для перехода в состояние паузы при печати этикеток
        /// </summary>
        /// <param name="driver">Объект класса driver</param>
        /// <param name="settings">Объект класса Settings, настройки принтера взятые из XML</param>
        public void PausePrinting(driver driver, Settings settings)
        {
            driver.openport(settings.PrinterName);
            driver.sendcommand_hex("1B2150");
            driver.closeport();
        }

        public void Check_PrinterStatus(Settings settings)
        {
            //byte b = Convert.ToByte(ethernet.sendcommand_hex("1B213F"));
            //string outb = ethernet.sendcommand_getstring($"OUT \"\";{b}");
            //byte[] ba = Encoding.Default.GetBytes(outb);
            //var hexString = BitConverter.ToString(ba);
        }
    }
}
