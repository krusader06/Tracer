using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tracer.Forms.Views.Default
{
    public partial class ucDefaultDashboard : UserControl
    {
        //Event Handlers--------------------------------------------------------------
        public event EventHandler ProcessButtonClicked;
        public event EventHandler SalesButtonClicked;
        public event EventHandler PurchasingButtonClicked;
        public event EventHandler ProductionButtonClicked;
        public event EventHandler ExecutiveButtonClicked;
        public event EventHandler ExitButtonClicked;

        //On Load Stuff--------------------------------------------------------------
        private static ucDefaultDashboard _instance;
        public static ucDefaultDashboard Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucDefaultDashboard();
                return _instance;
            }
        }

        public ucDefaultDashboard()
        {
            InitializeComponent();
        }

        //Button Event Handlers--------------------------------------------------------------

        private void onProcessButtonClick()
        {
            if (ProcessButtonClicked != null)
            {
                ProcessButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onSalesButtonClick()
        {
            if (SalesButtonClicked != null)
            {
                SalesButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onPurchasingButtonClick()
        {
            if (PurchasingButtonClicked != null)
            {
                PurchasingButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onProductionButtonClick()
        {
            if (ProductionButtonClicked != null)
            {
                ProductionButtonClicked(this, EventArgs.Empty);
            }
        }
        private void onExecutiveButtonClick()
        {
            if (ExecutiveButtonClicked != null)
            {
                ExecutiveButtonClicked(this, EventArgs.Empty);
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


        private void btnProcess_Click(object sender, EventArgs e)
        {
            onProcessButtonClick();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            onSalesButtonClick();
        }

        private void btnPurchasing_Click(object sender, EventArgs e)
        {
            onPurchasingButtonClick();
        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            onProductionButtonClick();
        }

        private void btnExecutive_Click(object sender, EventArgs e)
        {
            onExecutiveButtonClick();
        }
  
        private void btnExit_Click(object sender, EventArgs e)
        {
            onExitButtonClick();
        }
    }
}
