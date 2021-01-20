using System.Collections.Generic;
using System.Drawing;
using ZXing;

namespace TscDll.Helpers
{
    /// <summary>
    /// Класс для генерации datamatrix'ов и штрихкодов
    /// </summary>
    public class BarcodeHelper
    {
        /// <summary>
        /// Метод для генерации типа string (SGTIN'ов) в datamatrix (тип Bitmap)
        /// </summary>
        /// <param name="numbers_data">массив SGTIN'ов</param>
        /// <returns></returns>
        public static List<Bitmap> Generate2dDatamatrix(List<string> numbers_data)
        {
            List<Bitmap> list_of_datamatrix = new List<Bitmap>();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = { Width = 150, Height = 150, Margin = 4 } //the size of a datamatrix
            };

            int index = 0;
            foreach (string str in numbers_data)
            {
                list_of_datamatrix.Add(writer.Write(str));
                index++;
            }
            return list_of_datamatrix;
        }

        public static Image GenerateBarcode(string code)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = { Width = 600, Height = 200 } //the size of a datamatrix
            };

            Bitmap barcode = new Bitmap(writer.Write(code));
            return barcode;
        }
    }
}
