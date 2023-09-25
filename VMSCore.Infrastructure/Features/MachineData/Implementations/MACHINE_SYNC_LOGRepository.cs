using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_SYNC_LOGRepository : BaseRepository<MACHINE_SYNC_LOG>, Interfaces.IMACHINE_SYNC_LOGRepository
    {
        public MACHINE_SYNC_LOG GetByCode(string Code)
        {
            return _context.MACHINE_SYNC_LOG.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_SYNC_LOG()
        {
            int Trave = 0;
            var item = _context.MACHINE_SYNC_LOG.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_SYNC_LOG.Max(i => i.Sorted));
            }
            return Trave;
        }
        
        public string DeleteMACHINE_SYNC_LOGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_SYNC_LOG.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_SYNC_LOG.Remove(entry);
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
