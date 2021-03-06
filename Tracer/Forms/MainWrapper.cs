﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tracer
{
    public partial class MainShell : Form
    {
        public MainShell()
        {
            //On Initial Application Run, load the default menu and view selection dashboard
            InitializeComponent();
            //Load the default view
            prepareView(null, null);
        }

        //-------------------------Menu Toolstrip Controllers----------------------------------------

        private void engineeringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process View Button Clicked...Switch To Process View
            prepareEngineeringView(sender, e);
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sales View Button Clicked...Switch To Sales View
            prepareSalesView(sender, e);
        }

        private void purchasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Purchasing View Button Clicked...Switch To Purchasing View
            preparePurchasingView(sender, e);
        }

        private void productionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Production View Button Clicked...Switch To Production View
            prepareProductionView(sender, e);
        }

        private void executiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Executive View Button Clicked...Switch To Executive View
            prepareExecutiveView(sender, e);
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Hime View Button Clicked...Switch To Home View
            prepareView(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //-------------------------Home View Controller------------------------------------------
        private void prepareView(object sender, EventArgs e)
        {
            //Get the default view appSetting...
            string defaultView = ConfigurationManager.AppSettings["DefaultView"];

            if (defaultView == "")
            {
                defaultView = "Home";
            }

            switch (defaultView)
            {
                case "Home":
                    prepareHomeView(sender, e);
                    break;

                case "Sales":
                    prepareSalesView(sender, e);
                    break;

                case "Engineering":
                    prepareEngineeringView(sender, e);
                    break;

                case "Purchasing":
                    preparePurchasingView(sender, e);
                    break;

                case "Production":
                    prepareProductionView(sender, e);
                    break;

                case "Executive":
                    prepareExecutiveView(sender, e);
                    break;
            }
        }

        private void prepareHomeView(object sender, EventArgs e)
        {
            showHomeMenu(sender, e);
            showHomeDashboard(sender, e);
            homeToolStripMenuItem.Checked = true;

            //Set up checks for menu strip
            engineeringToolStripMenuItem.Checked = false;
            salesToolStripMenuItem.Checked = false;
            purchasingToolStripMenuItem.Checked = false;
            productionToolStripMenuItem.Checked = false;
            executiveToolStripMenuItem.Checked = false;
            homeToolStripMenuItem.Checked = false;
        }

            private void showHomeMenu(object sender, EventArgs e)
        {
            //Load Home Menu
            if (!MenuContainer.Controls.Contains(Forms.Views.Default.ucDefaultMenu.Instance))
            {
                MenuContainer.Controls.Add(Forms.Views.Default.ucDefaultMenu.Instance);
                Forms.Views.Default.ucDefaultMenu.Instance.Dock = DockStyle.Fill;
                Forms.Views.Default.ucDefaultMenu.Instance.BringToFront();

                //Subscribe to Home Buttons

                Forms.Views.Default.ucDefaultMenu.ExitButtonClicked += new EventHandler(exitApplication);
            }
            else
            {
                Forms.Views.Default.ucDefaultMenu.Instance.BringToFront();
            }
        }

        private void showHomeDashboard(object sender, EventArgs e)
        {
            lblMain.Text = "";

            // Show the Default Main View Dashboard
            if (!mainContainer.Controls.Contains(Forms.Views.Default.ucDefaultDashboard.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Default.ucDefaultDashboard.Instance);
                Forms.Views.Default.ucDefaultDashboard.Instance.Dock = DockStyle.Fill;
                Forms.Views.Default.ucDefaultDashboard.Instance.BringToFront();

                //Subscribe to Children Buttons

                Forms.Views.Default.ucDefaultDashboard.Instance.ProcessButtonClicked += new EventHandler(prepareEngineeringView);
                Forms.Views.Default.ucDefaultDashboard.Instance.SalesButtonClicked += new EventHandler(prepareSalesView);
                Forms.Views.Default.ucDefaultDashboard.Instance.PurchasingButtonClicked += new EventHandler(preparePurchasingView);
                Forms.Views.Default.ucDefaultDashboard.Instance.ProductionButtonClicked += new EventHandler(prepareProductionView);
                Forms.Views.Default.ucDefaultDashboard.Instance.ExecutiveButtonClicked += new EventHandler(prepareExecutiveView);
                Forms.Views.Default.ucDefaultDashboard.Instance.ExitButtonClicked += new EventHandler(exitApplication);
            }
            else
            {
                Forms.Views.Default.ucDefaultDashboard.Instance.BringToFront();
            }
        }

        //-------------------------Engineering View Controller------------------------------------------
        private void prepareEngineeringView(object sender, EventArgs e)
        {
            showEngineeringMenu(sender, e);
            showEngineeringDashboard(sender, e);

            //Set up checks for menu strip
            engineeringToolStripMenuItem.Checked = true;
            salesToolStripMenuItem.Checked = false;
            purchasingToolStripMenuItem.Checked = false;
            productionToolStripMenuItem.Checked = false;
            executiveToolStripMenuItem.Checked = false;
            homeToolStripMenuItem.Checked = false;
        }

        private void showEngineeringMenu(object sender, EventArgs e)
        {
            if (!MenuContainer.Controls.Contains(Forms.Views.Engineering.ucEngineeringMenu.Instance))
            {
                MenuContainer.Controls.Add(Forms.Views.Engineering.ucEngineeringMenu.Instance);
                Forms.Views.Engineering.ucEngineeringMenu.Instance.Dock = DockStyle.Fill;
                Forms.Views.Engineering.ucEngineeringMenu.Instance.BringToFront();

                //Listen To Menu Buttons

                Forms.Views.Engineering.ucEngineeringMenu.Instance.DashboardButtonClicked += new EventHandler(showEngineeringDashboard);
                Forms.Views.Engineering.ucEngineeringMenu.Instance.SalesRequestButtonClicked += new EventHandler(showSalesRequest);
                Forms.Views.Engineering.ucEngineeringMenu.Instance.PerformEngineeringTaskButtonClicked += new EventHandler(showPerformEngineeringTask);
                Forms.Views.Engineering.ucEngineeringMenu.Instance.HomeButtonClicked += new EventHandler(prepareHomeView);
                Forms.Views.Engineering.ucEngineeringMenu.Instance.ExitButtonClicked += new EventHandler(exitApplication);
            }
            else
            {
                Forms.Views.Engineering.ucEngineeringMenu.Instance.BringToFront();
            }
        }

        private void showEngineeringDashboard(object sender, EventArgs e)
        {
            //Show the Engineering Dashboard

            lblMain.Text = "Engineering - Dashboard";

            if (!mainContainer.Controls.Contains(Forms.Views.Engineering.ucProcessDashboard.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Engineering.ucProcessDashboard.Instance);
                Forms.Views.Engineering.ucProcessDashboard.Instance.Dock = DockStyle.Fill;
                Forms.Views.Engineering.ucProcessDashboard.Instance.BringToFront();
                //Listen to Dashboard Buttons Here
                    //None...
            }
            else
            {
                Forms.Views.Engineering.ucProcessDashboard.Instance.BringToFront();
                Forms.Views.Engineering.ucProcessDashboard.Instance.populate(null, null);
            }  
        }

        private void showSalesRequest(object sender, EventArgs e)
        {
            //Show the Engineering Dashboard

            lblMain.Text = "Engineering - Sales Request";

            if (!mainContainer.Controls.Contains(Forms.Views.Engineering.ucSalesRequest.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Engineering.ucSalesRequest.Instance);
                Forms.Views.Engineering.ucSalesRequest.Instance.Dock = DockStyle.Fill;
                Forms.Views.Engineering.ucSalesRequest.Instance.BringToFront();
                //Listen to Dashboard Buttons Here
                //None...
            }
            else
            {
                Forms.Views.Engineering.ucSalesRequest.Instance.BringToFront();
                Forms.Views.Engineering.ucSalesRequest.Instance.ShowLotNumbers();
            }
        }

        private void showPerformEngineeringTask(object sender, EventArgs e)
        {
            //Show the Engineering Dashboard

            lblMain.Text = "Engineering - Perform Engineering Tasks";

            if (!mainContainer.Controls.Contains(Forms.Views.Engineering.ucPerformEngineeringTask.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Engineering.ucPerformEngineeringTask.Instance);
                Forms.Views.Engineering.ucPerformEngineeringTask.Instance.Dock = DockStyle.Fill;
                Forms.Views.Engineering.ucPerformEngineeringTask.Instance.BringToFront();
                //Listen to Dashboard Buttons Here
                //None...
            }
            else
            {
                Forms.Views.Engineering.ucPerformEngineeringTask.Instance.BringToFront();
                Forms.Views.Engineering.ucPerformEngineeringTask.Instance.ShowLotNumbers();
            }
        }

        //-------------------------Sales View Controller------------------------------------------

        private void prepareSalesView(object sender, EventArgs e)
        {
            showSalesMenu(sender, e);
            showSalesDashboard(sender, e);

            //Set up checks for menu strip
            engineeringToolStripMenuItem.Checked = false;
            salesToolStripMenuItem.Checked = true;
            purchasingToolStripMenuItem.Checked = false;
            productionToolStripMenuItem.Checked = false;
            executiveToolStripMenuItem.Checked = false;
            homeToolStripMenuItem.Checked = false;
        }

        private void showSalesMenu(object sender, EventArgs e)
        {
            //Show Sales Menu
            if (!MenuContainer.Controls.Contains(Forms.Views.Sales.ucSalesMenu.Instance))
            {
                MenuContainer.Controls.Add(Forms.Views.Sales.ucSalesMenu.Instance);
                Forms.Views.Sales.ucSalesMenu.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucSalesMenu.Instance.BringToFront();

                //Listen To Menu Buttons

                Forms.Views.Sales.ucSalesMenu.Instance.DashboardButtonClicked += new EventHandler(showSalesDashboard);
                Forms.Views.Sales.ucSalesMenu.Instance.AddEditQuoteButtonClicked += new EventHandler(showSalesAddEditQuote);
                Forms.Views.Sales.ucSalesMenu.Instance.EditLotButtonClicked += new EventHandler(showSalesEditLot);
                Forms.Views.Sales.ucSalesMenu.Instance.EngineeringRequestButtonClicked += new EventHandler(showEngineeringRequest);
                Forms.Views.Sales.ucSalesMenu.Instance.PurchasingRequestButtonClicked += new EventHandler(showPurchasingRequest);
                Forms.Views.Sales.ucSalesMenu.Instance.AddPurchaseOrderButtonClicked += new EventHandler(showSalesAddPurchaseOrder);
                Forms.Views.Sales.ucSalesMenu.Instance.SendQuoteButtonClicked += new EventHandler(showSendQuote);
                Forms.Views.Sales.ucSalesMenu.Instance.DeactivateQuoteButtonClicked += new EventHandler(showDeActivateQuote);
                Forms.Views.Sales.ucSalesMenu.Instance.HomeButtonClicked += new EventHandler(prepareHomeView);
                Forms.Views.Sales.ucSalesMenu.Instance.ExitButtonClicked += new EventHandler(exitApplication);
            }
            else
            {
                Forms.Views.Sales.ucSalesMenu.Instance.BringToFront();
            }
        }

        private void showSalesDashboard(object sender, EventArgs e)
        {
            // Show the Sales View Dashboard

            lblMain.Text = "Sales - Dashboard";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucSalesDashboard.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucSalesDashboard.Instance);
                Forms.Views.Sales.ucSalesDashboard.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucSalesDashboard.Instance.BringToFront();
            }
            else
            {
                Forms.Views.Sales.ucSalesDashboard.Instance.BringToFront();
                Forms.Views.Sales.ucSalesDashboard.Instance.populate(null, null);
            }
        }

        private void showSalesAddEditQuote(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Add or Update Quote";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucAddEditQuote.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucAddEditQuote.Instance);
                Forms.Views.Sales.ucAddEditQuote.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucAddEditQuote.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucAddEditQuote.Instance.BringToFront();
            }
        }

        private void showSalesEditLot(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Edit Lot Numbers";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucEditLot.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucEditLot.Instance);
                Forms.Views.Sales.ucEditLot.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucEditLot.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucEditLot.Instance.BringToFront();
            }
        }

        private void showEngineeringRequest(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Engineering Request";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucEngineeringRequest.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucEngineeringRequest.Instance);
                Forms.Views.Sales.ucEngineeringRequest.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucEngineeringRequest.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucEngineeringRequest.Instance.BringToFront();
                Forms.Views.Sales.ucEngineeringRequest.Instance.ShowActiveQuotes();
            }
        }

        private void showPurchasingRequest(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Purchasing Request";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucPurchasingRequest.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucPurchasingRequest.Instance);
                Forms.Views.Sales.ucPurchasingRequest.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucPurchasingRequest.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucPurchasingRequest.Instance.BringToFront();
                Forms.Views.Sales.ucPurchasingRequest.Instance.ShowActiveQuotes();
            }
        }

        

        private void showSalesAddPurchaseOrder(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Select Quote to Add Purchase Order";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucLinkPurchaseOrder.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucLinkPurchaseOrder.Instance);
                Forms.Views.Sales.ucLinkPurchaseOrder.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucLinkPurchaseOrder.Instance.BringToFront();

                //Add Event Listeners If Necessary...
                Tracer.Forms.Views.Sales.ucLinkPurchaseOrder.Instance.POButtonClicked += new EventHandler(showSalesAddLots);
            }
            else
            {
                Forms.Views.Sales.ucLinkPurchaseOrder.Instance.BringToFront();
                Forms.Views.Sales.ucLinkPurchaseOrder.Instance.updateData(null, null);
            }
        }

        private void showSalesAddLots(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Add Lot Numbers to Work Order";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucAddLot.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucAddLot.Instance);
                Forms.Views.Sales.ucAddLot.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucAddLot.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucAddLot.Instance.BringToFront();
            }
        }

        private void showSendQuote(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - Send Quote to Customer";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucSendQuote.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucSendQuote.Instance);
                Forms.Views.Sales.ucSendQuote.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucSendQuote.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucSendQuote.Instance.BringToFront();
                Forms.Views.Sales.ucSendQuote.Instance.ShowActiveQuotes();
            }
        }

        private void showDeActivateQuote(object sender, EventArgs e)
        {
            // Show the Sales Add New Quote Page

            lblMain.Text = "Sales - De-Activate Quote";

            if (!mainContainer.Controls.Contains(Forms.Views.Sales.ucDeActivateQuote.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Sales.ucDeActivateQuote.Instance);
                Forms.Views.Sales.ucDeActivateQuote.Instance.Dock = DockStyle.Fill;
                Forms.Views.Sales.ucDeActivateQuote.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Sales.ucDeActivateQuote.Instance.BringToFront();
                Forms.Views.Sales.ucDeActivateQuote.Instance.ShowActiveQuotes();
            }
        }

        //-------------------------Purchasing View Controller------------------------------------------
        private void preparePurchasingView(object sender, EventArgs e)
        {
            showPurchasingMenu(sender, e);
            showPurchasingDashboard(sender, e);

            //Set up checks for menu strip
            engineeringToolStripMenuItem.Checked = false;
            salesToolStripMenuItem.Checked = false;
            purchasingToolStripMenuItem.Checked = true;
            productionToolStripMenuItem.Checked = false;
            executiveToolStripMenuItem.Checked = false;
            homeToolStripMenuItem.Checked = false;
        }

        private void showPurchasingMenu(object sender, EventArgs e)
        {
            //Show Purchasing Menu
            if (!MenuContainer.Controls.Contains(Forms.Views.Purchasing.ucPurchasingMenu.Instance))
            {
                MenuContainer.Controls.Add(Forms.Views.Purchasing.ucPurchasingMenu.Instance);
                Forms.Views.Purchasing.ucPurchasingMenu.Instance.Dock = DockStyle.Fill;
                Forms.Views.Purchasing.ucPurchasingMenu.Instance.BringToFront();

                //Listen To Menu Buttons

                Forms.Views.Purchasing.ucPurchasingMenu.Instance.DashboardButtonClicked += new EventHandler(showPurchasingDashboard);
                Forms.Views.Purchasing.ucPurchasingMenu.Instance.PerformPurchasingTaskButtonClicked += new EventHandler(showPerformPurchasingTask);
                Forms.Views.Purchasing.ucPurchasingMenu.Instance.HomeButtonClicked += new EventHandler(prepareHomeView);
                Forms.Views.Purchasing.ucPurchasingMenu.Instance.ExitButtonClicked += new EventHandler(exitApplication);

            }
            else
            {
                Forms.Views.Purchasing.ucPurchasingMenu.Instance.BringToFront();
            }
        }

        private void showPurchasingDashboard(object sender, EventArgs e)
        {
            // Show the Purchasing Main View Dashboard
            lblMain.Text = "Purchasing - Dashboard";

            if (!mainContainer.Controls.Contains(Forms.Views.Purchasing.ucPurchasingDashboard.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Purchasing.ucPurchasingDashboard.Instance);
                Forms.Views.Purchasing.ucPurchasingDashboard.Instance.Dock = DockStyle.Fill;
                Forms.Views.Purchasing.ucPurchasingDashboard.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Purchasing.ucPurchasingDashboard.Instance.BringToFront();
                Forms.Views.Purchasing.ucPurchasingDashboard.Instance.populate(sender, e);
            }
        }

        private void showPerformPurchasingTask(object sender, EventArgs e)
        {
            // Show the Purchasing Main View Dashboard
            lblMain.Text = "Purchasing - Perform Purchasing Task";

            if (!mainContainer.Controls.Contains(Forms.Views.Purchasing.ucPerformPurchasingTask.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Purchasing.ucPerformPurchasingTask.Instance);
                Forms.Views.Purchasing.ucPerformPurchasingTask.Instance.Dock = DockStyle.Fill;
                Forms.Views.Purchasing.ucPerformPurchasingTask.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Purchasing.ucPerformPurchasingTask.Instance.BringToFront();
                Forms.Views.Purchasing.ucPerformPurchasingTask.Instance.ShowLotNumbers();
            }
        }


        //-------------------------Production View Controller------------------------------------------

        private void prepareProductionView(object sender, EventArgs e)
        {
            showProductionMenu(sender, e);
            showProductionDashboard(sender, e);

            //Set up checks for menu strip
            engineeringToolStripMenuItem.Checked = false;
            salesToolStripMenuItem.Checked = false;
            purchasingToolStripMenuItem.Checked = false;
            productionToolStripMenuItem.Checked = true;
            executiveToolStripMenuItem.Checked = false;
            homeToolStripMenuItem.Checked = false;
        }

        private void showProductionMenu(object sender, EventArgs e)
        {
            //Show Production Menu
            if (!MenuContainer.Controls.Contains(Forms.Views.Production.ucProductionMenu.Instance))
            {
                MenuContainer.Controls.Add(Forms.Views.Production.ucProductionMenu.Instance);
                Forms.Views.Production.ucProductionMenu.Instance.Dock = DockStyle.Fill;
                Forms.Views.Production.ucProductionMenu.Instance.BringToFront();

                //Listen To Menu Buttons

                Forms.Views.Purchasing.ucPurchasingMenu.Instance.DashboardButtonClicked += new EventHandler(showProductionDashboard);
                Forms.Views.Production.ucProductionMenu.Instance.HomeButtonClicked += new EventHandler(prepareHomeView);
                Forms.Views.Production.ucProductionMenu.Instance.ExitButtonClicked += new EventHandler(exitApplication);
            }
            else
            {
                Forms.Views.Production.ucProductionMenu.Instance.BringToFront();
            }
        }

        private void showProductionDashboard(object sender, EventArgs e)
        {
            // Show the Production Main View Dashboard
            lblMain.Text = "Production - Dashboard";

            if (!mainContainer.Controls.Contains(Forms.Views.Production.ucProductionDashboard.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Production.ucProductionDashboard.Instance);
                Forms.Views.Production.ucProductionDashboard.Instance.Dock = DockStyle.Fill;
                Forms.Views.Production.ucProductionDashboard.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Production.ucProductionDashboard.Instance.BringToFront();
                Forms.Views.Production.ucProductionDashboard.Instance.populate(null,null);
            }

        }

        //-------------------------Executive View Controller------------------------------------------

        private void prepareExecutiveView(object sender, EventArgs e)
        {
            showExecutiveMenu(sender, e);
            showExecutiveDashboard(sender, e);

            //Set up checks for menu strip
            engineeringToolStripMenuItem.Checked = false;
            salesToolStripMenuItem.Checked = false;
            purchasingToolStripMenuItem.Checked = false;
            productionToolStripMenuItem.Checked = false;
            executiveToolStripMenuItem.Checked = true;
            homeToolStripMenuItem.Checked = false;
        }

        private void showExecutiveMenu(object sender, EventArgs e)
        {
            //Show Executive Menu
            if (!MenuContainer.Controls.Contains(Forms.Views.Executive.ucExecutiveMenu.Instance))
            {
                MenuContainer.Controls.Add(Forms.Views.Executive.ucExecutiveMenu.Instance);
                Forms.Views.Executive.ucExecutiveMenu.Instance.Dock = DockStyle.Fill;
                Forms.Views.Executive.ucExecutiveMenu.Instance.BringToFront();

                //Listen To Menu Buttons

                Forms.Views.Executive.ucExecutiveMenu.Instance.DashboardButtonClicked += new EventHandler(showExecutiveDashboard);
                Forms.Views.Executive.ucExecutiveMenu.Instance.SuperHotButtonClicked += new EventHandler(showSuperHot);
                Forms.Views.Executive.ucExecutiveMenu.Instance.HomeButtonClicked += new EventHandler(prepareHomeView);
                Forms.Views.Executive.ucExecutiveMenu.Instance.ExitButtonClicked += new EventHandler(exitApplication);
            }
            else
            {
                Forms.Views.Executive.ucExecutiveMenu.Instance.BringToFront();
            }
        }

        private void showExecutiveDashboard(object sender, EventArgs e)
        {
            // Show the Executive Main View Dashboard
            lblMain.Text = "Executive - Dashboard";

            if (!mainContainer.Controls.Contains(Forms.Views.Executive.ucExecutiveDashboard.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Executive.ucExecutiveDashboard.Instance);
                Forms.Views.Executive.ucExecutiveDashboard.Instance.Dock = DockStyle.Fill;
                Forms.Views.Executive.ucExecutiveDashboard.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Executive.ucExecutiveDashboard.Instance.BringToFront();
                Forms.Views.Executive.ucExecutiveDashboard.Instance.populate(null, null);
            }
        }

        private void showSuperHot(object sender, EventArgs e)
        {
            // Show the Executive Main View Dashboard
            lblMain.Text = "Executive - Set Super Hot Priority";

            if (!mainContainer.Controls.Contains(Forms.Views.Executive.ucSuperHot.Instance))
            {
                mainContainer.Controls.Add(Forms.Views.Executive.ucSuperHot.Instance);
                Forms.Views.Executive.ucSuperHot.Instance.Dock = DockStyle.Fill;
                Forms.Views.Executive.ucSuperHot.Instance.BringToFront();

                //Add Event Listeners If Necessary...

            }
            else
            {
                Forms.Views.Executive.ucSuperHot.Instance.BringToFront();
                Forms.Views.Executive.ucSuperHot.Instance.ShowLotNumbers();
            }
        }


        //-------------------------Exit Button---------------------------------------------------

        private void exitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
