using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS
{
    class Employee
    {
        private string empNum;
        private string empFName;
        private string empLName;
        private string empAddress;
        private string empCity;
        private string empProvince;
        private string empPostal;        
        private string empPhone;
        private string empSIN;
        private string empStartDate;
        private string empStatus;
        private string empEndDate;
        private string empPosition;

        // instantiate a corresponding BooksBusiness data access object
        EmployeeDAO empData;

        // this constructor ensures that a corresponding data access object is created for every BooksBusiness object
        public Employee()
        {
            empData = new EmployeeDAO();
        }

        // 13 getter and setter methods are included below to return and set object fields
        public string EmpNum
        {
            get { return this.empNum; }
            set { this.empNum = value; }
        }

        public string EmpFName
        {
            get { return this.empFName; }
            set { this.empFName = value; }
        }

        public string EmpLName
        {
            get { return this.empLName; }
            set { this.empLName = value; }
        }

        public string EmpAddress
        {
            get { return this.empAddress; }
            set { this.empAddress = value; }
        }

        public string EmpCity
        {
            get { return this.empCity; }
            set { this.empCity = value; }
        }

        public string EmpProvince
        {
            get { return this.empProvince; }
            set { this.empProvince = value; }
        }

        public string EmpPostal
        {
            get { return this.empPostal; }
            set { this.empPostal = value; }
        }

        public string EmpPhone
        {
            get { return this.empPhone; }
            set { this.empPhone = value; }
        }

        public string EmpSIN
        {
            get { return this.empSIN; }
            set { this.empSIN = value; }
        }

        public string EmpStartDate
        {
            get { return this.empStartDate; }
            set { this.empStartDate = value; }
        }

        public string EmpStatus
        {
            get { return this.empStatus; }
            set { this.empStatus = value; }
        }

        public string EmpEndDate
        {
            get { return this.empEndDate; }
            set { this.empEndDate = value; }
        }

        public string EmpPosition
        {
            get { return this.empPosition; }
            set { this.empPosition = value; }
        }

        // calls the add method from the data object layer
        public void Add()
        {
            empData.Add(this);
        }

        // calls the delete method from the data object layer
        public void Delete()
        {
            empData.Delete(this);
        }

        // calls the update method from the data object layer
        public void Update()
        {
            empData.Update(this);
        }

        // calls the search method from the data object layer
        public void Search()
        {
            empData.Search(this);
        }

        public void SearchByName() {
            empData.SearchByName(this);
        }

        public List<string> LoadEmployees() {
            List<string> lEmployees = new List<string>();

            lEmployees = empData.LoadEmployees(this);

            return lEmployees;
        }

    }
}
