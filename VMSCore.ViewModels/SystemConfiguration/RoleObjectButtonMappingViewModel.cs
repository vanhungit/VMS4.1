using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class RoleObjectButtonMappingViewModel
    {
        public string ObjectCode { get; set; }
        public string ButtonCode { get; set; }
        public string RoleCode { get; set; }
        public string ObjectName { get; set; }
        public string ButtonName { get; set; }
        public bool InUse { get; set; }

    }
}
