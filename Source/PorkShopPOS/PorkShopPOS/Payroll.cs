/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Business layer class for Payroll object
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PorkShopPOS
{
    class Payroll
    {
        private int payNum;
        private string empNum;
        private string fromDate;
        private string toDate;
        private decimal hours = 0m;
        private decimal amount = 0m;
        private const decimal CPP_RATE = 0.0495m; // correct rate for 2017
        private const decimal EI_RATE = 0.0163m; // correct rate for 2017
        private const decimal FEDERAL_TAX_RATE = 0.25m; // using a made up rate
        private const decimal VACATION_PAY_RATE = 0.04m; // using a made up rate
        private decimal cppDeduction = 0.0m;
        private decimal eiDeduction = 0.0m;
        private decimal federalTaxDeduction = 0.0m;
        private decimal vacationPay = 0.0m;
        private decimal netPay = 0.0m;
        private Salary aSalary;
        private decimal salaryRate = 0.0m;


        // instantiate a corresponding Payroll data access object
        PayrollDAO payData;

        // this constructor ensures that a corresponding data access object is created for every Payroll object
        public Payroll()
        {
            payData = new PayrollDAO();
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: Calculate deductions, vacation pay and net pay
        */
        public void calcPayDetails() 
        {
            try
            {
                //calculate cpp deduction
                this.cppDeduction = this.amount * CPP_RATE;

                //calculate EI deduction
                this.eiDeduction = this.amount * EI_RATE;

                //calculate federal tax deduction
                this.federalTaxDeduction = this.amount * FEDERAL_TAX_RATE;

                //calculate vacation pay
                this.vacationPay = this.amount * VACATION_PAY_RATE;

                //calculate net pay
                this.netPay = (((this.amount - this.cppDeduction) - this.eiDeduction) - this.federalTaxDeduction) + this.vacationPay;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: get the most current salary that shares the Payroll empNum
        */
        public void getSalary()
        {
            try
            {
                aSalary = new Salary();
                aSalary.EmpNum = this.empNum;
              
                // a salary that has a toDate other than 0000-00-00 should not be current
                aSalary.ToDate = "0000-00-00";

                aSalary.getMostCurrentSal();
                salaryRate = aSalary.Amount;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
                
        }

        // 12 getter and setter methods are included below to return and set object fields
        public int PayNum
        {
            get { return this.payNum; }
            set { this.payNum = value; }
        }

        public string EmpNum
        {
            get { return this.empNum; }
            set { this.empNum = value; }
        }

        public string FromDate
        {
            get { return this.fromDate; }
            set { this.fromDate = value; }
        }

        public string ToDate
        {
            get { return this.toDate; }
            set { this.toDate = value; }
        }

        public decimal Hours
        {
            get { return this.hours; }
            set { this.hours = value; }
        }

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        public decimal CppDeduction
        {
            get { return this.cppDeduction; }
            set { this.amount = value; }
        }
        public decimal EiDeduction
        {
            get { return this.eiDeduction; }
            set { this.eiDeduction = value; }
        }
        public decimal FederalTaxDeduction
        {
            get { return this.federalTaxDeduction; }
            set { this.federalTaxDeduction = value; }
        }

        public decimal VacationPay
        {
            get { return this.vacationPay; }
            set { this.vacationPay = value; }
        }

        public decimal NetPay
        {
            get { return this.netPay; }
            set { this.netPay = value; }
        }

        public decimal SalaryRate
        {
            get { return this.salaryRate; }
            set { this.salaryRate = value; }
        }

        // calls the add method from the data object layer
        public void Add()
        {
            payData.Add(this);
        }

        // calls the delete method from the data object layer
        public void Delete()
        {
            payData.Delete(this);
        }

        // calls the update method from the data object layer
        public void Update()
        {
            payData.Update(this);
        }

        // calls the search method from the data object layer
        public void Search()
        {
            payData.Search(this);
        }

        // calls searchForPayStub() method from the data object layer
        public void searchForPayStub()
        {
            payData.searchForPayStub(this);
        }
    }
}
