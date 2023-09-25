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
using System.Net.Sockets;

namespace VMSCore.WindowsForms
{
    public partial class UC_MayCameraCheck : UserControl
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
     
        public string Lenhsanxuat = "";
        //Cam
        bool On = true;
        bool startLISTENNER = true, startRead = true;
        int FlagCamStatus = 0;
        TcpListener ServerSocket;
        TcpClient ClientSocket;
        Thread threadReadTCP, listenner;
        int CountLoi = 0;
        ProductionOrder globalLSX = new ProductionOrder();
        ProductionOrderDetail globalLSXDetail = new ProductionOrderDetail();
        public UC_MayCameraCheck(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
        {
            InitializeComponent();
            frmMain = frmLine;
            doituong = objX1;
            LoadCauHinh(objX1);
            if (txtIP.Text != "")
            {
                IPAddress ipAddress = IPAddress.Parse(txtIP.Text);
                ServerSocket = new TcpListener(ipAddress, 3000);
                listenner = new Thread(ListenForRequests);

            }
           

            ReadXml_User();
            //Lenhsanxuat = new DOCUMENT_CHECKEntity().DOCUMENTMax().ID;
            Lenhsanxuat = LenhSX;
            globalLSX = new ProductionOrderRepository().GetByCode(LenhSX);
            globalLSXDetail = new ProductionOrderDetailRepository().GetByCode(LenhSX);
        }
        #region Camera
        private void ListenForRequests()
        {
            try
            {
                while ((startLISTENNER))
                {
                    ServerSocket.Start();
                    if (ServerSocket.Pending())
                    {
                        try
                        {
                            ClientSocket = new TcpClient();
                            ClientSocket = ServerSocket.AcceptTcpClient();
                            threadReadTCP = new System.Threading.Thread(readTCP);

                            if (threadReadTCP.ThreadState == ThreadState.Unstarted)
                                threadReadTCP.Start();
                            else if (threadReadTCP.ThreadState == ThreadState.Suspended)
                                threadReadTCP.Resume();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        //this.Invoke(() =>
                        //{
                        //    txtIPclient.Text = (IPEndPoint)ClientSocket.Client.RemoteEndPoint.ToString;
                        //});
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void readTCP()
        {
            TcpClient ClientsocketRead = ClientSocket;
            NetworkStream serverStream = ClientSocket.GetStream();
            while ((startRead))
            {
                if (serverStream.DataAvailable)
                {
                    byte[] inStream = new byte[ClientsocketRead.ReceiveBufferSize + 1];
                    serverStream.Read(inStream, 0, System.Convert.ToInt32(ClientsocketRead.ReceiveBufferSize));
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    //string IPequipment = (IPEndPoint)ClientsocketRead.Client.RemoteEndPoint;

                    //this.Invoke((MethodInvoker)delegate
                    //{
                    //    memoStatusCam.Text = returndata.Trim();
                    //    txtLinkCode.Text = returndata.Trim();
                    //    KiemTraCode(returndata.Trim().Replace('\0', ' ').Trim());

                    //});
                    if (this.IsHandleCreated)//Handle được kết nối
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            //memoStatusCam.Text = returndata.Trim();
                            txtCode.Text = returndata.Trim();
                            KiemTraCode(returndata.Trim().Replace('\0', ' ').Trim());
                            //KiemTraCode(returndata.Trim());

                        });
                    }

                }
                Thread.Sleep(100);
            }
        }
        /*private void readTCP()
        {
            TcpClient ClientsocketRead = ClientSocket;
            NetworkStream serverStream = ClientSocket.GetStream();
            while ((startRead))
            {
                if (serverStream.DataAvailable)
                {
                    byte[] inStream = new byte[ClientsocketRead.ReceiveBufferSize + 1];
                    serverStream.Read(inStream, 0, System.Convert.ToInt32(ClientsocketRead.ReceiveBufferSize));
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream).Substring(0, txtLink.Text.Trim().Length + 36);
                    //string IPequipment = (IPEndPoint)ClientsocketRead.Client.RemoteEndPoint;

                    //this.Invoke((MethodInvoker)delegate
                    //{
                    //    memoStatusCam.Text = returndata.Trim();
                    //    txtLinkCode.Text = returndata.Trim();
                    //    KiemTraCode(returndata.Trim().Replace('\0', ' ').Trim());

                    //});
                    this.Invoke((MethodInvoker)delegate
                    {
                        //memoStatusCam.Text = returndata.Trim();
                        txtLinkCode.Text = returndata.Trim();
                        KiemTraCode(returndata.Trim());

                    });
                }
                Thread.Sleep(100);
            }
        }*/
        public void KiemTraCode(string Code)
        {
            if (Code.Length > 7)
            {
                //string arr = Code.Substring(7, Code.Length - 7).ToString().Trim();
                string arr = Code.Trim();
                //string[] tach = arr.ToString().Split('/');
                if (arr.Length > 10)
                {
                    //TH chuỗi 12 ký tự
                    //string tach = arr.ToString().Substring(ChuoiLink.Length, 36);//Lấy mã Code2
                    ProductionOrderDetailCode objDetatail = new ProductionOrderDetailCodeRepository().GetOneByCondition(x => x.Code1 == arr && x.LevelPackage == doituong.header.LevelCode);
                    if (objDetatail != null)
                    {
                        ProductionOrderDetailCheck objCheck = new ProductionOrderDetailCheck();
                        objCheck.Id = Guid.NewGuid();
                        objCheck.ProductionOrderCode = objDetatail.ProductionOrderCode;
                        objCheck.Code = objCheck.Id.ToString();
                        objCheck.Code1 = objDetatail.Code1;
                        objCheck.Code2 = objDetatail.Code2;
                        objCheck.LineCode = objDetatail.LineCode;
                        objCheck.DeviceCode = objDetatail.DeviceCode;
                        objCheck.DeviceHandeCode = objDetatail.DeviceHandeCode;
                        objCheck.DeviceCheck = doituong.header.Code;
                        objCheck.LevelPackage = objDetatail.LevelPackage;
                        objCheck.Sorted = new ProductionOrderDetailCheckRepository().GetMaxProductionOrderDetailCheck() + 1;
                        objCheck.CreatorId = objuser.Username;
                        objCheck.CreationTime = DateTime.Now;
                        objCheck.LastModifierId = objuser.Username;
                        objCheck.LastModificationTime = DateTime.Now;
                        objCheck.Active = true;
                        new ProductionOrderDetailCheckRepository().Add(objCheck);
                    }
                    txtCode.Text = Code;
                    CAMERA_DATA doituongData = new CAMERA_DATA();                    
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.StatusWT = "";
                    doituongData.Quantity = 1;
                    doituongData.QuantityHex = Code;
                    doituongData.Data = Code;
                    doituongData.Sorted = new CAMERA_DATARepository().GetMaxCAMERA_DATA() + 1;
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Data(doituongData);
                }

            }

        }
        #endregion
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
        //void client_ConnectionStatusChanged(EventDrivenTCPClient sender, EventDrivenTCPClient.ConnectionStatus status)
        //{
        //    //Check if this event was fired on a different thread, if it is then we must invoke it on the UI thread
        //    if (InvokeRequired)
        //    {
        //        Invoke(new EventDrivenTCPClient.delConnectionStatusChanged(client_ConnectionStatusChanged), sender, status);
        //        return;
        //    }
        //    txtStatusConnect.Text = status.ToString();
        //    CAMERA_CONNECT doituongData = new CAMERA_CONNECT();
        //    doituongData.Id = Guid.NewGuid();
        //    doituongData.Code = "";
        //    doituongData.IDName = doituong.header.Code;
        //    doituongData.LineProcess = doituong.line.Code;
        //    doituongData.ProductID = "";
        //    doituongData.ProductOrder = Lenhsanxuat;
        //    doituongData.Quantity = 1;
        //    doituongData.QuantityHex = "";
        //    doituongData.Sorted = new CAMERA_CONNECTRepository().GetMaxCAMERA_CONNECT() + 1;
        //    doituongData.Data = status.ToString();
        //    doituongData.CreateBy = objuser.Username;
        //    doituongData.ModifyBy = objuser.Username;
        //    doituongData.CreateDate = DateTime.Now;
        //    doituongData.ModifyDate = DateTime.Now;
        //    doituongData.Active = true;
        //    InsertDataTP_Connect(doituongData);
        //}
        //Fired when new data is received in the TCP client
       
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
        public void InsertDataTP_Data(CAMERA_DATA doituong)
        {
            new CAMERA_DATARepository().Add(doituong);

            //new PRINT_MAKING_DATAEntity().ThemPRINT_MAKING_DATA(doituong);
        }
        public void InsertDataTP_Warning(CAMERA_WARNING doituong)
        {
            new CAMERA_WARNINGRepository().Add(doituong);

            //new PRINT_MAKING_WARNINGEntity().ThemPRINT_MAKING_WARNING(doituong);
        }
        public void InsertDataTP_Error(CAMERA_ERROR doituong)
        {
            new CAMERA_ERRORRepository().Add(doituong);

            //new PRINT_MAKING_ERROREntity().ThemPRINT_MAKING_ERROR(doituong);
        }
        public void InsertDataTP_Connect(CAMERA_CONNECT doituong)
        {
            new CAMERA_CONNECTRepository().Add(doituong);

            //new PRINT_MAKING_CONNECTEntity().ThemPRINT_MAKING_CONNECT(doituong);
        }
        public void InsertDataTP_Status(CAMERA_STATUS doituong)
        {
            new CAMERA_STATUSRepository().Add(doituong);

            //new PRINT_MAKING_STATUSEntity().ThemPRINT_MAKING_STATUS(doituong);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //frmMain.HienThiThongTin(doituong.header.IDEQUIP, txtIP.Text, "Start...");
            //client.Connect();
            try
            {
                if (listenner.ThreadState == ThreadState.Unstarted)
                {
                    listenner.Start();
                    txtStatusMachine.Text = "start listening";
                    FlagCamStatus = 1;
                }
                else if (listenner.ThreadState == ThreadState.Running | listenner.ThreadState == ThreadState.WaitSleepJoin)
                {
                    listenner.Suspend();
                    txtStatusMachine.Text = "Resume Server";
                    ServerSocket.Stop();
                    FlagCamStatus = 2;
                }
                else
                {
                    listenner.Resume();
                    FlagCamStatus = 3;
                    txtStatusMachine.Text = "Stop listening";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //client.Disconnect();
            if (FlagCamStatus == 2)
            {
                txtCounter.Text = "Vui lòng start cam chuyển sang Stop Server";
            }
            else
            {
                listenner.Abort(100);
                ServerSocket.Stop();
                startLISTENNER = false;
            }
        }     

        

        

        
    }
}
