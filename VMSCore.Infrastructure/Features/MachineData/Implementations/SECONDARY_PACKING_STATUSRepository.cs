using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class SECONDARY_PACKING_STATUSRepository : BaseRepository<SECONDARY_PACKING_STATUS>, ISECONDARY_PACKING_STATUSRepository
    {
        public SECONDARY_PACKING_STATUS GetByCode(string Code)
        {
            return _context.SECONDARY_PACKING_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteSECONDARY_PACKING_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.SECONDARY_PACKING_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.SECONDARY_PACKING_STATUS.Remove(entry);
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
