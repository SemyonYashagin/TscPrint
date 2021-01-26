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
        public PrintSettings()
        {
            InitializeComponent();
            cB_SgtinSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cB_SsccSize.DropDownStyle = ComboBoxStyle.DropDownList;

            Settings settings = TscHelper.GetSettings();
            if (settings != null)
            {
                cB_SgtinSize.SelectedValue = settings.SgtinSize;
                cB_SsccSize.Text = settings.SsccSize;

                tB_PrinterName.Text = settings.PrinterName;
                if (settings.Speed < 2 || settings.Speed > 12)
                    numericSpeed.Value = numericSpeed.Minimum;
                else
                    numericSpeed.Value = settings.Speed;
                
                if (settings.Density > 15)
                    numericDensity.Value = numericDensity.Maximum;
                else
                    numericDensity.Value = settings.Density;

                foreach (string sgtin in settings.SgtinList)
                {
                    cB_SgtinSize.Items.Add(sgtin);
                }
                foreach (string sscc in settings.SsccList)
                {
                    cB_SsccSize.Items.Add(sscc);
                }
            }
            else MessageBox.Show("Исходные данные не найдены");

        }

        private void Button_Synch_Click(object sender, EventArgs e)
        {
            Settings newset = TscHelper.GetSettings();

            newset.PrinterName = tB_PrinterName.Text;
            newset.SgtinSize = cB_SgtinSize.Text;
            newset.SsccSize = cB_SsccSize.Text;
            newset.Speed = numericSpeed.Value;
            newset.Density = numericDensity.Value;

            ResponseData response = TscHelper.SaveSettings(newset);

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
