using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Interfaces;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Implementations
{
    public class WardRepository : BaseRepository<WardModel>, IWardRepository
    {
        public List<WardViewModel> Search(WardSearchViewModel searchViewModel)
        {
            var wards = (from p in _context.WardModel
                         join d in _context.DistrictModel on p.DistrictId equals d.DistrictId
                         join pr in _context.ProvinceModel on d.ProvinceId equals pr.ProvinceId
                         orderby pr.Area, pr.ProvinceName, d.Appellation, d.DistrictName, p.Appellation, p.WardName
                         where (searchViewModel.ProvinceCode == null || pr.ProvinceId == searchViewModel.ProvinceCode) &&
                               (searchViewModel.DistrictCode == null || p.DistrictId == searchViewModel.DistrictCode) &&
                               (searchViewModel.WardName == null || (p.WardName.Contains(searchViewModel.WardName) ||
                                                                     p.Appellation.Contains(searchViewModel.WardName)))
                         select new WardViewModel()
                         {
                             WardId = p.WardId,
                             ProvinceName = pr.ProvinceName,
                             DistrictName = d.Appellation + " " + d.DistrictName,
                             WardCode = p.WardCode,
                             WardName = p.Appellation + " " + p.WardName,
                             OrderIndex = p.OrderIndex
                         }).ToList();
            return wards;
        }
    }
}
