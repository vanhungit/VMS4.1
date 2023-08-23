using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Entity
{
    public class DataError
    {
        public string IDHex { get; set; }
        public int IDDecimal { get; set; }
        public string IDBinary { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
