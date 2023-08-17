using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class StaffPermissionViewModel
    {
        public List<StaffPermissionCompayViewModel> StaffPermissionCompanies { get; set; }
        public List<StaffPermissionPlantViewModel> StaffPermissionPlants { get; set; }
        public List<StaffPermissionWorkShopViewModel> StaffPermissionWorkShops { get; set; }
        public List<StaffPermissionLineViewModel> StaffPermissionLines { get; set; }
        public List<RoleUserViewModel> StaffRoles { get; set; }
    }
}
