using System.Windows.Forms;
using TscDll.Entities;
using TscDll.Helpers;

namespace TscDll.Forms
{
    public partial class Gs128Settings : Form
    {
        Settings settings = TscHelper.GetSettings();
        public Gs128Settings()
        {
            InitializeComponent();
            cB_GS128Size.DropDownStyle = ComboBoxStyle.DropDownList;

            if (settings != null)
            {
                UpdateFields();
            }
            else MessageBox.Show("Исходные данные не найдены");
        }

        private void UpdateFields()
        {
            if (TscHelper.FileExist())
            {
                Settings settings = TscHelper.GetSettings();
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
            if (TscHelper.FileExist() && cB_GS128Size.Text != "" &&  tB_PrinterName.Text != "")
            {
                Settings newset = TscHelper.GetSettings();

                newset.PrinterName = tB_PrinterName.Text;
                newset.Gs128Size = new Intvalue
                {
                    Size = cB_GS128Size.Text,
                    Width = GetValue(newset, cB_GS128Size.Text).Width,
                    Height = GetValue(newset, cB_GS128Size.Text).Height
                };


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
            else
            {
                MessageBox.Show("Введите данные");
            }
        }
        private Intvalue GetValue(Settings set, string size)
        {
            foreach (Intvalue value in set.SgtinList)
            {
                if (size == value.Size)
                    return value;
            }
            return null;
        }
    }
}
