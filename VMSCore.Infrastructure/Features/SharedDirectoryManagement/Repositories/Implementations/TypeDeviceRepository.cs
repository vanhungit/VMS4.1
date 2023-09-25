using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class TypeDeviceRepository : BaseRepository<TypeDevice>, ITypeDeviceRepository
    {
        public TypeDevice GetByCode(string Code)
        {
            return _context.TypeDevice.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteLineByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.TypeDevice.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.TypeDevice.Remove(entry);
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
