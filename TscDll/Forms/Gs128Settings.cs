using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class Gs128Settings : Form
    {
        Settings settings = XMLHelper.GetSettings();
        public Gs128Settings()
        {
            InitializeComponent();
            UpdateFields();
        }
        /// <summary>
        /// Обновление полей формы
        /// </summary>
        private void UpdateFields()
        {
            cB_PrinterName.Items.Clear();
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                cB_PrinterName.Items.Add(printer);
            }

            if (XMLHelper.FileExist())
            {
                Settings settings = XMLHelper.GetSettings();
                cB_GS128Size.Items.Clear();
                
                if (settings.PrinterName != null)
                    cB_PrinterName.Text = settings.PrinterName;
                                
                if(settings.Gs128Size != null)
                    cB_GS128Size.Text = settings.Gs128Size.Size;

                foreach (Intvalue gs128 in settings.Gs128List)
                {
                    cB_GS128Size.Items.Add(gs128.Size);
                }
            }
        }

        private void Button_AddNewSize_Click(object sender, System.EventArgs e)
        {
            AddNewSizeGS128_Form addNewSize = new AddNewSizeGS128_Form();
            addNewSize.ShowDialog();
            UpdateFields();
        }

        private void Button_SaveNewSettings_Click(object sender, System.EventArgs e)
        {
            if (XMLHelper.FileExist() && cB_GS128Size.Text != "" && cB_PrinterName.Text != "")
            {
                Settings newset = XMLHelper.GetSettings();

                newset.PrinterName = cB_PrinterName.Text;
                newset.Gs128Size = new Intvalue
                {
                    Size = cB_GS128Size.Text,
                    Width = GetValue(newset, cB_GS128Size.Text).Width,
                    Height = GetValue(newset, cB_GS128Size.Text).Height
                };


                ResponseData response = XMLHelper.SaveSettings(newset);

                if (response.IsSuccess)
                {
                    AutoClosingMessageBox.Show("Данные загружены", "Успешно", 1500);
                    XMLHelper.GetSettings();
                    Close();
                }
                else
                {
                    AutoClosingMessageBox.Show(response.ErrorMessage, "Ошибка", 1500);
                }
            }
            else
            {
                AutoClosingMessageBox.Show("Введите данные", "Ошибка", 1500);
            }
        }
        /// <summary>
        /// Метод для поиска нужного размера (gs128) в настройках принтера из всех размеров gs128 (Gs128List)
        /// </summary>
        /// <param name="set">Объект класса Settings в котором хранятся настройки принтера</param>
        /// <param name="size">Размер gs128</param>
        /// <returns>Если данный размер записан в настройках принтера,то возвращает данный размер, иначе null</returns>
        private Intvalue GetValue(Settings set, string size)
        {
            foreach (Intvalue value in set.Gs128List)
            {
                if (size == value.Size)
                    return value;
            }
            return null;
        }

        private void cB_PrinterName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cB_GS128Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
