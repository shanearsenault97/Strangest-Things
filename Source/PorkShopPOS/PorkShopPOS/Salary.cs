using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

        // calls the getMostCurrentSal() method from the data object layer
        public void getMostCurrentSal()
        {
            salData.getMostCurrentSal(this);
        }

        // calls the salary list report from the data object layer
        public void salaryList()
        { 
            salData.salaryList();
        }

        // calls the salary history report from the data object layer
        public void salaryHistory(string empNum, DataGridView dgv)
        {
            salData.salaryHistory(empNum, dgv);
        }
    }
}
