using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PorkShopPOS
{
    class UserAccessDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "userAccess";
        private const string ACCOUNT_ID = "accountId";
        private const string EMP_NUM = "empNum";
        private const string PASSWORD = "password";
        private const string TYPE = "userTypeCode";


        /* 
        Function Name:    OpenConn()
        Version:          1
        Author:           Jonathan Deschene
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
           Function Name:    CloseConn()
           Version:          1
           Author:           Jonathan Deschene
           Description:      Closes database connection.
           Change History:   2016.05.12 Original version by JED 
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
        Function Name:    Login(UserAccess login)
        Version:          1
        Author:           Heather Watterson
        Description:      Retrieves the entry from the database based on employee number
        Change History:   2017.01.02 Original version by JED 
        */
        public void Login(UserAccess login)
        {

            try
            {
                // create sql 
                string sql = "Select * from " + thisTable + " Where empNum = '" + login.EmpNum + "'";

                // connect ot database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    login.AccountId = reader.GetInt16(0);
                    login.EmpNum = reader.GetValue(1).ToString();
                    login.Password = reader.GetValue(2).ToString();
                    login.Type = reader.GetInt32(3);
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


        public void Add(UserAccess login)
        {
            try
            {
                // get sql query to add an employee 
                String Str = BuildAddQuery(login);
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
        Function Name:    Delete(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Deletes a payroll entry from the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Delete(UserAccess access)
        {
            try
            {
                // get the sql query to delete a salary
                String Str = BuildDeleteQuery(access);
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
        Function Name:    Update(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Updates a payroll entry in the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Update(UserAccess access)
        {
            try
            {
                // get the sql query to update a payroll
                String Str = BuildUpdateQuery(access);
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
       Function Name:    BuildAddQuery(UserAccess login)
       Version:          1
       Author:           Jonathan Deschene
       Description:      Provides sql query for adding an enployee to the database
       Change History:   2017.30.01 Original version by JED 
       */
        private String BuildAddQuery(UserAccess login)
        {
            strTable = "Insert into " + thisTable;
            strFields = " (" + EMP_NUM +
                "," + PASSWORD +
                "," + TYPE +
                ")";
            strValues = " Values ( '" + login.EmpNum +
                         "' , '" + login.Password +
                         "' , '" + login.Type +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        /* 
        Function Name:    BuildDeleteQuery(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for deleting a payroll from the database
        Change History:   2017.30.01  Original version by JED 
        */
        private String BuildDeleteQuery(UserAccess access)
        {
            strTable = "Delete From " + thisTable;
            strFields = " Where (" + ACCOUNT_ID +
                "= '" + access.AccountId + "')";

            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    BuildUpdateQuery(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for updating an payroll in the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildUpdateQuery(UserAccess access)
        {
            strTable = "Update " + thisTable;
            strFields = " Set " + EMP_NUM + " = '" + access.EmpNum +
                "' ," + PASSWORD + " = '" + access.Password +
                "' ," + TYPE + " = '" + access.Type +
                "' Where " + ACCOUNT_ID + " = " + access.AccountId + "";

            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    Search(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Searches the database for an entry based on a payroll number
        Change History:   2017.30.01 Original version by JED 
        */
        public void Search(UserAccess access)
        {

            try
            {
                // create sql 
                string sql = "Select * from " + thisTable + " Where " + ACCOUNT_ID + " = " + access.AccountId;

                // connect to database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    access.AccountId = reader.GetInt32(0);
                    access.EmpNum = reader.GetValue(1).ToString();
                    access.Password = reader.GetValue(2).ToString();
                    access.Type = reader.GetInt16(3);            
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

    }
}
