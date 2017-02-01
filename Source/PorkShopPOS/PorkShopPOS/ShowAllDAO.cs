using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
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

        public void showAllEmployees(DataGridView dgv)
        {
            showAll(empQuery, dgv);
        }

        public void showAllSalaries(DataGridView dgv)
        {
            showAll(salQuery, dgv);
        }

        public void showAllPayrolls(DataGridView dgv)
        {
            showAll(payQuery, dgv);
        }
    }
}
