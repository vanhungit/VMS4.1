using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class ProductGroupRepository : BaseRepository<ProductGroup>, IProductGroupRepository
    {
        public ProductGroup GetByCode(string Code)
        {
            return _context.ProductGroup.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteProductGroupByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ProductGroup.Where(i => i.Code == Code).FirstOrDefault();
                if (entry != null)
                {
                    _context.ProductGroup.Remove(entry);
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
