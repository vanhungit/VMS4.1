using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class CAMERA_DATARepository : BaseRepository<CAMERA_DATA>, ICAMERA_DATARepository
    {
        public CAMERA_DATA GetByCode(string Code)
        {
            return _context.CAMERA_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxCAMERA_DATA()
        {
            int Trave = 0;
            var item = _context.CAMERA_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.CAMERA_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteCAMERA_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.CAMERA_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.CAMERA_DATA.Remove(entry);
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
