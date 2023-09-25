using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRIMARY_PACKING_DATARepository : BaseRepository<PRIMARY_PACKING_DATA>, IPRIMARY_PACKING_DATARepository
    {
        public PRIMARY_PACKING_DATA GetByCode(string Code)
        {
            return _context.PRIMARY_PACKING_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxPRIMARY_PACKING_DATA()
        {
            int Trave = 0;
            var item = _context.PRIMARY_PACKING_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.PRIMARY_PACKING_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeletePRIMARY_PACKING_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRIMARY_PACKING_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRIMARY_PACKING_DATA.Remove(entry);
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
