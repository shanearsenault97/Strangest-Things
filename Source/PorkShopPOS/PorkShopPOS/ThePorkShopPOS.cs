/**
 * User: Noah Gallant, Shane Arsenault
 * Date: 2/15/2017
 * Time: 10:53 AM
 * Purpose: The purpose of this POS system is to manage customer orders.
 *          It also includes reservations.
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
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PorkShopPOS {
    public partial class ThePorkShopPOS : Form {

        //Declare variables
        Employee Employee;
        Tables Tables;
        Order Order;
        int numGuests;
        string item = "";
        List<string> foodIds = new List<string>();
        List<string> foodDescriptions = new List<string>();
        List<string> foodCompleteDesc = new List<string>();
        List<string> foodPrices = new List<string>();
        List<string> foodCompletePrices = new List<string>();
        List<string> barIds = new List<string>();
        List<string> barDescriptions = new List<string>();
        List<string> barCompleteDesc = new List<string>();
        List<string> barPrices = new List<string>();
        List<string> descriptions = new List<string>();
        List<string> prices = new List<string>();
        string[] individualItems;
        char itemDelim = '+';
        char nameDelim = ' ';
        decimal total = 0;
        string[] empNames;
        string date;
        bool orderSubmitted = false;
        bool billPrinted = false;
        float taxAmount;
        float totalAfterTax;

        //Default constructor
        public ThePorkShopPOS() {
            InitializeComponent();
        }

        //Prepopulates information when the form loads
        private void ThePorkShopPOS_Load(object sender, EventArgs e) {
            //Set mix combobox defaults
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


        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: open the back office UI close the POS  UI 
        */
        private void btnBackOffice_Click(object sender, EventArgs e) {
            this.Close();
            BackOffice officeUI = new BackOffice();
            officeUI.Show();
        }

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: close the boack office UI 
        */
        private void btnLogout_Click(object sender, EventArgs e) {
            this.Close();          
        }

        //handles garlic soup being ordered
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

        //handles mac n cheese balls being ordered
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

        //handles nachos being ordered
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

        //Handles a porkzilla being ordered
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

        //handles a meatloaf being ordered
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

        //handles a steak being ordered
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

        //Handles molson canadian being ordered
        private void btnCanadian_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Molson Canadian");
        }

        //Handles budweiser being ordered
        private void btnBudweiser_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Budweiser");
        }

        //Handles keiths being ordered
        private void btnKeiths_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Alexander Keiths Red Amber Ale");
        }

        //Handles moose light being ordered
        private void btnMoose_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Moosehead Light");
        }

        //Handles alpine being ordered
        private void btnAlpine_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Alpine");
        }

        //Handles coors being ordered
        private void btnCoors_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Coors Light");
        }

        //Handles guiness being ordered
        private void btnGuinness_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Guinness");
        }

        //Handles corona being ordered
        private void btnCorona_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Corona");
        }

        //Handles MGD being ordered
        private void btnMGD_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Miller Genuine Draft");
        }

        //Handles rye being ordered
        private void btnRye_Click(object sender, EventArgs e) {
            item = "Rye";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        //Handles scotch being ordered
        private void btnScotch_Click(object sender, EventArgs e) {
            item = "Scotch";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        //Handles vodka being ordered
        private void btnVodka_Click(object sender, EventArgs e) {
            item = "Vodka";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        //Handles rum being ordered
        private void btnRum_Click(object sender, EventArgs e) {
            item = "Rum";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        //Handles gin being ordered
        private void btnGin_Click(object sender, EventArgs e) {
            item = "Gin";
            if (!cmbMix.Text.Equals("None")) {
                item += "+" + cmbMix.Text;
            }
            listOrder.Items.Add(item);
        }

        //Handles margerita being ordered
        private void btnMargerita_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Margerita");
        }

        //Handles pina colada being ordered
        private void btnPinaColada_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Pina Colada");
        }

        //Handles iced tea being ordered
        private void btnIcedTea_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Long Island Iced Tea");
        }

        //Handles an alabama slammer being ordered
        private void btnALSlammer_Click(object sender, EventArgs e) {
            listOrder.Items.Add("Alabama Slammer");
        }

        //Deletes the selected item in the orders listbox
        private void btnDeleteItem_Click(object sender, EventArgs e) {
            if (listOrder.SelectedIndex >= 0) {
                if (!listOrder.SelectedItem.ToString().Equals("-Food-") && !listOrder.SelectedItem.ToString().Equals("-Drinks-")) {
                    listOrder.Items.RemoveAt(listOrder.SelectedIndex);
                }
            }
        }

        //Handles a separate starter being ordered
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

        //Handles a separate side being ordered
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

        //Handles the submitting of an order
        private void btnSubmitOrder_Click(object sender, EventArgs e) {
            if (orderSubmitted) {
                //Shows message if previous order's bill hasn't been payed
                MessageBox.Show("You cannot submit another order until the previous order's bill is payed.", "Error");
            } else {
                bool guestTest = int.TryParse(txtNumGuestsOr.Text, out numGuests);
                if (cmbServer.SelectedItem == null) {
                    //Makes sure a server is selected
                    MessageBox.Show("Please select a server.", "Error");
                } else if (cmbTableOr.SelectedItem == null) {
                    //Makes sure a table is selected
                    MessageBox.Show("Please select a table.", "Error");
                } else if (txtNumGuestsOr.Text.Equals("") || !guestTest) {
                    //Makes sure a valid number of guests is entered
                    MessageBox.Show("Please enter a valid number of guests.", "Error");
                } else if (listOrder.Items.Count <= 2) {
                    //Makes sure items are added to the order list
                    MessageBox.Show("You must add something to the order list to submit.", "Error");
                } else {
                    //Declare variable
                    bool drinks = false;
                    //Loops through each item in the order list
                    foreach (string listItem in listOrder.Items) {
                        //Makes sure the drinks and food lines aren't included
                        if (listItem.Equals("-Food-") || listItem.Equals("-Drinks-")) {
                            if (listItem.Equals("-Drinks-")) {
                                //Sets the drinks variable to true when the drinks are reacher
                                drinks = true;
                            }
                        } else {
                            if (drinks) {
                                //Goes to the database and gets drink info
                                //and adds it to some lists to be used later
                                individualItems = listItem.Split(itemDelim);
                                Bar bar = new Bar();
                                bar.BarDescription = individualItems[0];
                                bar.Search();
                                barIds.Add(bar.BarId);
                                barDescriptions.Add(bar.BarDescription);
                                barCompleteDesc.Add(listItem);
                                //Checks if happy hour checkbox is checked
                                if (!chkHappyHr.Checked) {
                                    barPrices.Add(bar.BarPrice);
                                    total += decimal.Parse(bar.BarPrice);
                                } else {
                                    barPrices.Add((float.Parse(bar.BarPrice) - float.Parse(bar.BarPrice) * 0.15).ToString());
                                    total += decimal.Parse((float.Parse(bar.BarPrice) - float.Parse(bar.BarPrice) * 0.15).ToString());
                                }
                            } else {
                                //Goes to the database and gets food info
                                //and adds it to some lists to be used later
                                individualItems = listItem.Split(itemDelim);
                                Food food = new Food();
                                food.FoodDescription = individualItems[0];
                                food.Search();
                                foodIds.Add(food.FoodNum);
                                foodDescriptions.Add(food.FoodDescription);
                                foodCompleteDesc.Add(listItem);
                                foodPrices.Add(food.FoodPrice);
                                foodCompletePrices.Add(food.FoodPrice);
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
                    //Gathers information for the order and submits the order to the database
                    empNames = cmbServer.SelectedItem.ToString().Split(nameDelim);
                    Employee emp = new Employee();
                    emp.EmpFName = empNames[0];
                    emp.EmpLName = empNames[1];
                    emp.SearchByName();
                    Employee = emp;
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
                    taxAmount = (float)total * (float)0.15;
                    totalAfterTax = (float)total + taxAmount;
                    order.Add();
                    //Gathers information about the order and submits each line to the database
                    int lineNum = 1;
                    var groups = foodDescriptions.GroupBy(v => v);
                    foreach (var group in groups) {
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
                    //This is only needed if one kind of item is ordered
                    if (groups.Count() == 0) {
                        decimal linePrice = 0;
                        Line line = new Line();
                        for (int i = 0; i < foodIds.Count(); i++) {
                            linePrice += decimal.Parse(foodPrices[i]);
                            line.FoodId = "'" + foodIds[i] + "'";
                        }
                        line.LineQty = foodDescriptions.Count().ToString();
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
                    Order = order;
                    //Sets the orderSubmitted bool to true and displays the order was submitted
                    orderSubmitted = true;
                    MessageBox.Show("Order successfully submitted!", "Order Confirmation");
                }
            }
        }

        private void btnReserve_Click(object sender, EventArgs e) {
            //validation
            if (cmbTableRes.Text == "" || dateReservations.Text == "" || dateTime.Text == "" || txtName.Text == "" || txtPhone.Text.Contains('_')) {
                MessageBox.Show("All form elements are required to reserve a table.");
            } else {
                //adds the reservation
                if (MessageBox.Show("Confirmation", "Are you sure you want to add this?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                    Reservation reservation = new Reservation();
                    reservation.TableNum = cmbTableRes.Text;
                    reservation.ReservationDate = dateReservations.Text;
                    reservation.ReservationTime = dateTime.Text;
                    reservation.ReservationName = txtName.Text;
                    reservation.ReservationContact = txtPhone.Text;

                    reservation.Add();
                }
            }
        }

        private void btnShowRes_Click(object sender, EventArgs e) {
            //shows all of the reservations
            frmReservationShowAll resShowAll = new frmReservationShowAll();
            resShowAll.Show();
        }

        //Handles the printing of a customer's bill
        private void btnPrintBill_Click(object sender, EventArgs e) {
            //Makes sure the order has already been submitted
            if (orderSubmitted) {
                //Sets the billPrinted bool to true
                billPrinted = true;
                //Loops through each item and adds it to a list
                foreach (string food in foodCompleteDesc) {
                    descriptions.Add(food);
                }
                foreach (string price in foodCompletePrices) {
                    prices.Add(float.Parse(price).ToString("C"));
                }
                foreach (string bar in barCompleteDesc) {
                    descriptions.Add(bar);
                }
                foreach (string price in barPrices) {
                    prices.Add(float.Parse(price).ToString("C"));
                }
                //Uses all gathered order info to generate the bill using crystal reports
                Bill bill = new Bill();
                bill.SetParameterValue("EmpFName", Employee.EmpFName.ToString());
                bill.SetParameterValue("OrderDate", Order.OrderDate.ToString());
                bill.SetParameterValue("OrderTime", Order.OrderTime.ToString());
                bill.SetParameterValue("OrderNum", Order.OrderNum.ToString());
                bill.SetParameterValue("TableNum", Order.TableNum.ToString());
                bill.SetParameterValue("NumGuests", Order.NumGuests.ToString());
                bill.SetParameterValue("OrderTotal", "$" + Order.OrderTotal.ToString());
                bill.SetParameterValue("TaxAmount", taxAmount.ToString("C"));
                bill.SetParameterValue("TotalAfterTax", totalAfterTax.ToString("C"));
                bill.SetParameterValue("@Desc", descriptions.ToArray());
                bill.SetParameterValue("@Prices", prices.ToArray());
                BillReport billReport = new BillReport();
                billReport.reportDocument = bill;
                //Shows the bill
                billReport.Show();
            }
        }

        //Clears all controls and variables when clicked
        private void btnPayBill_Click(object sender, EventArgs e) {
            if (billPrinted) {
                Employee = null;
                Tables = null;
                numGuests = 0;
                item = "";
                foodIds.Clear();
                foodDescriptions.Clear();
                foodCompleteDesc.Clear();
                foodPrices.Clear();
                foodCompletePrices.Clear();
                barIds.Clear();
                barDescriptions.Clear();
                barCompleteDesc.Clear();
                barPrices.Clear();
                descriptions.Clear();
                prices.Clear();
                Array.Clear(individualItems, 0, individualItems.Length);
                total = 0;
                empNames = null;
                date = null;
                orderSubmitted = false;
                billPrinted = false;
                taxAmount = 0;
                totalAfterTax = 0;
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
