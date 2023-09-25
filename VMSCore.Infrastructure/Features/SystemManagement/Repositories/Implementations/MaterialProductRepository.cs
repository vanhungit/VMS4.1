using System;
using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class MaterialProductRepository : BaseRepository<MaterialProduct>, IMaterialProductRepository
    {
        public MaterialProduct GetByCode(string Code)
        {
            return _context.MaterialProduct.FirstOrDefault(x => x.Code == Code);
        }
        public List<BomProductView> GetViewBomByProduct(string ProductCode)
        {
            var hasName = string.IsNullOrWhiteSpace(ProductCode);
            var objects = (from o in _context.MaterialProduct
                           join p in _context.Product on o.ProductCode equals p.Code
                           join c in _context.Product on o.MaterialCode equals c.Code
                           where hasName == true || o.ProductCode.Contains(ProductCode) || o.ProductCode.Contains(ProductCode)
                           //orderby o.Name
                           select new BomProductView()
                           {
                               Id = o.Id,
                               Code = o.Code,
                               ProductCode = o.ProductCode,
                               ProductName = p.Name,
                               MaterialCode = o.MaterialCode,
                               MaterialName = c.Name,
                               CreatorId = o.CreatorId,
                               CreationTime = o.CreationTime,
                               LastModifierId = o.LastModifierId,
                               LastModificationTime = o.LastModificationTime,
                               Active = (bool)o.Active
                           }).ToList();
            return objects.Any() ? objects : new List<BomProductView>();
        }
        public string DeleteUNITCONVERTeByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MaterialProduct.Where(i => i.Code == Code).FirstOrDefault();
                if (entry != null)
                {
                    _context.MaterialProduct.Remove(entry);
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
