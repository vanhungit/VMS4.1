using System;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class LineDropListViewModel
    {
        public Guid LineId { get; set; }
        public string LineName { get; set; }
        public string LineCode { get; set; }
        public string dropdownListText
        {
            get { return string.Concat(LineName, " - ", LineCode); }
        }

    }
}
