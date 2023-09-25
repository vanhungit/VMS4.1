using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ProtocolParamRepository : BaseRepository<ProtocolParam>, IProtocolParamRepository
    {
        public ProtocolParam GetByCode(string Code)
        {
            return _context.ProtocolParam.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteProtocolParamByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ProtocolParam.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.ProtocolParam.Remove(entry);
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
