using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSCSDK;

namespace TscDll.Helpers
{
    public class Printer_Initialization
    {
        TSCSDK.driver driver = new TSCSDK.driver();
        public  bool openPort
        {
            get { return driver.openport("TSC MH240"); }
        }
            
        public  void GetSettings()
        {
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
        
    }
}
