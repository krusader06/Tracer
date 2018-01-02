using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class WorkOrders
    {
        public int JobWOR { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public int WorkOrderComplete { get; set; }
    }
}
