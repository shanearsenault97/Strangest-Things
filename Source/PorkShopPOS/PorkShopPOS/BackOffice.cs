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

        // closes back office UI and opens POS UI
        private void FrontHouseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ThePorkShopPOS posUI = new ThePorkShopPOS();
            posUI.Show();
        }

        // close the pos UI and load the back office UI
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome welcomeUI = new Welcome();
            welcomeUI.Show(); 
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
                string empPostal = empPostalTB.Text.Replace(" ", String.Empty);
                string empPhone = empPhoneTB.Text;
                string empSIN = empSinTB.Text;
                string empStartDate = empStartDateDTP.Value.ToString();
                string empStatus = empStatusCB.Text;
                string empEndDate = empEndDateMTB.Text;
                string empPosition = empPositionCB.Text;

                if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(empFName) |
                    String.IsNullOrEmpty(empLName) | String.IsNullOrEmpty(empAddress) | String.IsNullOrEmpty(empCity) |
                    String.IsNullOrEmpty(empProvince) | String.IsNullOrEmpty(empPostal) | String.IsNullOrEmpty(empPhone) |
                    String.IsNullOrEmpty(empSIN) | String.IsNullOrEmpty(empStartDate) | String.IsNullOrEmpty(empStatus) |
                    String.IsNullOrEmpty(empEndDate) | String.IsNullOrEmpty(empPosition))
                {
                    MessageBox.Show("All fields must be filled out. If no End Date, enter 0000-00-00.");
                }
                else if (empNum.Length > 6 | empNum.Length < 6)
                {
                     MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                 else if (empPostal.Length > 6 | empPostal.Length < 6)
                {
                     MessageBox.Show("Please enter valid postal code.");
                }
                else if (empSIN.Length < 9)
                {
                    MessageBox.Show("Please enter valid SIN.");
                }
                else if (empPhone.Length < 10)
                {
                    MessageBox.Show("Please enter valid phone number.");
                }
                else if (empEndDate.Length < 8)
                {
                    MessageBox.Show("Please enter valid End Date. If no End Date, enter 0000-00-00.");
                }

                else
                {
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
                string empNum = empNumTB.Text;
                string empFName = empFNameTB.Text;
                string empLName = empLNameTB.Text;
                string empAddress = empAddressTB.Text;
                string empCity = empCityTB.Text;
                string empProvince = empProvinceTB.Text;
                string empPostal = empPostalTB.Text.Replace(" ", String.Empty);
                string empPhone = empPhoneTB.Text;
                string empSIN = empSinTB.Text;
                string empStartDate = empStartDateDTP.Value.ToString();
                string empStatus = empStatusCB.Text;
                string empEndDate = empEndDateMTB.Text;
                string empPosition = empPositionCB.Text;

                if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(empFName) |
                    String.IsNullOrEmpty(empLName) | String.IsNullOrEmpty(empAddress) | String.IsNullOrEmpty(empCity) |
                    String.IsNullOrEmpty(empProvince) | String.IsNullOrEmpty(empPostal) | String.IsNullOrEmpty(empPhone) |
                    String.IsNullOrEmpty(empSIN) | String.IsNullOrEmpty(empStartDate) | String.IsNullOrEmpty(empStatus) |
                    String.IsNullOrEmpty(empEndDate) | String.IsNullOrEmpty(empPosition))
                {
                    MessageBox.Show("All fields must be filled out. If no End Date, enter 0000-00-00.");
                }
                else if (empNum.Length > 6 | empNum.Length < 6)
                {
                     MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                 else if (empPostal.Length > 6 | empPostal.Length < 6)
                {
                     MessageBox.Show("Please enter valid postal code.");
                }
                else if (empSIN.Length < 9)
                {
                    MessageBox.Show("Please enter valid SIN.");
                }
                else if (empPhone.Length < 10)
                {
                    MessageBox.Show("Please enter valid phone number.");
                }
                else if (empEndDate.Length < 8)
                {
                    MessageBox.Show("Please enter valid End Date. If no End Date, enter 0000-00-00.");
                }

                else
                {
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
                if (String.IsNullOrEmpty(empNumTB.Text) | empNumTB.Text.Length < 6 | empNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Please enter a valid employee number.");
                }
                else
                {
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
                if (String.IsNullOrEmpty(empNumTB.Text) | empNumTB.Text.Length < 6 | empNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Please enter a valid employee number.");
                }
                else
                {
                    // store employee first and last name to be outputted in the below confirmation message box
                    string empFName = empFNameTB.Text;
                    string empLName = empLNameTB.Text;

                    // delete employee from database based on empNumber
                    emp.EmpNum = empNumTB.Text;

                    // delete employee
                    emp.Delete();

                    MessageBox.Show(empFName + " " + empLName + " successfully deleted.");
                }
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

        // display all employee data in a datagrid in a new form
        private void empShowAllB_Click(object sender, EventArgs e)
        {
            EmployeeShowAllForm empShow = new EmployeeShowAllForm();
            empShow.Show();            
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

                
                decimal number;
                if ( Decimal.TryParse(salAmountTB.Text, out number) == false)
                {
                    MessageBox.Show("Please enter a valid amount.");
                }
                else 
                {
                    // these fields will be used to validate the form data
                    int salNum = int.Parse(salNumTB.Text); 
                    string empNum = salEmpNumTB.Text;
                    string fromDate = salFromDateMTB.Text;
                    string toDate = salToDateMTB.Text;
                    decimal amount = decimal.Parse(salAmountTB.Text);

                    if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(fromDate) |
                       String.IsNullOrEmpty(toDate))
                    {
                        MessageBox.Show("All fields must be filled out. If no To Date, enter 0000-00-00.");
                    }
                    else if (empNum.Length < 6 | empNum.Length > 6)
                    {
                        MessageBox.Show("Please enter a valid employee number");
                    }
                    else
                    {

                        // assign back office salary input data to a new salary object
                        sal.EmpNum = empNum;
                        sal.FromDate = fromDate;
                        sal.ToDate = toDate;
                        sal.Amount = amount;

                        // call Salary add()
                        sal.Add();

                        MessageBox.Show("New salary for employee " + sal.EmpNum + " successfully added.");
                    }
                }
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
                 decimal number;
                 if (Decimal.TryParse(salAmountTB.Text, out number) == false)
                 {
                     MessageBox.Show("Please enter a valid amount.");
                 }
                 else
                 {
                     // these fields will be used to validate the form data
                     int salNum = int.Parse(salNumTB.Text);
                     string empNum = salEmpNumTB.Text;
                     string fromDate = salFromDateMTB.Text;
                     string toDate = salToDateMTB.Text;
                     decimal amount = decimal.Parse(salAmountTB.Text);

                     if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(fromDate) |
                        String.IsNullOrEmpty(toDate))
                     {
                         MessageBox.Show("All fields must be filled out. If no To Date, enter 0000-00-00.");
                     }
                     else if (empNum.Length < 6 | empNum.Length > 6)
                     {
                         MessageBox.Show("Please enter a valid employee number");
                     }
                     else
                     {
                         sal.SalNum = int.Parse(salNumTB.Text);
                         sal.EmpNum = salEmpNumTB.Text;
                         sal.FromDate = salFromDateMTB.Text;
                         sal.ToDate = salToDateMTB.Text;
                         sal.Amount = decimal.Parse(salAmountTB.Text);


                         sal.Update();
                         MessageBox.Show("Update successful.");
                     }
                 }
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


                salEmpNumTB.Text = sal.EmpNum;
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


        // display all salary data in a datagrid in a new form
        private void salShowAllB_Click(object sender, EventArgs e)
        {
            SalaryShowAll salShow = new SalaryShowAll();
            salShow.Show();
        }

        // display all salary data in a datagrid in a new form
        private void salaryReportB_Click(object sender, EventArgs e)
        {

            SalaryListReport salaryList = new SalaryListReport();
            salaryList.Show();

       }

        private void salaryHistoryB_Click(object sender, EventArgs e)
        {
            SalaryHistory salHis = new SalaryHistory();
            salHis.Show();
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
                pay.EmpNum = payEmpNumTB.Text;
                pay.FromDate = payStartDateMTB.Text;
                pay.ToDate = payEndDateMTB.Text;
                pay.Hours = decimal.Parse(payHoursTB.Text);
                pay.Amount = decimal.Parse(payAmountTB.Text);

                // call Salary add()
                pay.Add();

                MessageBox.Show("New payroll for employee " + pay.EmpNum + " successfully added.");
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
                pay.EmpNum = payEmpNumTB.Text;
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

                payEmpNumTB.Text = pay.EmpNum;
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

        // display all payroll data in a datagrid in a new form
        private void payShowAllB_Click(object sender, EventArgs e)
        {
            PayrollShowAll payShow = new PayrollShowAll();
            payShow.Show();            
        }

        

        //*************************************************PAYROLL SECTION END****************************************************
        //*************************************************MENU_UPDATE SECTION START****************************************************

        // instantiate a new menu object
        MenuUpdate menu;

        // add a new menu item to the database
        private void menuAddB_Click(object sender, EventArgs e)
        {

            try
            {
                menu = new MenuUpdate();

                // these fields will be used to validate the form data
                //int salNum = salNumTB.Text; 
                //string salEmpNum = 
                //string salFromDate = 
                //string salToDate = 
                //decimal empCity = empCityTB.Text;    

                // assign back office menu input data to a new menu object
                menu.FoodNum = menuNumTB.Text;
                menu.FoodName = menuNameTB.Text;
                menu.FoodType = menuTypeLB.Text;
                menu.FoodPrice = decimal.Parse(menuPriceTB.Text);

                // call Salary add()
                menu.Add();

                MessageBox.Show("New menu item successfully added.");
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

        // update an existing menu item in the database
        private void menuUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new MenuUpdate();

                menu.FoodNum = menuNumTB.Text;
                menu.FoodName = menuNameTB.Text;
                menu.FoodType = menuTypeLB.Text;
                menu.FoodPrice = decimal.Parse(menuPriceTB.Text);


                menu.Update();
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

        // search for a menu item in the database
        private void menuSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new MenuUpdate();


                // search by empNum
                menu.FoodNum = menuNumTB.Text;

                // call the search method in the business layer
                menu.Search();

                // display search results in the form text boxes

                menuNumTB.Text = menu.FoodNum;
                menuNameTB.Text = menu.FoodName;
                menuTypeLB.Text = menu.FoodType;
                menuPriceTB.Text = menu.FoodPrice.ToString();
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

        // delete a menu item in the database
        private void menuDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new MenuUpdate();

                // delete employee from database based on empNumber
                menu.FoodNum = menuNumTB.Text;

                // delete employee
                menu.Delete();

                MessageBox.Show("Menu item successfully deleted.");
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

        // clear all fields in the update menu tab
        private void menuClearB_Click(object sender, EventArgs e)
        {
            menuNumTB.Text = String.Empty;
            menuNameTB.Text = String.Empty;
            menuTypeLB.Text = String.Empty;
            menuPriceTB.Text = String.Empty;          
        }

        // display all menu items in a data grid
        private void menuShowAllB_Click(object sender, EventArgs e)
        {
            MenuItemsShowAll menuShow = new MenuItemsShowAll();
            menuShow.Show();
        }


        //*************************************************MENU_UPDATE SECTION END****************************************************
        //*************************************************RESERVATION SECTION START****************************************************

        private void btnShowReservations_Click(object sender, EventArgs e)
        {
            frmReservationShowAll resShow = new frmReservationShowAll();
            resShow.Show();
        }


        // variables used in the Pay Stub Report form and the method below
        public static string empNum;
        public static string endDate;

        // create the Pay Stub Report form
        private void payStubB_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(payEmpNumTB.Text) | String.IsNullOrEmpty(payEndDateMTB.Text))
            {
                MessageBox.Show("Please ensure that employee number and pay period end date are entered correctly.");
            }
            else 
            {
                empNum = payEmpNumTB.Text;
                endDate = payEndDateMTB.Text;
                PayStub paystub = new PayStub();
                paystub.Show(); 
            }
        }

        //*************************************************RESERVATION SECTION END****************************************************

        //*************************************************TIME_CLOCK SECTION START****************************************************
        
        
        TimeClock timeC;

        
        private void timeClockInB_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Successfully clocked in.");
                timeC = new TimeClock();
                //create DateTime variable that displays the correct format for date
                DateTime dateOnly = new DateTime();
                dateOnly = DateTime.Now;
                string date = dateOnly.ToString("d");
                //create DateTime variable that displays the correct format for time
                DateTime timeOnly = new DateTime();
                timeOnly = DateTime.Now;
                string time = timeOnly.ToString("HH:mm");

                // assign back office menu input data to a new menu object
                timeC.EmpNum = timeEmpNumTB.Text;
                timeC.ShiftDate = Convert.ToDateTime(date);
                timeC.ClockIn = Convert.ToDateTime(time);
                timeC.ClockOut = Convert.ToDateTime(time);
                // timeC.EmpHours = 0.0m;

                // call TimeClock add()
                timeC.Add();

                MessageBox.Show("Employee: " + timeEmpNumTB.Text + " successfully clocked in at: " + time);

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

        private void timeClockOutB_Click(object sender, EventArgs e)
        {
            try
            {

                timeC = new TimeClock();
                //create DateTime variable that displays the correct format for date

                //DateTime dateOnly = new DateTime();
                //dateOnly = DateTime.Now;
                //string date = dateOnly.ToString("d");

                //create DateTime variable that displays the correct format for time
                DateTime timeOnly = new DateTime();
                timeOnly = DateTime.Now;
                string time = timeOnly.ToString("HH:mm");

                // assign back office menu input data to a new menu object
                timeC.EmpNum = timeEmpNumTB.Text;
                //timeC.ShiftDate = Convert.ToDateTime(date);
                timeC.ClockOut = Convert.ToDateTime(time);

                // call TimeClock update()
                timeC.Update();
                timeC.UpdateEmpHours();
                MessageBox.Show("Employee: " + timeEmpNumTB.Text + " successfully clocked out at: " + time);

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

        
        // add a new shift to the database
        private void schAddB_Click(object sender, EventArgs e)
        {
            try
            {
                timeC = new TimeClock();

                // these fields will be used to validate the form data
                //int salNum = salNumTB.Text; 
                //string salEmpNum = 
                //string salFromDate = 
                //string salToDate = 
                //decimal empCity = empCityTB.Text;    

                // assign back office menu input data to a new menu object
                timeC.TimeClockNum = int.Parse(schTimeClockNumTB.Text);
                timeC.EmpNum = schEmpNumTB.Text;
                timeC.ShiftDate = Convert.ToDateTime(schShiftDateMTB.Text);
                timeC.ClockIn = Convert.ToDateTime(schFromDateMTB.Text);
                timeC.ClockOut = Convert.ToDateTime(schToDateMTB.Text);
       

                // call Salary add()
                timeC.Add();

                MessageBox.Show("New shift successfully created.");
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

        // update time clock/shift information
        private void schUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                TimeClock timeC = new TimeClock();

                timeC.EmpNum = schEmpNumTB.Text;
                timeC.ShiftDate = Convert.ToDateTime(schShiftDateMTB.Text);
                timeC.ClockIn = Convert.ToDateTime(schFromDateMTB.Text);
                timeC.ClockOut = Convert.ToDateTime(schToDateMTB.Text);

                timeC.Update();
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

        // search for a time clock/shift based on employee number and shift date
        private void schSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                TimeClock timeC = new TimeClock();
                Console.WriteLine("1: got this far");
                // search by empNum and shiftDate
                //timeC.EmpNum = schEmpNumTB.Text;
                timeC.TimeClockNum = int.Parse(schTimeClockNumTB.Text);
                //timeC.ShiftDate = Convert.ToDateTime(schShiftDateMTB.Text);
                Console.WriteLine("2: got this far");
                // call the search method in the business layer
                timeC.Search();
                Console.WriteLine("3: got this far");
                // display search results in the form text boxes

                schTimeClockNumTB.Text = timeC.TimeClockNum.ToString();
                schEmpNumTB.Text = timeC.EmpNum;
                schShiftDateMTB.Text = timeC.ShiftDate.ToString();
                schFromDateMTB.Text = timeC.FromDate.ToString();
                schToDateMTB.Text = timeC.ToDate.ToString();
                Console.WriteLine("4: got this far");
            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString() + " the issue is here" );
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + " the issue is here");
            }
        }

        // delete a time/cock shift based on time clock number
        private void schDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                timeC = new TimeClock();

                // delete employee from database based on empNumber
                timeC.TimeClockNum = int.Parse(schTimeClockNumTB.Text);

                // delete employee
                timeC.Delete();

                MessageBox.Show("Shift successfully deleted.");
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

        // clear text box fields
        private void schClearB_Click(object sender, EventArgs e)
        {
            schTimeClockNumTB.Text = String.Empty;
            schEmpNumTB.Text = String.Empty;
            schShiftDateMTB.Text = String.Empty;
            schFromDateMTB.Text = String.Empty;
            schToDateMTB.Text = String.Empty;
        }

        // display shift history report
        private void shiftHistoryB_Click(object sender, EventArgs e)
        {
           
        }

       
               

        //*************************************************TIME_CLCOK SECTION END****************************************************

    }
}
