using System;
using System.Windows.Forms;
using TSCSDK;
using TscDll.Entities;
using TscDll.Helpers;
using System.Text;
using System.ComponentModel;

namespace TscDll.Forms
{
    public partial class ProgressForm : Form
    {

        bool net;//if net=false it means the printer is connected to pc by ethernet else by USB
        byte a = 3;
        public ProgressForm()
        {
            InitializeComponent();
            PrinterConnection();
            backgroundWorker2.RunWorkerAsync();
        }
        /// <summary>
        /// Пауза печати
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Settings cur_settings = XMLHelper.GetSettings();
            driver driver = new driver();
            PausePrinting(driver, cur_settings);
            Checking(driver, cur_settings);
        }
        /// <summary>
        /// Метод для определения типа соединения с принтером USB или Ethernet
        /// </summary>
        private void PrinterConnection()
        {
            ethernet ethernet = new ethernet();
            Settings cur_settings = XMLHelper.GetSettings();
            string IP = TscHelper.GetPrinterIP(cur_settings);
            int PortNumber = TscHelper.GetPrinter_PortNumber(IP);

            if (PortNumber != 0)
            {
                ethernet.openport(IP, PortNumber);
                if (ethernet.printerstatus() == 0 || ethernet.printerstatus() == 32)
                    net = true;
                else net = false;
                ethernet.closeport();
            }
            else net = false;           
        }

        /// <summary>
        /// Выбор между дейсвиями: продолжнить печати или отмена печати (перезагрузка принтера)
        /// </summary>
        /// <param name="driver">Объект класса driver</param>
        /// <param name="settings">Объект класса Settings, настройки принтера взятые из XML</param>
        private void Checking(driver driver, Settings settings)
        {
            string message = "Продолжить?";
            const string caption = "Проверка";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            driver.openport(settings.PrinterName);

            if (result == DialogResult.OK)//continue
            {
                driver.sendcommand_hex("1B214F");//to cancel the pause mode and continue printing
            }
            else// cancel printing
            {
                driver.sendcommand_hex("1B2143");//rebooting the printer
                Close();
            }
            driver.closeport();
        }

        /// <summary>
        /// Для перехода в состояние паузы при печати этикеток
        /// </summary>
        /// <param name="driver">Объект класса driver</param>
        /// <param name="settings">Объект класса Settings, настройки принтера взятые из XML</param>
        private void PausePrinting(driver driver, Settings settings)
        {
            driver.openport(settings.PrinterName);
            driver.sendcommand_hex("1B2150");
            driver.closeport();
        }

        /// <summary>
        /// Метод для получения состояния принтера по Ethernet
        /// </summary>
        /// <param name="IP">IP принтера</param>
        /// <param name="PortNumber">Номер порта принтера</param>
        /// <returns>Возвращает бит состояния</returns>
        private byte Check_PrinterStatusEthernet(string IP, int PortNumber)
        {
            ethernet ethernet = new ethernet();
            ethernet.openport(IP, PortNumber);
            byte b;
            try
            {
                b = ethernet.printerstatus();
                ethernet.clearbuffer();
                ethernet.closeport();
            }
            catch (System.Net.Sockets.SocketException)
            {
                b = 99;
            }

            return b;
        }

        /// <summary>
        /// Мотод для получения состояния принтера по USB
        /// </summary>
        /// <returns></returns>
        private byte Check_PrinterStatusUSB()
        {
            usb usb = new usb();
            usb.openport();

            byte b = usb.printerstatus();

            usb.clearbuffer();
            usb.closeport();

            return b;
        }

        /// <summary>
        /// BGW1 для непрерывной фоновой проверки статуса принтера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if(net)
            {
                Settings cur_settings = XMLHelper.GetSettings();
                string IP = TscHelper.GetPrinterIP(cur_settings);
                int PortNumber = TscHelper.GetPrinter_PortNumber(IP);

                while (a != 0)
                {
                    a = Check_PrinterStatusEthernet(IP, PortNumber);
                    if (a == 0)
                    { 
                        break;
                    }
                }
            }
            else
            {
                while (a != 0)
                {
                    a = Check_PrinterStatusUSB();
                    if (a == 0) break;

                }
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
            if(net)
            {
                Settings cur_settings = XMLHelper.GetSettings();
                string IP = TscHelper.GetPrinterIP(cur_settings);
                int PortNumber = TscHelper.GetPrinter_PortNumber(IP);
                while (a != 32)
                {
                    a = Check_PrinterStatusEthernet(IP, PortNumber);
                    if (a == 32) break;
                }
            }
            else
            {
                while (a != 32)
                {
                    a = Check_PrinterStatusUSB();
                    if (a == 32) break;
                }
            }
            
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();          
        }
    }
}
