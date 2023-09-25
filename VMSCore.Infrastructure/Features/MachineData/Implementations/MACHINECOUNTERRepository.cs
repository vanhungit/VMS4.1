using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class MACHINECOUNTERRepository : BaseRepository<MACHINECOUNTER>, IMACHINECOUNTERRepository
    {
        public MACHINECOUNTER GetByCode(string Code)
        {
            return _context.MACHINECOUNTER.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteMACHINECOUNTERByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.MACHINECOUNTER.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.MACHINECOUNTER.Remove(entry);
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
