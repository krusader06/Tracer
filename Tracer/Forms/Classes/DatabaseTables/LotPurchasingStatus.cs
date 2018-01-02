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
        public int NumStencilsRequired { get; set; }
        public int NumStencilsOrdered { get; set; }
        public int NumStencilsReceived { get; set; }
        public int NumPCBRequired { get; set; }
        public int NumPCBOrdered { get; set; }
        public int NumPCBReceived { get; set; }
        public int PartsOrdered { get; set; }
        public int PartsReceived { get; set; }
        public int KitReleased { get; set; }
    }
}
