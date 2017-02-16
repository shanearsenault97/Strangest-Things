/**
 * User: Noah Gallant
 * Date: 2/16/2017
 * Time: 6:05 PM
 * Purpose: The purpose of this class is to access the food table from the DB
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS {
    class FoodDAO {

        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "food";
        private const string FOOD_NUM = "foodNum";
        private const string FOOD_DESCRIPTION = "foodDescription";
        private const string FOOD_TYPE = "foodType";
        private const string FOOD_PRICE = "foodPrice";

        private void OpenConn() {
            try {
                String connStr = connectionStr;
                conn = new MySqlConnection(connStr);
                conn.Open();
            } catch (Exception ex) {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }
        }

        private void CloseConn() {
            try {
                conn.Close();
            } catch (Exception ex) {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }
        }

        //Search for food information
        public void Search(Food food) {
            String Str = BuildSearchQuery(food);

            //Try catch for database connection error validation
            try {
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                MySqlDataReader MySqlReader = cmd.ExecuteReader();

                while (MySqlReader.Read()) {
                    food.FoodNum = MySqlReader.GetValue(0).ToString();
                    food.FoodPrice = MySqlReader.GetValue(3).ToString();
                }

                MySqlReader.Close();
                cmd.Dispose();
                CloseConn();
            } catch {
                //Display error message if DB connection fails
                MessageBox.Show("Connection to the database has failed.", "Database Connection Error");
            }
        }

        //Builds the query for the Search method
        private String BuildSearchQuery(Food food) {
            strTable = "Select * from " + thisTable;
            strFields = " Where " + FOOD_DESCRIPTION + " = '" + food.FoodDescription + "'";

            strTotal = strTable + strFields;

            return strTotal;
        }
    }
}
