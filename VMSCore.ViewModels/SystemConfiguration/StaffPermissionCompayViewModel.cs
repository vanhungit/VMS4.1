using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class StaffPermissionCompayViewModel
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTax { get; set; }
        public bool IsCompanyAssigned { get; set; }
    }
}
