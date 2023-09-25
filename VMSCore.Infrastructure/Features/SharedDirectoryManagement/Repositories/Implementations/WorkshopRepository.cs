using System;
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
        public WorkShop GetByCode(string Code)
        {
            return _context.WorkShop.FirstOrDefault(x => x.Code == Code);
        }
        public List<WorkshopViewModel> GetAll()
        {
            var result = (from w in _context.WorkShop
                          join p in _context.Factory on w.FactoryCode equals p.Code
                          join c in _context.Company on w.CompanyCode equals c.Code
                          select new WorkshopViewModel()
                          {
                              Id = w.Id,
                              Name = w.Name,
                              Code = w.Code,
                              Description = w.Description,
                              WorkShopNameEn = w.NameEn,
                              PlantId = w.FactoryCode,
                              CompanyName = c.Name,
                              CompanyTax = c.CompanyTax,
                              PlantName = p.Name,
                              PlantCode = p.Code,
                              CompanyId = c.Code,
                              Active = (w.Active.HasValue && w.Active == true) ? true : false
                          }).Distinct().ToList();
            return result.Any() ? result : new List<WorkshopViewModel>();
        }
        public List<WorkshopViewModel> Search(string companyId, string plantId, string workshopName)
        {
            var hasCompanyId = string.IsNullOrWhiteSpace(companyId);
            var hasplantName = string.IsNullOrWhiteSpace(plantId);
            var hasWorkshopName = string.IsNullOrWhiteSpace(workshopName);
            var result = (from w in _context.WorkShop
                          join p in _context.Factory on w.FactoryCode equals p.Code
                          join c in _context.Company on w.CompanyCode equals c.Code
                          where (hasCompanyId == true || w.CompanyCode.Equals(companyId))
                          && (hasplantName == true || w.FactoryCode.Equals(plantId))
                          && (hasWorkshopName == true || w.Name.Contains(workshopName))
                          select new WorkshopViewModel()
                          {
                              Id = w.Id,
                              Name = w.Name,
                              Code = w.Code,
                              Description = w.Description,
                              WorkShopNameEn = w.NameEn,
                              PlantId = w.FactoryCode,
                              CompanyName = c.Name,
                              CompanyTax = c.CompanyTax,
                              PlantName = p.Name,
                              PlantCode = p.Code,
                              CompanyId = c.Code,
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
            var result = _context.WorkShop.Where(w => w.Active.HasValue && w.Active == true && w.FactoryCode.Equals(plantId)).Select(x => new WorkShopDropDownListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code
            }).ToList();
            return result.Any() ? result : new List<WorkShopDropDownListViewModel>();
        }
        public string DeleteWorkShopByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WorkShop.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WorkShop.Remove(entry);
                    _context.SaveChanges();
                    obj = entry.Code;
                    return obj;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return obj;
            }
        }
    }
}
