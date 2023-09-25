using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DeviceGroupRepository : BaseRepository<DeviceGroup>, IDeviceGroupRepository
    {
        public DeviceGroup GetByCode(string Code)
        {
            return _context.DeviceGroup.FirstOrDefault(x => x.Code == Code);
        }
        public string DeleteDeviceGroupByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.DeviceGroup.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.DeviceGroup.Remove(entry);
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
