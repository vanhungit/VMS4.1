using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class SkillRepository : BaseRepository<Skills>, ISkillRepository
    {
        public Skills GetByCode(string Code)
        {
            return _context.Skills.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteSkillsByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Skills.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Skills.Remove(entry);
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
