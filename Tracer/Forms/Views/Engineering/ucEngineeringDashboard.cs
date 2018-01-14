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
    public partial class ucProcessDashboard : UserControl
    {
        private static ucProcessDashboard _instance;
        List<Classes.DatabaseTables.Dashboard> engineeringDashboard = new List<Classes.DatabaseTables.Dashboard>();

        //Holder for selection location
        int currentSelectionRow = 0;
        int currentSelectionColumn = 0;

        public static ucProcessDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucProcessDashboard();
                return _instance;
            }
        }

        public ucProcessDashboard()
        {
            InitializeComponent();
            //setTimer();
            populate(null, null);
        }

        private void setTimer()
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(populate);
            timer.Start();
        }


        private void colorCells()
        {
            for (int x = 0; x < dgActiveWORs.Rows[0].Cells.Count; x++)
            {
                for (int y = 0; y < engineeringDashboard.Count(); y++)
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

                        }
                    }
                   
                }
            }
            dgActiveWORs.Refresh();

            for (int x = 0; x < dgActiveWORStatus.Rows[0].Cells.Count; x++)
            {
                for (int y = 0; y < engineeringDashboard.Count(); y++)
                {
                    if (dgActiveWORStatus.Rows[y].Cells[x].Value != null)
                    {
                        switch (dgActiveWORStatus.Rows[y].Cells[x].Value.ToString())
                        {
                            case "True":
                                dgActiveWORStatus.Rows[y].Cells[x].Value = "";
                                dgActiveWORStatus.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                            case "False":
                                dgActiveWORStatus.Rows[y].Cells[x].Value = "";
                                break;

                            case "!Not Used!":
                                dgActiveWORStatus.Rows[y].Cells[x].Value = "";
                                dgActiveWORStatus.Rows[y].Cells[x].Style.BackColor = Color.Gray;
                                break;

                            case "Not Started":
                                dgActiveWORStatus.Rows[y].Cells[x].Value = "";
                                break;

                            case "Requested":
                                dgActiveWORStatus.Rows[y].Cells[x].Style.BackColor = Color.LightSteelBlue;
                                break;

                            case "In Progress":
                                dgActiveWORStatus.Rows[y].Cells[x].Style.BackColor = Color.Yellow;
                                break;

                            case "Complete":
                                dgActiveWORStatus.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                                break;

                        }
                    }

                }
            }
            dgActiveWORStatus.Refresh();
        }

        private void formatDataGrids()
        {

            //Hides any cells that we don't care about. Eventually this will be in a configuration file...

            //WOR Grid...

            dgActiveWORs.Columns[0].HeaderText = "Quote/WOR";

            dgActiveWORs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgActiveWORs.Columns["BOMValidationRequest"].Visible = false;
            dgActiveWORs.Columns["BOMValidationInProgress"].Visible = false;
            dgActiveWORs.Columns["BOMValidationComplete"].Visible = false;
            dgActiveWORs.Columns["BOMValidationStatus"].Visible = false;

            dgActiveWORs.Columns["PartsReviewRequest"].Visible = false;
            dgActiveWORs.Columns["PartsReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["PartsReviewComplete"].Visible = false;
            dgActiveWORs.Columns["PartsReviewStatus"].Visible = false;

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

            dgActiveWORs.Columns["WORLotReleased"].Visible = false;

            dgActiveWORs.Columns["TravelerReleased"].Visible = false;
            dgActiveWORs.Columns["TravelerReturned"].Visible = false;
            dgActiveWORs.Columns["TravelerStatus"].Visible = false;

            dgActiveWORs.Columns["KitReleased"].Visible = false;
            dgActiveWORs.Columns["KitDueDate"].Visible = false;

            dgActiveWORs.Columns["JobDueDate"].Visible = false;

            dgActiveWORs.Columns["SuperHot"].Visible = false;

            dgActiveWORs.Columns["PCBRequired"].Visible = false;
            dgActiveWORs.Columns["PCBOrdered"].Visible = false;
            dgActiveWORs.Columns["PCBReceived"].Visible = false;
            dgActiveWORs.Columns["PCBStatus"].Visible = false;
            dgActiveWORs.Columns["PCBArraysApproved"].Visible = false;

            dgActiveWORs.Columns["StencilsRequired"].Visible = false;
            dgActiveWORs.Columns["StencilsOrdered"].Visible = false;
            dgActiveWORs.Columns["StencilsReceived"].Visible = false;
            dgActiveWORs.Columns["StencilStatus"].Visible = false;
            dgActiveWORs.Columns["StencilPlotsApproved"].Visible = false;

            dgActiveWORs.Columns["PartsRequired"].Visible = false;
            dgActiveWORs.Columns["PartsOrdered"].Visible = false;
            dgActiveWORs.Columns["PartsReceived"].Visible = false;
            dgActiveWORs.Columns["PartsStatus"].Visible = false;



            //WOR Grid...
            dgActiveWORStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgActiveWORStatus.Columns["QuoteOrWOR"].Visible = false;
            dgActiveWORStatus.Columns["WOR"].Visible = false;
            dgActiveWORStatus.Columns["Lot"].Visible = false;
            dgActiveWORStatus.Columns["PartID"].Visible = false;
            dgActiveWORStatus.Columns["Customer"].Visible = false;
            dgActiveWORStatus.Columns["PartDescription"].Visible = false;
            dgActiveWORStatus.Columns["QuoteConfidence"].Visible = false;
            dgActiveWORStatus.Columns["OrderQuantity"].Visible = false;
            dgActiveWORStatus.Columns["TurnTime"].Visible = false;
            dgActiveWORStatus.Columns["Consigned"].Visible = false;
            dgActiveWORStatus.Columns["Turnkey"].Visible = false;

            dgActiveWORStatus.Columns["BOMValidationRequest"].Visible = false;
            dgActiveWORStatus.Columns["BOMValidationInProgress"].Visible = false;
            dgActiveWORStatus.Columns["BOMValidationComplete"].Visible = false;

            dgActiveWORStatus.Columns["PartsReviewRequest"].Visible = false;
            dgActiveWORStatus.Columns["PartsReviewInProgress"].Visible = false;
            dgActiveWORStatus.Columns["PartsReviewComplete"].Visible = false;
            dgActiveWORStatus.Columns["PartsReviewStatus"].Visible = false;

            dgActiveWORStatus.Columns["PreBidRequest"].Visible = false;
            dgActiveWORStatus.Columns["PreBidInProgress"].Visible = false;
            dgActiveWORStatus.Columns["PreBidComplete"].Visible = false;

            dgActiveWORStatus.Columns["FinalReviewRequest"].Visible = false;
            dgActiveWORStatus.Columns["FinalReviewInProgress"].Visible = false;
            dgActiveWORStatus.Columns["FinalReviewComplete"].Visible = false;
            dgActiveWORStatus.Columns["FinalReviewStatus"].Visible = false;

            dgActiveWORStatus.Columns["QuoteDueDate"].Visible = false;
            dgActiveWORStatus.Columns["QuoteSent"].Visible = false;

            dgActiveWORStatus.Columns["QuoteReviewRequest"].Visible = false;
            dgActiveWORStatus.Columns["QuoteReviewInProgress"].Visible = false;
            dgActiveWORStatus.Columns["QuoteReviewComplete"].Visible = false;

            dgActiveWORStatus.Columns["MasterRequest"].Visible = false;
            dgActiveWORStatus.Columns["MasterInProgress"].Visible = false;
            dgActiveWORStatus.Columns["MasterComplete"].Visible = false;

            dgActiveWORStatus.Columns["MasterReviewRequest"].Visible = false;
            dgActiveWORStatus.Columns["MasterReviewInProgress"].Visible = false;
            dgActiveWORStatus.Columns["MasterReviewComplete"].Visible = false;

            dgActiveWORStatus.Columns["TravelerReleased"].Visible = false;
            dgActiveWORStatus.Columns["TravelerReturned"].Visible = false;

            dgActiveWORStatus.Columns["PCBRequired"].Visible = false;
            dgActiveWORStatus.Columns["PCBOrdered"].Visible = false;
            dgActiveWORStatus.Columns["PCBReceived"].Visible = false;

            dgActiveWORStatus.Columns["StencilsRequired"].Visible = false;
            dgActiveWORStatus.Columns["StencilsOrdered"].Visible = false;
            dgActiveWORStatus.Columns["StencilsReceived"].Visible = false;

            dgActiveWORStatus.Columns["PartsRequired"].Visible = false;
            dgActiveWORStatus.Columns["PartsOrdered"].Visible = false;
            dgActiveWORStatus.Columns["PartsReceived"].Visible = false;
            dgActiveWORStatus.Columns["PartsStatus"].Visible = false;

        }

        public void populate(object sender, EventArgs e)
        {

            dgActiveWORs.Enabled = false;
            dgActiveWORStatus.Enabled = false;

            Classes.DataAccess.DashboardDataAccess db = new Classes.DataAccess.DashboardDataAccess();
            engineeringDashboard = db.LoadDashboard();
            dgActiveWORs.DataSource = engineeringDashboard;
            dgActiveWORStatus.DataSource = engineeringDashboard;

            Classes.StatusCalculation calculatedStatus = new Classes.StatusCalculation();

            calculatedStatus.CalculateDashboard(engineeringDashboard);

            colorCells();
            formatDataGrids();

            dgActiveWORs.Enabled = true;
            dgActiveWORStatus.Enabled = true;

            //Re-select current cell
            dgActiveWORs.CurrentCell = dgActiveWORs.Rows[currentSelectionRow].Cells[currentSelectionColumn];
        }

        private void dgActiveWORs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update Selected cell so that it doesn't get reset during refresh
            if (e.RowIndex > 0)
            {
                currentSelectionRow = e.RowIndex;
                currentSelectionColumn = e.ColumnIndex;
            }
        }
    }
}
