//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VMSCore.EntityModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class MACHINE_SYNC
    {
        public System.Guid KeyId { get; set; }
        public string Code { get; set; }
        public string DeviceGroupName { get; set; }
        public string StatusType { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceName { get; set; }
        public string TypeDeviceCode { get; set; }
        public string DeviceGroupCode { get; set; }
        public string ProductOrderCode { get; set; }
        public string ProductCode { get; set; }
        public string LineCode { get; set; }
        public Nullable<decimal> UnderData { get; set; }
        public Nullable<decimal> OverData { get; set; }
        public Nullable<decimal> ReferData { get; set; }
        public string StatusWT { get; set; }
        public string Data { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string QuantityHex { get; set; }
        public string BinaryHex { get; set; }
        public Nullable<long> SortedRecord { get; set; }
        public Nullable<long> Sorted { get; set; }
        public Nullable<bool> StatusSync { get; set; }
        public string Description { get; set; }
        public string LastModifierId { get; set; }
        public string CreatorId { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
    }
}
