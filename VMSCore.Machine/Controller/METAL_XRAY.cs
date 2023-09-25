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
        public enum COMMAND
        {

            COUNTER_TOTAL = 200,//0x11FE - ĐỌC COUNTER tổng
            COUNTER_TP = 201,//0x1203 - Đọc countet TP
            COUNTER_ENG = 202,//0x1208 - Đọc counter NG
            COUNTER_LSX = 203,//0x120D - Lệnh sản xuất
            ENABLE_RUN = 204,//M0 -0x0800 - cho phép chạy chương trình
            START = 205,//M1 - Transaction M1 - 0x0801
            STOP = 206,//M2 - Transaction M2 - 0x0802
            RESET_COUNTER = 207,//M5 - Reset counter  - 0x0805 
            STATUS_RUN = 208,//M700 - 0x0ABC
            GET_DEVICE = 209//D500
        }

        public enum STATUS_PRINT_MACHINE
        {
            RUN,
            STOP,
            ENABLE
        }
    }
}
