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
    public partial class ucPerformPurchasingTask : UserControl
    {

        //Holders for Selected Rows
        int quoteRow;

        //Quote Holder
        List<Classes.DatabaseTables.LotNumbers> activeLotNumbers = new List<Classes.DatabaseTables.LotNumbers>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucPerformPurchasingTask _instance;
        public static ucPerformPurchasingTask Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPerformPurchasingTask();
                return _instance;
            }
        }

        public ucPerformPurchasingTask()
        {
            InitializeComponent();
            ShowLotNumbers();
        }

        public void ShowLotNumbers()
        {   //Takes Care of Loading the DataGridView with all Active Quotes

            dgActiveWOR.DataSource = null;
            Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();
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

        private void btnPartsReceived_Click(object sender, EventArgs e)
        {
            string message = "Did you receive the parts for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();

                //Set PartsReceived = True
                db.PartsReceived(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

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

        private void btnStencilsReceived_Click(object sender, EventArgs e)
        {
            string message = "Did you receive the stencil(s) for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();

                //Set PartsReceived = True
                db.StencilsReceived(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

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

        private void btnPCBsReceived_Click(object sender, EventArgs e)
        {
            string message = "Did you receive the PCBs for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();

                //Set PartsReceived = True
                db.PCBsReceived(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

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

        private void btnReleaseKit_Click(object sender, EventArgs e)
        {
            string message = "Release the Kit to production floor for Job Number: " + dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString() + "/" + dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString() + "?";
            string caption = "Are you sure?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Create a new db connection
                Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();

                //Set PartsReceived = True
                db.ReleaseKit(dgActiveWOR.Rows[quoteRow].Cells[1].Value.ToString(), dgActiveWOR.Rows[quoteRow].Cells[2].Value.ToString());

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

                btnPartsReceived.Enabled = true;
                btnStencilsReceived.Enabled = true;
                btnPCBsReceived.Enabled = true;
                btnReleaseKit.Enabled = true;

            }
        }


    }
}
