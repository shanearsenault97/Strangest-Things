using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PorkShopPOS
{
    class TimeClock
    {
        private int timeClockNum;
        private string empNum;
        private DateTime shiftDate;
        private DateTime clockIn;
        private DateTime clockOut;
        private DateTime fromDate;
        private DateTime toDate;
        private decimal empHours;


        // instantiate a corresponding TimeClockDAO data access object
        TimeClockDAO tcData;

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: TimeClock class
        */
        public TimeClock()
        {
            tcData = new TimeClockDAO();
        }

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: 8 getter and setter methods are included below to return and set object fields
        */
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

        public DateTime FromDate
        {
            get { return this.fromDate; }
            set { this.fromDate = value; }
        }
        public DateTime ToDate
        {
            get { return this.toDate; }
            set { this.toDate = value; }
        }

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: calls the add method from the data object layer
        */

        public void Add()
        {
            tcData.Add(this);
        }
        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: calls the delete method from the data object layer
        */
        public void Delete()
        {
            tcData.Delete(this);
        }
        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: calls the update method from the data object layer
      */

        public void Update()
        {
            tcData.Update(this);
        }

        // calls the update EmpHours method from the data object layer

        /* public void UpdateEmpHours()
        {
            tcData.UpdateEmpHours(this);
        }
         
        */
        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: calls the search method from the data object layer
      */
        public void Search()
        {
            tcData.Search(this);
        }
        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: calls the search dates method from the data object layer
      */
        public void SearchDateHistory(DateTime fromDate, DateTime toDate, DataGridView dgv)
        {
            tcData.SearchDateHistory(fromDate, toDate, dgv);


        }
    }
}
