using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS
{
    class SalaryDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "salary";
        private const string SAL_NUM = "salaryNum";
        private const string SAL_EMP_NUM = "empNum";
        private const string FROM_DATE = "salaryFrom";
        private const string TO_DATE= "salaryTo";
        private const string AMOUNT = "salaryAmount";
       

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
        Function Name:    Add(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Adds a new salary entry to the database.
        Change History:   2017.30.01  Original version by JED 
        */
        public void Add(Salary sal)
        {
            try
            {
                // get sql query to add a salary
                String Str = BuildAddQuery(sal);
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
        Function Name:    Delete(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Deletes a salary entry from the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Delete(Salary sal)
        {
            try
            {
                // get the sql query to delete a salary
                String Str = BuildDeleteQuery(sal);
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
        Function Name:    Update(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Updates a salary entry in the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Update(Salary sal)
        {
            try
            {
                // get the sql query to update a salary
                String Str = BuildUpdateQuery(sal);
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
        Function Name:    BuildAddQuery(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for adding a salary to the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildAddQuery(Salary sal)
        {
            strTable = "Insert into " + thisTable;
            strFields = " (" + SAL_EMP_NUM +
                "," + TO_DATE +
                "," + FROM_DATE +
                "," + AMOUNT +
                ")";
            strValues = " Values ( '" + sal.EmpNum +
                         "' , '" + sal.FromDate +
                         "' , '" + sal.ToDate +
                         "' , " + sal.Amount +
                         " )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        /* 
        Function Name:    BuildDeleteQuery(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for deleting a salary from the database
        Change History:   2017.30.01  Original version by JED 
        */
        private String BuildDeleteQuery(Salary sal)
        {
            strTable = "Delete From " + thisTable;
            strFields = " Where (" + SAL_NUM +
                "='" + sal.SalNum + "')";

            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    BuildUpdateQuery(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for updating an  in the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildUpdateQuery(Salary sal)
        {
            strTable = "Update " + thisTable;
            strFields = " Set " + SAL_EMP_NUM + " = '" + sal.EmpNum +
                "' ," + FROM_DATE + " = '" + sal.FromDate +
                "' ," + TO_DATE + " = '" + sal.ToDate +
                "' ," + AMOUNT + " = '" + sal.Amount +
                "' Where " + SAL_NUM + " = " + sal.SalNum + "";



            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    Search(Salary sal)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Searches the database for an entry based on a salary number
        Change History:   2017.30.01 Original version by JED 
        */
        public void Search(Salary sal)
        {

            try
            {
                // create sql 
                string sql = "Select * from " + thisTable + " Where salaryNum = " + sal.SalNum;

                // connect to database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sal.SalNum = reader.GetInt32(0);
                    sal.EmpNum = reader.GetValue(1).ToString();
                    sal.FromDate = reader.GetValue(2).ToString();
                    sal.ToDate = reader.GetValue(3).ToString();
                    sal.Amount = reader.GetDecimal(4);
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
