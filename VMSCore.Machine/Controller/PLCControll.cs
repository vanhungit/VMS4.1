using VMSCore.Machine.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VMSCore.Machine.Controller
{
    public class PLCControll
    {
        public EventDrivenTCPClient client;
        public EventDrivenTCPClient.ConnectionStatus globalStatus;
        public LibConvert spconvert;
        public PLCControll(IPAddress ip, int port, bool autoreconnect)
        {
            client = new EventDrivenTCPClient(ip, port, autoreconnect);
            globalStatus = EventDrivenTCPClient.ConnectionStatus.NeverConnected;
            spconvert = new LibConvert();
        }
        public enum COMMAND_PLC
        {
            StatusCAM = 103,//0x67
            StatusAlarm = 104,//0x68
            StatusOffCam = 105,//0x69
            Status0ffInterLog = 106,//0x6A
            CamHong = 107,//0x6B
            Sensor2s = 108,//0x6C
            ThungHong = 109//0x6D
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
        //Khai báo transaction gửi dữ liệu
        //byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x02, 0xFF, 0x00 };
        //byte[] KhoiTao = new byte[] { 0x00, Transaction, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, Địa chỉ cao, Địa chỉ thấp, Giá trị, 0x00 };
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
        public enum STATUS_MACHINE
        {
            START,
            STOP,
            ENABLE
        }
        public enum ADR_MACHINE
        {
            PRINTING,
            STOP_PRINT,
            PRINT_COMPLETED_REPORT
        }
        public enum MEMORY_MACHINE
        {
            PRINTING,
            STOP_PRINT,
            PRINT_COMPLETED_REPORT
        }
        //Read M0 {Tranaction 1, Tranaction 0, protocol 1, protocol 0, lenght 1, lenght 0, Unit address, Message N}
        const byte _ReadCoils = (byte)01;
        const byte _Station = (byte)00;
        public byte[] ReadCoilsCMD(ushort FirstAddress, ushort NumCoil)
        {
            byte[] arrBuffer = { _ReadCoils, (byte)(FirstAddress >> 8), (byte)FirstAddress, (byte)(NumCoil >> 8), (byte)NumCoil };
            byte CMDid = 0x65;

            return PackSend(CMDid, arrBuffer);
        }
        /// <summary>
        /// Gửi data
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="arrTX"></param>
        /// <returns></returns>
        private byte[] PackSend(byte TransactionID, byte[] arrTX)
        {
            byte[] arrPack = new byte[arrTX.Length + 7];
            ushort _Length = (ushort)(arrTX.Length + 1);

            byte[] Prefix = { 0, TransactionID, 0, 0, (byte)(_Length >> 8), (byte)_Length, _Station };
            Array.Copy(Prefix, 0, arrPack, 0, Prefix.Length);
            Array.Copy(arrTX, 0, arrPack, Prefix.Length, arrTX.Length);
            return arrPack;
        }
        private void ModbusRepliedReadCoil(byte[] arrBuffer)
        {
            byte _ByteCount = arrBuffer[8];
            byte[] _CoilData = new byte[_ByteCount];
            Array.Copy(arrBuffer, 9, _CoilData, 0, _ByteCount);
            Array.Reverse(_CoilData);

            string StrBit = Convert.ToString(_CoilData[0], 2).PadLeft(8, '0');  //only for 1 byte
            Console.WriteLine("\r\nString bit: " + StrBit);
        }
       
        //M1
        /// <summary>
        /// Khởi tạo PLC
        /// </summary>
        public void StartPLC()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0xFF, 0x00 };
            client.Send(KhoiTao);
        }
        //M2
        public void StopPLC()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x02, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
       
        public void GetInputMemory()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x65, 0x00, 0x00, 0x00, 0x06, 0x00, 0x01, 0x09, 0x00, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        public void GetCounterTong()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0xC8, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x07, 0x00, 0x00, 0x02 };
            //KhoiTao[1] = (int)PRIMARY_PACKING_DEFINE.COMMAND.COUNTER_TOTAL;
            client.Send(KhoiTao);
        }
        public void GetCounterNG()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0xC9, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x07, 0x02, 0x00, 0x02 };
            client.Send(KhoiTao);
        }
    }
}
