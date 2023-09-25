using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMSCore.EntityModels;

namespace VMSCore.ViewModels.MasterData
{
    public class EQUIP_PLANT_MAP
    {
        /// <summary>
        /// Thông tin thiết bi
        /// </summary>
        public Device header;
        /// <summary>
        /// Hiển thị dây chuyền sản xuất
        /// </summary>
        public Line line;
        /// <summary>
        /// Danh sách thiết bị trên line
        /// </summary>
        public List<LineDevice> linedetail;
        /// <summary>
        /// Danh sách thiết bị con của máy điều khiển
        /// </summary>
        public List<Device_Combo> headercombo;
        /// <summary>
        /// Danh sách giao thức của thiết bị
        /// </summary>
        public List<Device_PROTOCOL> headerptotocol;
        public bool isManager { get; set; }
        public bool globalActive { get; set; }
        public bool lineActive { get; set; }

        public EQUIP_PLANT_MAP()
        {
            header = new Device();
            line = new Line();
            linedetail = new List<LineDevice>();
            headercombo = new List<Device_Combo>();
            headerptotocol = new List<Device_PROTOCOL>();
        }
    }
}
