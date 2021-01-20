using System;
using System.Collections.Generic;
using System.Text;
using TSCSDK;

namespace TscDll.Entities
{
    
    public class MarkPrintUnit
    {
        public string Nomen { get; set; }
        public string Gtin { get; set; }
        public List<string> Sgtins { get; set; }
        public List<string> Ssccs { get; set; }
    }

    //public class Sscc
    //{
    //    public string ParentSscc { get; set; }
    //    public List<Sscc> ChildSscc { get; set; }
    //    public List<string> Sgtins { get; set; }
    //}
}
