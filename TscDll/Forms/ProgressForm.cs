using System;
using System.Windows.Forms;
using TSCSDK;
using TscDll.Entities;
using TscDll.Helpers;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace TscDll.Forms
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();            
            backgroundWorker2.RunWorkerAsync();
        }
        /// <summary>
        /// Пауза печати
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод для получения состояния принтера
        /// </summary>
        /// <param name="IP">IP принтера</param>
        /// <param name="PortNumber">Номер порта принтера</param>
        /// <returns>Возвращает бит состояния</returns>
        public byte Check_PrinterStatus(string IP, int PortNumber)
        {
            ethernet ethernet = new ethernet();
            ethernet.openport(IP, PortNumber);

            byte b = Convert.ToByte(ethernet.sendcommand_hex("1B213F"));
            string outb = ethernet.sendcommand_getstring($"OUT \"\";{b}");
            byte[] ba = Encoding.Default.GetBytes(outb);

            ethernet.clearbuffer();
            ethernet.closeport();

            return ba[0];
        }

        /// <summary>
        /// BGW1 для непрерывной фоновой проверки статуса принтера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Settings cur_settings = TscHelper.GetSettings();
            string IP = TscHelper.GetPrinterIP(cur_settings);
            int PortNumber = TscHelper.GetPrinter_PortNumber(IP);

            byte a = 3;          
            while (a != 0 )
            {
                a = Check_PrinterStatus(IP, PortNumber);
                if (a == 0) break;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// BGW2 для ожидания состояния печати принтера, как только принтер начинает печать срабатывает BGW1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Settings cur_settings = TscHelper.GetSettings();
            string IP = TscHelper.GetPrinterIP(cur_settings);
            int PortNumber = TscHelper.GetPrinter_PortNumber(IP);
            byte a = 3;
            while (a != 32)
            {
                a = Check_PrinterStatus(IP, PortNumber);
                if (a == 20) break;
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();          
        }
    }
}
