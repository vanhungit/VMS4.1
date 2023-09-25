using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DETECTOR_DATARepository : BaseRepository<DETECTOR_DATA>, IDETECTOR_DATARepository
    {
        public DETECTOR_DATA GetByCode(string Code)
        {
            return _context.DETECTOR_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxDETECTOR_DATA()
        {
            int Trave = 0;
            var item = _context.DETECTOR_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.DETECTOR_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteDETECTOR_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.DETECTOR_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.DETECTOR_DATA.Remove(entry);
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
