using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_WARNINGRepository : BaseRepository<MACHINE_WARNING>, IMACHINE_WARNINGRepository
    {
        public MACHINE_WARNING GetByCode(string Code)
        {
            return _context.MACHINE_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_WARNING()
        {
            int Trave = 0;
            var item = _context.MACHINE_WARNING.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_WARNING.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteMACHINE_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_WARNING.Remove(entry);
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
