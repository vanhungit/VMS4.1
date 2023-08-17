
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemOperationManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemOperationManagement.Repositories.Implementations
{
    public class ProductionOrderRepository : BaseRepository<ProductionOrder>, IProductionOrderRepository
    {
    }
}
