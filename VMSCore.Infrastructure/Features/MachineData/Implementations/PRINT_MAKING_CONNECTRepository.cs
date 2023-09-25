using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRINT_MAKING_CONNECTRepository : BaseRepository<PRINT_MAKING_CONNECT>, IPRINT_MAKING_CONNECTRepository
    {
        public PRINT_MAKING_CONNECT GetByCode(string Code)
        {
            return _context.PRINT_MAKING_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxPRINT_MAKING_CONNECT()
        {
            int Trave = 0;
            var item = _context.PRINT_MAKING_CONNECT.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.PRINT_MAKING_CONNECT.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeletePRINT_MAKING_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRINT_MAKING_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRINT_MAKING_CONNECT.Remove(entry);
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
