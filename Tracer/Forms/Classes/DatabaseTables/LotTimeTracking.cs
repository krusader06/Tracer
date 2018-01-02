using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Forms.Classes.DatabaseTables
{
    public class LotTimeTracking
    {
        public int LotTimeTrackingID { get; set; }
        public int LotStatusID { get; set; }
        public string QuoteReviewStart { get; set; }
        public string QuoteReviewEnd { get; set; }
        public string MasterStart { get; set; }
        public string MasterEnd { get; set; }
        public string MasterReviewStart { get; set; }
        public string MasterReviewEnd { get; set; }
        public string WORReleaseStart { get; set; }
        public string WORReleaseEnd { get; set; }
        public string TravelerStart { get; set; }
        public string TravelerEnd { get; set; }
        public string JobStart { get; set; }
        public string JobEnd { get; set; }

    }
}
