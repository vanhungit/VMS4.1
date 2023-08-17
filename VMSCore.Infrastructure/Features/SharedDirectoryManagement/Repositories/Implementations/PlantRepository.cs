using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PlantRepository : BaseRepository<Plant>, IPlantRepository
    {
        public List<PlantDropDownListViewModel> PlantDropDownList()
        {
            var result = _context.Plant
                .Where(x => x.Active == true)
                .Select(x => new PlantDropDownListViewModel()
                {
                    PlantCode = x.Code,
                    PlantName = x.Name,
                    PlantId = x.Id
                }).ToList();
            return result.Any() ? result : new List<PlantDropDownListViewModel>();
        }
        public List<PlantViewModel> GetAllPlant()
        {
            var result = (from p in _context.Plant
                          join c in _context.Company on p.CompanyId equals c.Id
                          select new PlantViewModel()
                          {
                              Active = p.Active,
                              CompanyId = p.CompanyId,
                              CompanyName = c.Name,
                              CompanyTax = c.CompanyTax,
                              Description = p.Description,
                              PlantCode = p.Code,
                              PlantId = p.Id,
                              PlantName = p.Name,
                              PlantNameEn = p.NameEn
                          }).ToList();
            return result.Any() ? result : new List<PlantViewModel>();
        }
        public List<PlantViewModel> Search(string companyId, string plantName)
        {
            var hasCompanyId = string.IsNullOrWhiteSpace(companyId);
            var hasplantName = string.IsNullOrWhiteSpace(plantName);
            var result = (from p in _context.Plant
                          join c in _context.Company on p.CompanyId equals c.Id
                          where (hasCompanyId == true || p.CompanyId.Equals(companyId))
                          && (hasplantName == true || p.Name.Contains(plantName))
                          select new PlantViewModel()
                          {
                              Active = p.Active,
                              CompanyId = p.CompanyId,
                              CompanyName = c.Name,
                              CompanyTax = c.CompanyTax,
                              Description = p.Description,
                              PlantCode = p.Code,
                              PlantId = p.Id,
                              PlantName = p.Name,
                              PlantNameEn = p.NameEn
                          }).ToList();
            return result.Any() ? result : new List<PlantViewModel>();
        }
        public List<PlantDropDownListViewModel> PlantDropDownListByCompanyId(string companyId)
        {
            var result = _context.Plant
                .Where(x => x.Active == true && x.CompanyId.Equals(companyId))
                .Select(x => new PlantDropDownListViewModel()
                {
                    PlantCode = x.Code,
                    PlantName = x.Name,
                    PlantId = x.Id
                }).ToList();
            return result.Any() ? result : new List<PlantDropDownListViewModel>();
        }
    }
}
