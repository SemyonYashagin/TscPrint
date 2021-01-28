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
                    SsccValue = "46500997801035207",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035208",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02" }
                                 },

                       new Unit {
                                    SsccValue = "46500997801035209",
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
                    SsccValue = "46500997801035207",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035208",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02", "010463003016034221641556169149391EE02" }
                                 },

                       new Unit {
                                    SsccValue = "46500997801035209",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                },
                       new Unit {
                                    SsccValue = "46500997801035209",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                 }

                    }
                }
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TscDll.Print.PrintSgtinSscc(printUnits);
            Close();
        }
    }
}
