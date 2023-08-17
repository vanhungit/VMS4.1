namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class LineDropListViewModel
    {
        public string LineId { get; set; }
        public string LineName { get; set; }
        public string LineCode { get; set; }
        public string dropdownListText
        {
            get { return string.Concat(LineName, " - ", LineCode); }
        }

    }
}
