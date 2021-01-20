using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TSCSDK;

namespace TscDll.Entities
{

    public class MarkPrintUnit
    {
        /// <summary>Номенклатура</summary>
        public string Nomen { get; set; }

        /// <summary>Номер партии</summary>
        public long PartyId { get; set; }

        /// <summary>GTIN (14 символов)</summary>
        public string Gtin { get; set; }

        /// <summary>Коллекция неупакованных SGTIN-ов</summary>
        public List<string> Sgtins { get; set; }

        /// <summary>Короб</summary>
        public Sscc Ssccs { get; set; }
    }

    public class Sscc
    {
        /// <summary>Идентификатор SSCC (20 символов)</summary>
        public string SsccValue { get; set; }

        /// <summary>Родительская SSCC</summary>
        public string ParentSscc { get; set; }

        /// <summary>Коллекция упакованных SGTIN-ов</summary>
        public List<string> Sgtins { get; set; }


        /// <summary>Дочерние SSCC</summary>
        public List<Sscc> ChildSscc { get; set; }

        private long? SsccId
        {
            get
            {
                if ( (ChildSscc != null && ChildSscc.Count > 0) || ParentSscc !=null)
                {
                    return 1;
                }
                else return null;
            }
        }
        private long? ParentSsccId
        {
            get
            {
                if (ParentSscc != null)
                {
                    return 2;
                }
                else return null;
            }
        }
    }
}
