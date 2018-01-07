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
    public partial class ucEditLot : UserControl
    {
        //Used to import from the database
        List<Classes.DatabaseTables.WorkOrders> WorkOrders = new List<Classes.DatabaseTables.WorkOrders>();
        List<Classes.DatabaseTables.LotNumbers> lotNumbers = new List<Classes.DatabaseTables.LotNumbers>();

        //Holders for a new Lot
        Classes.DatabaseTables.LotNumbers newLotNumber = new Classes.DatabaseTables.LotNumbers();
        Classes.DatabaseTables.LotStatus newLotStatus = new Classes.DatabaseTables.LotStatus();
        Classes.DatabaseTables.LotPurchasingStatus newLotPurchasingStatus = new Classes.DatabaseTables.LotPurchasingStatus();
        Classes.DatabaseTables.LotTimeTracking newLotTimeTracking = new Classes.DatabaseTables.LotTimeTracking();
        Classes.DatabaseTables.PurchasingTimeTracking newPurchasingTimeTracking = new Classes.DatabaseTables.PurchasingTimeTracking();

        //Holders for Selected Rows
        int lotRow, WORRow;

        //On Load Stuff--------------------------------------------------------------
        private static ucEditLot _instance;
        public static ucEditLot Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucEditLot();
                return _instance;
            }
        }

        public ucEditLot()
        {
            InitializeComponent();
            btnClear_Click(null, null);
            LoadActiveWorkOrders();
        }

        //Functions----------------------------------------------------------------------
        private void clearFields()
        {
            txtLotNumber.Text = "";
            txtOrderQuantity.Text = "";
            txtTurnTime.Text = "";
            txtJobComments.Text = "";

            ckConsigned.Checked = false;
            ckTurnkey.Checked = true;
            ckShowAll.Checked = false;

            dtJobDueDate.Format = DateTimePickerFormat.Custom;
            dtJobDueDate.CustomFormat = "MM-dd-yyyy";
            dtMasterDueDate.Format = DateTimePickerFormat.Custom;
            dtMasterDueDate.CustomFormat = "MM-dd-yyyy";
        }

        private void LoadActiveWorkOrders()
        {
            dgWORGrid.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            WorkOrders = db.GetActiveWorkOrders();
            dgWORGrid.DataSource = WorkOrders;

            dgWORGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgWORGrid.Columns["Date"].Visible = false;
            dgWORGrid.Columns["Time"].Visible = false;
            dgWORGrid.Columns["PurchaseOrderNumber"].Visible = false;
            dgWORGrid.Columns["WorkOrderComplete"].Visible = false;

        }

        private void LoadAllWorkOrders()
        {
            dgWORGrid.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            WorkOrders = db.GetAllWorkOrders();
            dgWORGrid.DataSource = WorkOrders;

            dgWORGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgWORGrid.Columns["Date"].Visible = false;
            dgWORGrid.Columns["Time"].Visible = false;
            dgWORGrid.Columns["PurchaseOrderNumber"].Visible = false;
            dgWORGrid.Columns["WorkOrderComplete"].Visible = false;
        }


        //Physical Button Events--------------------------------------------------------------

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
            LoadActiveWorkOrders();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Database Connection
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            //To hold all the information
            Classes.DatabaseTables.LotNumbers updateLot = new Classes.DatabaseTables.LotNumbers();

            //Fill in new Lot information
            updateLot.LotID = lotNumbers[lotRow].LotID;
            updateLot.Lot = Int32.Parse(txtLotNumber.Text);
            updateLot.OrderQuantity = Int32.Parse(txtOrderQuantity.Text);
            updateLot.JobDueDate = dtJobDueDate.Text;
            updateLot.MasterDueDate = dtMasterDueDate.Text;
            updateLot.TurnTime = Int32.Parse(txtTurnTime.Text);

            if (ckTurnkey.Checked == true)
            {
                if (ckConsigned.Checked == true)
                {
                    //Both Checked
                    updateLot.Consigned = "Turnkey/Consigned";
                }
                else
                {
                    //Only Turnkey Checked
                    updateLot.Consigned = "Turnkey";
                }
            }
            else
            {
                //Only Consigned Checked
                updateLot.Consigned = "Consigned";
            }

            updateLot.JobComments = txtJobComments.Text;

            //Update Lot Number
            db.UpdateLot(updateLot);
            refreshLotView();
            btnClear_Click(null, null);
        }

        private void ckShowAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowAll.Checked)
            {
                LoadAllWorkOrders();
            }
            else
            {
                LoadActiveWorkOrders();
            }
        }

        private void refreshLotView()
        {
            //Refresh Lot Number Grid
            dgLotGrid.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();

            lotNumbers = db.GetCurrentLotNumbers(dgWORGrid.Rows[WORRow].Cells["JobWOR"].Value.ToString());
            dgLotGrid.DataSource = lotNumbers;
            dgLotGrid.Columns["JobWOR"].Visible = false;
            dgLotGrid.Columns["LotID"].Visible = false;

            dgLotGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgLotGrid.Columns["JobComments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgWORGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                WORRow = e.RowIndex;
                refreshLotView();
            }
        }

        private void dgLotGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedLotRow = dgLotGrid.Rows[e.RowIndex];

                lotRow = e.RowIndex;

                //Load All of the Text Boxes
                txtLotNumber.Text = selectedLotRow.Cells["Lot"].Value.ToString();
                txtOrderQuantity.Text = selectedLotRow.Cells["OrderQuantity"].Value.ToString();
                txtTurnTime.Text = selectedLotRow.Cells["TurnTime"].Value.ToString();
                txtJobComments.Text = selectedLotRow.Cells["JobComments"].Value.ToString();

                dtJobDueDate.Value = Convert.ToDateTime(selectedLotRow.Cells["JobDueDate"].Value.ToString());
                dtMasterDueDate.Value = Convert.ToDateTime(selectedLotRow.Cells["MasterDueDate"].Value.ToString());

                switch (selectedLotRow.Cells["Consigned"].Value.ToString())
                {
                    case "Turnkey/Consigned":
                        ckConsigned.Checked = true;
                        ckTurnkey.Checked = true;
                        break;
                    case "Turnkey":
                        ckConsigned.Checked = false;
                        ckTurnkey.Checked = true;
                        break;
                    case "Consigned":
                        ckConsigned.Checked = true;
                        ckTurnkey.Checked = false;
                        break;
                }

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;

            }
        }





        private void LoadLotNumber()
        {
            //Add all fields to dgNewLots
            newLotNumber.JobWOR = WorkOrders[WORRow].JobWOR;

            newLotNumber.Lot = Int32.Parse(txtLotNumber.Text);

            newLotNumber.Customer = lotNumbers[lotRow].Customer;
            newLotNumber.PartID = lotNumbers[lotRow].PartID;
            newLotNumber.PartDescription = lotNumbers[lotRow].PartDescription;

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
            newLotPurchasingStatus.StencilsRequired = 0;
            newLotPurchasingStatus.StencilsOrdered = 0;
            newLotPurchasingStatus.StencilsReceived = 0;
            newLotPurchasingStatus.StencilPlotsApproved = 0;
            newLotPurchasingStatus.PCBRequired = 0;
            newLotPurchasingStatus.PCBOrdered = 0;
            newLotPurchasingStatus.PCBReceived = 0;
            newLotPurchasingStatus.PCBArraysApproved = 0;
            newLotPurchasingStatus.PartsRequired = 0;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
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
            refreshLotView();
            //Clear The Form
            btnClear_Click(null, null);
        }
    }
}
