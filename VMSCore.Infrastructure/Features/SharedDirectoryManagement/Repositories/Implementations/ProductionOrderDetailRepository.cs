using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProductionOrderDetailRepository : BaseRepository<ProductionOrderDetail>, IProductionOrderDetailRepository
    {
        public ProductionOrderDetail GetByCode(string Code)
        {
            ProductionOrderDetail objPro = new ProductionOrderDetail();
            objPro.Code = "";
            var item = _context.ProductionOrderDetail.FirstOrDefault(x => x.ProductionOrderCode == Code);
            if (item != null)
            {
                return (ProductionOrderDetail)(item);
            }
            else
            {
                return objPro;
            }

        }
        public string DeleteProductionOrderDetailByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ProductionOrderDetail.Where(i => i.ProductionOrderCode == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.ProductionOrderDetail.Remove(entry);
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
