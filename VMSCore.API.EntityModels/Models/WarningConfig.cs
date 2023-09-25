using System;
using System.Collections.Generic;

namespace VMSCore.API.EntityModels.Models
{
    public partial class WarningConfig
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public string NameShow { get; set; }
        public string CodeHex { get; set; }
        public string CodeBinary { get; set; }
        public Nullable<int> DecimalCode { get; set; }
        public string CodeMap { get; set; }
        public string WarningType { get; set; }
        public string TypeDeviceCode { get; set; }
        public string DeviceGroupCode { get; set; }
        public Nullable<int> Level { get; set; }
        public string LastModifierId { get; set; }
        public string CreatorId { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
    }
}
