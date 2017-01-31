using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace PorkShopPOS
{
    class PayrollDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "payroll";
        private const string PAY_NUM = "payCheckNum";
        private const string PAY_EMP_NUM = "payEmpNum";
        private const string FROM_DATE = "payFrom";
        private const string TO_DATE = "payTo";
        private const string HOURS = "payHours";
        private const string AMOUNT = "payAmount";


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
        Function Name:    Add(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Adds a new payroll entry to the database.
        Change History:   2017.30.01  Original version by JED 
        */
        public void Add(Payroll pay)
        {
            try
            {
                // get sql query to add a salary
                String Str = BuildAddQuery(pay);
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
        Function Name:    Delete(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Deletes a payroll entry from the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Delete(Payroll pay)
        {
            try
            {
                // get the sql query to delete a salary
                String Str = BuildDeleteQuery(pay);
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
        public void Update(Payroll pay)
        {
            try
            {
                // get the sql query to update a payroll
                String Str = BuildUpdateQuery(pay);
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
        Function Name:    BuildAddQuery(Payroll pay)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for adding a payroll to the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildAddQuery(Payroll pay)
        {
            strTable = "Insert into " + thisTable;
            strFields = " (" + PAY_EMP_NUM +
                "," + FROM_DATE +
                "," + TO_DATE +
                "," + HOURS +
                "," + AMOUNT +
                ")";
            strValues = " Values ( '" + pay.PayEmpNum +
                         "' , '" + pay.FromDate +
                         "' , '" + pay.ToDate +
                         "' , '" + pay.Hours +
                         "' , " + pay.Amount +
                         " )";

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
        private String BuildDeleteQuery(Payroll pay)
        {
            strTable = "Delete From " + thisTable;
            strFields = " Where (" + PAY_NUM +
                "='" + pay.PayNum + "')";

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
        private String BuildUpdateQuery(Payroll pay)
        {
            strTable = "Update " + thisTable;
            strFields = " Set " + PAY_EMP_NUM + " = '" + pay.PayEmpNum +
                "' ," + FROM_DATE + " = '" + pay.FromDate +
                "' ," + TO_DATE + " = '" + pay.ToDate +
                "' ," + HOURS + " = '" + pay.Hours +
                "' ," + AMOUNT + " = '" + pay.Amount +
                "' Where " + PAY_NUM + " = " + pay.PayNum + "";

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
        public void Search(Payroll pay)
        {

            try
            {
                // create sql 
                string sql = "Select * from " + thisTable + " Where payCheckNum = " + pay.PayNum;

                // connect to database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pay.PayNum = reader.GetInt32(0);
                    pay.PayEmpNum = reader.GetValue(1).ToString();
                    pay.FromDate = reader.GetValue(2).ToString();
                    pay.ToDate = reader.GetValue(3).ToString();
                    pay.Hours = reader.GetDecimal(4);
                    pay.Amount = reader.GetDecimal(5);
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
