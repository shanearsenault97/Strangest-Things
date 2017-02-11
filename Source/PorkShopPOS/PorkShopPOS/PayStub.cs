using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PorkShopPOS
{
    public partial class PayStub : Form
    {
        public PayStub()
        {
            InitializeComponent();
        }

        // populate fields with data based on BackOffice user input
        private void PayStub_Load(object sender, EventArgs e)
        {
            empNumLab.Text = BackOffice.empNum;
            periodEndingLab.Text = BackOffice.endDate;
            string empNum = empNumLab.Text;
            string endDate = periodEndingLab.Text;


            Employee anEmployee = new Employee();
            anEmployee.EmpNum = empNumLab.Text;
            anEmployee.Search();
            fNameLab.Text = anEmployee.EmpFName;
            lNameLab.Text = anEmployee.EmpLName;

            Payroll aPayroll = new Payroll();
            aPayroll.EmpNum = empNum;
            aPayroll.ToDate = endDate;
            aPayroll.searchForPayStub();
            payNumLab.Text = aPayroll.PayNum.ToString();

           
        }

        // close the form
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //print preview
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

            printPayStub.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
            printPayStub.Print();
        }

        // save the payStub
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        

      

        
    }
}
