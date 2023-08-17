using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMSCore.Infrastructure.Features.SystemConfiguration.Services.Interfaces;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Services.Implementations
{
    public class StaffPermissionService: IStaffPermissionService
    {
        public StaffPermissionViewModel GetPermissionByAccountId(string accountId)
        {
            DataSet ds = new DataSet();
            var staffPermission = new StaffPermissionViewModel();
            var companies = new List<StaffPermissionCompayViewModel>();
            var plants = new List<StaffPermissionPlantViewModel>();
            var workShops = new List<StaffPermissionWorkShopViewModel>();
            var lines = new List<StaffPermissionLineViewModel>();
            var roles = new List<RoleUserViewModel>();
            var connectionString = ConfigurationManager.ConnectionStrings["VMSCoreDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "dbo.GetPermissionByAccountId";
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    SqlDataReader  myReader = cmd.ExecuteReader();
                    
                    while (myReader.Read())
                    {
                        var data = new StaffPermissionCompayViewModel();
                        data.CompanyId = Convert.ToString(myReader["CompanyId"]);
                        data.CompanyName = Convert.ToString(myReader["CompanyName"]);
                        data.CompanyTax = Convert.ToString(myReader["CompanyTax"]);
                        data.IsCompanyAssigned = Convert.ToBoolean(myReader["IsCompanyAssigned"]);
                        companies.Add(data);
                    }
                    myReader.NextResult();

                    while (myReader.Read())
                    {
                        var data = new StaffPermissionPlantViewModel();
                        data.CompanyId = Convert.ToString(myReader["CompanyId"]);
                        data.PlantId = Convert.ToString(myReader["PlantId"]);
                        data.PlantName = Convert.ToString(myReader["PlantName"]);
                        data.PlantCode = Convert.ToString(myReader["PlantCode"]);
                        data.IsPlantAssigned = Convert.ToBoolean(myReader["IsPlantAssigned"]);
                        plants.Add(data);
                    }
                    myReader.NextResult();
                    while (myReader.Read())
                    {
                        var data = new StaffPermissionWorkShopViewModel();
                        data.PlantId = Convert.ToString(myReader["PlantId"]);
                        data.WorkShopId = Convert.ToString(myReader["WorkShopId"]);
                        data.WorkShopCode = Convert.ToString(myReader["WorkShopCode"]);
                        data.WorkShopName = Convert.ToString(myReader["WorkShopName"]);
                        data.IsWorkShopAssigned = Convert.ToBoolean(myReader["IsWorkShopAssigned"]);
                        workShops.Add(data);
                    }
                    myReader.NextResult();
                    while (myReader.Read())
                    {
                        var data = new StaffPermissionLineViewModel();
                        data.WorkshopId = Convert.ToString(myReader["WorkshopId"]);
                        data.LineId = Convert.ToString(myReader["LineId"]);
                        data.LineCode = Convert.ToString(myReader["LineCode"]);
                        data.LineName = Convert.ToString(myReader["LineName"]);
                        data.IsLineAssigned = Convert.ToBoolean(myReader["IsLineAssigned"]);
                        lines.Add(data);
                    }
                    myReader.NextResult();
                    while (myReader.Read())
                    {
                        var data = new RoleUserViewModel();
                        data.RoleId = Convert.ToString(myReader["RoleId"]);
                        data.RoleName = Convert.ToString(myReader["RoleName"]);
                        data.IsRoleAssigned = Convert.ToBoolean(myReader["IsRoleAssigned"]);
                        roles.Add(data);
                    }
                    conn.Close();
                }
            }

            staffPermission.StaffPermissionCompanies = companies;
            staffPermission.StaffPermissionPlants = plants;
            staffPermission.StaffPermissionWorkShops = workShops;
            staffPermission.StaffPermissionLines = lines;
            staffPermission.StaffRoles = roles;

            return staffPermission;
        }
        public void DeleteStaffPermission(string accountId)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["VMSCoreDb"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "sproc_DeleteUserCompanyMapping";
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    conn.Close();
                }
            }
        }
    }
}
