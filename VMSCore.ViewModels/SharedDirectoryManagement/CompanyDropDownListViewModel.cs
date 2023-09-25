using System;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class CompanyDropDownListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyTax { get; set; }
        public string DropDownListText
        {
            get { return string.Concat(Name, " - ", CompanyTax); }
        }
    }
}
