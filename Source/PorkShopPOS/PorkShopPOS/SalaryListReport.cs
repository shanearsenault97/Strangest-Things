/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Form that displays a crystal report of the most current employee salaries
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
    public partial class SalaryListReport : Form
    {
        public SalaryListReport()
        {
            InitializeComponent();
        }

        // this is probably not needed but deleting it causes untold woe
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.salaryList();
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: load the crystal report
        */
        private void SalaryListReport_Load(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            sal.salaryList();
        }
    }
}
