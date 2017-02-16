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
    public partial class UserAccessShowAll : Form
    {
        public UserAccessShowAll()
        {
            InitializeComponent();
        }

        private void UserAccessShowAll_Load(object sender, EventArgs e)
        {
            try
            {
                UserAccess access = new UserAccess();
                DataGridView dgv = userAccessDGV;
                access.showAllUserAccess(dgv);
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
    }
}
