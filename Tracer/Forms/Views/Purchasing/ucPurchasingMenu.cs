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
    public partial class ucPurchasingMenu : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public event EventHandler DashboardButtonClicked;
        public event EventHandler PerformPurchasingTaskButtonClicked;
        public event EventHandler HomeButtonClicked;
        public event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucPurchasingMenu _instance;
        public static ucPurchasingMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucPurchasingMenu();
                return _instance;
            }
        }

        public ucPurchasingMenu()
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

        private void onPerformPurchasingTaskButtonClick()
        {
            if (PerformPurchasingTaskButtonClicked != null)
            {
                PerformPurchasingTaskButtonClicked(this, EventArgs.Empty);
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

        private void btnPerformPurchasingTask_Click(object sender, EventArgs e)
        {
            onPerformPurchasingTaskButtonClick();
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
