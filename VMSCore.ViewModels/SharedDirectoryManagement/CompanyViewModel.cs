using System;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class CompanyViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string CompanyTax { get; set; }
        public string CompanyCodeNameEn { get; set; }
    }
}
