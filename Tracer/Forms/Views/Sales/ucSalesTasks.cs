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
    public partial class ucSalesTasks : UserControl
    {

        List<Classes.LotTask> MasterReviewRequests = new List<Classes.LotTask>();

        //Used to store datagridview selected row
        int activeRow;

        //On Load Stuff--------------------------------------------------------------
        private static ucSalesTasks _instance;
        public static ucSalesTasks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSalesTasks();
                return _instance;
            }
        }

        public ucSalesTasks()
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

        private void updateData(object sender, EventArgs e)
        {
            dgTaskView.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            MasterReviewRequests = db.GetMasterReviewRequests();
            //Fill In the Task Name for each list item
            for (int i = 0; i < MasterReviewRequests.Count; i++)
            {
                MasterReviewRequests[i].TaskDescription = "Perform Master Review";
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
                    case "Master Review Requested":
                        btnStart.Enabled = true;
                        btnStart.Visible = true;
                        btnEnd.Enabled = false;
                        btnEnd.Visible = false;

                        btnStart.Text = "Start Master Review for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
                        break;

                    case "Master Review In Progress":
                        btnStart.Enabled = false;
                        btnStart.Visible = false;
                        btnEnd.Enabled = true;
                        btnEnd.Visible = true;

                        btnEnd.Text = "Master Review is Complete for WOR: " + dgTaskView[0, activeRow].Value.ToString() + "/" + dgTaskView[1, activeRow].Value.ToString();
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
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            //Prepare currentTask
            Classes.LotTask currentTask = new Classes.LotTask();
            currentTask.JobWOR = Int32.Parse(dgTaskView[0, activeRow].Value.ToString());
            currentTask.Lot = Int32.Parse(dgTaskView[1, activeRow].Value.ToString());

            //Change the MasterReviewInProgress Flag to True and Time-Stamp LotTimeTracking.MasterReviewStart
            db.UpdateReviewMasterInProgress(currentTask);

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
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();

            //Prepare currentTask
            Classes.LotTask currentTask = new Classes.LotTask();
            currentTask.JobWOR = Int32.Parse(dgTaskView[0, activeRow].Value.ToString());
            currentTask.Lot = Int32.Parse(dgTaskView[1, activeRow].Value.ToString());

            //Update LotStatus and Time-stamp LotTimeTracking.MasterReviewEnd
            db.UpdateReviewMasterComplete(currentTask);

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
