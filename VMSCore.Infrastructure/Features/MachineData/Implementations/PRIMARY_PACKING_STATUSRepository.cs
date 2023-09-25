using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRIMARY_PACKING_STATUSRepository : BaseRepository<PRIMARY_PACKING_STATUS>, IPRIMARY_PACKING_STATUSRepository
    {
        public PRIMARY_PACKING_STATUS GetByCode(string Code)
        {
            return _context.PRIMARY_PACKING_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        public string DeletePRIMARY_PACKING_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRIMARY_PACKING_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRIMARY_PACKING_STATUS.Remove(entry);
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
