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

    public partial class ucProcessMenu : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public event EventHandler DashboardButtonClicked;
        public event EventHandler TasksButtonClicked;
        public event EventHandler SalesRequestButtonClicked;
        public event EventHandler ReleaseWORButtonClicked;
        public event EventHandler CompileTravelerButtonClicked;
        public event EventHandler TravelerReturnButtonClicked;
        public event EventHandler HomeButtonClicked;
        public event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucProcessMenu _instance;
        public static ucProcessMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucProcessMenu();
                return _instance;
            }
        }
        public ucProcessMenu()
        {
            InitializeComponent();
        }

        //Button Event Handlers--------------------------------------------------------------

        private void onDashboardButtonClick()
        {
            if (DashboardButtonClicked != null)
            {
                DashboardButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onTasksButtonClick()
        {
            if (TasksButtonClicked != null)
            {
                TasksButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onSalesRequestButtonClick()
        {
            if (SalesRequestButtonClicked != null)
            {
                SalesRequestButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onReleaseWORButtonClick()
        {
            if (ReleaseWORButtonClicked != null)
            {
                ReleaseWORButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onCompileTravelerButtonClick()
        {
            if (CompileTravelerButtonClicked != null)
            {
                CompileTravelerButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onTravelerReturnButtonClick()
        {
            if (TravelerReturnButtonClicked != null)
            {
                TravelerReturnButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onHomeButtonClick()
        {
            if (HomeButtonClicked != null)
            {
                HomeButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onExitButtonClick()
        {
            if (ExitButtonClicked != null)
            {
                ExitButtonClicked(this, EventArgs.Empty);
            }
        }

        //Physical Button Events--------------------------------------------------------------

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            onDashboardButtonClick();
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            onTasksButtonClick();
        }

        private void btnSalesRequest_Click(object sender, EventArgs e)
        {
            onSalesRequestButtonClick();
        }

        private void btnReleaseWOR_Click(object sender, EventArgs e)
        {
            onReleaseWORButtonClick();
        }

        private void btnCompileTraveler_Click(object sender, EventArgs e)
        {
            onCompileTravelerButtonClick();
        }

        private void btnTravelerReturn_Click(object sender, EventArgs e)
        {
            onTravelerReturnButtonClick();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            onHomeButtonClick();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            onExitButtonClick();
        }
    }
}
