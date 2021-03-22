using System;
using TscDll.Entities;
using TSCSDK;
using System.Management;
using System.Threading;
using System.Threading.Tasks;

namespace TscDll.Helpers
{
    public class TscHelper
    {
        /// <summary>
        /// Проверка статуса подключения принтера
        /// </summary>
        /// <param name="settings">Объект класса Settings</param>
        /// <returns>true - принтер подключен, иначе false</returns>
        public static Boolean Printer_status()
        {
            Settings settings = XMLHelper.GetSettings();
            if (XMLHelper.FileExist())
            {
                ethernet ethernet = new ethernet();
                usb usb = new usb();

                string IP = GetPrinterIP(settings);
                int PortNumber = GetPrinter_PortNumber(IP);
                if (PortNumber == 0)
                {
                    usb.openport();

                    string printerSystemName = usb.traceUSB_array()[0];// get printer name

                    //if a printer name that a user-selected doesn't contain a real printer name
                    if(printerSystemName!=null)
                    {
                        if (!settings.PrinterName.Contains(printerSystemName))
                        {
                            usb.closeport();
                            return false;
                        }
                    }                  

                    if (usb.traceUSB_string() == "no device") //if a printer is turned off
                    {
                        usb.closeport();
                        return false;
                    }
                    else
                    {
                        usb.closeport();
                        return true;                        
                    }
                }
                else
                {
                    ethernet.openport(IP, PortNumber);
                    
                    try
                    {
                        ethernet.printerstatus();
                    }
                    catch (System.Net.Sockets.SocketException)
                    {
                        return false;
                    }

                    if (ethernet.printerstatus() != 0)
                    {
                        ethernet.closeport();
                        return false;
                    }
                    else
                    {
                        ethernet.closeport();
                        return true;
                    }
                }
            }
            else
                return false;
        }       

        /// <summary>
        /// Проверка размера этикетки в принтере по Ethernet
        /// </summary>
        /// <param name="height">Высота этикетки, которая задана пользователем (из XML файла)</param>
        /// <returns>true-размер этикетки в принтере совпадает с заданной, иначе false</returns>
        private static bool CheckLabelSizeEthernet(int height)
        {
            ethernet ethernet = new ethernet();
            Settings cur_settings = XMLHelper.GetSettings();
            string IP = GetPrinterIP(cur_settings);
            int PortNumber = GetPrinter_PortNumber(IP);

            ethernet.openport(IP, PortNumber);

            if (ethernet.printerstatus() != 99)
            {
                ethernet.sendcommand("LIMITFEED 50 mm");//if the label height is more than 50 mm the calibration will be cancelled.
                ethernet.sendcommand("AUTODETECT");
                Thread.Sleep(4000);
                int printer_height = Convert.ToInt32(ethernet.sendcommand_getstring("OUT NET \"\"; GETSETTING$(\"CONFIG\", \"TSPL\", \"PAPER SIZE\")"));

                if (printer_height <= (height * 11.8) && printer_height >= ((height * 11.8) - 20))
                {
                    int dot = height * 12;
                    ethernet.sendcommand($"BACKFEED {dot}");
                    ethernet.closeport();
                    return true;
                }
            }

            ethernet.closeport();
            return false;
        }
        /// <summary>
        /// Проверка размера этикетки в принтере по USB
        /// </summary>
        /// <param name="height">Высота этикетки, которая задана пользователем (из XML файла)</param>
        /// <returns>true-размер этикетки в принтере совпадает с заданной, иначе false</returns>
        private static bool CheckLabelSizeUSB(int height)
        {
            usb usb = new usb();

            usb.openport();
            usb.sendcommand("LIMITFEED 50 mm");//if the label height is more than 50 mm the calibration will be cancelled.
            usb.sendcommand("AUTODETECT");
            Thread.Sleep(4000);
            int printer_height = Convert.ToInt32(usb.sendcommand_getstring("OUT USB \"\"; GETSETTING$(\"CONFIG\", \"TSPL\", \"PAPER SIZE\")"));

            if (printer_height <= (height * 11.8) && printer_height >= ((height * 11.8) - 20))
            {
                int dot = height * 12;
                usb.sendcommand($"BACKFEED {dot}");
                usb.closeport();
                return true;
            }

            usb.closeport();
            return false;
        }

        /// <summary>
        /// Метод для определения подключения принтера Ethernet или USB
        /// </summary>
        /// <param name="height">Высота этикетки, которая задана пользователем (из XML файла)</param>
        /// <returns>true-размер этикетки в принтере совпадает с заданной, иначе false</returns>
        public static bool PrinterConnection(int height)
        {
            Settings cur_settings = XMLHelper.GetSettings();
            string IP = GetPrinterIP(cur_settings);
            int PortNumber = GetPrinter_PortNumber(IP);

            if (PortNumber == 0) return CheckLabelSizeUSB(height);
            else return CheckLabelSizeEthernet(height);
        }

        /// <summary>
        /// Асинхронный метод для определения подключения принтера Ethernet или USB
        /// </summary>
        /// <param name="height">Высота этикетки, которая задана пользователем (из XML файла)</param>
        /// <returns>true-размер этикетки в принтере совпадает с заданной, иначе false</returns>
        public async static Task<bool> AsyncPrinterConnection(int height)
        {
            Settings cur_settings = XMLHelper.GetSettings();
            string IP = GetPrinterIP(cur_settings);
            int PortNumber = GetPrinter_PortNumber(IP);

            if (PortNumber == 0) return await Task.Run(() => CheckLabelSizeUSB(height));
            else return await Task.Run(() => CheckLabelSizeEthernet(height));
        }

        /// <summary>
        /// Метод для взятия IP адреса по имени принтера
        /// </summary>
        /// <param name="settings">Объет класса Settings, для взятия имени из XML файла с настройками принтера</param>
        /// <returns>IP адрес</returns>
        public static string GetPrinterIP(Settings settings)
        {
            string printerName = settings.PrinterName;
            string printerIP = "";
            string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            using (ManagementObjectCollection coll = searcher.Get())
            {
                try
                {
                    foreach (ManagementObject printer in coll)
                    {
                        foreach (PropertyData property in printer.Properties)
                        {
                            if (property.Name.ToString() == "PortName")
                            {
                                if (property.Value.ToString().Length > 14)
                                    printerIP = property.Value.ToString().Remove(14);
                                else printerIP = property.Value.ToString();
                                break;
                            }
                        }
                        if (!String.IsNullOrEmpty(printerIP)) break;
                    }
                }
                catch (ManagementException ex)
                {
                    throw new ManagementException(ex.Message);
                }
            }
            return printerIP;
        }

        /// <summary>
        /// Метод для взятия номера порта по IP принтера
        /// </summary>
        /// <param name="ip">IP принтера</param>
        /// <returns>Возвращает номер порта</returns>
        public static int GetPrinter_PortNumber(string ip)
        {
            string portNumber = "";

            try
            {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_TCPIPPrinterPort");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["Name"].ToString() == ip)
                    {
                        portNumber = queryObj["PortNumber"].ToString();
                        break;
                    }
                }
            }
            catch (ManagementException e)
            {
                throw new ManagementException(e.Message);
            }

            if (portNumber == "")
                return 0;

            return Convert.ToInt32(portNumber);
        }
    }
}