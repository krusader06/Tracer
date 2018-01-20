using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DataAccess
{
    public class DashboardDataAccess
    {
        public List<DatabaseTables.Dashboard> LoadDashboard(bool showQuotes, bool showWORs)
        {
            string sqlCall = "";

            if (showQuotes)
            {
                sqlCall =

                    $"SELECT QuoteOrWOR = 'Quote' " +
                    $", ActiveQuotes.QuoteWOR AS WOR " +
                    $", Lot = '0' " +
                    $", ActiveQuotes.PartID " +
                    $", ActiveQuotes.Customer " +
                    $", ActiveQuotes.PartDescription " +
                    $", ActiveQuotes.QuoteConfidence " +
                    $", OrderQuantity = '' " +
                    $", TurnTime = '' " +
                    $", ActiveQuotes.Consigned " +
                    $", ActiveQuotes.Turnkey " +

                    $", QuoteStatus.BOMValidationRequest " +
                    $", QuoteStatus.BOMValidationInProgress " +
                    $", QuoteStatus.BOMValidationComplete " +
                    $", QuoteStatus.PartsReviewRequest " +
                    $", QuoteStatus.PartsReviewInProgress " +
                    $", QuoteStatus.PartsReviewComplete " +
                    $", QuoteStatus.PreBidRequest " +
                    $", QuoteStatus.PreBidInProgress " +
                    $", QuoteStatus.PreBidComplete " +
                    $", QuoteStatus.FinalReviewRequest " +
                    $", QuoteStatus.FinalReviewInProgress " +
                    $", QuoteStatus.FinalReviewComplete " +
                    $", ActiveQuotes.QuoteDueDate " +
                    $", QuoteStatus.QuoteSent " +

                    $", QuoteReviewRequest = '' " +
                    $", QuoteReviewInProgress = '' " +
                    $", QuoteReviewComplete = '' " +
                    $", MasterRequest = '' " +
                    $", MasterInProgress = '' " +
                    $", MasterComplete = '' " +
                    $", MasterDueDate = '' " +
                    $", MasterReviewRequest = '' " +
                    $", MasterReviewInProgress = '' " +
                    $", MasterReviewComplete = '' " +
                    $", WORLotReleased = '' " +
                    $", TravelerReleased = '' " +
                    $", TravelerReturned = '' " +
                    $", KitReleased = '' " +
                    $", KitDueDate = '' " +
                    $", JobDueDate = '' " +
                    $", SuperHot = '' " +

                    $", PCBRequired = '' " +
                    $", PCBOrdered = '' " +
                    $", PCBReceived = '' " +
                    $", PCBArraysApproved = '' " +
                    $", StencilsRequired = '' " +
                    $", StencilsOrdered = '' " +
                    $", StencilsReceived = '' " +
                    $", StencilPlotsApproved = '' " +
                    $", PartsRequired = '' " +
                    $", PartsOrdered = '' " +
                    $", PartsReceived = '' " +
                    $", ActiveQuotes.QuoteComments AS Comments " +

                    $"FROM ActiveQuotes " +
                    $"INNER JOIN QuoteStatus " +
                    $"ON QuoteStatus.QuoteWOR = ActiveQuotes.QuoteWOR " +
                    $"WHERE " +
                    $"ActiveQuotes.POReceived = 'False' AND ActiveQuotes.QuoteInactive = 'False' ";
            }
                
            if (showWORs)
            {
                if (showQuotes)
                {
                    sqlCall += $"UNION ";
                }

                sqlCall +=

                    $"SELECT QuoteOrWOR = 'WOR' " +
                    $", LotNumbers.JobWOR AS WOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", LotNumbers.Customer " +
                    $", LotNumbers.PartDescription " +
                    $", ActiveQuotes.QuoteConfidence " +
                    $", LotNumbers.OrderQuantity " +
                    $", LotNumbers.TurnTime " +
                    $", LotNumbers.Consigned " +
                    $", LotNumbers.Turnkey " +

                    $", QuoteStatus.BOMValidationRequest " +
                    $", QuoteStatus.BOMValidationInProgress " +
                    $", QuoteStatus.BOMValidationComplete " +
                    $", QuoteStatus.PartsReviewRequest " +
                    $", QuoteStatus.PartsReviewInProgress " +
                    $", QuoteStatus.PartsReviewComplete " +
                    $", QuoteStatus.PreBidRequest " +
                    $", QuoteStatus.PreBidInProgress " +
                    $", QuoteStatus.PreBidComplete " +
                    $", QuoteStatus.FinalReviewRequest " +
                    $", QuoteStatus.FinalReviewInProgress " +
                    $", QuoteStatus.FinalReviewComplete " +
                    $", ActiveQuotes.QuoteDueDate " +
                    $", QuoteStatus.QuoteSent " +

                    $", LotStatus.QuoteReviewRequest " +
                    $", LotStatus.QuoteReviewInProgress " +
                    $", LotStatus.QuoteReviewComplete " +
                    $", LotStatus.MasterRequest " +
                    $", LotStatus.MasterInProgress " +
                    $", LotStatus.MasterComplete " +
                    $", LotNumbers.MasterDueDate " +
                    $", LotStatus.MasterReviewRequest " +
                    $", LotStatus.MasterReviewInProgress " +
                    $", LotStatus.MasterReviewComplete " +
                    $", LotStatus.WORLotReleased " +
                    $", LotStatus.TravelerReleased " +
                    $", LotStatus.TravelerReturned " +

                    $", LotPurchasingStatus.KitReleased " +
                    $", LotNumbers.KitDueDate " +
                    $", LotNumbers.JobDueDate " +
                    $", LotStatus.SuperHot " +

                    $", LotPurchasingStatus.PCBRequired " +
                    $", LotPurchasingStatus.PCBOrdered " +
                    $", LotPurchasingStatus.PCBReceived " +
                    $", LotPurchasingStatus.PCBArraysApproved " +
                    $", LotPurchasingStatus.StencilsRequired " +
                    $", LotPurchasingStatus.StencilsOrdered " +
                    $", LotPurchasingStatus.StencilsReceived " +
                    $", LotPurchasingStatus.StencilPlotsApproved " +
                    $", LotPurchasingStatus.PartsRequired " +
                    $", LotPurchasingStatus.PartsOrdered " +
                    $", LotPurchasingStatus.PartsReceived " +

                    $", LotNumbers.JobComments AS Comments " +

                    $"FROM LotNumbers " +
                    $"INNER JOIN ActiveQuotes " +
                    $"ON ActiveQuotes.QuoteWOR = LotNumbers.JobWOR " +
                    $"INNER JOIN QuoteStatus " +
                    $"ON QuoteStatus.QuoteWOR = ActiveQuotes.QuoteWOR " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotStatus.LotID = LotNumbers.LotID " +
                    $"INNER JOIN LotPurchasingStatus " +
                    $"ON LotPurchasingStatus.LotID = LotNumbers.LotID " +
                    $"WHERE LotStatus.JobComplete = 'False'";
            }        
            
            if ((showWORs) || (showQuotes))
            {
                using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
                {//Grab all active/high-confidence quotes
                    return connection.Query<DatabaseTables.Dashboard>(sqlCall).ToList();
                }
            }
            else
            {
                List<DatabaseTables.Dashboard> tempList = new List<DatabaseTables.Dashboard>();
                return tempList;
            }
        }

        //Update Comments
        public void UpdateComments(string newComment, string type, string WOR, string Lot)
        {
            //Determines wheter or not this is a Quote or Work Order, then updates the proper table

            if (type == "Quote")
            {
                //Update ActiveQuotes.QuoteComments
                using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
                {
                    connection.Execute($"UPDATE ActiveQuotes SET QuoteComments='{ newComment }' WHERE QuoteWOR='{ WOR }'");
                }
            }
            else
            {
                //Update LotNumbers.JobComments
                using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
                {
                    connection.Execute($"UPDATE LotNumbers SET JobComments='{ newComment }' WHERE JobWOR='{ WOR }' AND Lot='{ Lot }'");
                }
            }
        }
    }
}
