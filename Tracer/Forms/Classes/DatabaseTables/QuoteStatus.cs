using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class QuoteStatus
    {
        public int QuoteStatusID { get; set; }
        public int QuoteWOR { get; set; }
        public int BOMValidationRequest { get; set; }
        public int BOMValidationInProgress { get; set; }
        public int BOMValidationComplete { get; set; }
        public int PartsReviewRequest { get; set; }
        public int PartsReviewInProgress { get; set; }
        public int PartsReviewComplete { get; set; }
        public int PreBidRequest { get; set; }
        public int PreBidInProgress { get; set; }
        public int PreBidComplete { get; set; }
        public int FinalReviewRequest { get; set; }
        public int FinalReviewInProgress { get; set; }
        public int FinalReviewComplete { get; set; }
        public int QuoteSent { get; set; }
        public string QuoteCurrentStatus { get; set; }

    }
}
