﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VMSCore.EntityModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EntityDataContext : DbContext
    {
        public EntityDataContext()
            : base("name=EntityDataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountGroupMapping> AccountGroupMapping { get; set; }
        public virtual DbSet<Barcode> Barcode { get; set; }
        public virtual DbSet<BarcodeConfig> BarcodeConfig { get; set; }
        public virtual DbSet<BOXDEFINE> BOXDEFINE { get; set; }
        public virtual DbSet<BOXDEFINE_MAP> BOXDEFINE_MAP { get; set; }
        public virtual DbSet<BOXDEFINE_TRANS> BOXDEFINE_TRANS { get; set; }
        public virtual DbSet<Button> Button { get; set; }
        public virtual DbSet<CAMERA_CONNECT> CAMERA_CONNECT { get; set; }
        public virtual DbSet<CAMERA_DATA> CAMERA_DATA { get; set; }
        public virtual DbSet<CAMERA_ERROR> CAMERA_ERROR { get; set; }
        public virtual DbSet<CAMERA_STATUS> CAMERA_STATUS { get; set; }
        public virtual DbSet<CAMERA_WARNING> CAMERA_WARNING { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyModuleMapping> CompanyModuleMapping { get; set; }
        public virtual DbSet<CompanyUserMapping> CompanyUserMapping { get; set; }
        public virtual DbSet<ConnectConfig> ConnectConfig { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<ContractFile> ContractFile { get; set; }
        public virtual DbSet<ContractPermission> ContractPermission { get; set; }
        public virtual DbSet<DataSetting> DataSetting { get; set; }
        public virtual DbSet<DataSettingCompany> DataSettingCompany { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DepartmentStaff> DepartmentStaff { get; set; }
        public virtual DbSet<DETECTOR_CONNECT> DETECTOR_CONNECT { get; set; }
        public virtual DbSet<DETECTOR_DATA> DETECTOR_DATA { get; set; }
        public virtual DbSet<DETECTOR_ERROR> DETECTOR_ERROR { get; set; }
        public virtual DbSet<DETECTOR_STATUS> DETECTOR_STATUS { get; set; }
        public virtual DbSet<DETECTOR_WARNING> DETECTOR_WARNING { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Device_Combo> Device_Combo { get; set; }
        public virtual DbSet<Device_PROTOCOL> Device_PROTOCOL { get; set; }
        public virtual DbSet<DeviceConnectHistory> DeviceConnectHistory { get; set; }
        public virtual DbSet<DeviceGroup> DeviceGroup { get; set; }
        public virtual DbSet<DeviceSession> DeviceSession { get; set; }
        public virtual DbSet<DeviceSessionDetail> DeviceSessionDetail { get; set; }
        public virtual DbSet<DeviceSessionDetail_Weighing> DeviceSessionDetail_Weighing { get; set; }
        public virtual DbSet<DistrictModel> DistrictModel { get; set; }
        public virtual DbSet<ErrorConfig> ErrorConfig { get; set; }
        public virtual DbSet<Factory> Factory { get; set; }
        public virtual DbSet<FunctionGroupModuleObjectMapping> FunctionGroupModuleObjectMapping { get; set; }
        public virtual DbSet<HistoryModel> HistoryModel { get; set; }
        public virtual DbSet<LABELING_RFID_CONNECT> LABELING_RFID_CONNECT { get; set; }
        public virtual DbSet<LABELING_RFID_DATA> LABELING_RFID_DATA { get; set; }
        public virtual DbSet<LABELING_RFID_ERROR> LABELING_RFID_ERROR { get; set; }
        public virtual DbSet<LABELING_RFID_STATUS> LABELING_RFID_STATUS { get; set; }
        public virtual DbSet<LABELING_RFID_WARNING> LABELING_RFID_WARNING { get; set; }
        public virtual DbSet<Line> Line { get; set; }
        public virtual DbSet<LineAccountMapping> LineAccountMapping { get; set; }
        public virtual DbSet<LineDevice> LineDevice { get; set; }
        public virtual DbSet<LineUserMapping> LineUserMapping { get; set; }
        public virtual DbSet<LockAccount> LockAccount { get; set; }
        public virtual DbSet<LockAccountLog> LockAccountLog { get; set; }
        public virtual DbSet<LoginCheck> LoginCheck { get; set; }
        public virtual DbSet<LoginRecord> LoginRecord { get; set; }
        public virtual DbSet<MACHINE_CONNECT> MACHINE_CONNECT { get; set; }
        public virtual DbSet<MACHINE_DATA> MACHINE_DATA { get; set; }
        public virtual DbSet<MACHINE_ERROR> MACHINE_ERROR { get; set; }
        public virtual DbSet<MACHINE_STATUS> MACHINE_STATUS { get; set; }
        public virtual DbSet<MACHINE_SYNC> MACHINE_SYNC { get; set; }
        public virtual DbSet<MACHINE_SYNC_LOG> MACHINE_SYNC_LOG { get; set; }
        public virtual DbSet<MACHINE_WARNING> MACHINE_WARNING { get; set; }
        public virtual DbSet<MACHINECOUNTER> MACHINECOUNTER { get; set; }
        public virtual DbSet<MaterialProduct> MaterialProduct { get; set; }
        public virtual DbSet<NotificationConfig> NotificationConfig { get; set; }
        public virtual DbSet<NotificationContact> NotificationContact { get; set; }
        public virtual DbSet<NotificationLine> NotificationLine { get; set; }
        public virtual DbSet<NotificationSystem> NotificationSystem { get; set; }
        public virtual DbSet<ObjectButtonMapping> ObjectButtonMapping { get; set; }
        public virtual DbSet<ObjectEntity> ObjectEntity { get; set; }
        public virtual DbSet<PALLETDEFINE> PALLETDEFINE { get; set; }
        public virtual DbSet<PALLETDEFINE_MAP> PALLETDEFINE_MAP { get; set; }
        public virtual DbSet<PALLETDEFINE_TRANS> PALLETDEFINE_TRANS { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PlantSiteMapping> PlantSiteMapping { get; set; }
        public virtual DbSet<PlantUserMapping> PlantUserMapping { get; set; }
        public virtual DbSet<PRIMARY_PACKING_CONNECT> PRIMARY_PACKING_CONNECT { get; set; }
        public virtual DbSet<PRIMARY_PACKING_DATA> PRIMARY_PACKING_DATA { get; set; }
        public virtual DbSet<PRIMARY_PACKING_ERROR> PRIMARY_PACKING_ERROR { get; set; }
        public virtual DbSet<PRIMARY_PACKING_STATUS> PRIMARY_PACKING_STATUS { get; set; }
        public virtual DbSet<PRIMARY_PACKING_WARNING> PRIMARY_PACKING_WARNING { get; set; }
        public virtual DbSet<PRINT_MAKING_CONNECT> PRINT_MAKING_CONNECT { get; set; }
        public virtual DbSet<PRINT_MAKING_DATA> PRINT_MAKING_DATA { get; set; }
        public virtual DbSet<PRINT_MAKING_ERROR> PRINT_MAKING_ERROR { get; set; }
        public virtual DbSet<PRINT_MAKING_STATUS> PRINT_MAKING_STATUS { get; set; }
        public virtual DbSet<PRINT_MAKING_WARNING> PRINT_MAKING_WARNING { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductionOrder> ProductionOrder { get; set; }
        public virtual DbSet<ProductionOrderDetail> ProductionOrderDetail { get; set; }
        public virtual DbSet<ProductionOrderDetailCheck> ProductionOrderDetailCheck { get; set; }
        public virtual DbSet<ProductionOrderDetailCode> ProductionOrderDetailCode { get; set; }
        public virtual DbSet<ProductionOrderDetailMAP> ProductionOrderDetailMAP { get; set; }
        public virtual DbSet<ProductionOrderRawDetail> ProductionOrderRawDetail { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<Protocol> Protocol { get; set; }
        public virtual DbSet<ProtocolParam> ProtocolParam { get; set; }
        public virtual DbSet<ProvinceModel> ProvinceModel { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleDetaill> RoleDetaill { get; set; }
        public virtual DbSet<RoleObjectButtonMapping> RoleObjectButtonMapping { get; set; }
        public virtual DbSet<RoleUser> RoleUser { get; set; }
        public virtual DbSet<SECONDARY_PACKING_CONNECT> SECONDARY_PACKING_CONNECT { get; set; }
        public virtual DbSet<SECONDARY_PACKING_DATA> SECONDARY_PACKING_DATA { get; set; }
        public virtual DbSet<SECONDARY_PACKING_ERROR> SECONDARY_PACKING_ERROR { get; set; }
        public virtual DbSet<SECONDARY_PACKING_STATUS> SECONDARY_PACKING_STATUS { get; set; }
        public virtual DbSet<SECONDARY_PACKING_WARNING> SECONDARY_PACKING_WARNING { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<ShiftStaff> ShiftStaff { get; set; }
        public virtual DbSet<Site> Site { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<StaffAccountMapping> StaffAccountMapping { get; set; }
        public virtual DbSet<StaffSkill> StaffSkill { get; set; }
        public virtual DbSet<Stage> Stage { get; set; }
        public virtual DbSet<StatusConfig> StatusConfig { get; set; }
        public virtual DbSet<TABLE_SYNC> TABLE_SYNC { get; set; }
        public virtual DbSet<TypeDevice> TypeDevice { get; set; }
        public virtual DbSet<UNIT> UNIT { get; set; }
        public virtual DbSet<UNITCONVERT> UNITCONVERT { get; set; }
        public virtual DbSet<UserFunctionUsage> UserFunctionUsage { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<WardModel> WardModel { get; set; }
        public virtual DbSet<WarningConfig> WarningConfig { get; set; }
        public virtual DbSet<WEIGHT_CONNECT> WEIGHT_CONNECT { get; set; }
        public virtual DbSet<WEIGHT_DATA> WEIGHT_DATA { get; set; }
        public virtual DbSet<WEIGHT_ERROR> WEIGHT_ERROR { get; set; }
        public virtual DbSet<WEIGHT_STATUS> WEIGHT_STATUS { get; set; }
        public virtual DbSet<WEIGHT_WARNING> WEIGHT_WARNING { get; set; }
        public virtual DbSet<WorkShop> WorkShop { get; set; }
        public virtual DbSet<WorkshopUserMapping> WorkshopUserMapping { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<GetObjectPermissionByAccountId_Result> GetObjectPermissionByAccountId(Nullable<System.Guid> accountId, string typeId, Nullable<int> type, string moduleType, string groupType)
        {
            var accountIdParameter = accountId.HasValue ?
                new ObjectParameter("AccountId", accountId) :
                new ObjectParameter("AccountId", typeof(System.Guid));
    
            var typeIdParameter = typeId != null ?
                new ObjectParameter("typeId", typeId) :
                new ObjectParameter("typeId", typeof(string));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            var moduleTypeParameter = moduleType != null ?
                new ObjectParameter("moduleType", moduleType) :
                new ObjectParameter("moduleType", typeof(string));
    
            var groupTypeParameter = groupType != null ?
                new ObjectParameter("groupType", groupType) :
                new ObjectParameter("groupType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetObjectPermissionByAccountId_Result>("GetObjectPermissionByAccountId", accountIdParameter, typeIdParameter, typeParameter, moduleTypeParameter, groupTypeParameter);
        }
    
        public virtual ObjectResult<sproc_reportHistoryDevice_Result> sproc_reportHistoryDevice(string companyId, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo, ObjectParameter cOUNT)
        {
            var companyIdParameter = companyId != null ?
                new ObjectParameter("companyId", companyId) :
                new ObjectParameter("companyId", typeof(string));
    
            var dateFromParameter = dateFrom.HasValue ?
                new ObjectParameter("dateFrom", dateFrom) :
                new ObjectParameter("dateFrom", typeof(System.DateTime));
    
            var dateToParameter = dateTo.HasValue ?
                new ObjectParameter("dateTo", dateTo) :
                new ObjectParameter("dateTo", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sproc_reportHistoryDevice_Result>("sproc_reportHistoryDevice", companyIdParameter, dateFromParameter, dateToParameter, cOUNT);
        }
    }
}
