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

        public ThePorkShopPOS() {
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
        private void btnBackOffice_Click(object sender, EventArgs e) {
            this.Close();
            BackOffice officeUI = new BackOffice();
            officeUI.Show();
        }

        // close the pos UI and load the login UI
        private void btnLogout_Click(object sender, EventArgs e) {
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
            if (orderSubmitted) {
                MessageBox.Show("You cannot submit another order until the previous order's bill is payed.", "Error");
            } else {
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
                                barCompleteDesc.Add(listItem);
                                if (!chkHappyHr.Checked) {
                                    barPrices.Add(bar.BarPrice);
                                    total += decimal.Parse(bar.BarPrice);
                                } else {
                                    barPrices.Add((float.Parse(bar.BarPrice) - float.Parse(bar.BarPrice) * 0.15).ToString());
                                    total += decimal.Parse((float.Parse(bar.BarPrice) - float.Parse(bar.BarPrice) * 0.15).ToString());
                                }
                            } else {
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
                    orderSubmitted = true;
                    MessageBox.Show("Order successfully submitted!", "Order Confirmation");
                }
            }
        }

        private void btnReserve_Click(object sender, EventArgs e) {
            if (cmbTableRes.Text == "" || dateReservations.Text == "" || dateTime.Text == "" || txtName.Text == "" || txtPhone.Text.Contains('_')) {
                MessageBox.Show("All form elements are required to reserve a table.");
            } else {
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
            frmReservationShowAll resShowAll = new frmReservationShowAll();
            resShowAll.Show();
        }

        private void btnPrintBill_Click(object sender, EventArgs e) {
            if (orderSubmitted) {
                billPrinted = true;
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
                billReport.Show();
            }
        }

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
