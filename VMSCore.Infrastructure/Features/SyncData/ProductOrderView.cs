using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class ProductOrderView
    {
        public string code { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string lineCode { get; set; }
        public int numberTemp { get; set; }
        public int status { get; set; }
        public string creatorId { get; set; }
        public Nullable<System.DateTime> creationTime { get; set; }
        public string lastModifierId { get; set; }
        public Nullable<System.DateTime> lastModificationTime { get; set; }
        public Nullable<bool> active { get; set; }

    }
}
