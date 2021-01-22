using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TscDll.Extensions
{
    public static class ObjectExtensions
    {
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

        public static string Serialize<T>(this T value)
        {
            if (value == null) return string.Empty;

            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    return stringWriter.ToString();
                }
            }
        }
    }
}
