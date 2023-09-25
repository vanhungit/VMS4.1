using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class UNITCONVERTRepository : BaseRepository<UNITCONVERT>, IUNITCONVERTRepository
    {
        public UNITCONVERT GetByCode(string Code)
        {
            return _context.UNITCONVERT.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteUNITCONVERTeByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.UNITCONVERT.Where(i => i.Code == Code).FirstOrDefault();
                if (entry != null)
                {
                    _context.UNITCONVERT.Remove(entry);
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
