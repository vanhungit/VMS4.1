using System;
using System.Linq;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Extensions;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    public partial class frmStaff : Form
    {
        public frmStaff()
        {
            InitializeComponent();
            var staff = _staffRepository.GetAll();
            dataGridView1.DataSource = staff.Select(x=> 
            new 
            {
                LastName = x.LastName,
                Code =x.Code,
                Name=x.Name,
                Phone=x.Phone,
                Description=x.Description,
                BirthDay=x.BirthDay
            }).ToList();
        }

        private void frmStaff_Load(object sender, EventArgs e)
        {

        }
        private readonly StaffRepository _staffRepository = new StaffRepository();
        private readonly RepositoryLibrary _repositoryLibrary = new RepositoryLibrary();
        private void btnStaff1_Click(object sender, EventArgs e)
        {
            var data = new Staff()
            {
                Id = Guid.NewGuid().ToString(),
                Code = "S001",
                Name = "John Doe",
                Email = "johndoe@example.com",
                Username = "johndoe",
                Phone = "1234567890",
                Address = "123 Main St",
                CompanyId = "25633629-5675-4574-8492-5072a2a7e7e4",
                Password = RepositoryLibrary.GetMd5Sum("testing"),
                KeyPassword = "key123",
                KeyActiveEmail = "keyemail123",
                Description = "Description for John Doe",
                CreatorId = "C001",
                LastModifierId = "C002",
                Active = true,
                LogDate = DateTime.Now,
                CreationTime = DateTime.Now,
                LastModificationTime = DateTime.Now,
                FristName = "John",
                LastName = "Doe",
                FullName = "John Doe",
                Alias = "JD",
                sex = true,
                CountryId = "CO001",
                Tel_1 = "9876543210",
                Tel_2 = "5432167890",
                Mobile = "9876543210",
                Fax = "1234567890",
                BirthDay = new DateTime(1990, 5, 10),
                Married = false,
                PositionTitle = "Manager",
                JobTitle = "Software Engineer",
                BranchId = "B001",
                DepartmentId = "D001",
                TeamId = "T001",
                PersonalTaxId = "TAX001",
                CityId = "CTY001",
                DistrictId = "DST001",
                ManagerId = "M001",
                Employeetype = "Full-Time"
            };
            _staffRepository.Add(data);
        }

        private void btnStaff2_Click(object sender, EventArgs e)
        {
            var data = new Staff()
            {
                Id = Guid.NewGuid().ToString(),
                Code = "S002",
                Name = "Jane Smith",
                Email = "janesmith@example.com",
                Username = "janesmith",
                Phone = "0987654321",
                Address = "456 Elm St",
                CompanyId = "25633629-5675-4574-8492-5072a2a7e7e4",
                Password = RepositoryLibrary.GetMd5Sum("testing"),
                KeyPassword = "key456",
                KeyActiveEmail = "keyemail456",
                Description = "Description for Jane Smith",
                CreatorId = "C001",
                LastModifierId = "C003",
                Active = true,
                LogDate = DateTime.Now,
                CreationTime = DateTime.Now,
                LastModificationTime = DateTime.Now,
                FristName = "Jane",
                LastName = "Smith",
                FullName = "Jane Smith",
                Alias = "JS",
                sex = false,
                CountryId = "CO001",
                Tel_1 = "8765432109",
                Tel_2 = "2109876543",
                Mobile = "8765432109",
                Fax = "0987654321",
                BirthDay = new DateTime(1988, 8, 15),
                Married = true,
                PositionTitle = "Supervisor",
                JobTitle = "Sales Representative",
                BranchId = "B002",
                DepartmentId = "D001",
                TeamId = "T002",
                PersonalTaxId = "TAX002",
                CityId = "CTY002",
                DistrictId = "DST002",
                ManagerId = "M001",
                Employeetype = "Full-Time"
            };
            _staffRepository.Add(data);
        }

        private void btnStaff3_Click(object sender, EventArgs e)
        {
            var data = new Staff()
            {
                Id = Guid.NewGuid().ToString(),
                Code = "S003",
                Name = "Emily Johnson",
                Email = "emilyjohnson@example.com",
                Username = "emilyjohnson",
                Phone = "9876543210",
                Address = "789 Oak St",
                CompanyId = "25633629-5675-4574-8492-5072a2a7e7e4",
                Password = RepositoryLibrary.GetMd5Sum("testing"),
                KeyPassword = "key789",
                KeyActiveEmail = "keyemail789",
                Description = "Description for Emily Johnson",
                CreatorId = "C001",
                LastModifierId = "C004",
                Active = true,
                LogDate = DateTime.Now,
                CreationTime = DateTime.Now,
                LastModificationTime = DateTime.Now,
                FristName = "Emily",
                LastName = "Johnson",
                FullName = "Emily Johnson",
                Alias = "EJ",
                sex = false,
                CountryId = "CO001",
                Tel_1 = "8765432109",
                Tel_2 = "2109876543",
                Mobile = "8765432109",
                Fax = "0987654321",
                BirthDay = new DateTime(1995, 3, 20),
                Married = false,
                PositionTitle = "Engineer",
                JobTitle = "Software Developer",
                BranchId = "B002",
                DepartmentId = "D002",
                TeamId = "T003",
                PersonalTaxId = "TAX003",
                CityId = "CTY002",
                DistrictId = "DST002",
                ManagerId = "M002",
                Employeetype = "Full-Time"
            };
            _staffRepository.Add(data);
        }

        
    }
}
