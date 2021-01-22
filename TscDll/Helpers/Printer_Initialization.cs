using System;
using TSCSDK;

namespace TscDll.Helpers
{
    [Serializable]
    public class Printer_Initialization
    {
        public static void GetSGTINSettings()
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
        }
        public static void GetSSCCSettings()
        {
            TSCSDK.driver driver = new TSCSDK.driver();
            driver.openport("TSC MH240");
            driver.sendcommand("SIZE 100 mm, 50 mm"); //the size of a paper in the printer
            driver.sendcommand("GAP 2 mm, 0");
            driver.sendcommand("SPEED 4");
            driver.sendcommand("DENSITY 12");
            driver.sendcommand("DIRECTION 1");
            driver.sendcommand("SET TEAR ON");
            driver.sendcommand("CODEPAGE UTF-8");
            driver.clearbuffer();
        }
    }
}
