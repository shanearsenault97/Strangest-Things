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
    public partial class ThePorkShopPOS : Form
    {

        //Declare variables
        Employee Employee;
        Tables Tables;

        public ThePorkShopPOS()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ThePorkShopPOS_Load(object sender, EventArgs e) {
            //Create employee object
            Employee = new Employee();

            //Create list for employees
            List<string> lPresEmployees = new List<string>();

            try {
                //Load the employees into the list
                lPresEmployees = Employee.LoadEmployees();
            } catch (Exception ex) {
                //Display error message if something went wrong accessing the database
                MessageBox.Show("Something went wrong: " + ex.GetBaseException());
            }
            //Add each employee to the combo box
            for (int i = 0; i < lPresEmployees.Count; i++) {
                cmbServer.Items.Add(lPresEmployees[i]);
            }

            //Create table object
            Tables = new Tables();

            //Create list for tables
            List<string> lPresTables = new List<string>();

            try {
                //Load the tables into the list
                lPresTables = Tables.LoadTables();
            } catch (Exception ex) {
                //Display error message if something went wrong accessing the database
                MessageBox.Show("Something went wrong: " + ex.GetBaseException());
            }
            //Add each table to the combo box
            for (int i = 0; i < lPresTables.Count; i++) {
                cmbTableOr.Items.Add(lPresTables[i]);
                cmbTableRes.Items.Add(lPresTables[i]);
            }
        }


        // close the pos UI and load the back office UI
        private void btnBackOffice_Click(object sender, EventArgs e)
        {        
            this.Close();
            BackOffice officeUI = new BackOffice();
            officeUI.Show();                       
        }

        // close the pos UI and load the login UI
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome welcomeUI = new Welcome();
            welcomeUI.Show(); 
        }    
    }
}
