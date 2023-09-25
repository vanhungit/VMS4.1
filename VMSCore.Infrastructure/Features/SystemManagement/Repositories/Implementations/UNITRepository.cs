using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class UNITRepository : BaseRepository<UNIT>, IUNITRepository
    {
        public UNIT GetByCode(string Code)
        {
            return _context.UNIT.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteUNITeByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.UNIT.Where(i => i.Code == Code).FirstOrDefault();
                if (entry != null)
                {
                    _context.UNIT.Remove(entry);
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
