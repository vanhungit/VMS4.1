using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations
{
    public class FunctionGroupModuleObjectMappingRepository : BaseRepository<FunctionGroupModuleObjectMapping>, IFunctionGroupModuleObjectMappingRepository
    {
        public bool IsExistingFunctionGroupModuleObjectMapping(FunctionGroupModuleObjectMapping newEntity)
        {
            var entity = _context.FunctionGroupModuleObjectMapping.FirstOrDefault(x =>
              x.ObjectId == newEntity.ObjectId && x.Description == newEntity.Description && x.ParentId == newEntity.ParentId && x.Level == newEntity.Level &&
              x.Owner == newEntity.Owner && x.Active == newEntity.Active && x.ModuleType == newEntity.ModuleType && x.GroupType == newEntity.GroupType);
            return (entity != null);
        }
    }
}
