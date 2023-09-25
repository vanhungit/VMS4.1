using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class CAMERA_STATUSRepository : BaseRepository<CAMERA_STATUS>, ICAMERA_STATUSRepository
    {
        public CAMERA_STATUS GetByCode(string Code)
        {
            return _context.CAMERA_STATUS.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxCAMERA_STATUS()
        {
            int Trave = 0;
            var item = _context.CAMERA_STATUS.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.CAMERA_STATUS.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteCAMERA_STATUSByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.CAMERA_STATUS.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.CAMERA_STATUS.Remove(entry);
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
