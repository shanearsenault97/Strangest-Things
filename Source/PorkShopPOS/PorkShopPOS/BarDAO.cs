using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS {
    class BarDAO {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "bar";
        private const string BAR_ID = "barId";
        private const string BAR_DESCRIPTION = "barDescription";
        private const string BAR_TYPE = "barType";
        private const string BAR_PRICE = "barPrice";
        private const string BAR_QOH = "barQOH";

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

        //Search the salespeople in the database with the salesperson name
        public void Search(Bar bar) {
            String Str = BuildSearchQuery(bar);

            //Try catch for database connection error validation
            try {
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                MySqlDataReader MySqlReader = cmd.ExecuteReader();

                while (MySqlReader.Read()) {
                    bar.BarId = MySqlReader.GetValue(0).ToString();
                    bar.BarPrice = MySqlReader.GetValue(3).ToString();
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
        private String BuildSearchQuery(Bar bar) {
            strTable = "Select * from " + thisTable;
            strFields = " Where " + BAR_DESCRIPTION + " = '" + bar.BarDescription + "'";

            strTotal = strTable + strFields;

            return strTotal;
        }
    }
}
