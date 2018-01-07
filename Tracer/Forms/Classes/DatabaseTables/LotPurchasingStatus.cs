using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class LotPurchasingStatus
    {
        public int PurchasingStatusID { get; set; }
        public int LotID { get; set; }

        public int StencilsRequired { get; set; }
        public int StencilsOrdered { get; set; }
        public int StencilsReceived { get; set; }
        public int StencilPlotsApproved { get; set; }

        public int PCBRequired { get; set; }
        public int PCBOrdered { get; set; }
        public int PCBReceived { get; set; }
        public int PCBArraysApproved { get; set; }

        public int PartsRequired { get; set; }
        public int PartsOrdered { get; set; }
        public int PartsReceived { get; set; }

        public int KitReleased { get; set; }
    }
}
