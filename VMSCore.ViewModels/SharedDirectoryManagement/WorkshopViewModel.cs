using System;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class WorkshopViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CompanyId { get; set; }
        public string Description { get; set; }
        public string WorkShopNameEn { get; set; }
        public string PlantId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTax { get; set; }
        public string PlantName { get; set; }
        public string PlantCode { get; set; }
        public string Companyinfor
        {
            get { return string.Concat(CompanyName, " - ", CompanyTax); }
        }

        public string PlantInfor
        {
            get { return string.Concat(PlantName, " - ", PlantCode); }
        }
        public bool Active { get; set; }

    }


}
