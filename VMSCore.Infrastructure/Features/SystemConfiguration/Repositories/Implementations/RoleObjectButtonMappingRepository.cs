using System;
using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations
{
    public class RoleObjectButtonMappingRepository : BaseRepository<RoleObjectButtonMapping>
    {
        public bool IsExistingRoleObjectButtonMapping(RoleObjectButtonMapping newEntity)
        {
            var entity = _context.RoleObjectButtonMapping.FirstOrDefault(x =>
              x.ObjectCode == newEntity.ObjectCode && x.ButtonCode == newEntity.ButtonCode && x.RoleCode == newEntity.RoleCode);
            return (entity != null);
        }
        public string DeleteRoleObjectButtonMappingByID(string Role)
        {
            string obj = "";
            try
            {
                var entry = _context.RoleObjectButtonMapping.Where(i => i.RoleCode == Role && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.RoleObjectButtonMapping.Remove(entry);
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
        public List<RoleObjectButtonMappingViewModel> GetRoleObjectButtonMappingByRole(string roleId)
        {
            var result = (from c in _context.ObjectButtonMapping
                          join o in _context.ObjectEntity on c.ObjectCode equals o.Code
                          join b in _context.Button on c.ButtonCode equals b.Code
                          join ro in _context.RoleObjectButtonMapping on new { c.ButtonCode, c.ObjectCode, RoleCode = roleId } equals new { ro.ButtonCode, ro.ObjectCode, ro.RoleCode } into rot
                          from rob in rot.DefaultIfEmpty()
                          //orderby o.ObjectName descending, b.Name
                          select new RoleObjectButtonMappingViewModel()
                          {
                              ButtonCode = b.Code,
                              ButtonName = b.Name,
                              ObjectCode = o.Code,
                              ObjectName = o.Name,
                              RoleCode = rob.RoleCode,
                              InUse = rob != null && rob.RoleCode.Equals(roleId) ? true : false
                          }).ToList();
            return result.Any() ? result : new List<RoleObjectButtonMappingViewModel>();
        }
        public List<RoleObjectButtonMappingViewModel> GetRoleObjectButtonMappingByRoleActive(string roleId)
        {
            var result = (from c in _context.ObjectButtonMapping
                          join o in _context.ObjectEntity on c.ObjectCode equals o.Code
                          join b in _context.Button on c.ButtonCode equals b.Code
                          join ro in _context.RoleObjectButtonMapping on new { c.ButtonCode, c.ObjectCode, RoleCode = roleId } equals new { ro.ButtonCode, ro.ObjectCode, ro.RoleCode } into rot
                          from rob in rot.DefaultIfEmpty()
                          group new { o.Name, rob } by new { rob.ObjectCode, rob.RoleCode, o.Name } into grouped
                          //orderby o.Name descending, b.Name
                          select new RoleObjectButtonMappingViewModel()
                          {
                              //ButtonCode = b.Code,
                              //ButtonName = b.Name,
                              ObjectCode = grouped.Key.ObjectCode,
                              ObjectName = grouped.Key.Name,
                              RoleCode = grouped.Key.RoleCode,
                              InUse = grouped.Key.ObjectCode != null && grouped.Key.RoleCode.Equals(roleId) ? true : false
                          }).ToList();
            return result.Any() ? result : new List<RoleObjectButtonMappingViewModel>();
        }
    }
}
