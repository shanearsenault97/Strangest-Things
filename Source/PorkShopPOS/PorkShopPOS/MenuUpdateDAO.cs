using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS
{
    class MenuUpdateDAO
    {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string THIS_TABLE = "food";
        private const string FOOD_NUM = "foodNum";
        private const string FOOD_NAME = "foodDescription";
        private const string FOOD_TYPE = "foodType";
        private const string FOOD_PRICE = "foodPrice";


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
        Function Name:    Add(MenuUpdate menu)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Adds a new menu entry to the database.
        Change History:   2017.30.01  Original version by JED 
        */
        public void Add(MenuUpdate menu)
        {
            try
            {
                // get sql query to add a salary
                String Str = BuildAddQuery(menu);
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
        Description:      Deletes a menu entry from the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Delete(MenuUpdate menu)
        {
            try
            {
                // get the sql query to delete a salary
                String Str = BuildDeleteQuery(menu);
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
        Function Name:    Update(MenuUpdate menu)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Updates a menu entry in the database.
        Change History:   2017.30.01 Original version by JED 
        */
        public void Update(MenuUpdate menu)
        {
            try
            {
                // get the sql query to update a salary
                String Str = BuildUpdateQuery(menu);
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
        Function Name:    BuildAddQuery(MenuUpdate menu)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for adding a menu entry to the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildAddQuery(MenuUpdate menu)
        {
            strTable = "Insert into " + THIS_TABLE;
            strFields = " (" + FOOD_NUM +
                "," + FOOD_NAME +
                "," + FOOD_TYPE +
                "," + FOOD_PRICE +
                ")";
            strValues = " Values ( '" + menu.FoodNum +
                         "' , '" + menu.FoodName +
                         "' , '" + menu.FoodType +
                         "' , " + menu.FoodPrice +
                         " )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        /* 
        Function Name:    BuildDeleteQuery(MenuUpdate menu)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for deleting a menu entry from the database
        Change History:   2017.30.01  Original version by JED 
        */
        private String BuildDeleteQuery(MenuUpdate menu)
        {
            strTable = "Delete From " + THIS_TABLE;
            strFields = " Where (" + FOOD_NUM +
                "='" + menu.FoodNum + "')";

            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    BuildUpdateQuery(MenuUpdate menu)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Provides sql query for updating a menu entry in the database
        Change History:   2017.30.01 Original version by JED 
        */
        private String BuildUpdateQuery(MenuUpdate menu)
        {
            strTable = "Update " + THIS_TABLE;
            strFields = " Set " + FOOD_NAME + " = '" + menu.FoodName +
                "' ," + FOOD_TYPE + " = '" + menu.FoodType +
                "' ," + FOOD_PRICE + " = '" + menu.FoodPrice +
                "' Where " + FOOD_NUM+ " = " + menu.FoodNum + "";



            strTotal = strTable + strFields;

            return strTotal;
        }

        /* 
        Function Name:    Search(MenuUpdate menu)
        Version:          1
        Author:           Jonathan Deschene
        Description:      Searches the database for a menu entry based on a foodNum
        Change History:   2017.30.01 Original version by JED 
        */
        public void Search(MenuUpdate menu)
        {

            try
            {
                // create sql 
                string sql = "Select * from " + THIS_TABLE + " Where " + FOOD_NUM + " = " + menu.FoodNum + ";";

                // connect to database

                MySqlConnection conn = new MySqlConnection(connectionStr);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    menu.FoodNum = reader.GetValue(0).ToString();
                    menu.FoodName = reader.GetValue(1).ToString();
                    menu.FoodType = reader.GetValue(2).ToString();
                    menu.FoodPrice = reader.GetDecimal(3);
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
