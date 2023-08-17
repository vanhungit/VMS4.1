namespace VMSCore.ViewModels.SystemConfiguration
{
    public class ObjectButtonPermissionViewModel
    {
        public string FunctionGroupModuleObjectMappingId { get; set; }
        public string ObjectId { get; set; }
        public string ButtonId { get; set; }
        public string ParentId { get; set; }
        public string FunctionGroupModuleObjectMappingDescription { get; set; }
        public int Level { get; set; }
        public int OrderId { get; set; }
        public string Owner { get; set; }
        public bool? FunctionGroupModuleObjectMappingActive { get; set; }
        public string ModuleType { get; set; }
        public string GroupType { get; set; }
        public string ObjectName { get; set; }
        public string ObjectNameEn { get; set; }
        public string ObjectEntityDescription { get; set; }
        public bool? ObjectEntityActive { get; set; }
        public string ButtonName { get; set; }
        public string ButtonNameEn { get; set; }
        public string ButtonDescription { get; set; }
        public bool? ButtonActive { get; set; }
    }
}
