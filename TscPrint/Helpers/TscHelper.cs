using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using TSCSDK;

namespace TscDll.Helpers
{
    public class TscHelper
    {
        public static void Init_printer(TSCSDK.driver driver)
        {
            int a= 43;
            int b= 25;
            driver.openport("TSC MH240");
            driver.sendcommand("SIZE \"a\" mm, \"b\" mm"); //the size of a paper in the printer
            //driver.sendcommand("SIZE 60 mm, 30 mm");
            //driver.sendcommand("SIZE 100 mm, 50 mm");
            //driver.sendcommand("AUTODETECT");
            //driver.sendcommand("GAP 2 mm, 0");
            driver.sendcommand("SPEED 4");
            driver.sendcommand("DENSITY 12");
            driver.sendcommand("DIRECTION 1");
            driver.sendcommand("SET TEAR ON");
            driver.sendcommand("CODEPAGE UTF-8");
            driver.clearbuffer();
        }

        public static void Print(TSCSDK.driver driver, List<Bitmap> bitmaps, string[] sgtins)
        {
            int k = 0;//the number of SGTIN
            int y = 5;// the first position
            foreach (Bitmap bitmap in bitmaps)
            {
                driver.windowsfont(180, y, 30, 0, 0, 0, "arial.TTF", sgtins[k].Substring(2, 14));// print GTIN
                y += 25;
                driver.windowsfont(180, y, 30, 0, 0, 0, "arial.TTF", sgtins[k].Substring(18, 13)); //print serial number
                y += 50;
                driver.windowsfont(180, y, 72, 0, 0, 0, "arial.TTF", "2927");// print the number which connect to SSCC code

                //driver.send_bitmap(0, 0, bitmap);//print a datamatrix
                k++;
                y = 0;

                driver.printlabel("1", "1");
                driver.clearbuffer();
                //break; // for printing only one page (one datamatrix)
            }
        }
    }
}
