using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Tracer.Forms.Classes.DataAccess
{
    public class EngineeringDataAccess
    {
        //Generic Queries--------------------------------------------------------------------------------------------------------------
        public List<DatabaseTables.ActiveQuotes> LoadProcessDashboard()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {//Grab all active/high-confidence quotes
                var result = connection.Query<DatabaseTables.ActiveQuotes>($"select * from ActiveQuotes where QuoteConfidence='High' AND POReceived='False' AND QuoteInactive='False'").ToList();
                return result;
            }
        }

        //Task Queries-----------------------------------------------------------------------------------------------------------------

        public List<Classes.LotTask> GetEngineeringTaskList()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {   //Responsible for returning all 4 Engineerings Taks types and compiling them under a lotTask list
                return connection.Query<Classes.LotTask>($"SELECT ActiveQuotes.QuoteWOR AS JobWOR" +
                    $", Lot='0', ActiveQuotes.PartID, QuoteStatus.QuoteCurrentStatus AS JobStatus " +
                    $"FROM ActiveQuotes INNER JOIN QuoteStatus " +
                    $"ON ActiveQuotes.QuoteWOR = QuoteStatus.QuoteWOR " +
                    $"WHERE QuoteStatus.BOMValidationRequest='True' " +
                    $"OR QuoteStatus.PreBidRequest='True' " +
                    $"UNION " +
                    $"SELECT LotNumbers.JobWOR, LotNumbers.Lot, LotNumbers.PartID, LotStatus.JobStatus " +
                    $"FROM LotNumbers INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +
                    $"WHERE LotStatus.QuoteReviewRequest = 'True' OR LotStatus.MasterRequest = 'True'").ToList();
            }
        }

        //BOM Validation Tasks----------------------------------------------------------------------

        public void UpdateBOMValidationInProgress(LotTask currentTask)
        {

            //Set BomValidationInProgress Flag within QuoteStatus
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Update BOMValidationInProgress where QuoteWOR = workorder from currentTask
                connection.Execute($"UPDATE QuoteStatus SET BOMValidationInProgress='True' WHERE QuoteWOR='{ currentTask.JobWOR }'");
            }
        }

        public void UpdateBOMValidationComplete(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Change BOMValidationRequest, BOMValidationInProgress flags to "False", and BOMValidationComplete flag to "True" where QuoteWOR = currentTask.JobWOR
                connection.Execute($"UPDATE QuoteStatus SET BOMValidationInProgress='False', BOMValidationRequest='False', BOMValidationComplete='True' WHERE QuoteWOR='{ currentTask.JobWOR }'");

                //TIME-TRACKING PLACE-HOLDER FOR NOW


                //DateTime rightNow = new DateTime();
                //rightNow = DateTime.Now;

                //3. update MasterReviewEnd(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                //connection.Execute($"UPDATE LotTimeTracking SET MasterReviewEnd='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

        //Master Tasks-------------------------------------------------------------------------------

        internal void UpdateMasterInProgress(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = currentTask.JobWOR and Lot = currentTask.Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change MasterInProgress flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET MasterInProgress='True' WHERE LotID='{ LotID[0] }'");

                //3. Get LotStatusID from LotStatus where LotID = returned LotID from previous Call
                var LotStatusID = connection.Query<string>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update MasterStart(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                connection.Execute($"UPDATE LotTimeTracking SET MasterStart='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

        internal void UpdateMasterComplete(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {

                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change MasterRequest, MasterInProgress flags to "False", and MasterReviewComplete flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET MasterInProgress='False', MasterRequest='False', MasterComplete='True' WHERE LotID='{ LotID[0] }'");

                //3. Get LotStatusID from LotStatus where LotID = returned LotID from previous Call
                var LotStatusID = connection.Query<string>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update MasterEnd(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                connection.Execute($"UPDATE LotTimeTracking SET MasterEnd='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }


        //Quote Review Tasks-------------------------------------------------------------------------------

        internal void UpdateQuoteReviewInProgress(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Get LotID from LotNumbers where JobWOR = currentTask.JobWOR and Lot = currentTask.Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change QuoteReviewInProgress flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET QuoteReviewInProgress='True' WHERE LotID='{ LotID[0] }'");

                //3. Get LotStatusID from LotStatus where LotID = returned LotID from previous Call
                var LotStatusID = connection.Query<string>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update QuoteReviewStart(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                connection.Execute($"UPDATE LotTimeTracking SET QuoteReviewStart='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

        internal void UpdateQuoteReviewComplete(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {

                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change QuoteReviewRequest, QuoteReviewInProgress flags to "False", and QuoteReviewComplete flag to "True" where LotID = returned LotID from previous Call
                connection.Execute($"UPDATE LotStatus SET QuoteReviewInProgress='False', QuoteReviewRequest='False', QuoteReviewComplete='True' WHERE LotID='{ LotID[0] }'");

                //3. Get LotStatusID from LotStatus where LotID = returned LotID from previous Call
                var LotStatusID = connection.Query<string>($"SELECT LotStatusID FROM LotStatus WHERE LotID='{ LotID[0] }'").ToList();

                //Get Current DateTime
                DateTime rightNow = new DateTime();
                rightNow = DateTime.Now;

                //4. update QuoteReviewEnd(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                connection.Execute($"UPDATE LotTimeTracking SET QuoteReviewEnd='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

        //Pre-Bid Tasks-------------------------------------------------------------------------------

        internal void UpdatePreBidInProgress(LotTask currentTask)
        {
            //Set PreBidInProgress Flag within QuoteStatus
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Update PreBidInProgress where QuoteWOR = workorder from currentTask
                connection.Execute($"UPDATE QuoteStatus SET PreBidInProgress='True' WHERE QuoteWOR='{ currentTask.JobWOR }'");
            }
        }



        internal void UpdatePreBidComplete(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {
                //1. Change PreBidRequest, PreBidInProgress flags to "False", and PreBidComplete flag to "True" where QuoteWOR = currentTask.JobWOR
                connection.Execute($"UPDATE QuoteStatus SET PreBidInProgress='False', PreBidRequest='False', PreBidComplete='True' WHERE QuoteWOR='{ currentTask.JobWOR }'");

                //TIME-TRACKING PLACE-HOLDER FOR NOW


                //DateTime rightNow = new DateTime();
                //rightNow = DateTime.Now;

                //3. update MasterReviewEnd(time-stamp) in LotTimeTracking where LotStatusID = LotStatusID from previous Call
                //connection.Execute($"UPDATE LotTimeTracking SET MasterReviewEnd='{ rightNow.ToString() }' WHERE LotStatusID='{ LotStatusID[0] }'");
            }
        }

       
    }
}
