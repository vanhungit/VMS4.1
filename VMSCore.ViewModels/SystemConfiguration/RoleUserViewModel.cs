using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class RoleUserViewModel
    {
        public string Code { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string StaffName { get; set; }
        public bool Active { get; set; }
    }
}
