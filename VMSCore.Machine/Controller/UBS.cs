using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class UBS
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
            LOAD_FORMAT_TO_PRINT,
            PRINT_PAUSE_PRINTING,
            DOWNLOAD_VARIABLE,
            CLEAR_BUFFER,
            REQUEST_COUNTER,
            REQUEST_ERROR
        }
        public enum STATUS_PRINT_MACHINE
        {
            PRINTTING,
            PAUSE,
            PRINT_END
        }
        public enum STATUS_ERROR
        {
            System_temperature_warning,
            Print_head_temperature_warning,
            Low_ink_temperature,
            No_ink_warning
        }
    }
}
