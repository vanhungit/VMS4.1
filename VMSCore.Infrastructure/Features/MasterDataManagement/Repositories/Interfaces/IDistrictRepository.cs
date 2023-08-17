using System.Collections.Generic;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Interfaces
{
    public interface IDistrictRepository
    {
        List<DistrictViewModel> Search(DistrictSearchViewModel searchViewModel);
    }
}
