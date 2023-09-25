using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class WEIGHT_ERRORRepository : BaseRepository<WEIGHT_ERROR>, IWEIGHT_ERRORRepository
    {
        public WEIGHT_ERROR GetByCode(string Code)
        {
            return _context.WEIGHT_ERROR.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteWEIGHT_ERRORByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WEIGHT_ERROR.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WEIGHT_ERROR.Remove(entry);
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
