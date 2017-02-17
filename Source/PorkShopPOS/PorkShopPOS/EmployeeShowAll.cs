/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Form that displays all employee data in a datagrid
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    public partial class EmployeeShowAllForm : Form
    {
        public EmployeeShowAllForm()
        {
            InitializeComponent();
        }

        // instantiate a ShowAll class to be used in the below method
        ShowAll showAll;

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: calls the showAll() method from ShowALL to display employee data in a datagrid
        */
        private void EmployeeShowAllForm_Load(object sender, EventArgs e)
        {
            showAll = new ShowAll(); 
            DataGridView dgv = empShowDGV;
            showAll.showAllEmployees(dgv);
        }
    }
}
