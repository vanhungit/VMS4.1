using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRIMARY_PACKING_ERRORRepository : BaseRepository<PRIMARY_PACKING_ERROR>, IPRIMARY_PACKING_ERRORRepository
    {
        public PRIMARY_PACKING_ERROR GetByCode(string Code)
        {
            return _context.PRIMARY_PACKING_ERROR.FirstOrDefault(x => x.Code == Code);
        }
        public string DeletePRIMARY_PACKING_ERRORByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRIMARY_PACKING_ERROR.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRIMARY_PACKING_ERROR.Remove(entry);
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
