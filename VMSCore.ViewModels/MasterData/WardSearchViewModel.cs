using System;

namespace VMSCore.ViewModels.MasterData
{
    public class WardSearchViewModel
    {
        public string WardName { get; set; }
        public Guid? DistrictCode { get; set; }
        public Guid? ProvinceCode { get; set; }
        public bool? Actived { get; set; }
    }
}
