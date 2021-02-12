using System;
using System.Collections.Generic;

namespace TscDll.Entities
{
    public class MarkPrintUnit
    {
        /// <summary>Номенклатура (обязательный параметр)</summary>
        private string nomenProduct { get; set; }

        public string NomenProduct
        {
            get
            {
                if (!String.IsNullOrEmpty(nomenProduct))
                {
                    return nomenProduct;
                }
                else throw new NullReferenceException("NomenProduct is null or empty!");
            }
            set
            {
                nomenProduct = value;
            }
        }

        /// <summary>Номер партии (обязательный параметр)</summary>
        public long PartyId { get; set; }

        /// <summary>GTIN (14 символов) (обязательный параметр)</summary>
        private string gtin { get; set; }

        public string Gtin
        {
            get
            {
                if (!String.IsNullOrEmpty(gtin))
                {
                    return gtin;
                }
                else throw new NullReferenceException("Gtin is null or empty!");
            }
            set
            {
                gtin = value;
            }
        }
        
        private Unit units { get; set; }

        /// <summary>Короб (обязательный параметр)</summary>
        public Unit Units
        {
            get
            {
                if (units!=null)
                {
                    return units;
                }
                else throw new NullReferenceException("Units is null or empty!");
            }
            set
            {
                units = value;
            }
        }
    }
    public class Unit
    {
        private string ssccValue { get; set; }

        /// <summary>Идентификатор SSCC (18 символов) (обязательный параметр)</summary>
        public string SsccValue
        {
            get
            {
                if(String.IsNullOrEmpty(ssccValue))
                {
                    if (Sgtins != null && sgtins.Count > 0)
                    {
                        return ssccValue;
                    }
                    else throw new NullReferenceException("Sscc is null or empty!");
                }
                return ssccValue;
            }
            set
            {
                ssccValue = value;
            }
        }
        /// <summary>Агрегаты (необязательный параметр)</summary>
        public List<Unit> Units { get; set; }
        
        private List<string> sgtins { get; set; }
        /// <summary>SGTIN-ы (необязательный параметр)</summary>
        public List<string> Sgtins
        {
            get
            {
                if(sgtins==null)
                {
                    if (Units != null && Units.Count>0)
                    {
                        return sgtins;
                    }
                    else throw new NullReferenceException("Sgtins is null or empty!");
                }
                return sgtins;                
            }
            set
            {
                sgtins = value;
            }
        }
    }
}
