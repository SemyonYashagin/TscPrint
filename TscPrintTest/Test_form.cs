using System.Windows.Forms;
using System;
using System.Drawing;
using TscDll.Entities;
using System.Collections.Generic;

namespace TscPrintTest
{
    public partial class Test_form : Form
    {
        List<MarkPrintUnit> printUnits = new List<MarkPrintUnit>();
        public Test_form()
        {
            InitializeComponent();

            UnitsInitialize(printUnits);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap gs128 = (Bitmap)Image.FromFile("D:\\Codes\\GS128.jpg");
            TscDll.Print.PrintGS128(gs128);
        }

        private void UnitsInitialize(List<MarkPrintUnit> printUnits)
        {
            printUnits.Add(new MarkPrintUnit
            {
                NomenProduct = "Сыр",
                Gtin = "04630030160342",
                PartyId = 1,
                Units = new Unit
                {
                    SsccValue = "46500997801035211",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035212",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02" }
                                 },

                       new Unit {
                                    SsccValue = "46500997801035213",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                 }
                    }
                }


            });

            printUnits.Add(new MarkPrintUnit
            {
                NomenProduct = "Молоко",
                Gtin = "04630030160343",
                PartyId = 1,
                Units = new Unit
                {
                    SsccValue = "46500997801035221",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035222",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE05", "010463003016034221641556169149391EE06", "010463003016034221641556169149391EE07" }
                                 },

                       new Unit {
                                    SsccValue = "46500997801035223",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE08", "010463003016034221641556169149391EE09" }
                                },
                       new Unit {
                                    SsccValue = "46500997801035224",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE10", "010463003016034221641556169149391EE11" }
                                 }

                    }
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TscDll.Print print = new TscDll.Print();
            
            print.PrintSgtinSscc(printUnits);
            Close();
        }
    }
}
