using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;
using TSCSDK;


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
        public static ResponseData PrintGS128(Bitmap bitmap)
        { 
            Settings settings = TscHelper.GetSettings();
            ResponseData response = new ResponseData();
            if (!TscHelper.FileExist() || settings == null)
            {
                response.ErrorMessage = "Файл не найден";
                return response;
            }
            if (settings.SsccSize == null)
            {
                response.ErrorMessage = "Данные в файле повреждены";
                return response;
            }
            else if (settings.SsccSize.Width == 0 || settings.SsccSize.Height == 0)
            {
                response.ErrorMessage = "Данные в файле повреждены";
                return response;
            }
            if(!TscHelper.Printer_status(settings))
            {
                response.ErrorMessage = "Принтер не подключен";
                return response;
            }    

            TscHelper.Init_printer(settings.SsccSize.Width, settings.SsccSize.Height);
            Bitmap gs128 = TscHelper.ResizeImage(bitmap, settings.SsccSize.Width, settings.SsccSize.Height);
            TscHelper.PrintPicture(gs128);
            response.IsSuccess = true;
            return response;         
        }
    }
}
