using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Extensions;

namespace TscDll.Forms
{
    public partial class PrintSettings : Form
    {
        public PrintSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var k = new Settings()
            {
                PrinterName = textBox1.Text,
                SgtinSizes = textBox2.Text
            };
            SaveSettings(k);
        }

        private void SaveSettings(Settings settings)
        {
            string xmlSetting = settings.ToXml();

            string directory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\TscPrinter";
            string fileSettings = directory + @"\printerSettings.xml";

            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(fileSettings))
            {
                outputFile.WriteLine(xmlSetting);
            }
        }
    }
}
