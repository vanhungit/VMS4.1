using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.API.EntityModels.Interfaces
{
    public interface IEntity
    {
        string Id { get; set; }
    }

    public partial class Staff : IEntity
    {
        public string Id { get; set; }
    }

    public partial class Button : IEntity
    {
        public string Id { get; set; }
    }
    public partial class UNIT : IEntity
    {
        public string Id { get; set; }
    }
    //public partial class Barcode : IEntity
    //{
    //    public string Id { get; set; }
    //}
}
