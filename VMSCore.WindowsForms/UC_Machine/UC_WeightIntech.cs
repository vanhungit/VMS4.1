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
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class UC_WeightIntech : UserControl
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
        public UC_WeightIntech(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
        {
            InitializeComponent();
            frmMain = frmLine;
            doituong = objX1;
            LoadCauHinh(objX1);
            dtTong.Columns.Add("ID", typeof(string));
            dtTong.Columns.Add("ProductID", typeof(string));
            dtTong.Columns.Add("Counter", typeof(string));
            dtTong.Columns.Add("Unit", typeof(string));
            dtTong.Columns.Add("Under", typeof(string));
            dtTong.Columns.Add("Over", typeof(string));
            dtTong.Columns.Add("Pass", typeof(string));
            dtTong.Columns.Add("StatusWT", typeof(string));
            dtTong.Columns.Add("Timer", typeof(DateTime));
            dtTongStatus.Columns.Add("Counter", typeof(int));
            dtTongStatus.Columns.Add("Timer", typeof(DateTime));
            if (txtIP.Text !="")
            {
                client = new EventDrivenTCPClient(IPAddress.Parse(txtIP.Text), Convert.ToUInt16(txtPort.Text.Trim()), true);
                client.DataReceived += new EventDrivenTCPClient.delDataReceived(client_DataReceived);
                client.ConnectionStatusChanged += new EventDrivenTCPClient.delConnectionStatusChanged(client_ConnectionStatusChanged);

            }
            gridControlCounterTong.DataSource = dtTong;

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
            WEIGHT_CONNECT doituongData = new WEIGHT_CONNECT();
            doituongData.Id = Guid.NewGuid();
            doituongData.Code = doituongData.Id.ToString();
            doituongData.DeviceCode = doituong.header.Code;
            doituongData.IDName = doituong.header.Name;
            doituongData.LineProcess = doituong.line.Code;
            doituongData.ProductID = globalLSXDetail.ProductCode;
            doituongData.ProductOrder = Lenhsanxuat;
            doituongData.Quantity = 1;
            doituongData.QuantityHex = "";
            doituongData.Sorted = new WEIGHT_CONNECTRepository().GetMaxWEIGHT_CONNECT() + 1;
            doituongData.Data = new ConnectConfigRepository().GetByCodeMap(status.ToString()).Code;
            doituongData.Description = status.ToString();
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
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                //DOCUMENT_CHECKEntity obj = new DOCUMENT_CHECKEntity();
                //if (obj.GetDOCUMENT_CHECK(client.IP.ToString(), "0000000001") == 0)
                //{
                //    DOCUMENT_CHECK data = new DOCUMENT_CHECK();
                //    data.KeyID = Guid.NewGuid();
                //    data.ID = "0000000001";
                //    data.IP = client.IP.ToString();
                //    obj.ThemDOCUMENT_CHECK(data);
                    
                //}
                RESETCounterOFF();
                RESETCounterON();
            }
            string Trave = "", Under = "0", Over = "0", Refer = "0", Status = "", ID = "", ProductID = "";
            if (byData.Length >= 36)
            {

                ID = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 2, 6);
                ProductID = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 7, 10);
                Under = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 11, 16);
                Refer = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 17, 22);
                Over = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 23, 28);
                Status = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 29, 29);
                Trave = new TCPProtocolClient.LibConvert().GiaMaResultAsciiByIndex(byData, 30, 36).Replace(" ","");
                if(dtTong.Rows.Count == 5)
                {
                    dtTong.Rows.RemoveAt(0);
                }    
                DataRow row = dtTong.NewRow();
                row["ID"] = ID + "";
                row["ProductID"] = ProductID + "";
                row["Counter"] = Trave + "";
                row["Under"] = Under + "";
                row["Over"] = Over + "";
                row["Pass"] = Refer + "";
                row["StatusWT"] = Status + "";
                row["Unit"] = "G";
                row["Timer"] = DateTime.Now;
                dtTong.Rows.Add(row);
                WEIGHT_DATA doituongData = new WEIGHT_DATA();
                doituongData.Id = Guid.NewGuid();
                doituongData.Code = doituongData.Id.ToString();
                doituongData.DeviceCode = doituong.header.Code;
                doituongData.IDName = doituong.header.Name;
                doituongData.LineProcess = doituong.line.Code;
                doituongData.ProductID = globalLSXDetail.ProductCode;
                doituongData.ProductOrder = Lenhsanxuat;
                doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                doituongData.UnderData = Decimal.Parse(Under);
                doituongData.OverData = Decimal.Parse(Over);
                doituongData.ReferData = Decimal.Parse(Refer);
                doituongData.StatusWT = Status;
                doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6).ToString();
                doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                doituongData.Sorted = new WEIGHT_DATARepository().GetMaxWEIGHT_DATA() + 1;
                doituongData.CreateBy = objuser.Username;
                doituongData.ModifyBy = objuser.Username;
                doituongData.CreateDate = DateTime.Now;
                doituongData.ModifyDate = DateTime.Now;
                doituongData.Active = true;
                InsertDataTP_Data(doituongData);

            }
            return Trave;
        }
        public void InsertAnser(MACHINECOUNTER doituong)
        {
            //new MACHINECOUNTEREntity().ThemMACHINECOUNTER(doituong);
        }
        public void InsertDataTP_Data(WEIGHT_DATA doituong)
        {
            new WEIGHT_DATARepository().Add(doituong);
        }
        public void InsertDataTP_Warning(WEIGHT_WARNING doituong)
        {
            new WEIGHT_WARNINGRepository().Add(doituong);
            //new PRINT_MAKING_WARNINGEntity().ThemPRINT_MAKING_WARNING(doituong);
        }
        public void InsertDataTP_Error(WEIGHT_ERROR doituong)
        {
            new WEIGHT_ERRORRepository().Add(doituong);

            //new PRINT_MAKING_ERROREntity().ThemPRINT_MAKING_ERROR(doituong);
        }
        public void InsertDataTP_Connect(WEIGHT_CONNECT doituong)
        {
            new WEIGHT_CONNECTRepository().Add(doituong);
        }
        public void InsertDataTP_Status(WEIGHT_STATUS doituong)
        {
            new WEIGHT_STATUSRepository().Add(doituong);

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
            btnConnect.Enabled = true;
        }

        public void RESETCounterON()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x02, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0xFF, 0x00 };
            client.Send(KhoiTao);
        }
        public void RESETCounterOFF()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x02, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0x00, 0x00 };
            client.Send(KhoiTao);
        }
        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                RESETCounterON();
                RESETCounterOFF();
            }
        }

        private void gridView10_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }
    }
}
