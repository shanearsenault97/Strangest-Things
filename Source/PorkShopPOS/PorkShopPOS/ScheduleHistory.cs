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
    public partial class ScheduleHistory : Form
    {
        public ScheduleHistory()
        {
            InitializeComponent();
        }
        
        /* User: Bryan MacFarlane
      * Date: 2017-02-05
      * Time: 12:30 AM
      * Purpose: load schedule report
      */

        private void ScheduleHistory_Load(object sender, EventArgs e)
        {
            try
            {

               // DateTime toDate = BackOffice.historyToDate;
              //  DateTime fromDate = BackOffice.historyFromDate;

                TimeClock timeC = new TimeClock();

               timeC.FromDate = BackOffice.historyFromDate;
                timeC.ToDate = BackOffice.historyToDate;

                // fromtoL.text = timeC.FromDate + " " + timeC.ToDate;

                DataGridView dgv = schHistoryDGV;
                timeC.SearchDateHistory( timeC.FromDate, timeC.ToDate, dgv);
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

        private void schHistoryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

        

    