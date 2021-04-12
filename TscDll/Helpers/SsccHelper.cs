using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using TscDll.Entities;
using TscDll.Forms;
using TSCSDK;
using ZXing;
using ZXing.Rendering;

namespace TscDll.Helpers
{
    class SsccHelper
    {
        /// <summary>
        /// Метод генерирует Bitmap изображение размером 100*50 мм, и затем сжимает его под нужный размер этикетки с использованием List of Tuple
        /// </summary>
        /// <param name="width">Требуемая ширина этикетки</param>
        /// <param name="height">Требуемая высота этикетки</param>
        /// <param name="ssccList">Список кортежей sgtin-ов в формате "parentID+ID+PartyID - список sgtin-ов"</param>
        public static void PrintSsccs(int width, int height, List<Tuple<string, string>> ssccList)
        {
            driver driver = new driver();
            driver.clearbuffer();
            int w = 1100;
            int h = 550;
            Bitmap barcode = new Bitmap(w, h);

            FontFamily fontFamily = new FontFamily("Arial");//a font for the label under a barcode

            var writer = new BarcodeWriter//generation a barcode
            {
                Renderer = new BitmapRenderer
                {
                    TextFont = new Font(fontFamily, 56, FontStyle.Bold)
                },
                Format = BarcodeFormat.CODE_128,
                Options = { Width = 1100, Height = 400, Margin = 10 } //the size of a barcode               
            };

            Graphics g = Graphics.FromImage(barcode);
            g.Clear(Color.White);

            Font font = new Font("Arial", 72, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            Pen skyBluePen = new Pen(Brushes.Black)
            {
                Width = 8.0F,
                LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel
            };

            g.CompositingQuality = CompositingQuality.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            foreach (Tuple<string, string> sscc in ssccList)
            {
                string number = sscc.Item1;

                g.DrawRectangle(skyBluePen,
            new Rectangle(10, 10, 1080, 120));// draw the rectangle aroun id and parentID

                StringFormat stringFormat = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(number, font, drawBrush, new RectangleF(10, 10, 1080, 120),stringFormat);//id and parentID                                                
                g.DrawImage(writer.Write(sscc.Item2), 0, 150);//barcode

                if (width != 100 && height != 50)
                {
                    var destRect = new Rectangle(0, 0, width * 11, height * 11);
                    var destImage = new Bitmap(width * 11, height * 11);

                    using (var graphics = Graphics.FromImage(destImage))
                    {
                        using (var wrapMode = new ImageAttributes())
                        {
                            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                            graphics.DrawImage(barcode, destRect, 0, 0, barcode.Width, barcode.Height, GraphicsUnit.Pixel, wrapMode);
                        }
                    }
                    destImage.SetResolution(300, 300);
                    driver.send_bitmap(0, 0, destImage);
                }
                else
                {
                    barcode.SetResolution(300, 300);
                    driver.send_bitmap(0, 0, barcode);// print datamatrix     
                }

                driver.printlabel("1", "1");
                driver.clearbuffer();
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
