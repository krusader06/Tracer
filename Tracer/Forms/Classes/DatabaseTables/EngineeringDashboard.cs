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
        public string BOMValidationComplete { get; set; }
        public string PreBidComplete { get; set; }
        public string QuoteReviewComplete { get; set; }
        public string MasterComplete { get; set; }
        public string MasterReviewComplete { get; set; }
        public string WORLotReleaseComplete { get; set; }
        public string TravelerComplete { get; set; }
        public string StencilPlotsApproved { get; set; }
        public string PCBArraysApproved { get; set; }
        public string KitReleased { get; set; }
    }
}
