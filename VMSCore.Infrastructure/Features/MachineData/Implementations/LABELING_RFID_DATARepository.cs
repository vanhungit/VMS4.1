using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class LABELING_RFID_DATARepository : BaseRepository<LABELING_RFID_DATA>, ILABELING_RFID_DATARepository
    {
        public LABELING_RFID_DATA GetByCode(string Code)
        {
            return _context.LABELING_RFID_DATA.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxLABELING_RFID_DATA()
        {
            int Trave = 0;
            var item = _context.LABELING_RFID_DATA.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.LABELING_RFID_DATA.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteLABELING_RFID_DATAByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.LABELING_RFID_DATA.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.LABELING_RFID_DATA.Remove(entry);
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
