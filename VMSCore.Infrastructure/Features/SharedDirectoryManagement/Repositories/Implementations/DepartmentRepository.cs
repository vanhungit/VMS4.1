using System.Collections.Generic;
using System;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using System.Linq;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public Department GetByCode(string Code)
        {
            return _context.Department.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteErrorConfigByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Department.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Department.Remove(entry);
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
