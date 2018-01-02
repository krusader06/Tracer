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
        public event EventHandler TasksButtonClicked;
        public event EventHandler ReviewPartsForQuoteButtonClicked;
        public event EventHandler OrderItemsButtonClicked;
        public event EventHandler ItemsReceivedButtonClicked;
        public event EventHandler ReleaseKitButtonClicked;
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
        private void onTasksButtonClick()
        {
            if (TasksButtonClicked != null)
            {
                TasksButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onReviewPartsForQuoteButtonClick()
        {
            if (ReviewPartsForQuoteButtonClicked != null)
            {
                ReviewPartsForQuoteButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onOrderItemsButtonClick()
        {
            if (OrderItemsButtonClicked != null)
            {
                OrderItemsButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onItemsReceivedButtonClick()
        {
            if (ItemsReceivedButtonClicked != null)
            {
                ItemsReceivedButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onReleaseKitButtonClick()
        {
            if (ReleaseKitButtonClicked != null)
            {
                ReleaseKitButtonClicked(this, EventArgs.Empty);
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

        private void btnReviewPartsForQuote_Click(object sender, EventArgs e)
        {
            onReviewPartsForQuoteButtonClick();
        }

        private void btnOrderItems_Click(object sender, EventArgs e)
        {
            onOrderItemsButtonClick();
        }

        private void btnItemsReceived_Click(object sender, EventArgs e)
        {
            onItemsReceivedButtonClick();
        }

        private void btnReleaseKit_Click(object sender, EventArgs e)
        {
            onReleaseKitButtonClick();
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
