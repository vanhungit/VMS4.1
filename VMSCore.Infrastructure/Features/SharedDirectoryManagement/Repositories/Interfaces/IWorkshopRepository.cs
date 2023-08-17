using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces
{
    public interface IWorkshopRepository : IRepository<WorkShop>
    {
        List<WorkshopViewModel> GetAll();
        List<WorkshopViewModel> Search(string companyId, string plantId, string workshopName);

        List<WorkShopDropDownListViewModel> workShopDropDownList();


    }
}
