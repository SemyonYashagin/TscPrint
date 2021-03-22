using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using TscDll.Entities;
using TscDll.Forms;
using TSCSDK;
using ZXing;

namespace TscDll.Helpers
{
    public class SgtinHelper
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
        //public static void PrintSgtins(int width, int height, Dictionary<string, List<string>> sgtinsList)
        //{
        //    driver driver = new driver();
        //    driver.clearbuffer();

        //    int y = (height * 9) / 2;// the y position
        //    int x = height * 9 + 10;//the x position
        //    int multisize = width / height;

        //    var writer = new BarcodeWriter
        //    {
        //        Format = BarcodeFormat.DATA_MATRIX,
        //        Options = { Width = height * 9, Height = height * 9, Margin = 10 } //the size of a datamatrix
        //    };

        //    foreach(KeyValuePair<string, List<string>> sgtins in sgtinsList)
        //    {
        //        string number = sgtins.Key;
        //        int index = sgtins.Key.IndexOf('|');//for separating the unique number of the sscc and partyID
        //        string uniqueNum = sgtins.Key.Remove(index);
        //        string partyId = sgtins.Key.Remove(0, index + 1);
        //        foreach(string sgtin in sgtins.Value)
        //        {
        //            string gtin = sgtin.Substring(2, 14);//get gtin from sgtin
        //            string sn = sgtin.Substring(18, 13);// get serial number from sgtin

        //            driver.sendcommand($"TEXT {x+10}, {y}, \"4\", 0, {multisize}, {multisize}, \"{uniqueNum}\"");
        //            driver.sendcommand($"BOX {x},{y - 10},{width * 11},{height * 6},5");// the rectangle around uniqueNum
        //            y += 50;
        //            driver.sendcommand($"TEXT {x + 10}, {y}, \"4\", 0, {multisize}, {multisize}, \"{partyId}\"");
        //            driver.sendcommand($"BOX {x},{y - 10},{width * 11},{height * 6},5");// was 470,150; the rectangle around partyID
        //            y += 50;
        //            driver.sendcommand($"TEXT {x}, {y}, \"3\",0 , {multisize}, {multisize}, \"{gtin}\"");//send text
        //            y += height + 5;
        //            driver.sendcommand($"TEXT {x}, {y}, \"3\", 0, {multisize}, {multisize}, \"{sn}\"");
        //            driver.send_bitmap(0, (height * 11 - height * 9), writer.Write(sgtin));// print datamatrix                    
        //            y = (height * 9) / 2;

        //            driver.printlabel("1", "1");
        //            driver.clearbuffer();
        //        }
        //    }
        //    driver.closeport();

        //    //ProgressForm progress = new ProgressForm();
        //    //progress.ShowDialog();
        //}

        public static void CreateSgtinBitmap(int width, int height, Dictionary<string, List<string>> sgtinsList)
        {
            driver driver = new driver();
            driver.clearbuffer();
            int w = 1100;
            int h = 550;
            Bitmap datamatrix = new Bitmap(w, h);

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = { Width = 450, Height = 450, Margin = 10 } //the size of a datamatrix
            };
            
           
            Graphics g = Graphics.FromImage(datamatrix);
            g.Clear(Color.White);

            PointF point = new PointF(460, 60 + 75);
            PointF pointParty = new PointF(460, 150 + 75);
            Point pointGtin = new Point(460, 250 + 75);
            Point pointSN = new Point(460, 330 + 75);

            Font font = new Font("Arial", 72, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font fontSgtin = new Font("Arial", 55);

            Pen skyBluePen = new Pen(Brushes.Black)
            {
                Width = 8.0F,
                LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel
            };

            //g.CompositingMode = CompositingMode.SourceCopy;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            
            foreach (KeyValuePair<string, List<string>> sgtins in sgtinsList)
            {
                string number = sgtins.Key;
                int index = sgtins.Key.IndexOf('|');//for separating the unique number of the sscc and partyID
                string uniqueNum = sgtins.Key.Remove(index);
                string partyId = sgtins.Key.Remove(0, index + 1);
                foreach (string sgtin in sgtins.Value)
                {
                    g.DrawRectangle(skyBluePen,
                new Rectangle(460, 50 + 75, 600, 200));
                    g.DrawString(uniqueNum, font, drawBrush, point);//the code of a box (sscc)
                    g.DrawString(partyId, font, drawBrush, pointParty);//party
                    string gtin = sgtin.Substring(2, 14);//get gtin from sgtin
                    string sn = sgtin.Substring(18, 13);// get serial number from sgtin
                    g.DrawString(gtin, fontSgtin, drawBrush, pointGtin);//gtin
                    g.DrawString(sn, fontSgtin, drawBrush, pointSN);//sn
                    g.DrawImage(writer.Write(sgtin), 0, 75);

                    if (width != 100 && height != 50)
                    {
                        var destRect = new Rectangle(0, 0, width * 11, height * 11);
                        var destImage = new Bitmap(width * 11, height * 11);

                        using (var graphics = Graphics.FromImage(destImage))
                        {
                            using (var wrapMode = new ImageAttributes())
                            {
                                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                                graphics.DrawImage(datamatrix, destRect, 0, 0, datamatrix.Width, datamatrix.Height, GraphicsUnit.Pixel, wrapMode);
                            }
                        }
                        destImage.SetResolution(300, 300);
                        driver.send_bitmap(0, 0, destImage);
                    }
                    else
                    {
                        datamatrix.SetResolution(300, 300);
                        driver.send_bitmap(0, 0, datamatrix);// print datamatrix     
                    }                                  

                    driver.printlabel("1", "1");
                    driver.clearbuffer();
                }
                g.Clear(Color.White);
            }

            driver.closeport();            
            g.Dispose();
            skyBluePen.Dispose();
            
            //ProgressForm progress = new ProgressForm();
            //progress.ShowDialog();
        }
    }
}
