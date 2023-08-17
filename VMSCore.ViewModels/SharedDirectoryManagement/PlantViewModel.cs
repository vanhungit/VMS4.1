namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class PlantViewModel
    {

        public string PlantName { get; set; }
        public string PlantNameEn { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTax { get; set; }
        public string CompayInfor
        {
            get { return string.Concat(CompanyName, " - ", CompanyTax); }
        }
        public string PlantCode { get; set; }
        public string PlantId { get; set; }
    }
}
