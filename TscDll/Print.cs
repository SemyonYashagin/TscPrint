using System.Collections.Generic;
using TscDll.Entities;

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

    }
}
