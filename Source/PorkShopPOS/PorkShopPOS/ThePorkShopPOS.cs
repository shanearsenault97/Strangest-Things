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
        int numGuests;
        string item = "";

        public ThePorkShopPOS()
        {
            InitializeComponent();
        }

        private void ThePorkShopPOS_Load(object sender, EventArgs e) {

            

            cmbMix.Text = "None";
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

        private void btnGarlicSoup_Click(object sender, EventArgs e) {
            item = "Roasted Garlic Soup";
            if (rdbRoll.Checked) {
                item += "+Crusty Roll";
            } else if (rdbCornbread.Checked) {
                item += "+Cornbread";
            } else if (rdbBiscuit.Checked) {
                item += "+Biscuit";
            } else if (rdbChipotle.Checked) {
                item += "+Chipotle Mayo";
            }
            listOrder.Items.Insert(1, item);
        }

        private void btnMacBalls_Click(object sender, EventArgs e) {
            item = "Mac n Cheese Balls";
            if (rdbRoll.Checked) {
                item += "+Crusty Roll";
            } else if (rdbCornbread.Checked) {
                item += "+Cornbread";
            } else if (rdbBiscuit.Checked) {
                item += "+Biscuit";
            } else if (rdbChipotle.Checked) {
                item += "+Chipotle Mayo";
            }
            listOrder.Items.Insert(1, item);
        }

        private void btnNachos_Click(object sender, EventArgs e) {
            item = "Pulled Pork Nachos";
            if (rdbRoll.Checked) {
                item += "+Crusty Roll";
            } else if (rdbCornbread.Checked) {
                item += "+Cornbread";
            } else if (rdbBiscuit.Checked) {
                item += "+Biscuit";
            } else if (rdbChipotle.Checked) {
                item += "+Chipotle Mayo";
            }
            listOrder.Items.Insert(1, item);
        }

        private void btnPorkzilla_Click(object sender, EventArgs e) {
            item = "Porkzilla";
            if (rdbOnRings.Checked) {
                item += "+Onion Rings";
            } else if (rdbHomeFries.Checked) {
                item += "+Home Fries";
            } else if (rdbMacNCheese.Checked) {
                item += "+Mac n Cheese";
            } else if (rdbMashed.Checked) {
                item += "+Mashed Potatoes";
            }
            listOrder.Items.Insert(1, item);
        }

        private void btnMeatloaf_Click(object sender, EventArgs e) {
            item = "Bacon Wrapped Meatloaf";
            if (rdbOnRings.Checked) {
                item += "+Onion Rings";
            } else if (rdbHomeFries.Checked) {
                item += "+Home Fries";
            } else if (rdbMacNCheese.Checked) {
                item += "+Mac n Cheese";
            } else if (rdbMashed.Checked) {
                item += "+Mashed Potatoes";
            }
            listOrder.Items.Insert(1, item);
        }

        private void btnSteak_Click(object sender, EventArgs e) {
            item = "Smoked Flap Steak";
            if (rdbOnRings.Checked) {
                item += "+Onion Rings";
            } else if (rdbHomeFries.Checked) {
                item += "+Home Fries";
            } else if (rdbMacNCheese.Checked) {
                item += "+Mac n Cheese";
            } else if (rdbMashed.Checked) {
                item += "+Mashed Potatoes";
            }
            listOrder.Items.Insert(1, item);
        }

        private void btnCanadian_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Molson Canadian");
        }

        private void btnBudweiser_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Budweiser");
        }

        private void btnKeiths_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Alexander Keiths Red Amber Ale");
        }

        private void btnMoose_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Moosehead Light");
        }

        private void btnAlpine_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Alpine");
        }

        private void btnCoors_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Coors Light");
        }

        private void btnGuinness_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Guinness");
        }

        private void btnCorona_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Corona");
        }

        private void btnMGD_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Miller Genuine Draft");
        }

        private void btnRye_Click(object sender, EventArgs e) {
            item = "Rye";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        private void btnScotch_Click(object sender, EventArgs e) {
            item = "Scotch";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        private void btnVodka_Click(object sender, EventArgs e) {
            item = "Vodka";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        private void btnRum_Click(object sender, EventArgs e) {
            item = "Rum";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        private void btnGin_Click(object sender, EventArgs e) {
            item = "Gin";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        private void btnMargerita_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Margerita");
        }

        private void btnPinaColada_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Pina Colada");
        }

        private void btnIcedTea_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Long Island Iced Tea");
        }

        private void btnALSlammer_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Alabama Slammer");
        }

        private void btnDeleteItem_Click(object sender, EventArgs e) {
            if (listOrder.SelectedIndex >= 0) {
                if (!listOrder.SelectedItem.ToString().Equals("-Food-") && !listOrder.SelectedItem.ToString().Equals("-Drinks-")) {
                    listOrder.Items.RemoveAt(listOrder.SelectedIndex);
                }
            }
        }

        private void btnSeparateStarter_Click(object sender, EventArgs e) {
            if (rdbRoll.Checked) {
                listOrder.Items.Insert(1, "Crusty Roll");
            } else if (rdbCornbread.Checked) {
                listOrder.Items.Insert(1, "Cornbread");
            } else if (rdbBiscuit.Checked) {
                listOrder.Items.Insert(1, "Biscuit");
            } else if (rdbChipotle.Checked) {
                listOrder.Items.Insert(1, "Chipotle Mayo");
            }
        }

        private void btnSeparateSide_Click(object sender, EventArgs e) {
            if (rdbOnRings.Checked) {
                listOrder.Items.Insert(1, "Onion Rings");
            } else if (rdbHomeFries.Checked) {
                listOrder.Items.Insert(1, "Home Fries");
            } else if (rdbMacNCheese.Checked) {
                listOrder.Items.Insert(1, "Mac n Cheese");
            } else if (rdbMashed.Checked) {
                listOrder.Items.Insert(1, "Mashed Potatoes");
            }
        }

        private void btnSubmitOrder_Click(object sender, EventArgs e) {
            bool guestTest = int.TryParse(txtNumGuestsOr.Text, out numGuests);
            if (cmbServer.SelectedItem == null) {
                MessageBox.Show("Please select a server.", "Error");
            } else if (cmbTableOr.SelectedItem == null) {
                MessageBox.Show("Please select a table.", "Error");
            } else if (txtNumGuestsOr.Text.Equals("") || !guestTest) {
                MessageBox.Show("Please enter a valid number of guests.", "Error");
            } else if (listOrder.Items.Count <= 2) {
                MessageBox.Show("You must add something to the order list to submit.", "Error");
            } else {
                bool drinks = false;
                foreach (string listItem in listOrder.Items) {
                    if (listItem.Equals("-Food-") || listItem.Equals("-Drinks-")) {
                        if (listItem.Equals("-Drinks-")) {
                            drinks = true;
                        }
                    } else {
                        if (drinks) {

                        } else {

                        }
                    }
                }
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (cmbTableRes.Text == "" || dateReservations.Text == "" || dateTime.Text == "" || txtName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("All form elements are required to reserve a table.");
            }
            else
            {
                Reservation reservation = new Reservation();
                reservation.TableNum = cmbTableRes.Text;
                reservation.ReservationDate = dateReservations.Text;
                reservation.ReservationTime = dateTime.Text;
                reservation.ReservationName = txtName.Text;
                reservation.ReservationContact = txtPhone.Text;

                reservation.Add();
            }
        }

        private void btnShowRes_Click(object sender, EventArgs e)
        {
            ReservationShowAll resShowAll = new ReservationShowAll();
            resShowAll.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }    
    }
}
