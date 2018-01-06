using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Engineering
{
    public partial class ucSalesRequest : UserControl
    {

        //Holders for Selected Rows
        int quoteRow;

        //Quote Holder
        List<Classes.DatabaseTables.LotNumbers> activeLotNumbers = new List<Classes.DatabaseTables.LotNumbers>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucSalesRequest _instance;
        public static ucSalesRequest Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSalesRequest();
                return _instance;
            }
        }
        public ucSalesRequest()
        {
            InitializeComponent();
            ShowLotNumbers();
        }

        public void ShowLotNumbers()
        {   //Takes Care of Loading the DataGridView with all Active Quotes

            dgActiveQuotes.DataSource = null;
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            activeLotNumbers = db.GetLotNumbers();

            dgActiveQuotes.DataSource = activeLotNumbers;

            dgActiveQuotes.Columns["LotID"].Visible = false;
            dgActiveQuotes.Columns["OrderQuantity"].Visible = false;
            dgActiveQuotes.Columns["PartDescription"].Visible = false;
            dgActiveQuotes.Columns["JobDueDate"].Visible = false;
            dgActiveQuotes.Columns["MasterDueDate"].Visible = false;
            dgActiveQuotes.Columns["TurnTime"].Visible = false;
            dgActiveQuotes.Columns["Consigned"].Visible = false;
            dgActiveQuotes.Columns["JobComments"].Visible = false;

            dgActiveQuotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveQuotes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        //Physical Events-----------------------------------------------------------------------------------------------

        private void btnRequestMasterReview_Click(object sender, EventArgs e)
        {
            string message = "Would you like to request a Master Review for Job Number " + dgActiveQuotes.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveQuotes.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

                //Set MasterReviewRequest to True, MasterReviewInProgress and MasterReviewComplete to False
                db.requestMasterReview(dgActiveQuotes.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveQuotes.Rows[quoteRow].Cells[2].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveQuotes.Rows[quoteRow].Cells[1].Value.ToString());
                tempLotTask.Lot = Int32.Parse(dgActiveQuotes.Rows[quoteRow].Cells[2].Value.ToString());

                //Update Quote Current Status
                Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
                getStatus.CalculateStatus(tempLotTask);

                //Refresh
                ShowLotNumbers();

            }
        }

        private void dgActiveQuotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedLotRow = dgActiveQuotes.Rows[e.RowIndex];

                quoteRow = e.RowIndex;

                btnRequestMasterReview.Enabled = true;

            }
        }
    }
}
