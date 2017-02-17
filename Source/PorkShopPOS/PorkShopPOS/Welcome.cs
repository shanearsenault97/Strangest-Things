/* User: Heather Watterson, Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: User authentication/login page that grants access to the applicaton based on permission level linked to employee #
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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }


        // used to hold the user permission type which can then be accessed from the BackOffice 
        public static int accessLevel;

        /* User: Heather Watterson, Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: validate a user using employee number and password from the database and allow them to access the POS screen
        */
        private void porkShopPOSButton_Click_1(object sender, EventArgs e)
        {
            try
                {   
                if (string.IsNullOrEmpty(empNumTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    MessageBox.Show("Please enter your credentials.");
                }
                else 
                {
                        UserAccess login = new UserAccess();
                        login.EmpNum = empNumTextBox.Text.ToString();
                        login.Login();

                        //compare the password in the database to the password that was input
                        if (login.EmpNum.Equals(empNumTextBox.Text.ToString()) && login.Password.Equals(passwordTextBox.Text.ToString()))
                        {
                            
                            accessLevel = login.Type;
                            ThePorkShopPOS pos = new ThePorkShopPOS();
                            pos.Show();
                            empNumTextBox.Text = String.Empty;
                            passwordTextBox.Text = String.Empty;
                        }
                        else
                        {if (login.Password != passwordTextBox.Text.ToString())
                            {
                                MessageBox.Show("Your username or password is incorrect.  Please try again.");
                            }
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


        /* User: Heather Watterson, Jonathan Deschene
       * Date: 2017-01-20
       * Time: 2:45 PM
       * Purpose: //validate a user using employee number and password from the database and allow them to access the Back Office screen
       */
        private void porkShopOfficeButton_Click(object sender, EventArgs e)
        {
            try
            {  
                if (string.IsNullOrEmpty(empNumTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    MessageBox.Show("Please enter your credentials.");
                }
                else 
                {
                    UserAccess login = new UserAccess();

                    login.EmpNum = empNumTextBox.Text.ToString();
                    login.Login();

                    
                    //compare the password in the database to the password that was input
                    if (login.EmpNum.Equals(empNumTextBox.Text) && login.Password.Equals(passwordTextBox.Text))
                    {

                        accessLevel = login.Type;
                        BackOffice office = new BackOffice();
                        office.Show();
                        empNumTextBox.Text = String.Empty;
                        passwordTextBox.Text = String.Empty;
                    }
                    else
                    {
                        if (login.Password != passwordTextBox.Text.ToString())
                        {
                            MessageBox.Show("Your username or password is incorrect.  Please try again.");
                        }
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

        // closes the Welcome page
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
         /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: create database; this function would be removed in the production version
        */
        private void createDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseCreation dbCreate = new DatabaseCreation();
                dbCreate.createDatabaseTables();

                
            }
            catch (Exception exception)
            {
                Console.WriteLine(e.ToString());
            }
        }       
        }
     
    }
