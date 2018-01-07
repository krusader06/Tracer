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
        List<Classes.DatabaseTables.EngineeringDashboard> engineeringDashboard = new List<Classes.DatabaseTables.EngineeringDashboard>();

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


        private void colorCells()
        {
            for (int x = 5; x < dgActiveWORs.Rows[0].Cells.Count; x++)
            {
                for (int y = 0; y < engineeringDashboard.Count(); y++)
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

                        case "Not Used":
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
            dgActiveWORs.Refresh();
        }

        private void formatDataGrid()
        {
            dgActiveWORs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgActiveWORs.Columns["BOMValidationRequest"].Visible = false;
            dgActiveWORs.Columns["BOMValidationInProgress"].Visible = false;
            dgActiveWORs.Columns["BOMValidationComplete"].Visible = false;

            dgActiveWORs.Columns["PreBidRequest"].Visible = false;
            dgActiveWORs.Columns["PreBidInProgress"].Visible = false;
            dgActiveWORs.Columns["PreBidComplete"].Visible = false;

            dgActiveWORs.Columns["QuoteReviewRequest"].Visible = false;
            dgActiveWORs.Columns["QuoteReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["QuoteReviewComplete"].Visible = false;

            dgActiveWORs.Columns["MasterRequest"].Visible = false;
            dgActiveWORs.Columns["MasterInProgress"].Visible = false;
            dgActiveWORs.Columns["MasterComplete"].Visible = false;

            dgActiveWORs.Columns["MasterReviewRequest"].Visible = false;
            dgActiveWORs.Columns["MasterReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["MasterReviewComplete"].Visible = false;

        }

        public void populate(object sender, EventArgs e)
        {

            dgActiveWORs.Enabled = false;
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            engineeringDashboard = db.LoadProcessDashboard();
            dgActiveWORs.DataSource = engineeringDashboard;

            Classes.StatusCalculation calculatedStatus = new Classes.StatusCalculation();

            calculatedStatus.CalculateEngineeringDashboard(engineeringDashboard);

            colorCells();
            formatDataGrid();

            dgActiveWORs.Enabled = true;

            //Re-select current cell
            dgActiveWORs.CurrentCell = dgActiveWORs.Rows[currentSelectionRow].Cells[currentSelectionColumn];
        }

        private void dgActiveWORs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update Selected cell so that it doesn't get reset during refresh
            currentSelectionRow = e.RowIndex;
            currentSelectionColumn = e.ColumnIndex;
        }
    }
}
