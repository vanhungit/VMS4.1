using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class CAMERA_ERRORRepository : BaseRepository<CAMERA_ERROR>, ICAMERA_ERRORRepository
    {
        public CAMERA_ERROR GetByCode(string Code)
        {
            return _context.CAMERA_ERROR.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxCAMERA_ERROR()
        {
            int Trave = 0;
            var item = _context.CAMERA_ERROR.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.CAMERA_ERROR.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteCAMERA_ERRORByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.CAMERA_ERROR.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.CAMERA_ERROR.Remove(entry);
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
