using System.Collections.Generic;
using System;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
    }

public class MyClass
{
    private readonly CompanyRepository _companyRepository;

    public MyClass()
    {
        _companyRepository = new CompanyRepository();
    }

    public void DoSomething()
    {
        // Get company by code
        var companyByCode = _companyRepository.GetByCode("code1");

        // Get company by tax number
        var companyByTaxNo = _companyRepository.GetByTaxNo("tax123");

        // Get all companies
        var allCompanies = _companyRepository.GetAllCompany();

        // Search companies theo Company Code, Company Name vaà Company Tax
        var searchResult = _companyRepository.Search("code2", "name2", "tax1234");
    }
}


}
