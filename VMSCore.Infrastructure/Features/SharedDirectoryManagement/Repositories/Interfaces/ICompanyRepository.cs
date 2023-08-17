using System.Collections.Generic;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetByCode(string companyCode);
        Company GetByTaxNo(string companyTaxNumber);
        List<CompanyViewModel> GetAllCompany();
        List<CompanyViewModel> Search(string code, string name, string tax);
        List<CompanyDropDownListViewModel> CompanyDropDownList();
    }
}
