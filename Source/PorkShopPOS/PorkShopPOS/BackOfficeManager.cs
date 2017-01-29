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
    public partial class BackOfficeManager : Form
    {
        public BackOfficeManager()
        {
            InitializeComponent();
        }


        //*************************************************EMPLOYEE SECTION START****************************************************

        // add a new employee
        private void empAddB_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$;");
                connection.Open();

                string strTable = "INSERT INTO employee "; 
                string strFields = "(empFName, empLName, empAddress, empCity, empProv, empPostal, empPhone, empSIN, empStartDate, empStatus, empEndDate, empPosition)";
                string strValues = "VALUES ('" + empFNameTB.Text + "', '" + empLNameTB.Text + "', '" + empAddressTB.Text + "', '" + empCityTB.Text + "', '"
                    + empProvinceTB.Text + "', '" + empPostalTB.Text + "', '" + empPhoneTB.Text + "', '" + empSinTB.Text + "', '" + empStartDateDTP.Value.TimeOfDay + "', '"
                    + empStatusCB.Text + "', '" + empEndDateMTB.Text + "' '" + empPositionCB.Text + "')";
                string sql = strTable + strFields + strValues;
     
            
                MySqlCommand cmd;
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Error 0: it isn't working");
            }
        }


        // update an existing employee's information
        private void empUpdateB_Click(object sender, EventArgs e)
        {

            
        }


        // search for an employee
        private void empSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$;");
                connection.Open();

                string sql = "Select * From employee";

                MySqlCommand cmd;
                cmd = new MySqlCommand(sql, connection);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    empNumTB.Text = reader.GetInt16(0).ToString();
                    empFNameTB.Text = reader.GetValue(1).ToString();
                    empLNameTB.Text = reader.GetValue(2).ToString();
                    empAddressTB.Text = reader.GetValue(3).ToString();
                    empCityTB.Text = reader.GetValue(4).ToString();
                    empProvinceTB.Text = reader.GetValue(5).ToString();
                    empPostalTB.Text = reader.GetValue(6).ToString();
                    empPhoneTB.Text = reader.GetValue(7).ToString();
                    empSinTB.Text = reader.GetValue(8).ToString();
                    empStartDateDTP.Text = reader.GetDateTime(9).ToString();
                    empStatusCB.Text = reader.GetValue(10).ToString();
                    empEndDateMTB. = reader.GetDateTime(11).ToString();
                    empPositionCB.Text = reader.GetValue(12).ToString();
                }


                reader.Close();
                cmd.Dispose();
                connection.Close();

            }
            catch
            {
                Console.WriteLine("Error 0: it isn't working");
            }
        }


        // delete an employee
        private void empDeleteB_Click(object sender, EventArgs e)
        {

        }


        //*************************************************EMPLOYEE SECTION END****************************************************

     

  
    }
}
