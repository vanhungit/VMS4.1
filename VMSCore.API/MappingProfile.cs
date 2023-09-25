using AutoMapper;
using Newtonsoft.Json.Linq;
using VMSCore.API.EntityModels.Models;

namespace VMSCore.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<JObject, Company>();
            CreateMap<Company, Company>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Factory>();
            CreateMap<Factory, Factory>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, WorkShop>();
            CreateMap<WorkShop, WorkShop>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Stage>();
            CreateMap<Stage, Stage>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, DeviceGroup>();
            CreateMap<DeviceGroup, DeviceGroup>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, TypeDevice>();
            CreateMap<TypeDevice, TypeDevice>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Device>();
            CreateMap<Device, Device>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Device_PROTOCOL>();
            CreateMap<Device_PROTOCOL, Device_PROTOCOL>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ConnectConfig>();
            CreateMap<ConnectConfig, ConnectConfig>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, StatusConfig>();
            CreateMap<StatusConfig, StatusConfig>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ErrorConfig>();
            CreateMap<ErrorConfig, ErrorConfig>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, WarningConfig>();
            CreateMap<WarningConfig, WarningConfig>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, Protocol>();
            CreateMap<Protocol, Protocol>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ProtocolParam>();
            CreateMap<ProtocolParam, ProtocolParam>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, ProductionOrder>();
            CreateMap<ProductionOrder, ProductionOrder>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ProductionOrderDetail>();
            CreateMap<ProductionOrderDetail, ProductionOrderDetail>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ProductionOrderDetailCode>();
            CreateMap<ProductionOrderDetailCode, ProductionOrderDetailCode>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ProductionOrderRawDetail>();
            CreateMap<ProductionOrderRawDetail, ProductionOrderRawDetail>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, Line>();
            CreateMap<Line, Line>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, LineDevice>();
            CreateMap<LineDevice, LineDevice>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, ProductGroup>();
            CreateMap<ProductGroup, ProductGroup>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ProductType>();
            CreateMap<ProductType, ProductType>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Product>();
            CreateMap<Product, Product>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, UNIT>();
            CreateMap<UNIT, UNIT>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, UNITCONVERT>();
            CreateMap<UNITCONVERT, UNITCONVERT>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, MaterialProduct>();
            CreateMap<MaterialProduct, MaterialProduct>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, Shift>();
            CreateMap<Shift, Shift>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Staff>();
            CreateMap<Staff, Staff>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Skills>();
            CreateMap<Skills, Skills>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, StaffSkill>();
            CreateMap<StaffSkill, StaffSkill>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ShiftStaff>();
            CreateMap<ShiftStaff, ShiftStaff>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, Department>();
            CreateMap<Department, Department>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, DepartmentStaff>();
            CreateMap<DepartmentStaff, DepartmentStaff>()
                    .ForMember(dest => dest.Id, act => act.Ignore());

            CreateMap<JObject, Role>();
            CreateMap<Role, Role>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, RoleDetaill>();
            CreateMap<RoleDetaill, RoleDetaill>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, RoleUser>();
            CreateMap<RoleUser, RoleUser>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, ObjectEntity>();
            CreateMap<ObjectEntity, ObjectEntity>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
            CreateMap<JObject, RoleObjectButtonMapping>();
            CreateMap<RoleObjectButtonMapping, RoleObjectButtonMapping>()
                    .ForMember(dest => dest.Id, act => act.Ignore());
        }
    }
}
