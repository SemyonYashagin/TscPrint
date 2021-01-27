using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscDll.Entities
{
    /// <summary>
    /// Класс для работы с настройками принтера
    /// </summary>
    public class Settings
    {
        public string PrinterName { get; set; }       
        public string SgtinSize { get; set; }
        public List<string> SgtinList { set; get; }
        public string SsccSize { get; set; }
        public List<string> SsccList { set; get; }
        public decimal Speed { get; set; }
        public decimal Density { get; set; }
    }
}
