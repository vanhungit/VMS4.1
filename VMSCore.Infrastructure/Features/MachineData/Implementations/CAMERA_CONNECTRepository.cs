using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class CAMERA_CONNECTRepository : BaseRepository<CAMERA_CONNECT>, ICAMERA_CONNECTRepository
    {
        public CAMERA_CONNECT GetByCode(string Code)
        {
            return _context.CAMERA_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxCAMERA_CONNECT()
        {
            int Trave = 0;
            var item = _context.CAMERA_CONNECT.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.CAMERA_CONNECT.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteCAMERA_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.CAMERA_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.CAMERA_CONNECT.Remove(entry);
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
