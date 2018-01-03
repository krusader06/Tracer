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
