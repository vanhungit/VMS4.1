using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Entity
{
    public class TemplateLayOut
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<DataField> listField;
        public DataTable tablefield;
    }
}
