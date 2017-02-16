/* User: Jonathan Deschene
* Date: 2017-01-20
* Time: 2:45 PM
* Purpose: Data layer class for ShowAll object
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PorkShopPOS
{
    class ShowAllDAO
    {

        string connection = "server=localhost; database=pork_shop; user=pork_shop_admin; password=5tr&ng3rTh!ng$; Convert Zero Datetime=True;";
        DataTable dataTable;
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        string empQuery = "SELECT * FROM employee;";
        string salQuery = "SELECT * FROM salary;";
        string payQuery = "SELECT * FROM payroll;";
        string menuQuery = "SELECT * FROM food;";
        string reservationQuery = "SELECT * FROM reservation;";

        /* User: Jonathan Deschene
        * Date: 2017-01-20
        * Time: 2:45 PM
        * Purpose: the ShowAll basic method which provides access to the database, dumping the data into a datagrid 
        */

        // code borrowed from http://stackoverflow.com/questions/14020038/filling-a-datatable-in-c-sharp-using-mysql
        public void showAll(string query, DataGridView dgv)
        {
            dataTable = new DataTable();
            dataTable.Clear();

            try
            {
                conn = new MySqlConnection(connection);
                conn.Open();
                cmd = new MySqlCommand
                {
                    Connection = conn,
                    CommandText = query
                };
                cmd.ExecuteNonQuery();

                // send data to datagrid
                da = new MySqlDataAdapter(cmd);
                da.Fill(dataTable);

                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

                dgv.DataSource = dataTable;
                dgv.DataMember = dataTable.TableName;
                dgv.AutoResizeColumns();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // get all data from Employee table
        public void showAllEmployees(DataGridView dgv)
        {
            showAll(empQuery, dgv);
        }

        // get all data from MenuUpdate table
        public void showAllMenuItems(DataGridView dgv)
        {
            showAll(menuQuery, dgv);
        }

        // get all data from Reservations table
        public void showAllReservations(DataGridView dgv)
        {
            showAll(reservationQuery, dgv);
        }
    }
}
