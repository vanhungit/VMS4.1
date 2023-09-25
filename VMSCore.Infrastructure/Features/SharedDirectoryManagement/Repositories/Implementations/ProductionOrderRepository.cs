using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProductionOrderRepository : BaseRepository<ProductionOrder>, IProductionOrderRepository
    {
        public int GetMaxProductionOrder()
        {
            int Trave = 0;
            var item = _context.ProductionOrder.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.ProductionOrder.Max(i => i.Sorted));
            }
            return Trave;
        }
        public ProductionOrder GetByCode(string Code)
        {
            ProductionOrder objPro = new ProductionOrder();
            objPro.Code = "";
            var item = _context.ProductionOrder.FirstOrDefault(x => x.Code == Code);
            if(item !=null)
            {
                return (ProductionOrder)(item);
            }
            else
            {
                return objPro;
            }
            
        }
        public string DeleteProductionOrderByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ProductionOrder.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.ProductionOrder.Remove(entry);
                    _context.SaveChanges();
                    obj = entry.Code;
                    return obj;
                }
                else
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                return obj;
            }
        }
    }
}
