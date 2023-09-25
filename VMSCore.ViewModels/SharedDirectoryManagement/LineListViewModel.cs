using System;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class LineListViewModel
    {
        public Guid LineId { get; set; }
        public string LineName { get; set; }
        public string LineCode { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string PlantId { get; set; }
        public string PlantName { get; set; }
        public string WorkShopId { get; set; }
        public string WorkShopName { get; set; }

    }
}
