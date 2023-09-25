using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_SYNCRepository : BaseRepository<MACHINE_SYNC>, IMACHINE_SYNCRepository
    {
        public MACHINE_SYNC GetByCode(string Code)
        {
            return _context.MACHINE_SYNC.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_SYNC()
        {
            int Trave = 0;
            var item = _context.MACHINE_SYNC.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_SYNC.Max(i => i.Sorted));
            }
            return Trave;
        }
        public int GetMaxMACHINE_SYNC_Record()
        {
            int Trave = 0;
            var item = _context.MACHINE_SYNC.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_SYNC.Max(i => i.SortedRecord));
            }
            return Trave;
        }
        public string DeleteMACHINE_SYNCByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_SYNC.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_SYNC.Remove(entry);
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
