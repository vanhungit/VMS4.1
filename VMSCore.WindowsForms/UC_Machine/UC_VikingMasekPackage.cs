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

namespace VMSCore.WindowsForms
{
    public partial class UC_VikingMasekPackage : UserControl
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
        public UC_VikingMasekPackage(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
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
            globalStatus = status;
            txtStatusConnect.Text = status.ToString();
            PRINT_MAKING_CONNECT doituongData = new PRINT_MAKING_CONNECT();
            doituongData.Id = Guid.NewGuid();
            doituongData.Code = "";
            doituongData.IDName = doituong.header.Code;
            doituongData.LineProcess = doituong.line.Code;
            doituongData.ProductID = "";
            doituongData.ProductOrder = Lenhsanxuat;
            doituongData.Quantity = 1;
            doituongData.QuantityHex = "";
            doituongData.Data = status.ToString();
            doituongData.CreateBy = objuser.Username;
            doituongData.ModifyBy = objuser.Username;
            doituongData.CreateDate = DateTime.Now;
            doituongData.ModifyDate = DateTime.Now;
            doituongData.Active = true;
            InsertDataTP_Connect(doituongData);
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
        public void HamDocRequestCounter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 0C 00 CA 00 00 03 00 00 00 00 44 44 44 A5 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(memoChuoi.Text);
            //socket.Send(byData);
            //socket.Send(End);
            //var length = socket.Receive(receiveBuffer);

            // chuyển đổi mảng byte về chuỗi
            //var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
            //string chuoiHex = (int.Parse(receiveBuffer[8].ToString()) > 15 ? int.Parse(receiveBuffer[8].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[8].ToString()).ToString("X"))
            //    + (int.Parse(receiveBuffer[7].ToString()) > 15 ? int.Parse(receiveBuffer[7].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[7].ToString()).ToString("X"))
            //    + (int.Parse(receiveBuffer[6].ToString()) > 15 ? int.Parse(receiveBuffer[6].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[6].ToString()).ToString("X"))
            //    + (int.Parse(receiveBuffer[5].ToString()) > 15 ? int.Parse(receiveBuffer[5].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[5].ToString()).ToString("X"));
            //int int_value = Convert.ToInt32(chuoiHex, 16);
            //memoStatus.Text = int_value + "";
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
        public byte[] SetDynamicStringTable(string Var1, string Var2, string Var3, string Var4, string Var5)
        {
            int LengthVAR = 9 + Var1.Length + Var2.Length + Var3.Length + Var4.Length + Var5.Length;
            string strVAR = Var1 + Var2 + Var3 + Var4 + Var5;
            byte[] arrBuffer = new byte[2 + LengthVAR];

            arrBuffer[0] = (byte)(LengthVAR >> 8);
            arrBuffer[1] = (byte)LengthVAR;
            arrBuffer[2] = 0;
            arrBuffer[3] = 0xCA;
            arrBuffer[6] = (byte)(Var1.Length);
            arrBuffer[7] = (byte)(Var2.Length);
            arrBuffer[8] = (byte)(Var3.Length);
            arrBuffer[9] = (byte)(Var4.Length);
            arrBuffer[10] = (byte)(Var5.Length);

            byte[] arrVAR = System.Text.Encoding.ASCII.GetBytes(strVAR);
            Array.Copy(arrVAR, 0, arrBuffer, 11, arrVAR.Length);    //add var 1, var2,... to array

            return PackSend(arrBuffer);
        }
        private byte[] PackSend(byte[] arrSend)
        {
            byte[] arrPackSend = new byte[arrSend.Length + 3];
            byte _Checksum = 0;

            foreach (byte b in arrSend)
                _Checksum += b;

            arrPackSend[0] = 0x02;
            arrPackSend[arrPackSend.Length - 2] = _Checksum;
            arrPackSend[arrPackSend.Length - 1] = 0x03;
            // update data array
            for (int i = 0; i < arrSend.Length; i++)
                arrPackSend[i + 1] = arrSend[i];
            return arrPackSend;
        }
        /// <summary>
        /// Load dữ liệu cần in vào bản tin
        /// </summary>
        /// <param name="BangTin"></param>
        public void LoadBangTin(string BangTin)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 " + new TCPProtocolClient.LibConvert().Integer_To_Hex(9 + BangTin.Trim().Length) + " 00 CA 00 00 " + new TCPProtocolClient.LibConvert().Integer_To_Hex(BangTin.Trim().Length) + " 00 00 00 00 " + new TCPProtocolClient.LibConvert().GiaMaResultSpace(System.Text.Encoding.ASCII.GetBytes(BangTin)) + " " + HamCheckSum(System.Text.Encoding.ASCII.GetBytes(BangTin)) + " 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(memoChuoi.Text);
            //socket.Send(byData);
            //socket.Send(End);
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoai(receiveBuffer);
            // chuyển đổi mảng byte về chuỗi
            //var result = Encoding.ASCII.GetString(receiveBuffer, 0, length);
            //string chuoiHex = (int.Parse(receiveBuffer[8].ToString()) > 15 ? int.Parse(receiveBuffer[8].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[8].ToString()).ToString("X"))
            //    + (int.Parse(receiveBuffer[7].ToString()) > 15 ? int.Parse(receiveBuffer[7].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[7].ToString()).ToString("X"))
            //    + (int.Parse(receiveBuffer[6].ToString()) > 15 ? int.Parse(receiveBuffer[6].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[6].ToString()).ToString("X"))
            //    + (int.Parse(receiveBuffer[5].ToString()) > 15 ? int.Parse(receiveBuffer[5].ToString()).ToString("X") : "0" + int.Parse(receiveBuffer[5].ToString()).ToString("X"));
            //int int_value = Convert.ToInt32(chuoiHex, 16);
            //memoStatus.Text = int_value + "";

        }
        /// <summary>
        /// Dừng máy in 
        /// </summary>
        public void StopPrinter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 06 00 46 00 00 00 00 4C 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoai(receiveBuffer);
        }
        /// <summary>
        /// chọn thứ tự bản tin để in, hàm start máy in
        /// </summary>
        public void StartPrinter(int TTBanTin)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm 
            string Trave = "", temp = "";
            long data = new TCPProtocolClient.LibConvert().Hex_To_Integer("06") + new TCPProtocolClient.LibConvert().Hex_To_Integer("46") + TTBanTin;
            temp = new TCPProtocolClient.LibConvert().Integer_To_Hex(data);
            Trave = temp.Substring(temp.Length - 2);
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 06 00 46 " + new TCPProtocolClient.LibConvert().Integer_To_Hex(TTBanTin) + " 00 00 00 " + Trave + " 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //txtLenhSX.Text = ChuoiSend;
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoai(receiveBuffer);
        }
        /// <summary>
        /// True : start
        /// </summary>
        /// <param name="TTBanTin"></param>
        public void LoadBanTinANSER(bool TTBanTin)
        {
            var size = 20; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm 
            if (TTBanTin)
            {
                receiveBuffer[1] = 0x02;
            }
            else
                receiveBuffer[1] = 0x03;

        }
        /// <summary>
        /// reset về 0
        /// 65000 = E8 FD 00 00
        /// </summary>
        public void SetCounterPrinter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            //string ChuoiSend = "02 00 06 00 E5 00 00 00 00 EB 03";
            string ChuoiSend = "02 00 06 00 E5 E8 FD 00 00 D0 03";//set counter > 0;1->4
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoai(receiveBuffer);
        }
        public void ResetCounterPrinter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 06 00 E5 00 00 00 00 EB 03";
            //string ChuoiSend = "02 00 06 00 E5 E8 FD 00 00 D0 03";//set counter > 0;1->4
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoai(receiveBuffer);
        }
        public void SetCounter3BPrinter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 16 00 3B 02 01 09 00 00 00 FF FF 00 00 03 00 00 00 01 05 01 00 01 00 66 03";
            //string ChuoiSend = "02 00 06 00 E5 E8 FD 00 00 D0 03";//set counter > 0;1->4
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoai(receiveBuffer);
        }
        public void GetCounterPrinter()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 02 00 D2 D4 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamPhanLoaiGetCounter(receiveBuffer);
        }
        public void GetPrinterAlarm()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 02 00 7F 81 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamGiaiMaAlarmStatus(receiveBuffer);
        }
        public void GetPrinterStatus()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x1F, 0x58, 0x03 };
            string ChuoiSend = "02 00 02 00 45 47 03";
            String CodeReplaceSpace = ChuoiSend.Trim().Replace(" ", "");
            String CodeReplaceENTER = CodeReplaceSpace.Trim().Replace("\r\n", "");
            KhoiTao = ConvertHexStringToByteArray(CodeReplaceENTER);
            client.Send(KhoiTao);
            //var length = socket.Receive(receiveBuffer);
            //HamGiaiMaStatusPrinter(receiveBuffer);
        }
        public void RequestDataPrinter()
        {
            GetPrinterAlarm();
            GetPrinterStatus();
            GetCounterPrinter();
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

                if ((int.Parse(byData[4].ToString())) == 79)//Kết quả OK là 4F
                {
                    //MessageBox.Show("Lệnh OK");
                }
                else if ((int.Parse(byData[4].ToString())) == 48)//Kết quả OK sau in, cũng command get counter luôn
                {
                    //MessageBox.Show("Lệnh in OK");
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6)).ToString();
                    txtCounter.Text = Trave;
                    PRINT_MAKING_DATA doituongData = new PRINT_MAKING_DATA();
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.TypeDevice = doituong.header.TypeDeviceCode;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6).ToString();
                    doituongData.Data = txtCode.Text.Trim();
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Data(doituongData);

                    MACHINECOUNTER doituongcounterTong = new MACHINECOUNTER();
                    doituongcounterTong.Id = Guid.NewGuid();
                    doituongcounterTong.ProductOrder = Lenhsanxuat;
                    doituongcounterTong.IDName = client.IP.ToString();
                    doituongcounterTong.CountPrevious = long.Parse(Trave);
                    doituongcounterTong.CountTong = long.Parse(Trave);
                    doituongcounterTong.CreateDate = DateTime.Now;
                    doituongcounterTong.ModifyDate = DateTime.Now;
                    InsertAnser(doituongcounterTong);
                    //Update Code đã in

                    //BOX_ASSIGN objX1_confirm = new BOX_ASSIGN();
                    //objX1_confirm.DeviceConfirm = doituong.header.IDEQUIP;
                    //objX1_confirm.CodeBox = txtCode.Text.Trim();
                    //new BOX_ASSIGNEntity().UpdateBoxConfirm(objX1_confirm);
                    //BOX_ASSIGN objX1 = new BOX_ASSIGN();
                    //objX1 = new BOX_ASSIGNEntity().BOX_ASSIGNGetCodeDeviceHandle(doituong.header.IDEQUIP);
                    //if (objX1.CodeBox != "")
                    //{
                    //    BoxData data = new BoxDataEntity().BoxDataGetByID(objX1.CodeBox);
                    //    txtCode.Text = data.ID;
                    //    client.Send(SetDynamicStringTable(String.Format("{0:dd/MM/yyyy}", data.DateManufacture) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), String.Format("{0:dd/MM/yyyy}", data.DateExpire), data.QRCode, data.ID, "05"));
                    //}
                    //else
                    //{
                    //    objX1 = new BOX_ASSIGNEntity().BOX_ASSIGNGetCodeFree("L0011", doituong.line.Code);
                    //    BoxData data = new BoxDataEntity().BoxDataGetByID(objX1.CodeBox);
                    //    txtCode.Text = data.ID;
                    //    objX1.DeviceHandeld = doituong.header.IDEQUIP;
                    //    new BOX_ASSIGNEntity().UpdateBoxHandle(objX1);
                    //    client.Send(SetDynamicStringTable(String.Format("{0:dd/MM/yyyy}", data.DateManufacture) + " " + String.Format("{0:HH:mm:ss}", DateTime.Now), String.Format("{0:dd/MM/yyyy}", data.DateExpire), data.QRCode, data.ID, "05"));

                    //}
                    //client.Send(SetDynamicStringTable(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now), "24/09/2025", "https://qrvitadairy.vn/dt?qr=THUG7W01Y9012H5B5", "THUG7W01Y9012H5B5", "05"));

                }
                else if ((int.Parse(byData[4].ToString())) == 127)//mã lệnh AlarmStatus 7F
                {
                    //MessageBox.Show("OK");
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 7, 6)).ToString();
                    PRINT_MAKING_ERROR doituongData = new PRINT_MAKING_ERROR();
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = "";
                    doituongData.IDName = doituong.header.Name;
                    doituongData.ProductID = "";
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 7, 6).ToString();
                    doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Error(doituongData);

                }
                else if ((int.Parse(byData[4].ToString())) == 69)//mã lệnh Status Printer 45
                {
                    //MessageBox.Show("OK");
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 13, 6)).ToString();
                    //DataRow row = dtTongNG.NewRow();
                    //row["Counter"] = Trave;
                    //row["Timer"] = DateTime.Now;
                    //dtTongNG.Rows.Add(row);
                    PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.ProductID = "";
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 13, 6).ToString();
                    doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                    //doituongData.Sorted = new SECONDARY_PACKING_ERROREntity().GetMaxSECONDARY_PACKING_ERROR() + 1;
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Status(doituongData);

                }
                else if ((int.Parse(byData[4].ToString())) == 210)//counter tổng D2
                {
                    //Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6)).ToString();
                    //DataRow row = dtTong.NewRow();
                    //row["Counter"] = Trave;
                    //row["Timer"] = DateTime.Now;
                    //dtTong.Rows.Add(row);
                    //SECONDARY_PACKING doituong = new SECONDARY_PACKING();
                    //doituong.KeyID = Guid.NewGuid();
                    //doituong.IDKey = "";
                    //doituong.IDName = SERVER_IP;
                    //doituong.ProductID = "";
                    //doituong.TypeDevice = 3;
                    //doituong.ProductOrder = "0000000001";
                    //doituong.Quantity = (decimal)double.Parse(Trave.ToString());
                    //doituong.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6).ToString();
                    //doituong.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituong.QuantityHex.Trim());
                    //doituong.Sorted = new SECONDARY_PACKINGEntity().GetMaxSECONDARY_PACKING() + 1;
                    //doituong.CreateBy = objuser.Username;
                    //doituong.ModifyBy = objuser.Username;
                    //doituong.CreateDate = DateTime.Now;
                    //doituong.ModifyDate = DateTime.Now;
                    //doituong.Active = true;
                    //InsertDataCounter(doituong);
                }
                else
                {
                    //MessageBox.Show("Fail");
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
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertDataTP_Warning(PRINT_MAKING_WARNING doituong)
        {
            //new PRINT_MAKING_WARNINGEntity().ThemPRINT_MAKING_WARNING(doituong);
        }
        public void InsertDataTP_Error(PRINT_MAKING_ERROR doituong)
        {
            //new PRINT_MAKING_ERROREntity().ThemPRINT_MAKING_ERROR(doituong);
        }
        public void InsertDataTP_Connect(PRINT_MAKING_CONNECT doituong)
        {
            //new PRINT_MAKING_CONNECTEntity().ThemPRINT_MAKING_CONNECT(doituong);
        }
        public void InsertDataTP_Status(PRINT_MAKING_STATUS doituong)
        {
            //new PRINT_MAKING_STATUSEntity().ThemPRINT_MAKING_STATUS(doituong);
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
            StartPrinter(6);// chọn bản tin
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
            StopPrinter();
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
            //BOX_ASSIGN objX1 = new BOX_ASSIGN();
            //objX1 = new BOX_ASSIGNEntity().BOX_ASSIGNGetCodeDeviceHandle(doituong.header.IDEQUIP);
            //if (objX1.CodeBox !="")
            //{
            //    BoxData data = new BoxDataEntity().BoxDataGetByID(objX1.CodeBox);
            //    txtCode.Text = data.ID;
            //    client.Send(SetDynamicStringTable(String.Format("{0:dd/MM/yyyy HH:mm:ss}", data.DateManufacture), String.Format("{0:dd/MM/yyyy}", data.DateExpire), data.QRCode, data.ID, ""));
            //}
            //else
            //{
            //    objX1 = new BOX_ASSIGNEntity().BOX_ASSIGNGetCodeFree("L0011", doituong.line.Code);
            //    BoxData data = new BoxDataEntity().BoxDataGetByID(objX1.CodeBox);
            //    txtCode.Text = data.ID;
            //    objX1.DeviceHandeld = doituong.header.IDEQUIP;
            //    new BOX_ASSIGNEntity().UpdateBoxHandle(objX1);
            //    client.Send(SetDynamicStringTable(String.Format("{0:dd/MM/yyyy HH:mm:ss}", data.DateManufacture), String.Format("{0:dd/MM/yyyy}", data.DateExpire), data.QRCode, data.ID, ""));

            //}
            //client.Send(SetDynamicStringTable(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now), "24/09/2025", "https://qrvitadairy.vn/dt?qr=THUG7W01Y9012H5B5", "THUG7W01Y9012H5B5", "05"));

        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            StopPrinter();
            Thread.Sleep(500);
            ResetCounterPrinter();
            Thread.Sleep(500);
            StartPrinter(6);
        }
    }
}
