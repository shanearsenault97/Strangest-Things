using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS {
    class Tables {
        private string tableNum;

        public string TableNum {
            get { return tableNum; }
            set { tableNum = value; }
        }
        private int tableSeats;

        public int TableSeats {
            get { return tableSeats; }
            set { tableSeats = value; }
        }

        // instantiate a corresponding BooksBusiness data access object
        TablesDAO tableData;

        public Tables() {
            tableData = new TablesDAO();
        }

        public List<string> LoadTables() {
            List<string> lTables = new List<string>();

            lTables = tableData.LoadTables(this);

            return lTables;
        }
    }
}
