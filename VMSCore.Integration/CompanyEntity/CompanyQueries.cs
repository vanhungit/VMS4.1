using System.Collections.Generic;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Integration.CompanyEntity.Interfaces;

namespace VMSCore.Integration.CompanyEntity
{
    public class CompanyQueries : ICompanyQueries
    {
        private readonly CompanyRepository _companyCommandRepository = new CompanyRepository();

        public List<Company> GetAllCompanies()
        {
            var companies = _companyCommandRepository.GetAll();
            return companies;
        }

        public Company GetCompanyByCode(string companyCode)
        {
            var companies = _companyCommandRepository.GetByCode(companyCode);
            return companies;
        }

        public Company GetCompanyByTaxNumber(string companyTaxNumber)
        {
            if (string.IsNullOrWhiteSpace(companyTaxNumber))
            {
                return null;
            }
            var companies = _companyCommandRepository.GetByTaxNo(companyTaxNumber);
            return companies;
        }
    }
}
