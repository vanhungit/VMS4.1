using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces
{
    public interface IFactoryRepository : IRepository<Factory>
    {
        Factory GetByCode(string Code);
        List<PlantDropDownListViewModel> PlantDropDownList();
        List<PlantViewModel> GetAllPlant();
        List<PlantViewModel> Search(string companyId, string plantName);
        List<PlantDropDownListViewModel> PlantDropDownListByCompanyId(string companyId);
    }
}
