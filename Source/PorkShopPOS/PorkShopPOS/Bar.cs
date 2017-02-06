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

        public void Search() {
            barData.Search(this);
        }
    }
}
