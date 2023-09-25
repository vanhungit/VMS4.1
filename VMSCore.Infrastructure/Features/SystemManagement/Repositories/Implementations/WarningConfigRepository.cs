using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class WarningConfigRepository : BaseRepository<WarningConfig>, IWarningConfigRepository
    {
        public WarningConfig GetByCode(string Code)
        {
            return _context.WarningConfig.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteWarningConfigByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.WarningConfig.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.WarningConfig.Remove(entry);
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
