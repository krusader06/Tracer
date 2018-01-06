using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Sales
{
    public partial class ucPurchasingRequest : UserControl
    {

        //Holders for Selected Rows
        int quoteRow;

        //Quote Holder
        List<Classes.DatabaseTables.ActiveQuotes> activeQuotes = new List<Classes.DatabaseTables.ActiveQuotes>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucPurchasingRequest _instance;
        public static ucPurchasingRequest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPurchasingRequest();
                return _instance;
            }
        }

        public ucPurchasingRequest()
        {
            InitializeComponent();
            ShowActiveQuotes();
        }

        public void ShowActiveQuotes()
        {   //Takes Care of Loading the DataGridView with all Active Quotes

            dgActiveQuotes.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            activeQuotes = db.GetActiveQuotes();

            dgActiveQuotes.DataSource = activeQuotes;
            dgActiveQuotes.Columns["QuoteInactive"].Visible = false;
            dgActiveQuotes.Columns["POReceived"].Visible = false;

        }

        //Physical Events-----------------------------------------------------------------------------------------------

        private void btnRequestPartsReview_Click(object sender, EventArgs e)
        {
            string message = "Would you like to request a Parts Review for Job Number " + dgActiveQuotes.Rows[quoteRow].Cells[0].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();

                //Set PartsReviewRequest to True, PartsReviewInProgress and PartsReviewComplete to False
                db.requestPartsReview(dgActiveQuotes.Rows[quoteRow].Cells[0].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveQuotes.Rows[quoteRow].Cells[0].Value.ToString());
                tempLotTask.Lot = 0;

                //Update Quote Current Status
                Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
                getStatus.CalculateStatus(tempLotTask);

                //Refresh
                ShowActiveQuotes();

            }
        }

        private void dgActiveQuotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedLotRow = dgActiveQuotes.Rows[e.RowIndex];

                quoteRow = e.RowIndex;

                btnRequestPartsReview.Enabled = true;

            }
        }
    }
}
