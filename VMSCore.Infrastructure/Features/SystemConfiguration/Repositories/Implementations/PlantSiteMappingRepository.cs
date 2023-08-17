using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations
{
    public class PlantSiteMappingRepository : BaseRepository<PlantSiteMapping>
    {
        public List<PlantSiteMappingViewModel> GetPlantSiteMapping(string plantId)
        {
            var result = (from s in _context.Site
                          join p in _context.PlantSiteMapping on new { SiteId = s.Id, PlantId = plantId } equals new { p.SiteId, p.PlantId } into pt
                          from pb in pt.DefaultIfEmpty()
                          orderby s.Name ascending, s.CreationTime descending
                          select new PlantSiteMappingViewModel()
                          {
                              SiteId = s.Id,
                              SiteCode = s.Code,
                              SiteName = s.Name,
                              SitePrice = s.Price,
                              CustomerCode = pb != null? pb.CustomerCode: string.Empty,
                              Assigned = pb != null && pb.PlantId.Equals(plantId) ? true : false
                          }).ToList();
            return result.Any() ? result : new List<PlantSiteMappingViewModel>();
        }

    }
}
