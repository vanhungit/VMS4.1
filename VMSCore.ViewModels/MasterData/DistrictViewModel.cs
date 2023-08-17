using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VMSCore.ViewModels.MasterData
{
    public class DistrictViewModel
    {
        public System.Guid DistrictId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "MasterData_Province")]
        public Guid ProvinceId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "District_DistrictCode")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        [Remote("CheckExistingDistrictCode", "District", AdditionalFields = "DistrictCodeValid, ProvinceId", HttpMethod = "POST", ErrorMessageResourceName = "Validation_Already_Exists", ErrorMessageResourceType = typeof(Resources.LanguageResource))]
        public string DistrictCode { get; set; }

        public string DistrictCodeValid { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "District_Appellation")]
        public string Appellation { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "District_DistrictName")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        public string DistrictName { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "OrderIndex")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Validation_OrderIndex")]
        public Nullable<int> OrderIndex { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Actived")]
        public Nullable<bool> Actived { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "MasterData_Province")]
        public string ProvinceName { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "RegisterVAT")]
        public Nullable<decimal> RegisterVAT { get; set; }
    }
}
