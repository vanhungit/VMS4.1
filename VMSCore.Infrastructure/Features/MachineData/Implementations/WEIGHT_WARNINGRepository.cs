using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class WEIGHT_WARNINGRepository : BaseRepository<WEIGHT_WARNING>, IWEIGHT_WARNINGRepository
    {
        public WEIGHT_WARNING GetByCode(string Code)
        {
            return _context.WEIGHT_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteWEIGHT_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WEIGHT_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WEIGHT_WARNING.Remove(entry);
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
