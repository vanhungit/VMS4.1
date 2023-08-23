using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class TTO
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
            SELECT_JOB,
            SELECT_JOB_FIELDNAME,
            UPDATE_DATA,
            UPDATE_DATA_FIELDNAME,
            UPDATE_DATA_FIELDNAME_COUTING,
            SET_STATES,
            REQUEST_STATE,
            SET_COUNTS
        }
        public enum STATUS_PRINT_MACHINE
        {
            Shut_down,
            Starting_up,
            Shutting_down,
            Running,
            Offline,
            PRINT_START_NOTIFICATION,
            PRINT_COMPLETED_NOTIFICATION
        }
        public enum STATUS_ERROR
        {
            No_errors,
            Warning_present,
            Fault_present
        }
    }
}
