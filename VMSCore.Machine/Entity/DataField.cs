using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Entity
{
    /// <summary>
    /// Khai báo trường dữ liệu sẽ nạp remote trên bản tin layout, remote field
    /// </summary>
    public class DataField
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string IDHex { get; set; }
        public int IDDecimal { get; set; }
        public string IDBinary { get; set; }        
        public string Description { get; set; }
        public int? Sorted { get; set; }
        public int? LengthString { get; set; }

        public string Note { get; set; }
    }
}
