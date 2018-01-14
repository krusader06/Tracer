using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Tracer.Forms.Classes.DatabaseTables;

namespace Tracer.Forms.Classes.DataAccess
{
    public class SalesDataAccess
    {

        //Generic Queries--------------------------------------------------------------------------------------------------------

        public List<DatabaseTables.ActiveQuotes> GetActiveQuotes()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<DatabaseTables.ActiveQuotes>($"SELECT * FROM ActiveQuotes WHERE QuoteInactive='False' AND POReceived='False'").ToList();
            }
        }

        public List<DatabaseTables.ActiveQuotes> GetAllQuotes()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<DatabaseTables.ActiveQuotes>($"SELECT * FROM ActiveQuotes").ToList();
            }
        }

        public List<DatabaseTables.ActiveQuotes> GetSingleQuote(string workOrder)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<DatabaseTables.ActiveQuotes>($"SELECT * FROM ActiveQuotes WHERE QuoteWOR='{ workOrder }'").ToList();
            }
        }

        public List<DatabaseTables.WorkOrders> GetAllWorkOrders()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<DatabaseTables.WorkOrders>($"SELECT * FROM WorkOrders").ToList();
            }
        }

        public List<DatabaseTables.WorkOrders> GetActiveWorkOrders()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<DatabaseTables.WorkOrders>($"SELECT * FROM WorkOrders WHERE WorkOrderComplete='False'").ToList();
            }
        }

        public List<Classes.DatabaseTables.LotNumbers> GetCurrentLotNumbers(string workOrder)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<Classes.DatabaseTables.LotNumbers>($"SELECT * FROM LotNumbers WHERE JobWOR='{ workOrder }'").ToList();
            }
        }

        //Task Queries--------------------------------------------------------------------------------------------------------------

        public List<Classes.LotTask> GetMasterReviewRequests()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                return connection.Query<Classes.LotTask>(
                    $"SELECT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", JobStatus = 'Master Review Requested' " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +
                    $"WHERE LotStatus.MasterReviewRequest = 'True' " +
                    $"AND LotStatus.MasterReviewInProgress = 'False' " +
                    $"AND LotStatus.JobComplete = 'False' " +

                    $"UNION " +

                    $"SELECT LotNumbers.JobWOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", JobStatus = 'Master Review In Progress' " +
                    $"FROM LotNumbers " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +
                    $"WHERE LotStatus.MasterReviewRequest = 'True' " +
                    $"AND LotStatus.MasterReviewInProgress = 'True' " +
                    $"AND LotStatus.JobComplete = 'False'").ToList();
            }
        }

        //Task Updates--------------------------------------------------------------------------------------------------------------
        public void UpdateReviewMasterInProgress(Classes.LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {

                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change MasterReviewInProgress flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET MasterReviewInProgress='True' WHERE LotID='{ LotID[0] }'");

                //3. Get LotStatusID from LotStatus where LotID = returned LotID from previous Call
                var LotStatusID = connection.Query<string>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update MasterReviewStart(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                connection.Execute($"UPDATE LotTimeTracking SET MasterReviewStart='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

        public void UpdateReviewMasterComplete(Classes.LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {

                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change MasterReviewInProgress, MasterReviewInProgress flags to "False", and MasterReviewComplete flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET MasterReviewInProgress='False', MasterReviewRequest='False', MasterReviewComplete='True' WHERE LotID='{ LotID[0] }'");

                //3. Get LotStatusID from LotStatus where LotID = returned LotID from previous Call
                var LotStatusID = connection.Query<string>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update MasterReviewEnd(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                connection.Execute($"UPDATE LotTimeTracking SET MasterReviewEnd='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }


        //Update Data---------------------------------------------------------------------------------------------------------------
        public void UpdateQuote(Classes.DatabaseTables.ActiveQuotes updateQuote)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                List<DatabaseTables.ActiveQuotes> activeQuote = new List<DatabaseTables.ActiveQuotes>();
                activeQuote.Add(updateQuote);

                connection.Execute($"UPDATE ActiveQuotes SET Date=@Date, Time=@Time, PartID=@PartID, Customer=@Customer, PartDescription=@PartDescription, QuoteConfidence=@QuoteConfidence, Consigned=@Consigned, Turnkey=@Turnkey, QuoteComments=@QuoteComments, QuoteDueDate=@QuoteDueDate WHERE QuoteWOR=@QuoteWOR", activeQuote);

            }
        }

        internal void UpdateLot(LotNumbers updateLot)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                List<DatabaseTables.LotNumbers> activeLot = new List<DatabaseTables.LotNumbers>();
                activeLot.Add(updateLot);

                connection.Execute($"UPDATE LotNumbers SET Lot=@Lot, OrderQuantity=@OrderQuantity, JobDueDate=@JobDueDate, MasterDueDate=@MasterDueDate, KitDueDate=@KitDueDate, TurnTime=@TurnTime, Consigned=@Consigned, Turnkey=@Turnkey, JobComments=@JobComments WHERE LotID=@LotID", activeLot);

            }
        }

        //Insert Data---------------------------------------------------------------------------------------------------------------

        public void InsertNewQuote(Classes.DatabaseTables.ActiveQuotes newActiveQuote, Classes.DatabaseTables.QuoteStatus newQuoteStatus)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Add new ActiveQuotes and QuoteStatus

                List<DatabaseTables.ActiveQuotes> activeQuote = new List<DatabaseTables.ActiveQuotes>();
                List<DatabaseTables.QuoteStatus> quoteStatus = new List<DatabaseTables.QuoteStatus>();

                activeQuote.Add(newActiveQuote);
                quoteStatus.Add(newQuoteStatus);

                connection.Execute($"insert into ActiveQuotes(QuoteWOR, Date, Time, PartID, Customer, PartDescription, QuoteConfidence, Consigned, Turnkey, QuoteComments, QuoteDueDate, QuoteInactive, POReceived) values(@QuoteWOR, @Date, @Time, @PartID, @Customer, @PartDescription, @QuoteConfidence, @Consigned, @Turnkey, @QuoteComments, @QuoteDueDate, @QuoteInactive, @POReceived)", activeQuote);
                connection.Execute($"insert into QuoteStatus(QuoteWOR, BOMValidationRequest, BOMValidationInProgress, BOMValidationComplete, PartsReviewRequest, PartsReviewInProgress, PartsReviewComplete, PreBidRequest, PreBidInProgress, PreBidComplete, FinalReviewRequest, FinalReviewInProgress, FinalReviewComplete, QuoteSent, QuoteCurrentStatus) values(@QuoteWOR, @BOMValidationRequest, @BOMValidationInProgress, @BOMValidationComplete, @PartsReviewRequest, @PartsReviewInProgress, @PartsReviewComplete, @PreBidRequest, @PreBidInProgress, @PreBidComplete, @FinalReviewRequest, @FinalReviewInProgress, @FinalReviewComplete, @QuoteSent, @QuoteCurrentStatus)", quoteStatus);

            }
        }

        public void InsterWorkOrder(Classes.DatabaseTables.WorkOrders newWorkOrder)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                List<DatabaseTables.WorkOrders> WorkOrders = new List<DatabaseTables.WorkOrders>();
                WorkOrders.Add(newWorkOrder);

                //Set POReceived Field to True
                connection.Execute($"UPDATE ActiveQuotes SET POReceived='True' WHERE QuoteWOR=@JobWOR", WorkOrders);

                //Insert New Work Order
                connection.Execute($"insert into WorkOrders(JobWOR, Date, Time, PurchaseOrderNumber, WorkOrderComplete) values(@JobWOR, @Date, @Time, @PurchaseOrderNumber, @WorkOrderComplete)", WorkOrders);

            }
        }

        public void InsertLotNumber(Classes.DatabaseTables.LotNumbers newLotNumber, Classes.DatabaseTables.LotStatus newLotStatus, Classes.DatabaseTables.LotPurchasingStatus newLotPurchasingStatus, Classes.DatabaseTables.LotTimeTracking newLotTimeTracking, Classes.DatabaseTables.PurchasingTimeTracking newPurchasingTimeTracking)
        {   //This fulfills the complete setup of a Lot number.

            //1. Enters a LotNumber
            //2. Gets the LotID
            //3. Enters a LotStatus
            //4. Gets LotStatusID
            //5. Enters LotTimeTracking
            //6. Enters a LotPurchasingStatus
            //7. Gets LotPurchasingStatusID
            //8. Enters PurchasingTimeTracking


            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Compile all classes into a list for each
                List<DatabaseTables.LotNumbers> lstNewLotNumber = new List<DatabaseTables.LotNumbers>();
                List<DatabaseTables.LotStatus> lstNewLotStatus = new List<DatabaseTables.LotStatus>();
                List<DatabaseTables.LotPurchasingStatus> lstNewLotPurchasingStatus = new List<DatabaseTables.LotPurchasingStatus>();
                List<DatabaseTables.LotTimeTracking> lstNewLotTimeTracking = new List<DatabaseTables.LotTimeTracking>();
                List<DatabaseTables.PurchasingTimeTracking> lstNewPurchasingTimeTracking = new List<DatabaseTables.PurchasingTimeTracking>();

                //Add Each class to the respective list
                lstNewLotNumber.Add(newLotNumber);
                lstNewLotStatus.Add(newLotStatus);
                lstNewLotPurchasingStatus.Add(newLotPurchasingStatus);
                lstNewLotTimeTracking.Add(newLotTimeTracking);
                lstNewPurchasingTimeTracking.Add(newPurchasingTimeTracking);

                //1. Enter LotNumber
                connection.Execute($"insert into LotNumbers(JobWOR, Lot, Customer, PartID, PartDescription, OrderQuantity, JobDueDate, MasterDueDate, KitDueDate, TurnTime, Consigned, JobComments) values(@JobWOR, @Lot, @Customer, @PartID, @PartDescription, @OrderQuantity, @JobDueDate, @MasterDueDate, @KitDueDate, @TurnTime, @Consigned, @JobComments)", lstNewLotNumber);

                //2. Get LotID from JobWOR
                var tempLotID = connection.Query<DatabaseTables.LotNumbers>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ lstNewLotNumber[0].JobWOR }' AND Lot='{ lstNewLotNumber[0].Lot }'").ToList();

                //Update the LotStatus and LotPurchasingStatus with tempLotID
                lstNewLotStatus[0].LotID = tempLotID[0].LotID;
                lstNewLotPurchasingStatus[0].LotID = tempLotID[0].LotID;
            
                //3. Enter LotStatus
                connection.Execute($"insert into LotStatus(LotID, QuoteReviewRequest, QuoteReviewInProgress, QuoteReviewComplete, MasterRequest, MasterInProgress, MasterComplete, MasterReviewRequest, MasterReviewInProgress, MasterReviewComplete, WORLotReleased, TravelerReleased, TravelerReturned, JobInProgress, JobComplete, SuperHot, JobStatus) values(@LotID, @QuoteReviewRequest, @QuoteReviewInProgress, @QuoteReviewComplete, @MasterRequest, @MasterInProgress, @MasterComplete, @MasterReviewRequest, @MasterReviewInProgress, @MasterReviewComplete, @WORLotReleased, @TravelerReleased, @TravelerReturned, @JobInProgress, @JobComplete, @SuperHot, @JobStatus)", lstNewLotStatus);

                //4. Get LotStatusID from LotID
                var tempLotStatusID = connection.Query<DatabaseTables.LotStatus>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ lstNewLotStatus[0].LotID }'").ToList();

                //Update the LotTimeTracking with LotStatusID
                lstNewLotTimeTracking[0].LotStatusID = tempLotStatusID[0].LotStatusID;

                //5. Enter LotTimeTracking
                connection.Execute($"insert into LotTimeTracking(LotStatusID, QuoteReviewStart, QuoteReviewEnd, MasterStart, MasterEnd, MasterReviewStart, MasterReviewEnd, WORReleaseStart, WORReleaseEnd, TravelerStart, TravelerEnd, JobStart, JobEnd) values(@LotStatusID, @QuoteReviewStart, @QuoteReviewEnd, @MasterStart, @MasterEnd, @MasterReviewStart, @MasterReviewEnd, @WORReleaseStart, @WORReleaseEnd, @TravelerStart, @TravelerEnd, @JobStart, @JobEnd)", lstNewLotTimeTracking);

                //6. Enter LotPurchasingStatus
                connection.Execute($"insert into LotPurchasingStatus(LotID, StencilsRequired, StencilsOrdered, StencilsReceived, StencilPlotsApproved, PCBRequired, PCBOrdered, PCBReceived, PCBArraysApproved, PartsRequired, PartsOrdered, PartsReceived, KitReleased) values(@LotID, @StencilsRequired, @StencilsOrdered, @StencilsReceived, @StencilPlotsApproved, @PCBRequired, @PCBOrdered, @PCBReceived, @PCBArraysApproved, @PartsRequired, @PartsOrdered, @PartsReceived, @KitReleased)", lstNewLotPurchasingStatus);

                //7. Get LotPurchasingStatusID from LotID
                var tempLotPurchasingStatusID = connection.Query<DatabaseTables.LotPurchasingStatus>($"SELECT PurchasingStatusID FROM LotPurchasingStatus WHERE LotID='{ lstNewLotPurchasingStatus[0].LotID }'").ToList();

                //Update the LotPurchasingStatusID with tempLotPurchasingStatusID
                lstNewPurchasingTimeTracking[0].PurchasingStatusID = tempLotPurchasingStatusID[0].PurchasingStatusID;

                //8.Enter PurchasingTimeTracking
                connection.Execute($"insert into PurchasingTimeTracking(PurchasingStatusID, StencilOrderDate, StencilReceivedDate, PCBOrderDate, PCBReceivedDate, PartsOrderDate, PartsReceivedDate) values(@PurchasingStatusID, @StencilOrderDate, @StencilReceivedDate, @PCBOrderDate, @PCBReceivedDate, @PartsOrderDate, @PartsReceivedDate)", lstNewPurchasingTimeTracking);

                //All Done!

            }
        }

        //Insert Data---------------------------------------------------------------------------------------------------------------

        public void requestPreBidReview(string QuoteWOR)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Set PreBidRequest to True, PreBidInProgress and PreBidComplete to False
                connection.Execute($"UPDATE QuoteStatus SET PreBidRequest='True', PreBidInProgress='False', PreBidComplete='False' WHERE QuoteWOR='{ QuoteWOR }'");
            }
        }

        public void requestBOMValidation(string QuoteWOR)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Set BOMValidationRequest to True, BOMValidationInProgress and BOMValidationComplete to False
                connection.Execute($"UPDATE QuoteStatus SET BOMValidationRequest='True', BOMValidationInProgress='False', BOMValidationComplete='False' WHERE QuoteWOR='{ QuoteWOR }'");
            }
        }

        public void requestPartsReview(string QuoteWOR)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Set PartsReviewRequest to True, PartsReviewInProgress and PartsReviewComplete to False
                connection.Execute($"UPDATE QuoteStatus SET PartsReviewRequest='True', PartsReviewInProgress='False', PartsReviewComplete='False' WHERE QuoteWOR='{ QuoteWOR }'");
            }
        }

        public void deActivateQuote(string QuoteWOR)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //Set QuoteInactive to True
                connection.Execute($"UPDATE ActiveQuotes SET QuoteInactive='True' WHERE QuoteWOR='{ QuoteWOR }'");
            }
        }




    }
}
