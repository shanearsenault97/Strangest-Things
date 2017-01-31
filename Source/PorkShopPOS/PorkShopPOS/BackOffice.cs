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

        // functionality required when the Back Office interface loads
         private void BackOffice_Load(object sender, EventArgs e)
        {
             // set the date time picker control in the employee tab (utilities) to the current date
             empStartDateDTP.Value = DateTime.Now;
        }


        //*************************************************EMPLOYEE SECTION START****************************************************

        // instantiate an employee object to be used in the CRUD methods below
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

                MessageBox.Show(empFName + " " + empLName + " successfully added.");
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
                MessageBox.Show("Update successful.");
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
               
                // search by empNum
                emp.EmpNum = empNumTB.Text.ToString();
               
                // call the search method in the business layer
                emp.Search();
                
                // display search results in the form text boxes
                
                        
                    empFNameTB.Text = emp.EmpFName;
                    empLNameTB.Text = emp.EmpLName;
                    empAddressTB.Text = emp.EmpAddress;
                    empCityTB.Text = emp.EmpCity;
                    empProvinceTB.Text = emp.EmpProvince;
                    empPostalTB.Text = emp.EmpPostal;
                    empPhoneTB.Text = emp.EmpPhone;
                    empSinTB.Text = emp.EmpSIN;
                    empStartDateDTP.Value = Convert.ToDateTime(emp.EmpStartDate);
                    empStatusCB.Text = emp.EmpStatus;
                    empEndDateMTB.Text = emp.EmpEndDate;
                    empPositionCB.Text = emp.EmpPosition;
                   
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

                // store employee first and last name to be outputted in the below confirmation message box
                string empFName = empFNameTB.Text;
                string empLName = empLNameTB.Text;

                // delete employee from database based on empNumber
                emp.EmpNum = empNumTB.Text;

                // delete employee
               emp.Delete();

               MessageBox.Show(empFName + " " + empLName + " successfully deleted.");
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

        // clears input controls in employee section of the utilitiesTab
        private void clearB_Click(object sender, EventArgs e)
        {
            empNumTB.Text = String.Empty;
            empFNameTB.Text = String.Empty;
            empLNameTB.Text = String.Empty;
            empAddressTB.Text = String.Empty;
            empCityTB.Text = String.Empty;
            empProvinceTB.Text = String.Empty;
            empPostalTB.Text = String.Empty;
            empPhoneTB.Text = String.Empty;
            empSinTB.Text = String.Empty;
            empStartDateDTP.Value = DateTime.Now;
            empStatusCB.Text = String.Empty;
            empEndDateMTB.Text = String.Empty;
            empPositionCB.Text = String.Empty;
        }

       

        //*************************************************EMPLOYEE SECTION END****************************************************

        //*************************************************SALARY SECTION START****************************************************


        // instantiate a salary object to be used in the CRUD methods below
        Salary sal; 

        // add a new salary
        private void salAddB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();

                // these fields will be used to validate the form data
                //int salNum = salNumTB.Text; 
                //string salEmpNum = 
                //string salFromDate = 
                //string salToDate = 
                //decimal empCity = empCityTB.Text;                

              

                // assign back office salary input data to a new salary object
                sal.SalEmpNum = salEmpNumTB.Text;
                sal.FromDate = salFromDateMTB.Text;
                sal.ToDate = salToDateMTB.Text;
                sal.Amount = decimal.Parse(salAmountTB.Text);           

                // call Salary add()
                sal.Add();

                MessageBox.Show("New salary for employee " + sal.SalEmpNum + " successfully added.");
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

        // update an existing salary's information
        private void salUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();

                sal.SalNum = int.Parse(salNumTB.Text);
                sal.SalEmpNum = salEmpNumTB.Text;
                sal.FromDate = salFromDateMTB.Text;
                sal.ToDate = salToDateMTB.Text;
                sal.Amount = decimal.Parse(salAmountTB.Text);
               

                sal.Update();
                MessageBox.Show("Update successful.");
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

        // search for a salary
        private void salSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();

              
                // search by empNum
                sal.SalNum = int.Parse(salNumTB.Text);

                // call the search method in the business layer
                sal.Search(); 

                // display search results in the form text boxes


                salEmpNumTB.Text = sal.SalEmpNum;
                salFromDateMTB.Text = sal.FromDate;
                salToDateMTB.Text = sal.ToDate;
                salAmountTB.Text = sal.Amount.ToString();    
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

        // delete a salary
        private void salDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();
               
                // delete employee from database based on empNumber
                sal.SalNum = int.Parse(salNumTB.Text);

                // delete employee
                sal.Delete();

                MessageBox.Show("Salary successfully deleted.");
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

        // clears input controls in the salary section of the utilitiesTab
        private void salClearB_Click(object sender, EventArgs e)
        {
            salEmpNumTB.Text = String.Empty;
            salNumTB.Text = String.Empty;
            salFromDateMTB.Text = String.Empty;
            salToDateMTB.Text = String.Empty;
            salAmountTB.Text = String.Empty;            
        }

        //*************************************************SALARY SECTION END****************************************************

        //*************************************************PAYROLL SECTION START****************************************************

        // instantiate a payroll object to be used in the CRUD methods below
        Payroll pay; 

        // add a payroll object to the database
        private void payAddB_Click(object sender, EventArgs e)
        {
            try
            {
                pay= new Payroll();

                // these fields will be used to validate the form data
                //int salNum = salNumTB.Text; 
                //string salEmpNum = 
                //string salFromDate = 
                //string salToDate = 
                //decimal empCity = empCityTB.Text;   

                // assign back office salary input data to a new payroll object
                pay.PayEmpNum = payEmpNumTB.Text;
                pay.FromDate = payStartDateMTB.Text;
                pay.ToDate = payEndDateMTB.Text;
                pay.Hours = decimal.Parse(payHoursTB.Text);
                pay.Amount = decimal.Parse(payAmountTB.Text);

                // call Salary add()
                pay.Add();

                MessageBox.Show("New payroll for employee " + pay.PayEmpNum + " successfully added.");
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

        // update an existing payroll's information
        private void payUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                pay = new Payroll();

                pay.PayNum = int.Parse(payNumTB.Text);
                pay.PayEmpNum = payEmpNumTB.Text;
                pay.FromDate = payStartDateMTB.Text;
                pay.ToDate = payEndDateMTB.Text;
                pay.Hours = decimal.Parse(payHoursTB.Text);
                pay.Amount = decimal.Parse(payAmountTB.Text);


                pay.Update();
                MessageBox.Show("Update successful.");
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

        // search for a payroll
        private void paySearchB_Click(object sender, EventArgs e)
        {
            try
            {
                pay = new Payroll();


                // search by empNum
                pay.PayNum = int.Parse(payNumTB.Text);

                // call the search method in the business layer
                pay.Search();

                // display search results in the form text boxes

                payEmpNumTB.Text = pay.PayEmpNum;
                payStartDateMTB.Text = pay.FromDate;
                payEndDateMTB.Text = pay.ToDate;
                payHoursTB.Text = pay.Hours.ToString();
                payAmountTB.Text = pay.Amount.ToString();
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

        // delete a payroll
        private void payDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                pay = new Payroll();

                // delete employee from database based on empNumber
                pay.PayNum = int.Parse(payNumTB.Text);

                // delete employee
                pay.Delete();

                MessageBox.Show("Salary successfully deleted.");
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

        // clears input controls in the payroll section of the utilitiesTab
        private void payClearB_Click(object sender, EventArgs e)
        {
               payEmpNumTB.Text = String.Empty;
               payNumTB.Text = String.Empty;
               payStartDateMTB.Text = String.Empty;
               payEndDateMTB.Text = String.Empty;
               payHoursTB.Text = String.Empty; 
               payAmountTB.Text = String.Empty; 
        }

        //*************************************************PAYROLL SECTION END****************************************************

        

     

  
    }
}
