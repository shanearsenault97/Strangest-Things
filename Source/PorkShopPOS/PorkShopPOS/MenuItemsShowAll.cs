/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Form that displays MenuUpdate data
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

namespace PorkShopPOS
{
    public partial class MenuItemsShowAll : Form
    {
        public MenuItemsShowAll()
        {
            InitializeComponent();
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: method that displays MenuUpdate data
        */
        private void MenuItemsShowAll_Load(object sender, EventArgs e)
        {
            ShowAll showAll;
            showAll = new ShowAll();
            DataGridView dgv = menuShowDGV;
            showAll.showAllMenuItems(dgv);
        }
    }
}
