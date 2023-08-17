using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class WorkshopRepository : BaseRepository<WorkShop>, IWorkshopRepository
    {
        public List<WorkshopViewModel> GetAll()
        {
            var result = (from w in _context.WorkShop
                          join p in _context.Plant on w.PlantId equals p.Id
                          join c in _context.Company on w.CompanyId equals c.Id
                          select new WorkshopViewModel()
                          {
                              Id = w.Id,
                              Name = w.Name,
                              Code = w.Code,
                              Description = w.Description,
                              WorkShopNameEn = w.WorkShopNameEn,
                              PlantId = w.PlantId,
                              CompanyName = c.Name,
                              CompanyTax = c.CompanyTax,
                              PlantName = p.Name,
                              PlantCode = p.Code,
                              CompanyId = c.Id,
                              Active = (w.Active.HasValue && w.Active == true) ? true : false
                          }).ToList();
            return result.Any() ? result : new List<WorkshopViewModel>();
        }
        public List<WorkshopViewModel> Search(string companyId, string plantId, string workshopName)
        {
            var hasCompanyId = string.IsNullOrWhiteSpace(companyId);
            var hasplantName = string.IsNullOrWhiteSpace(plantId);
            var hasWorkshopName = string.IsNullOrWhiteSpace(workshopName);
            var result = (from w in _context.WorkShop
                          join p in _context.Plant on w.PlantId equals p.Id
                          join c in _context.Company on w.CompanyId equals c.Id
                          where (hasCompanyId == true || w.CompanyId.Equals(companyId))
                          && (hasplantName == true || w.PlantId.Equals(plantId))
                          && (hasWorkshopName == true || w.Name.Contains(workshopName))
                          select new WorkshopViewModel()
                          {
                              Id = w.Id,
                              Name = w.Name,
                              Code = w.Code,
                              Description = w.Description,
                              WorkShopNameEn = w.WorkShopNameEn,
                              PlantId = w.PlantId,
                              CompanyName = c.Name,
                              CompanyTax = c.CompanyTax,
                              PlantName = p.Name,
                              PlantCode = p.Code,
                              CompanyId = c.Id,
                              Active = (w.Active.HasValue && w.Active == true) ? true : false
                          }).ToList();
            return result.Any() ? result : new List<WorkshopViewModel>();
        }

        public List<WorkShopDropDownListViewModel> workShopDropDownList()
        {
            var result = _context.WorkShop.Where(w => w.Active.HasValue && w.Active == true).Select(x => new WorkShopDropDownListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).ToList();
            return result.Any() ? result : new List<WorkShopDropDownListViewModel>();
        }
        public List<WorkShopDropDownListViewModel> workShopDropDownListByPlantId(string plantId)
        {
            var result = _context.WorkShop.Where(w => w.Active.HasValue && w.Active == true && w.PlantId.Equals(plantId)).Select(x => new WorkShopDropDownListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).ToList();
            return result.Any() ? result : new List<WorkShopDropDownListViewModel>();
        }
    }
}
