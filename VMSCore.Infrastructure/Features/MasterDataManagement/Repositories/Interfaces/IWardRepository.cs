using System.Collections.Generic;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Interfaces
{
    public interface IWardRepository
    {
        List<WardViewModel> Search(WardSearchViewModel searchViewModel);
    }
}
