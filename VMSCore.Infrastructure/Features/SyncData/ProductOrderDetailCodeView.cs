using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class ProductOrderDetailCodeView
    {
        public string code { get; set; }
        public string productionOrderCode { get; set; }
        public string code1 { get; set; }
        public string code2 { get; set; }
        public string lineCode { get; set; }
        public int levelPackage { get; set; }
        public string creatorId { get; set; }
        public Nullable<System.DateTime> creationTime { get; set; }
        public string lastModifierId { get; set; }
        public Nullable<System.DateTime> lastModificationTime { get; set; }
        public Nullable<bool> active { get; set; }

    }
}
