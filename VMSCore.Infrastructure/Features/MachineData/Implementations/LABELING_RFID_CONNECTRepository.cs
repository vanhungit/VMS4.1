using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class LABELING_RFID_CONNECTRepository : BaseRepository<LABELING_RFID_CONNECT>, ILABELING_RFID_CONNECTRepository
    {
        public LABELING_RFID_CONNECT GetByCode(string Code)
        {
            return _context.LABELING_RFID_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public int GetMaxLABELING_RFID_CONNECT()
        {
            int Trave = 0;
            var item = _context.LABELING_RFID_CONNECT.FirstOrDefault();
            if (item != null)
            {
                Trave = (int)(_context.LABELING_RFID_CONNECT.Max(i => i.Sorted));
            }
            return Trave;
        }
        public string DeleteLABELING_RFID_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.LABELING_RFID_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.LABELING_RFID_CONNECT.Remove(entry);
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
