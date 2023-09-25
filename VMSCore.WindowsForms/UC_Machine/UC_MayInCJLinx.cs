using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;

using System.Xml;
using System.IO;
using System.Globalization;
using System.Threading;
using VMSCore.ViewModels.MasterData;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.EntityModels;
using VMSCore.Machine.Controller;
using TCPProtocolClient;
using VMSCore.Machine.Entity;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class UC_MayInCJLinx : UserControl
    {
        EQUIP_PLANT_MAP doituong = new EQUIP_PLANT_MAP();
        frmTongHopMay frmMain;
        DataTable dtTong = new DataTable();
        DataTable dtTongNG = new DataTable();
        DataTable dtTongStatus = new DataTable();
        const int PORT_NO = 8882;
        const string SERVER_IP = "192.168.1.70";
        const char ESC = (char)0x1B;
        const char GS = (char)0x1D;
        const char STX = (char)0x02;
        const char EXT = (char)0x03;
        const char LF = (char)0x0A;
        //Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public EventDrivenTCPClient client;
        EventDrivenTCPClient.ConnectionStatus globalStatus = EventDrivenTCPClient.ConnectionStatus.NeverConnected;
        public string Lenhsanxuat = "";
        ProductionOrder globalLSX = new ProductionOrder();
        ProductionOrderDetail globalLSXDetail = new ProductionOrderDetail();
        int i = 0;
        public UC_MayInCJLinx(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
        {
            InitializeComponent();
            frmMain = frmLine;
            doituong = objX1;
            LoadCauHinh(objX1);
            if(txtIP.Text !="")
            {
                client = new EventDrivenTCPClient(IPAddress.Parse(txtIP.Text), Convert.ToUInt16(txtPort.Text.Trim()), true);
                client.DataReceived += new EventDrivenTCPClient.delDataReceived(client_DataReceived);
                client.ConnectionStatusChanged += new EventDrivenTCPClient.delConnectionStatusChanged(client_ConnectionStatusChanged);

            }


            ReadXml_User();
            //Lenhsanxuat = new DOCUMENT_CHECKEntity().DOCUMENTMax().ID;
            Lenhsanxuat = LenhSX;
            globalLSX = new ProductionOrderRepository().GetByCode(LenhSX);
            globalLSXDetail = new ProductionOrderDetailRepository().GetByCode(LenhSX);
        }
        public void LoadCauHinh(EQUIP_PLANT_MAP objdata)
        {
            for (int j = 0; j < objdata.headerptotocol.Count; j++)
            {
                if (objdata.headerptotocol[j].ProtocolParamCode.ToString() == "IP")
                {
                    txtIP.Text = objdata.headerptotocol[j].Data;
                }
                else if (objdata.headerptotocol[j].ProtocolParamCode.ToString() == "PORT")
                {
                    txtPort.Text = Convert.ToUInt16(objdata.headerptotocol[j].Data)+"";
                }

            }
            
        }
        void client_ConnectionStatusChanged(EventDrivenTCPClient sender, EventDrivenTCPClient.ConnectionStatus status)
        {
            //Check if this event was fired on a different thread, if it is then we must invoke it on the UI thread
            if (InvokeRequired)
            {
                Invoke(new EventDrivenTCPClient.delConnectionStatusChanged(client_ConnectionStatusChanged), sender, status);
                return;
            }
            if (globalStatus != status)
            {
                globalStatus = status;
                txtStatusConnect.Text = status.ToString();
                PRINT_MAKING_CONNECT doituongData = new PRINT_MAKING_CONNECT();
                doituongData.Id = Guid.NewGuid();
                doituongData.Code = doituongData.Id.ToString();
                doituongData.DeviceCode = doituong.header.Code;
                doituongData.IDName = doituong.header.Name;
                doituongData.LineProcess = doituong.line.Code;
                doituongData.ProductID = globalLSXDetail.ProductCode;
                doituongData.Sorted = new PRINT_MAKING_CONNECTRepository().GetMaxPRINT_MAKING_CONNECT() + 1;
                doituongData.ProductOrder = Lenhsanxuat;
                doituongData.Quantity = 1;
                doituongData.QuantityHex = "";
                doituongData.Data = new ConnectConfigRepository().GetByCodeMap(status.ToString()).Code;
                doituongData.Description = status.ToString();
                doituongData.CreateBy = objuser.Username;
                doituongData.ModifyBy = objuser.Username;
                doituongData.CreateDate = DateTime.Now;
                doituongData.ModifyDate = DateTime.Now;
                doituongData.Active = true;
                InsertDataTP_Connect(doituongData);

                MACHINE_SYNC objData = new MACHINE_SYNC();
                objData.KeyId = Guid.NewGuid();
                objData.Code = doituongData.Code;
                objData.DeviceGroupName = "PRINT_MAKING_CONNECT";
                objData.StatusType = "CONNECT";
                objData.TypeDeviceCode = doituong.header.TypeDeviceCode;
                objData.DeviceGroupCode = doituong.header.DeviceGroupCode;
                objData.DeviceCode = doituongData.DeviceCode;
                objData.DeviceName = doituong.header.Name;
                objData.LineCode = doituongData.LineProcess;
                objData.ProductOrderCode = doituongData.ProductOrder;
                objData.ProductCode = doituongData.ProductID;
                objData.Data = doituongData.Data;
                objData.Quantity = doituongData.Quantity;
                objData.QuantityHex = doituongData.QuantityHex;
                objData.BinaryHex = doituongData.BinaryHex;
                objData.Sorted = doituongData.Sorted;
                objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                objData.Description = status.ToString();
                objData.CreatorId = doituongData.CreateBy;
                objData.CreationTime = doituongData.CreateDate;
                objData.LastModifierId = doituongData.ModifyBy;
                objData.LastModificationTime = doituongData.ModifyDate;
                objData.Active = true;
                InsertMACHINE_SYNC(objData);

                MACHINE_CONNECT doituongmachine = new MACHINE_CONNECT();
                doituongmachine.Id = Guid.NewGuid();
                doituongmachine.Code = doituongmachine.Id.ToString();
                doituongmachine.DeviceCode = doituong.header.Code;
                doituongmachine.IDName = doituong.header.Name;
                doituongmachine.LineProcess = doituong.line.Code;
                doituongmachine.ProductID = globalLSXDetail.ProductCode;
                doituongmachine.Sorted = new MACHINE_CONNECTRepository().GetMaxMACHINE_CONNECT() + 1;
                doituongmachine.ProductOrder = Lenhsanxuat;
                doituongmachine.Quantity = 1;
                doituongmachine.QuantityHex = "";
                doituongmachine.Data = new ConnectConfigRepository().GetByCodeMap(status.ToString()).Code;
                doituongmachine.Description = status.ToString();
                doituongmachine.CreateBy = objuser.Username;
                doituongmachine.ModifyBy = objuser.Username;
                doituongmachine.CreateDate = DateTime.Now;
                doituongmachine.ModifyDate = DateTime.Now;
                doituongmachine.Active = true;
                InsertMachineTP_Connect(doituongmachine);
            }
        }
        public void InsertMACHINE_SYNC(MACHINE_SYNC doituong)
        {
            new MACHINE_SYNCRepository().Add(doituong);
        }
        public void InsertMachineTP_Data(MACHINE_DATA doituong)
        {
            new MACHINE_DATARepository().Add(doituong);
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertMachineTP_Connect(MACHINE_CONNECT doituong)
        {
            new MACHINE_CONNECTRepository().Add(doituong);
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertMachineTP_Error(MACHINE_ERROR doituong)
        {
            new MACHINE_ERRORRepository().Add(doituong);
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertMachineTP_Warning(MACHINE_WARNING doituong)
        {
            new MACHINE_WARNINGRepository().Add(doituong);
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertMachineTP_Status(MACHINE_STATUS doituong)
        {
            new MACHINE_STATUSRepository().Add(doituong);
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        //Fired when new data is received in the TCP client
        void client_DataReceived(EventDrivenTCPClient sender, byte[] data)
        {
            //Again, check if this needs to be invoked in the UI thread
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new EventDrivenTCPClient.delDataReceived(client_DataReceived), sender, data);
                }
                catch
                { }
                return;
            }
            //Interpret the received data object as a string

            //string strData = data as string;
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(strData);
            byte[] byData = data;//Chuyển Asscii sang Byte.
            string chuoiHex = "";
            //Add the received data to a rich text box
            //var result = Encoding.ASCII.GetString(data);

            for (int i = 0; i < byData.Length; i++)
            {
                chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
            }
            //memoStatus.Text = chuoiHex;//lấy byte
            HamPhanLoai(byData);
        }
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = _staffRepository.GetStaffByUserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
    
        /// <summary>
        /// Ham sum checksum
        /// </summary>
        /// <param name="byData"></param>
        /// <returns></returns>
        public string HamCheckSum(byte[] byData)
        {
            string Trave = "", temp = "";
            long data = 9 + byData.Length + new TCPProtocolClient.LibConvert().Hex_To_Integer("00") + new TCPProtocolClient.LibConvert().Hex_To_Integer("CA") + byData.Length + new TCPProtocolClient.LibConvert().GiaMaResultSum(byData);
            temp = new TCPProtocolClient.LibConvert().Integer_To_Hex(data);
            Trave = temp.Substring(temp.Length - 2);
            return Trave;
        }
        public string HamCheckSumByArray(byte[] byData)
        {
            string Trave = "", temp = "";
            long data = new TCPProtocolClient.LibConvert().GiaMaResultSum(byData);
            temp = new TCPProtocolClient.LibConvert().Integer_To_Hex(data);
            Trave = temp.Substring(temp.Length - 2);
            return Trave;
        }
        /// <summary>
        /// Đọc byte 6
        /// </summary>
        /// <param name="InputHex"></param>
        /// <returns></returns>
        public string StatusJetParser(string InputHex)
        {
            string Trave = "";
            long ChuoiInt = new Machine.Entity.LibConvert().Hex_To_Integer(InputHex);
            Array enums = Enum.GetValues(typeof(LINX_CIJ.STATUS_JET_MACHINE));
            foreach (LINX_CIJ.STATUS_JET_MACHINE name in enums)
            {
                if ((int)name == ChuoiInt)
                {
                    Trave = name.ToString();
                    break;
                }
                //DoSomething(suit);
                //MessageBox.Show(name.ToString() + "-" + (int)name);
            }
            return Trave;
        }
        /// <summary>
        /// Đọc byte số 7
        /// </summary>
        /// <param name="InputHex"></param>
        /// <returns></returns>
        public string StatusPrintParser(string InputHex)
        {
            string Trave = "";
            long ChuoiInt = new Machine.Entity.LibConvert().Hex_To_Integer(InputHex);
            Array enums = Enum.GetValues(typeof(LINX_CIJ.STATUS_PRINT_MACHINE));
            foreach (LINX_CIJ.STATUS_PRINT_MACHINE name in enums)
            {
                if ((int)name == ChuoiInt)
                {
                    Trave = name.ToString();
                    break;
                }
                //DoSomething(suit);
                //MessageBox.Show(name.ToString() + "-" + (int)name);
            }
            return Trave;
        }
        /// <summary>
        ///  đọc byte 8,9,10,11
        /// </summary>
        /// <param name="InputHex"> Ghép 4 byte xong đảo</param>
        /// <returns></returns>
        public string FindErrorParser(int InputHex)
        {
            string Trave = "Not Used";
            Array enums = Enum.GetValues(typeof(LINX_CIJ.STATUS_ERROR));
            foreach (LINX_CIJ.STATUS_ERROR name in enums)
            {
                if ((int)name == InputHex)
                {
                    Trave = name.ToString();
                    break;
                }
                //DoSomething(suit);
                //MessageBox.Show(name.ToString() + "-" + (int)name);
            }
            return Trave;
        }
        public string FindErrorParserM1(int InputHex)
        {
            string Trave = "Not Used";
            Array enums = Enum.GetValues(typeof(LINX_CIJ.STATUS_ERROR_WARNING));
            foreach (LINX_CIJ.STATUS_ERROR_WARNING name in enums)
            {
                if ((int)name == InputHex)
                {
                    Trave = name.ToString();
                    break;
                }
                //DoSomething(suit);
                //MessageBox.Show(name.ToString() + "-" + (int)name);
            }
            return Trave;
        }
        public string FindErrorParserM2(int InputHex)
        {
            string Trave = "Not Used";
            Array enums = Enum.GetValues(typeof(LINX_CIJ.STATUS_ERROR_WARNING_EXTEND));
            foreach (LINX_CIJ.STATUS_ERROR_WARNING_EXTEND name in enums)
            {
                if ((int)name == InputHex)
                {
                    Trave = name.ToString();
                    break;
                }
                //DoSomething(suit);
                //MessageBox.Show(name.ToString() + "-" + (int)name);
            }
            return Trave;
        }
        public List<DataError> GetlistError(string Chuoi)
        {
            List<DataError> doituong = new List<DataError>();
            DataError objdt = new DataError();
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (Chuoi[i].ToString() == "1")
                {
                    objdt = new DataError();
                    objdt.Name = FindErrorParser(i);
                    objdt.IDDecimal = i;
                    doituong.Add(objdt);
                }
            }
            return doituong;
        }
        public List<DataError> GetlistErrorM1(string Chuoi)
        {
            List<DataError> doituong = new List<DataError>();
            DataError objdt = new DataError();
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (Chuoi[i].ToString() == "1")
                {
                    objdt = new DataError();
                    objdt.Name = FindErrorParserM1(i);
                    objdt.IDDecimal = i;
                    doituong.Add(objdt);
                }
            }
            return doituong;
        }
        public List<DataError> GetlistErrorM2(string Chuoi)
        {
            List<DataError> doituong = new List<DataError>();
            DataError objdt = new DataError();
            for (int i = 0; i < Chuoi.Length; i++)
            {
                if (Chuoi[i].ToString() == "1")
                {
                    objdt = new DataError();
                    objdt.Name = FindErrorParserM2(i);
                    objdt.IDDecimal = i;
                    doituong.Add(objdt);
                }
            }
            return doituong;
        }
        /// <summary>
        /// Hàm xóa buffer dữ liệu gửi
        /// </summary>
        public void ClearBuffer()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, 0x00, 0x00 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);
        }
        /// <summary>
        /// Hàm reset dữ liệu counter, reset 4 byte đầu tiên trong 16 byte
        /// </summary>
        public void ResetCounter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiLenh = "1B 02 8c 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 1B 03";
            KhoiTao = new TCPProtocolClient.LibConvert().ConvertCommandHEX(ChuoiLenh);
            client.Send(KhoiTao);
        }
        /// <summary>
        /// Set counter là set 4 byte đầu.Thứ tự 1->4; 255 là FF 00 00 00
        /// Đọc counter là 4 byte đầu
        /// Đọc counter từ máy về sau đó set ngược lại máy in
        /// </summary>
        public void SetCounter(int Counter)
        {
            byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX("00 00 00 00");//Bản tin lưu 16 bytes
            byte[] Tam = new TCPProtocolClient.LibConvert().ConvertCommandHEX_FromString(new TCPProtocolClient.LibConvert().Integer_To_Hex(Counter));
            for (int i = Tam.Length - 1; i >= 0; i--)
            {
                receiveBuffer[Tam.Length - i - 1] = Tam[i];
            }
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiLenh = "1B 02 8c " + new TCPProtocolClient.LibConvert().GiaMaResultSpace(receiveBuffer) + " 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 1B 03";//set 255
            KhoiTao = new TCPProtocolClient.LibConvert().ConvertCommandHEX(ChuoiLenh);
            client.Send(KhoiTao);
        }
        /// <summary>
        /// Chọn layout bản tin, khi load layout sẽ reset bản tin
        /// </summary>
        /// <param name="BangTin"></param>
        public void LoadBangTin(string BangTin)
        {
            var size = 1024; // kích thước của bộ đệm
            byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");//Bản tin lưu 16 bytes
            byte[] Start = new byte[] { 0x1B, 0x02, 0x1E };
            byte[] End = new byte[] { 0x00, 0x00, 0x1B, 0x03 };
            byte[] Tam = System.Text.Encoding.ASCII.GetBytes(BangTin);
            for (int i = 0; i < Tam.Length; i++)
            {
                receiveBuffer[i] = Tam[i];
            }
            client.Send(Start);
            client.Send(receiveBuffer);
            client.Send(End);
            //var length = socket.Receive(receiveBuffer);

            // chuyển đổi mảng byte về chuỗi
            //var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
        }
        /// <summary>
        /// Đẩy dữ liệu cần in vào bản tin theo số ký tự cố định
        /// </summary>
        /// <param name="Chuoi"></param>
        public void SendBuffer(string Chuoi)
        {
            var size = 1024; // kích thước của bộ đệm
            //var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm    
            //byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
            byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX("00 00 00 00 00 00 00 00 00 00");

            //byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, 0x05, 0x00 };
            byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, 0x0A, 0x00 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            byte[] Tam = System.Text.Encoding.ASCII.GetBytes(Chuoi);
            for (int i = 0; i < Tam.Length; i++)
            {
                receiveBuffer[i] = Tam[i];
            }
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(Chuoi);
            client.Send(receiveBuffer);
            client.Send(End);
            //var length = socket.Receive(receiveBuffer);

            // chuyển đổi mảng byte về chuỗi
            //var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
        }
        public void SendBuffer(string Chuoi, int LengthChuoi)
        {
            var size = 1024; // kích thước của bộ đệm
            //var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm    
            //byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX("00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00");
            string ChuoiTest = "00";
            for (int i = 1; i < LengthChuoi; i++)
            {
                ChuoiTest = ChuoiTest + " " + "00";
            }
            byte[] receiveBuffer = new TCPProtocolClient.LibConvert().ConvertCommandHEX(ChuoiTest);

            //byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, 0x05, 0x00 };
            byte[] Start = new byte[] { 0x1B, 0x02, 0x1D, (byte)LengthChuoi, 0x00 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            byte[] Tam = System.Text.Encoding.ASCII.GetBytes(Chuoi);
            for (int i = 0; i < Tam.Length; i++)
            {
                receiveBuffer[i] = Tam[i];
            }
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(Chuoi);
            client.Send(receiveBuffer);
            client.Send(End);
            //var length = socket.Receive(receiveBuffer);

            // chuyển đổi mảng byte về chuỗi
            //var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
        }
        public void HamDocRequestCounter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiLenh = "1B 02 8D 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 1B 03";
            KhoiTao = new TCPProtocolClient.LibConvert().ConvertCommandHEX(ChuoiLenh);
            client.Send(KhoiTao);

        }
        public void HamDocRequestsStatus()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x14 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }
        public void HamDocRequestsStatusExtend()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x81 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }
        public void HamDocRequestsStatusExtend88()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0xAE };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }
        /// <summary>
        /// Hàm dừng máy in
        /// </summary>
        public void StopPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x12 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }

        /// <summary>
        /// Hàm chạy máy in
        /// </summary>
        public void StartPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x11 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }
        /// <summary>
        /// Hàm dừng phun mực
        /// </summary>
        public void StopJetPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x10 };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }
        /// <summary>
        /// Hàm phun mực
        /// </summary>
        public void StartJetPrint()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] Start = new byte[] { 0x1B, 0x02, 0x0F };
            byte[] End = new byte[] { 0x1B, 0x03 };
            client.Send(Start);
            client.Send(End);

        }
        public void RequestDataPrinter()
        {
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                HamDocRequestCounter();
                HamDocRequestsStatus();
                HamDocRequestsStatusExtend88();
            }
        }
        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
        public string HamPhanLoai(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 2)
            {
                if ((int.Parse(byData[1].ToString())) == (int)LINX_CIJ.COMMAND_ASCII.ACK)//kiểm tra lệnh trả về thành công hay thất bại
                {
                    if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.GETCOUNTER)//counter tổng
                    {
                        Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6)).ToString();
                        //DataRow row = dtTong.NewRow();
                        //row["Counter"] = Trave;
                        //row["Timer"] = DateTime.Now;
                        //dtTong.Rows.Add(row);
                        txtCounter.Text = Trave;
                        PRINT_MAKING_DATA doituongData = new PRINT_MAKING_DATA();
                        doituongData.Id = Guid.NewGuid();
                        doituongData.Code = doituongData.Id.ToString();
                        doituongData.DeviceCode = doituong.header.Code;
                        doituongData.IDName = doituong.header.Name;
                        doituongData.LineProcess = doituong.line.Code;
                        doituongData.ProductID = globalLSXDetail.ProductCode;
                        doituongData.ProductOrder = Lenhsanxuat;
                        doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                        doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6).ToString();
                        doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                        doituongData.Sorted = new PRINT_MAKING_DATARepository().GetMaxPRINT_MAKING_DATA() +1;
                        doituongData.CreateBy = objuser.Username;
                        doituongData.ModifyBy = objuser.Username;
                        doituongData.CreateDate = DateTime.Now;
                        doituongData.ModifyDate = DateTime.Now;
                        doituongData.Active = true;
                        InsertDataTP_Data(doituongData);

                        MACHINE_SYNC objData = new MACHINE_SYNC();
                        objData.KeyId = Guid.NewGuid();
                        objData.Code = doituongData.Code;
                        objData.DeviceGroupName = "PRINT_MAKING";
                        objData.StatusType = "DATA";
                        objData.TypeDeviceCode = doituong.header.TypeDeviceCode;
                        objData.DeviceGroupCode = doituong.header.DeviceGroupCode;
                        objData.DeviceCode = doituongData.DeviceCode;
                        objData.DeviceName = doituong.header.Name;
                        objData.LineCode = doituongData.LineProcess;
                        objData.ProductOrderCode = doituongData.ProductOrder;
                        objData.ProductCode = doituongData.ProductID;
                        objData.Data = doituongData.Data;
                        objData.Quantity = doituongData.Quantity;
                        objData.QuantityHex = doituongData.QuantityHex;
                        objData.BinaryHex = "";
                        objData.Sorted = doituongData.Sorted;
                        objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                        objData.Description = doituongData.Description;
                        objData.CreatorId = doituongData.CreateBy;
                        objData.CreationTime = doituongData.CreateDate;
                        objData.LastModifierId = doituongData.ModifyBy;
                        objData.LastModificationTime = doituongData.ModifyDate;
                        objData.Active = true;
                        InsertMACHINE_SYNC(objData);

                        MACHINE_DATA objMachine = new MACHINE_DATA();
                        objMachine.Id = Guid.NewGuid();
                        objMachine.Code = doituongData.Code;
                        objMachine.DeviceCode = doituongData.DeviceCode;
                        objMachine.IDName = doituong.header.Name;
                        objMachine.LineProcess = doituongData.LineProcess;
                        objMachine.ProductOrder = doituongData.ProductOrder;
                        objMachine.ProductID = doituongData.ProductID;
                        objMachine.Data = doituongData.Data;
                        objMachine.Quantity = doituongData.Quantity;
                        objMachine.QuantityHex = doituongData.QuantityHex;
                        objMachine.BinaryHex = "";
                        objMachine.Sorted = new MACHINE_DATARepository().GetMaxMACHINE_DATA() + 1;
                        objMachine.Description = doituongData.Description;
                        objMachine.CreateBy = objuser.Username;
                        objMachine.ModifyBy = objuser.Username;
                        objMachine.CreateDate = DateTime.Now;
                        objMachine.ModifyDate = DateTime.Now;
                        objMachine.Active = true;
                        InsertMachineTP_Data(objMachine);
                        //Counter = (int)doituong.Quantity;
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.SEND_BUFFER)//send data to 
                    {
                        //Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11)).ToString();
                        //DataRow row = dtTongNG.NewRow();
                        //row["Counter"] = Trave;
                        //row["Timer"] = DateTime.Now;
                        //dtTongNG.Rows.Add(row);
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.RESETCOUNTER)//Reset counter
                    {
                        //Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10)).ToString();
                        //DataRow row = dtTongStatus.NewRow();
                        //row["Counter"] = Trave;
                        //row["Timer"] = DateTime.Now;
                        //dtTongStatus.Rows.Add(row);
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.STATUS_RQ)//đọc trạng thái máy in
                    {
                        //Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11);

                        string PrinterState = "00", ErrorWarning = "", PrintJet = "";
                        PrinterState = StatusPrintParser(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 7, 7));
                        PrintJet = StatusJetParser(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 6, 6));
                        ErrorWarning = new TCPProtocolClient.LibConvert().DaoChuoi(new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 11)).PadLeft(8, '0') + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 10)).PadLeft(8, '0') + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 9)).PadLeft(8, '0') + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 8)).PadLeft(8, '0'));
                        List<DataError> objdt = GetlistError(ErrorWarning);
                        
                        for (int i = 0; i < objdt.Count; i++)
                        {
                            DataRow row = dtTongStatus.NewRow();
                            row["Counter"] = objdt[i].Name;
                            row["Timer"] = DateTime.Now;
                            dtTongStatus.Rows.Add(row);
                            PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
                            doituongData.Id = Guid.NewGuid();
                            doituongData.Code = doituongData.Id.ToString();
                            doituongData.DeviceCode = doituong.header.Code;
                            doituongData.IDName = doituong.header.Name;
                            doituongData.LineProcess = doituong.line.Code;
                            doituongData.ProductID = globalLSXDetail.ProductCode;
                            doituongData.ProductOrder = Lenhsanxuat;
                            doituongData.Quantity = (decimal)double.Parse(new TCPProtocolClient.LibConvert().Hex_To_Integer(ErrorWarning.ToString()).ToString());
                            doituongData.QuantityHex = ErrorWarning;
                            doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                            doituongData.Sorted = new PRINT_MAKING_STATUSRepository().GetMaxPRINT_MAKING_STATUS() + 1;
                            doituongData.Description = objdt[i].Name;
                            doituongData.CreateBy = objuser.Username;
                            doituongData.ModifyBy = objuser.Username;
                            doituongData.CreateDate = DateTime.Now;
                            doituongData.ModifyDate = DateTime.Now;
                            doituongData.Active = true;
                            InsertDataTP_Status(doituongData);

                            MACHINE_SYNC objData = new MACHINE_SYNC();
                            objData.KeyId = Guid.NewGuid();
                            objData.Code = doituongData.Code;
                            objData.DeviceGroupName = "PRINT_MAKING";
                            objData.StatusType = "STATUS";
                            objData.TypeDeviceCode = doituong.header.TypeDeviceCode;
                            objData.DeviceGroupCode = doituong.header.DeviceGroupCode;
                            objData.DeviceCode = doituongData.DeviceCode;
                            objData.DeviceName = doituong.header.Name;
                            objData.LineCode = doituongData.LineProcess;
                            objData.ProductOrderCode = doituongData.ProductOrder;
                            objData.ProductCode = doituongData.ProductID;
                            objData.Data = doituongData.Data;
                            objData.Quantity = doituongData.Quantity;
                            objData.QuantityHex = doituongData.QuantityHex;
                            objData.BinaryHex = "";
                            objData.Sorted = doituongData.Sorted;
                            objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                            objData.Description = doituongData.Description;
                            objData.CreatorId = doituongData.CreateBy;
                            objData.CreationTime = doituongData.CreateDate;
                            objData.LastModifierId = doituongData.ModifyBy;
                            objData.LastModificationTime = doituongData.ModifyDate;
                            objData.Active = true;
                            InsertMACHINE_SYNC(objData);

                            MACHINE_ERROR objMachine = new MACHINE_ERROR();
                            objMachine.Id = Guid.NewGuid();
                            objMachine.Code = doituongData.Code;
                            objMachine.DeviceCode = doituongData.DeviceCode;
                            objMachine.IDName = doituong.header.Name;
                            objMachine.LineProcess = doituongData.LineProcess;
                            objMachine.ProductOrder = doituongData.ProductOrder;
                            objMachine.ProductID = doituongData.ProductID;
                            objMachine.Data = doituongData.Data;
                            objMachine.Quantity = doituongData.Quantity;
                            objMachine.QuantityHex = doituongData.QuantityHex;
                            objMachine.BinaryHex = "";
                            objMachine.Sorted = new MACHINE_ERRORRepository().GetMaxMACHINE_ERROR() + 1;
                            objMachine.Description = doituongData.Description;
                            objMachine.CreateBy = objuser.Username;
                            objMachine.ModifyBy = objuser.Username;
                            objMachine.CreateDate = DateTime.Now;
                            objMachine.ModifyDate = DateTime.Now;
                            objMachine.Active = true;
                            InsertMachineTP_Error(objMachine);
                            if (objdt[i].IDDecimal == 31)
                            {
                                HamDocRequestsStatusExtend();
                            }
                        }

                        
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.LOAD_PRINT)//tải bản tin máy in
                    {
                        Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 1, byData.Length);
                        DataRow row = dtTongStatus.NewRow();
                        row["Counter"] = Trave;
                        row["Timer"] = DateTime.Now;
                        dtTongStatus.Rows.Add(row);
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.STATUS_RQ_EX)
                    {
                        Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 1, byData.Length);
                        DataRow row = dtTongStatus.NewRow();
                        row["Counter"] = Trave;
                        row["Timer"] = DateTime.Now;
                        dtTongStatus.Rows.Add(row);
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.STATUS_RQ_EX_88)//đọc trạng thái máy in
                    {
                        //Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11);

                        string PrinterState = "00", ErrorWarningM1 = "", PrintJet = "", ErrorWarningM2;
                        //PrinterState = StatusPrintParser(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 7, 7));
                        //PrintJet = StatusJetParser(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 6, 6));
                        ErrorWarningM1 = new TCPProtocolClient.LibConvert().DaoChuoi(new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 9)).PadLeft(8, '0')
                            + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 8)).PadLeft(8, '0')
                            + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 7)).PadLeft(8, '0')
                            + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 6)).PadLeft(8, '0'));
                        ErrorWarningM2 = new TCPProtocolClient.LibConvert().DaoChuoi(new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 13)).PadLeft(8, '0')
                            + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 12)).PadLeft(8, '0')
                            + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 11)).PadLeft(8, '0')
                            + new TCPProtocolClient.LibConvert().Integer_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultDecimalByIndex(byData, 10)).PadLeft(8, '0'));

                        List<DataError> objdtM1 = GetlistErrorM1(ErrorWarningM1);
                        List<DataError> objdtM2 = GetlistErrorM2(ErrorWarningM2);

                        
                        for (int i = 0; i < objdtM1.Count; i++)
                        {
                            DataRow row = dtTongStatus.NewRow();
                            row["Counter"] = objdtM1[i].Name;
                            row["Timer"] = DateTime.Now;
                            dtTongStatus.Rows.Add(row);
                            PRINT_MAKING_WARNING doituongData = new PRINT_MAKING_WARNING();
                            doituongData.Id = Guid.NewGuid();
                            doituongData.Code = doituongData.Id.ToString();
                            doituongData.DeviceCode = doituong.header.Code;
                            doituongData.IDName = doituong.header.Name;
                            doituongData.LineProcess = doituong.line.Code;
                            doituongData.ProductID = globalLSXDetail.ProductCode;
                            doituongData.ProductOrder = Lenhsanxuat;
                            doituongData.Quantity = (decimal)double.Parse(new TCPProtocolClient.LibConvert().Hex_To_Integer(ErrorWarningM1.ToString()).ToString());
                            doituongData.QuantityHex = ErrorWarningM1;
                            doituongData.Description = objdtM1[i].Name;
                            doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                            doituongData.Sorted = new PRINT_MAKING_WARNINGRepository().GetMaxPRINT_MAKING_WARNING() + 1;
                            doituongData.CreateBy = objuser.Username;
                            doituongData.ModifyBy = objuser.Username;
                            doituongData.CreateDate = DateTime.Now;
                            doituongData.ModifyDate = DateTime.Now;
                            doituongData.Active = true;
                            InsertDataTP_Warning(doituongData);

                            MACHINE_SYNC objData = new MACHINE_SYNC();
                            objData.KeyId = Guid.NewGuid();
                            objData.Code = doituongData.Code;
                            objData.DeviceGroupName = "PRINT_MAKING";
                            objData.StatusType = "WARNING";
                            objData.TypeDeviceCode = doituong.header.TypeDeviceCode;
                            objData.DeviceGroupCode = doituong.header.DeviceGroupCode;
                            objData.DeviceCode = doituongData.DeviceCode;
                            objData.DeviceName = doituong.header.Name;
                            objData.LineCode = doituongData.LineProcess;
                            objData.ProductOrderCode = doituongData.ProductOrder;
                            objData.ProductCode = doituongData.ProductID;
                            objData.Data = doituongData.Data;
                            objData.Quantity = doituongData.Quantity;
                            objData.QuantityHex = doituongData.QuantityHex;
                            objData.BinaryHex = "";
                            objData.Sorted = doituongData.Sorted;
                            objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                            objData.Description = doituongData.Description;
                            objData.CreatorId = doituongData.CreateBy;
                            objData.CreationTime = doituongData.CreateDate;
                            objData.LastModifierId = doituongData.ModifyBy;
                            objData.LastModificationTime = doituongData.ModifyDate;
                            objData.Active = true;
                            InsertMACHINE_SYNC(objData);

                            MACHINE_WARNING objMachine = new MACHINE_WARNING();
                            objMachine.Id = Guid.NewGuid();
                            objMachine.Code = doituongData.Code;
                            objMachine.DeviceCode = doituongData.DeviceCode;
                            objMachine.IDName = doituong.header.Name;
                            objMachine.LineProcess = doituongData.LineProcess;
                            objMachine.ProductOrder = doituongData.ProductOrder;
                            objMachine.ProductID = doituongData.ProductID;
                            objMachine.Data = doituongData.Data;
                            objMachine.Quantity = doituongData.Quantity;
                            objMachine.QuantityHex = doituongData.QuantityHex;
                            objMachine.BinaryHex = "";
                            objMachine.Sorted = new MACHINE_WARNINGRepository().GetMaxMACHINE_WARNING() + 1;
                            objMachine.Description = doituongData.Description;
                            objMachine.CreateBy = objuser.Username;
                            objMachine.ModifyBy = objuser.Username;
                            objMachine.CreateDate = DateTime.Now;
                            objMachine.ModifyDate = DateTime.Now;
                            objMachine.Active = true;
                            InsertMachineTP_Warning(objMachine);
                            //if (objdt[i].IDDecimal == 31)
                            //{
                            //    HamDocRequestsStatusExtend();
                            //}
                        }
                        for (int i = 0; i < objdtM2.Count; i++)
                        {
                            DataRow row = dtTongStatus.NewRow();
                            row["Counter"] = objdtM2[i].Name;
                            row["Timer"] = DateTime.Now;
                            dtTongStatus.Rows.Add(row);
                            PRINT_MAKING_WARNING doituongData = new PRINT_MAKING_WARNING();
                            doituongData.Id = Guid.NewGuid();
                            doituongData.Code = doituongData.Id.ToString();
                            doituongData.DeviceCode = doituong.header.Code;
                            doituongData.IDName = doituong.header.Name;
                            doituongData.LineProcess = doituong.line.Code;
                            doituongData.ProductID = globalLSXDetail.ProductCode;
                            doituongData.ProductOrder = Lenhsanxuat;
                            doituongData.Quantity = (decimal)double.Parse(new TCPProtocolClient.LibConvert().Hex_To_Integer(ErrorWarningM2.ToString()).ToString());
                            doituongData.QuantityHex = ErrorWarningM2;
                            doituongData.Description = objdtM2[i].Name;
                            doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                            doituongData.Sorted = new PRINT_MAKING_WARNINGRepository().GetMaxPRINT_MAKING_WARNING() + 1;
                            doituongData.CreateBy = objuser.Username;
                            doituongData.ModifyBy = objuser.Username;
                            doituongData.CreateDate = DateTime.Now;
                            doituongData.ModifyDate = DateTime.Now;
                            doituongData.Active = true;
                            InsertDataTP_Warning(doituongData);

                            MACHINE_SYNC objData = new MACHINE_SYNC();
                            objData.KeyId = Guid.NewGuid();
                            objData.Code = doituongData.Code;
                            objData.DeviceGroupName = "PRINT_MAKING";
                            objData.StatusType = "WARNING";
                            objData.TypeDeviceCode = doituong.header.TypeDeviceCode;
                            objData.DeviceGroupCode = doituong.header.DeviceGroupCode;
                            objData.DeviceCode = doituongData.DeviceCode;
                            objData.DeviceName = doituong.header.Name;
                            objData.LineCode = doituongData.LineProcess;
                            objData.ProductOrderCode = doituongData.ProductOrder;
                            objData.ProductCode = doituongData.ProductID;
                            objData.Data = doituongData.Data;
                            objData.Quantity = doituongData.Quantity;
                            objData.QuantityHex = doituongData.QuantityHex;
                            objData.BinaryHex = "";
                            objData.Sorted = doituongData.Sorted;
                            objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                            objData.Description = doituongData.Description;
                            objData.CreatorId = doituongData.CreateBy;
                            objData.CreationTime = doituongData.CreateDate;
                            objData.LastModifierId = doituongData.ModifyBy;
                            objData.LastModificationTime = doituongData.ModifyDate;
                            objData.Active = true;
                            InsertMACHINE_SYNC(objData);

                            MACHINE_WARNING objMachine = new MACHINE_WARNING();
                            objMachine.Id = Guid.NewGuid();
                            objMachine.Code = doituongData.Code;
                            objMachine.DeviceCode = doituongData.DeviceCode;
                            objMachine.IDName = doituong.header.Name;
                            objMachine.LineProcess = doituongData.LineProcess;
                            objMachine.ProductOrder = doituongData.ProductOrder;
                            objMachine.ProductID = doituongData.ProductID;
                            objMachine.Data = doituongData.Data;
                            objMachine.Quantity = doituongData.Quantity;
                            objMachine.QuantityHex = doituongData.QuantityHex;
                            objMachine.BinaryHex = "";
                            objMachine.Sorted = new MACHINE_WARNINGRepository().GetMaxMACHINE_WARNING() + 1;
                            objMachine.Description = doituongData.Description;
                            objMachine.CreateBy = objuser.Username;
                            objMachine.ModifyBy = objuser.Username;
                            objMachine.CreateDate = DateTime.Now;
                            objMachine.ModifyDate = DateTime.Now;
                            objMachine.Active = true;
                            InsertMachineTP_Warning(objMachine);
                            //if (objdt[i].IDDecimal == 31)
                            //{
                            //    HamDocRequestsStatusExtend();
                            //}
                        }
                       
                    }
                    else if ((int.Parse(byData[4].ToString())) == (int)LINX_CIJ.COMMAND_LINX.START_JET)
                    {
                        Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 1, byData.Length);
                        DataRow row = dtTongStatus.NewRow();
                        row["Counter"] = Trave;
                        row["Timer"] = DateTime.Now;
                        dtTongStatus.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("Fail");
                    //Kết quả trả về fail
                    //hiển thị lỗi máy in
                }

            }
            else if (byData.Length == 2)
            {
                if ((int.Parse(byData[1].ToString())) == (int)LINX_CIJ.STATUS_RECEIV_MACHINE.SI_Print_go_character)//Print go character received 
                {
                    i++;
                    PRINT_MAKING_DATA doituongData = new PRINT_MAKING_DATA();
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.Quantity = 1;
                    doituongData.QuantityHex = "";
                    doituongData.Data = "";
                    doituongData.Sorted = new PRINT_MAKING_DATARepository().GetMaxPRINT_MAKING_DATA() + 1;
                    doituongData.Description = "";
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Data(doituongData);

                    MACHINE_SYNC objData = new MACHINE_SYNC();
                    objData.KeyId = Guid.NewGuid();
                    objData.Code = doituongData.Code;
                    objData.DeviceGroupName = "PRINT_MAKING";
                    objData.StatusType = "DATA";
                    objData.TypeDeviceCode = doituong.header.TypeDeviceCode;
                    objData.DeviceGroupCode = doituong.header.DeviceGroupCode;
                    objData.DeviceCode = doituongData.DeviceCode;
                    objData.DeviceName = doituong.header.Name;
                    objData.LineCode = doituongData.LineProcess;
                    objData.ProductOrderCode = doituongData.ProductOrder;
                    objData.ProductCode = doituongData.ProductID;
                    objData.Data = doituongData.Data;
                    objData.Quantity = doituongData.Quantity;
                    objData.QuantityHex = doituongData.QuantityHex;
                    objData.BinaryHex = "";
                    objData.Sorted = doituongData.Sorted;
                    objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                    objData.Description = doituongData.Description;
                    objData.CreatorId = doituongData.CreateBy;
                    objData.CreationTime = doituongData.CreateDate;
                    objData.LastModifierId = doituongData.ModifyBy;
                    objData.LastModificationTime = doituongData.ModifyDate;
                    objData.Active = true;
                    InsertMACHINE_SYNC(objData);

                    MACHINE_DATA objMachine = new MACHINE_DATA();
                    objMachine.Id = Guid.NewGuid();
                    objMachine.Code = doituongData.Code;
                    objMachine.DeviceCode = doituongData.DeviceCode;
                    objMachine.IDName = doituong.header.Name;
                    objMachine.LineProcess = doituongData.LineProcess;
                    objMachine.ProductOrder = doituongData.ProductOrder;
                    objMachine.ProductID = doituongData.ProductID;
                    objMachine.Data = doituongData.Data;
                    objMachine.Quantity = doituongData.Quantity;
                    objMachine.QuantityHex = doituongData.QuantityHex;
                    objMachine.BinaryHex = "";
                    objMachine.Sorted = new MACHINE_DATARepository().GetMaxMACHINE_DATA() + 1;
                    objMachine.Description = doituongData.Description;
                    objMachine.CreateBy = objuser.Username;
                    objMachine.ModifyBy = objuser.Username;
                    objMachine.CreateDate = DateTime.Now;
                    objMachine.ModifyDate = DateTime.Now;
                    objMachine.Active = true;
                    InsertMachineTP_Data(objMachine);
                    txtCounter.Text = i.ToString();
                }
                else if ((int.Parse(byData[1].ToString())) == (int)LINX_CIJ.STATUS_RECEIV_MACHINE.EM_Print_end_character)//EM_Print_end_character 
                {
                    txtCode.Text = LINX_CIJ.STATUS_RECEIV_MACHINE.EM_Print_end_character.ToString();
                }
            }
            return Trave;
        }
        public void InsertAnser(MACHINECOUNTER doituong)
        {
            //new MACHINECOUNTEREntity().ThemMACHINECOUNTER(doituong);
        }
        public void InsertDataTP_Data(PRINT_MAKING_DATA doituong)
        {
            new PRINT_MAKING_DATARepository().Add(doituong);
        }
        public void InsertDataTP_Warning(PRINT_MAKING_WARNING doituong)
        {
            new PRINT_MAKING_WARNINGRepository().Add(doituong);

            //new PRINT_MAKING_WARNINGEntity().ThemPRINT_MAKING_WARNING(doituong);
        }
        public void InsertDataTP_Error(PRINT_MAKING_ERROR doituong)
        {
            new PRINT_MAKING_ERRORRepository().Add(doituong);
        }
        public void InsertDataTP_Connect(PRINT_MAKING_CONNECT doituong)
        {
            new PRINT_MAKING_CONNECTRepository().Add(doituong);
        }
        public void InsertDataTP_Status(PRINT_MAKING_STATUS doituong)
        {
            new PRINT_MAKING_STATUSRepository().Add(doituong);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //frmMain.HienThiThongTin(doituong.header.IDEQUIP, txtIP.Text, "Start...");
            client.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartPrint();
            PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
            doituongData.Id = Guid.NewGuid();
            doituongData.Code = doituong.header.Code;
            doituongData.IDName = doituong.header.Name;
            doituongData.ProductID = "";
            doituongData.LineProcess = doituong.line.Code;
            doituongData.ProductOrder = Lenhsanxuat;
            doituongData.Quantity = 1;
            doituongData.QuantityHex = "";
            doituongData.Data = "START";
            //doituongData.Sorted = new SECONDARY_PACKING_ERROREntity().GetMaxSECONDARY_PACKING_ERROR() + 1;
            doituongData.CreateBy = objuser.Username;
            doituongData.ModifyBy = objuser.Username;
            doituongData.CreateDate = DateTime.Now;
            doituongData.ModifyDate = DateTime.Now;
            doituongData.Active = true;
            InsertDataTP_Status(doituongData);
            txtStatusMachine.Text = "START";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPrint();
            PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
            doituongData.Id = Guid.NewGuid();
            doituongData.Code = doituong.header.Code;
            doituongData.IDName = doituong.header.Name;
            doituongData.ProductID = "";
            doituongData.LineProcess = doituong.line.Code;
            doituongData.ProductOrder = Lenhsanxuat;
            doituongData.Quantity = 1;
            doituongData.QuantityHex = "";
            doituongData.Data = "STOP";
            //doituongData.Sorted = new SECONDARY_PACKING_ERROREntity().GetMaxSECONDARY_PACKING_ERROR() + 1;
            doituongData.CreateBy = objuser.Username;
            doituongData.ModifyBy = objuser.Username;
            doituongData.CreateDate = DateTime.Now;
            doituongData.ModifyDate = DateTime.Now;
            doituongData.Active = true;
            InsertDataTP_Status(doituongData);
            txtStatusMachine.Text = "STOP";


        }

        private void btnUpCode_Click(object sender, EventArgs e)
        {
            string NgaySX = String.Format("{0:dd.MM.yyyy}", globalLSX.ManufactureDate);
            string HanSD = String.Format("{0:dd.MM.yyyy}", globalLSX.ExpireDate);
            string LotNum = globalLSXDetail.LotNumber;
            SendBuffer(NgaySX + HanSD + LotNum, 30);
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            ResetCounter();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            StopPrint();
            //LoadBangTin("TEST 4.1");
            LoadBangTin("VMS");
        }
        public void StartMay()
        {
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                StartPrint();

            }
        }
        public void StopMay()
        {
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                StopPrint();
                txtStatusMachine.Text = "STOP";

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            HamDocRequestCounter();
        }
    }
}
