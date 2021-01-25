using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TSCSDK;

namespace TscDll.Entities
{

    public class MarkPrintUnit
    {
        /// <summary>Номенклатура (обязательный параметр)</summary>
        public string NomenProduct { get; set; }

        /// <summary>Номер партии (обязательный параметр)</summary>
        public long PartyId { get; set; }

        /// <summary>GTIN (14 символов) (обязательный параметр)</summary>
        public string Gtin { get; set; }

        /// <summary>Короб</summary>
        public Unit Units { get; set; }
    }

    public class Unit
    {
        private string ssccValue { get; set; }

        /// <summary>Идентификатор SSCC (18 символов) (обязательный параметр)</summary>
        public string SsccValue
        {
            get
            {
                if (!String.IsNullOrEmpty(ssccValue))
                {
                    return ssccValue;
                }
                else throw new NullReferenceException("Sscc is null or empty!");
            }
            set
            {
                ssccValue = value;
            }
        }

        /// <summary>Агрегаты (необязательный параметр)</summary>
        public List<Unit> Units { get; set; }

        /// <summary>SGTIN-ы (необязательный параметр)</summary>
        public List<string> Sgtins { get; set; }
    }
}
