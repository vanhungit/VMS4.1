using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.API.EntityModels.Models
{
    public class ProductionOrderDetailMAP
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string KeyBox { get; set; }
        public string KeyCuon { get; set; }
        public Nullable<int> LevelBox { get; set; }
        public Nullable<int> LevelCuon { get; set; }
        public string ProductionOrderCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string LOT { get; set; }
        public string UnitCode { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string KeyDate { get; set; }
        public string KeyTime { get; set; }
        public string Description { get; set; }
        public Nullable<long> Sorted { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}
