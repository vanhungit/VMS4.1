using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Interfaces;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.MasterDataManagement.Repositories.Implementations
{
    public class DistrictRepository : BaseRepository<DistrictModel>, IDistrictRepository
    {
        public List<DistrictViewModel> Search(DistrictSearchViewModel searchViewModel)
        {
            var districts = (from p in _context.DistrictModel
                             join pr in _context.ProvinceModel on p.ProvinceId equals pr.ProvinceId
                             orderby pr.Area, pr.ProvinceName, p.Appellation, p.DistrictName
                             where (searchViewModel.ProvinceId == null || p.ProvinceId == searchViewModel.ProvinceId) &&
                                   (searchViewModel.DistrictName == null || (p.DistrictName.Contains(searchViewModel.DistrictName) ||
                                                                             p.Appellation.Contains(searchViewModel
                                                                                 .DistrictName))) &&
                                   (searchViewModel.Actived == null || p.Actived == searchViewModel.Actived)
                             select new DistrictViewModel()
                             {
                                 ProvinceName = pr.ProvinceName,
                                 DistrictId = p.DistrictId,
                                 DistrictCode = p.DistrictCode,
                                 DistrictName = p.Appellation + " " + p.DistrictName,
                                 OrderIndex = p.OrderIndex,
                                 Actived = p.Actived
                             }).ToList();

            return districts;
        }
    }
}
