using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class PurchasingTimeTracking
    {
        public int PurchasingTimeTrackingID { get; set; }
        public int PurchasingStatusID { get; set; }
        public string StencilOrderDate { get; set; }
        public string StencilPlotsApprovedDate { get; set; }
        public string StencilReceivedDate { get; set; }
        public string PCBOrderDate { get; set; }
        public string PCBArraysApprovedDate { get; set; }
        public string PCBReceivedDate { get; set; }
        public string PartsOrderDate { get; set; }
        public string PartsReceivedDate { get; set; }

    }
}
