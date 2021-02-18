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
            cB_GS128Size.DropDownStyle = ComboBoxStyle.DropDownList;

            if (settings != null)
            {
                UpdateFields();
            }
            else AutoClosingMessageBox.Show("Исходные данные не найдены", "Ошибка", 2000);
        }

        private void UpdateFields()
        {
            if (XMLHelper.FileExist())
            {
                Settings settings = XMLHelper.GetSettings();
                cB_GS128Size.Items.Clear();
                tB_PrinterName.Text = settings.PrinterName;
                
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
            if (XMLHelper.FileExist() && cB_GS128Size.Text != "" &&  tB_PrinterName.Text != "")
            {
                Settings newset = XMLHelper.GetSettings();

                newset.PrinterName = tB_PrinterName.Text;
                newset.Gs128Size = new Intvalue
                {
                    Size = cB_GS128Size.Text,
                    Width = GetValue(newset, cB_GS128Size.Text).Width,
                    Height = GetValue(newset, cB_GS128Size.Text).Height
                };


                ResponseData response = XMLHelper.SaveSettings(newset);

                if (response.IsSuccess)
                {
                    AutoClosingMessageBox.Show("Данные загружены", "Успешно", 2000);
                    XMLHelper.GetSettings();
                    Close();
                }
                else
                {
                    AutoClosingMessageBox.Show(response.ErrorMessage, "Ошибка", 2000);
                }
            }
            else
            {
                AutoClosingMessageBox.Show("Введите данные", "Ошибка", 2000);
            }
        }
        private Intvalue GetValue(Settings set, string size)
        {
            foreach (Intvalue value in set.Gs128List)
            {
                if (size == value.Size)
                    return value;
            }
            return null;
        }
    }
}
