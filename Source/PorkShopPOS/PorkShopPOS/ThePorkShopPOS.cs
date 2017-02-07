using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PorkShopPOS
{
    public partial class ThePorkShopPOS : Form
    {

        //Declare variables
        Employee Employee;
        Tables Tables;
        int numGuests;
        string item = "";
        List<string> foodIds = new List<string>();
        List<string> foodDescriptions = new List<string>();
        List<string> foodPrices = new List<string>();
        List<string> barIds = new List<string>();
        List<string> barDescriptions = new List<string>();
        List<string> barPrices = new List<string>();
        string[] individualItems;
        char itemDelim = '+';
        char nameDelim = ' ';
        decimal total = 0;
        string[] empNames;
        string date;
        bool orderSubmitted = false;
        bool billPrinted = false;

        public ThePorkShopPOS()
        {
            InitializeComponent();
        }

        private void ThePorkShopPOS_Load(object sender, EventArgs e) {

            

            cmbMix.Text = "None";
            cmbMix.SelectedIndex = cmbMix.FindString("None");
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
                            individualItems = listItem.Split(itemDelim);
                            Bar bar = new Bar();
                            bar.BarDescription = individualItems[0];
                            bar.Search();
                            barIds.Add(bar.BarId);
                            barDescriptions.Add(bar.BarDescription);
                            barPrices.Add(bar.BarPrice);
                            total += decimal.Parse(bar.BarPrice);
                        } else {
                            individualItems = listItem.Split(itemDelim);
                            Food food = new Food();
                            food.FoodDescription = individualItems[0];
                            food.Search();
                            foodIds.Add(food.FoodNum);
                            foodDescriptions.Add(food.FoodDescription);
                            foodPrices.Add(food.FoodPrice);
                            total += decimal.Parse(food.FoodPrice);
                            if (individualItems.Count() == 2) {
                                food.FoodDescription = individualItems[1];
                                food.Search();
                                foodIds.Add(food.FoodNum);
                                foodDescriptions.Add(food.FoodDescription);
                                foodPrices.Add("0");
                            }
                        }
                    }
                }
                empNames = cmbServer.SelectedItem.ToString().Split(nameDelim);
                Employee emp = new Employee();
                emp.EmpFName = empNames[0];
                emp.EmpLName = empNames[1];
                emp.SearchByName();
                Order order = new Order();
                order.EmpNum = emp.EmpNum;
                order.TableNum = cmbTableOr.SelectedItem.ToString();
                DateTime today = DateTime.Today;
                date = today.ToString("d");
                date.Replace("/", "-");
                order.OrderDate = date;
                order.OrderTime = DateTime.Now.ToString("HH:mm:ss");
                order.NumGuests = txtNumGuestsOr.Text;
                order.OrderTotal = total.ToString();
                order.Add();
                int lineNum = 1;
                var groups = foodDescriptions.GroupBy(v => v);
                foreach(var group in groups) {
                    decimal linePrice = 0;
                    Line line = new Line();
                    for (int i = 0; i < foodIds.Count(); i++) {
                        if (foodDescriptions[i].Equals(group.Key)) {
                            linePrice += decimal.Parse(foodPrices[i]);
                            line.FoodId = "'" + foodIds[i] + "'";
                        }
                    }
                    line.LineQty = group.Count().ToString();
                    line.LineNum = lineNum.ToString();
                    line.BarId = "NULL";
                    line.LinePrice = linePrice.ToString();
                    order.Search();
                    line.OrderNum = order.OrderNum;
                    line.Add();
                    lineNum++;
                }
                groups = barDescriptions.GroupBy(v => v);
                foreach (var group in groups) {
                    decimal linePrice = 0;
                    Line line = new Line();
                    for (int i = 0; i < barIds.Count(); i++) {
                        if (barDescriptions[i].Equals(group.Key)) {
                            linePrice += decimal.Parse(barPrices[i]);
                            line.BarId = "'" + barIds[i] + "'";
                        }
                    }
                    line.LineQty = group.Count().ToString();
                    line.LineNum = lineNum.ToString();
                    line.OrderNum = order.OrderNum;
                    line.FoodId = "NULL";
                    line.LinePrice = linePrice.ToString();
                    line.Add();
                    lineNum++;
                }
                orderSubmitted = true;
                MessageBox.Show("Order successfully submitted!", "Order Confirmation");
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

        private void btnPrintBill_Click(object sender, EventArgs e) {
            if (orderSubmitted) {
                billPrinted = true;
            }
        }

        private void btnPayBill_Click(object sender, EventArgs e) {
            if (billPrinted) {
                Employee = null;
                Tables = null;
                numGuests = 0;
                item = "";
                foodIds = null;
                foodDescriptions = null;
                foodPrices = null;
                barIds = null;
                barDescriptions = null;
                barPrices = null;
                individualItems = null;
                total = 0;
                empNames = null;
                date = null;
                orderSubmitted = false;
                billPrinted = false;
                listOrder.Items.Clear();
                listOrder.Items.Add("-Food-");
                listOrder.Items.Add("-Drinks-");
                rdbNoSides.Select();
                rdbNoStarters.Select();
                cmbMix.SelectedIndex = cmbMix.FindString("None");
                txtNumGuestsOr.Text = "";
            }
        }

    }
}
