using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.ViewModels.SystemConfiguration
{
    public class PlantSiteMappingViewModel
    {
        public string SiteName { get; set; }
        public Guid SiteId { get; set; }
        public decimal SitePrice { get; set; }
        public string SiteCode { get; set; }
        public string CustomerCode { get; set; }
        public bool Assigned { get; set; }
    }
}
