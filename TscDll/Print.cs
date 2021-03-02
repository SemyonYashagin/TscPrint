using System.Collections.Generic;
using System.Drawing;
using TscDll.Entities;
using TscDll.Forms;

namespace TscDll
{
    public class Print
    {
        /// <summary>
        /// Метод для печати SGTIN-ов
        /// </summary>
        /// <param name="markPrintUnits">Объекты для печати</param>
        /// <returns></returns>
        public static ResponseData PrintSgtinSscc(List<MarkPrintUnit> markPrintUnits)
        {
            ResponseData response = new ResponseData();

            Main_form main = new Main_form();
            main.Activate();
            main.InputToGV(markPrintUnits);
            main.ShowDialog();

            return response;
        }

        /// <summary>
        /// Распечатывает штрихкод GS128 
        /// </summary>
        /// <param name="bitmap">Объект Bitmap</param>
        public static void PrintGS128(Bitmap bitmap)
        {
            PrintGS128_Form print = new PrintGS128_Form();
            print.Activate();
            print.GetBitmap(bitmap);
            print.ShowDialog();
        }
    }
}