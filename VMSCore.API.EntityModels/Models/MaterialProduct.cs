﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VMSCore.API.EntityModels.Models
{
    public partial class MaterialProduct
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string MaterialCode { get; set; }
        public string LastModifierId { get; set; }
        public string CreatorId { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
    }
}