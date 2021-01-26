using System;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class Adding_NewSize : Form
    {
        public Adding_NewSize()
        {
            InitializeComponent();
        }

        private void button_AddnewSize_Click(object sender, EventArgs e)
        {
            if(AddToXMLData())
            {
                MessageBox.Show("Размер добавлен");
            }
            else
            {
                MessageBox.Show("Размер записан ранее");
            }
        }

        private void tB_newSizeWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tB_newSizeHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private bool AddToXMLData()
        {
            string newSize = tB_newSizeWidth.Text + " mm, " + tB_newSizeHeight.Text + " mm";

            if (!TscHelper.FileExist())
            {
                Settings settings = new Settings();
                TscHelper.CreateFile(settings);
            }

            if (int.TryParse(tB_newSizeWidth.Text, out int width) && int.TryParse(tB_newSizeHeight.Text, out int height))
            {
                if (tB_newSizeHeight.TextLength != 0 && tB_newSizeWidth.TextLength != 0 && (width <= 100 && width >= 30) && (height <= 200 && height >= 20))
                {
                    Settings newSetting = TscHelper.GetSettings();

                    foreach (string sgtinSize in newSetting.SgtinList)
                    {
                        if (newSize == sgtinSize)
                        {
                            return false;
                        }
                    }

                    newSetting.SgtinList.Add(newSize);
                    newSetting.SsccList.Add(newSize);
                    ResponseData response = TscHelper.SaveSettings(newSetting);
                }
            }
            return true;
        }
    }
}
