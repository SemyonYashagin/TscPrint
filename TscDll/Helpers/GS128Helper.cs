using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using TscDll.Entities;
using TSCSDK;

namespace TscDll.Helpers
{
    class GS128Helper
    {
        /// <summary>
        /// Инициализация принтера для печати GS128
        /// </summary>
        /// <param name="width">Ширина этикетки</param>
        /// <param name="height">Высота этикетки</param>
        /// <returns>true - если принтер подключён, иначе false</returns>
        public static bool Init_printer_GS128(int width, int height)
        {
            if (!XMLHelper.FileExist())
            {
                return false;
            }
            Settings printer_set = XMLHelper.GetSettings();

            if (!TscHelper.Printer_status(printer_set))
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
        /// Печать GS128 формата Bitmap на этикетке горизонтально
        /// </summary>
        /// <param name="gs128">GS128 в формате Bitmap</param>
        public static void PrintPictureHorizontally(Bitmap gs128)
        {
            driver driver = new driver();

            driver.send_bitmap(0, 40, gs128);
            driver.printlabel("1", "1");
            driver.closeport();
        }

        /// <summary>
        /// Метод для выявлении ошибок при печати штрихкода GS128
        /// </summary>
        /// <param name="bitmap">Объект Bitmap</param>
        /// <returns>Объект класса ResponseData</returns>
        public static ResponseData CheckGS128(Bitmap bitmap)
        {
            Settings settings = XMLHelper.GetSettings();
            ResponseData response = new ResponseData();
            if (!XMLHelper.FileExist() || settings == null)
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
            if (!TscHelper.Printer_status(settings))
            {
                response.ErrorMessage = "Принтер не подключен";
                return response;
            }

            Init_printer_GS128(settings.Gs128Size.Width, settings.Gs128Size.Height);
            Bitmap gs128 = ResizeImage(bitmap, settings.Gs128Size.Width, settings.Gs128Size.Height);
            PrintPictureHorizontally(gs128);
            response.IsSuccess = true;
            return response;
        }

        /// <summary>
        /// Метод для изменения размера GS128 для печати на конкретной этикетке
        /// </summary>
        /// <param name="gs128">GS128 в формате Bitmap</param>
        /// <param name="width">Конечная ширина</param>
        /// <param name="height">Конечная высота</param>
        /// <returns>Измененный GS128 в формате Bitmap</returns>
        public static Bitmap ResizeImage(Bitmap gs128, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width * 11, height * 11);
            var destImage = new Bitmap(width * 11, height * 11);

            if (width < height)
            {
                destRect = new Rectangle(0, 0, height * 11, width * 11);
                destImage = new Bitmap(height * 11, width * 11);
            }

            destImage.SetResolution(gs128.HorizontalResolution, gs128.VerticalResolution);

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
                    graphics.DrawImage(gs128, destRect, 0, 0, gs128.Width, gs128.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            if (width < height)
                destImage.RotateFlip(RotateFlipType.Rotate90FlipNone);

            return destImage;
        }
    }
}
