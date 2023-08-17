using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class StaffPermissionWorkShopViewModel
    {
        public string WorkShopId { get; set; }
        public string WorkShopCode { get; set; }
        public string WorkShopName { get; set; }
        public string PlantId { get; set; }
        public bool IsWorkShopAssigned { get; set; }
    }
}
