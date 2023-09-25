using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class WEIGHT_DATARepository : BaseRepository<WEIGHT_DATA>, IWEIGHT_DATARepository
    {
        public WEIGHT_DATA GetByCode(string Code)
        {
            return _context.WEIGHT_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxWEIGHT_DATA()
        {
            int Trave = 0;
            var item = _context.WEIGHT_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.WEIGHT_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteWEIGHT_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WEIGHT_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WEIGHT_DATA.Remove(entry);
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
