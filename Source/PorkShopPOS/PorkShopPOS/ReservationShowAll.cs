using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PorkShopPOS
{
    public partial class frmReservationShowAll : Form
    {
        public frmReservationShowAll()
        {
            InitializeComponent();
        }

        private void ReservationShowAll_Load(object sender, EventArgs e)
        {
            ShowAll showAll;
            showAll = new ShowAll();
            DataGridView dgv = reservationDGV;
            showAll.showAllReservations(dgv);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (reservationDGV.SelectedCells.Count < 6)
            {
                MessageBox.Show("Try selecting the entire row before updating.");
            }
            else
            {
                for (int i = 0; i < reservationDGV.SelectedCells.Count; i++)
                {
                    if (reservationDGV.SelectedCells[i].Value.ToString() == "")
                    {
                        MessageBox.Show("All attributes of a reservation are required to update.");
                    }
                }

                Reservation reservation = new Reservation();
                reservation.ReservationID = Int32.Parse(reservationDGV.SelectedCells[0].Value.ToString());
                reservation.TableNum = reservationDGV.SelectedCells[1].Value.ToString();
                reservation.ReservationDate = reservationDGV.SelectedCells[2].Value.ToString();
                reservation.ReservationTime = reservationDGV.SelectedCells[3].Value.ToString();
                reservation.ReservationName = reservationDGV.SelectedCells[4].Value.ToString();
                reservation.ReservationContact = reservationDGV.SelectedCells[5].Value.ToString();
                reservation.Update();

                MessageBox.Show("Updated record. Refreshing reservation list.");
                this.Refresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (reservationDGV.SelectedCells.Count < 6)
            {
                MessageBox.Show("Try selecting the entire row before deleting.");
            }
            else if (reservationDGV.SelectedCells[0].Value.ToString() == "")
            {
                MessageBox.Show("Reservation ID is required to delete.");
            }
            else
            {
                Reservation reservation = new Reservation();
                reservation.ReservationID = Int32.Parse(reservationDGV.SelectedCells[0].Value.ToString());
                reservation.TableNum = reservationDGV.SelectedCells[1].Value.ToString();
                reservation.ReservationDate = reservationDGV.SelectedCells[2].Value.ToString();
                reservation.ReservationTime = reservationDGV.SelectedCells[3].Value.ToString();
                reservation.ReservationName = reservationDGV.SelectedCells[4].Value.ToString();
                reservation.ReservationContact = reservationDGV.SelectedCells[5].Value.ToString();
                reservation.Delete();

                MessageBox.Show("Deleted record. Refreshing reservation list.");
                this.Refresh();
            }
        }
    }
}
