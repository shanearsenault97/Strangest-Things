/**
 * User: Noah Gallant
 * Date: 2/16/2017
 * Time: 6:05 PM
 * Purpose: The purpose of this class is to store bar information
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS {
    class Bar {
        private string barId;

        public string BarId {
            get { return barId; }
            set { barId = value; }
        }
        private string barDescription;

        public string BarDescription {
            get { return barDescription; }
            set { barDescription = value; }
        }
        private string barType;

        public string BarType {
            get { return barType; }
            set { barType = value; }
        }
        private string barPrice;

        public string BarPrice {
            get { return barPrice; }
            set { barPrice = value; }
        }
        private string barQOH;

        public string BarQOH {
            get { return barQOH; }
            set { barQOH = value; }
        }

        BarDAO barData;

        public Bar() {
            barData = new BarDAO();
        }

        //Calls the Search method from the data object layer
        public void Search() {
            barData.Search(this);
        }
    }
}
