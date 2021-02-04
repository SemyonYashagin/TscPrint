using System;
using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class Adding_NewSize : Form
    {
        private ToolTip t_Tip;
        public Adding_NewSize()
        {
            InitializeComponent();
            t_Tip = new ToolTip
            {
                Active = true,
                AutoPopDelay = 4000,
                InitialDelay = 600,
                IsBalloon = true,
                ToolTipIcon = ToolTipIcon.Info,
                ShowAlways = true
            };
            t_Tip.SetToolTip(label1, "от 30 до 100 мм");
            t_Tip.SetToolTip(label2, "от 20 до 50 мм");
            t_Tip.SetToolTip(groupBox1, "Ширина от 30 до 100 мм \r\n Высота от 20 до 50 мм");
        }

        private void button_AddnewSize_Click(object sender, EventArgs e)
        {
            if (AddToXMLNewSize()==1)
            {
                MessageBox.Show("Размер записан ранее");
            }
            else if (AddToXMLNewSize() == 2)
            {
                MessageBox.Show("Некорректные значения");
            }
            else
            {
                MessageBox.Show("Новый размер добавлен");
                Close();
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
        /// <summary>
        /// Добавление нового размера в XML 
        /// </summary>
        /// <returns></returns>
        private int AddToXMLNewSize()
        {
            Intvalue intvalue = new Intvalue();

            if (!TscHelper.FileExist())
            {
                Settings settings = new Settings();
                TscHelper.CreateFile(settings);
            }

            if (int.TryParse(tB_newSizeWidth.Text, out int width) && int.TryParse(tB_newSizeHeight.Text, out int height))
            {
                if (tB_newSizeHeight.TextLength != 0 && tB_newSizeWidth.TextLength != 0 && (width <= 100 && width >= 30) && (height <= 50 && height >= 20) && (width > height+17))
                {
                    intvalue.Size = tB_newSizeWidth.Text + " mm, " + tB_newSizeHeight.Text + " mm";
                    intvalue.Width = Convert.ToInt32(tB_newSizeWidth.Text);//width
                    intvalue.Height = Convert.ToInt32(tB_newSizeHeight.Text);//height

                    Settings newSetting = TscHelper.GetSettings();

                    foreach (Intvalue sgtinSize in newSetting.SgtinList)
                    {
                        if (intvalue.Size == sgtinSize.Size)
                        {
                            return 1;
                        }
                    }

                    newSetting.SgtinList.Add(intvalue);
                    newSetting.SsccList.Add(intvalue);
                    TscHelper.SaveSettings(newSetting);
                }
                else return 2;
            }
            else return 2;
            return 3;
        }       
    }
}
