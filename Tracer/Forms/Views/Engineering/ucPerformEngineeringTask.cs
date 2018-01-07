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
    public partial class ucPerformEngineeringTask : UserControl
    {
        //Holders for Selected Rows
        int quoteRow;

        //Quote Holder
        List<Classes.DatabaseTables.LotNumbers> activeLotNumbers = new List<Classes.DatabaseTables.LotNumbers>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucPerformEngineeringTask _instance;
        public static ucPerformEngineeringTask Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPerformEngineeringTask();
                return _instance;
            }
        }

        public ucPerformEngineeringTask()
        {
            InitializeComponent();
            ShowLotNumbers();
        }

        public void ShowLotNumbers()
        {   //Takes Care of Loading the DataGridView with all Active Quotes

            dgActiveWOR.DataSource = null;
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            activeLotNumbers = db.GetLotNumbers();

            dgActiveWOR.DataSource = activeLotNumbers;

            dgActiveWOR.Columns["LotID"].Visible = false;
            dgActiveWOR.Columns["OrderQuantity"].Visible = false;
            dgActiveWOR.Columns["PartDescription"].Visible = false;
            dgActiveWOR.Columns["JobDueDate"].Visible = false;
            dgActiveWOR.Columns["MasterDueDate"].Visible = false;
            dgActiveWOR.Columns["TurnTime"].Visible = false;
            dgActiveWOR.Columns["Consigned"].Visible = false;
            dgActiveWOR.Columns["JobComments"].Visible = false;

            dgActiveWOR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveWOR.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        //Physical Events-----------------------------------------------------------------------------------------------

        private void btnReleaseWOR_Click(object sender, EventArgs e)
        {
            string message = "Are you releasing the Work Order for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

                //Set WORLotReleased = True
                db.releaseWorkOrder(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString());
                tempLotTask.Lot = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Update Quote Current Status
                Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
                getStatus.CalculateStatus(tempLotTask);

                //Refresh
                ShowLotNumbers();

            }
        }

        private void btnReleaseTraveler_Click(object sender, EventArgs e)
        {
            string message = "Are you releasing the traveler for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

                //Set TravelerReleased = True, TravelerReturned = False
                db.releaseTraveler(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString());
                tempLotTask.Lot = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Update Quote Current Status
                Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
                getStatus.CalculateStatus(tempLotTask);

                //Refresh
                ShowLotNumbers();

            }
        }

        private void btnReturnTraveler_Click(object sender, EventArgs e)
        {
            string message = "Has the traveler been returned for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

                //Set TravelerReturned = True
                db.returnTraveler(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString());
                tempLotTask.Lot = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Update Quote Current Status
                Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
                getStatus.CalculateStatus(tempLotTask);

                //Refresh
                ShowLotNumbers();

            }
        }
        private void btnApproveStencilPlots_Click(object sender, EventArgs e)
        {
            string message = "Are you approving the stencil plots for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

                //Set LotPurchasingStatus.StencilPlotsApproved = True
                db.approveStencilPlots(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString());
                tempLotTask.Lot = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Update Quote Current Status
                Classes.StatusCalculation getStatus = new Classes.StatusCalculation();
                getStatus.CalculateStatus(tempLotTask);

                //Refresh
                ShowLotNumbers();

            }
        }

        private void btnApprovePCBArrays_Click(object sender, EventArgs e)
        {
            string message = "Are you approving the PCB arrays for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();

                //Set LotPurchasingStatus.StencilPlotsApproved = True
                db.approvePCBArrays(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

                //Load Temp Lot Task for status calc
                Classes.LotTask tempLotTask = new Classes.LotTask();

                tempLotTask.JobWOR = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString());
                tempLotTask.Lot = Int32.Parse(dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

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
                DataGridViewRow selectedLotRow = dgActiveWOR.Rows[e.RowIndex];

                quoteRow = e.RowIndex;

                btnReleaseWOR.Enabled = true;
                btnCompileTraveler.Enabled = true;
                btnReturnTraveler.Enabled = true;
                btnApproveStencilPlots.Enabled = true;
                btnApprovePCBArrays.Enabled = true;

            }
        }
    }
}
