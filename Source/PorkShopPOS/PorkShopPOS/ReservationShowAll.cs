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
    public partial class ReservationShowAll : Form
    {
        public ReservationShowAll()
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
    }
}
