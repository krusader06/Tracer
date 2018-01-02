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
            {
                var result = connection.Query<DatabaseTables.ActiveQuotes>($"select * from ActiveQuotes where QuoteConfidence='High'").ToList();
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

        public void UpdateBOMValidationInProgress(LotTask currentTask)
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {

                //1. Get LotID from LotNumbers where JobWOR = inputted JobWOR and Lot = inputted Lot
                var LotID = connection.Query<string>($"SELECT LotID FROM LotNumbers WHERE JobWOR='{ currentTask.JobWOR }' AND Lot=' { currentTask.Lot }'").ToList();

                //2. Change MasterInProgress flag to "True" where LotID = returned LotID from previous Call
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

        public void UpdateBOMValidationComplete(LotTask currentTask)
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

        internal void UpdateMasterInProgress(LotTask currentTask)
        {
            throw new NotImplementedException();
        }

        internal void UpdateQuoteReviewInProgress(LotTask currentTask)
        {
            throw new NotImplementedException();
        }

        internal void UpdatePreBidInProgress(LotTask currentTask)
        {
            throw new NotImplementedException();
        }

        

        internal void UpdateQuoteReviewComplete(LotTask currentTask)
        {
            throw new NotImplementedException();
        }

        internal void UpdatePreBidComplete(LotTask currentTask)
        {
            throw new NotImplementedException();
        }

        internal void UpdateMasterComplete(LotTask currentTask)
        {
            throw new NotImplementedException();
        }
    }
}
