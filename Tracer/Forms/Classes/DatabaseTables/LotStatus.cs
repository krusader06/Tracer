using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class LotStatus
    {
        public int LotStatusID { get; set; }
        public int LotID { get; set; }
        public int QuoteReviewRequest { get; set; }
        public int QuoteReviewInProgress { get; set; }
        public int QuoteReviewComplete { get; set; }
        public int MasterRequest { get; set; }
        public int MasterInProgress { get; set; }
        public int MasterComplete { get; set; }
        public int MasterReviewRequest { get; set; }
        public int MasterReviewInProgress { get; set; }
        public int MasterReviewComplete { get; set; }
        public int WORLotReleaseInProgress { get; set; }
        public int WORLotReleaseComplete { get; set; }
        public int TravelerInProgress { get; set; }
        public int TravelerComplete { get; set; }
        public int JobInProgress { get; set; }
        public int JobComplete { get; set; }
        public int SuperHot { get; set; }
        public string JobStatus { get; set; }
    }
}
