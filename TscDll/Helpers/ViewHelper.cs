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
