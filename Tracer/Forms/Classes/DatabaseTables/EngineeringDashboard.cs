using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class EngineeringDashboard
    {
        public string QuoteOrWOR { get; set; }
        public string WOR { get; set; }
        public int Lot { get; set; }
        public string PartID { get; set; }
        public string Customer { get; set; }

        //BOM Validation
        public string BOMValidationRequest { get; set; }
        public string BOMValidationInProgress { get; set; }
        public string BOMValidationComplete { get; set; }
        public string BOMValidationStatus { get; set; }

        //PreBid
        public string PreBidRequest { get; set; }
        public string PreBidInProgress { get; set; }
        public string PreBidComplete { get; set; }
        public string PreBidStatus { get; set; }

        //Quote Review
        public string QuoteReviewRequest { get; set; }
        public string QuoteReviewInProgress { get; set; }
        public string QuoteReviewComplete { get; set; }
        public string QuoteReviewStatus { get; set; }

        //Master
        public string MasterRequest { get; set; }
        public string MasterInProgress { get; set; }
        public string MasterComplete { get; set; }
        public string MasterStatus { get; set; }

        //Master Review
        public string MasterReviewRequest { get; set; }
        public string MasterReviewInProgress { get; set; }
        public string MasterReviewComplete { get; set; }
        public string MasterReviewStatus { get; set; }

        //Others
        public string WORLotReleased { get; set; }
        public string TravelerReleased { get; set; }
        public string StencilPlotsApproved { get; set; }
        public string PCBArraysApproved { get; set; }
        public string KitReleased { get; set; }
    }
}
