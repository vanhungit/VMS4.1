using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINE_CONNECTRepository : BaseRepository<MACHINE_CONNECT>, IMACHINE_CONNECTRepository
    {
        public MACHINE_CONNECT GetByCode(string Code)
        {
            return _context.MACHINE_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxMACHINE_CONNECT()
        {
            int Trave = 0;
            var item = _context.MACHINE_CONNECT.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.MACHINE_CONNECT.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteMACHINE_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINE_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINE_CONNECT.Remove(entry);
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
