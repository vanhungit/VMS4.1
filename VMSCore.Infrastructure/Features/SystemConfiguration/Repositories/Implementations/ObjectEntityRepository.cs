using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Interfaces;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations
{
    public class ObjectEntityRepository : BaseRepository<ObjectEntity>, IObjectEntityRepository
    {

        public List<ObjectEntityViewModel> Search(string name)
        {
            var hasName = string.IsNullOrWhiteSpace(name);
            var objects = (from o in _context.ObjectEntity
                           where hasName == true || o.ObjectName.Contains(name) || o.ObjectNameEn.Contains(name)
                           orderby o.ObjectName
                           select new ObjectEntityViewModel()
                           {
                               ObjectId = o.ObjectId,
                               ObjectName = o.ObjectName,
                               ObjectNameEn = o.ObjectNameEn,
                               Description = o.Description,
                               Active = o.Active
                           }).ToList();
            return objects.Any() ? objects : new List<ObjectEntityViewModel>();
        }
    }
}
