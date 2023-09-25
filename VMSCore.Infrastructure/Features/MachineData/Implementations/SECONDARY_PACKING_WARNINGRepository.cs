using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class SECONDARY_PACKING_WARNINGRepository : BaseRepository<SECONDARY_PACKING_WARNING>, ISECONDARY_PACKING_WARNINGRepository
    {
        public SECONDARY_PACKING_WARNING GetByCode(string Code)
        {
            return _context.SECONDARY_PACKING_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteSECONDARY_PACKING_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.SECONDARY_PACKING_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.SECONDARY_PACKING_WARNING.Remove(entry);
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
