using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class METAL_XRAY
    {
        public enum STATUS_CONNECT
        {
            NeverConnected,
            Connecting,
            Connected,
            AutoReconnecting,
            DisconnectedByUser,
            DisconnectedByHost,
            ConnectFail_Timeout,
            ReceiveFail_Timeout,
            SendFail_Timeout,
            SendFail_NotConnected,
            Error

        }
        public enum COMMAND_DATA
        {
            REQUEST_STATUS_RUNSTOP,
            REQUEST_COUNTER_TOTAL,
            REQUEST_COUNTER_NG,
            RESET_COUNTER,
            ENABLE_PROGRAM
        }
        public enum STATUS_PRINT_MACHINE
        {
            RUN,
            STOP,
            ENABLE
        }
    }
}
