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
        List<Classes.DatabaseTables.PurchasingDashboard> purchasingDashboard = new List<Classes.DatabaseTables.PurchasingDashboard>();

        //Holder for selection location
        int currentSelectionRow = 0;
        int currentSelectionColumn = 0;

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
            Classes.DataAccess.PurchasingDataAccess db = new Classes.DataAccess.PurchasingDataAccess();
            purchasingDashboard = db.LoadPurchasingDashboard();
            dgActiveWORs.DataSource = purchasingDashboard;

            Classes.StatusCalculation calculatedStatus = new Classes.StatusCalculation();

            calculatedStatus.CalculatePurchasingDashboard(purchasingDashboard);

            colorCells();
            formatDataGrid();

            dgActiveWORs.Enabled = true;

            //Re-select current cell
            dgActiveWORs.CurrentCell = dgActiveWORs.Rows[currentSelectionRow].Cells[currentSelectionColumn];
        }

        private void colorCells()
        {
            for (int x = 5; x < dgActiveWORs.Rows[0].Cells.Count; x++)
            {
                for (int y = 0; y < purchasingDashboard.Count(); y++)
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
            dgActiveWORs.Refresh();
        }

        private void formatDataGrid()
        {
            dgActiveWORs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dgActiveWORs.Columns["PartsReviewRequest"].Visible = false;
            dgActiveWORs.Columns["PartsReviewInProgress"].Visible = false;
            dgActiveWORs.Columns["PartsReviewComplete"].Visible = false;

            dgActiveWORs.Columns["StencilsRequired"].Visible = false;
            dgActiveWORs.Columns["StencilsOrdered"].Visible = false;
            dgActiveWORs.Columns["StencilsReceived"].Visible = false;

            dgActiveWORs.Columns["PCBRequired"].Visible = false;
            dgActiveWORs.Columns["PCBOrdered"].Visible = false;
            dgActiveWORs.Columns["PCBReceived"].Visible = false;

            dgActiveWORs.Columns["PartsRequired"].Visible = false;
            dgActiveWORs.Columns["PartsOrdered"].Visible = false;
            dgActiveWORs.Columns["PartsReceived"].Visible = false;

        }

        private void dgActiveWORs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update Selected cell so that it doesn't get reset during refresh
            currentSelectionRow = e.RowIndex;
            currentSelectionColumn = e.ColumnIndex;
        }
    }
}
