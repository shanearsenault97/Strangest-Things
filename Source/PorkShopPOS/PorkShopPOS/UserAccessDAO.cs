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
        private const string thisTable = "useraccess";
        private const string EMP_NUM = "empNum";
        private const string PASSWORD = "password";
        private const string USER_TYPE_CODE = "userTypeCode";


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
                string sql = "Select * from " + thisTable + " Where empNum = '" + login.Emp_Num + "'";

                // connect ot database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    login.Emp_Num = reader.GetValue(0).ToString();
                    login.password = reader.GetValue(1).ToString();
                    login.User_Type_Code = reader.GetInt32(2);
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
                "," + USER_TYPE_CODE +
                ")";
            strValues = " Values ( '" + login.Emp_Num +
                         "' , '" + login.password +
                         "' , '" + 1 +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

    }
}
