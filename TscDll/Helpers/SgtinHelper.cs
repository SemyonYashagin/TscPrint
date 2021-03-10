using System.Collections.Generic;
using System.Drawing;
using TscDll.Entities;
using TscDll.Forms;
using TSCSDK;
using ZXing;

namespace TscDll.Helpers
{
    class SgtinHelper
    {
        /// <summary>
        /// Инициализация принтера для печати SSCC и SGTIN
        /// </summary>
        /// <param name="width">Ширина этикетки</param>
        /// <param name="height">Высота этикетки</param>
        /// <returns>true - если принтер подключён, иначе false</returns>
        public static bool Init_printer(int width, int height)
        {
            if (!XMLHelper.FileExist())
            {
                return false;
            }
            Settings printer_set = XMLHelper.GetSettings();

            if (!TscHelper.Printer_status())
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

            driver.sendcommand("FORMFEED");
            driver.sendcommand("CODEPAGE UTF-8");
            driver.clearbuffer();

            return true;
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
                //string gtin = sgtins[k].Substring(2, 14);//get gtin from sgtin
                //string sn = sgtins[k].Substring(18, 13);// get serial number from sgtin

                //driver.sendcommand($"TEXT {x}, {y}, \"3\",0 , {multisize}, {multisize}, \"{gtin}\"");//send text
                //y += height + 5;
                //driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"{sn}\"");
                //y += 50;
                //driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"2927\"");

                //driver.send_bitmap(0, (height * 11 - height * 9), bitmap);
                //k++;
                //y = (height * 10) / 2;

                //driver.printlabel("1", "1");
                //driver.clearbuffer();


                driver.sendcommand($"TEXT {x}, {y}, \"3\",0 , {multisize}, {multisize}, \"\"");//send text
                y += height + 5;
                driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"\"");
                y += 50;
                driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"\"");

                k++;
                y = (height * 10) / 2;

                driver.printlabel("1", "1");
                driver.clearbuffer();
            }

            driver.closeport();

            ProgressForm progress = new ProgressForm();
            progress.ShowDialog();
        }

    }
}
