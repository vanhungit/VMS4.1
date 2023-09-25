using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class LABELING_RFID_ERRORRepository : BaseRepository<LABELING_RFID_ERROR>, ILABELING_RFID_ERRORRepository
    {
        public LABELING_RFID_ERROR GetByCode(string Code)
        {
            return _context.LABELING_RFID_ERROR.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxLABELING_RFID_ERROR()
        {
            int Trave = 0;
            var item = _context.LABELING_RFID_ERROR.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.LABELING_RFID_ERROR.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteLABELING_RFID_ERRORByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.LABELING_RFID_ERROR.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.LABELING_RFID_ERROR.Remove(entry);
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
