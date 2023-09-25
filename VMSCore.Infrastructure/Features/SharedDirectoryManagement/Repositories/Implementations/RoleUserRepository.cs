using System;
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
        public string DeleteRoleUserByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.RoleUser.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.RoleUser.Remove(entry);
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
        public RoleUser GetRoleUserByUserId(string userId)
        {
            return _context.RoleUser.FirstOrDefault(x => x.UserCode == userId);
        }
        public List<RoleUserViewModel> GetRoleStaffByStaffId(string userId)
        {
            var result = (from r in _context.Role
                          from ur in _context.RoleUser.Where(x => x.UserCode == r.Code && x.UserCode == userId).DefaultIfEmpty()
                          select new RoleUserViewModel()
                          {
                              RoleCode = r.Code,
                              RoleName = r.Name,
                              Active = ur != null && ur.UserCode == userId ? true : false
                          }).ToList();
            return result.Any() ? result : new List<RoleUserViewModel>();
        }
        public List<RoleUserViewModel> GetRoleStaffByRole(string Role)
        {
            var result =
                           (from ur in _context.RoleUser
                            join r in _context.Role on ur.RoleCode equals r.Code
                            join o in _context.Staff on ur.UserCode equals o.Code
                            where ur.RoleCode == Role
                            select new RoleUserViewModel()
                            {
                                Code = ur.Code,
                                RoleCode = ur.RoleCode,
                                RoleName = r.Name,
                                UserCode = ur.UserCode,
                                UserName = ur.UserName,
                                StaffName = o.Name,
                                Active = ur.Active != null ? (bool)ur.Active : false
                            }).ToList();
            return result.Any() ? result : new List<RoleUserViewModel>();
        }
        public List<RoleUserViewModel> GetRoleStaffByRoleAll()
        {
            var result = 
                          (from ur in _context.RoleUser
                          join r in _context.Role on ur.RoleCode equals r.Code
                          join o in _context.Staff on ur.UserCode equals o.Code
                          select new RoleUserViewModel()
                          {
                              Code = ur.Code,
                              RoleCode = ur.RoleCode,
                              RoleName = r.Name,
                              UserCode = ur.UserCode,
                              UserName = ur.UserName,
                              StaffName = o.Name,
                              Active = ur.Active != null ? (bool)ur.Active : false
                          }).ToList();
            return result.Any() ? result : new List<RoleUserViewModel>();
        }
        public bool IsAdminRole(string userId)
        {
            var result = (from r in _context.Role
                          join ur in _context.RoleUser on r.Code equals ur.UserCode
                          where ur.UserCode == userId && r.Code == "admin"
                          select true
                          ).FirstOrDefault();
            return result;


        }
    }
}
