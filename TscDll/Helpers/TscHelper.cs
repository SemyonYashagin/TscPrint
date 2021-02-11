using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using TscDll.Entities;
using TscDll.Extensions;
using TscDll.Forms;
using TSCSDK;
using ZXing;
using ZXing.Rendering;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.Text;

namespace TscDll.Helpers
{
    public class TscHelper
    {
        /// <summary>
        /// Проверка на существовании файла в котором храняться настройки принтера
        /// </summary>
        /// <returns>true - файл найден, иначе false</returns>
        public static Boolean FileExist()
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml"; //full directory
            if (File.Exists(fileSettings))
                return true;
            return false;
        }
        /// <summary>
        /// Возвращает настройки принтера из XML
        /// </summary>
        /// <returns>Класс Settings</returns>
        public static Settings GetSettings()
        {
            if (FileExist())
            {
                string set = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter\printerSettings.xml");
                var settings = (Settings)set.ParseXML(typeof(Settings), System.Text.Encoding.GetEncoding("utf-16"));
                return settings;
            }
            return null;
        }
        /// <summary>
        /// Создает файл XML c настройками принтера
        /// </summary>
        /// <param name="settings">Объект класса Settings</param>
        public static void CreateFile(Settings settings)
        {
            string xmlSetting = settings.ToXml();

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml"; //full directory

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            using (StreamWriter outputFile = new StreamWriter(fileSettings))
            {
                outputFile.WriteLine(xmlSetting);
            }
        }
        /// <summary>
        /// Сохраняет настройки принтера в XML 
        /// </summary>
        /// <param name="settings">Объект класса Settings</param>
        /// <returns>true - настройки сохранены успешно, иначе false</returns>
        public static ResponseData SaveSettings(Settings settings)
        {
            ResponseData response = new ResponseData();

            string xmlSetting = settings.ToXml();

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml"; //full directory

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            using (StreamWriter outputFile = new StreamWriter(fileSettings))
            {
                outputFile.WriteLine(xmlSetting);
            }

            if (System.IO.Directory.Exists(directory))
                response.IsSuccess = true;

            return response;
        }
        /// <summary>
        /// Проверка статуса подключения принтера
        /// </summary>
        /// <param name="settings">Объект класса Settings</param>
        /// <returns>true - принтер подключен, иначе false</returns>
        public static Boolean Printer_status(Settings settings)
        {
            settings = TscHelper.GetSettings();
            if (FileExist())
            {
                ethernet ethernet = new ethernet();
                usb usb = new usb();

                string IP = GetPrinterIP(settings);
                int PortNumber = GetPrinter_PortNumber(IP);
                if (PortNumber == 0)
                {
                    usb.openport();                  
                    if (usb.traceUSB_string() == "no device")
                    {
                        usb.closeport();
                        return false;
                    }
                    else
                    {
                        driver driver = new driver();
                        driver.openport(settings.PrinterName);
                        if (driver.driver_status(settings.PrinterName))
                        {
                            driver.closeport();
                            return true;
                        }
                        else
                        {
                            driver.closeport();
                            return false;
                        }                          
                    }
                }
                else
                {
                    ethernet.openport(IP, PortNumber);

                    if (ethernet.printerstatus() != 0)
                    {
                        ethernet.closeport();
                        return false;
                    }
                    else
                    {
                        driver driver = new driver();
                        driver.openport(settings.PrinterName);
                        if (driver.driver_status(settings.PrinterName))
                        {
                            driver.closeport();
                            ethernet.closeport();
                            return true;
                        }
                        else
                        {
                            driver.closeport();
                            ethernet.closeport();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        
        /// <summary>
        /// Инициализация принтера для печати SSCC и SGTIN
        /// </summary>
        /// <param name="width">Ширина этикетки</param>
        /// <param name="height">Высота этикетки</param>
        /// <returns>true - если принтер подключён, иначе false</returns>
        public static bool Init_printer(int width, int height)
        {
            if (!FileExist())
            {
                return false;
            }
            Settings printer_set = GetSettings();

            if (!Printer_status(printer_set))
            {
                return false;
            }

            driver driver = new driver();
            string size = "SIZE " + width + " mm, " + height + " mm";
            string speed = "SPEED " + printer_set.Speed;
            string density = "DENSITY " + printer_set.Density;

            driver.openport(printer_set.PrinterName);
            driver.sendcommand(size); //the size of a paper in the printer
            driver.sendcommand("GAP 2 mm, 0");
            driver.sendcommand(speed);
            driver.sendcommand(density);
            driver.sendcommand("DIRECTION 1");

            if (printer_set.PrinterMode == "Режим смотчика")
            {
                driver.sendcommand("SET TEAR OFF");
                driver.sendcommand("SET REWIND ON");
            }
            else
            {
                driver.sendcommand("SET REWIND OFF");
                driver.sendcommand("SET TEAR ON");
            }

            driver.sendcommand("CODEPAGE UTF-8");
            driver.clearbuffer();
            driver.sendcommand("FORMFEED");

            return true;
        }

        /// <summary>
        /// Инициализация принтера для печати GS128
        /// </summary>
        /// <param name="width">Ширина этикетки</param>
        /// <param name="height">Высота этикетки</param>
        /// <returns>true - если принтер подключён, иначе false</returns>
        public static bool Init_printer_GS128(int width, int height)
        {
            if (!FileExist())
            {
                return false;
            }
            Settings printer_set = GetSettings();

            if (!Printer_status(printer_set))
            {
                return false;
            }

            driver driver = new driver();
            string size = "SIZE " + width + " mm, " + height + " mm";

            driver.openport(printer_set.PrinterName);
            driver.sendcommand(size); //the size of a paper in the printer
            driver.sendcommand("GAP 2 mm, 0");
            driver.sendcommand("SPEED 2");
            driver.sendcommand("DENSITY 15");
            driver.sendcommand("DIRECTION 1");
            driver.sendcommand("SET REWIND OFF");
            driver.sendcommand("SET TEAR ON"); 
            driver.sendcommand("CODEPAGE UTF-8");
            driver.clearbuffer();
            driver.sendcommand("FORMFEED");

            return true;
        }


        /// <summary>
        /// Проверка размера этикетки в принтере по Ethernet
        /// </summary>
        /// <param name="height">Высота этикетки, которая задана пользователем (из XML файла)</param>
        /// <returns>true-размер этикетки в принтере совпадает с заданной, иначе false</returns>
        private static bool CheckLabelSizeEthernet(int height)
        {
            ethernet ethernet = new ethernet();
            Settings cur_settings = TscHelper.GetSettings();
            string IP = TscHelper.GetPrinterIP(cur_settings);
            int PortNumber = TscHelper.GetPrinter_PortNumber(IP);

            ethernet.openport(IP, PortNumber);
            
            if(ethernet.printerstatus()!=99)
            {
                ethernet.sendcommand("AUTODETECT");
                Thread.Sleep(4000);
                int printer_height = Convert.ToInt32(ethernet.sendcommand_getstring("OUT NET \"\"; GETSETTING$(\"CONFIG\", \"TSPL\", \"PAPER SIZE\")"));

                if (printer_height <= (height * 11.8) && printer_height >= ((height * 11.8) - 20))
                {
                    int dot = height * 12;
                    //ethernet.sendcommand($"BACKFEED {dot}");
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
            usb.sendcommand("AUTODETECT");
            Thread.Sleep(10000);
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
            Settings cur_settings = TscHelper.GetSettings();
            string IP = TscHelper.GetPrinterIP(cur_settings);
            int PortNumber = TscHelper.GetPrinter_PortNumber(IP);

            if (PortNumber == 0) return CheckLabelSizeUSB(height);
            else return CheckLabelSizeEthernet(height);
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width * 11, height * 11);
            var destImage = new Bitmap(width * 11, height * 11);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        /// <summary>
        /// Печать файла формата Bitmap на этикетке
        /// </summary>
        /// <param name="bitmap">Картинка в формате Bitmap</param>
        public static void PrintPicture(Bitmap bitmap)
        {
            driver driver = new driver();

            driver.send_bitmap(0, 40, bitmap);
            driver.printlabel("1", "1");
            driver.closeport();
        }

        //Just for empty labels
        public static void FakePrinting()
        {
            driver driver = new driver();

            for(int i=1;i<8;i++)
                driver.printlabel("1", "1");
            driver.closeport();

            ProgressForm progress = new ProgressForm();
            progress.ShowDialog();
        }

        /// <summary>
        /// Метод для выявлении ошибок при печати штрихкода GS128
        /// </summary>
        /// <param name="bitmap">Объект Bitmap</param>
        /// <returns>Объект класса ResponseData</returns>
        public static ResponseData CheckGS128(Bitmap bitmap)
        {
            Settings settings = GetSettings();
            ResponseData response = new ResponseData();
            if (!FileExist() || settings == null)
            {
                response.ErrorMessage = "Файл не найден";
                return response;
            }
            if (settings.Gs128Size == null)
            {
                response.ErrorMessage = "Данные в файле повреждены";
                return response;
            }
            else if (settings.Gs128Size.Width == 0 || settings.Gs128Size.Height == 0)
            {
                response.ErrorMessage = "Данные в файле повреждены";
                return response;
            }
            if (!Printer_status(settings))
            {
                response.ErrorMessage = "Принтер не подключен";
                return response;
            }

            Init_printer_GS128(settings.Gs128Size.Width, settings.Gs128Size.Height);
            Bitmap gs128 = ResizeImage(bitmap, settings.Gs128Size.Width, settings.Gs128Size.Height);

            if (PrinterConnection(settings.Gs128Size.Height))
            {
                PrintPicture(gs128);
                response.IsSuccess = true;
            }
            else
            {
                response.ErrorMessage = "Размер этикетки в принтере не соответвует выбранному";
            }
            return response;
        }


        /// <summary>
        /// Печать SGTIN-ов в форме datamatrix
        /// </summary>
        /// <param name="sgtins">Список SGTIN-ов</param>
        public static void PrintSgtins(int width, int height, List<string> sgtins)
        {
            driver driver = new driver();
            driver.clearbuffer();
            List<Bitmap> list_of_datamatrix = new List<Bitmap>();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = { Width = height * 9, Height = height * 9, Margin = 10 } //the size of a datamatrix
            };

            foreach (string str in sgtins)
            {
                list_of_datamatrix.Add(writer.Write(str));
            }

            int k = 0;//the number of SGTIN
            int y = (height * 10) / 2;// the y position
            int x = height * 9 + 10;//the x position
            int multisize = width / height; 

            foreach (Bitmap bitmap in list_of_datamatrix)
            {
                string gtin = sgtins[k].Substring(2, 14);//get gtin from sgtin
                string sn = sgtins[k].Substring(18, 13);// get serial number from sgtin
                
                driver.sendcommand($"TEXT {x}, {y}, \"3\",0 , {multisize}, {multisize}, \"{gtin}\"");//send text
                y += height + 5;
                driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"{sn}\"");
                y += 50;
                driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"2927\"");

                driver.send_bitmap(0, (height * 11 - height * 9), bitmap);
                k++;
                y = (height * 10) / 2;

                driver.printlabel("1", "1");
                driver.clearbuffer();
                //break;//delete (only for printing one label)
            }
            driver.closeport();

            ProgressForm progress = new ProgressForm();
            progress.ShowDialog();
        }
        /// <summary>
        /// Печать SSCC в форме штрихкодов
        /// </summary>
        /// <param name="driver">Объект класса TSCSDK.driver</param>
        /// <param name="sscc">Список SSCC</param>
        public static ResponseData PrintSscc(int width, int height, List<string> sscc)
        {
            ResponseData response = new ResponseData();
            if(sscc.Count==0)
            {
                response.ErrorMessage = "SSCC не обнаружено";
                return response;
            }

            driver driver = new driver();
            List<Bitmap> list_of_barcodes = new List<Bitmap>();

            FontFamily fontFamily = new FontFamily("Arial");//a font for the label under a barcode

            var writer = new BarcodeWriter//generation a barcode
            {
                Renderer = new BitmapRenderer
                {
                    TextFont = new Font(fontFamily, width - height + 2)
                },
                Format = BarcodeFormat.CODE_128,
                Options = { Width = width * 11, Height = height * 8, Margin = 10 } //the size of a barcode               
            };

            foreach (string str in sscc)
            {
                list_of_barcodes.Add(writer.Write(str));//save a barcode in the list
            }

            foreach (Bitmap bitmap in list_of_barcodes)
            {
                driver.send_bitmap(0, (height * 12) / 4, bitmap);//print a barcode             
                driver.printlabel("1", "1");
                driver.clearbuffer();
                //break;//delete (only for printing one label)
            }
            driver.closeport();

            ProgressForm progress = new ProgressForm();
            progress.ShowDialog();

            response.IsSuccess = true;
            return response;
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
            string query = string.Format($"SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);

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