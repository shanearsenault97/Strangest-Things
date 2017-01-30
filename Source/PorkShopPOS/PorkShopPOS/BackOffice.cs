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
    public partial class BackOffice : Form
    {
        public BackOffice()
        {
            InitializeComponent();
        }


        //*************************************************EMPLOYEE SECTION START****************************************************

        Employee emp;

        

        // add a new employee
        private void empAddB_Click(object sender, EventArgs e)
        {

            try
            {
                emp = new Employee();

                // these fields will be used to validate the form data
                string empNum = empNumTB.Text;
                string empFName = empFNameTB.Text;
                string empLName = empLNameTB.Text;
                string empAddress = empAddressTB.Text;
                string empCity = empCityTB.Text;
                string empProvince = empProvinceTB.Text;
                string empPostal = empPostalTB.Text;
                string empPhone = empPhoneTB.Text;
                string empSIN = empSinTB.Text;
                string empStartDate = empStartDateDTP.Value.ToString();
                string empStatus = empStatusCB.Text;
                string empEndDate = empEndDateMTB.Text;
                string empPosition = empPositionCB.Text;

                // assign back office employee data to a new employee object
                emp.EmpNum = empNum;
                emp.EmpFName = empFName;
                emp.EmpLName = empLName;
                emp.EmpAddress = empAddress;
                emp.EmpCity = empCity;
                emp.EmpProvince = empProvince;
                emp.EmpPostal = empPostal;
                emp.EmpPhone = empPhone;
                emp.EmpSIN = empSIN;
                emp.EmpStartDate = empStartDate;
                emp.EmpStatus = empStatus;
                emp.EmpEndDate = empEndDate;
                emp.EmpPosition = empPosition;

                // call Employee add()
                emp.Add();
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


        // update an existing employee's information
        private void empUpdateB_Click(object sender, EventArgs e)
        {
            // find out if the employee number can be changed by the user
            try
            {
                emp = new Employee();
                
                
                emp.EmpNum = empNumTB.Text;
                emp.EmpFName = empFNameTB.Text;
                emp.EmpLName = empLNameTB.Text;
                emp.EmpAddress = empAddressTB.Text;
                emp.EmpCity = empCityTB.Text;
                emp.EmpProvince = empProvinceTB.Text;
                emp.EmpPostal = empPostalTB.Text;
                emp.EmpPhone = empPhoneTB.Text;
                emp.EmpSIN = empSinTB.Text;
                emp.EmpStartDate = empStartDateDTP.Value.ToString();
                emp.EmpStatus = empStatusCB.Text;
                emp.EmpEndDate = empEndDateMTB.Text;
                emp.EmpPosition = empPositionCB.Text;

                emp.Update();
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


        // search for an employee
        private void empSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                emp = new Employee();

                // search by Title
                emp.EmpNum = empNumTB.Text.ToString();

                // call the search method in the business layer
                emp.Search();

                // display search results in the form text boxes
                
                    empNumTB.Text = empNumTB.Text;
                    empFNameTB.Text = empFNameTB.Text;
                    empLNameTB.Text = empLNameTB.Text;
                    empAddressTB.Text = empAddressTB.Text;
                    empCityTB.Text = empCityTB.Text;
                    empProvinceTB.Text = empProvinceTB.Text;
                    empPostalTB.Text = empPostalTB.Text;
                    empPhoneTB.Text = empPhoneTB.Text;
                    empSinTB.Text = empSinTB.Text;
                    empStartDateDTP.Value = empStartDateDTP.Value;
                    empStatusCB.Text = empStatusCB.Text;
                    empEndDateMTB.Text = empEndDateMTB.Text;
                    empPositionCB.Text = empPositionCB.Text;
                
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


        // delete an employee
        private void empDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                emp = new Employee();

                // delete employee from database based on empNumber
                emp.EmpNum = empNumTB.Text.ToString();

                // delete employee
               emp.Delete();
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


        //*************************************************EMPLOYEE SECTION END****************************************************

     

  
    }
}
