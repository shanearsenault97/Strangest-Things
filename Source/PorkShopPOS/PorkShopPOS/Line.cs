/**
 * User: Noah Gallant
 * Date: 2/16/2017
 * Time: 6:05 PM
 * Purpose: The purpose of this class is to store line information
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS {
    class Line {
        private string orderNum;

        public string OrderNum {
            get { return orderNum; }
            set { orderNum = value; }
        }
        private string lineNum;

        public string LineNum {
            get { return lineNum; }
            set { lineNum = value; }
        }
        private string foodId;

        public string FoodId {
            get { return foodId; }
            set { foodId = value; }
        }
        private string barId;

        public string BarId {
            get { return barId; }
            set { barId = value; }
        }
        private string lineQty;

        public string LineQty {
            get { return lineQty; }
            set { lineQty = value; }
        }
        private string linePrice;

        public string LinePrice {
            get { return linePrice; }
            set { linePrice = value; }
        }

        LineDAO lineData;

        public Line() {
            lineData = new LineDAO();
        }

        //Calls the Add method from the data object layer
        public void Add() {
            lineData.Add(this);
        }
    }
}
