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
        /// Печать SSCC в форме штрихкодов
        /// </summary>
        /// <param name="driver">Объект класса TSCSDK.driver</param>
        /// <param name="sscc">Список SSCC</param>
        public static ResponseData PrintSscc(int width, int height, Dictionary<string, string> ssccList)
        {
            ResponseData response = new ResponseData();
            if (ssccList.Count == 0)
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
                    TextFont = new Font(fontFamily, width - height + 2, FontStyle.Bold)
                },
                Format = BarcodeFormat.CODE_128,
                Options = { Width = width * 11, Height = height * 8, Margin = 10 } //the size of a barcode               
            };

            int y = (height * 9) / 2;// the y position
            int x = height * 9 + 10;//the x position
            int multisize = width / height;

            foreach (KeyValuePair<string, string> sscc in ssccList)
            {
                string number = sscc.Key;
                driver.sendcommand($"TEXT {(width * 12) / 4}, 20, \"4\", 0, {multisize}, {multisize}, \"{number}\"");
                driver.sendcommand($"BOX {((width * 12) / 4) - 10}, 10,{(width * 12 * 3) / 4},{((height * 11) / 5) + 10},5");// the rectangle around uniqueNum
                driver.send_bitmap(0, (height * 12) / 4, writer.Write(sscc.Value));//print a barcode             
                driver.printlabel("1", "1");
                driver.clearbuffer();
            }
            driver.closeport();

            //ProgressForm progress = new ProgressForm();
            //progress.ShowDialog();

            response.IsSuccess = true;
            return response;
        }

        public static void CreateSsccBitmap(int width, int height, Dictionary<string, string> ssccList)
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

            PointF point = new PointF(300, 15);//for number

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

            foreach (KeyValuePair<string, string> sscc in ssccList)
            {
                string number = sscc.Key;

                g.DrawRectangle(skyBluePen,
            new Rectangle(200, 10, 700, 120));
                g.DrawString(number, font, drawBrush, point);//the code of a box (sscc)                    
                g.DrawImage(writer.Write(sscc.Value), 0, 150);//barcode

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
