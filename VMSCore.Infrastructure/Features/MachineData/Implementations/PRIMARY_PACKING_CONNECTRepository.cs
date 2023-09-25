using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class PRIMARY_PACKING_CONNECTRepository : BaseRepository<PRIMARY_PACKING_CONNECT>, IPRIMARY_PACKING_CONNECTRepository
    {
        public PRIMARY_PACKING_CONNECT GetByCode(string Code)
        {
            return _context.PRIMARY_PACKING_CONNECT.FirstOrDefault(x => x.Code == Code);
        }
        public string DeletePRIMARY_PACKING_CONNECTByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.PRIMARY_PACKING_CONNECT.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.PRIMARY_PACKING_CONNECT.Remove(entry);
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
