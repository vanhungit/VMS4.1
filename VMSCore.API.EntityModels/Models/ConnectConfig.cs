using System;
using System.Collections.Generic;

namespace VMSCore.API.EntityModels.Models
{
    public partial class ConnectConfig
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public string NameShow { get; set; }
        public string CodeMap { get; set; }
        public string LastModifierId { get; set; }
        public string CreatorId { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
    }
}
