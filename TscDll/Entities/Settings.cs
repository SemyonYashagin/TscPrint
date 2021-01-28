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
        public Intvalue SgtinSize { get; set; }
        public List<Intvalue> SgtinList { set; get; }
        public Intvalue SsccSize { get; set; }
        public List<Intvalue> SsccList { set; get; }
        public decimal Speed { get; set; }
        public decimal Density { get; set; }
    }

    public class Intvalue
    {
        public string Size { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
