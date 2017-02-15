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
    public partial class SalaryListReport : Form
    {
        public SalaryListReport()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.salaryList();
        }

        private void SalaryListReport_Load(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.salaryList();
        }
    }
}
