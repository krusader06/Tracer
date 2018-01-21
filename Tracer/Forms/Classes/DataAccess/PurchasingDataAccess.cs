using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tracer.Forms.Classes.DataAccess
{
    public class PurchasingDataAccess
    {

        public List<DatabaseTables.LotNumbers> GetLotNumbers()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {//Grab all Unique Lot Numbers that aren't complete and Master Review has not been requested/In Progress
                return connection.Query<DatabaseTables.LotNumbers>(
                    $"SELECT DISTINCT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.Customer " +
                    $", LotNumbers.PartID " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotStatus.LotID = LotNumbers.LotID " +
                    $"WHERE LotStatus.JobComplete = 'False' " +
                    $"AND LotStatus.WORLotReleased = 'True' " +
                    $"ORDER BY LotNumbers.JobWOR, LotNumbers.Lot").ToList();
            }
        }

        //Task Queries-----------------------------------------------------------------------------------------------------------------

        public List<Classes.LotTask> GetPurchasingTaskList()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {   //Responsible for returning Purchasing Task types and compiling them under a lotTask list

                return connection.Query<Classes.LotTask>(
                    //Get Parts Review Sales Requests
                    $"SELECT ActiveQuotes.QuoteWOR AS JobWOR " +
                    $", Lot = '0' " +
                    $", ActiveQuotes.PartID " +
                    $", JobStatus = 'Parts Review Requested' " +
                    $", QuoteDueDate AS DueDate " +
                    $", SuperHot = '0' " +
                    $"FROM ActiveQuotes " +
                    $"INNER JOIN QuoteStatus " +
                    $"ON ActiveQuotes.QuoteWOR = QuoteStatus.QuoteWOR " +
                    $"WHERE QuoteStatus.PartsReviewRequest = 'True' " +
                    $"AND QuoteStatus.PartsReviewInProgress = 'False' " +
                    $"AND ActiveQuotes.QuoteInactive = 'False' " +
                    $"AND ActiveQuotes.POReceived = 'False' " +

                    $"UNION " +
                    //Parts Review In Progress Sales Request
                    $"SELECT ActiveQuotes.QuoteWOR AS JobWOR " +
                    $", Lot = '0' " +
                    $", ActiveQuotes.PartID " +
                    $", JobStatus = 'Parts Review In Progress' " +
                    $", QuoteDueDate AS DueDate " +
                    $", SuperHot = '0' " +
                    $"FROM ActiveQuotes " +
                    $"INNER JOIN QuoteStatus " +
                    $"ON ActiveQuotes.QuoteWOR = QuoteStatus.QuoteWOR " +
                    $"WHERE QuoteStatus.PartsReviewRequest = 'True' " +
                    $"AND QuoteStatus.PartsReviewInProgress = 'True' " +
                    $"AND ActiveQuotes.QuoteInactive = 'False' " +
                    $"AND ActiveQuotes.POReceived = 'False' " +

                    $"UNION " +
                    //Order Parts after a WOR has been released
                    $"SELECT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", JobStatus = 'Order Parts' " +
                    $", JobDueDate AS DueDate " +
                    $", SuperHot " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +
                    $"INNER JOIN LotPurchasingStatus " +
                    $"ON LotPurchasingStatus.LotID = LotNumbers.LotID " +
                    $"WHERE LotStatus.WORLotReleased = 'True' " +
                    $"AND LotPurchasingStatus.PartsRequired = 'True' " +
                    $"AND LotPurchasingStatus.PartsOrdered = 'False' " +

                    $"UNION " +
                    //Order PCBs after a WOR has been released
                    $"SELECT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", JobStatus = 'Order PCBs' " +
                    $", JobDueDate AS DueDate " +
                    $", SuperHot " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +
                    $"INNER JOIN LotPurchasingStatus " +
                    $"ON LotPurchasingStatus.LotID = LotNumbers.LotID " +
                    $"WHERE LotStatus.WORLotReleased = 'True' " +
                    $"AND LotPurchasingStatus.PCBRequired = 'True' " +
                    $"AND LotPurchasingStatus.PCBOrdered = 'False' " +

                    $"UNION " +
                    //Order Stencils after a WOR has been released
                    $"SELECT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", JobStatus = 'Order Stencils' " +
                    $", JobDueDate AS DueDate " +
                    $", SuperHot " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +
                    $"INNER JOIN LotPurchasingStatus " +
                    $"ON LotPurchasingStatus.LotID = LotNumbers.LotID " +
                    $"WHERE LotStatus.WORLotReleased = 'True' " +
                    $"AND LotPurchasingStatus.StencilsRequired = 'True' " +
                    $"AND LotPurchasingStatus.StencilsOrdered = 'False' " +
                    $"AND LotPurchasingStatus.PCBArraysApproved = 'True' " +

                    $"ORDER BY SuperHot DESC, DueDate, JobWOR, Lot").ToList();


            }
        }


        //BOM Validation Tasks----------------------------------------------------------------------

        public void UpdatePartsReviewInProgress(LotTask currentTask)
        {

            //Set BomValidationInProgress Flag within QuoteStatus
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Update PartsReviewInProgress where QuoteWOR = workorder from currentTask
                connection.Execute($"UPDATE QuoteStatus SET PartsReviewInProgress='True' WHERE QuoteWOR='{ currentTask.JobWOR }'");
            }
        }

        public void UpdatePartsReviewComplete(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Change PartsReviewRequest, PartsReviewInProgress flags to "False", and PartsReviewComplete flag to "True" where QuoteWOR = currentTask.JobWOR
                connection.Execute($"UPDATE QuoteStatus SET PartsReviewInProgress='False', PartsReviewRequest='False', PartsReviewComplete='True' WHERE QuoteWOR='{ currentTask.JobWOR }'");

                //TIME-TRACKING PLACE-HOLDER FOR NOW


                //DateTime rightNow = new DateTime();
                //rightNow = DateTime.Now;

                //3. update MasterReviewEnd(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                //connection.Execute($"UPDATE LotTimeTracking SET MasterReviewEnd='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

        //Parts Ordered----------------------------------------------------------------------
        public void UpdatePartsOrdered(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = currentTask.JobWOR and Lot = currentTask.Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change PartsOrdered flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET PartsOrdered='True' WHERE LotID='{ LotID[0] }'");

                //3. Get PurchasingStatusID from LotPurchasingStatus where LotID = returned LotID from previous Call
                var PurchasingStatusID = connection.Query<string>($"SELECT PurchasingStatusID FROM LotPurchasingStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update PartsOrderDate(time-stamp) in PurchasingTimeTracking where PurchasingStatusID = PurchasingStatusID from previous Call
                connection.Execute($"UPDATE PurchasingTimeTracking SET PartsOrderDate='{ rightNow.ToString() }' WHERE PurchasingStatusID='{ PurchasingStatusID[0] }'");
            }
        }

        //PCBs Ordered----------------------------------------------------------------------
        public void UpdatePCBOrdered(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = currentTask.JobWOR and Lot = currentTask.Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change PCBOrdered flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET PCBOrdered='True' WHERE LotID='{ LotID[0] }'");

                //3. Get PurchasingStatusID from LotPurchasingStatus where LotID = returned LotID from previous Call
                var PurchasingStatusID = connection.Query<string>($"SELECT PurchasingStatusID FROM LotPurchasingStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update PCBOrderDate(time-stamp) in PurchasingTimeTracking where PurchasingStatusID = PurchasingStatusID from previous Call
                connection.Execute($"UPDATE PurchasingTimeTracking SET PCBOrderDate='{ rightNow.ToString() }' WHERE PurchasingStatusID='{ PurchasingStatusID[0] }'");
            }
        }

        //Stencils Ordered----------------------------------------------------------------------
        public void UpdateStencilsOrdered(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = currentTask.JobWOR and Lot = currentTask.Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change StencilsOrdered flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET StencilsOrdered='True' WHERE LotID='{ LotID[0] }'");

                //3. Get PurchasingStatusID from LotPurchasingStatus where LotID = returned LotID from previous Call
                var PurchasingStatusID = connection.Query<string>($"SELECT PurchasingStatusID FROM LotPurchasingStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update StencilOrderDate(time-stamp) in PurchasingTimeTracking where PurchasingStatusID = PurchasingStatusID from previous Call
                connection.Execute($"UPDATE PurchasingTimeTracking SET StencilOrderDate='{ rightNow.ToString() }' WHERE PurchasingStatusID='{ PurchasingStatusID[0] }'");
            }
        }



        //Parts Received Task----------------------------------------------------------------------

        public void PartsReceived(string JobWOR, string Lot)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ JobWOR }' AND Lot=' { Lot }'").ToList();

                //2. Change TravelerReleased = True, TravelerReturned = False where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET PartsReceived = 'True' WHERE LotID='{ LotID[0] }'");

            }
        }


        //Stencils Received Task----------------------------------------------------------------------

        public void StencilsReceived(string JobWOR, string Lot)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ JobWOR }' AND Lot=' { Lot }'").ToList();

                //2. Change TravelerReleased = True, TravelerReturned = False where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET StencilsReceived = 'True' WHERE LotID='{ LotID[0] }'");

            }
        }

        //PCBs Received Task----------------------------------------------------------------------

        public void PCBsReceived(string JobWOR, string Lot)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ JobWOR }' AND Lot=' { Lot }'").ToList();

                //2. Change TravelerReleased = True, TravelerReturned = False where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET PCBReceived = 'True' WHERE LotID='{ LotID[0] }'");

            }
        }

        //Release Kit Task----------------------------------------------------------------------

        public void ReleaseKit(string JobWOR, string Lot)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ JobWOR }' AND Lot=' { Lot }'").ToList();

                //2. Change TravelerReleased = True, TravelerReturned = False where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotPurchasingStatus SET KitReleased = 'True' WHERE LotID='{ LotID[0] }'");

            }
        }


    }
}
