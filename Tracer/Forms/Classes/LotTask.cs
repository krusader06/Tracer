using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes
{
    public class LotTask
    {
        public int JobWOR { get; set; }
        public int Lot { get; set; }
        public string PartID { get; set; }
        public string JobStatus { get; set; }
        public string Owner { get; set; }
    }
}
