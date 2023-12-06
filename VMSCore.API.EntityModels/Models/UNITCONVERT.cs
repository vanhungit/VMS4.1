﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.API.EntityModels.Models
{
    public partial class UNITCONVERT
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string UnitCode { get; set; }
        public Nullable<decimal> UnitConvertValue { get; set; }
        public string UnitChildCode { get; set; }
        public Nullable<int> LevelPackage { get; set; }
        public string? Description { get; set; }
        public string? LastModifierId { get; set; }
        public string? CreatorId { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModicationTime { get; set; }
    }
}
