using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class StaffPermissionPlantViewModel
    {
        public string CompanyId { get; set; }
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantCode { get; set; }
        public bool IsPlantAssigned { get; set; }
    }
}
