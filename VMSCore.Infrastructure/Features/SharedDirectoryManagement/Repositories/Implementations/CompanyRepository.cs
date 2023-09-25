using System;
using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public Company GetByCode(string companyCode)
        {
            return _context.Company.FirstOrDefault(x => x.Code == companyCode);
        }
        public string DeletePlantByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Company.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Company.Remove(entry);
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

        public Company GetByTaxNo(string companyTaxNumber)
        {
            return _context.Company.FirstOrDefault(x => x.CompanyTax.Equals(companyTaxNumber, StringComparison.InvariantCultureIgnoreCase));
        }
        public List<CompanyViewModel> GetAllCompany()
        {
            var result = _context.Company.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,
                CompanyCodeNameEn = x.CompanyCodeNameEn,
                CompanyTax = x.CompanyTax,
                Description = x.Description,
                Active = x.Active
            }).ToList();
            return result.Any() ? result : new List<CompanyViewModel>();
        }
        public List<CompanyViewModel> Search(string code, string name, string tax)
        {
            var hasCode = string.IsNullOrWhiteSpace(code);
            var hasName = string.IsNullOrWhiteSpace(name);
            var hasTax = string.IsNullOrWhiteSpace(tax);
            var result = _context.Company
                .Where(c => (hasCode || c.Code.Contains(code))
                && (hasName || c.Name.Contains(name)
                && (hasTax || c.CompanyTax.Contains(tax)))
                )
                .Select(x => new CompanyViewModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    CompanyCodeNameEn = x.CompanyCodeNameEn,
                    CompanyTax = x.CompanyTax,
                    Description = x.Description,
                    Active = x.Active
                }).ToList();
            return result.Any() ? result : new List<CompanyViewModel>();
        }
        public List<CompanyDropDownListViewModel> CompanyDropDownList()
        {
            var result = _context.Company.Where(x => x.Active == true).Select(x => new CompanyDropDownListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CompanyTax = x.CompanyTax
            }).ToList();
            return result.Any() ? result : new List<CompanyDropDownListViewModel>();
        }

        // Delete Company
        public bool DeleteCompany(string companyId)
        {
            var company = _context.Company.FirstOrDefault(x => x.Code == companyId);
            if (company == null)
            {
                return false;
            }

            _context.Company.Remove(company);
            _context.SaveChanges();
            return true;


        }
    }
}
