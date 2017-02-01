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

        private void btnPOS_Click(object sender, EventArgs e) {
            ThePorkShopPOS POS = new ThePorkShopPOS();
            POS.Show();
        }

        private void btnBackOffice_Click(object sender, EventArgs e) {
            BackOffice BO = new BackOffice();
            BO.Show();
        }
    }
}
