using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DETECTOR_STATUSRepository : BaseRepository<DETECTOR_STATUS>, IDETECTOR_STATUSRepository
    {
        public DETECTOR_STATUS GetByCode(string Code)
        {
            return _context.DETECTOR_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxDETECTOR_STATUS()
        {
            int Trave = 0;
            var item = _context.DETECTOR_STATUS.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.DETECTOR_STATUS.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteDETECTOR_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.DETECTOR_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.DETECTOR_STATUS.Remove(entry);
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
