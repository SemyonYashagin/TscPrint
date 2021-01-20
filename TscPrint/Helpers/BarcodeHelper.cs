using System.Collections.Generic;
using System.Drawing;
using ZXing;
using ZXing.Presentation;

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
        public static List<Bitmap> Generate2dDatamatrix(string[] numbers_data)
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
                //list_of_datamatrix.Add(writer.Write(str));
                index++;
            }

            /* // for checking images (datamatrixes) in list
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                index = 0;
                foreach (var image in list_of_datamatrix)
                { 
                    image.Save(string.Format("{0}\\Image{1}.png", dialog.SelectedPath, index), System.Drawing.Imaging.ImageFormat.Png);
                    index++;
                }
            }
            */
            //driver.sendcommand("DMATRIX 100,110,600,600,\"pivovar\""); // very easy alternative way to create datamatrix
            return list_of_datamatrix;
        }

        public static Image GenerateBarcode(string code)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = { Width = 600, Height = 200 } //the size of a datamatrix
            };

            //Bitmap barcode = new Bitmap(writer.Write(code));
            //return barcode;
            return null;
        }
    }
}
