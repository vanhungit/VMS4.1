using VMSCore.Machine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class LINX_CIJ
    {
        public EventDrivenTCPClient client;
        public EventDrivenTCPClient.ConnectionStatus globalStatus;
        public LibConvert spconvert;
        public DataError STATUS_JET;
        public DataError STATUS_PRINT;
        public List<DataError> STATUS_Error;
        public List<DataError> STATUS_Warning;
        public List<TemplateLayOut> listlayoutPrint;
        public string IDDevice { get; set; }
        public string NameDevice { get; set; }
        public string SeriNumber { get; set; }
        private string _IP { get; set; }
        private int _Port { get; set; }
        private System.Timers.Timer tmrReceiveTimeout = new System.Timers.Timer();

        public LINX_CIJ(IPAddress ip, int port, bool autoreconnect)
        {
            tmrReceiveTimeout.Interval = 1000;
            client = new EventDrivenTCPClient(ip, port, autoreconnect);
            globalStatus = EventDrivenTCPClient.ConnectionStatus.NeverConnected;
            spconvert = new LibConvert();
            _Port = port;
            _IP = ip.ToString();
            tmrReceiveTimeout.AutoReset = false;
            tmrReceiveTimeout.Elapsed += new System.Timers.ElapsedEventHandler(tmrReceiveTimeout_Elapsed);

        }
        void tmrReceiveTimeout_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {//Tạo reqquest, khai báo danh sách hàm cần reqquest
            //1. request status printer
            //2. request status jet
            //3. request status warning
            //4. request status extend
        }
        public LINX_CIJ()
        {
            IDDevice = "";
            NameDevice = "";
            SeriNumber = "";
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
            START_JET = 15,//0x30
            STOP_JET = 15,//0x8C
            START_PRINT = 17,
            STOP_PRINT = 18,
            PRINTER_STATUS_REQUEST = 20,
            DOWNLOAD_REMOTE_FIELD_DATA = 29,
            LOAD_PRINT_MESSAGE = 30,
            REQUEST_PRINT_MESSAGE = 31,
            REQUEST_SYSTEM_TIME = 48,
            REQUEST_EXTENDED_WARNING = 129,
            SET_MESSAGE_PRINT_COUNT = 140,
            REQUEST_MESSAGE_PRINT_COUNT = 141,
            REQUEST_PRINTER_SERIAL_NUMBER = 152,
            REQUEST_WARNING_ENHANCED = 174
        }
        public enum STATUS_JET_MACHINE
        {
            JetRunning = 0,     //Đang phun
            JetStartUp = 1,     //Đang khởi động phun
            JetShutdown = 2,    //Đang dừng phun
            JetStopped = 3,     //Đứng im
            Fault = 4  
        }
        public enum STATUS_PRINT_MACHINE
        {
            Printing,           //Đang in
            Undefined,          //_
            Idle,               //Ngừng in
            GeneratingPixel,    //Đang tạo ma trận điểm ảnh
            Waiting,            //Đang chờ tín hiệu in
            Last,               //Đang in bản tin cuối
            Printing_GeneratingPixel    //Đang in hoặc đang tạo ma trận điểm ảnh
        }
        public enum STATUS_RECEIV_MACHINE
        {
            SI_Print_go_character = 15 ,//0x0F
            EM_Print_end_character = 25,//0x19
        }
        public enum STATUS_ERROR
        {
            No_Time_of_Flight = 0,
            Shutdown_Incomplete = 1,
            Over_Speed_Print_Trigger = 2,
            Ink_Low = 3,
            Solvent_Low = 4,
            Over_Speed_No_Remote_Data = 5,
            Printer_Requires_Scheduled_Maintenance = 6,
            Printhead_Cover_Off= 7,
            Over_Speed_Synchronous_Data = 8,
            Over_Speed_Line_Speed = 9,
            Over_Speed_Compensation = 10,
            Safety_Override_Active = 11,
            Low_Pressure = 12,
            Under_Speed_Line_Speed = 13,
            Over_Speed_Asynchronous_Data = 14,
            User_Data_Corrupt = 16,
            Memory_Corrupt = 17,
            No_Message_in_Memory = 18,
            Remote_Error = 20,
            Corrupt_Program_Data = 22,
            Print_Go_After_Schedule_End = 27,
            Extended_Errors_Present = 31
        }
        public enum STATUS_ERROR_WARNING
        {
            Restart_In_Progress = 0,
            Service_Module_Removed = 1,
            Service_Module_Requires_Commissioning = 2,
            Solvent_Tank_Needs_Commissioning = 3,
            Service_Module_Replacement_Due_Within_One_Month = 4,
            Pump_Pressure_Failure = 5,
            Pump_RPM_Failure = 6,
            Pump_RPM_Limit_Reached = 7,
            Pump_Current_Limit_Exceeded = 8,
            Valve_Supply = 9,
            Pump_Oscillating = 10,
            Pump_Power_Limit_Reached = 11,
            Printhead_Over_Temperature = 14,
            EHT_Trip = 15,
            Internal_Spillage = 16,
            Low_Battery = 17,
            Reset_System_Clock =18,
            Reverted_To_System_Settings_From_Last_Successful_Powerdown = 19,
            System_Settings_Not_Found,_Reverted_To_Defaults = 20,
            Field_Truncation = 21,
            Remote_Field_Not_Found = 22,
            Jet_Start_Failure_Do_Not_Switch_Off = 23,
            Ink_Cartridge_Not_Found = 24,
            Solvent_Cartridge_Not_Found =25,
            Invalid_Ink_Cartridge = 26,
            Invalid_Solvent_Cartridge = 27,
            Ink_Cartridge_Expired = 28,
            Solvent_Cartridge_Expired = 29
        }
        public enum STATUS_ERROR_WARNING_EXTEND
        {
            Wrong_Ink_Type= 0,
            Wrong_Solvent_Type = 1,
            Easi_Change_Service_Key_Not_Found = 2,
            Invalid_Easi_Change_Service_Key = 3,
            Daylight_Saving_Time_Started = 4,
            Daylight_Saving_Time_Ended = 5,
            Easi_Change_Service_Key_Already = 6,
            Over_Speed_Line_Sensor = 7,
            Under_Speed_Line_Sensor = 8,
            Line_Sensor_Missing = 9,
            Line_Object_Error_Line_Sensor = 10,
            Service_Module_Replacement_Recommended = 11,
            Air_Filter_Cleaning_Recommended = 12,
            Over_Speed_Delay_Update_Missed = 13,
            Over_Speed_Delay_Update_Late= 14,
            Check_Custom_Date_Format = 15,
            Commissioning_Required = 16,
            Incorrect_Easi_Change_Service_Key = 17,
            Service_Module_High = 18,
            Service_Module_Full = 19,
            Software_Upgrade_Available = 20,
            Remote_Upgrade_Ready = 21,
            Trigger_Rate_Too_High =22,
            Incorrect_Service_Module_Type =23
        }
        #region Function
        private byte[] CombomBinaryArray(byte[] srcArray1, byte[] srcArray2)
        {
            //Create a new array based on the total number of two array elements to be merged
            byte[] newArray = new byte[srcArray1.Length + srcArray2.Length];

            //Copy the first array to the newly created array
            Array.Copy(srcArray1, 0, newArray, 0, srcArray1.Length);

            //Copy the second array to the newly created array
            Array.Copy(srcArray2, 0, newArray, srcArray1.Length, srcArray2.Length);

            return newArray;
        }
        /// <summary>
        /// Hàm chạy máy in
        /// </summary>
        public void StartPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, (byte)COMMAND_DATA.START_PRINT };
            byte[] End = new byte[] { 0x1B, 0x03 };
            byte[] newArr = CombomBinaryArray(Start, End);
            client.Send(newArr);
        }
        /// <summary>
        /// Hàm dừng máy in
        /// </summary>
        public void StopPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, (byte)COMMAND_DATA.STOP_PRINT };
            byte[] End = new byte[] { 0x1B, 0x03 };
            byte[] newArr = CombomBinaryArray(Start, End);
            client.Send(newArr);
            tmrReceiveTimeout.Stop();
            tmrReceiveTimeout.Dispose();
        }
     
        /// <summary>
        /// Hàm dừng phun mực
        /// </summary>
        public void StopJetPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, (byte)COMMAND_DATA.STOP_JET };
            byte[] End = new byte[] { 0x1B, 0x03 };
            byte[] newArr = CombomBinaryArray(Start, End);
            client.Send(newArr);

        }
        /// <summary>
        /// Hàm phun mực
        /// </summary>
        public void StartJetPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, (byte)COMMAND_DATA.START_JET };
            byte[] End = new byte[] { 0x1B, 0x03 };
            byte[] newArr = CombomBinaryArray(Start, End);
            client.Send(newArr);

        }
        /// <summary>
        /// Chọn layout bản tin, khi load layout sẽ reset bản tin
        /// </summary>
        /// <param name="BangTin"></param>
        public void LoadBangTin(string BangTin)
        {
            var size = 1024; // kích thước của bộ đệm
            byte[] receiveBuffer = spconvert.ConvertCommandHEX("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");//Bản tin lưu 16 bytes
            byte[] Start = new byte[] { 0x1B, 0x02, 0x1E };
            byte[] End = new byte[] { 0x00, 0x00, 0x1B, 0x03 };
            byte[] Tam = System.Text.Encoding.ASCII.GetBytes(BangTin);
            for (int i = 0; i < Tam.Length; i++)
            {
                receiveBuffer[i] = Tam[i];
            }
            byte[] newArr = CombomBinaryArray(CombomBinaryArray(Start, receiveBuffer), End);
            client.Send(newArr);
            //client.Send(Start);
            //client.Send(receiveBuffer);
            //client.Send(End);
            //var length = socket.Receive(receiveBuffer);

            // chuyển đổi mảng byte về chuỗi
            //var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
        }
        /// <summary>
        /// send data remote field
        /// </summary>
        /// <param name="Chuoi"></param>
        /// <param name="LengthChuoi"></param>
        public void SendBuffer(string Chuoi)
        {
            var size = 1024; // kích thước của bộ đệm
            //var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm    
            //byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
            string ChuoiTest = "00";
            for (int i = 1; i < Chuoi.Length; i++)
            {
                ChuoiTest = ChuoiTest + " " + "00";
            }
            byte[] receiveBuffer = spconvert.ConvertCommandHEX(ChuoiTest);

            //byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, 0x05, 0x00 };
            byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, (byte)Chuoi.Length, (byte)(Chuoi.Length >> 8) };
            byte[] End = new byte[] { 0x1B, 0x03 };
            byte[] Tam = System.Text.Encoding.ASCII.GetBytes(Chuoi);
            for (int i = 0; i < Tam.Length; i++)
            {
                receiveBuffer[i] = Tam[i];
            }
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(Chuoi);
            byte[] newArr = CombomBinaryArray(CombomBinaryArray(Start, receiveBuffer), End);
            client.Send(newArr);
        }
        public void ResetCounter()
        {
            byte[] arrTX = new byte[25];
            arrTX[0] = 0x1b;
            arrTX[1] = 0x02;
            arrTX[2] = (byte)COMMAND_DATA.SET_MESSAGE_PRINT_COUNT;
            arrTX[23] = 0x1b;
            arrTX[24] = 0x03;
            client.Send(arrTX);
        }
        public void RequestMessagePrintCount()
        {
            //note: request message present
            byte[] arrTX = new byte[21];
            arrTX[0] = 0x1b;
            arrTX[1] = 0x02;
            arrTX[2] = (byte)COMMAND_DATA.REQUEST_MESSAGE_PRINT_COUNT;
            arrTX[19] = 0x1b;
            arrTX[20] = 0x03;
            client.Send(arrTX);
        }
        public void SetCounter(int Counter)
        {
            byte[] receiveBuffer = spconvert.ConvertCommandHEX("00 00 00 00");//Bản tin lưu 16 bytes
            byte[] Tam = spconvert.ConvertCommandHEX_FromString(spconvert.Integer_To_Hex(Counter));
            for (int i = Tam.Length - 1; i >= 0; i--)
            {
                receiveBuffer[Tam.Length - i - 1] = Tam[i];
            }
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiLenh = "1B 02 8c " + spconvert.GiaMaResultSpace(receiveBuffer) + " 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 1B 03";//set 255
            KhoiTao = spconvert.ConvertCommandHEX(ChuoiLenh);
            client.Send(KhoiTao);
        }
        public void RequestPrinterStatus()
        {

            byte[] arrTX = { 0x1b, 0x02, (byte)COMMAND_DATA.PRINTER_STATUS_REQUEST, 0x1b, 0x03 };
            client.Send(arrTX);
        }

        public void RequestExtendedWarning()
        {
            byte[] arrTX = { 0x1b, 0x02, (byte)COMMAND_DATA.REQUEST_EXTENDED_WARNING, 0x1b, 0x03 };
            client.Send(arrTX);
        }

        public void ResquestEnhandcedWarning()
        {
            byte[] arrTX = { 0x1b, 0x02, (byte)COMMAND_DATA.REQUEST_WARNING_ENHANCED, 0x1b, 0x03 };
            client.Send(arrTX);
        }
        public void ResquestSystemTime()
        {
            byte[] arrTX = { 0x1b, 0x02, (byte)COMMAND_DATA.REQUEST_SYSTEM_TIME, 0x1b, 0x03 };
            client.Send(arrTX);
        }
        #endregion
    }
}
