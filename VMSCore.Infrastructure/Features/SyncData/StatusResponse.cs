using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Infrastructure.Features.SyncData
{
    public class StatusResponse
    {
        public StatusResponse()
        {
            idStatus = 0;
            description = "";
            jsonData = "";
        }
        public int idStatus { get; set; }
        public string description { get; set; }
        public string jsonData { get; set; }
    }
}
