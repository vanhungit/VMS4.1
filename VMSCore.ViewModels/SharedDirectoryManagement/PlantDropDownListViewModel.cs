using System;

namespace VMSCore.ViewModels.SharedDirectoryManagement
{
    public class PlantDropDownListViewModel
    {
        public string PlantCode { get; set; }
        public string PlantName { get; set; }
        public Guid PlantId { get; set; }
        public string PlantDropDownListText
        {
            get { return string.Concat(PlantCode, " - ", PlantName); }
        }
    }
}
