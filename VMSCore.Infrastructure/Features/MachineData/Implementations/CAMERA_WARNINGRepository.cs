using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class CAMERA_WARNINGRepository : BaseRepository<CAMERA_WARNING>, ICAMERA_WARNINGRepository
    {
        public CAMERA_WARNING GetByCode(string Code)
        {
            return _context.CAMERA_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxCAMERA_WARNING()
        {
            int Trave = 0;
            var item = _context.CAMERA_WARNING.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.CAMERA_WARNING.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteCAMERA_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.CAMERA_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.CAMERA_WARNING.Remove(entry);
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
