using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Interfaces;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Implementations
{
    public class ProvinceRepository : BaseRepository<ProvinceModel>, IProvinceRepository
    {
        public List<ProvinceModel> Search(ProvinceSearchViewModel searchViewModel)
        {
            var provinceList = (from p in _context.ProvinceModel
                                orderby p.Area, p.OrderIndex, p.ProvinceName
                                where
                                    (searchViewModel.ProvinceName == null || p.ProvinceName.Contains(searchViewModel.ProvinceName))
                                    && (searchViewModel.Actived == null || p.Actived == searchViewModel.Actived)
                                select p).ToList();
            return provinceList;
        }
    }
}
