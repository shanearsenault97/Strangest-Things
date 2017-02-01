using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS
{
    class Salary
    {
        private int salNum;
        private string salEmpNum;
        private string fromDate;
        private string toDate;
        private decimal amount = 0m;
     

        // instantiate a corresponding Salary data access object
        SalaryDAO salData;

        // this constructor ensures that a corresponding data access object is created for every Salary object
        public Salary()
        {
            salData = new SalaryDAO();
        }

        // 5 getter and setter methods are included below to return and set object fields
        public int SalNum
        {
            get { return this.salNum; }
            set { this.salNum = value; }
        }

        public string EmpNum
        {
            get { return this.salEmpNum; }
            set { this.salEmpNum = value; }
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

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        // calls the add method from the data object layer
        public void Add()
        {
            salData.Add(this);
        }

        // calls the delete method from the data object layer
        public void Delete()
        {
            salData.Delete(this);
        }

        // calls the update method from the data object layer
        public void Update()
        {
            salData.Update(this);
        }

        // calls the search method from the data object layer
        public void Search()
        {
            salData.Search(this);
        }

    }
}
