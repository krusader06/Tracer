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
        public List<DatabaseTables.Dashboard> LoadDashboard()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {//Grab all active/high-confidence quotes
                return connection.Query<DatabaseTables.Dashboard>(

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
                    $"ActiveQuotes.POReceived = 'False' AND ActiveQuotes.QuoteInactive = 'False' " +

                    $"UNION " +

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
                    $"WHERE LotStatus.JobComplete = 'False'"

                    ).ToList();




            }
        }
    }
}
