using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class StageRepository : BaseRepository<Stage>, IStageRepository
    {
        public Stage GetByCode(string Code)
        {
            return _context.Stage.FirstOrDefault(x => x.Code == Code);
        }
    }
}
