using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace PorkShopPOS {
    class LineDAO {
        // set up connection data
        private MySqlConnection conn;
        private const string connectionStr = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True; Allow Zero Datetime=True;";
        private string strTable = "";
        private string strFields = "";
        private string strValues = "";
        private string strTotal = "";

        // database table name and fields
        private const string thisTable = "line";
        private const string ORDER_NUM = "orderNum";
        private const string LINE_NUM = "lineNum";
        private const string FOOD_ID = "foodId";
        private const string BAR_ID = "barId";
        private const string LINE_QTY = "lineQty";
        private const string LINE_PRICE = "linePrice";

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

        public void Add(Line line) {
            try {
                // get sql query to add an order 
                String Str = BuildAddQuery(line);
                OpenConn();

                MySqlCommand cmd = new MySqlCommand(Str, conn);

                cmd.ExecuteNonQuery();

                CloseConn();
            } catch (Exception ex) {
                Console.WriteLine("Exception.Message: {0}", ex.Message);
            }

        }

        private String BuildAddQuery(Line line) {
            strTable = "Insert into " + thisTable;
            strFields = " (" + ORDER_NUM +
                "," + LINE_NUM +
                "," + FOOD_ID +
                "," + BAR_ID +
                "," + LINE_QTY +
                "," + LINE_PRICE +
                ")";
            strValues = " Values ( " + line.OrderNum +
                         " , '" + line.LineNum +
                         "' , " + line.FoodId +
                         " , " + line.BarId +
                         " , '" + line.LineQty +
                         "' , '" + line.LinePrice +
                         "' )";

            strTotal = strTable + strFields + strValues;

            return strTotal;
        }
    }
}
