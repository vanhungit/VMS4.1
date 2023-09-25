using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRINT_MAKING_WARNINGRepository : BaseRepository<PRINT_MAKING_WARNING>, IPRINT_MAKING_WARNINGRepository
    {
        public PRINT_MAKING_WARNING GetByCode(string Code)
        {
            return _context.PRINT_MAKING_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxPRINT_MAKING_WARNING()
        {
            int Trave = 0;
            var item = _context.PRINT_MAKING_WARNING.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.PRINT_MAKING_WARNING.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeletePRINT_MAKING_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRINT_MAKING_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRINT_MAKING_WARNING.Remove(entry);
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
