using System;
using System.Collections.Generic;

namespace VMSCore.API.EntityModels.Models
{
    public partial class Device_PROTOCOL
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string? ProtocolParamCode { get; set; }
        public string? Data { get; set; }
        public string? ProtocolCode { get; set; }
        public string? DeviceCode { get; set; }
        public Nullable<int> Sorted { get; set; }
        public string? Description { get; set; }
        public string? CreatorId { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public string? LastModifierId { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
