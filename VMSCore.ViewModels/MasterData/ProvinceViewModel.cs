using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VMSCore.ViewModels.MasterData
{
    public class ProvinceViewModel
    {
        public System.Guid ProvinceId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Province_ProvinceCode")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        [Remote("CheckExistingProvinceCode", "Province", AdditionalFields = "ProvinceCodeValid", HttpMethod = "POST", ErrorMessageResourceName = "Validation_Already_Exists", ErrorMessageResourceType = typeof(Resources.LanguageResource))]
        public string ProvinceCode { get; set; }

        public string ProvinceCodeValid { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Province_ProvinceName")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        public string ProvinceName { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Province_Area")]
        public int? Area { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "OrderIndex")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Validation_OrderIndex")]
        public Nullable<int> OrderIndex { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Actived")]
        public Nullable<bool> Actived { get; set; }
    }
}
