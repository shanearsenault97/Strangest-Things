/**
 * User: Noah Gallant
 * Date: 2/16/2017
 * Time: 6:05 PM
 * Purpose: The purpose of this class is to store order information
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS {
    class Order {
        private string orderNum;

        public string OrderNum {
            get { return orderNum; }
            set { orderNum = value; }
        }
        private string empNum;

        public string EmpNum {
            get { return empNum; }
            set { empNum = value; }
        }
        private string tableNum;

        public string TableNum {
            get { return tableNum; }
            set { tableNum = value; }
        }
        private string orderDate;

        public string OrderDate {
            get { return orderDate; }
            set { orderDate = value; }
        }
        private string orderTime;

        public string OrderTime {
            get { return orderTime; }
            set { orderTime = value; }
        }
        private string numGuests;

        public string NumGuests {
            get { return numGuests; }
            set { numGuests = value; }
        }
        private string orderTotal;

        public string OrderTotal {
            get { return orderTotal; }
            set { orderTotal = value; }
        }
        private string orderGratuity;

        public string OrderGratuity {
            get { return orderGratuity; }
            set { orderGratuity = value; }
        }

        OrderDAO orderData;

        public Order() {
            orderData = new OrderDAO();
        }

        //Calls the Add method from the data object layer
        public void Add() {
            orderData.Add(this);
        }

        //Calls the Search method from the data object layer
        public void Search() {
            orderData.Search(this);
        }
    }
}
