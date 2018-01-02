using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class ActiveQuotes
    {
        public int QuoteWOR { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string PartID { get; set; }
        public string Customer { get; set; }
        public string PartDescription { get; set; }
        public string QuoteConfidence { get; set; }
        public string QuoteComments { get; set; }
        public string QuoteDueDate { get; set; }
        public int QuoteInactive { get; set; }
        public int POReceived { get; set; }

    }
}
