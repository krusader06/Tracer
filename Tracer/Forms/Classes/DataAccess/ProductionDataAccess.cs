using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DataAccess
{
    public class ProductionDataAccess
    {
        public List<Classes.LotTask> GetProductionTaskList()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {   //Responsible for returning all 4 Engineering Task types and compiling them under a lotTask list

                //Crazy SQL Call...
                return connection.Query<Classes.LotTask>(
                    
                    //Get Pre-Bid Review Requests
                    $"SELECT ActiveQuotes.QuoteWOR AS JobWOR " +
                    $", Lot = '0' " +
                    $", ActiveQuotes.PartID " +
                    $", JobStatus = 'Pre-Bid Review Requested' " +
                    $", QuoteDueDate AS DueDate " +
                    $", SuperHot = '0' " +
                    $"FROM ActiveQuotes INNER JOIN QuoteStatus " +
                    $"ON ActiveQuotes.QuoteWOR = QuoteStatus.QuoteWOR " +
                    $"WHERE QuoteStatus.PreBidRequest = 'True' " +
                    $"AND QuoteStatus.PreBidInProgress = 'False' " +
                    $"AND ActiveQuotes.QuoteInactive = 'False' " +
                    $"AND ActiveQuotes.POReceived = 'False' " +

                    $"UNION " +
                    //Get Pre-Bid Review In Progress
                    $"SELECT ActiveQuotes.QuoteWOR AS JobWOR " +
                    $", Lot = '0' " +
                    $", ActiveQuotes.PartID " +
                    $", JobStatus = 'Pre-Bid Review In Progress' " +
                    $", QuoteDueDate AS DueDate " +
                    $", SuperHot = '0' " +
                    $"FROM ActiveQuotes INNER JOIN QuoteStatus " +
                    $"ON ActiveQuotes.QuoteWOR = QuoteStatus.QuoteWOR " +
                    $"WHERE QuoteStatus.PreBidRequest = 'True' " +
                    $"AND QuoteStatus.PreBidInProgress = 'True' " +
                    $"AND ActiveQuotes.QuoteInactive = 'False' " +
                    $"AND ActiveQuotes.POReceived = 'False' " +

                    $"ORDER BY SuperHot DESC, DueDate, JobWOR, Lot").ToList();
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
