using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRINT_MAKING_DATARepository : BaseRepository<PRINT_MAKING_DATA>, IPRINT_MAKING_DATARepository
    {
        public PRINT_MAKING_DATA GetByCode(string Code)
        {
            return _context.PRINT_MAKING_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxPRINT_MAKING_DATA()
        {
            int Trave = 0;
            var item = _context.PRINT_MAKING_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.PRINT_MAKING_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeletePRINT_MAKING_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRINT_MAKING_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRINT_MAKING_DATA.Remove(entry);
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
