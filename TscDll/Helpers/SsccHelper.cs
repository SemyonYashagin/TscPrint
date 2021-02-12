using System.Collections.Generic;
using System.Drawing;
using TscDll.Entities;
using TscDll.Forms;
using TSCSDK;
using ZXing;
using ZXing.Rendering;

namespace TscDll.Helpers
{
    class SsccHelper
    {
        /// <summary>
        /// Печать SSCC в форме штрихкодов
        /// </summary>
        /// <param name="driver">Объект класса TSCSDK.driver</param>
        /// <param name="sscc">Список SSCC</param>
        public static ResponseData PrintSscc(int width, int height, List<string> sscc)
        {
            ResponseData response = new ResponseData();
            if (sscc.Count == 0)
            {
                response.ErrorMessage = "SSCC не обнаружено";
                return response;
            }

            driver driver = new driver();
            List<Bitmap> list_of_barcodes = new List<Bitmap>();

            FontFamily fontFamily = new FontFamily("Arial");//a font for the label under a barcode

            var writer = new BarcodeWriter//generation a barcode
            {
                Renderer = new BitmapRenderer
                {
                    TextFont = new Font(fontFamily, width - height + 2)
                },
                Format = BarcodeFormat.CODE_128,
                Options = { Width = width * 11, Height = height * 8, Margin = 10 } //the size of a barcode               
            };

            foreach (string str in sscc)
            {
                list_of_barcodes.Add(writer.Write(str));//save a barcode in the list
            }

            foreach (Bitmap bitmap in list_of_barcodes)
            {
                driver.send_bitmap(0, (height * 12) / 4, bitmap);//print a barcode             
                driver.printlabel("1", "1");
                driver.clearbuffer();
            }
            driver.closeport();

            ProgressForm progress = new ProgressForm();
            progress.ShowDialog();

            response.IsSuccess = true;
            return response;
        }
    }
}
