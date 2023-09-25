using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_DATARepository : BaseRepository<MACHINE_DATA>, IMACHINE_DATARepository
    {
        public MACHINE_DATA GetByCode(string Code)
        {
            return _context.MACHINE_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_DATA()
        {
            int Trave = 0;
            var item = _context.MACHINE_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteMACHINE_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_DATA.Remove(entry);
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
