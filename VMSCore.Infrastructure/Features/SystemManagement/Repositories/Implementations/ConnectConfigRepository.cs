using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class ConnectConfigRepository : BaseRepository<ConnectConfig>, IConnectConfigRepository
    {
        public ConnectConfig GetByCode(string Code)
        {
            return _context.ConnectConfig.FirstOrDefault(x => x.Code == Code);
        }
        public ConnectConfig GetByCodeMap(string Code)
        {
            ConnectConfig obj = new ConnectConfig();
            obj.Code = "";
            var entry = _context.ConnectConfig.FirstOrDefault(x => x.CodeMap == Code);
            if (entry != null)
            {
                return _context.ConnectConfig.FirstOrDefault(x => x.CodeMap == Code);
            }
            else
            {
                return obj;
            }    
        }
        public string DeleteConnectConfigByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ConnectConfig.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.ConnectConfig.Remove(entry);
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
