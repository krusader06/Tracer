using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Executive
{
    public partial class ucExecutiveMenu : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public event EventHandler DashboardButtonClicked;
        public event EventHandler SuperHotButtonClicked;
        public event EventHandler HomeButtonClicked;
        public event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucExecutiveMenu _instance;
        public static ucExecutiveMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucExecutiveMenu();
                return _instance;
            }
        }

        public ucExecutiveMenu()
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

        private void onSuperHotButtonClick()
        {
            if (SuperHotButtonClicked != null)
            {
                SuperHotButtonClicked(this, EventArgs.Empty);
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

        private void btnSuperHot_Click(object sender, EventArgs e)
        {
            onSuperHotButtonClick();
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
