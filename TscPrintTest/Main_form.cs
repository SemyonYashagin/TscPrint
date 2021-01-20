using TscDll;
using TscDll.Entities;
using TscDll.Helpers;
using TscDll.Extensions;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data;

namespace TscPrintTest
{
    public partial class Main_form : Form
    {
        TSCSDK.driver driver = new TSCSDK.driver();
        List<MarkPrintUnit> printUnits;
        List<string> sscc_values = new List<string>();
        List<string> sgtin_values = new List<string>();

        public Main_form()
        {
            InitializeComponent();

            printUnits = new List<MarkPrintUnit>();
            UnitsInitialize(printUnits);

            foreach (MarkPrintUnit unit in printUnits)
            {
                DGV_Name_Gtin.Rows.Add(unit.Nomen, unit.Gtin);
            }

            ResponseData k = Print.PrintSgtinSscc(printUnits);

            if (k.IsSuccess)
            {

            }
            else
            {
                //MessageBox.Show(k.ErrorMessage);
            }
        }

        private void UnitsInitialize(List<MarkPrintUnit> printUnits)
        {
            printUnits.Add(new MarkPrintUnit
            {
                Nomen = "Сыр",
                Gtin = "04630030160342",
                PartyId = 1,
                Ssccs = new Sscc
                {
                    SsccValue = "46500997801035207",
                    ChildSscc = new List<Sscc>
                    {
                       new Sscc {
                                    SsccValue = "46500997801035208",
                                    ParentSscc = "46500997801035207",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE01", "010463003016034221641556169149391EE02" }
                                 },

                       new Sscc {
                                    SsccValue = "46500997801035209",
                                    ParentSscc = "46500997801035207",
                                    Sgtins = new List<string> { "010463003016034221641556169149391EE03", "010463003016034221641556169149391EE04" }
                                 }
                    }
                }
            });
        }

        private void But_SGTIN_print_Click(object sender, System.EventArgs e)
        {
            //Progress_form progress = new Progress_form();
            //progress.ShowDialog();
            TscHelper.Init_printer(driver);
            TscHelper.PrintSgtins(driver, sgtin_values);
            
        }

        private void But_SSCC_print_Click(object sender, System.EventArgs e)
        {
            //TscHelper.Init_printer(driver);
            //TscHelper.PrintSscc(driver, sscc_values);
            Progress_form progress = new Progress_form();
            progress.ShowDialog();
        }

        private void DGV_Name_Gtin_CellClick(object sender, DataGridViewCellEventArgs e)
        { //when you click in some name or gtin then appear their sgtins and sscc 
            try 
            {
                if (DGV_Name_Gtin.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    DGV_Name_Gtin.CurrentRow.Selected = true;                    
                    ViewHelper.GetSgtinANDSscc(sgtin_values, sscc_values, printUnits[e.RowIndex].Ssccs);
                    DGV_Sgtin_Sscc.AutoGenerateColumns = true;
                    DGV_Sgtin_Sscc.DataSource = ViewHelper.Put_dataToDGV(sgtin_values, sscc_values);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Нажмите на продукт");
            }
        }
    }
}
