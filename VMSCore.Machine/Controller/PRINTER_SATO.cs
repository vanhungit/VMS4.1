using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class PRINTER_SATO
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
            CARD_SLOT_SELECT,
            FORMAT_CALL,
            PINT_OF_FIELD,
            PRINT_QUANTITY
        }
       
    }
}
