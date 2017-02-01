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
    public partial class SalaryShowAll : Form
    {
        public SalaryShowAll()
        {
            InitializeComponent();
        }

        ShowAll showAll;

        private void SalaryShowAll_Load(object sender, EventArgs e)
        {
            showAll = new ShowAll();
            DataGridView dgv = salShowDGV;
            showAll.showAllSalaries(dgv);
        }

     
    }
}
