using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class LABELING_RFID_WARNINGRepository : BaseRepository<LABELING_RFID_WARNING>, ILABELING_RFID_WARNINGRepository
    {
        public LABELING_RFID_WARNING GetByCode(string Code)
        {
            return _context.LABELING_RFID_WARNING.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxLABELING_RFID_WARNING()
        {
            int Trave = 0;
            var item = _context.LABELING_RFID_WARNING.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.LABELING_RFID_WARNING.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteLABELING_RFID_WARNINGByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.LABELING_RFID_WARNING.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.LABELING_RFID_WARNING.Remove(entry);
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
