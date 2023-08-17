using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class LineRepository : BaseRepository<Line>, ILineRepository
    {
        public List<LineListViewModel> SearchLine(string companyId, string plantId, string workshopId, string lineName)
        {
            var hasCompanyId = !string.IsNullOrWhiteSpace(companyId);
            var hasPlantId = !string.IsNullOrWhiteSpace(plantId);
            var hasworkshopId = !string.IsNullOrWhiteSpace(workshopId);
            var haslineName = !string.IsNullOrWhiteSpace(lineName);
            var result = (from l in _context.Line
                          join c in _context.Company on l.CompanyId equals c.Id into ct
                          from co in ct.DefaultIfEmpty()
                          join p in _context.Plant on l.PlantId equals p.Id into pt
                          from pl in pt.DefaultIfEmpty()
                          join w in _context.WorkShop on l.WorkshopId equals w.Id into wt
                          from wh in wt.DefaultIfEmpty()
                          where (hasCompanyId == false || l.CompanyId.Equals(companyId))
                                && (hasPlantId == false || l.CompanyId.Equals(plantId))
                                && (hasworkshopId == false || l.CompanyId.Equals(companyId))
                                && (haslineName == false || l.CompanyId.Equals(lineName))
                          select new LineListViewModel()
                          {
                              LineId = l.Id,
                              LineName = l.Name,
                              LineCode = l.Code,
                              Description = l.Description,
                              Active = l.Active,
                              CompanyId = co != null ? co.Id : string.Empty,
                              CompanyName = co != null ? co.Name + " - " + co.CompanyTax : string.Empty,
                              PlantId = pl != null ? pl.Id : string.Empty,
                              PlantName = pl != null ? pl.Name + " - " + pl.Code : string.Empty,
                              WorkShopId = wh != null ? wh.Id : string.Empty,
                              WorkShopName = wh != null ? wh.Name + " - " + wh.Code : string.Empty

                          }).ToList();
            return result.Any() ? result : new List<LineListViewModel>();
        }
        public List<LineDropListViewModel> LineDropList()
        {
            var result = _context.Line.Where(x => x.Active == true).Select(x => new LineDropListViewModel()
            {
                LineId = x.Id,
                LineCode = x.Code,
                LineName = x.Name
            }).ToList();
            return result.Any() ? result : new List<LineDropListViewModel>();

        }
        public List<LineListViewModel> GetAllLine()
        {

            var result = (from l in _context.Line
                          join c in _context.Company on l.CompanyId equals c.Id into ct
                          from co in ct.DefaultIfEmpty()
                          join p in _context.Plant on l.PlantId equals p.Id into pt
                          from pl in pt.DefaultIfEmpty()
                          join w in _context.WorkShop on l.WorkshopId equals w.Id into wt
                          from wh in wt.DefaultIfEmpty()
                          select new LineListViewModel()
                          {
                              LineId = l.Id,
                              LineName = l.Name,
                              LineCode = l.Code,
                              Description = l.Description,
                              Active = l.Active,
                              CompanyId = co != null ? co.Id : string.Empty,
                              CompanyName = co != null ? co.Name + " - " + co.CompanyTax : string.Empty,
                              PlantId = pl != null ? pl.Id : string.Empty,
                              PlantName = pl != null ? pl.Name + " - " + pl.Code : string.Empty,
                              WorkShopId = wh != null ? wh.Id : string.Empty,
                              WorkShopName = wh != null ? wh.Name + " - " + wh.Code : string.Empty

                          }).ToList();
            return result.Any() ? result : new List<LineListViewModel>();
        }
    }
}
