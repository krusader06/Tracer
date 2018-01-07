using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class PurchasingDashboard
    {
        public string QuoteOrWOR { get; set; }
        public string WOR { get; set; }
        public int Lot { get; set; }
        public string PartID { get; set; }
        public string Customer { get; set; }

        //Parts Review
        public string PartsReviewRequest { get; set; }
        public string PartsReviewInProgress { get; set; }
        public string PartsReviewComplete { get; set; }
        public string PartsReviewStatus { get; set; }

        //Stencils
        public string StencilsRequired { get; set; }
        public string StencilsOrdered { get; set; }
        public string StencilsReceived { get; set; }
        public string StencilStatus { get; set; }
        public string StencilPlotsApproved { get; set; }

        //PCB
        public string PCBRequired { get; set; }
        public string PCBOrdered { get; set; }
        public string PCBReceived { get; set; }
        public string PCBStatus { get; set; }
        public string PCBArraysApproved { get; set; }

        //Parts
        public string PartsRequired { get; set; }
        public string PartsOrdered { get; set; }
        public string PartsReceived { get; set; }
        public string PartsStatus { get; set; }

        //Other
        public string KitReleased { get; set; }

    }
}
