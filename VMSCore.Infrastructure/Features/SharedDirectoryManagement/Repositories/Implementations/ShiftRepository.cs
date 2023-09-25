using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class ShiftRepository : BaseRepository<Shift>, IShiftRepository
    {
        public Shift GetByCode(string Code)
        {
            return _context.Shift.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteShiftByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Shift.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Shift.Remove(entry);
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
