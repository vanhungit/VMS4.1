using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DETECTOR_ERRORRepository : BaseRepository<DETECTOR_ERROR>, IDETECTOR_ERRORRepository
    {
        public DETECTOR_ERROR GetByCode(string Code)
        {
            return _context.DETECTOR_ERROR.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxDETECTOR_ERROR()
        {
            int Trave = 0;
            var item = _context.DETECTOR_ERROR.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.DETECTOR_ERROR.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteDETECTOR_ERRORByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.DETECTOR_ERROR.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.DETECTOR_ERROR.Remove(entry);
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
