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
    public partial class ucSalesDashboard : UserControl
    {

        List<Classes.DatabaseTables.ActiveQuotes> quotes = new List<Classes.DatabaseTables.ActiveQuotes>();

        //Load Stuff------------------------------------------------------------------------------
        private static ucSalesDashboard _instance;
        public static ucSalesDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSalesDashboard();
                return _instance;
            }
        }

        public ucSalesDashboard()
        {
            InitializeComponent();
            setTimer();
            refreshData(null, null);
        }

        //Timer Stuff------------------------------------------------------------------------------

        private void setTimer()
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000);
            timer.Tick += new EventHandler(refreshData);
            timer.Start();
        }

        public void refreshData(object sender, EventArgs e)
        {
            //Refresh the dataGridView
            updateData(sender, e);
        }

        //Functions----------------------------------------------------------------------------------

        private void UpdateBinding()
        {
            dgActiveQuotes.DataSource = quotes;
            dgActiveQuotes.Columns["QuoteInactive"].Visible = false;
            dgActiveQuotes.Columns["POReceived"].Visible = false;
        }

        private void updateData(object sender, EventArgs e)
        {
            dgActiveQuotes.DataSource = null;
            Classes.DataAccess.SalesDataAccess db = new Classes.DataAccess.SalesDataAccess();
            quotes = db.GetActiveQuotes();
            UpdateBinding();
        }
    }
}
