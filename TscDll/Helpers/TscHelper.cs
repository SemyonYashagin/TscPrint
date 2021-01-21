using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using ZXing;

namespace TscDll.Helpers
{
    public class TscHelper
    {
        public static void Init_printer()
        {
            TSCSDK.driver driver = new TSCSDK.driver();
            
            driver.openport("TSC MH240");
            driver.sendcommand("SIZE 43 mm, 25 mm"); //the size of a paper in the printer
            driver.sendcommand("GAP 2 mm, 0");
            driver.sendcommand("SPEED 4");
            driver.sendcommand("DENSITY 12");
            driver.sendcommand("DIRECTION 1");
            driver.sendcommand("SET TEAR ON");
            driver.sendcommand("CODEPAGE UTF-8");

            driver.clearbuffer();
            driver.printlabel("1", "1");
            driver.closeport();
        }

        public static void PrintSgtins(TSCSDK.driver driver, List<string> sgtins)
        {
            List<Bitmap> list_of_datamatrix = new List<Bitmap>();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.DATA_MATRIX,
                Options = { Width = 150, Height = 150, Margin = 4 } //the size of a datamatrix
            };

            foreach (string str in sgtins)
            {
                list_of_datamatrix.Add(writer.Write(str));
            }

            int k = 0;//the number of SGTIN
            int y = 5;// the first position
            foreach (Bitmap bitmap in list_of_datamatrix)
            {
                driver.windowsfont(180, y, 30, 0, 0, 0, "arial.TTF", sgtins[k].Substring(2, 14));// print GTIN
                y += 25;
                driver.windowsfont(180, y, 30, 0, 0, 0, "arial.TTF", sgtins[k].Substring(18, 13)); //print serial number
                y += 50;
                driver.windowsfont(180, y, 72, 0, 0, 0, "arial.TTF", "2927");// print the number which connect to SSCC code

                driver.send_bitmap(5, 5, bitmap);//print a datamatrix
                k++;
                y = 0;

                driver.printlabel("1", "1");
                driver.clearbuffer();
            }
            driver.closeport();
        }

        public static void PrintSscc(TSCSDK.driver driver, List<string> sscc)
        {
            List<Bitmap> list_of_barcodes = new List<Bitmap>();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = { Width = 300, Height = 150, } //the size of a datamatrix
            };

            foreach (string str in sscc)
            {
                list_of_barcodes.Add(writer.Write(str));
            }

            foreach (Bitmap bitmap in list_of_barcodes)
            {
                driver.send_bitmap(1, 1, bitmap);//print a datamatrix                
                driver.printlabel("1", "1");
                driver.clearbuffer();
            }
            driver.closeport();
        }

        public static void TSLPrintSettings()
        {
            XmlTextReader settingsReader = new XmlTextReader("TSCPrinterSettings.xml");
            settingsReader.Read();
            while(settingsReader.Read())
            {

            }
        }

    }
}
