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
using DevExpress.XtraEditors;
using VMSCore.Machine.Controller;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class UC_PLCBangTai : UserControl
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
        public UC_PLCBangTai(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
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
                DETECTOR_CONNECT doituongData = new DETECTOR_CONNECT();
                doituongData.Id = Guid.NewGuid();
                doituongData.Code = doituongData.Id.ToString();
                doituongData.DeviceCode = doituong.header.Code;
                doituongData.IDName = doituong.header.Name;
                doituongData.LineProcess = doituong.line.Code;
                doituongData.ProductID = globalLSXDetail.ProductCode;
                doituongData.Sorted = new DETECTOR_CONNECTRepository().GetMaxDETECTOR_CONNECT() + 1;
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
                objData.DeviceGroupName = "DETECTOR";
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
            HamPhanLoaiPLC(byData);
        }
        public string HamPhanLoaiPLC(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 2)
            {
                if ((int.Parse(byData[7].ToString())) == 133)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Lỗi PLC send " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                    XtraMessageBox.Show("Lỗi PLC send", "Thông Báo");
                }
                else if ((int.Parse(byData[1].ToString())) == 102)//Status Printer đổi thành Alarm
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);// bắt đầu từ byte 1
                    //if (Trave == "01")
                    //{
                    //    txtStatusPrinter.Text = "Printer running";
                    //}
                    //else
                    //{
                    //    txtStatusPrinter.Text = "Printer ready";
                    //}

                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.StatusCAM)//Status Cam
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //string chuoiHex = "";
                    ////Add the received data to a rich text box
                    ////var result = Encoding.ASCII.GetString(data);

                    //for (int i = 0; i < byData.Length; i++)
                    //{
                    //    chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    //}
                    //if (Trave == "01")
                    //{
                    //    txtStatusCam.Text = "Camera running";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Camera running " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                    //else
                    //{
                    //    txtStatusCam.Text = "Camera ready";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Camera ready " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.StatusAlarm)//Status Alarm
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //string chuoiHex = "";
                    ////Add the received data to a rich text box
                    ////var result = Encoding.ASCII.GetString(data);

                    //for (int i = 0; i < byData.Length; i++)
                    //{
                    //    chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    //}
                    //if (Trave == "01")
                    //{
                    //    txtStatusPLC.Text = "Alarm On";
                    //    memoPLC.Text = memoPLC.Text + "Sensor reject hỏng hoặc van khí hỏng" + "\r\n";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Alarm On " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                    //else
                    //{
                    //    txtStatusPLC.Text = "Alarm Off";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Alarm Off " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.StatusOffCam)//Status OffCam
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //string chuoiHex = "";
                    ////Add the received data to a rich text box
                    ////var result = Encoding.ASCII.GetString(data);

                    //for (int i = 0; i < byData.Length; i++)
                    //{
                    //    chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    //}
                    //if (Trave == "01")// lúc này ko cần máy cam chạy vẫn start đc băng tải
                    //{
                    //    txtStatusPLC.Text = "PLC off Cam";
                    //    FlagOffCam = false;
                    //    btnOffCam.Text = "On Cam";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Alarm On " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                    //else
                    //{
                    //    txtStatusPLC.Text = "PLC on Cam";
                    //    FlagOffCam = true;
                    //    btnOffCam.Text = "Off Cam";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Alarm Off " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.Status0ffInterLog)//Status OffInterLog
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //string chuoiHex = "";
                    ////Add the received data to a rich text box
                    ////var result = Encoding.ASCII.GetString(data);

                    //for (int i = 0; i < byData.Length; i++)
                    //{
                    //    chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    //}
                    //if (Trave == "01")// lúc này ko cần máy in chạy vẫn start đc băng tải
                    //{
                    //    txtStatusPLC.Text = "PLC On Interlog";
                    //    FlagoffInterLock = true;
                    //    btnOffInterlock.Text = "Off InterLock";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Alarm On " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                    //else
                    //{
                    //    txtStatusPLC.Text = "PLC off Interlog";
                    //    FlagoffInterLock = false;
                    //    btnOffInterlock.Text = "On InterLock";
                    //    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Alarm Off " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    //}
                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.CamHong)//Status OffInterLog
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //if (Trave == "01")// lúc này ko cần máy in chạy vẫn start đc băng tải
                    //{
                    //    txtStatusPLC.Text = "Sensor Camera hỏng";
                    //    memoPLC.Text = memoPLC.Text + "Sensor Camera hỏng" + "\r\n";
                    //    //XtraMessageBox.Show("Cam hỏng", "Thông Báo");
                    //}
                    //else
                    //{
                    //    txtStatusPLC.Text = "Cam ok";
                    //}
                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.Sensor2s)//Status OffInterLog
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //if (Trave == "01")// lúc này ko cần máy in chạy vẫn start đc băng tải
                    //{
                    //    txtStatusPLC.Text = "Sensor bị che 2s";
                    //    memoPLC.Text = memoPLC.Text + "Sensor bị che 2s" + "\r\n";
                    //    //XtraMessageBox.Show("Lỗi sensor 2s", "Thông Báo");

                    //}
                    //else
                    //{
                    //    //txtStatusPLC.Text = "Cam ok";
                    //}
                }
                else if ((int.Parse(byData[1].ToString())) == (int)PLCControll.COMMAND_PLC.ThungHong)//Status OffInterLog
                {
                    Trave = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11, 11);
                    //if (Trave == "01")// lúc này ko cần máy in chạy vẫn start đc băng tải
                    //{
                    //    txtStatusPLC.Text = "Sensor thùng hỏng hoặc sản phẩm không rơi vào thùng";
                    //    memoPLC.Text = memoPLC.Text + "Sensor thùng hỏng hoặc sản phẩm không rơi vào thùng" + "\r\n";
                    //    //XtraMessageBox.Show("Lỗi Thùng Hỏng", "Thông Báo");
                    //}
                    //else
                    //{
                    //    //txtStatusPLC.Text = "Cam ok";
                    //}
                }
            }
            return Trave;
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
     
        public void InsertAnser(MACHINECOUNTER doituong)
        {
            //new MACHINECOUNTEREntity().ThemMACHINECOUNTER(doituong);
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
        public void InsertDataTP_Data(DETECTOR_DATA doituong)
        {
            new DETECTOR_DATARepository().Add(doituong);
            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertDataTP_Warning(DETECTOR_WARNING doituong)
        {
            new DETECTOR_WARNINGRepository().Add(doituong);
            //new PRINT_MAKING_WARNINGEntity().ThemPRINT_MAKING_WARNING(doituong);
        }
        public void InsertDataTP_Error(DETECTOR_ERROR doituong)
        {
            new DETECTOR_ERRORRepository().Add(doituong);

            //new PRINT_MAKING_ERROREntity().ThemPRINT_MAKING_ERROR(doituong);
        }
        public void InsertDataTP_Connect(DETECTOR_CONNECT doituong)
        {
            new DETECTOR_CONNECTRepository().Add(doituong);
            //new PRINT_MAKING_CONNECTEntity().ThemPRINT_MAKING_CONNECT(doituong);
        }
        public void InsertDataTP_Status(DETECTOR_STATUS doituong)
        {
            new DETECTOR_STATUSRepository().Add(doituong);
            //new PRINT_MAKING_STATUSEntity().ThemPRINT_MAKING_STATUS(doituong);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //frmMain.HienThiThongTin(doituong.header.IDEQUIP, txtIP.Text, "Start...");
            if (Lenhsanxuat != "")
            {
                client.Connect();
                btnConnect.Enabled = false;
            }
            else
            {
                XtraMessageBox.Show("Nhập lệnh sản xuất !", "Thông Báo");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (Lenhsanxuat != "")
            {
                client.Disconnect();
                btnDisconnect.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show("Nhập lệnh sản xuất !", "Thông Báo");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
            //doituongData.Id = Guid.NewGuid();
            //doituongData.Code = doituong.header.Code;
            //doituongData.IDName = doituong.header.Name;
            //doituongData.ProductID = "";
            //doituongData.LineProcess = doituong.line.Code;
            //doituongData.ProductOrder = Lenhsanxuat;
            //doituongData.Quantity = 1;
            //doituongData.QuantityHex = "";
            //doituongData.Data = "START";
            ////doituongData.Sorted = new SECONDARY_PACKING_ERROREntity().GetMaxSECONDARY_PACKING_ERROR() + 1;
            //doituongData.CreateBy = objuser.Username;
            //doituongData.ModifyBy = objuser.Username;
            //doituongData.CreateDate = DateTime.Now;
            //doituongData.ModifyDate = DateTime.Now;
            //doituongData.Active = true;
            //InsertDataTP_Status(doituongData);
            //txtStatusMachine.Text = "START";
            StartBangTai();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            //PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
            //doituongData.Id = Guid.NewGuid();
            //doituongData.Code = doituong.header.Code;
            //doituongData.IDName = doituong.header.Name;
            //doituongData.ProductID = "";
            //doituongData.LineProcess = doituong.line.Code;
            //doituongData.ProductOrder = Lenhsanxuat;
            //doituongData.Quantity = 1;
            //doituongData.QuantityHex = "";
            //doituongData.Data = "STOP";
            ////doituongData.Sorted = new SECONDARY_PACKING_ERROREntity().GetMaxSECONDARY_PACKING_ERROR() + 1;
            //doituongData.CreateBy = objuser.Username;
            //doituongData.ModifyBy = objuser.Username;
            //doituongData.CreateDate = DateTime.Now;
            //doituongData.ModifyDate = DateTime.Now;
            //doituongData.Active = true;
            //InsertDataTP_Status(doituongData);
            txtStatusMachine.Text = "STOP";
            StopBangTai();

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
        //M0
        public void StartBangTai()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x00, 0xFF, 0x00 };
            client.Send(KhoiTao);
        }
        //M1
        public void StopBangTai()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //M2
        public void OffCam()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x02, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //M6
        public void OnCam()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x06, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //M3
        public void OffInterlock()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x03, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //Set M7
        public void OnInterlock()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x07, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //M4
        public void ResetAlarm()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x04, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //M5
        public void SendM5ToPLC(int Bien)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm 
            if (Bien == 1)//Đang in
            {
                receiveBuffer = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x05, 0xFF, 0x00 };
            }
            else
                receiveBuffer = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x05, 0x00, 0x00 };


            client.Send(receiveBuffer);
        }
        //Get D10
        // Byte 9 bằng 1 on(sẵn sàng - đang chạy), bằng 0 là off (chưa in, chưa check)
        public void GetPrinterready()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x66, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x0A, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Set D10 sau khi đọc trạng thái máy in
        public void SetD10()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x66, 0x00, 0x00, 0x00, 0x06, 0x00, 0x06, 0x00, 0x06, 0x2A, 0xE5, 0x00, 0x00, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D101
        public void GetCamReady()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x67, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x65, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D102
        public void GetAlarmReject()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x68, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x66, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D103
        //trang thai offcam
        public void GetStatusOffCam()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x69, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x67, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D104
        //trang thai intrelog
        public void GetStatusOffInterlog()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x6A, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x68, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D105
        //trang thai cam hỏng
        public void GetStatusCamHong()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x6B, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x69, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D106
        //trang thai Sensor bị che 2s
        public void GetStatusSensor2s()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x6C, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x6A, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        //Get D107
        //trang thai thùng hỏng
        public void GetStatusThungHong()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x6D, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x10, 0x6B, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            //StopPrinter();
            //Thread.Sleep(500);
            //ResetCounterPrinter();
            //Thread.Sleep(500);
            //StartPrinter(6);
        }
    }
}
