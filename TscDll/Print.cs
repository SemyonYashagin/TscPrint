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

            Forms.Main_form main = new Forms.Main_form();
            main.Activate();
            main.InputToGV(markPrintUnits);
            main.ShowDialog();

            return response;
        }
        /// <summary>
        /// Распечатывает штрихкод GS128 
        /// </summary>
        /// <param name="bitmap">Объект Bitmap</param>
        /// <returns></returns>
        public static ResponseData PrintGS128(System.Drawing.Bitmap bitmap)
        {
            int width = 100;
            int height = 50;
            ResponseData response = new ResponseData();
            TscHelper.Init_printer(width, height);
            //TscHelper.PrintPicture(TscHelper.ResizeBitmap(bitmap, width, height));
            Bitmap gs128 = TscHelper.ResizeImage(bitmap, width, height);
            TscHelper.PrintPicture(gs128);
            return response;
        }
    }
}
