namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class WorkShopDropDownListViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DropDownListText
        {
            get { return string.Concat(Name, " - ", Code); }
        }


    }
}
