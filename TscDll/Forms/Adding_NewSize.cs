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
                AutoClosingMessageBox.Show("Размер записан ранее", "Ошибка", 2000);
            }
            else if (AddToXMLNewSize() == 2)
            {
                AutoClosingMessageBox.Show("Некорректные значения", "Ошибка", 2000);
            }
            else
            {
                AutoClosingMessageBox.Show("Новый размер добавлен", "Успешно", 2000);
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
        /// Добавление нового размера для Sgtin и SSCC в XML 
        /// </summary>
        /// <returns></returns>
        private int AddToXMLNewSize()
        {
            Intvalue intvalue = new Intvalue();

            if (!XMLHelper.FileExist())
            {
                Settings settings = new Settings();
                XMLHelper.CreateFile(settings);
            }

            if (int.TryParse(tB_newSizeWidth.Text, out int width) && int.TryParse(tB_newSizeHeight.Text, out int height))
            {
                if (tB_newSizeHeight.TextLength != 0 && tB_newSizeWidth.TextLength != 0 && (width <= 100 && width >= 30) && (height <= 50 && height >= 20) && (width > height+17))
                {
                    intvalue.Size = tB_newSizeWidth.Text + " mm, " + tB_newSizeHeight.Text + " mm";
                    intvalue.Width = Convert.ToInt32(tB_newSizeWidth.Text);//width
                    intvalue.Height = Convert.ToInt32(tB_newSizeHeight.Text);//height

                    Settings newSetting = XMLHelper.GetSettings();

                    foreach (Intvalue sgtinSize in newSetting.SgtinList)
                    {
                        if (intvalue.Size == sgtinSize.Size)
                        {
                            return 1;
                        }
                    }

                    newSetting.SgtinList.Add(intvalue);
                    newSetting.SsccList.Add(intvalue);
                    XMLHelper.SaveSettings(newSetting);
                }
                else return 2;
            }
            else return 2;
            return 3;
        }       
    }
}
