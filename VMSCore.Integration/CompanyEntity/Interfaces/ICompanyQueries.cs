using System.Collections.Generic;

namespace VMSCore.Integration.CompanyEntity.Interfaces
{
    public interface ICompanyQueries
    {
        List<Company> GetAllCompanies();
        Company GetCompanyByCode(string companyCode);
        Company GetCompanyByTaxNumber(string companyTaxNumber);
    }
}
