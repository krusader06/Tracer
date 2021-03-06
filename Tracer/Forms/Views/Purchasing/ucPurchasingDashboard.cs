﻿using System;
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

        //Refresh Timer
        private static Timer timer = new Timer();

        //Used to store current cell for active WOR datagrid
        int WORactiveRow;
        int WORactiveColumn;
        //Task DGV current cell holders
        int TaskActiveRow;
        int TaskActiveColumn;

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
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(populate);
            timer.Start();
        }

        public void populate(object sender, EventArgs e)
        {

            dgActiveWORs.Enabled = false;

            //Get Current Selection Location
            if (dgActiveWORs.CurrentCell != null)
            {
                if (dgActiveWORs.CurrentCell.ColumnIndex > 0)
                {
                    WORactiveRow = dgActiveWORs.CurrentCell.RowIndex;
                    WORactiveColumn = dgActiveWORs.CurrentCell.ColumnIndex;
                }
            }

            //Load DataGridView
            Classes.DataAccess.DashboardDataAccess db = new Classes.DataAccess.DashboardDataAccess();
            purchasingDashboard = db.LoadDashboard(ckQuotes.Checked, ckWORs.Checked);
            dgActiveWORs.DataSource = purchasingDashboard;

            Classes.StatusCalculation calculatedStatus = new Classes.StatusCalculation();
            calculatedStatus.CalculateDashboard(purchasingDashboard);

            //Format DataGridView
            formatDataGrid();

            //Re-set Current Cell
            try
            {
                dgActiveWORs.CurrentCell = dgActiveWORs.Rows[WORactiveRow].Cells[WORactiveColumn];
            }
            catch { }

            dgActiveWORs.Enabled = true;


            //Task View Stuff
            dgTaskView.Enabled = false;

            //Get Current Selection Location
            if (dgTaskView.CurrentCell != null)
            {
                if (dgTaskView.CurrentCell.ColumnIndex > 0)
                {
                    TaskActiveRow = dgTaskView.CurrentCell.RowIndex;
                    TaskActiveColumn = dgTaskView.CurrentCell.ColumnIndex;
                }
            }

            Classes.DataAccess.PurchasingDataAccess dbPur = new Classes.DataAccess.PurchasingDataAccess();
            TaskRequests = dbPur.GetPurchasingTaskList();
            dgTaskView.DataSource = TaskRequests;

            //Format Task View Data Grid
            dgTaskView.Columns["Owner"].Visible = false;
            dgTaskView.Columns["SuperHot"].Visible = false;

            //Re-Select Current Cell
            try
            {
                dgTaskView.CurrentCell = dgTaskView.Rows[TaskActiveRow].Cells[TaskActiveColumn];
            }
            catch { }

            dgTaskView.Enabled = true;

            dgTaskView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgTaskView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgTaskView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTaskView.Rows[e.RowIndex].Cells[dgTaskView.Columns["SuperHot"].Index].Value.ToString() == "1")
            {
                //Highlight the row if it is SuperHot
                dgTaskView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightPink;
                dgTaskView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;

            }
            else
            {
                dgTaskView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
                dgTaskView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
            }
        }

        private void dgActiveWORs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                switch (e.Value.ToString())
                {
                    case "True":
                        e.Value = "";
                        e.CellStyle.BackColor = Color.LimeGreen;
                        break;

                    case "False":
                        e.Value = "";
                        break;

                    case "!Not Used!":
                        e.Value = "";
                        e.CellStyle.BackColor = Color.Gray;
                        break;


                    case "Not Started":
                        e.Value = "";
                        break;

                    case "Requested":
                        e.CellStyle.BackColor = Color.LightSteelBlue;
                        break;

                    case "In Progress":
                        e.CellStyle.BackColor = Color.Yellow;
                        break;

                    case "Complete":
                        e.CellStyle.BackColor = Color.LimeGreen;
                        break;

                    //Stencils

                    case "Stencils Needed":
                        e.CellStyle.BackColor = Color.LightSteelBlue;
                        break;

                    case "Stencils Received":
                        e.CellStyle.BackColor = Color.LimeGreen;
                        break;

                    case "Stencils on Order":
                        e.CellStyle.BackColor = Color.Yellow;
                        break;

                    //PCBs

                    case "PCBs Needed":
                        e.CellStyle.BackColor = Color.LightSteelBlue;
                        break;

                    case "PCBs Received":
                        e.CellStyle.BackColor = Color.LimeGreen;
                        break;

                    case "PCBs on Order":
                        e.CellStyle.BackColor = Color.Yellow;
                        break;

                    //Parts

                    case "Parts Needed":
                        e.CellStyle.BackColor = Color.LightSteelBlue;
                        break;

                    case "Parts Received":
                        e.CellStyle.BackColor = Color.LimeGreen;
                        break;

                    case "Parts on Order":
                        e.CellStyle.BackColor = Color.Yellow;
                        break;

                }
            }

            //SuperHot Color Formatting------------------------------------------------------------------------------------------

            if (dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["SuperHot"].Index].Value.ToString() == "True")
            {
                dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["QuoteOrWOR"].Index].Style.BackColor = Color.Crimson;
                dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["QuoteOrWOR"].Index].Style.ForeColor = Color.WhiteSmoke;
            }

            //Date Color Formatting----------------------------------------------------------------------------------------------

            DateTime dt = new DateTime();
            double tempDays;

            if ((e.ColumnIndex == dgActiveWORs.Columns["QuoteDueDate"].Index) && (e.Value.ToString() != ""))
            {
                //Grab and convert the cell value to a date
                dt = Convert.ToDateTime(e.Value.ToString());
                tempDays = (dt - DateTime.Now).TotalDays;

                //find out if Quote has been sent
                if ((dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["QuoteSent"].Index].Value != null) && (dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["QuoteSent"].Index].Value.ToString() == "True"))
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                    //evaluate time remaining
                    if (tempDays <= 1)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        if (tempDays < 4)
                        {
                            e.CellStyle.ForeColor = Color.Brown;
                            e.CellStyle.BackColor = Color.Gold;
                        }
                        else
                        {
                            if (tempDays >= 4)
                            {
                                e.CellStyle.ForeColor = Color.DarkGreen;
                                e.CellStyle.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }

            if ((e.ColumnIndex == dgActiveWORs.Columns["MasterDueDate"].Index) && (e.Value.ToString() != ""))
            {
                //Grab and convert the cell value to a date
                dt = Convert.ToDateTime(e.Value.ToString());
                tempDays = (dt - DateTime.Now).TotalDays;

                //find out if master is complete
                if ((dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["MasterStatus"].Index].Value != null) && (dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["MasterStatus"].Index].Value.ToString() == "Complete"))
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                    //evaluate time remaining
                    if (tempDays <= 1)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        if (tempDays < 4)
                        {
                            e.CellStyle.ForeColor = Color.Brown;
                            e.CellStyle.BackColor = Color.Gold;
                        }
                        else
                        {
                            if (tempDays >= 4)
                            {
                                e.CellStyle.ForeColor = Color.DarkGreen;
                                e.CellStyle.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }

            if ((e.ColumnIndex == dgActiveWORs.Columns["KitDueDate"].Index) && (e.Value.ToString() != ""))
            {
                //Grab and convert the cell value to a date
                dt = Convert.ToDateTime(e.Value.ToString());
                tempDays = (dt - DateTime.Now).TotalDays;

                //find out if Kit has been released
                if ((dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["KitReleased"].Index].Value != null) && (dgActiveWORs.Rows[e.RowIndex].Cells[dgActiveWORs.Columns["KitReleased"].Index].Value.ToString() == "True"))
                {
                    e.CellStyle.ForeColor = Color.Black;
                }
                else
                {
                    //evaluate time remaining
                    if (tempDays <= 1)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        if (tempDays < 4)
                        {
                            e.CellStyle.ForeColor = Color.Brown;
                            e.CellStyle.BackColor = Color.Gold;
                        }
                        else
                        {
                            if (tempDays >= 4)
                            {
                                e.CellStyle.ForeColor = Color.DarkGreen;
                                e.CellStyle.BackColor = Color.LightGreen;
                            }
                        }
                    }
                }
            }

            if ((e.ColumnIndex == dgActiveWORs.Columns["JobDueDate"].Index) && (e.Value.ToString() != ""))
            {
                //Grab and convert the cell value to a date
                dt = Convert.ToDateTime(e.Value.ToString());
                tempDays = (dt - DateTime.Now).TotalDays;

                //evaluate time remaining
                if (tempDays <= 1)
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    if (tempDays < 4)
                    {
                        e.CellStyle.ForeColor = Color.Brown;
                        e.CellStyle.BackColor = Color.Gold;
                    }
                    else
                    {
                        if (tempDays >= 4)
                        {
                            e.CellStyle.ForeColor = Color.DarkGreen;
                            e.CellStyle.BackColor = Color.LightGreen;
                        }
                    }
                }
            }
        }

        private void formatDataGrid()
        {
            //Format Grid-View-------------------------------------------------------------------------------

            dgActiveWORs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveWORs.Columns["Comments"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Set all minimum column widths
            for (int i = 0; i < 65; i++)
            {
                dgActiveWORs.Columns[i].MinimumWidth = 75;
            }

            dgActiveWORs.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgActiveWORs.EnableHeadersVisualStyles = false;

            //Read-Only except for Comments Column
            dgActiveWORs.ReadOnly = false;
            for (int i = 0; i < dgActiveWORs.ColumnCount - 1; i++)
            {
                dgActiveWORs.Columns[i].ReadOnly = true;
            }

            dgActiveWORs.Columns["Comments"].ReadOnly = false;

            //Re-Name Columns--------------------------------------------------------------------------------

            dgActiveWORs.Columns["QuoteOrWOR"].HeaderText = "Quote/WOR";
            dgActiveWORs.Columns["PartID"].HeaderText = "Part ID";
            dgActiveWORs.Columns["PartDescription"].HeaderText = "Description";
            dgActiveWORs.Columns["QuoteConfidence"].HeaderText = "Confidence";
            dgActiveWORs.Columns["OrderQuantity"].HeaderText = "Quantity";
            dgActiveWORs.Columns["TurnTime"].HeaderText = "Turn Time";
            dgActiveWORs.Columns["Consigned"].HeaderText = "C";
            dgActiveWORs.Columns["Turnkey"].HeaderText = "T";

            dgActiveWORs.Columns["BOMValidationStatus"].HeaderText = "BOM Validation";
            dgActiveWORs.Columns["PartsReviewStatus"].HeaderText = "Parts Review";
            dgActiveWORs.Columns["PreBidStatus"].HeaderText = "Pre-Bid";
            dgActiveWORs.Columns["FinalReviewStatus"].HeaderText = "Final Review";

            dgActiveWORs.Columns["QuoteDueDate"].HeaderText = "Quote Due";
            dgActiveWORs.Columns["QuoteSent"].HeaderText = "Quote Sent";
            dgActiveWORs.Columns["QuoteReviewStatus"].HeaderText = "Quote Review";

            dgActiveWORs.Columns["MasterStatus"].HeaderText = "Master";
            dgActiveWORs.Columns["MasterDueDate"].HeaderText = "Master Due";
            dgActiveWORs.Columns["MasterReviewStatus"].HeaderText = "Master Review";

            dgActiveWORs.Columns["WORLotReleased"].HeaderText = "WOR Released";

            dgActiveWORs.Columns["TravelerStatus"].HeaderText = "Traveler";

            dgActiveWORs.Columns["KitReleased"].HeaderText = "Kit";
            dgActiveWORs.Columns["KitDueDate"].HeaderText = "Kit Due";

            dgActiveWORs.Columns["JobDueDate"].HeaderText = "Job Due";

            dgActiveWORs.Columns["PCBStatus"].HeaderText = "PCBs";
            dgActiveWORs.Columns["PCBArraysApproved"].HeaderText = "PCBs Approved";

            dgActiveWORs.Columns["StencilStatus"].HeaderText = "Stencils";
            dgActiveWORs.Columns["StencilPlotsApproved"].HeaderText = "Stencils Approved";

            dgActiveWORs.Columns["PartsStatus"].HeaderText = "Parts";


            //Show/Hide Columns---------------------------------------------------------

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

        private void dgActiveWORs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 64)
            {
                timer.Stop();
            }
        }

        private void dgActiveWORs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string tempComment = "";
            string tempType = ""; //Quote or WOR
            string tempWOR = "";
            string tempLot = "";

            Classes.DataAccess.DashboardDataAccess db = new Classes.DataAccess.DashboardDataAccess();

            //Store Comment
            tempComment = dgActiveWORs.Rows[e.RowIndex].Cells["Comments"].Value.ToString();
            tempType = dgActiveWORs.Rows[e.RowIndex].Cells["QuoteOrWOR"].Value.ToString();
            tempWOR = dgActiveWORs.Rows[e.RowIndex].Cells["WOR"].Value.ToString();
            tempLot = dgActiveWORs.Rows[e.RowIndex].Cells["Lot"].Value.ToString();

            db.UpdateComments(tempComment, tempType, tempWOR, tempLot);

            //Start Timer
            timer.Start();
        }

        private void ckWORs_CheckedChanged(object sender, EventArgs e)
        {
            populate(null, null);
        }

        private void ckQuotes_CheckedChanged(object sender, EventArgs e)
        {
            populate(null, null);
        }
    }
}
