using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Process
{
    public partial class ucProcessDashboard : UserControl
    {
        private static ucProcessDashboard _instance;
        List<Classes.DatabaseTables.ActiveQuotes> quotes = new List<Classes.DatabaseTables.ActiveQuotes>();

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
            this.populate(null, null);
            UpdateBinding();
        }

        public void populate(object sender, EventArgs e)
        {
            Classes.DataAccess.EngineeringDataAccess db = new Classes.DataAccess.EngineeringDataAccess();
            quotes = db.LoadProcessDashboard();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            dgActiveWORs.DataSource = quotes;
        }
    }
}
