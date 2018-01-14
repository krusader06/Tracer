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

    public partial class ucEngineeringMenu : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public event EventHandler DashboardButtonClicked;
        public event EventHandler SalesRequestButtonClicked;
        public event EventHandler ReleaseWORButtonClicked;
        public event EventHandler CompileTravelerButtonClicked;
        public event EventHandler PerformEngineeringTaskButtonClicked;
        public event EventHandler HomeButtonClicked;
        public event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucEngineeringMenu _instance;
        public static ucEngineeringMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucEngineeringMenu();
                return _instance;
            }
        }
        public ucEngineeringMenu()
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
        private void onPerformEngineeringTaskButtonClick()
        {
            if (PerformEngineeringTaskButtonClicked != null)
            {
                PerformEngineeringTaskButtonClicked(this, EventArgs.Empty);
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

        private void btnPerformEngineeringTask_Click(object sender, EventArgs e)
        {
            onPerformEngineeringTaskButtonClick();
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
