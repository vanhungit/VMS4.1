using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class ProductTypeRepository : BaseRepository<ProductType>, IProductTypeRepository
    {
        public ProductType GetByCode(string Code)
        {
            return _context.ProductType.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteProductTypeByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ProductType.Where(i => i.Code == Code).FirstOrDefault();
                if (entry != null)
                {
                    _context.ProductType.Remove(entry);
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
