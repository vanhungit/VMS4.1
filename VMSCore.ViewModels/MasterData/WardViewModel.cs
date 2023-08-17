using System;

namespace VMSCore.ViewModels.MasterData
{
    public class WardViewModel
    {
        public Guid WardId { get; set; }
        public string WardCode { get; set; }
        public string WardName { get; set; }
        public string Appellation { get; set; }
        public Guid? ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public Guid? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? OrderIndex { get; set; }
    }
}
