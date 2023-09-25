using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_ERRORRepository : BaseRepository<MACHINE_ERROR>, IMACHINE_ERRORRepository
    {
        public MACHINE_ERROR GetByCode(string Code)
        {
            return _context.MACHINE_ERROR.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_ERROR()
        {
            int Trave = 0;
            var item = _context.MACHINE_ERROR.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_ERROR.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteMACHINE_ERRORByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_ERROR.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_ERROR.Remove(entry);
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
