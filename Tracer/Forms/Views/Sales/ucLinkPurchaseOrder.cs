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
    public partial class ucLinkPurchaseOrder : UserControl
    {
        public string SelectedWorkOrder;

        //Event Handlers--------------------------------------------------------------
        public event EventHandler POButtonClicked;

        //To Hold Active Quotes
        List<Classes.DatabaseTables.ActiveQuotes> quotes = new List<Classes.DatabaseTables.ActiveQuotes>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucLinkPurchaseOrder _instance;
        public static ucLinkPurchaseOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucLinkPurchaseOrder();
                return _instance;
            }
        }

        public ucLinkPurchaseOrder()
        {
            InitializeComponent();
            updateData(null, null);
        }

        //Functions----------------------------------------------------------------------------------

        public void updateData(object sender, EventArgs e)
        {
            dgActiveQuotes.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            quotes = db.GetActiveQuotes();
            dgActiveQuotes.DataSource = quotes;
            dgActiveQuotes.Columns["QuoteInactive"].Visible = false;
            dgActiveQuotes.Columns["POReceived"].Visible = false;

            dgActiveQuotes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveQuotes.Columns["QuoteComments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void createWOR()
        {
            //Set Up holder to update the Active Quote PO Status
            Classes.DatabaseTables.ActiveQuotes activeQuote = new Classes.DatabaseTables.ActiveQuotes();

            //Set Up Holder for the new WOR
            Classes.DatabaseTables.WorkOrders newWOR = new Classes.DatabaseTables.WorkOrders();

            DateTime rightNow = new DateTime();
            rightNow = DateTime.Now;

            newWOR.JobWOR = Int32.Parse(SelectedWorkOrder);
            newWOR.Date = rightNow.ToString("MM-dd-yyyy");
            newWOR.Time = rightNow.ToString("hh:mm:ss tt");
            newWOR.PurchaseOrderNumber = txtPONumber.Text;
            newWOR.WorkOrderComplete = 0;

            //Create Data Access Class
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            db.InsterWorkOrder(newWOR);
        }

        private void onPOButtonClick()
        {
            if (POButtonClicked != null)
            {
                POButtonClicked(this, EventArgs.Empty);
            }
        }

        //Physical Button Listeners----------------------------------------------------------------------------------

        private void dgActiveQuotes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgActiveQuotes.Rows[e.RowIndex];

                lblSelectedQuote.Text = selectedRow.Cells[0].Value.ToString();
                SelectedWorkOrder = lblSelectedQuote.Text;

            }

            if(lblSelectedQuote.Text != "None")
            {
                if (txtPONumber.Text != "")
                {
                    btnAddPO.Enabled = true;
                }
                else
                {
                    btnAddPO.Enabled = false;
                }
            }
        }

        private void txtPONumber_TextChanged(object sender, EventArgs e)
        {
            if(txtPONumber.Text != "")
            {
                if (lblSelectedQuote.Text != "None")
                {
                    btnAddPO.Enabled = true;
                }
                else
                {
                    btnAddPO.Enabled = false;
                }
                    
            }
        }

        private void btnAddPO_Click(object sender, EventArgs e)
        {
            //Add New WOR to WorkOrder Table
            createWOR();
            //Start Button Event Click
            onPOButtonClick();
        }
    }
}
