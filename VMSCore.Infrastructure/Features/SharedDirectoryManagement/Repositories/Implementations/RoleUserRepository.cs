using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class RoleUserRepository : BaseRepository<RoleUser>, IRoleUserRepository
    {
        public RoleUser GetRoleUserByUserId(string userId)
        {
            return _context.RoleUser.FirstOrDefault(x => x.UserId == userId);
        }
        public List<RoleUserViewModel> GetRoleStaffByStaffId(string userId)
        {
            var result = (from r in _context.Role
                          from ur in _context.RoleUser.Where(x => x.RoleId == r.Id && x.UserId == userId).DefaultIfEmpty()
                          select new RoleUserViewModel()
                          {
                              RoleId = r.Id,
                              RoleName = r.Name,
                              IsRoleAssigned = ur != null && ur.UserId == userId ? true : false
                          }).ToList();
            return result.Any() ? result : new List<RoleUserViewModel>();
        }
        public bool IsAdminRole(string userId)
        {
            var result = (from r in _context.Role
                          join ur in _context.RoleUser on r.Id equals ur.RoleId
                          where ur.UserId == userId && r.Code == "admin"
                          select true
                          ).FirstOrDefault();
            return result;


        }
    }
}
