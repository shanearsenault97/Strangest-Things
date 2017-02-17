/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Form that displays pay stub information
*/

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

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: Populate fields with data based on input from BackOffice and calculations done in Payroll
        */
        private void PayStub_Load(object sender, EventArgs e)
        {
            try
            {
                // get the employee number and period ending date from BackOffice and display it
                empNumLab.Text = BackOffice.empNum;
                periodEndingLab.Text = BackOffice.endDate;
                string empNum = empNumLab.Text;
                string endDate = periodEndingLab.Text;

                // create a new Employee object and use the above employee number to get that employee's first and last name
                Employee anEmployee = new Employee();
                anEmployee.EmpNum = empNumLab.Text;
                anEmployee.Search();
                fNameLab.Text = anEmployee.EmpFName;
                lNameLab.Text = anEmployee.EmpLName;

                // create a Payroll object
                Payroll aPayroll = new Payroll();
                aPayroll.EmpNum = empNum;
                aPayroll.ToDate = endDate;

                // call the searhForPayStub() method from Payroll to get and then display the relevant information; 
                aPayroll.searchForPayStub();
                payNumLab.Text = aPayroll.PayNum.ToString();
                grossPayCurrentLab.Text = aPayroll.Amount.ToString("c2");
                hoursLab.Text = aPayroll.Hours.ToString();

                // calll the calcPayDetails() from Payroll to calculate and then dislay the relevant information
                aPayroll.calcPayDetails();
                netPayLab.Text = aPayroll.NetPay.ToString("c2");
                vacPayLab.Text = aPayroll.VacationPay.ToString("c2");
                cppLab.Text = aPayroll.CppDeduction.ToString("c2");
                eiLab.Text = aPayroll.EiDeduction.ToString("c2");
                federalTaxLab.Text = aPayroll.FederalTaxDeduction.ToString("c2");

                // call the getSalary() method to get the employee's rate of pay from the Salary class, and then display the amount
                aPayroll.getSalary();
                rateLab.Text = aPayroll.SalaryRate.ToString("c2");

            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
           
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

        // save the payStub (to be continued...)
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
