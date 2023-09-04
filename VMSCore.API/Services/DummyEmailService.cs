using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMSCore.API.Services
{
    public class DummyEmailService : IDummyEmailService
    {
        public void SendEmail(string backGroundJobType, string startTime)
        {
            Console.WriteLine(backGroundJobType + " - " + startTime + " - Email Sent - " + DateTime.Now.ToLongTimeString());
        }
    }
}
