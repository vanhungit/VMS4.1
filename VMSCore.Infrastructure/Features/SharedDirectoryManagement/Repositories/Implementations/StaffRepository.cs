using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        public Staff GetByCode(string Code)
        {
            return _context.Staff.FirstOrDefault(x => x.Code == Code);
        }
        public Staff GetStaffByUserName(string UserName)
        {
            Staff obj = new Staff();
            var result = _context.Staff.Where(i => i.Username == UserName && i.Active == true).FirstOrDefault();
            if (result != null)
            {
                obj = (Staff)result;
            }          
            return obj;
        }
       
    }
}
