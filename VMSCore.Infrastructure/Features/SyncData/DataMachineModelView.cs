using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class DataMachineModelView
    {
        public string code { get; set; }
        public string deviceGroupName { get; set; }
        public string statusType { get; set; }
        public string deviceCode { get; set; }
        public string typeDeviceCode { get; set; }
        public string deviceGroupCode { get; set; }
        public string productionOrderCode { get; set; }
        public string productCode { get; set; }
        public string lineCode { get; set; }
        public string data { get; set; }
        public int quantity { get; set; }
        public string quantityHex { get; set; }
        public string binaryHex { get; set; }
        public int sorted { get; set; }
        public string description { get; set; }
        public string creatorId { get; set; }
        public Nullable<System.DateTime> creationTime { get; set; }
        public string lastModifierId { get; set; }
        public Nullable<System.DateTime> lastModificationTime { get; set; }
        public Nullable<bool> active { get; set; }
    }
}
