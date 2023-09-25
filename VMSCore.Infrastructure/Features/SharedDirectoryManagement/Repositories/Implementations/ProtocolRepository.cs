using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProtocolRepository : BaseRepository<Protocol>, IProtocolRepository
    {
        public Protocol GetByCode(string Code)
        {
            return _context.Protocol.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteProtocolByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Protocol.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Protocol.Remove(entry);
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
