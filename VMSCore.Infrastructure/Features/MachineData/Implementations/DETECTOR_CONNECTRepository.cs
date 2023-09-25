using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DETECTOR_CONNECTRepository : BaseRepository<DETECTOR_CONNECT>, IDETECTOR_CONNECTRepository
    {
        public DETECTOR_CONNECT GetByCode(string Code)
        {
            return _context.DETECTOR_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxDETECTOR_CONNECT()
        {
            int Trave = 0;
            var item = _context.DETECTOR_CONNECT.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.DETECTOR_CONNECT.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteDETECTOR_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.DETECTOR_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.DETECTOR_CONNECT.Remove(entry);
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
