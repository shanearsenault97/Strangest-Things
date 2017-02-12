using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace PorkShopPOS {
    public partial class BillReport : Form {
        public ReportDocument reportDocument;
        public BillReport() {
            InitializeComponent();
        }

        private void BillReport_Load(object sender, EventArgs e) {
            reportDocument1 = reportDocument;
            crystalReportViewer1.ReportSource = reportDocument1;
            crystalReportViewer1.Refresh();
        }
    }
}
