using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VMSCore.API.Services
{
    public interface IDummyEmailService
    {
        void SendEmail(string backGroundJobType, string startTime);
    }
}
