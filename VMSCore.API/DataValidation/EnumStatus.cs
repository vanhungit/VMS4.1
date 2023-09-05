using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMSCore.API.DataValidation
{
    public class EnumStatus
    {
        public EnumStatus()
        {
            IDStatus = 0;
            StatusHttp = "";
            Description = "";
        }
        public void SetSuccess()
        {
            IDStatus = 1;
            StatusHttp = "200";
            Description = "Thành Công";
        }
        public void SetFail(string Message)
        {
            IDStatus = 2;
            Description = Message;
        }
        public void SetFail(string Message, string HttpStatus)
        {
            IDStatus = 2;
            StatusHttp = HttpStatus;
            Description = Message;
        }
        public int IDStatus { get; set; }
        public string StatusHttp { get; set; }
        public string Description { get; set; }
    }
}
