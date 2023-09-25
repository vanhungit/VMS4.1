using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.API.EntityModels.Interfaces
{
    public interface ICodedEntity
    {
        public string? Code { get; set; }
    }
}