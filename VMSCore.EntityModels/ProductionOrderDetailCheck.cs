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
    
    public partial class ProductionOrderDetailCheck
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string ProductionOrderCode { get; set; }
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string ToDate { get; set; }
        public Nullable<int> LevelPackage { get; set; }
        public string LineCode { get; set; }
        public string GroupDeviceCode { get; set; }
        public string TypeDeviceCode { get; set; }
        public string DeviceCode { get; set; }
        public string DeviceHandeCode { get; set; }
        public string DeviceCheck { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> PrintCount { get; set; }
        public Nullable<long> Sorted { get; set; }
        public string LastModifierId { get; set; }
        public string CreatorId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
    }
}
