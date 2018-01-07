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
        public List<DatabaseTables.PurchasingDashboard> LoadPurchasingDashboard()
        {
            using (System.Data.IDbConnection connection = new System.Data.SqlClient.SqlConnection(Classes.Helper.CnnVal("TracerDB")))
            {//Grab all active/high-confidence quotes
                return connection.Query<DatabaseTables.PurchasingDashboard>(
                    $"SELECT 'QuoteOrWOR' = 'Quote' " +
                    $", ActiveQuotes.QuoteWOR AS WOR " +
                    $", Lot = '' " +
                    $", ActiveQuotes.PartID " +
                    $", ActiveQuotes.Customer " +

                    $", QuoteStatus.PartsReviewRequest " +
                    $", QuoteStatus.PartsReviewInProgress " +
                    $", QuoteStatus.PartsReviewComplete " +

                    $", StencilsRequired = '' " +
                    $", StencilsOrdered = '' " +
                    $", StencilsReceived = '' " +
                    $", StencilPlotsApproved = '' " +

                    $", PCBRequired = '' " +
                    $", PCBOrdered = '' " +
                    $", PCBReceived = '' " +
                    $", PCBArraysApproved = '' " +

                    $", PartsRequired = '' " +
                    $", PartsOrdered = '' " +
                    $", PartsReceived = '' " +

                    $", KitReleased = '' " +
                    $"FROM ActiveQuotes " +
                    $"INNER JOIN QuoteStatus " +
                    $"ON ActiveQuotes.QuoteWOR = QuoteStatus.QuoteWOR " +
                    $"WHERE " +
                    $"ActiveQuotes.POReceived = 'False' AND ActiveQuotes.QuoteInactive = 'False' " +

                    $"UNION " +

                    $"SELECT 'QuoteOrWOR' = 'WOR' " +
                    $", LotNumbers.JobWOR AS WOR " +
                    $", LotNumbers.Lot " +
                    $", LotNumbers.PartID " +
                    $", LotNumbers.Customer " +

                    $", QuoteStatus.PartsReviewRequest " +
                    $", QuoteStatus.PartsReviewInProgress " +
                    $", QuoteStatus.PartsReviewComplete " +

                    $", LotPurchasingStatus.StencilsRequired " +
                    $", LotPurchasingStatus.StencilsOrdered " +
                    $", LotPurchasingStatus.StencilsReceived " +
                    $", LotPurchasingStatus.StencilPlotsApproved " +

                    $", LotPurchasingStatus.PCBRequired " +
                    $", LotPurchasingStatus.PCBOrdered " +
                    $", LotPurchasingStatus.PCBReceived " +
                    $", LotPurchasingStatus.PCBArraysApproved " +

                    $", LotPurchasingStatus.PartsRequired " +
                    $", LotPurchasingStatus.PartsOrdered " +
                    $", LotPurchasingStatus.PartsReceived " +

                    $", LotPurchasingStatus.KitReleased " +

                    $"FROM LotNumbers " +

                    $"INNER JOIN QuoteStatus " +
                    $"ON LotNumbers.JobWOR = QuoteStatus.QuoteWOR " +
                    $"INNER JOIN LotPurchasingStatus " +
                    $"ON LotNumbers.LotID = LotPurchasingStatus.LotID " +
                    $"INNER JOIN LotStatus " +
                    $"ON LotNumbers.LotID = LotStatus.LotID " +

                    $"WHERE LotStatus.JobComplete = 'False'").ToList();

            }
        }
    }
}
