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
            for (int x = 5; x <= 14; x++)
            {
                for (int y = 0; y < engineeringDashboard.Count(); y++)
                {
                    if ((dgActiveWORs.Rows[y].Cells[0].Value.ToString() == "Quote") && (x > 6))
                    {
                        dgActiveWORs.Rows[y].Cells[x].Value = "";
                        dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.Gray;
                    }

                    if (dgActiveWORs.Rows[y].Cells[x].Value.ToString() == "True")
                    {
                        dgActiveWORs.Rows[y].Cells[x].Value = "";
                        dgActiveWORs.Rows[y].Cells[x].Style.BackColor = Color.LightGreen;
                    } else
                    {
                        dgActiveWORs.Rows[y].Cells[x].Value = "";
                    }
                }
            }
            dgActiveWORs.Refresh();
        }

        public void populate(object sender, EventArgs e)
        {
            dgActiveWORs.Enabled = false;
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            engineeringDashboard = db.LoadProcessDashboard();
            dgActiveWORs.DataSource = engineeringDashboard;

            colorCells();

            dgActiveWORs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgActiveWORs.Enabled = true;
        }



    }
}
