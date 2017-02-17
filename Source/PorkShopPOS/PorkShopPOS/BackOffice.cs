/* User: Bryan MacFarlane, Heather Watterson, Jonathan Deschene, Noah Gallant, Shane Arsenault
 * Date: 2017-01-20
 * Time: 2:45 PM
 * Purpose: This is the BackOffice form, one of the two central interfaces of the PorkShopPOS application.  
 *          It manages all input and output related to Employees, TimeClocks, Salary, Payroll, and updating the Menu.
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
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    public partial class BackOffice : Form
    {
        public BackOffice()
        {
            InitializeComponent();
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: closes back office UI and opens POS UI
         */
        private void FrontHouseButton_Click(object sender, EventArgs e)
        {
            this.Close();
            ThePorkShopPOS posUI = new ThePorkShopPOS();
            posUI.Show();
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: close the pos UI and load the back office UI
         */
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome welcomeUI = new Welcome();
            welcomeUI.Show(); 
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: functionality required when the Back Office interface loads
         */
        private void BackOffice_Load(object sender, EventArgs e)
        {
             // set the date time picker control in the employee tab (utilities) to the current date
             empStartDateDTP.Value = DateTime.Now;

            // disable buttons depending on user authorization
            int userPermission = Welcome.userPermissionType;
            if (userPermission == 1)
            {
                // disable employee functionality in utilities tab
                empAddB.Enabled = false;
                empUpdateB.Enabled = false;
                empSearchB.Enabled = false;
                empDeleteB.Enabled = false;
                empClearB.Enabled = false;
                empShowAllB.Enabled = false;

                // disable schedule functionality in utilities tab
                empAddB.Enabled = false;
                empUpdateB.Enabled = false;
                empSearchB.Enabled = false;
                empDeleteB.Enabled = false;
                empClearB.Enabled = false;
                empShowAllB.Enabled = false;

                // disable salary functionality in utilities tab
                empAddB.Enabled = false;
                empUpdateB.Enabled = false;
                empSearchB.Enabled = false;
                empDeleteB.Enabled = false;
                empClearB.Enabled = false;
                empShowAllB.Enabled = false;

                // disable payroll functionality in utilities tab
                empAddB.Enabled = false;
                empUpdateB.Enabled = false;
                empSearchB.Enabled = false;
                empDeleteB.Enabled = false;
                empClearB.Enabled = false;
                empShowAllB.Enabled = false;

                // disable update menu functionality in utilities tab
                empAddB.Enabled = false;
                empUpdateB.Enabled = false;
                empSearchB.Enabled = false;
                empDeleteB.Enabled = false;
                empClearB.Enabled = false;
                empShowAllB.Enabled = false;

                // disable accounts functionality in utilities tab
            }
        }


        //*************************************************EMPLOYEE SECTION START****************************************************

        // instantiate an employee object to be used in the CRUD methods below
        Employee emp;

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: add a new employee
         */
        private void empAddB_Click(object sender, EventArgs e)
        {

            try
            {
                emp = new Employee();

                // shorten and simplfy variables containing input for validation
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

                // validate to ensure that all fields are filled out
                if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(empFName) |
                    String.IsNullOrEmpty(empLName) | String.IsNullOrEmpty(empAddress) | String.IsNullOrEmpty(empCity) |
                    String.IsNullOrEmpty(empProvince) | String.IsNullOrEmpty(empPostal) | String.IsNullOrEmpty(empPhone) |
                    String.IsNullOrEmpty(empSIN) | String.IsNullOrEmpty(empStartDate) | String.IsNullOrEmpty(empStatus) |
                    String.IsNullOrEmpty(empEndDate) | String.IsNullOrEmpty(empPosition))
                {
                    MessageBox.Show("All fields must be filled out. If no End Date, enter 0000-00-00.");
                }

                // validate to ensure that the empNum is of an appropriate length
                else if (empNum.Length > 6 | empNum.Length < 6)
                {
                     MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }

                // validate to ensure that the postal code is of an appropriate length
                else if (empPostal.Length > 6 | empPostal.Length < 6)
                {
                     MessageBox.Show("Please enter valid postal code.");
                }

                // validate to ensure that the SIN is of an appropriate length
                else if (empSIN.Length < 9)
                {
                    MessageBox.Show("Please enter valid SIN.");
                }

                // validate to ensure that the phone number is of an appropriate length
                else if (empPhone.Length < 10)
                {
                    MessageBox.Show("Please enter valid phone number.");
                }

                // validate to ensure that the end date is of an appropriate length
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
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: update an existing employee's information
         */
        private void empUpdateB_Click(object sender, EventArgs e)
        {
            
            try
            {
                // instantiate a new Employee object
                emp = new Employee();

                // shorten and simplfy variables containing input for validation
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

                // validate to ensure that all fields are filled out
                if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(empFName) |
                    String.IsNullOrEmpty(empLName) | String.IsNullOrEmpty(empAddress) | String.IsNullOrEmpty(empCity) |
                    String.IsNullOrEmpty(empProvince) | String.IsNullOrEmpty(empPostal) | String.IsNullOrEmpty(empPhone) |
                    String.IsNullOrEmpty(empSIN) | String.IsNullOrEmpty(empStartDate) | String.IsNullOrEmpty(empStatus) |
                    String.IsNullOrEmpty(empEndDate) | String.IsNullOrEmpty(empPosition))
                {
                    MessageBox.Show("All fields must be filled out. If no End Date, enter 0000-00-00.");
                }

                // validate to ensure that empNum is of an appropriate length
                else if (empNum.Length > 6 | empNum.Length < 6)
                {
                     MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }

                // validate to ensure that postal code is of an appropriate length
                else if (empPostal.Length > 6 | empPostal.Length < 6)
                {
                     MessageBox.Show("Please enter valid postal code.");
                }

                // validate to ensure that SIN is of an appropriate length
                else if (empSIN.Length < 9)
                {
                    MessageBox.Show("Please enter valid SIN.");
                }

                // validate to ensure that phone number is of an appropriate length
                else if (empPhone.Length < 10)
                {
                    MessageBox.Show("Please enter valid phone number.");
                }

                // validate to ensure that end date is of an appropriate length
                else if (empEndDate.Length < 8)
                {
                    MessageBox.Show("Please enter valid End Date. If no End Date, enter 0000-00-00.");
                }
                
                // update employee fields
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

                    // call the update() method from the business layer
                    emp.Update();
                    MessageBox.Show("Update successful.");
                }
                
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
                    
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: search for an employee
         */
        private void empSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                emp = new Employee();

                // validate to ensure that the empNum is filled out and of an appropriate length
                if (String.IsNullOrEmpty(empNumTB.Text) | empNumTB.Text.Length < 6 | empNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
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
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


        /* User: Jonathan Deschene
         * Date: 2017-01-28
         * Time: 6:27 PM
         * Purpose: delete an employee
         */
        private void empDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                emp = new Employee();
                
                // validate to ensure that an appropriate employee number was entered
                if (String.IsNullOrEmpty(empNumTB.Text) | empNumTB.Text.Length < 6 | empNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
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
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-28
         * Time: 6:27 PM
         * Purpose: clears input controls in employee section of the utilitiesTab
         */
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

        /* User: Jonathan Deschene
         * Date: 2017-01-28
         * Time: 6:27 PM
         * Purpose: display all employee data in a datagrid in a new form
         */
        private void empShowAllB_Click(object sender, EventArgs e)
        {
            // load the employeeShowAll form that contains the datagrid
            EmployeeShowAllForm empShow = new EmployeeShowAllForm();
            empShow.Show();            
        }

        //*************************************************EMPLOYEE SECTION END****************************************************

        //*************************************************SALARY SECTION START****************************************************


        // instantiate a salary object to be used in the CRUD methods below
        Salary sal;

        /* User: Jonathan Deschene
         * Date: 2017-01-28
         * Time: 6:27 PM
         * Purpose: add a new salary
         */
        private void salAddB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();

                // variable used in the below validation
                decimal number;

                // validate to ensure that the amount entered is numeric
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

                    // validate to ensure that the fields are not empty
                    if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(fromDate) |
                       String.IsNullOrEmpty(toDate))
                    {
                        MessageBox.Show("All fields must be filled out. If no To Date, enter 0000-00-00.");
                    }

                    // validate to ensure that the employee number is of appropriate length
                    else if (empNum.Length < 6 | empNum.Length > 6)
                    {
                        MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
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
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: update an existing salary's information
        */
        private void salUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                 sal = new Salary();

                 // variable to be used in the below validation
                 decimal number;
                 
                 // validate to ensure that the amount entered is numeric
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

                     // validate to ensure that all important fields are filled out
                     if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(fromDate) |
                        String.IsNullOrEmpty(toDate))
                     {
                         MessageBox.Show("All fields must be filled out. If no To Date, enter 0000-00-00.");
                     }
                     else if (empNum.Length < 6 | empNum.Length > 6)
                     {
                         MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                     }
                     else
                     {
                         // update the objects fields with the new input
                         sal.SalNum = int.Parse(salNumTB.Text);
                         sal.EmpNum = salEmpNumTB.Text;
                         sal.FromDate = salFromDateMTB.Text;
                         sal.ToDate = salToDateMTB.Text;
                         sal.Amount = decimal.Parse(salAmountTB.Text);

                         // update the object in the database 
                         sal.Update();
                         MessageBox.Show("Update successful.");
                     }
                 }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }            
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: search for a salary
         */
        private void salSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();

                // ensure that a salary number has been entered
                if (String.IsNullOrEmpty(salNumTB.Text))
                {
                    MessageBox.Show("Please enter a salary number.");
                }
                else
                {
                    // search by salNum
                    sal.SalNum = int.Parse(salNumTB.Text);

                    // call the search method in the business layer
                    sal.Search();

                    // display search results in the form text boxes
                    salEmpNumTB.Text = sal.EmpNum;
                    salFromDateMTB.Text = sal.FromDate;
                    salToDateMTB.Text = sal.ToDate;
                    salAmountTB.Text = sal.Amount.ToString();
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
         * Date: 2017-01-20
         * Time: 2:45 PM
         * Purpose: deletes a salary
         */
        private void salDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                sal = new Salary();
                // ensure that a salary number has been entered
                if (String.IsNullOrEmpty(salNumTB.Text))
                {
                    MessageBox.Show("Please enter a salary number.");
                }
                else
                {
                    // delete employee from database based on salNumber
                    sal.SalNum = int.Parse(salNumTB.Text);

                    // delete salary
                    sal.Delete();

                    MessageBox.Show("Salary successfully deleted.");
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: clears input controls in the salary section of the utilitiesTab
        */
        private void salClearB_Click(object sender, EventArgs e)
        {
            salEmpNumTB.Text = String.Empty;
            salNumTB.Text = String.Empty;
            salFromDateMTB.Text = String.Empty;
            salToDateMTB.Text = String.Empty;
            salAmountTB.Text = String.Empty;            
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: display all salary data in a datagrid in a new form
        */
        private void salaryReportB_Click(object sender, EventArgs e)
        {
            // load the new form that displays the salary list
            SalaryListReport salaryList = new SalaryListReport();
            salaryList.Show();
       }


        // declare static variable for use in the below salaryHistory method
        public static string salEmpNum;
        
        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: displays all salary information for a user selected employee 
        */
        private void salaryHistoryB_Click(object sender, EventArgs e)
        {
            try
            {
                // validate to ensure that an appropriate employee number was entered
                if (String.IsNullOrEmpty(salEmpNumTB.Text) | salEmpNumTB.Text.Length < 6 | salEmpNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                else
                {
                    salEmpNum = salEmpNumTB.Text;

                    // open the form which will display the salary history report
                    SalaryHistory salHistory = new SalaryHistory();
                    salHistory.Show();
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        //*************************************************SALARY SECTION END****************************************************

        //*************************************************PAYROLL SECTION START****************************************************

        // instantiate a payroll object to be used in the CRUD methods below
        Payroll pay;

       /* User: Jonathan Deschene
       * Date: 2017-01-20
       * Time: 2:45 PM
       * Purpose: add a payroll object to the database
       */
        private void payAddB_Click(object sender, EventArgs e)
        {
            try
            {
                pay= new Payroll();

                // variables delcared for validation directly below
                decimal amnt;
                decimal hrs;

                //validate to ensure that values entered are numeric
                if (Decimal.TryParse(payHoursTB.Text, out amnt) == false |
                    Decimal.TryParse(payAmountTB.Text, out hrs) == false)
                {
                    MessageBox.Show("Please ensure that hours and amount fields are numeric.");
                }
                else
                {
                    // these fields will be used to validate the form data
                    int payNum = int.Parse(payNumTB.Text);
                    string empNum = payEmpNumTB.Text;
                    string fromDate = payStartDateMTB.Text;
                    string toDate = payEndDateMTB.Text;
                    decimal hours = decimal.Parse(payHoursTB.Text);
                    decimal amount = decimal.Parse(payAmountTB.Text);

                    // validate to ensure that input fields are not left empty
                    if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(fromDate) | String.IsNullOrEmpty(toDate))
                    {
                        MessageBox.Show("Please ensure that all fields are filled out.");
                    }
                    
                    //validate to ensure that approprate length employee number is entered
                    else if (empNum.Length > 6 | empNum.Length < 6)
                    {
                        MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                    }

                    else
                    {
                        // assign back office salary input data to a new payroll object
                        pay.EmpNum = empNum;
                        pay.FromDate = fromDate;
                        pay.ToDate = toDate;
                        pay.Hours = hours;
                        pay.Amount = amount;

                        // call Pay add()
                        pay.Add();

                        MessageBox.Show("New payroll for employee " + pay.EmpNum + " successfully added.");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
       * Date: 2017-02-01
       * Time: 11:30 AM
       * Purpose: update an existing payroll's information
       */
        private void payUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
               pay= new Payroll();

                // variables delcared for validation directly below
                decimal amnt;
                decimal hrs;

                //validate to ensure that values entered are numeric
                if (Decimal.TryParse(payHoursTB.Text, out amnt) == false |
                    Decimal.TryParse(payAmountTB.Text, out hrs) == false)
                {
                    MessageBox.Show("Please ensure that hours and amount fields are numeric.");
                }
                else
                {
                    // these fields will be used to validate the form data
                    int payNum = int.Parse(payNumTB.Text);
                    string empNum = payEmpNumTB.Text;
                    string fromDate = payStartDateMTB.Text;
                    string toDate = payEndDateMTB.Text;
                    decimal hours = decimal.Parse(payHoursTB.Text);
                    decimal amount = decimal.Parse(payAmountTB.Text);

                    // validate to ensure that input fields are not left empty
                    if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(fromDate) | String.IsNullOrEmpty(toDate))
                    {
                        MessageBox.Show("Please ensure that all fields are filled out.");
                    }

                    //validate to ensure that approprate length employee number is entered
                    else if (empNum.Length > 6 | empNum.Length < 6)
                    {
                        MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                    }

                    else
                    {
                        // update payroll information with new input
                        pay.PayNum = payNum;
                        pay.EmpNum = empNum;
                        pay.FromDate = fromDate;
                        pay.ToDate = toDate;
                        pay.Hours = hours;
                        pay.Amount = amount;

                        pay.Update();
                        MessageBox.Show("Update successful.");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: search for a payroll object in the database
        */
        private void paySearchB_Click(object sender, EventArgs e)
        {
            try
            {
                pay = new Payroll();

                int payNum;
                //validate to ensure that pay num was entered
                if (int.TryParse(payNumTB.Text, out payNum) == false)
                {
                    MessageBox.Show("Please enter a valid payroll number.");
                }

                else
                {
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
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: delete a payroll object
        */
        private void payDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                pay = new Payroll();

                int payNum;
                //validate to ensure that pay num was entered
                if (int.TryParse(payNumTB.Text, out payNum) == false)
                {
                    MessageBox.Show("Please enter a valid payroll number.");
                }

                else
                {
                    // delete employee from database based on empNumber
                    pay.PayNum = int.Parse(payNumTB.Text);

                    // delete employee
                    pay.Delete();

                    MessageBox.Show("Payroll successfully deleted.");
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: clears input controls in the payroll section of the utilitiesTab
        */
        private void payClearB_Click(object sender, EventArgs e)
        {
               payEmpNumTB.Text = String.Empty;
               payNumTB.Text = String.Empty;
               payStartDateMTB.Text = String.Empty;
               payEndDateMTB.Text = String.Empty;
               payHoursTB.Text = String.Empty; 
               payAmountTB.Text = String.Empty; 
        }

        // variables used in the Pay Stub Report form called in the method below
        public static string empNum;
        public static string endDate;

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: create the Pay Stub Report for
        */
        private void payStubB_Click(object sender, EventArgs e)
        {
            try
            {
                // validate to ensure that the required fields are entered
                if (String.IsNullOrEmpty(payEmpNumTB.Text) | String.IsNullOrEmpty(payEndDateMTB.Text))
                {
                    MessageBox.Show("Please ensure that employee number and pay period end date are entered correctly.");
                }
                
                //validate to ensure that the empNum is of an appropriate length
                else if (payEmpNumTB.Text.Length < 6 | payEmpNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                else
                {
                    // get the user iput
                    empNum = payEmpNumTB.Text;
                    endDate = payEndDateMTB.Text;

                    // open the form that displays the pay stub
                    PayStub paystub = new PayStub();
                    paystub.Show();
                }

            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
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

                // variable used in validation directly below
                decimal amnt;

                // validate to ensure that amount is numeric
                if (Decimal.TryParse(menuPriceTB.Text, out amnt) == false)
                {
                    MessageBox.Show("Please ensure that the Menu Item Price is numeric");
                }
                else
                {
                    // these fields will be used to validate the form data
                    string num = menuNumTB.Text;
                    string name = menuNameTB.Text;
                    string type = menuTypeLB.Text;
                    decimal price = decimal.Parse(menuPriceTB.Text); 

                    // validate to ensure that input fields are not empty
                    if (String.IsNullOrEmpty(num) | String.IsNullOrEmpty(name) | String.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Please ensure that all fields are entered.");
                    }
                    else
                    {
                        // assign menu input data to a new menu object
                        menu.FoodNum = num;
                        menu.FoodName = name;
                        menu.FoodType = type;
                        menu.FoodPrice = price;

                        // call MenuUpdate add()
                        menu.Add();

                        MessageBox.Show("New menu item successfully added.");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * update an existing menu item in the databasee
        */
        private void menuUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
               // variable used in validation directly below
                decimal amnt;

                // validate to ensure that amount is numeric
                if (Decimal.TryParse(menuPriceTB.Text, out amnt) == false)
                {
                    MessageBox.Show("Please ensure that the Menu Item Price is numeric");
                }
                else
                {
                    // these fields will be used to validate the form data
                    string num = menuNumTB.Text;
                    string name = menuNameTB.Text;
                    string type = menuTypeLB.Text;
                    decimal price = decimal.Parse(menuPriceTB.Text); 

                    // validate to ensure that input fields are not empty
                    if (String.IsNullOrEmpty(num) | String.IsNullOrEmpty(name) | String.IsNullOrEmpty(type))
                    {
                        MessageBox.Show("Please ensure that all fields are entered.");
                    }
                    else
                    {
                        // assign menu input data to a existing menu object
                        menu.FoodNum = num;
                        menu.FoodName = name;
                        menu.FoodType = type;
                        menu.FoodPrice = price;

                        menu.Update();
                        MessageBox.Show("Update successful.");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }            
                    
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: search for a menu item in the database
        */
        private void menuSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new MenuUpdate();

                // validate to ensure that a menuNum has been entered
                if (String.IsNullOrEmpty(menuNumTB.Text))
                {
                    MessageBox.Show("Please enter a Menu Item Code");
                }
                else
                {
                    // search by menuNum
                    menu.FoodNum = menuNumTB.Text;

                    // call the search method in the business layer
                    menu.Search();

                    // display search results in the form text boxes
                    menuNumTB.Text = menu.FoodNum;
                    menuNameTB.Text = menu.FoodName;
                    menuTypeLB.Text = menu.FoodType;
                    menuPriceTB.Text = menu.FoodPrice.ToString();
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: delete a menu item in the database
        */
        private void menuDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                menu = new MenuUpdate();

                //validate to ensure that a menu number was entered
                if (String.IsNullOrEmpty(menuNumTB.Text))
                {
                    MessageBox.Show("Please enter an menu item code");
                }
                else
                {
                    // delete menu item from database based on menuNum
                    menu.FoodNum = menuNumTB.Text;

                    // delete menu item
                    menu.Delete();

                    MessageBox.Show("Menu item successfully deleted.");
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: clear all fields in the update menu tab
        */
        private void menuClearB_Click(object sender, EventArgs e)
        {
            menuNumTB.Text = String.Empty;
            menuNameTB.Text = String.Empty;
            menuTypeLB.Text = String.Empty;
            menuPriceTB.Text = String.Empty;          
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: display all menu items in a data grid
        */
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



        //*************************************************RESERVATION SECTION END****************************************************

        //*************************************************TIME_CLOCK SECTION START****************************************************
        
        //creating instance of the Timeclock class
        TimeClock timeC;
        public static int timeclockNumber = 28;
        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: user enters empNum, clicks clock in. saves empNum and saves current time to database
      */
        private void timeClockInB_Click(object sender, EventArgs e)
        {
            try
            {
                //MessageBox.Show("Successfully clocked in.");
                timeC = new TimeClock();
                if (String.IsNullOrEmpty(timeEmpNumTB.Text) | timeEmpNumTB.Text.Length < 6 | timeEmpNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                else
                {
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
                    timeclockNumber++;

                    MessageBox.Show("Employee: " + timeEmpNumTB.Text + " successfully clocked in at: " + time);
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

         

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: allow the user to clock out, saves current time and clocks out empNum
      */
        private void timeClockOutB_Click(object sender, EventArgs e)
        {
            try
            {

                timeC = new TimeClock();
                //create DateTime variable that displays the correct format for date
                if (String.IsNullOrEmpty(timeEmpNumTB.Text) | timeEmpNumTB.Text.Length < 6 | timeEmpNumTB.Text.Length > 6)
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                else
                {
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
                    timeC.ClockOut = Convert.ToDateTime(time);
                    timeC.TimeClockNum = timeclockNumber;

                    // call TimeClock ClockOutUpdate()
                    timeC.ClockOutUpdate();
                    //timeC.UpdateEmpHours();
                    MessageBox.Show("Employee: " + timeEmpNumTB.Text + " successfully clocked out at: " + time);
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

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: add a new shift to the database 
      */
        
       private void schAddB_Click(object sender, EventArgs e)
        {
            try
            {
                timeC = new TimeClock();

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

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: update timeclock/shift information 
      */
        
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

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: search for a timeclock/shift based on employee number and shift date 
       */
       
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

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: delete a timeclock shift based on timeclock number
      */
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

        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: clear all data from boxes
      */
        private void schClearB_Click(object sender, EventArgs e)
        {
            schTimeClockNumTB.Text = String.Empty;
            schEmpNumTB.Text = String.Empty;
            schShiftDateMTB.Text = String.Empty;
            schFromDateMTB.Text = String.Empty;
            schToDateMTB.Text = String.Empty;
            historyFromDateMTB.Text = String.Empty;
            historyToDateMTB.Text = String.Empty;
        }
        
        
        //variables created to use in shifthistory
        public static DateTime historyFromDate;
        public static DateTime historyToDate;

          /* User: Bryan MacFarlane
        * Date: 2017-02-05
        * Time: 12:30 AM
        * Purpose: display shift history report
        */
        private void shiftHistoryB_Click(object sender, EventArgs e)
        {
            try
            {
                //validate to ensure that an appropriate employee number was entered
                if (String.IsNullOrEmpty(historyFromDateMTB.Text) | String.IsNullOrEmpty(historyToDateMTB.Text))
                {
                    MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                }
                else
                {
                    historyToDate = Convert.ToDateTime(historyFromDateMTB.Text);
                    historyFromDate = Convert.ToDateTime(historyToDateMTB.Text);


                    // open the form which will display the salary history report
                    ScheduleHistory schHistory = new ScheduleHistory();
                    schHistory.Show();
                   
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

                    

        //*************************************************TIME_CLCOK SECTION END****************************************************

        //*************************************************ACCOUNTS SECTION START****************************************************


        // instantiate a payroll object to be used in the CRUD methods below
        UserAccess access;

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: create a new account object information
        */
        private void acctAddB_Click(object sender, EventArgs e)
        {
            try
            {
                access = new UserAccess();

                // variables delcared for validation directly below
                int account;
                int userType;

                //validate to ensure that values entered are numeric
                if (int.TryParse(acctIdTB.Text, out account) == false | int.TryParse(acctTypeCB.Text, out userType) == false)
                {
                    MessageBox.Show("Please ensure that the Account ID and Account Type fields are numeric.");
                }
                else
                {
                    // these fields will be used to validate the form data
                    int accntID = int.Parse(acctIdTB.Text);
                    string empNum = acctEmpNumTB.Text;
                    string password = acctPasswordTB.Text;
                    int type = int.Parse(acctTypeCB.Text);

                    // validate to ensure that input fields are not left empty
                    if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Please ensure that all fields are filled out.");
                    }

                    //validate to ensure that approprate length employee number is entered
                    else if (empNum.Length > 6 | empNum.Length < 6)
                    {
                        MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                    }

                    //validate to ensure that account type is not greater than 3 or less than 1
                    else if (type < 1 | type > 3)
                    {
                        MessageBox.Show("Account type number cannot be less than 1 or greater than 3.");
                    }
                    else
                    {
                        // add account information to new UserAccess object
                        access.AccountId = accntID;
                        access.EmpNum = empNum;
                        access.Password = password;
                        access.Type = type;

                        access.Add();
                        MessageBox.Show("New User Access account successfully created.");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-01
        * Time: 11:30 AM
        * Purpose: update an existing account object's information
        */
        private void acctUpdateB_Click(object sender, EventArgs e)
        {
            try
            {
                access = new UserAccess();

                // variables delcared for validation directly below
                int account;
                int userType;

                //validate to ensure that values entered are numeric
                if (int.TryParse(acctIdTB.Text, out account) == false | int.TryParse(acctTypeCB.Text, out userType) == false)
                {
                    MessageBox.Show("Please ensure that the Account ID and Account Type fields are numeric.");
                }
                else
                {
                    // these fields will be used to validate the form data
                    int accntID = int.Parse(acctIdTB.Text);
                    string empNum = acctEmpNumTB.Text;
                    string password = acctPasswordTB.Text;
                    int type = int.Parse(acctTypeCB.Text);

                    // validate to ensure that input fields are not left empty
                    if (String.IsNullOrEmpty(empNum) | String.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Please ensure that all fields are filled out.");
                    }

                    //validate to ensure that approprate length employee number is entered
                    else if (empNum.Length > 6 | empNum.Length < 6)
                    {
                        MessageBox.Show("Employee number cannot be greater or less than than 6 characters.");
                    }

                    //validate to ensure that account type is not greater than 3 or less than 1
                    else if (type < 1 | type > 3)
                    {
                        MessageBox.Show("Account type number cannot be less than 1 or greater than 3.");
                    }
                    else
                    {
                        // update account information with new input
                        access.AccountId = accntID;
                        access.EmpNum = empNum;
                        access.Password = password;
                        access.Type = type;

                        access.Update();
                        MessageBox.Show("Update successful.");
                    }
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

       /* User: Jonathan Deschene
       * Date: 2017-02-01
       * Time: 11:30 AM
       * Purpose: search for an account object in the database
       */
        private void acctSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                access = new UserAccess();

                int acctId;
                //validate to ensure that pay num was entered
                if (int.TryParse(acctIdTB.Text, out acctId) == false)
                {
                    MessageBox.Show("Please enter a valid Account ID.");
                }

                else
                {
                    // search by account ID
                    access.AccountId = int.Parse(acctIdTB.Text);

                    // call the search method in the business layer
                    access.Search();

                    // display search results in the form text boxes
                    acctEmpNumTB.Text = access.EmpNum;
                    acctPasswordTB.Text = access.Password;
                    acctTypeCB.Text = access.Type.ToString();
                    
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-14
        * Time: 9:30 PM
        * Purpose: deletes an account
        */
        private void acctDeleteB_Click(object sender, EventArgs e)
        {
            try
            {
                access = new UserAccess();

                int acctId;
                //validate to ensure that account num was entered
                if (int.TryParse(acctIdTB.Text, out acctId) == false)
                {
                    MessageBox.Show("Please enter a valid account ID.");
                }

                else
                {
                    // delete account from database based on account id
                    access.AccountId = int.Parse(acctIdTB.Text);

                    // delete employee
                    access.Delete();

                    MessageBox.Show("Account successfully deleted.");
                }
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine(exc.ToString());
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /* User: Jonathan Deschene
        * Date: 2017-02-14
        * Time: 9:30 PM
        * Purpose: clears input controls in the account section of the utilitiesTab
        */
        private void acctClearB_Click(object sender, EventArgs e)
        {
            acctIdTB.Text = String.Empty;
            acctEmpNumTB.Text = String.Empty;
            acctPasswordTB.Text = String.Empty;
            acctTypeCB.Text = String.Empty;
        }

      
        private void acctShowAllB_Click(object sender, EventArgs e)
        {            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        //*************************************************ACCOUNT SECTION END****************************************************

    }
}
