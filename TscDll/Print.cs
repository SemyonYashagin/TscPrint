using System.Collections.Generic;
using System.Drawing;
using TscDll.Entities;
using TscDll.Helpers;


namespace TscDll
{
    public class Print
    {
        public Print()
        {
        }

        /// <summary>
        /// Метод для печати SGTIN-ов
        /// </summary>
        /// <param name="markPrintUnits">Объекты для печати</param>
        /// <returns></returns>
        public static ResponseData PrintSgtinSscc(List<MarkPrintUnit> markPrintUnits)
        {
            ResponseData response = new ResponseData();






            return response;
        }

        public static ResponseData PrintGS128(System.Drawing.Bitmap bitmap)
        {
            int width = 100;
            int height = 50;
            ResponseData response = new ResponseData();
            TscHelper.Init_printer(width, height);
            //TscHelper.PrintPicture(TscHelper.ResizeBitmap(bitmap, width, height));
            TscHelper.PrintPicture(TscHelper.ResizeImage(bitmap, width, height));
            return response;
        }
    }
}
