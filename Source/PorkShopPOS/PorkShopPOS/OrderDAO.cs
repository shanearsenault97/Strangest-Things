/**
 * User: Noah Gallant
 * Date: 2/16/2017
 * Time: 6:05 PM
 * Purpose: The purpose of this class is to access the order table from the DB
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS {
    class OrderDAO {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "customerorders";
        private const string ORDER_NUM = "orderNum";
        private const string EMP_NUM = "empNum";
        private const string TABLE_NUM = "tableNum";
        private const string ORDER_DATE = "orderDate";
        private const string ORDER_TIME = "orderTime";
        private const string NUM_GUESTS = "numGuests";
        private const string ORDER_TOTAL = "orderTotal";
        private const string ORDER_GRATUITY = "orderGratuity";

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

        //Adds an order
        public void Add(Order order) {
            try {
                // get sql query to add an order 
                String Str = BuildAddQuery(order);
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                cmd.ExecuteNonQuery();

                CloseConn();
            } catch (Exception ex) {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }

        }

        //Searches for order information
        public void Search(Order order) {
            String Str = BuildSearchQuery(order);

            //Try catch for database connection error validation
            try {
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                MySqlDataReader MySqlReader = cmd.ExecuteReader();

                while (MySqlReader.Read()) {
                    order.OrderNum = MySqlReader.GetValue(0).ToString();
                }

                MySqlReader.Close();
                cmd.Dispose();
                CloseConn();
            } catch {
                //Display error message if DB connection fails
                MessageBox.Show("Connection to the database has failed.", "Database Connection Error");
            }
        }

        //Builds the query for the Add method
        private String BuildAddQuery(Order order) {
            strTable = "Insert into " + thisTable;
            strFields = " (" + ORDER_NUM +
                "," + EMP_NUM +
                "," + TABLE_NUM +
                "," + ORDER_DATE +
                "," + ORDER_TIME +
                "," + NUM_GUESTS +
                "," + ORDER_TOTAL +
                ")";
            strValues = " Values ( " + "NULL" +
                         " , '" + order.EmpNum +
                         "' , '" + order.TableNum +
                         "' , '" + order.OrderDate +
                         "' , '" + order.OrderTime +
                         "' , '" + order.NumGuests +
                         "' , '" + order.OrderTotal +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }

        //Builds the query for the Search method
        private String BuildSearchQuery(Order order) {
            strTable = "Select * from " + thisTable;
            strFields = " where " + ORDER_DATE + " = '" + order.OrderDate + "' AND " + ORDER_TIME + " = '" + order.OrderTime + "' AND " + ORDER_TOTAL + " = '" + order.OrderTotal + "'";

            strTotal = strTable + strFields;

            return strTotal;
        }
    }
}
