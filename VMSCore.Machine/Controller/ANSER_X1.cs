﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class ANSER_X1
    {
        public enum COMMAND_ANSER
        {
            GETCOUNTER = 48,//0x30
            RESETCOUNTER = 140,//0x8C
            StartPrint = 2,//0x02
            StopPrint = 3,//0x03
            ClearExecl = 4,//0x04
            LoadCoDinh = 5,//0x05
            SendDoc = 6,//0x06
            SendPack = 7,//0x07
            GetStatus = 8//0x08
        }
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
            GET_ALARM_STATUS,
            GET_COUNTER_SERI,
            SET_COUNTER_SERI,
            GET_PPRINTING_STTATUS,
            SET_PRINTING_STATUS,
            SET_DYNAMIC_STRING_TABLE,
            SEND_DOCUMENT,
            SEND_DATA_PACK,
            CLEAR_EXCEL,
            RESET_TOTAL_COUNT
        }
        public enum STATUS_PRINT_MACHINE
        {
            PRINTING,
            STOP_PRINT,
            Print_Completed_Report
        }
        public enum STATUS_ERROR
        {
            No_Error,
            Ink_low,
            Ink_empty,
            Ink_Type_Not_Supported,
            Ink_Color_Not_Supported,
            Gate_Not_Closed,
            DISC_error
        }
    }
}
