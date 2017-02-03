using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS
{
    class MenuUpdate
    {
        private string foodNum;
        private string foodName;
        private string foodType;
        private decimal foodPrice = 0m;
     

        // instantiate a corresponding MenuItem data access object
        MenuUpdateDAO menuData;

        // this constructor ensures that a corresponding data access object is created for every MenuItem y object
        public MenuUpdate()
        {
            menuData = new MenuUpdateDAO();
        }

        // 4 getter and setter methods are included below to return and set object fields
        public string FoodNum
        {
            get { return this.foodNum; }
            set { this.foodNum = value; }
        }

        public string FoodName
        {
            get { return this.foodName; }
            set { this.foodName = value; }
        }

        public string FoodType
        {
            get { return this.foodType; }
            set { this.foodType = value; }
        }


        public decimal FoodPrice
        {
            get { return this.foodPrice; }
            set { this.foodPrice = value; }
        }

        // calls the add method from the data object layer
        public void Add()
        {
            menuData.Add(this);
        }

        // calls the delete method from the data object layer
        public void Delete()
        {
            menuData.Delete(this);
        }

        // calls the update method from the data object layer
        public void Update()
        {
            menuData.Update(this);
        }

        // calls the search method from the data object layer
        public void Search()
        {
            menuData.Search(this);
        }
    }
}
