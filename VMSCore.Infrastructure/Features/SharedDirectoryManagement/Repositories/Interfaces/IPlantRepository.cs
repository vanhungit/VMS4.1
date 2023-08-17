using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces
{
    public interface IPlantRepository : IRepository<Plant>
    {
        List<PlantDropDownListViewModel> PlantDropDownList();
        List<PlantViewModel> GetAllPlant();
        List<PlantViewModel> Search(string companyId, string plantName);
        List<PlantDropDownListViewModel> PlantDropDownListByCompanyId(string companyId);
    }
}
