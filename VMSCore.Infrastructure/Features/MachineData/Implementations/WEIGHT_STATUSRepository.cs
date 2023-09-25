using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class WEIGHT_STATUSRepository : BaseRepository<WEIGHT_STATUS>, IWEIGHT_STATUSRepository
    {
        public WEIGHT_STATUS GetByCode(string Code)
        {
            return _context.WEIGHT_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteWEIGHT_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WEIGHT_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WEIGHT_STATUS.Remove(entry);
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
