using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class StatusConfigRepository : BaseRepository<StatusConfig>, IStatusConfigRepository
    {
        public StatusConfig GetByCode(string Code)
        {
            return _context.StatusConfig.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteStatusConfigByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.StatusConfig.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.StatusConfig.Remove(entry);
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

