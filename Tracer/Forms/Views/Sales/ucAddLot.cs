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
    public partial class ucAddLot : UserControl
    {
        //Public Variables
        public string QuoteWorkOrder;

        //Holder for the List of Lot Numbers
        List<Classes.DatabaseTables.LotNumbers> newLots = new List<Classes.DatabaseTables.LotNumbers>();
        List<Classes.DatabaseTables.LotNumbers> currentLots = new List<Classes.DatabaseTables.LotNumbers>();

        //Quote Holder
        List<Classes.DatabaseTables.ActiveQuotes> activeQuotes = new List<Classes.DatabaseTables.ActiveQuotes>();

        //Holders for a new Lot
        Classes.DatabaseTables.LotNumbers newLotNumber = new Classes.DatabaseTables.LotNumbers();
        Classes.DatabaseTables.LotStatus newLotStatus = new Classes.DatabaseTables.LotStatus();
        Classes.DatabaseTables.LotPurchasingStatus newLotPurchasingStatus = new Classes.DatabaseTables.LotPurchasingStatus();
        Classes.DatabaseTables.LotTimeTracking newLotTimeTracking = new Classes.DatabaseTables.LotTimeTracking();
        Classes.DatabaseTables.PurchasingTimeTracking newPurchasingTimeTracking = new Classes.DatabaseTables.PurchasingTimeTracking();

        //Load Stuff------------------------------------------------------------------------------
        private static ucAddLot _instance;
        public static ucAddLot Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucAddLot();
                return _instance;
            }
        }

        public ucAddLot()
        {
            InitializeComponent();

            //Get Selected Work Order Number
            lblWorkOrder.Text = ucLinkPurchaseOrder.Instance.SelectedWorkOrder;
            InitializeFields();
            ShowCurrentLotNumbers();
        }

        private void ShowCurrentLotNumbers()
        {   //Takes Care of Loading the DataGridView with any lot numbers that are registered under the work order

            dgNewLots.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            currentLots = db.GetCurrentLotNumbers(lblWorkOrder.Text);

            dgNewLots.DataSource = currentLots;
        }



        private void InitializeFields()
        {
            dtJobDueDate.Format = DateTimePickerFormat.Custom;
            dtJobDueDate.CustomFormat = "MM-dd-yyyy";
            dtMasterDueDate.Format = DateTimePickerFormat.Custom;
            dtMasterDueDate.CustomFormat = "MM-dd-yyyy";
        }

        private void LoadActiveQuote()
        {
            //New Connection
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            activeQuotes = db.GetSingleQuote(lblWorkOrder.Text);

        }

        private void LoadLotNumber()
        {
            //Add all fields to dgNewLots
            newLotNumber.JobWOR = Int32.Parse(lblWorkOrder.Text);
            newLotNumber.Lot = Int32.Parse(txtLotNumber.Text);
            newLotNumber.Customer = activeQuotes[0].Customer;
            newLotNumber.PartID = activeQuotes[0].PartID;
            newLotNumber.PartDescription = activeQuotes[0].PartDescription;
            newLotNumber.OrderQuantity = Int32.Parse(txtOrderQuantity.Text);
            newLotNumber.JobDueDate = dtJobDueDate.Text;
            newLotNumber.MasterDueDate = dtMasterDueDate.Text;
            newLotNumber.TurnTime = Int32.Parse(txtTurnTime.Text);

            if (ckTurnkey.Checked == true)
            {
                if (ckConsigned.Checked == true)
                {
                    //Both Checked
                    newLotNumber.Consigned = "Turnkey/Consigned";
                }
                else
                {
                    //Only Turnkey Checked
                    newLotNumber.Consigned = "Turnkey";
                }
            }
            else
            {
                //Only Consigned Checked
                newLotNumber.Consigned = "Consigned";
            }

            newLotNumber.JobComments = txtJobComments.Text;
        }

        private void LoadLotStatus()
        {
            //Load Default values, and request that Engineering does a quote review and makes a master
            newLotStatus.QuoteReviewRequest = 1;
            newLotStatus.QuoteReviewInProgress = 0;
            newLotStatus.QuoteReviewComplete = 0;
            newLotStatus.MasterRequest = 1;
            newLotStatus.MasterInProgress = 0;
            newLotStatus.MasterComplete = 0;
            newLotStatus.MasterReviewRequest = 0;
            newLotStatus.MasterReviewInProgress = 0;
            newLotStatus.MasterReviewComplete = 0;
            newLotStatus.WORLotReleased = 0;
            newLotStatus.TravelerReleased = 0;
            newLotStatus.TravelerReturned = 0;
            newLotStatus.JobInProgress = 0;
            newLotStatus.JobComplete = 0;
            newLotStatus.SuperHot = 0;
            newLotStatus.JobStatus = "";
        }

        private void LoadLotPurchasingStatus()
        {
            newLotPurchasingStatus.NumStencilsRequired = 0;
            newLotPurchasingStatus.NumStencilsOrdered = 0;
            newLotPurchasingStatus.NumStencilsReceived = 0;
            newLotPurchasingStatus.StencilPlotsApproved = 0;
            newLotPurchasingStatus.NumPCBRequired = 0;
            newLotPurchasingStatus.NumPCBOrdered = 0;
            newLotPurchasingStatus.NumPCBReceived = 0;
            newLotPurchasingStatus.PCBArraysApproved = 0;
            newLotPurchasingStatus.PartsOrdered = 0;
            newLotPurchasingStatus.PartsReceived = 0;
            newLotPurchasingStatus.KitReleased = 0;
        }

        private void LoadPurchasingTimeTracking()
        {
            newPurchasingTimeTracking.StencilOrderDate = "";
            newPurchasingTimeTracking.StencilPlotsApprovedDate = "";
            newPurchasingTimeTracking.StencilReceivedDate = "";
            newPurchasingTimeTracking.PCBOrderDate = "";
            newPurchasingTimeTracking.PCBArraysApprovedDate = "";
            newPurchasingTimeTracking.PCBReceivedDate = "";
            newPurchasingTimeTracking.PartsOrderDate = "";
            newPurchasingTimeTracking.PartsReceivedDate = "";
        }

        private void LoadLotTimeTracking()
        {
            newLotTimeTracking.QuoteReviewStart = "";
            newLotTimeTracking.QuoteReviewEnd = "";
            newLotTimeTracking.MasterStart = "";
            newLotTimeTracking.MasterEnd = "";
            newLotTimeTracking.MasterReviewStart = "";
            newLotTimeTracking.MasterReviewEnd = "";
            newLotTimeTracking.WORReleaseStart = "";
            newLotTimeTracking.WORReleaseEnd = "";
            newLotTimeTracking.TravelerStart = "";
            newLotTimeTracking.TravelerEnd = "";
            newLotTimeTracking.JobStart = "";
            newLotTimeTracking.JobEnd = "";

        }

        private void AddLotNumber()
        {
            //make a new access connection
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            //Create the Lot
            db.InsertLotNumber(newLotNumber, newLotStatus, newLotPurchasingStatus, newLotTimeTracking, newPurchasingTimeTracking);

        }

        //Physical Events-----------------------------------------------------------------------------------------------

        private void btnAddLot_Click(object sender, EventArgs e)
        {
            //Load Active Quote Info so that we can pull PartID/Customer/PartDescription
            LoadActiveQuote();
            //Load Lot Number
            LoadLotNumber();
            //Load Default Values for each Status Table
            LoadLotStatus();
            LoadLotPurchasingStatus();
            //Load Default Values for each Time Tracking Table
            LoadLotTimeTracking();
            LoadPurchasingTimeTracking();
            //Perform SQL Calls to create everything
            AddLotNumber();
            //Bring in the New Lot Number
            ShowCurrentLotNumbers();
        }

        
    }
}
