﻿using System.Windows.Forms;
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
            //TSCSDK.driver driver = new TSCSDK.driver();
            //driver.openport("TSC MH340");
            //driver.sendcommand("SIZE 43 mm, 25 mm");

            //for (int i=0;i<2;i++)
            //{
            //    Bitmap bitmap = TscDll.Helpers.SgtinHelper.CreateSgtinBitmap(43, 25);
            //    driver.send_bitmap(0, 0, bitmap);
            //    driver.printlabel("1", "1");
            //}
            //driver.clearbuffer();
            //driver.closeport();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap gs128 = (Bitmap)Image.FromFile("D:\\Codes\\GS128.png");
            TscDll.Print.PrintGS128(gs128);          
        }

        private void UnitsInitialize(List<MarkPrintUnit> printUnits)
        {
            printUnits.Add(new MarkPrintUnit
            {
                NomenProduct = "Сыр",
                Gtin = "04630030160342",
                PartyId = "151515",
                Units = new Unit
                {
                    SsccValue = "46500997801035211",
                    Units = new List<Unit>
                    {
                       new Unit {
                                    SsccValue = "46500997801035212",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02"}
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
                PartyId = "65777789",
                Units = new Unit
                {
                    Units = new List<Unit>
                    {
                        new Unit {
                                    SsccValue = "46500997801035213",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE11", "010463003016034221641556169149391EE12" },
                                    Units = new List<Unit>
                                    {
                                        new Unit
                                        {
                                            Sgtins = new List<string> { "010463003016034221641556169149391EE13", "010463003016034221641556169149391EE14" },
                                            SsccValue = "46500997801035214"
                                        }
                                    }
                                    
                                }
                    },
                    Sgtins = new List<string> { "010463003016034221641556169149391EE15", "010463003016034221641556169149391EE16" }
                    
                }
            });

            printUnits.Add(new MarkPrintUnit
            {
                NomenProduct = "Паштет",
                Gtin = "04630030160344",
                PartyId = "9764889",
                Units = new Unit
                {
                    Sgtins = new List<string> { "010463003016034221641556169149391EE21", "010463003016034221641556169149391EE22" }
                }
            });
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TscDll.Print.PrintSgtinSscc(printUnits);
        }
    }
}
