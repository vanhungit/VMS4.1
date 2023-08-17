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
                          join o in _context.ObjectButtonMapping on new { Id = b.Id, ObjectId = objectId } equals new { Id = o.ButtonId, o.ObjectId } into ot
                          from og in ot.DefaultIfEmpty()
                          select new ObjectButtonMappingViewModel()
                          {
                              ButtonId = b.Id,
                              ButtonName = b.Name,
                              InUse = og != null && og.ObjectId.Equals(objectId) ? true : false
                          }).OrderByDescending(x => x.InUse).ToList();
            return result.Any() ? result : new List<ObjectButtonMappingViewModel>();
        }
        public List<ObjectButtonMapping> GetButtonByObjectEnity(string objectId)
        {

            var result = _context.ObjectButtonMapping.Where(x => x.ObjectId.Equals(objectId)).ToList();

            return result.Any() ? result : new List<ObjectButtonMapping>();
        }
    }
}
