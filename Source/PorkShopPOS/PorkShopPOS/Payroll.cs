using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        // instantiate a corresponding Payroll data access object
        PayrollDAO payData;

        // this constructor ensures that a corresponding data access object is created for every Payroll object
        public Payroll()
        {
            payData = new PayrollDAO();
        }

        // 6 getter and setter methods are included below to return and set object fields
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
    }
}
