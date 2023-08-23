using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{ 
    public class ANSER_U2
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
            START_PRINT = 17,//0x46
            STOP_PRINT = 18,//
            SET_DYNAMIC_STRING_TABLE = 20,//0xCA
            GET_PRINTER_ALARM_STATUS = 29,//0x7F
            GET_PRINTING_STATUS = 30,//0x45
            GET_COUNTER = 31,//0x3A
            GET_PRODUCTION_COUNTER = 48,//0xD2
            SET_PRODUCTION_COUNTER = 129,//0xE5
            PRINT_COMPLETED_REPORT = 140//0x30
        }
        public enum STATUS_PRINT_MACHINE
        {
            PRINTING,
            STOP_PRINT,
            PRINT_COMPLETED_REPORT
        }
        public enum STATUS_ERROR
        {
            Ink_empty,
            Ink_low,
            Cannot_print,
            No_Cartridge,
            Reserved,
            Sales_code_error,
            Area_code_error,
            DISC_error
        }
    }
}
