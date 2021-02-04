using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TscDll.Entities;

namespace TscDll.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Преобразование объекта в JSON
        /// </summary>
        /// <param name="obj">Объект класса</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented).ToString();
        }

        /// <summary>
        /// Преобразование объекта в строку XML
        /// </summary>
        /// <param name="obj">Объект класса</param>
        /// <returns></returns>
        public static string ToXml(this object obj, System.Xml.Formatting formatting = System.Xml.Formatting.Indented)
        {
            XmlSerializer xs = new XmlSerializer(obj.GetType(), new Type[] { obj.GetType() });
            StringWriter w = new StringWriter();
            xs.Serialize(w, obj);
            return w.ToString();
        }

        /// <summary>
        /// Преобраование строки XML в Generic объект (входящий параметр Type)
        /// </summary>
        /// <param name="str">Строка для преобразования</param>
        /// <param name="T">Тип</param>
        /// <returns></returns>
        public static object ParseXML(this string str, Type T, Encoding encoding = null)
        {

            var reader = XmlReader.Create(str.Trim().ToStream(encoding), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });
            return new XmlSerializer(T).Deserialize(reader);
        }

        /// <summary>
        /// Преобраование строки в поток байтов
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static Stream ToStream(this string str, Encoding encoding)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            if (encoding == null)
            {
                writer = new StreamWriter(stream);
            }
            else
                writer = new StreamWriter(stream, encoding);

            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static DataTable ToDataTable(List<MarkPrintUnit> marks)
        {
            DataTable table = new DataTable();
            DataColumn column;
            DataRow row;
            List<string> sgtins = new List<string>();
            List<string> sscc = new List<string>();

            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "ProductName",
                Caption = "Номенклатура",
                ReadOnly = true,
                Unique = true
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Gtin",
                Caption = "GTIN",
                ReadOnly = true,
                Unique = true
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "SgtinCount",
                Caption = "Кол-во SGTIN-ов",
                ReadOnly = true,
                Unique = false
            };
            table.Columns.Add(column);

            column = new DataColumn
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "SsccCount",
                Caption = "Кол-во SSCC",
                ReadOnly = true,
                Unique = false
            };
            table.Columns.Add(column);

            foreach(MarkPrintUnit unit in marks)
            {
                row = table.NewRow();
                row[0] = unit.NomenProduct;
                row[1] = unit.Gtin;
                GetSsccSgtin(sgtins, sscc, unit.Units);
                row[2] = sgtins.Count;
                row[3] = sscc.Count;

                table.Rows.Add(row);
                sgtins.Clear();
                sscc.Clear();
            }

            return table;
        }

        public static void GetSsccSgtin(List<string> All_Sgtin, List<string> All_Sscc, Unit unit)
        {
            if(unit!=null)
            {
                if (unit.Units != null)
                {
                    foreach (Unit item_sscc in unit.Units)
                    {
                        GetSsccSgtin(All_Sgtin, All_Sscc, item_sscc);
                    }
                }
                if (unit.Units == null)
                {
                    foreach (string sgtin in unit.Sgtins)
                    {
                        All_Sgtin.Add(sgtin);
                    }
                }
                if(unit.SsccValue!=null) All_Sscc.Add(unit.SsccValue);
            }
        }
    }
}
