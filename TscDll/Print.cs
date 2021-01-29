using System.Collections.Generic;
using System.Drawing;
using TscDll.Entities;
using TscDll.Helpers;


namespace TscDll
{
    public class Print
    {
        /// <summary>
        /// Метод для печати SGTIN-ов
        /// </summary>
        /// <param name="markPrintUnits">Объекты для печати</param>
        /// <returns></returns>
        public ResponseData PrintSgtinSscc(List<MarkPrintUnit> markPrintUnits)
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
            Settings settings = TscHelper.GetSettings();
            ResponseData response = new ResponseData();
            TscHelper.Init_printer(settings.SsccSize.Width, settings.SsccSize.Height);
            Bitmap gs128 = TscHelper.ResizeImage(bitmap, settings.SsccSize.Width, settings.SsccSize.Height);
            TscHelper.PrintPicture(gs128);
            return response;
        }
    }
}
