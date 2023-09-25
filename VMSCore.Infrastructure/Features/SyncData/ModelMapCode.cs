using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMSCore.EntityModels;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class ModelMapCode
    {
        public ProductionOrderDetailCode objGen = new ProductionOrderDetailCode();
        public ProductionOrderDetailMAP listMap = new ProductionOrderDetailMAP();
        public bool StatusCreate { get; set; }
        public bool StatusMapSon { get; set; }
        public bool StatusDAD { get; set; }
        public int LevelCode { get; set; }

    }
}
