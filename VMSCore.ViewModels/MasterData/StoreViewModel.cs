using System;
using System.ComponentModel.DataAnnotations;

namespace VMSCore.ViewModels.MasterData
{
    public class StoreViewModel
    {
        public System.Guid StoreId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_CompanyId")]
        public Guid CompanyId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_StoreTypeId")]
        public Guid? StoreTypeId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_StoreCode")]
        //[Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        //[Remote("CheckExistingStoreCode", "Store", AdditionalFields = "StoreCodeValid", HttpMethod = "POST", ErrorMessageResourceName = "Validation_Already_Exists", ErrorMessageResourceType = typeof(Resources.LanguageResource))]
        public string StoreCode { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_StoreCode")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        public string SaleOrgCode { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_SaleOrgCode_KetToan")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        public string SaleOrgCode_KetToan { get; set; }

        //[Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_StoreName")]
        [Display(Name = "Cửa hàng")]
        [Required(ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Required")]
        public string StoreName { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Customer_Phone")]
        public string TelProduct { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Customer_Phone2")]
        public string TelService { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_StoreAddress")]
        public string StoreAddress { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "MasterData_Province")]
        public Guid? ProvinceId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "MasterData_District")]
        public Guid? DistrictId { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "OrderIndex")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessageResourceType = typeof(Resources.LanguageResource), ErrorMessageResourceName = "Validation_OrderIndex")]
        public Nullable<int> OrderIndex { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Actived")]
        public Nullable<bool> Actived { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Store_CompanyId")]
        public string CompanyName { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "ImageUrl")]
        public string ImageUrl { get; set; }
        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "Configuration_Logo")]
        public string LogoUrl { get; set; }
        [Display(Name = "Lat")]
        public string mLat { get; set; }
        [Display(Name = "Long")]
        public string mLong { get; set; }

        [Display(ResourceType = typeof(Resources.LanguageResource), Name = "MasterData_Province")]
        public string ProvinceName { get; set; }

        public string Fax { get; set; }
    }
}
