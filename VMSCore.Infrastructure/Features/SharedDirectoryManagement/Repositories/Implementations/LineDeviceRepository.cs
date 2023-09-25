using System;
using System.Collections.Generic;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class LineDeviceRepository : BaseRepository<LineDevice>, ILineDeviceRepository
    {
        public LineDevice LineDeviceGetByIDDevice(string IDDevice)
        {
            LineDevice obj = new LineDevice();
            obj.LineCode = "";
            var item = _context.LineDevice.Where(i => i.DeviceCode == IDDevice).FirstOrDefault();
            if (item != null)
            {
                obj = (LineDevice)item;
            }
            return obj;
        }
        public LineDevice LineDeviceGetByCode(string Code)
        {
            LineDevice obj = new LineDevice();
            obj.LineCode = "";
            var item = _context.LineDevice.Where(i => i.Code == Code).FirstOrDefault();
            if (item != null)
            {
                obj = (LineDevice)item;
            }
            return obj;
        }
    }
}