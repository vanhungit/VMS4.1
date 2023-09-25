using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations
{
    public class ErrorConfigRepository : BaseRepository<ErrorConfig>, IErrorConfigRepository
    {
        public ErrorConfig GetByCode(string Code)
        {
            return _context.ErrorConfig.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteErrorConfigByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.ErrorConfig.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.ErrorConfig.Remove(entry);
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
