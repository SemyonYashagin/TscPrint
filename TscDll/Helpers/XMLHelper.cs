using System;
using System.IO;
using System.Text;
using TscDll.Entities;
using TscDll.Extensions;

namespace TscDll.Helpers
{
    class XMLHelper
    {
        /// <summary>
        /// Проверка на существовании файла в котором храняться настройки принтера
        /// </summary>
        /// <returns>true - файл найден, иначе false</returns>
        public static Boolean FileExist()
        {
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml"; //full directory
            if (File.Exists(fileSettings))
                return true;
            return false;
        }

        /// <summary>
        /// Возвращает настройки принтера из XML
        /// </summary>
        /// <returns>Класс Settings</returns>
        public static Settings GetSettings()
        {
            if (FileExist())
            {
                string set = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter\printerSettings.xml");
                var settings = (Settings)set.ParseXML(typeof(Settings), Encoding.GetEncoding("utf-16"));
                return settings;
            }
            return null;
        }
        /// <summary>
        /// Создает файл XML c настройками принтера
        /// </summary>
        /// <param name="settings">Объект класса Settings</param>
        public static void CreateFile(Settings settings)
        {
            string xmlSetting = settings.ToXml();

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml"; //full directory

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter outputFile = new StreamWriter(fileSettings))
            {
                outputFile.WriteLine(xmlSetting);
            }
        }
        /// <summary>
        /// Сохраняет настройки принтера в XML 
        /// </summary>
        /// <param name="settings">Объект класса Settings</param>
        /// <returns>true - настройки сохранены успешно, иначе false</returns>
        public static ResponseData SaveSettings(Settings settings)
        {
            ResponseData response = new ResponseData();

            string xmlSetting = settings.ToXml();

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml"; //full directory

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter outputFile = new StreamWriter(fileSettings))
            {
                outputFile.WriteLine(xmlSetting);
            }

            if (Directory.Exists(directory))
                response.IsSuccess = true;

            return response;
        }
    }
}
