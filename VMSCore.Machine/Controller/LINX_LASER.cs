using VMSCore.Machine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class LINX_LASER
    {
        public EventDrivenTCPClient client;
        public EventDrivenTCPClient.ConnectionStatus globalStatus;
        public LibConvert spconvert;
        public DataError STATUS_JET;
        public DataError STATUS_PRINT;
        public List<DataError> STATUS_Error;
        #region KhaiBao

        const string _Start = "Start";
        const string _Stop = "Stop";
        const string _GetStatus = "GetStatus";
        const string _GetJob = "GetJob";
        const string _SetJob = "SetJob";
        const string _SetJobVars = "SetJobVars";
        const string _SetVarSimple = "SetVarsSimple";
        const string _SetVarByName = "SetVars";
        const string _SetVarAsync = "SetVarsAsync";
        const string _GetGlobalCounter = "GetGlobalCounter";
        const string _GetMakingCounter = "GetMarkingCounter";
        const string _GetProductCounter = "GetProductCounter";
        const string _ResetMakingCounter = "ResetMarkingCounter";
        const string _ResetProductCounter = "ResetProductCounter";
        const string _ClearBuffer = "ClearBufferData";
        const string _StoreAndSetVars = "SetVarsAsync";
        string CMD = "";
        #endregion
        public LINX_LASER(IPAddress ip, int port, bool autoreconnect)
        {
            client = new EventDrivenTCPClient(ip, port, autoreconnect);
            globalStatus = EventDrivenTCPClient.ConnectionStatus.NeverConnected;
            spconvert = new LibConvert();
        }
        public string StartLaser()
        {
            string strSend = _Start;
            return strSend + ";\r\n";
        }

        public string StopLaser()
        {
            string strSend = _Stop;
            return strSend + ";\r\n";
        }

        public string GetStatus()
        {
            string strSend = _GetStatus;
            return strSend + ";\r\n";
        }

        public string GetJob()
        {
            string strSend = _GetJob;
            CMD = _GetJob;
            return strSend + ";\r\n";
        }

        public string SetJob(string TemplateName)
        {
            string strSend = _SetJob + ";" + TemplateName;
            CMD = _SetJob;
            return strSend + ";\r\n";
        }

        public string SetJobVars(string TemplateName, string ListVarName_VarData)
        {// Jobname;Varname1;Value1;Varname2;Value2;…;VarnameX;ValueX;
            string strSend = _SetJobVars + ";" + TemplateName + ";" + ListVarName_VarData;
            CMD = _SetJobVars;
            return strSend + ";\r\n";
        }

        public string SetVarSimple(string ListVarData)
        {//Varvalue1;Varvalue2;…;VarvalueX
            string strSend = _SetVarSimple + ";" + ListVarData;
            CMD = _SetVarSimple;
            return strSend + ";\r\n";
        }

        public string SetVarByName(string ListVarName_VarData)
        {//Varname1;Varvalue1;Varname2;Varvalue2;…;VarnameX;VarvalueX
            string strSend = _SetVarByName + ";" + ListVarName_VarData;
            CMD = _SetVarByName;
            return strSend + ";\r\n";
        }

        public string StoreAndSetVar(string ListVarName_VarData)
        {//Varname1;Varvalue1;Varname2;Varvalue2;…;VarnameX;VarvalueX
            string strSend = _SetVarAsync + ";" + ListVarName_VarData;
            CMD = _SetVarAsync;
            return strSend + ";\r\n";
        }

        public string GetGlobalCounter()
        {
            string strSend = _GetGlobalCounter;
            CMD = _GetGlobalCounter;
            return strSend + ";\r\n";
        }

        public string GetMakingCounter()
        {
            string strSend = _GetMakingCounter;
            CMD = _GetMakingCounter;
            return strSend + ";\r\n";
        }

        public string GetProductCounter()
        {
            string strSend = _GetProductCounter;
            CMD = _GetProductCounter;
            return strSend + ";\r\n";
        }

        public string ClearBuffer()
        {
            string strSend = _ClearBuffer;
            CMD = _ClearBuffer;
            return strSend + ";\r\n";
        }

        public string ResetMakingCounter()
        {
            string strSend = _ResetMakingCounter;
            CMD = _ResetMakingCounter;
            return strSend + ";\r\n";
        }

        public string ResetProductCounter()
        {
            string strSend = _ResetProductCounter;
            CMD = _ResetProductCounter;
            return strSend + ";\r\n";
        }

        // -----  RX: Hàm xử lý dữ liệu trả về sau khi gửi command ----------
        public void PrinterReplied(string strRX)
        {
            char c = strRX[0];
            if (c == 0x15)
            {//NAK
                string msg = "Command error: " + CMD + "\r\nResult code: " + ResultCode(strRX.Substring(2, 4));
                //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { //ACK
                switch (CMD)
                {
                    case _GetJob: PrinterRepliedGetJob(strRX); break;
                    case _GetStatus: PrinterRepliedGetStatus(strRX); break;
                    case _GetGlobalCounter: PrinterRepliedGetGlobalCounter(strRX); break;
                    case _GetProductCounter: PrinterRepliedGetProductCounter(strRX); break;
                    case _GetMakingCounter: PrinterRepliedGetMakingCounter(strRX); break;
                    default: PrinterRipliedFinished(strRX); break;
                }
            }
            CMD = "";
        }
        // RX: ------ Hàm xử lý Event trả về -------------------
        public void PrinterRepliedEvent(string strRX)
        {
            string[] arrRX = strRX.Split(';');
            if (arrRX[0] == "Event")
            {
                switch (arrRX[1])
                {
                    case "TemplateChanged": EventTemplateChanged(strRX); break;
                    case "StatusChanged": EventStatusChanged(strRX); break;
                    case "ValueSet": EventValueSet(strRX); break;
                    case "ProductCounterChanged": EventProductCounterChanged(strRX); break;
                    case "MarkingCounterChanged": EventMarkingCounterChanged(strRX); break;
                    case "MarkResult": EventMarkResult(strRX); break;
                }
            }
        }
        // ------  Xử lý Event trả về ------------------------------
        private void EventTemplateChanged(string strData)
        {
            Console.WriteLine("Event: Template Changed");
        }

        private void EventStatusChanged(string strData)
        {
            string[] arrData = strData.Split(';');
            string LaserStatus = arrData[2];
            string StatusCode = arrData[3];
            Console.WriteLine("Event: Status Changed \r\nLaser status: " + LaserStatus + "\r\nStatus code: " + StatusCode);
        }

        private void EventValueSet(string strData)
        {//Event;ValueSet;[Varname];[Value];[ResultCode];<CR><LF>
            string[] arrData = strData.Split(';');
            string VarName = arrData[2];
            string VarValue = arrData[3];
            string Resultcode = ResultCode(arrData[4]);
            Console.WriteLine("Event: Value Set \r\nVar Name: " + VarName + "\r\nVar value: " + VarValue + "\r\nResult code: " + Resultcode);
        }

        private void EventProductCounterChanged(string strData)
        {
            string[] arrData = strData.Split(';');
            string ProductCounter = arrData[2];
            Console.WriteLine("Product counter: " + ProductCounter);
        }

        private void EventMarkingCounterChanged(string strData)
        {
            string[] arrData = strData.Split(';');
            string MarkingCounter = arrData[2];
            Console.WriteLine("Marking counter: " + MarkingCounter);
        }

        private void EventMarkResult(string strData)
        {
            string[] arrData = strData.Split(';');
            string MarkingResult = arrData[2];
            Console.WriteLine("Marking result: " + MarkingResult);
        }
        // ------  Xử lý phản hồi sau khi gửi command --------------
        private void PrinterRipliedFinished(string strData)
        {
            string msg = "Command send finished: " + CMD + "\r\nResult code: " + ResultCode(strData.Substring(2, 4));
            //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void PrinterRepliedGetJob(string strData)
        {
            string[] arrData = strData.Split(';');
            string strResultcode = ResultCode(arrData[1]);
            string strJobName = arrData[2];

            string msg = "Template name: " + strJobName + "\r\nResult code: " + strResultcode;
            //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrinterRepliedGetStatus(string strData)
        {
            string[] arrData = strData.Split(';');
            string strResultcode = ResultCode(arrData[1]);
            string strStatus = arrData[2];

            string msg = "Status laser: " + strStatus + "\r\nResult code: " + strResultcode;
            //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrinterRepliedGetGlobalCounter(string strData)
        {
            string[] arrData = strData.Split(';');
            string strResultcode = ResultCode(arrData[1]);
            string strGlobalCounter = arrData[2];

            string msg = "Global counter: " + strGlobalCounter + "\r\nResult code: " + strResultcode;
            //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrinterRepliedGetProductCounter(string strData)
        {
            string[] arrData = strData.Split(';');
            string strResultcode = ResultCode(arrData[1]);
            string strProductCounter = arrData[2];

            string msg = "Product counter: " + strProductCounter + "\r\nResult code: " + strResultcode;
            //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrinterRepliedGetMakingCounter(string strData)
        {
            string[] arrData = strData.Split(';');
            string strResultcode = ResultCode(arrData[1]);
            string strMakingCounter = arrData[2];

            string msg = "Making counter: " + strMakingCounter + "\r\nResult code: " + strResultcode;
            //MessageBox.Show(msg, "Printer replied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private string ResultCode(string strRS)
        {
            string _ResultCode = "";

            switch (strRS)
            {
                case "0000": _ResultCode = "OK"; break;
                case "0001": _ResultCode = "OK"; break;
                case "0002": _ResultCode = "Interface Busy"; break;
                case "9C40": _ResultCode = "Unknown Error"; break;
                case "9C41": _ResultCode = "Unknown Command"; break;
                case "9C42": _ResultCode = "Not Connected To Laser"; break;
                case "9C4D": _ResultCode = "Unknown SystemState Error"; break;
                case "9C50": _ResultCode = "LaserState Change Error"; break;
                case "B3B0": _ResultCode = "XML Parse Error"; break;
                case "9CA5": _ResultCode = "Database Fatal Error"; break;
                case "9CA6": _ResultCode = "Database Template Not Found"; break;
                case "9CA8": _ResultCode = "Database Variable Not Found"; break;
                case "9CAB": _ResultCode = "Database Parameter Set Not Found"; break;
                case "9CAC": _ResultCode = "Database Configuration Not Found"; break;
                case "9CAE": _ResultCode = "Database Index Not Found"; break;
                case "9CB0": _ResultCode = "Database Delete Database Object In Use"; break;
                case "9CB1": _ResultCode = "Database Delete Error"; break;
                case "9CB7": _ResultCode = "Database Database Object Exists Error"; break;
                case "9CBA": _ResultCode = "Database Database Object Not Found"; break;
                case "A029": _ResultCode = "Command Action Error"; break;
                case "A02A": _ResultCode = "Command Location Error"; break;
                case "A02B": _ResultCode = "Command Element Error"; break;
                case "A02F": _ResultCode = "Command LaserMarking Error"; break;
                case "A030": _ResultCode = "Command Invalid Timezone Error"; break;
                case "A031": _ResultCode = "Command Invalid Language Error"; break;
                case "A032": _ResultCode = "Command Invalid Time Error"; break;
                case "A035": _ResultCode = "Command Invalid In Current LaserState Error"; break;
                case "A037": _ResultCode = "Command Invalid Node Content Error"; break;
                case "A038": _ResultCode = "Command Delete ErrorMessages Error"; break;
                case "A03B": _ResultCode = "Command Value Out Of Range Error"; break;
                case "AB7C": _ResultCode = "TCL Communication Interrupted Error"; break;
                case "AB7D": _ResultCode = "TCL Parse Error"; break;
                case "AB7E": _ResultCode = "TCL Invalid State Error"; break;
                case "AB7F": _ResultCode = "TCL UnknownCommand Error"; break;
                case "AB80": _ResultCode = "TCL Parameter not allowed"; break;
                case "AFDF": _ResultCode = "Xpath Not Exists Error"; break;
            }
            return _ResultCode;
        }
        public LINX_LASER()
        {
            
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
            START_LASER,
            STOP_LASER,
            GET_STATUS_CURRENT,
            GET_ALL_VARIABLE_NAME,
            GET_ALL_VARIABLE_AND_VALUE,
            SET_VARIABLE_BY_NAME,
            SET_VARIABLE,
            STORE_AND_SET_VARIABLE,
            GET_JOB_CURRENT,
            SET_JOB,
            SET_JOB_AND_VARIABLE,
            GET_GLOBAL_COUNTER,
            GET_MAKING_COUNTER,
            GET_PRODUCT_COUNTER,
            RESET_MAKING_COUNTER,
            RESET_PRODUCT_COUNTER
        }
        public enum STATUS_PRINT_MACHINE
        {
            LaserStatusStandby,
            LaserStatusReady,
            LaserStatusMarking,
            LaserStatusWaitForTrigger,
            LaserStatusWaitForTriggerDelay,
            LaserStatusPause,
            LaserStatusPrepareForMarking,
            LaserStatusWaitForPause,
            LaserStatusStartUp,
            LaserStatusKeySwitchOpen,
            LaserStatusInterlockOpen,
            LaserStatusShutterlockOpen,
            LaserStatusProtectedServiceMode,
            LaserStatusServiceMode,
            LaserStatusError1,
            LaserStatusError2,
            MarkingCounterChanged,
            MarkResult_Good,
            MarkResult_Bad
        }
        public enum STATUS_ERROR
        {
            LaserState_Change_Error,
            XML_Parse_Error,
            Database_Fatal_Error_,
            Database_Template_Not_Found_,
            Database_Variable_Not_Found_,
            Database_Parameter_Set_Not_Found_,
            Database_Configuration_Not_Found_,
            Database_Index_Not_Found_,
            Database_Delete_Database_Object_In_Use_,
            Database_Delete_Error_,
            Database_Database_Object_Exists_Error_,
            Database_Database_Object_Not_Found_,
            Command_Action_Error_,
            Command_Location_Error_,
            Command_Element_Error_,
            Command_LaserMarking_Error_,
            Command_Invalid_Timezone_Error_,
            Command_Invalid_Language_Error_,
            Command_Invalid_Time_Error_,
            Command_Invalid_In_Current_LaserState_Error_,
            Command_Invalid_Node_Content_Error_,
            Command_Delete_ErrorMessages_Error_,
            Command_Value_Out_Of_Range_Error_,
            TCL_Communication_Interrupted_Error_,
            TCL_Parse_Error_,
            TCL_Invalid_State_Error_,
            TCL_UnknownCommand_Error_,
            TCL_Parameter_not_allowed_,
            Xpath_Not_Exists_Error
        }
    }
}
