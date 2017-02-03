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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }


        //set default access level
        Int32 accessLevel = 1;


        //validate a user using employee number and password from the database and allow them to access the POS screen
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
                        login.Emp_Num = empNumTextBox.Text.ToString();
                        login.Login();

                        //compare the password in the database to the password that was input
                        if (login.Emp_Num.Equals(empNumTextBox.Text.ToString()) && login.password.Equals(passwordTextBox.Text.ToString()))
                        {
                            
                            accessLevel = login.User_Type_Code;
                            ThePorkShopPOS pos = new ThePorkShopPOS();
                            pos.Show();
                        }
                        else
                        {if (login.password != passwordTextBox.Text.ToString())
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


        //validate a user using employee number and password from the database and allow them to access the Back Office screen
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

                    login.Emp_Num = empNumTextBox.Text.ToString();
                    login.Login();

                    //compare the password in the database to the password that was input
                    if (login.Emp_Num.Equals(empNumTextBox.Text) && login.password.Equals(passwordTextBox.Text))
                    {
                        accessLevel = login.User_Type_Code;
                        BackOffice office = new BackOffice();
                        office.Show();
                    }
                    else
                    {
                        if (login.password != passwordTextBox.Text.ToString())
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

        //set up password for user with default access level
        private void newUserButton_Click(object sender, EventArgs e)
        {
            UserAccess login = new UserAccess();
            login.Emp_Num = empNumTextBox.Text;
            login.password = passwordTextBox.Text;
            login.Add();
        }
      
    }
    }
