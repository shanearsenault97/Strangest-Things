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

        private void MenuItemsShowAll_Load(object sender, EventArgs e)
        {
            ShowAll showAll;
            showAll = new ShowAll();
            DataGridView dgv = menuShowDGV;
            showAll.showAllMenuItems(dgv);
        }
    }
}
