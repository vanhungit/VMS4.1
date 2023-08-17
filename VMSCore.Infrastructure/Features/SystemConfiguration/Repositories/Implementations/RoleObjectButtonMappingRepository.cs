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
              x.ObjectId == newEntity.ObjectId && x.ButtonId == newEntity.ButtonId && x.RoleId == newEntity.RoleId);
            return (entity != null);
        }
        public List<RoleObjectButtonMappingViewModel> GetRoleObjectButtonMappingByRole(string roleId)
        {
            var result = (from c in _context.ObjectButtonMapping
                          join o in _context.ObjectEntity on c.ObjectId equals o.ObjectId
                          join b in _context.Button on c.ButtonId equals b.Id
                          join ro in _context.RoleObjectButtonMapping on new { c.ButtonId, c.ObjectId, RoleId = roleId} equals new { ro.ButtonId, ro.ObjectId,ro.RoleId } into rot
                          from rob in rot.DefaultIfEmpty()
                          orderby o.ObjectName descending,b.Name
                          select new RoleObjectButtonMappingViewModel()
                          {
                              ButtonId = b.Id,
                              ButtonName = b.Name,
                              ObjectId = o.ObjectId,
                              ObjectName = o.ObjectName,
                              RoleId = rob.RoleId,
                              InUse = rob != null && rob.RoleId.Equals(roleId) ? true : false
                          }).ToList() ;
            return result.Any() ? result : new List<RoleObjectButtonMappingViewModel>();
        }

    }
}
