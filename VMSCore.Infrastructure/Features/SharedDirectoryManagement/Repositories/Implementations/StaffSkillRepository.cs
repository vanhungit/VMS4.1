using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class StaffSkillRepository : BaseRepository<StaffSkill>, IStaffSkillRepository
    {
        public string DeleteStaffSkillByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.StaffSkill.Where(i => i.Code == Code).FirstOrDefault();
                if (entry != null)
                {
                    _context.StaffSkill.Remove(entry);
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
