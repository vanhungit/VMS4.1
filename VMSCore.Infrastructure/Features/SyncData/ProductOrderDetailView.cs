using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class ProductOrderDetailView
    {
        public string code { get; set; }
        public string ProductionOrderCode { get; set; }
        public string ProductCode { get; set; }
        public string productName { get; set; }
        public string lotNumber { get; set; }
        public string batchNumber { get; set; }
        public int numberTemp { get; set; }
        public string lineId { get; set; }
        public string unitId { get; set; }
        public int quantity { get; set; }
        public string note1 { get; set; }
        public string note2 { get; set; }
        public string note3 { get; set; }
        public string creatorId { get; set; }
        public Nullable<System.DateTime> creationTime { get; set; }
        public string lastModifierId { get; set; }
        public Nullable<System.DateTime> lastModificationTime { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
