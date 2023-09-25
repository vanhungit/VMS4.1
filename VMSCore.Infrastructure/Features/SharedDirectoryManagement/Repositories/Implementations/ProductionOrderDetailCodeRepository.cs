using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProductionOrderDetailCodeRepository : BaseRepository<ProductionOrderDetailCode>, IProductionOrderDetailCodeRepository
    {
        public int GetMaxProductionOrderDetailCode()
        {
            int Trave = 0;
            var item = _context.ProductionOrderDetailCode.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.ProductionOrderDetailCode.Max(i => i.Sorted));
            }
            return Trave;
        }
        public ProductionOrderDetailCode GetByCode(string Code)
        {
            ProductionOrderDetailCode objPro = new ProductionOrderDetailCode();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailCode.Where(x => x.Code == Code).FirstOrDefault();
            if (item != null)
            {
                return (ProductionOrderDetailCode)(item);
            }
            else
            {
                return objPro;
            }

        }
        public ProductionOrderDetailCode GetByCodeGen(string Code)
        {
            ProductionOrderDetailCode objPro = new ProductionOrderDetailCode();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailCode.Where(x => x.Code1 == Code).FirstOrDefault();
            if (item != null)
            {
                return (ProductionOrderDetailCode)(item);
            }
            else
            {
                return objPro;
            }

        }
    }
}
