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
    public partial class ucDeActivateQuote : UserControl
    {
        //Holders for Selected Rows
        int quoteRow;

        //Quote Holder
        List<Classes.DatabaseTables.ActiveQuotes> activeQuotes = new List<Classes.DatabaseTables.ActiveQuotes>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucDeActivateQuote _instance;
        public static ucDeActivateQuote Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucDeActivateQuote();
                return _instance;
            }
        }

        public ucDeActivateQuote()
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

            dgActiveQuotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveQuotes.Columns["QuoteComments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        //Physical Events-----------------------------------------------------------------------------------------------

        private void btnDeActivateQuote_Click(object sender, EventArgs e)
        {
            string message = "Would you like to De-Activate the Quote for Job Number " + dgActiveQuotes.Rows[quoteRow].Cells[0].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();

                //Set QuoteInactive to True
                db.deActivateQuote(dgActiveQuotes.Rows[quoteRow].Cells[0].Value.ToString());

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

                btnDeActivateQuote.Enabled = true;

            }
        }



    }
}
