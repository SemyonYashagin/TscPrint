using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TscDll.Entities;

namespace TscDll.Helpers
{
    public class ViewHelper
    {
        public static void GetSgtinANDSscc(List<string> All_Sgtin, List<string> All_Sscc, Sscc unit)
        {
            if (unit.ChildSscc != null)
            {
                foreach (Sscc item_sscc in unit.ChildSscc)
                {
                    GetSgtinANDSscc(All_Sgtin, All_Sscc, item_sscc);
                }
            }
            if (unit.Sgtins != null)
            {
                foreach (string sgtin in unit.Sgtins)
                {
                    All_Sgtin.Add(sgtin);
                }
            }
            All_Sscc.Add(unit.SsccValue);
        }

        public static DataTable Put_dataToDGV(List<string> Sgtin, List<string> Sscc)
        {
            var dictionary = new Dictionary<string, List<string>>
            {
                { "SGTIN", Sgtin },
                { "SSCC", Sscc }
            };

            int rowCount = dictionary.Cast<KeyValuePair<string, List<string>>>()
                         .Select(x => x.Value.Count).Max();

            var dataTable = new DataTable();
            foreach (var key in dictionary.Keys)
            {
                dataTable.Columns.Add(key);
            }

            for (int i = 0; i < rowCount; i++)
            {
                var row = dataTable.Rows.Add();
                foreach (var key in dictionary.Keys)
                {
                    try
                    {
                        row[key] = dictionary[key][i];
                    }
                    catch
                    {
                        row[key] = null;
                    }
                }
            }
            return dataTable;
        }
    }
}
