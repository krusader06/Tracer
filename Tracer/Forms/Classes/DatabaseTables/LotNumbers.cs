using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class LotNumbers
    {
        public int LotID { get; set; }
        public int JobWOR { get; set; }
        public int Lot { get; set; }
        public string Customer { get; set; }
        public string PartID { get; set; }
        public string PartDescription { get; set; }
        public int OrderQuantity { get; set; }
        public string JobDueDate { get; set; }
        public string MasterDueDate { get; set; }
        public string KitDueDate { get; set; }
        public int TurnTime { get; set; }
        public int Consigned { get; set; }
        public int Turnkey { get; set; }
        public string JobComments { get; set; }

    }
}
