using System;
using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class FactoryRepository : BaseRepository<Factory>, IFactoryRepository
    {
        public Factory GetByCode(string Code)
        {
            return _context.Factory.FirstOrDefault(x => x.Code == Code);
        }
        public List<PlantDropDownListViewModel> PlantDropDownList()
        {
            var result = _context.Factory
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
            var result = (from p in _context.Factory
                          join c in _context.Company on p.CompanyCode equals c.Code
                          select new PlantViewModel()
                          {
                              Active = p.Active,
                              CompanyId = p.CompanyCode,
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
            var result = (from p in _context.Factory
                          join c in _context.Company on p.CompanyCode equals c.Code
                          where (hasCompanyId == true || p.CompanyCode.Equals(companyId))
                          && (hasplantName == true || p.Name.Contains(plantName))
                          select new PlantViewModel()
                          {
                              Active = p.Active,
                              CompanyId = p.CompanyCode,
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
            var result = _context.Factory
                .Where(x => x.Active == true && x.CompanyCode.Equals(companyId))
                .Select(x => new PlantDropDownListViewModel()
                {
                    PlantCode = x.Code,
                    PlantName = x.Name,
                    PlantId = x.Id
                }).ToList();
            return result.Any() ? result : new List<PlantDropDownListViewModel>();
        }
        public string DeletePlantByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Factory.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Factory.Remove(entry);
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
