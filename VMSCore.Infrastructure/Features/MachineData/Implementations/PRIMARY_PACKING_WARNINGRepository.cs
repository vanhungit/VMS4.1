using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRIMARY_PACKING_WARNINGRepository : BaseRepository<PRIMARY_PACKING_WARNING>, IPRIMARY_PACKING_WARNINGRepository
    {
        public PRIMARY_PACKING_WARNING GetByCode(string Code)
        {
            return _context.PRIMARY_PACKING_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public string DeletePRIMARY_PACKING_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRIMARY_PACKING_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRIMARY_PACKING_WARNING.Remove(entry);
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
