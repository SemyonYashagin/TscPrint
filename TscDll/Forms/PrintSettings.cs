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
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class PrintSettings : Form
    {
        public Boolean Status { get; set; }

        public PrintSettings()
        {
            InitializeComponent();
            cB_SgtinSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cB_SsccSize.DropDownStyle = ComboBoxStyle.DropDownList;
            
            Settings settings = TscHelper.GetSettings();
            if (settings != null)
            {
                tB_PrinterName.Text = settings.PrinterName;
                cB_SgtinSize.Text = settings.SgtinSizes;
                cB_SsccSize.Text = settings.SsccSizes;
                tB_PrinterSpeed.Text = settings.Speed;
                tB_PrinterDensity.Text = settings.Density;
            }
            else MessageBox.Show("Исходные данные не найдены");

        }

        private void Button_Synch_Click(object sender, EventArgs e)
        {
            Main_form main = new Main_form();
            var k = new Settings()
            {
                PrinterName = tB_PrinterName.Text,
                SgtinSizes = cB_SgtinSize.Text,
                SsccSizes= cB_SsccSize.Text,
                Speed = tB_PrinterSpeed.Text,
                Density = tB_PrinterDensity.Text

            };

            ResponseData response = TscHelper.SaveSettings(k);

            if (response.IsSuccess)
            {
                MessageBox.Show("Данные загружены");
                TscHelper.GetSettings();

                Close();
                
            }
            else
            {
                MessageBox.Show(response.ErrorMessage);
            }
        }
    }
}
