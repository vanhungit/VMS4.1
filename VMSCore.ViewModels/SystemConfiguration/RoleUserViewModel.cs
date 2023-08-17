using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class RoleUserViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsRoleAssigned { get; set; }
    }
}
