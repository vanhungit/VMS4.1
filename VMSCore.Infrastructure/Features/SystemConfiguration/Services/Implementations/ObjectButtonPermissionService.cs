using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Services.Interfaces;
using VMSCore.ViewModels.SystemConfiguration;
using static VMSCore.Common.Enums.SystemEnum;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Services.Implementations
{
    public class ObjectButtonPermissionService : IObjectButtonPermissionService
    {
        private readonly RoleObjectButtonMappingRepository _roleObjectButtonMappingRepository = new RoleObjectButtonMappingRepository();
        private readonly FunctionGroupModuleObjectMappingRepository _functionGroupModuleObjectMappingRepository = new FunctionGroupModuleObjectMappingRepository();

        public List<ObjectButtonPermissionViewModel> GetAssignObjectButtonByAccount(string accountId, string typeId, int type, string moduleType, string groupType)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["VMSCoreDb"].ConnectionString;
            DataSet ds = new DataSet();

            using (var conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.GetObjectPermissionByAccountId";
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Parameters.AddWithValue("@typeId", typeId);
                    cmd.Parameters.AddWithValue("@type", type);
                    cmd.Parameters.AddWithValue("@moduleType", moduleType);
                    cmd.Parameters.AddWithValue("@groupType", groupType);

                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    conn.Close();
                }
            }

            return (from p in ds.Tables[0].AsEnumerable()
                    select new ObjectButtonPermissionViewModel()
                    {
                        FunctionGroupModuleObjectMappingId = p.Field<string>("FunctionGroupModuleObjectMappingId"),
                        ObjectId = p.Field<string>("ObjectId"),
                        ButtonId = p.Field<string>("ButtonId"),
                        ParentId = p.Field<string>("ParentId"),
                        FunctionGroupModuleObjectMappingDescription =
                        p.Field<string>("FunctionGroupModuleObjectMappingDescription"),
                        Level = p.Field<int>("Level"),
                        OrderId = p.Field<int>("OrderId"),
                        Owner = p.Field<string>("Owner"),
                        FunctionGroupModuleObjectMappingActive = p.Field<bool?>("FunctionGroupModuleObjectMappingActive"),
                        ModuleType = p.Field<string>("ModuleType"),
                        GroupType = p.Field<string>("GroupType"),
                        ObjectName = p.Field<string>("ObjectName"),
                        ObjectNameEn = p.Field<string>("ObjectNameEn"),
                        ObjectEntityDescription = p.Field<string>("ObjectEntityDescription"),
                        ObjectEntityActive = p.Field<bool?>("ObjectEntityActive"),
                        ButtonName = p.Field<string>("ButtonName"),
                        ButtonNameEn = p.Field<string>("ButtonNameEn"),
                        ButtonDescription = p.Field<string>("ButtonDescription"),
                        ButtonActive = p.Field<bool?>("ButtonActive")
                    }).ToList();
        }

        //public void AssignObjectButtonForAccount(int type, RoleObjectButtonMapping roleObjectButtonMappingEntity,
        //  FunctionGroupModuleObjectMapping functionGroupModuleObjectMappingEntity,
        //  PlantRoleObjectMapping plantRoleObjectMappingEntityEntity,
        //  WorkshopRoleObjectMapping workshopRoleObjectMappingEntity,
        //  LineRoleObjectMapping lineRoleObjectMappingEntity,
        //  CompanyRoleObjectMapping companyRoleObjectMappingEntity)
        //{
        //    if (!_roleObjectButtonMappingRepository.IsExistingRoleObjectButtonMapping(roleObjectButtonMappingEntity))
        //    {
        //        _roleObjectButtonMappingRepository.Add(roleObjectButtonMappingEntity);
        //    }

        //    if (!_functionGroupModuleObjectMappingRepository.IsExistingFunctionGroupModuleObjectMapping(
        //          functionGroupModuleObjectMappingEntity))
        //    {
        //        _functionGroupModuleObjectMappingRepository.Add(functionGroupModuleObjectMappingEntity);
        //    }

        //    if (type == (int)PermissionType.Company)
        //    {
        //        if (_companyRoleObjectMappingRepository.IsExistingCompanyRoleObjectMapping(companyRoleObjectMappingEntity))
        //        {
        //            _companyRoleObjectMappingRepository.Add(companyRoleObjectMappingEntity);
        //        }
        //    }

        //    if (type == (int)PermissionType.Plant)
        //    {
        //        if (_plantRoleObjectMappingRepository.IsExistingPlantRoleObjectMapping(plantRoleObjectMappingEntityEntity))
        //        {
        //            _plantRoleObjectMappingRepository.Add(plantRoleObjectMappingEntityEntity);
        //        }
        //    }

        //    if (type == (int)PermissionType.Line)
        //    {
        //        if (_lineRoleObjectMappingRepository.IsExistingLineRoleObjectMapping(lineRoleObjectMappingEntity))
        //        {
        //            _lineRoleObjectMappingRepository.Add(lineRoleObjectMappingEntity);
        //        }
        //    }

        //    if (type == (int)PermissionType.Workshop)
        //    {
        //        if (_workshopRoleObjectMappingRepository.IsExistingWorkshopRoleObjectMapping(workshopRoleObjectMappingEntity))
        //        {
        //            _workshopRoleObjectMappingRepository.Add(workshopRoleObjectMappingEntity);
        //        }
        //    }
        //}
    }
}