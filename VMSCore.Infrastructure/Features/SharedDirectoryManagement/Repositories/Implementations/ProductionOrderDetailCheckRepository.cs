using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProductionOrderDetailCheckRepository : BaseRepository<ProductionOrderDetailCheck>, IProductionOrderDetailCheckRepository
    {
        public int GetMaxProductionOrderDetailCheck()
        {
            int Trave = 0;
            var item = _context.ProductionOrderDetailCheck.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.ProductionOrderDetailCheck.Max(i => i.Sorted));
            }
            return Trave;
        }
        public ProductionOrderDetailCheck GetByCode(string Code)
        {
            ProductionOrderDetailCheck objPro = new ProductionOrderDetailCheck();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailCheck.FirstOrDefault(x => x.Code == Code);
            if (item != null)
            {
                return (ProductionOrderDetailCheck)(item);
            }
            else
            {
                return objPro;
            }

        }
        public ProductionOrderDetailCheck GetByCodeGen(string Code)
        {
            ProductionOrderDetailCheck objPro = new ProductionOrderDetailCheck();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailCheck.FirstOrDefault(x => x.Code1 == Code);
            if (item != null)
            {
                return (ProductionOrderDetailCheck)(item);
            }
            else
            {
                return objPro;
            }

        }
    }
}
