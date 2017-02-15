/**
 * User: Shane Arsenault
 * Date: 2/15/2017
 * Purpose: Reservation object for use in the POS and Back Office System
 * **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkShopPOS
{
    class Reservation
    {
        private int reservationID;

        public int ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        private string tableNum;

        public string TableNum
        {
            get { return tableNum; }
            set { tableNum = value; }
        }

        private string reservationDate;

        public string ReservationDate
        {
            get { return reservationDate; }
            set { reservationDate = value; }
        }

        private string reservationTime;

        public string ReservationTime
        {
            get { return reservationTime; }
            set { reservationTime = value; }
        }

        private string reservationName;

        public string ReservationName
        {
            get { return reservationName; }
            set { reservationName = value; }
        }

        private string reservationContact;

        public string ReservationContact
        {
            get { return reservationContact; }
            set { reservationContact = value; }
        }

        ReservationDAO reservationData;

        public Reservation()
        {
            reservationData = new ReservationDAO(); 
        }

        // calls the add method from the data object layer
        public void Add()
        {
            reservationData.Add(this);
        }

        // calls the delete method from the data object layer
        public void Delete()
        {
            reservationData.Delete(this);
        }

        // calls the update method from the data object layer
        public void Update()
        {
            reservationData.Update(this);
        }

        // calls the search method from the data object layer
        public void Search()
        {
            reservationData.Search(this);
        }

        public List<string> LoadReservations()
        {
            List<string> lReservations = new List<string>();

            lReservations = reservationData.LoadReservations(this);

            return lReservations;
        }
    }
}
