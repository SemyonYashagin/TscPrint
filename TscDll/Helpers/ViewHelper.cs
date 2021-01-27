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
        /// <summary>
        /// Изъятие SGTIN-ов и SSCC из объекта класса Unit
        /// </summary>
        /// <param name="All_Sgtin">Список SGTIN-ов</param>
        /// <param name="All_Sscc">Список SSCC</param>
        /// <param name="unit">Объект класса Unit</param>
        public static void GetSgtinANDSscc(List<string> All_Sgtin, List<string> All_Sscc, Unit unit)
        {
            if (unit.Units != null)
            {
                foreach (Unit item_sscc in unit.Units)
                {
                    GetSgtinANDSscc(All_Sgtin, All_Sscc, item_sscc);
                }
            }
            if (unit.Units != null)
            {
                foreach (string sgtin in unit.Sgtins)
                {
                    All_Sgtin.Add(sgtin);
                }
            }
            All_Sscc.Add(unit.SsccValue);
        }
        /// <summary>
        /// Ввод данные в DataGridView
        /// </summary>
        /// <param name="Sgtin">Список SGTIN-ов</param>
        /// <param name="Sscc">Список SSCC</param>
        /// <returns>объект класса DataTable</returns>
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
