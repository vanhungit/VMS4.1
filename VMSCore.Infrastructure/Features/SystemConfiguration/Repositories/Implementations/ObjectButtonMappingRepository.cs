using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Interfaces;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations
{
    public class ObjectButtonMappingRepository : BaseRepository<ObjectButtonMapping>, IObjectButtonMappingRepository
    {
        public List<ObjectButtonMappingViewModel> GetButton(string objectId)
        {
            var result = (from b in _context.Button
                          join o in _context.ObjectButtonMapping on new { Id = b.Code, ObjectCode = objectId } equals new { Id = o.ButtonCode, o.ObjectCode } into ot
                          from og in ot.DefaultIfEmpty()
                          select new ObjectButtonMappingViewModel()
                          {
                              ButtonCode = b.Code,
                              ButtonName = b.Name,
                              InUse = og != null && og.ObjectCode.Equals(objectId) ? true : false
                          }).OrderByDescending(x => x.InUse).ToList();
            return result.Any() ? result : new List<ObjectButtonMappingViewModel>();
        }
        public List<ObjectButtonMapping> GetButtonByObjectEnity(string objectId)
        {

            var result = _context.ObjectButtonMapping.Where(x => x.ObjectCode.Equals(objectId)).ToList();

            return result.Any() ? result : new List<ObjectButtonMapping>();
        }
    }
}
