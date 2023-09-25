using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProductionOrderDetailMAPRepository : BaseRepository<ProductionOrderDetailMAP>, IProductionOrderDetailMAPRepository
    {
        public int GetMaxProductionOrderDetailMAP()
        {
            int Trave = 0;
            var item = _context.ProductionOrderDetailMAP.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.ProductionOrderDetailMAP.Max(i => i.Sorted));
            }
            return Trave;
        }
        public ProductionOrderDetailMAP GetByCode(string Code)
        {
            ProductionOrderDetailMAP objPro = new ProductionOrderDetailMAP();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailMAP.FirstOrDefault(x => x.Code == Code);
            if (item != null)
            {
                return (ProductionOrderDetailMAP)(item);
            }
            else
            {
                return objPro;
            }

        }
        public ProductionOrderDetailMAP GetByCodeMapSon(string Code)
        {
            ProductionOrderDetailMAP objPro = new ProductionOrderDetailMAP();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailMAP.FirstOrDefault(x => x.KeyCuon == Code);
            if (item != null)
            {
                return (ProductionOrderDetailMAP)(item);
            }
            else
            {
                return objPro;
            }

        }
        public ProductionOrderDetailMAP GetByCodeMapDad(string Code)
        {
            ProductionOrderDetailMAP objPro = new ProductionOrderDetailMAP();
            objPro.Code = "";
            var item = _context.ProductionOrderDetailMAP.FirstOrDefault(x => x.KeyBox == Code);
            if (item != null)
            {
                return (ProductionOrderDetailMAP)(item);
            }
            else
            {
                return objPro;
            }

        }
    }
}
