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
    
    public partial class Company
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string URLSmall { get; set; }
        public string URLLarge { get; set; }
        public string Description { get; set; }
        public string CreatorId { get; set; }
        public string LastModifierId { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
        public string CompanyTax { get; set; }
        public string CompanyCodeNameEn { get; set; }
    }
}
