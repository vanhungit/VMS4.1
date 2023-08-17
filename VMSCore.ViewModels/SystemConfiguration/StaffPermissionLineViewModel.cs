using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class StaffPermissionLineViewModel
    {
        public string LineId { get; set; }
        public string LineCode { get; set; }
        public string LineName { get; set; }
        public string WorkshopId { get; set; }
        public bool IsLineAssigned { get; set; }
    }
}
