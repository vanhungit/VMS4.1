using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class BomProductView
    {
        public System.Guid Id { get; set; }
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public string LastModifierId { get; set; }
        public string CreatorId { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> LogDate { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastModificationTime { get; set; }
    }
}
