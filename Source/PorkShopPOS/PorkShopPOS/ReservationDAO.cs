using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS
{
    class ReservationDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "reservation";
        private const string RES_ID = "reservationId";
        private const string TAB_NUM = "tableNum";
        private const string RES_DATE = "reservationDate";
        private const string RES_TIME = "reservationTime";
        private const string RES_NAME = "reservationName";
        private const string RES_CONTACT = "reservationContact";


        /* 
        Function Name:    OpenConn()
        Version:          1
        Author:           Shane Arsenault
        Description:      Creates a new database connection.
        Change History:   2017.30.01 Original version by JED 
        *                 2017.06.02 Adapted by SMA
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
        Function Name:    Add(BooksBusiness book)
        Version:          1
        Author:           Shane Arsenault
        Description:      Adds a new employee entry to the database.
        Change History:   2017.30.01  Original version by JED
         * *                 2017.06.02 Adapted by SMA
        */
        public void Add(Reservation res)
        {
            try
            {
                // get sql query to add an employee 
                String Str = BuildAddQuery(res);
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
        Function Name:    Delete(Employee emp)
        Version:          1
        Author:           Shane Arsenault
        Description:      Deletes an employee entry from the database.
        Change History:   2017.30.01 Original version by JED 
         * *                 2017.06.02 Adapted by SMA
        */
        public void Delete(Reservation res)
        {
            try
            {
                // get the sql query to delete an employee
                String Str = BuildDeleteQuery(res);
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
        Function Name:    Update(Employee emp)
        Version:          1
        Author:           Shane Arsenault
        Description:      Updates an employee entry in the database.
        Change History:   2017.30.01 Original version by JED 
         * *                 2017.06.02 Adapted by SMA
        */
        public void Update(Reservation res)
        {
            try
            {
                // get the sql query to update an employee
                String Str = BuildUpdateQuery(res);
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

        public List<string> LoadReservations(Reservation res)
        {
            List<string> employee = new List<string>();

            String Str = BuildLoadEmployeesQuery(res);
            OpenConn();

            MySqlCommand cmd = new MySqlCommand(Str, conn);

            MySqlDataReader MySqlReader = cmd.ExecuteReader();

            while (MySqlReader.Read()) {
                employee.Add(MySqlReader.GetValue(1).ToString() + " " + MySqlReader.GetValue(2).ToString());
            }

            MySqlReader.Close();
            cmd.Dispose();
            CloseConn();

            return employee;
        }

        /* 
        Function Name:    CloseConn()
        Version:          1
        Author:           Shane Arsenault
        Description:      Closes database connection.
        Change History:   2016.05.12 Original version by JED
         * *                 2017.06.02 Adapted by SMA
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
        Function Name:    BuildAddQuery(Employee emp)
        Version:          1
        Author:           Shane Arsenault
        Description:      Provides sql query for adding an enployee to the database
        Change History:   2017.30.01 Original version by JED 
         * *                 2017.06.02 Adapted by SMA
        */
        private String BuildAddQuery(Reservation res)
        {
            strTable = "Insert into " + thisTable;
            strFields = " ("  +
                TAB_NUM +
                "," + RES_DATE +
                "," + RES_TIME +
                "," + RES_NAME +
                "," + RES_CONTACT +
                ")";
            strValues = " Values ( '" + res.TableNum +
                         "' , '" + res.ReservationDate +
                         "' , '" + res.ReservationTime +
                         "' , '" + res.ReservationName +
                         "' , '" + res.ReservationContact +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        /* 
        Function Name:    BuildDeleteQuery(Employee emp)
        Version:          1
        Author:           Shane Arsenault
        Description:      Provides sql query for deleting an employee from the database
        Change History:   2017.30.01  Original version by JED 
         * *                 2017.06.02 Adapted by SMA
        */
        private String BuildDeleteQuery(Reservation res)
        {
            strTable = "Delete From " + thisTable;
            strFields = " Where (" + RES_ID +
                "='" + res.ReservationID + "')";

            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    BuildUpdateQuery(Employee empk)
        Version:          1
        Author:           Shane Arsenault
        Description:      Provides sql query for updating an  in the database
        Change History:   2017.30.01 Original version by JED 
         * *                 2017.06.02 Adapted by SMA
        */
        private String BuildUpdateQuery(Reservation res)
        {
            strTable = "Update " + thisTable;
            strFields = " Set " + RES_ID + " = '" + res.ReservationID +
                "' ," + TAB_NUM + " = '" + res.TableNum +
                "' ," + RES_DATE + " = '" + res.ReservationDate +
                "' ," + RES_TIME + " = '" + res.ReservationTime +
                "' ," + RES_NAME + " = '" + res.ReservationName +
                "' ," + RES_CONTACT + " = '" + res.ReservationContact +
                "' Where " + RES_ID + " = '" + res.ReservationID + "'";



           strTotal = strTable + strFields;

           return strTotal;
        }

        /* 
        Function Name:    Search(Employee emp)
        Version:          1
        Author:           Shane Arsenault
        Description:      Searches the database for an entry based on an employee number
        Change History:   2017.30.01 Original version by JED 
         * *                 2017.06.02 Adapted by SMA
        */
        public void Search(Reservation res)
        {
           
          try
            {
                // create sql 
                string sql = "Select * from " + thisTable + " Where empNum = '" + res.ReservationID + "'";
                
                // connect ot database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    res.ReservationID = Int32.Parse(reader.GetValue(0).ToString());
                    res.TableNum = reader.GetValue(1).ToString();
                    res.ReservationDate = reader.GetValue(2).ToString();
                    res.ReservationTime = reader.GetValue(3).ToString();
                    res.ReservationName = reader.GetValue(4).ToString();
                    res.ReservationContact = reader.GetValue(5).ToString();
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

        private String BuildLoadEmployeesQuery(Reservation res)
        {
            // create sql 
            strTable = "Select * from " + thisTable + ";";

            strTotal = strTable;

            return strTotal;
        }
       
    }
    }

