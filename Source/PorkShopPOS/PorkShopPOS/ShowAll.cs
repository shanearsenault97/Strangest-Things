/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Business layer class for ShowAll object
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // calls the showAllEmployees from the data layer
        public void showAllEmployees(DataGridView dgv)
        {
            showAllData.showAllEmployees(dgv);
        }

        // calls the showAllEmployees from the data layer
        public void showAllMenuItems(DataGridView dgv)
        {
            showAllData.showAllMenuItems(dgv);
        }

        // calls the showAllEmployees from the data layer
        public void showAllReservations(DataGridView dgv)
        {
            showAllData.showAllReservations(dgv);
        }
    }
}
