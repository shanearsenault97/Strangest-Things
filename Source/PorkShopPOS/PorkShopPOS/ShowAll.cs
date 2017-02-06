using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    class ShowAll
    {
        ShowAllDAO showAllData;

        public ShowAll() 
        {
            showAllData = new ShowAllDAO();
        }

        public void showAllEmployees(DataGridView dgv)
        {
            showAllData.showAllEmployees(dgv);
        }

        public void showAllSalaries(DataGridView dgv)
        {
            showAllData.showAllSalaries(dgv);
        }

        public void showAllPayrolls(DataGridView dgv)
        {
            showAllData.showAllPayrolls(dgv);
        }

        public void showAllMenuItems(DataGridView dgv)
        {
            showAllData.showAllMenuItems(dgv);
        }

        public void showAllReservations(DataGridView dgv)
        {
            showAllData.showAllReservations(dgv);
        }
    }
}
