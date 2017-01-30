using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    class EmployeeDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$;";
        

        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "employee";
        private const string EMP_NUM = "empNum";
        private const string EMP_F_NAME = "empFName";
        private const string EMP_L_NAME = "empLName";
        private const string EMP_ADDRESS = "empAddress";
        private const string EMP_CITY = "empCity";
        private const string EMP_PROVINCE = "empProv";
        private const string EMP_POSTAL = "empPostal";
        private const string EMP_PHONE = "empPhone";
        private const string EMP_SIN = "empSIN";
        private const string EMP_START_DATE = "empStartDate";
        private const string EMP_STATUS = "empStatus";
        private const string EMP_END_DATE = "empEndDate";
        private const string EMP_POSITION = "empPosition";


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
        Function Name:    Add(BooksBusiness book)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Adds a new employee entry to the database.
        Change History:   2017.30.01  Original version by JED 
        */
        public void Add(Employee emp)
        {
            try
            {
                // get sql query to add an employee 
                String Str = BuildAddQuery(emp);
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
        Author:           Jonathan Deschene
        Description:      Deletes an employee entry from the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Delete(Employee emp)
        {
            try
            {
                // get the sql query to delete an employee
                String Str = BuildDeleteQuery(emp);
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
        Author:           Jonathan Deschene
        Description:      Updates an employee entry in the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Update(Employee emp)
        {
            try
            {
                // get the sql query to update an employee
                String Str = BuildUpdateQuery(emp);
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
        Function Name:    BuildAddQuery(Employee emp)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for adding an enployee to the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildAddQuery(Employee emp)
        {
            strTable = "Insert into " + thisTable;
            strFields = " (" + EMP_NUM +
                "," + EMP_F_NAME +
                "," + EMP_L_NAME +
                "," + EMP_ADDRESS +
                "," + EMP_CITY +
                "," + EMP_PROVINCE +
                "," + EMP_POSTAL +
                "," + EMP_PHONE +
                "," + EMP_SIN +
                "," + EMP_START_DATE +
                "," + EMP_STATUS +
                "," + EMP_END_DATE +
                "," + EMP_POSITION +
                ")";
            strValues = " Values ( '" + emp.EmpNum +
                         "' , '" + emp.EmpFName +
                         "' , '" + emp.EmpLName +
                         "' , '" + emp.EmpAddress +
                         "' , '" + emp.EmpCity +
                         "' , '" + emp.EmpProvince +
                         "' , '" + emp.EmpPostal +
                         "' , '" + emp.EmpPhone +
                         "' , '" + emp.EmpSIN +
                         "' , '" + emp.EmpStartDate +
                         "' , '" + emp.EmpStatus +
                         "' , '" + emp.EmpEndDate +
                         "' , '" + emp.EmpPosition +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        /* 
        Function Name:    BuildDeleteQuery(Employee emp)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for deleting an employee from the database
        Change History:   2017.30.01  Original version by JED 
        */
        private String BuildDeleteQuery(Employee emp)
        {
            strTable = "Delete From " + thisTable;
            strFields = " Where (" + EMP_NUM +
                "='" + emp.EmpNum + "')";

            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    BuildUpdateQuery(Employee empk)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for updating an  in the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildUpdateQuery(Employee emp)
        {
            strTable = "Update " + thisTable;
            strFields = " Set " + EMP_NUM + " = '" + emp.EmpNum +
                "' ," + EMP_F_NAME + " = '" + emp.EmpFName +
                "' ," + EMP_L_NAME + " = '" + emp.EmpLName +
                "' ," + EMP_ADDRESS + " = '" + emp.EmpAddress +
                "' ," + EMP_CITY + " = '" + emp.EmpCity +
                "' ," + EMP_PROVINCE + " = '" + emp.EmpProvince +
                "' ," + EMP_POSTAL + " = '" + emp.EmpPostal +
                "' ," + EMP_PHONE + " = '" + emp.EmpPhone +
                "' ," + EMP_SIN + " = '" + emp.EmpSIN +
                "' ," + EMP_START_DATE + " = '" + emp.EmpStartDate +
                "' ," + EMP_STATUS + " = '" + emp.EmpStatus +
                "' ," + EMP_END_DATE + " = '" + emp.EmpEndDate +
                "' ," + EMP_POSITION + " = '" + emp.EmpPosition +
                " Where (" + EMP_NUM +
                "='" + emp.EmpNum + "')";



           strTotal = strTable + strFields;

           return strTotal;
        }

        /* 
        Function Name:    Search(Employee emp)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Searches the database for an entry based on an employee number
        Change History:   2017.30.01 Original version by JED 
        */
        public void Search(Employee emp)
        {
           
          try
            {
                // create sql 
                string sql = "Select * from " + thisTable + " Where empNum = '" + emp.EmpNum + "'";
                
                // connect ot database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    emp.EmpNum = reader.GetValue(0).ToString();
                    emp.EmpFName = reader.GetValue(1).ToString();
                    emp.EmpLName = reader.GetValue(2).ToString();
                    emp.EmpAddress = reader.GetValue(3).ToString();
                    emp.EmpCity = reader.GetValue(4).ToString();
                    emp.EmpProvince = reader.GetValue(5).ToString();
                    emp.EmpPostal = reader.GetValue(6).ToString();
                    emp.EmpPhone = reader.GetValue(7).ToString();
                    emp.EmpSIN = reader.GetValue(8).ToString();
                    emp.EmpStartDate = reader.GetValue(9).ToString();
                    emp.EmpStatus = reader.GetValue(10).ToString();
                    emp.EmpEndDate = reader.GetValue(11).ToString();
                    emp.EmpPosition = reader.GetValue(12).ToString();
                }


                reader.Close();
                cmd.Dispose();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }
        }
       
    }
}
