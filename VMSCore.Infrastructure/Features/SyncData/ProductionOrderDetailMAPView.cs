using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class ProductionOrderDetailMAPView
    {
        public string code { get; set; }
        public string productionOrderCode { get; set; }
        public string keyBox { get; set; }
        public string keyCuon { get; set; }
        public int levelBox { get; set; }
        public int levelCuon { get; set; }
        public string lot { get; set; }
        public string productCode { get; set; }
        public string unitCode { get; set; }
        public int quantity { get; set; }
        public int sorted { get; set; }
        public string creatorId { get; set; }
        public Nullable<System.DateTime> creationTime { get; set; }
        public string lastModifierId { get; set; }
        public Nullable<System.DateTime> lastModificationTime { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
