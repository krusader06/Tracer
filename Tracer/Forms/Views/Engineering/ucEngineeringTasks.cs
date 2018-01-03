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
    public partial class ucEngineeringTasks : UserControl
    {

        List<Classes.LotTask> MasterReviewRequests = new List<Classes.LotTask>();

        //Used to store datagridview selected row
        int activeRow;

        //On Load Stuff--------------------------------------------------------------
        private static ucEngineeringTasks _instance;
        public static ucEngineeringTasks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucEngineeringTasks();
                return _instance;
            }
        }

        public ucEngineeringTasks()
        {
            InitializeComponent();
            setTimer();
            updateData(null, null);
        }

        //Timer Stuff------------------------------------------------------------------------------

        private void setTimer()
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(updateData);
            timer.Start();
        }

        //Functions----------------------------------------------------------------------------------
        //Engineering Task List will show 4 items for now: BOM Validation Request, Quote Review Request, Master Creation Request, Pre-Bid Review Request
        private void updateData(object sender, EventArgs e)
        {
            dgTaskView.DataSource = null;
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            MasterReviewRequests = db.GetEngineeringTaskList();
            //Fill In the Task Name for each list item
            for (int i = 0; i < MasterReviewRequests.Count; i++)
            {
                switch (MasterReviewRequests[i].JobStatus)
                {
                    case "BOM Validation Requested":
                        MasterReviewRequests[i].TaskDescription = "Perform BOM Validation";

                        break;
                    case "Master Creation Requested":
                        MasterReviewRequests[i].TaskDescription = "Perform Master Creation";

                        break;
                    case "Quote Review Requested":
                        MasterReviewRequests[i].TaskDescription = "Perform Quote Review";
                        break;
                    case "Pre-Bid Review Requested":
                        MasterReviewRequests[i].TaskDescription = "Perform Pre-Bid Review";
                        break;
                }
            }

            dgTaskView.DataSource = MasterReviewRequests;
            dgTaskView.Columns["Owner"].Visible = false;

            dgTaskView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgTaskView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgTaskView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //Store Row Details
                activeRow = e.RowIndex;

                switch (dgTaskView[3, e.RowIndex].Value.ToString())
                {
                    case "BOM Validation Requested":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Start BOM Validation for Quote: " + dgTaskView[0, activeRow].Value.ToString();
                        break;

                    case "BOM Validation In Progress":
                        btnStart.Enabled = false;
                        btnStart.Visible = false;
                        btnEnd.Enabled = true;
                        btnEnd.Visible = true;

                        btnEnd.Text = "BOM Validation is Complete for Quote: " + dgTaskView[0, activeRow].Value.ToString();
                        break;

                    case "Master Creation Requested":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Start Master Creation for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Master Creation In Progress":
                        btnStart.Enabled = false;
                        btnStart.Visible = false;
                        btnEnd.Enabled = true;
                        btnEnd.Visible = true;

                        btnEnd.Text = "Master Creation is Complete for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Quote Review Requested":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Start Quote Review for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Quote Review In Progress":
                        btnStart.Enabled = false;
                        btnStart.Visible = false;
                        btnEnd.Enabled = true;
                        btnEnd.Visible = true;

                        btnEnd.Text = "Quote Review is Complete for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Pre-Bid Review Requested":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Start Pre-Bid Review for Quote: " + dgTaskView[0, activeRow].Value.ToString();
                        break;

                    case "Pre-Bid Review In Progress":
                        btnStart.Enabled = false;
                        btnStart.Visible = false;
                        btnEnd.Enabled = true;
                        btnEnd.Visible = true;

                        btnEnd.Text = "Pre-Bid Review is Complete for Quote: " + dgTaskView[0, activeRow].Value.ToString();
                        break;

                    default:
                        btnStart.Enabled = false;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;
                        break;
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Grab an Instance of SalesDataAccess
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            //Prepare currentTask
            Classes.LotTask currentTask = new Classes.LotTask();
            currentTask.JobWOR = Int32.Parse(dgTaskView[0, activeRow].Value.ToString());
            currentTask.Lot = Int32.Parse(dgTaskView[1, activeRow].Value.ToString());

            switch (dgTaskView[3, activeRow].Value.ToString())
            {
                case "BOM Validation Requested":
                    //Change the BOMValidationInProgress Flag to True
                    db.UpdateBOMValidationInProgress(currentTask);

                    break;
                case "Master Creation Requested":
                    //Change the MasterInProgress Flag to True and Time-Stamp LotTimeTracking.MasterStart
                    db.UpdateMasterInProgress(currentTask);

                    break;
                case "Quote Review Requested":
                    //Change the QuoteReviewInProgress Flag to True and Time-Stamp LotTimeTracking.QuoteReviewStart
                    db.UpdateQuoteReviewInProgress(currentTask);

                    break;
                case "Pre-Bid Review Requested":
                    //Change the PreBidInProgress Flag to True
                    db.UpdatePreBidInProgress(currentTask);

                    break;
            }

            //Re-Calculate the JobStatus
            Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
            getStatus.CalculateStatus(currentTask);

            //Update the GridView
            updateData(null, null);

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
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

            //Prepare currentTask
            Classes.LotTask currentTask = new Classes.LotTask();
            currentTask.JobWOR = Int32.Parse(dgTaskView[0, activeRow].Value.ToString());
            currentTask.Lot = Int32.Parse(dgTaskView[1, activeRow].Value.ToString());

            switch (dgTaskView[3, activeRow].Value.ToString())
            {
                case "BOM Validation In Progress":
                    //Set BOMValidationComplete=True, BOMValidationRequest=False, BOMValidationInProgress=False; Eventually, Time-Tracking will happen here too...
                    db.UpdateBOMValidationComplete(currentTask);

                    break;
                case "Master Creation In Progress":
                    //Change the MasterInProgress Flag to True and Time-Stamp LotTimeTracking.MasterEnd
                    db.UpdateMasterComplete(currentTask);

                    break;
                case "Quote Review In Progress":
                    //Update QuoteReviewComplete Flag to True and Time-stamp LotTimeTracking.QuoteReviewEnd
                    db.UpdateQuoteReviewComplete(currentTask);

                    break;
                case "Pre-Bid Review In Progress":
                    //Update PreBidComplete Flag to True
                    db.UpdatePreBidComplete(currentTask);

                    break;
            }

            //Re-Calculate the JobStatus
            Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
            getStatus.CalculateStatus(currentTask);

            //Update the GridView
            updateData(null, null);

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
