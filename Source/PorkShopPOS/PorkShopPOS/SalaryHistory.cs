/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Form that displays the salary history report in a data grid
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
    public partial class SalaryHistory : Form
    {
        public SalaryHistory()
        {
            InitializeComponent();
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: displays the salary history of one employee
        */
        private void SalaryHistory_Load(object sender, EventArgs e)
        {
            try
            {
                // use the empNum input to get and then display the employee's neame
                string salEmpNum = BackOffice.salEmpNum;
                Employee emp = new Employee();
                emp.EmpNum = salEmpNum;
                emp.Search();
                fromtoL.Text = emp.EmpFName + " " + emp.EmpLName;

                // use the empNum to get the employee's salary history which will be ordered by descending salary numbers
                Salary sal = new Salary();             
                DataGridView dgv = salHistoryDGV;
                sal.salaryHistory(salEmpNum, dgv);
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
    }
}
