using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TscDll.Entities
{
    public class SimplePrint
    {
        public IList<Sgtin> sgtins { get; set; }
        public IList<SSCC> SSCCs { get; set; }
    }
    public class Sgtin : item
    {
        public string nomenShortName { get; set; } //
    }
    public class SSCC : item
    {
        
    }
    public abstract class item
    {
        public int? id { get; set; }
        public int? parentId { get; set; }
        public int nomenId { get; set; }
        public string nomenName { get; set; }
        public string partyId { get; set; }
        public string value { get; set; }
    }
}
