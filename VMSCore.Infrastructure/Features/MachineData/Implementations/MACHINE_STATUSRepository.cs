using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_STATUSRepository : BaseRepository<MACHINE_STATUS>, IMACHINE_STATUSRepository
    {
        public MACHINE_STATUS GetByCode(string Code)
        {
            return _context.MACHINE_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_STATUS()
        {
            int Trave = 0;
            var item = _context.MACHINE_STATUS.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_STATUS.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteMACHINE_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_STATUS.Remove(entry);
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
