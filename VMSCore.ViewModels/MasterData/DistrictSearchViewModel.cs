using System;

namespace VMSCore.ViewModels.MasterData
{
    public class DistrictSearchViewModel
    {
        public Guid? ProvinceId { get; set; }
        public string DistrictName { get; set; }
        public bool? Actived { get; set; }
    }
}
