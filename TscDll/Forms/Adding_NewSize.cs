using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string newSize = tB_newSizeWidth.Text + " mm, " + tB_newSizeHeight + " mm";
            MessageBox.Show("Новый размер добавлен!");
            Close();
        }
    }
}
