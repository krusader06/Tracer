using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Purchasing
{
    public partial class ucPurchasingDashboard : UserControl
    {

        private static ucPurchasingDashboard _instance;
        List<Classes.DatabaseTables.Dashboard> purchasingDashboard = new List<Classes.DatabaseTables.Dashboard>();
        List<Classes.LotTask> TaskRequests = new List<Classes.LotTask>();

        //Holder for selection location
        int currentSelectionRow = 0;
        int currentSelectionColumn = 0;
        //Used for Task View
        int activeRow;

        public static ucPurchasingDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPurchasingDashboard();
                return _instance;
            }
        }

        public ucPurchasingDashboard()
        {
            InitializeComponent();
            setTimer();
            populate(null, null);
        }

        private void setTimer()
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(populate);
            timer.Start();
        }

        public void populate(object sender, EventArgs e)
        {

            dgActiveWORs.Enabled = false;
            Classes.DataAccess.DashboardDataAccess db = new Classes.DataAccess.DashboardDataAccess();
            purchasingDashboard = db.LoadDashboard();
            dgActiveWORs.DataSource = purchasingDashboard;

            Classes.StatusCalculation calculatedStatus = new Classes.StatusCalculation();

            calculatedStatus.CalculateDashboard(purchasingDashboard);

            colorCells();
            formatDataGrid();

            dgActiveWORs.Enabled = true;

            //Re-select current cell
            dgActiveWORs.CurrentCell = dgActiveWORs.Rows[currentSelectionRow].Cells[currentSelectionColumn];

            //Task View Stuff
            dgTaskView.DataSource = null;

            Classes.DataAccess.PurchasingDataAccess dbPur = new Classes.DataAccess.PurchasingDataAccess();
            TaskRequests = dbPur.GetPurchasingTaskList();

            dgTaskView.DataSource = TaskRequests;
            dgTaskView.Columns["Owner"].Visible = false;

            dgTaskView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgTaskView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void colorCells()
        {
            for (int x = 0; x < dgActiveWORs.Rows[0].Cells.Count; x++)
            {
                for (int y = 0; y < purchasingDashboard.Count(); y++)
                {
                    if (dgActiveWORs.Rows[y].Cells[x].Value != null)
                    {
                        switch (dgActiveWORs.Rows[y].Cells[x].Value.ToString())
                        {
                            case "True":
                                dgActiveWORs.Rows[y].Cells[x].Value = "";
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                            case "False":
                                dgActiveWORs.Rows[y].Cells[x].Value = "";
                                break;

                            case "!Not Used!":
                                dgActiveWORs.Rows[y].Cells[x].Value = "";
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.Gray;
                                break;


                            case "Not Started":
                                dgActiveWORs.Rows[y].Cells[x].Value = "";
                                break;

                            case "Requested":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightSteelBlue;
                                break;

                            case "In Progress":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                                break;

                            case "Complete":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                            //Stencils

                            case "Stencils Needed":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightSteelBlue;
                                break;

                            case "Stencils Received":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                            case "Stencils on Order":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                                break;

                            //PCBs

                            case "PCBs Needed":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightSteelBlue;
                                break;

                            case "PCBs Received":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                            case "PCBs on Order":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                                break;

                            //Parts

                            case "Parts Needed":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightSteelBlue;
                                break;

                            case "Parts Received":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                            case "Parts on Order":
                                dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                                break;

                        }
                    }
                }
            }
            dgActiveWORs.Refresh();
        }

        private void formatDataGrid()
        {
            //Hides any cells that we don't care about. Eventually this will be in a configuration file...

            //WOR Grid...

            dgActiveWORs.Columns[0].HeaderText = "Quote/WOR";

            dgActiveWORs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //dgActiveWORs.Columns["QuoteOrWOR"].Visible = false;
            //dgActiveWORs.Columns["WOR"].Visible = false;
            //dgActiveWORs.Columns["Lot"].Visible = false;
            //dgActiveWORs.Columns["PartID"].Visible = false;
            //dgActiveWORs.Columns["Customer"].Visible = false;
            dgActiveWORs.Columns["PartDescription"].Visible = false;
            dgActiveWORs.Columns["QuoteConfidence"].Visible = false;
            dgActiveWORs.Columns["OrderQuantity"].Visible = false;
            dgActiveWORs.Columns["TurnTime"].Visible = false;
            //dgActiveWORs.Columns["Consigned"].Visible = false;
            //dgActiveWORs.Columns["Turnkey"].Visible = false;

            dgActiveWORs.Columns["BOMValidationRequest"].Visible = false;
            dgActiveWORs.Columns["BOMValidationInProgress"].Visible = false;
            dgActiveWORs.Columns["BOMValidationComplete"].Visible = false;
            dgActiveWORs.Columns["BOMValidationStatus"].Visible = false;

            dgActiveWORs.Columns["PartsReviewRequest"].Visible = false;
            dgActiveWORs.Columns["PartsReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["PartsReviewComplete"].Visible = false;
            //dgActiveWORs.Columns["PartsReviewStatus"].Visible = false;

            dgActiveWORs.Columns["PreBidRequest"].Visible = false;
            dgActiveWORs.Columns["PreBidInProgress"].Visible = false;
            dgActiveWORs.Columns["PreBidComplete"].Visible = false;
            dgActiveWORs.Columns["PreBidStatus"].Visible = false;

            dgActiveWORs.Columns["FinalReviewRequest"].Visible = false;
            dgActiveWORs.Columns["FinalReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["FinalReviewComplete"].Visible = false;
            dgActiveWORs.Columns["FinalReviewStatus"].Visible = false;

            dgActiveWORs.Columns["QuoteDueDate"].Visible = false;
            dgActiveWORs.Columns["QuoteSent"].Visible = false;

            dgActiveWORs.Columns["QuoteReviewRequest"].Visible = false;
            dgActiveWORs.Columns["QuoteReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["QuoteReviewComplete"].Visible = false;
            dgActiveWORs.Columns["QuoteReviewStatus"].Visible = false;

            dgActiveWORs.Columns["MasterRequest"].Visible = false;
            dgActiveWORs.Columns["MasterInProgress"].Visible = false;
            dgActiveWORs.Columns["MasterComplete"].Visible = false;
            dgActiveWORs.Columns["MasterStatus"].Visible = false;
            dgActiveWORs.Columns["MasterDueDate"].Visible = false;

            dgActiveWORs.Columns["MasterReviewRequest"].Visible = false;
            dgActiveWORs.Columns["MasterReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["MasterReviewComplete"].Visible = false;
            dgActiveWORs.Columns["MasterReviewStatus"].Visible = false;

            //dgActiveWORs.Columns["WORLotReleased"].Visible = false;

            dgActiveWORs.Columns["TravelerReleased"].Visible = false;
            dgActiveWORs.Columns["TravelerReturned"].Visible = false;
            dgActiveWORs.Columns["TravelerStatus"].Visible = false;

            //dgActiveWORs.Columns["KitReleased"].Visible = false;
            //dgActiveWORs.Columns["KitDueDate"].Visible = false;

            //dgActiveWORs.Columns["JobDueDate"].Visible = false;

            dgActiveWORs.Columns["SuperHot"].Visible = false;

            dgActiveWORs.Columns["PCBRequired"].Visible = false;
            dgActiveWORs.Columns["PCBOrdered"].Visible = false;
            dgActiveWORs.Columns["PCBReceived"].Visible = false;
            //dgActiveWORs.Columns["PCBStatus"].Visible = false;
            //dgActiveWORs.Columns["PCBArraysApproved"].Visible = false;

            dgActiveWORs.Columns["StencilsRequired"].Visible = false;
            dgActiveWORs.Columns["StencilsOrdered"].Visible = false;
            dgActiveWORs.Columns["StencilsReceived"].Visible = false;
            //dgActiveWORs.Columns["StencilStatus"].Visible = false;
            //dgActiveWORs.Columns["StencilPlotsApproved"].Visible = false;

            dgActiveWORs.Columns["PartsRequired"].Visible = false;
            dgActiveWORs.Columns["PartsOrdered"].Visible = false;
            dgActiveWORs.Columns["PartsReceived"].Visible = false;
            //dgActiveWORs.Columns["PartsStatus"].Visible = false;


        }

        private void dgActiveWORs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update Selected cell so that it doesn't get reset during refresh
            currentSelectionRow = e.RowIndex;
            currentSelectionColumn = e.ColumnIndex;
        }

        //Task View Handlers----------------------------------------------------------------------------------------------

        private void dgTaskView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Store Row Details
                activeRow = e.RowIndex;

                switch (dgTaskView[3, e.RowIndex].Value.ToString())
                {
                    case "Parts Review Requested":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Start Parts Review for Quote: " + dgTaskView[0, activeRow].Value.ToString();
                        break;

                    case "Parts Review In Progress":
                        btnStart.Enabled = false;
                        btnStart.Visible = false;
                        btnEnd.Enabled = true;
                        btnEnd.Visible = true;

                        btnEnd.Text = "Parts Review is Complete for Quote: " + dgTaskView[0, activeRow].Value.ToString();
                        break;

                    case "Order Parts":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Order Parts for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Order PCBs":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Order PCBs for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Order Stencils":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Order Stencils for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Grab an Instance of PurchasingDataAccess
            Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();
            //Prepare currentTask
            Classes.LotTask currentTask = new Classes.LotTask();
            currentTask.JobWOR = Int32.Parse(dgTaskView[0, activeRow].Value.ToString());
            currentTask.Lot = Int32.Parse(dgTaskView[1, activeRow].Value.ToString());

            switch (dgTaskView[3, activeRow].Value.ToString())
            {
                case "Parts Review Requested":
                    //Change the PartsReviewInProgress Flag to True
                    db.UpdatePartsReviewInProgress(currentTask);

                    break;
                case "Order Parts":
                    //Change the PartsOrdered Flag to True and Time-Stamp LotTimeTracking.PartsOrderedDate
                    db.UpdatePartsOrdered(currentTask);

                    break;
                case "Order PCBs":
                    //Change the PCBOrdered Flag to True and Time-Stamp LotTimeTracking.PCBOrderDate
                    db.UpdatePCBOrdered(currentTask);

                    break;
                case "Order Stencils":
                    //Change the StencilsOrdered Flag to True and Time-Stamp LotTimeTracking.StencilOrderDate
                    db.UpdateStencilsOrdered(currentTask);

                    break;
            }

            //Re-Calculate the JobStatus
            Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
            getStatus.CalculateStatus(currentTask);

            //Update the GridView
            populate(null, null);

            //Reset Buttons
            btnStart.Enabled = false;
            btnStart.Visible = true;
            btnStart.Text = "Start";
            btnEnd.Enabled = false;
            btnEnd.Visible = false;
            btnEnd.Text = "End";
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //Grab an Instance of SalesDataAccess
            Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();

            //Prepare currentTask
            Classes.LotTask currentTask = new Classes.LotTask();
            currentTask.JobWOR = Int32.Parse(dgTaskView[0, activeRow].Value.ToString());
            currentTask.Lot = Int32.Parse(dgTaskView[1, activeRow].Value.ToString());

            switch (dgTaskView[3, activeRow].Value.ToString())
            {
                case "Parts Review In Progress":
                    //Set PartsReviewComplete=True, PartsReviewRequest=False, PartsReviewInProgress=False; Eventually, Time-Tracking will happen here too...
                    db.UpdatePartsReviewComplete(currentTask);

                    break;
            }

            //Re-Calculate the JobStatus
            Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
            getStatus.CalculateStatus(currentTask);

            //Update the GridView
            populate(null, null);

            //Reset Buttons
            btnStart.Enabled = false;
            btnStart.Visible = true;
            btnStart.Text = "Start";
            btnEnd.Enabled = false;
            btnEnd.Visible = false;
            btnEnd.Text = "End";
        }
    }
}
