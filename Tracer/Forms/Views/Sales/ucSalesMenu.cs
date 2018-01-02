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
    public partial class ucSalesMenu : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public event EventHandler DashboardButtonClicked;
        public event EventHandler TasksButtonClicked;
        public event EventHandler AddEditQuoteButtonClicked;
        public event EventHandler EditLotButtonClicked;
        public event EventHandler RequestPreBidReviewButtonClicked;
        public event EventHandler RequestPartsReviewButtonClicked;
        public event EventHandler ReviewMasterButtonClicked;
        public event EventHandler AddPurchaseOrderButtonClicked;
        public event EventHandler DeactivateQuoteButtonClicked;
        public event EventHandler HomeButtonClicked;
        public event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucSalesMenu _instance;
        public static ucSalesMenu Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSalesMenu();
                return _instance;
            }
        }

        public ucSalesMenu()
        {
            InitializeComponent();
        }


        //Button Event Handlers--------------------------------------------------------------
        private void OnDashboardButtonClick()
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

        private void onAddEditQuoteButtonClick()
        {
            if (AddEditQuoteButtonClicked != null)
            {
                AddEditQuoteButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onEditLotButtonClick()
        {
            if (EditLotButtonClicked != null)
            {
                EditLotButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onRequestPreBidReviewButtonClick()
        {
            if (RequestPreBidReviewButtonClicked != null)
            {
                RequestPreBidReviewButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onRequestPartsReviewButtonClick()
        {
            if (RequestPartsReviewButtonClicked != null)
            {
                RequestPartsReviewButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onReviewMasterButtonClick()
        {
            if (ReviewMasterButtonClicked != null)
            {
                ReviewMasterButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onAddPurchaseOrderButtonClick()
        {
            if (AddPurchaseOrderButtonClicked != null)
            {
                AddPurchaseOrderButtonClicked(this, EventArgs.Empty);
            }
        }

        private void onDeactivateQuoteButtonClick()
        {
            if (DeactivateQuoteButtonClicked != null)
            {
                DeactivateQuoteButtonClicked(this, EventArgs.Empty);
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
            OnDashboardButtonClick();
        }

        private void btnTasks_Click(object sender, EventArgs e)
        {
            onTasksButtonClick();
        }

        private void btnAddEditQuote_Click(object sender, EventArgs e)
        {
            onAddEditQuoteButtonClick();
        }

        private void btnEditLot_Click(object sender, EventArgs e)
        {
            onEditLotButtonClick();
        }

        private void btnRequestPreBidReview_Click(object sender, EventArgs e)
        {
            onRequestPreBidReviewButtonClick();
        }

        private void btnRequestPartsReview_Click(object sender, EventArgs e)
        {
            onRequestPartsReviewButtonClick();
        }

        private void btnReviewMaster_Click(object sender, EventArgs e)
        {
            onReviewMasterButtonClick();
        }

        private void btnAddPurchaseOrder_Click(object sender, EventArgs e)
        {
            onAddPurchaseOrderButtonClick();
        }

        private void btnDeactivateQuote_Click(object sender, EventArgs e)
        {
            onDeactivateQuoteButtonClick();
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
