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

        private void SalaryHistory_Load(object sender, EventArgs e)
        {
            try
            {

                string salEmpNum = BackOffice.salEmpNum;
                Employee emp = new Employee();
                emp.EmpNum = salEmpNum;
                emp.Search();
                nameLab.Text = emp.EmpFName + " " + emp.EmpLName;

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
