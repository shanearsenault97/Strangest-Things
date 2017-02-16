using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.Data;

namespace PorkShopPOS
{
    class TimeClockDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero DateTime = True; Allow Zero DateTime=True; ";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";
        private string sql = "";

        // database table name and fields
        private const string thisTable = "timeclock";
        private const string TIME_CLOCK_NUM = "timeClockNum";    
        private const string EMP_NUM = "empNum";
        private const string SHIFT_DATE = "shiftDate";
        private const string CLOCK_IN = "clockIn";
        private const string CLOCK_OUT = "clockOut";
        private const string EMP_HOURS = "empHours";



        /* 
        Function Name:    OpenConn()
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Creates a new database connection.
        Change History:   2017.30.01 Original version by JED 
        */
        private void OpenConn()
        {
            try
            {
                String connStr = connectionStr;
                conn = new MySqlConnection(connStr);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }
        }

        /* 
        Function Name:    Add(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Adds a new clock in entry to the database.
        Change History:   2017.30.01  Original version by JED 
        */
        public void Add(TimeClock time)
        {
            try
            {
                // get sql query to add an employee 
                String Str = BuildAddQuery(time);
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                cmd.ExecuteNonQuery();

                CloseConn();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }

        }

        /* 
        Function Name:    Delete(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Deletes an employee entry from the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Delete(TimeClock time)
        {
            try
            {
                // get the sql query to delete an employee
                String Str = BuildDeleteQuery(time);
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                cmd.ExecuteNonQuery();

                CloseConn();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }

        }

        /* 
        Function Name:    Update(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Updates clock out time of employee in the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Update(TimeClock time)
        {
            try
            {
                // get the sql query to update an employee
                String Str = BuildUpdateQuery(time);
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                cmd.ExecuteNonQuery();

                CloseConn();
            }

            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        
        /* 
        Function Name:    LoadTimeClock(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Loads Timeclock from database
        Change History:   2017.30.01 Original version by JED 
        */

        public List<string> LoadTimeClock(TimeClock time)
        {
            List<string> timeclock = new List<string>();

            String Str = BuildLoadTimeClockQuery(time);
            OpenConn();

            MySqlCommand cmd = new MySqlCommand(Str, conn);

            MySqlDataReader MySqlReader = cmd.ExecuteReader();

            while (MySqlReader.Read())
            {
                timeclock.Add(MySqlReader.GetValue(1).ToString() + " " + MySqlReader.GetValue(2).ToString());
            }

            MySqlReader.Close();
            cmd.Dispose();
            CloseConn();

            return timeclock;
        }

        /* 
        Function Name:    CloseConn()
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Closes database connection.
        Change History:   2017.20.01 Original version by JED 
        */
        private void CloseConn()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }
        }

        /* 
        Function Name:    BuildAddQuery(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Provides sql query for clocking in to the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildAddQuery(TimeClock time)
        {
            strTable = "Insert into " + thisTable;
            strFields = " (" + EMP_NUM +
                "," + SHIFT_DATE +
                "," + CLOCK_IN +
                "," + CLOCK_OUT +
                ")";
            strValues = " Values ( '" + time.EmpNum +
                         "' , '" + time.ShiftDate +
                         "' , '" + time.ClockIn +
                         "' , '" + time.ClockOut +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        /* 
        Function Name:    BuildDeleteQuery(Employee emp)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Provides sql query for deleting a time clock entry from the database
        Change History:   2017.30.01  Original version by JED 
        */
        private String BuildDeleteQuery(TimeClock time)
        {
            strTable = "Delete From " + thisTable;
            strFields = " Where timeClockNum = '" + time.TimeClockNum + "';";
     
            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    BuildUpdateQuery(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Provides sql query for updating clock out time in the database
        Change History:   2017.30.01 Original version by JED 
        */
        
        private String BuildUpdateQuery(TimeClock time)
        {
            strTable = "Update " + thisTable;
            strFields = " Set " + EMP_NUM + " = '" + time.EmpNum +
                 "', " + SHIFT_DATE + " = '" + time.ShiftDate +
                 "', " + CLOCK_OUT + " = '" + time.ClockOut +
               "', " + CLOCK_IN + " = '" + time.ClockIn +              
                "' Where " + TIME_CLOCK_NUM + " = '" + time.TimeClockNum + "'";
            strTotal = strTable + strFields;

            return strTotal;
        }
        /* 
      Function Name:    SearchDateHistory(DateTime toDate, DateTime FromDate, DataGridView dgv)
      Version:          1
      Author:           Bryan MacFarlane
      Description:      Searches the database for an entry based on the from/to date inputed
      Change History:   2017.30.01 Original version by JED 
      */
        public void SearchDateHistory(DateTime schFromDate, DateTime schToDate, DataGridView dgv)
        {

            DataTable dataTable;
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataAdapter da;
            dataTable = new DataTable();
            dataTable.Clear();


            sql = "Select * from timeclock where shiftDate BETWEEN" + "'" + schFromDate + "' AND '" + schToDate + "'";
            

            try
            {
                conn = new MySqlConnection(connectionStr);
                conn.Open();
                cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandText = sql
                };
                cmd.ExecuteNonQuery();

                da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);

                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

                dgv.DataSource = dataTable;
                dgv.DataMember = dataTable.TableName;
                dgv.AutoResizeColumns();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /* 
        Function Name:    Search(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Searches the database for an entry based on an employee number
        Change History:   2017.30.01 Original version by JED 
        */
        public void Search(TimeClock time)
        {

            try
            {
                // create sql 
                //string sql = "Select * from " + thisTable + " Where  empNum = '" + time.EmpNum + 
                //    "' AND shiftDate = '" + time.ShiftDate + "';";

                string sql = "Select * from " + thisTable + " Where  timeClockNum = '" + time.TimeClockNum + "';";

                // connect to database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    time.TimeClockNum = reader.GetInt16(0);
                    time.EmpNum = reader.GetValue(1).ToString();
                    time.ShiftDate = reader.GetDateTime(2);
                    time.ClockIn = DateTime.Parse(reader.GetValue(3).ToString());
                    time.ClockOut = reader.GetDateTime(4);                    
                }
                
                reader.Close();
                cmd.Dispose();
                conn.Close();
            }

            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        /* 
        Function Name:    BuildLoadTimeClockQuery(TimeClock time)
        Version:          1
        Author:           Bryan MacFarlane
        Description:      Builds query for loading timeclock
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildLoadTimeClockQuery(TimeClock time)
        {
            // create sql 
            strTable = "Select * from " + thisTable + ";";

            strTotal = strTable;

            return strTotal;
        }
    }
}
