using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS {
    class TablesDAO {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "tables";
        private const string TABLE_NUM = "tableNum";
        private const string TABLE_SEATS = "tableSeats";

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

        public List<string> LoadTables(Tables table) {
            List<string> tables = new List<string>();

            String Str = BuildLoadTablesQuery(table);
            OpenConn();

            MySqlCommand cmd = new MySqlCommand(Str, conn);

            MySqlDataReader MySqlReader = cmd.ExecuteReader();

            while (MySqlReader.Read()) {
                tables.Add(MySqlReader.GetValue(1).ToString());
            }

            MySqlReader.Close();
            cmd.Dispose();
            CloseConn();

            return tables;
        }

        private String BuildLoadTablesQuery(Tables table) {
            // create sql 
            strTable = "Select * from " + thisTable + ";";

            strTotal = strTable;

            return strTotal;
        }
    }
}
