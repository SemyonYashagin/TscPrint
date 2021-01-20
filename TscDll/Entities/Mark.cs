using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace TscDll.Entities
{
    internal class Mark
    {
        /// <summary>
        /// Метод для генерации картинки с SSCC штрихкодом
        /// </summary>
        /// <param name="barcode">Изображение штрихкода</param>
        /// <returns>Возвращает Bitmap</returns>
        public Bitmap Generate_SSCC(Image barcode)
        {
            Bitmap photo = new Bitmap(1200, 600, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);// the full resolution is 1200x600

            RectangleF rect_Title = new RectangleF(0, 0, 1200, 100);//for the title
            RectangleF rect_Infomation = new RectangleF(0, 100, 1200, 200);//for extra information like дата изготовления, срок годности, масса и т.д.
            RectangleF rect_Barcode = new RectangleF(0, 300, 1200, 150);// for the barcode

            StringFormat format_center = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            };

            Graphics graphics = Graphics.FromImage(photo);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);//has changed the background color to a white
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            graphics.DrawString("СМЕТАНА\r\nмассовая доля жира 15%\r\nТУ", new Font("Times New Roman", 20), Brushes.Black, rect_Title, format_center);
            graphics.DrawString("Дата изготовления (число, месяц, год) " + DateTime.Now, new Font("Times New Roman", 20), Brushes.Black, rect_Infomation);
            //graphics.DrawString("0000000000000", new Font("Times New Roman", 48), Brushes.Black, rect_Barcode);
            graphics.DrawImage(barcode, rect_Barcode);
            graphics.Flush();

            photo.Save("draw.jpg");
            return photo;
        }
    }
}
