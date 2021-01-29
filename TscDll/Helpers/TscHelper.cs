using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ZXing;
using TSCSDK;
using TscDll.Entities;
using System;
using TscDll.Extensions;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
            if (FileExist())
            {
                driver driver = new driver();
                
                if (driver.driver_status(settings.PrinterName))
                {
                    return true;
                }  
            }
            return false;            
        }
        /// <summary>
        /// Инициализация принтера
        /// </summary>
        public static bool Init_printer(int width, int height)
        {
            if (!Helpers.TscHelper.FileExist())
            {
                return false;
            }
            Settings printer_set = TscHelper.GetSettings();

            if (!TscHelper.Printer_status(printer_set))
            {
                return false;
            }

            TSCSDK.driver driver = new TSCSDK.driver();
            string size = "SIZE " + width + " mm, " + height + " mm";
            string speed = "SPEED " + printer_set.Speed;
            string density = "DENSITY " + printer_set.Density;

            driver.openport(printer_set.PrinterName);
            driver.sendcommand(size); //the size of a paper in the printer
            driver.sendcommand("GAP 2 mm, 0");
            driver.sendcommand(speed);
            driver.sendcommand(density);
            driver.sendcommand("DIRECTION 1");
            driver.sendcommand("SET TEAR ON");
            driver.sendcommand("CODEPAGE UTF-8");
            driver.clearbuffer();

            return true;
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
            
            driver.send_bitmap(0, 20, bitmap);
            driver.printlabel("1", "1");
            driver.closeport();
        }

        /// <summary>
        /// Печать SGTIN-ов в форме datamatrix
        /// </summary>
        /// <param name="sgtins">Список SGTIN-ов</param>
        public static void PrintSgtins(int width, int height, List<string> sgtins)
        {
            driver driver = new driver();

            List<Bitmap> list_of_datamatrix = new List<Bitmap>();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = { Width = height * 9, Height = height * 9, Margin = 4 } //the size of a datamatrix
            };

            foreach (string str in sgtins)
            {
                list_of_datamatrix.Add(writer.Write(str));
            }

            int k = 0;//the number of SGTIN
            int y = (height * 10) / 2;// the first position
            foreach (Bitmap bitmap in list_of_datamatrix)
            {
                driver.windowsfont(height * 9 + 10, y, 30, 0, 0, 0, "arial.TTF", sgtins[k].Substring(2, 14));// print GTIN
                y += 25;
                driver.windowsfont(height * 9 + 10, y, 30, 0, 0, 0, "arial.TTF", sgtins[k].Substring(18, 13)); //print serial number
                y += 50;
                driver.windowsfont(height * 9 + 10, y, 72, 0, 0, 0, "arial.TTF", "2927");// print the number which connect to SSCC code

                //driver.send_bitmap(5, (height*11 - height*9) , bitmap);//print a datamatrix
                driver.send_bitmap(0, (height * 11 - height * 9), bitmap);
                k++;
                y = 0;

                driver.printlabel("1", "1");
                driver.clearbuffer();
                break;//delete (only for printing one label)
            }
            driver.closeport();
        }
        /// <summary>
        /// Печать SSCC в форме штрихкодов
        /// </summary>
        /// <param name="driver">Объект класса TSCSDK.driver</param>
        /// <param name="sscc">Список SSCC</param>
        public static void PrintSscc(int width, int height, List<string> sscc)
        {
            driver driver = new driver();
            List<Bitmap> list_of_barcodes = new List<Bitmap>();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = { Width = width * 11, Height = height * 8 } //the size of a barcode
            };

            foreach (string str in sscc)
            {
                list_of_barcodes.Add(writer.Write(str));
            }

            foreach (Bitmap bitmap in list_of_barcodes)
            {
                driver.send_bitmap(0, (height*12)/4, bitmap);//print a barcode             
                driver.printlabel("1", "1");
                driver.clearbuffer();
                break;//delete (only for printing one label)
            }
            driver.closeport();
        }
    }
}
