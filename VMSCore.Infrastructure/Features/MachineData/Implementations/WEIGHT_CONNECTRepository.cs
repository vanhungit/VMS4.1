using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class WEIGHT_CONNECTRepository : BaseRepository<WEIGHT_CONNECT>, IWEIGHT_CONNECTRepository
    {
        public int GetMaxWEIGHT_CONNECT()
        {
            int Trave = 0;
            var item = _context.WEIGHT_CONNECT.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.WEIGHT_CONNECT.Max(i => i.Sorted));
            }
            return Trave;
        }
        public WEIGHT_CONNECT GetByCode(string Code)
        {
            return _context.WEIGHT_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteWEIGHT_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WEIGHT_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WEIGHT_CONNECT.Remove(entry);
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
