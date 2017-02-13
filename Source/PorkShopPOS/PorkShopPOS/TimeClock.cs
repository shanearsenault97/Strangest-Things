using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS
{
    class TimeClock
    {
        private int timeClockNum;
        private string empNum;
        private DateTime shiftDate;
        private DateTime clockIn;
        private DateTime clockOut;
        private string fromDate;
        private string toDate;
        private decimal empHours;


        // instantiate a corresponding BooksBusiness data access object
        TimeClockDAO tcData;

        // this constructor ensures that a corresponding data access object is created for every BooksBusiness object
        public TimeClock()
        {
            tcData = new TimeClockDAO();
        }

        // 6 getter and setter methods are included below to return and set object fields
        public int TimeClockNum
        {
            get { return this.timeClockNum; }
            set { this.timeClockNum = value; }
        }
        
        public string EmpNum
        {
            get { return this.empNum; }
            set { this.empNum = value; }
        }

        public DateTime ShiftDate
        {
            get { return this.shiftDate; }
            set { this.shiftDate = value; }
        }

        public DateTime ClockIn
        {
            get { return this.clockIn; }
            set { this.clockIn = value; }
        }

        public DateTime ClockOut
        {
            get { return this.clockOut; }
            set { this.clockOut = value; }
        }

        public decimal EmpHours
        {
            get { return this.empHours; }
            set { this.empHours = value; }
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
       


        // calls the add method from the data object layer
        public void Add()
        {
            tcData.Add(this);
        }

        // calls the delete method from the data object layer
        public void Delete()
        {
            tcData.Delete(this);
        }

        // calls the update method from the data object layer
        public void Update()
        {
            tcData.Update(this);
        }
        
        // calls the update EmpHours method from the data object layer
        public void UpdateEmpHours()
        {
            tcData.UpdateEmpHours(this);
        }
        
        // calls the search method from the data object layer
        public void Search()
        {
          tcData.Search(this);
        }

        public List<string> LoadEmployees()
        {
            List<string> lEmployees = new List<string>();

            //  lEmployees = tcData.LoadEmployees(this);

            return lEmployees;
        }

    }
    
}
