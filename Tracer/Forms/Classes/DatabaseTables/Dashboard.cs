using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class Dashboard
    {
        //Quote/Job Details
        public string QuoteOrWOR { get; set; }
        public string WOR { get; set; }
        public string Lot { get; set; }
        public string PartID { get; set; }
        public string Customer { get; set; }
        public string PartDescription { get; set; }
        public string QuoteConfidence { get; set; }
        public string OrderQuantity { get; set; }
        public string TurnTime { get; set; }
        public string Consigned { get; set; }
        public string Turnkey { get; set; }

        //BOMValidationStatus
        public string BOMValidationRequest { get; set; }
        public string BOMValidationInProgress { get; set; }
        public string BOMValidationComplete { get; set; }
        public string BOMValidationStatus { get; set; }

        //PartsReviewStatus
        public string PartsReviewRequest { get; set; }
        public string PartsReviewInProgress { get; set; }
        public string PartsReviewComplete { get; set; }
        public string PartsReviewStatus { get; set; }

        //PreBidStatus
        public string PreBidRequest { get; set; }
        public string PreBidInProgress { get; set; }
        public string PreBidComplete { get; set; }
        public string PreBidStatus { get; set; }

        //FianlReviewStatus
        public string FinalReviewRequest { get; set; }
        public string FinalReviewInProgress { get; set; }
        public string FinalReviewComplete { get; set; }
        public string FinalReviewStatus { get; set; }

        //QuoteStatus
        public string QuoteDueDate { get; set; }
        public string QuoteSent { get; set; }

        //QuoteReviewStatus
        public string QuoteReviewRequest { get; set; }
        public string QuoteReviewInProgress { get; set; }
        public string QuoteReviewComplete { get; set; }
        public string QuoteReviewStatus { get; set; }

        //MasterStatus
        public string MasterRequest { get; set; }
        public string MasterInProgress { get; set; }
        public string MasterComplete { get; set; }
        public string MasterStatus { get; set; }
        public string MasterDueDate { get; set; }

        //MasterReviewStatus
        public string MasterReviewRequest { get; set; }
        public string MasterReviewInProgress { get; set; }
        public string MasterReviewComplete { get; set; }
        public string MasterReviewStatus { get; set; }

        //WOR Lot Status
        public string WORLotReleased { get; set; }

        //Traveler Status
        public string TravelerReleased { get; set; }
        public string TravelerReturned { get; set; }
        public string TravelerStatus { get; set; }

        //Kit Status
        public string KitReleased { get; set; }
        public string KitDueDate { get; set; }

        //Job Due Date
        public string JobDueDate { get; set; }

        //Super Hot
        public string SuperHot { get; set; }

        //PCB Status
        public string PCBRequired { get; set; }
        public string PCBOrdered { get; set; }
        public string PCBReceived { get; set; }
        public string PCBStatus { get; set; }
        public string PCBArraysApproved { get; set; }

        //Stencil Status
        public string StencilsRequired { get; set; }
        public string StencilsOrdered { get; set; }
        public string StencilsReceived { get; set; }
        public string StencilStatus { get; set; }
        public string StencilPlotsApproved { get; set; }

        //Parts Status
        public string PartsRequired { get; set; }
        public string PartsOrdered { get; set; }
        public string PartsReceived { get; set; }
        public string PartsStatus { get; set; }

        //Comment
        public string Comments { get; set; }
    }
}
