using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS {
    class Food {
        private string foodNum;

        public string FoodNum {
            get { return foodNum; }
            set { foodNum = value; }
        }

        private string foodDescription;

        public string FoodDescription {
            get { return foodDescription; }
            set { foodDescription = value; }
        }
        private string foodType;

        public string FoodType {
            get { return foodType; }
            set { foodType = value; }
        }
        private string foodPrice;

        public string FoodPrice {
            get { return foodPrice; }
            set { foodPrice = value; }
        }

        FoodDAO foodData;

        public Food() {
            foodData = new FoodDAO();
        }

        public void Search() {
            foodData.Search(this);
        }
    }
}
