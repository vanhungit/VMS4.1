using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces
{
    public interface ILineRepository : IRepository<Line>
    {
        List<LineListViewModel> SearchLine(string companyId, string plantId, string workshopId, string LineName);
        List<LineDropListViewModel> LineDropList();
        List<LineListViewModel> GetAllLine();
    }
}
