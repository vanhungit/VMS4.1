using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Interfaces
{
    public interface IProvinceRepository
    {
        List<ProvinceModel> Search(ProvinceSearchViewModel searchViewModel);
    }
}
