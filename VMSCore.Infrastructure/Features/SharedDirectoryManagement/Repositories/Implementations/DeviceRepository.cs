using System;
using System.Linq;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Interfaces;
using VMSCore.ViewModels.MasterData;

namespace VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public EQUIP_PLANT_MAP GetEQUIP_PLANT_MAPByIP(string IPDevice)
        {
            EQUIP_PLANT_MAP obj = new EQUIP_PLANT_MAP();
            obj.header = new DeviceRepository().EQUIP_PLANTGetByIP(IPDevice);
            obj.line = new LineRepository().GetByCode(new LineDeviceRepository().LineDeviceGetByIDDevice(obj.header.Code).LineCode);
            obj.linedetail = new LineDeviceRepository().GetAllByCondition(x => x.LineCode == obj.line.Code);
            obj.headercombo = new Device_ComboRepository().GetAllByCondition(x => x.KeyID_DAD == obj.header.Code);
            obj.headerptotocol = new Device_PROTOCOLRepository().GetAllByCondition(x => x.DeviceCode == obj.header.Code);
            obj.globalActive = (bool)obj.header.Active;
            obj.isManager = (bool)new LineDeviceRepository().LineDeviceGetByIDDevice(obj.header.Code).IsManager;
            obj.lineActive = (bool)new LineDeviceRepository().LineDeviceGetByIDDevice(obj.header.Code).Active;
            return obj;
        }
        public EQUIP_PLANT_MAP GetEQUIP_PLANT_MAPByID(string IDDevice)
        {
            EQUIP_PLANT_MAP obj = new EQUIP_PLANT_MAP();
            obj.header = new DeviceRepository().EQUIP_PLANTGetByID(IDDevice);
            obj.line = new LineRepository().GetByCode(new LineDeviceRepository().LineDeviceGetByIDDevice(obj.header.Code).LineCode);
            obj.linedetail = new LineDeviceRepository().GetAllByCondition(x => x.LineCode == obj.line.Code);
            obj.headercombo = new Device_ComboRepository().GetAllByCondition(x => x.KeyID_DAD == obj.header.Code);
            obj.headerptotocol = new Device_PROTOCOLRepository().GetAllByCondition(x => x.DeviceCode == obj.header.Code);
            obj.globalActive = (bool)obj.header.Active;
            obj.isManager = (bool)new LineDeviceRepository().LineDeviceGetByIDDevice(obj.header.Code).IsManager;
            obj.lineActive = (bool)new LineDeviceRepository().LineDeviceGetByIDDevice(obj.header.Code).Active;
            return obj;
        }
        public Device GetByCode(string Code)
        {
            return _context.Device.FirstOrDefault(x => x.Code == Code);
        }
        public Device EQUIP_PLANTGetByIP(string IPDevice)
        {
            return _context.Device.FirstOrDefault(x => x.Description == IPDevice);
        }
        public Device EQUIP_PLANTGetByID(string IDDevice)
        {
            return _context.Device.FirstOrDefault(x => x.Code == IDDevice);
        }
        public string DeleteDeviceByID(string Code)
        {
            string obj = "";
            try
            {
                var entry = _context.Device.Where(i => i.Code == Code && i.Active == true).FirstOrDefault();
                if (entry != null)
                {
                    _context.Device.Remove(entry);
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
