using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRINT_MAKING_STATUSRepository : BaseRepository<PRINT_MAKING_STATUS>, IPRINT_MAKING_STATUSRepository
    {
        public PRINT_MAKING_STATUS GetByCode(string Code)
        {
            return _context.PRINT_MAKING_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        
        public int GetMaxPRINT_MAKING_STATUS()
        {
            int Trave = 0;
            var item = _context.PRINT_MAKING_STATUS.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.PRINT_MAKING_STATUS.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeletePRINT_MAKING_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRINT_MAKING_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRINT_MAKING_STATUS.Remove(entry);
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
