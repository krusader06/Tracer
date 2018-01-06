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
    public partial class ucAddEditQuote : UserControl
    {
        List<Classes.DatabaseTables.ActiveQuotes> quotes = new List<Classes.DatabaseTables.ActiveQuotes>();

        //Hold info
        string tempDate, tempTime;

        //On Load Stuff--------------------------------------------------------------
        private static ucAddEditQuote _instance;
        public static ucAddEditQuote Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucAddEditQuote();
                return _instance;
            }
        }

        public ucAddEditQuote()
        {
            InitializeComponent();
            btnClear_Click(null, null);
        }

        //Functions----------------------------------------------------------------------
        private void clearFields()
        {
            txtWOR.Text = "";
            txtPartID.Text = "";
            txtCustomer.Text = "";
            txtDescription.Text = "";
            txtComment.Text = "";

            radioMedConf.Checked = true;
            ckShowAll.Checked = false;

            dtDueDate.Format = DateTimePickerFormat.Custom;
            dtDueDate.CustomFormat = "MM-dd-yyyy";
        }
        
        private void UpdateBinding()
        {
            dgQuoteGrid.DataSource = quotes;
        }

        private void showAllQuotes()
        {
            dgQuoteGrid.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            quotes = db.GetAllQuotes();
            UpdateBinding();
            dgQuoteGrid.Columns["QuoteInactive"].Visible = true;
            dgQuoteGrid.Columns["POReceived"].Visible = true;

            dgQuoteGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgQuoteGrid.Columns["PartDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void showActiveQuotes()
        {
            dgQuoteGrid.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            quotes = db.GetActiveQuotes();
            UpdateBinding();
            dgQuoteGrid.Columns["QuoteInactive"].Visible = false;
            dgQuoteGrid.Columns["POReceived"].Visible = false;

            dgQuoteGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgQuoteGrid.Columns["PartDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Physical Button Events--------------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();

            //Holder to validate the Data


            //Create new class to hold the new Active Quote
            Classes.DatabaseTables.ActiveQuotes newActiveQuote = new Classes.DatabaseTables.ActiveQuotes();
            Classes.DatabaseTables.QuoteStatus newQuoteStatus = new Classes.DatabaseTables.QuoteStatus();

            //Fill New Active Quote
            newActiveQuote.QuoteWOR = Int32.Parse(txtWOR.Text);

            DateTime rightNow = new DateTime();
            rightNow = DateTime.Now;
            newActiveQuote.Date = rightNow.ToString("MM-dd-yyyy");
            newActiveQuote.Time = rightNow.ToString("hh:mm:ss tt");

            newActiveQuote.PartID = txtPartID.Text;
            newActiveQuote.Customer = txtCustomer.Text;
            newActiveQuote.PartDescription = txtDescription.Text;

            if (radioLowConf.Checked)
            {
                newActiveQuote.QuoteConfidence = "Low";
            }
            if (radioMedConf.Checked)
            {
                newActiveQuote.QuoteConfidence = "Medium";
            }
            if (radioHighConf.Checked)
            {
                newActiveQuote.QuoteConfidence = "High";
            }

            newActiveQuote.QuoteComments = txtComment.Text;

            newActiveQuote.QuoteDueDate = dtDueDate.Text;

            //Set Initial Status
            newActiveQuote.QuoteInactive = 0;
            newActiveQuote.POReceived = 0;

            //QuoteStatus Initialization
            newQuoteStatus.QuoteWOR = Int32.Parse(txtWOR.Text);
            newQuoteStatus.BOMValidationRequest = 0;
            newQuoteStatus.BOMValidationInProgress = 0;
            newQuoteStatus.BOMValidationComplete = 0;
            newQuoteStatus.PartsReviewRequest = 0;
            newQuoteStatus.PartsReviewInProgress = 0;
            newQuoteStatus.PartsReviewComplete = 0;
            newQuoteStatus.PreBidRequest = 0;
            newQuoteStatus.PreBidInProgress = 0;
            newQuoteStatus.PreBidComplete = 0;
            newQuoteStatus.FinalReviewRequest = 0;
            newQuoteStatus.FinalReviewInProgress = 0;
            newQuoteStatus.FinalReviewComplete = 0;
            newQuoteStatus.QuoteCurrentStatus = "";

            db.InsertNewQuote(newActiveQuote, newQuoteStatus);
            btnClear_Click(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            showActiveQuotes();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void ckShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowAll.Checked)
            {
                showAllQuotes();
            } else
            {
                showActiveQuotes();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Database Connection
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();

            //To hold all the information
            Classes.DatabaseTables.ActiveQuotes updateQuote = new Classes.DatabaseTables.ActiveQuotes();

            //Fill updateQuote
            updateQuote.QuoteWOR = Int32.Parse(txtWOR.Text);

            updateQuote.Date = tempDate;
            updateQuote.Time = tempTime;

            updateQuote.PartID = txtPartID.Text;
            updateQuote.Customer = txtCustomer.Text;
            updateQuote.PartDescription = txtDescription.Text;

            if (radioLowConf.Checked)
            {
                updateQuote.QuoteConfidence = "Low";
            }
            if (radioMedConf.Checked)
            {
                updateQuote.QuoteConfidence = "Medium";
            }
            if (radioHighConf.Checked)
            {
                updateQuote.QuoteConfidence = "High";
            }

            updateQuote.QuoteComments = txtComment.Text;

            updateQuote.QuoteDueDate = dtDueDate.Text;

            db.UpdateQuote(updateQuote);
            btnClear_Click(null, null);
        }

        private void dgQuoteGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //Update All of the Text Boxes
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgQuoteGrid.Rows[e.RowIndex];

                txtWOR.Text = selectedRow.Cells[0].Value.ToString();
                tempDate = selectedRow.Cells[1].Value.ToString();
                tempTime = selectedRow.Cells[2].Value.ToString();
                txtPartID.Text = selectedRow.Cells[3].Value.ToString();
                txtCustomer.Text = selectedRow.Cells[4].Value.ToString();
                txtDescription.Text = selectedRow.Cells[5].Value.ToString();

                switch (selectedRow.Cells[6].Value.ToString())
                {
                    case "Low":
                        radioLowConf.Checked = true;
                        break;
                    case "Medium":
                        radioMedConf.Checked = true;
                        break;
                    case "High":
                        radioHighConf.Checked = true;
                        break;
                }

                txtComment.Text = selectedRow.Cells[7].Value.ToString();
                dtDueDate.Value = Convert.ToDateTime(selectedRow.Cells[8].Value.ToString());

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }





    }
}
