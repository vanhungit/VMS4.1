using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DETECTOR_WARNINGRepository : BaseRepository<DETECTOR_WARNING>, IDETECTOR_WARNINGRepository
    {
        public DETECTOR_WARNING GetByCode(string Code)
        {
            return _context.DETECTOR_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxDETECTOR_WARNING()
        {
            int Trave = 0;
            var item = _context.DETECTOR_WARNING.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.DETECTOR_WARNING.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteDETECTOR_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.DETECTOR_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.DETECTOR_WARNING.Remove(entry);
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
