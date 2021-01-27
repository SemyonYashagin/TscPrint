using TscDll;
using TscDll.Entities;
using TscDll.Helpers;
using TscDll.Extensions;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;
using System.Drawing;

namespace TscPrintTest
{
    public partial class Main_form : Form
    {
        public Main_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap gs128 = (Bitmap)Image.FromFile("D:\\Codes\\GS128.jpg");
            TscDll.Print.PrintGS128(gs128);
        }
    }
}
