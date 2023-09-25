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
using DevExpress.XtraEditors;
using VMSCore.Infrastructure.Features.SyncData;
using DevExpress.XtraEditors.Controls;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class UC_MayInAnserX1 : UserControl
    {
        EQUIP_PLANT_MAP doituong = new EQUIP_PLANT_MAP();
        frmTongHopMay frmMain;
        DataTable dtTong = new DataTable();
        DataTable dtTongNG = new DataTable();
        DataTable dtTongStatus = new DataTable();
        string configFile = @"XMLTimer.xml";
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
        string Pathname = @"G:\Code Nap";
        string NameFileCode = "", NgaySX = "", HanSD = "", LotNum = "", LinkCode = "", FileLog = "";
        DataTable dtBanTin = new DataTable();
        int CounterTong = 0;
        ProductionOrder globalLSX = new ProductionOrder();
        ProductionOrderDetail globalLSXDetail = new ProductionOrderDetail();

        public UC_MayInAnserX1(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string Lenh)
        {
            InitializeComponent();
            Pathname = XMLParser(configFile, "Table/LinkPath");
            frmMain = frmLine;
            doituong = objX1;
            LoadCauHinh(objX1);
            if(txtIP.Text !="")
            {
                client = new EventDrivenTCPClient(IPAddress.Parse(txtIP.Text), Convert.ToUInt16(txtPort.Text.Trim()), true);
                client.DataReceived += new EventDrivenTCPClient.delDataReceived(client_DataReceived);
                client.ConnectionStatusChanged += new EventDrivenTCPClient.delConnectionStatusChanged(client_ConnectionStatusChanged);

            }
            dtBanTin.Columns.Add("ID", typeof(int));
            dtBanTin.Columns.Add("Name", typeof(string));
            DataRow row = dtBanTin.NewRow();
            row[0] = 6;
            row[1] = "Bản tin QR";
            dtBanTin.Rows.Add(row);
            DataRow row1 = dtBanTin.NewRow();
            row1[0] = 7;
            row1[1] = "Bản tin không QR";
            dtBanTin.Rows.Add(row1);
            LoadListBanTin();

            ReadXml_User();
            //Lenhsanxuat = new DOCUMENT_CHECKEntity().DOCUMENTMax().ID;
            Lenhsanxuat = Lenh;
            globalLSX = new ProductionOrderRepository().GetByCode(Lenh);
            globalLSXDetail = new ProductionOrderDetailRepository().GetByCode(Lenh);
        }
        public string XMLParser(string configFile, string Tagname)
        {
            string Trave = "";
            XmlDocument xml = new XmlDocument();
            xml.Load(configFile);
            //---XPath expression 1---
            XmlNode node = xml.SelectSingleNode(Tagname);
            Trave = (node.InnerText);
            return Trave;
        }
        public void LoadListBanTin()
        {
            lookUpEditChonBanTin.Properties.DataSource = dtBanTin;
            lookUpEditChonBanTin.Properties.DisplayMember = "Name";
            lookUpEditChonBanTin.Properties.ValueMember = "ID";
            lookUpEditChonBanTin.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            lookUpEditChonBanTin.EditValue = 6;
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
            if(globalStatus != status)
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
                doituongData.ProductOrder = Lenhsanxuat;
                doituongData.Quantity = 1;
                doituongData.QuantityHex = "";
                doituongData.BinaryHex = "";
                doituongData.Sorted = new PRINT_MAKING_CONNECTRepository().GetMaxPRINT_MAKING_CONNECT() + 1;
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
                objData.DeviceGroupName = "PRINT_MAKING";
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
        #region X1
        /// <summary>
        /// True : start
        /// </summary>
        /// <param name="TTBanTin"></param>
        public void LoadBanTinANSER(bool TTBanTin)
        {
            var size = 20; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm
            receiveBuffer[0] = 0x00;
            if (TTBanTin)
            {
                receiveBuffer[1] = 0x02;// start
            }
            else
                receiveBuffer[1] = 0x03;//stop
            //Protocol
            receiveBuffer[2] = 0x00;
            receiveBuffer[3] = 0x00;
            //lengt
            receiveBuffer[4] = 0x00;
            receiveBuffer[5] = 0x00;
            //Print ID
            receiveBuffer[6] = 0x00;
            receiveBuffer[7] = 0x64;
            //length data
            receiveBuffer[8] = 0x00;
            receiveBuffer[9] = 0x09;
            //ST#
            receiveBuffer[10] = 0x00;
            //CMD
            receiveBuffer[11] = 0x46;
            //DATA
            //MESS
            receiveBuffer[12] = 0x00;
            receiveBuffer[13] = 0x06;//số bản tin động

            if (TTBanTin)
            {
                receiveBuffer[14] = 0x00;
            }
            else
                receiveBuffer[14] = 0x01;
            //Product line
            receiveBuffer[15] = 0x00;
            receiveBuffer[16] = 0x00;
            //station index 1
            receiveBuffer[17] = 0x00;
            receiveBuffer[18] = 0x00;
            client.Send(receiveBuffer);
        }
        public void ClearBanTinANSER(bool TTBanTin)
        {
            var size = 20; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm 
            receiveBuffer[0] = 0x00;
            if (TTBanTin)
            {
                receiveBuffer[1] = (byte)ANSER_X1.COMMAND_ANSER.ClearExecl;// start
            }
            //else
            //    receiveBuffer[1] = 0x03;//stop
            //Protocol
            receiveBuffer[2] = 0x00;
            receiveBuffer[3] = 0x00;
            //lengt
            receiveBuffer[4] = 0x00;
            receiveBuffer[5] = 0x06;
            //Print ID
            receiveBuffer[6] = 0x00;
            receiveBuffer[7] = 0x64;
            //length data
            receiveBuffer[8] = 0x00;
            receiveBuffer[9] = 0x02;
            //ST#
            receiveBuffer[10] = 0x00;
            //CMD
            receiveBuffer[11] = 0x80;
            //DATA
            //MESS
            //receiveBuffer[12] = 0x00;
            //receiveBuffer[13] = 0x07;//số bản tin động

            //if (TTBanTin)
            //{
            //    receiveBuffer[14] = 0x00;
            //}
            //else
            //    receiveBuffer[14] = 0x01;
            ////Product line
            //receiveBuffer[15] = 0x00;
            //receiveBuffer[16] = 0x00;
            ////station index 1
            //receiveBuffer[17] = 0x00;
            //receiveBuffer[18] = 0x00;
            client.Send(receiveBuffer);
        }
        public void LoadBanTinANSER(bool TTBanTin, int ThuTu)
        {
            var size = 20; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm 
            receiveBuffer[0] = 0x00;
            if (TTBanTin)
            {
                receiveBuffer[1] = (byte)ANSER_X1.COMMAND_ANSER.StartPrint;// start
            }
            else
                receiveBuffer[1] = (byte)ANSER_X1.COMMAND_ANSER.StopPrint;// start
            //Protocol
            receiveBuffer[2] = 0x00;
            receiveBuffer[3] = 0x00;
            //lengt
            receiveBuffer[4] = 0x00;
            receiveBuffer[5] = 0x0D;
            //Print ID
            receiveBuffer[6] = 0x00;
            receiveBuffer[7] = 0x64;
            //length data
            receiveBuffer[8] = 0x00;
            receiveBuffer[9] = 0x09;
            //ST#
            receiveBuffer[10] = 0x00;
            //CMD
            receiveBuffer[11] = 0x46;
            //DATA
            //MESS
            receiveBuffer[12] = 0x00;
            receiveBuffer[13] = (byte)ThuTu;//số bản tin động

            if (TTBanTin)
            {
                receiveBuffer[14] = 0x00;
            }
            else
                receiveBuffer[14] = 0x01;
            //Product line
            receiveBuffer[15] = 0x00;
            receiveBuffer[16] = 0x00;
            //station index 1
            receiveBuffer[17] = 0x00;
            receiveBuffer[18] = 0x00;
            client.Send(receiveBuffer);
        }
        private void SendString()
        {
            //try
            {
                string NameFile = "VMS.ini";
                string strPcode = NgaySX;
                string strLOTno = HanSD;
                string strHSD = LotNum;
                string Link = LinkCode;

                byte[] arrHeader = new byte[200];
                // Transaction
                arrHeader[0] = 0;
                arrHeader[1] = (byte)ANSER_X1.COMMAND_ANSER.LoadCoDinh;
                // Protocol
                arrHeader[2] = 0;
                arrHeader[3] = 0;
                // Length
                arrHeader[4] = 0;
                arrHeader[5] = System.Convert.ToByte(6 + 1 + NameFile.Length + 1 + strPcode.Length + 1 + strLOTno.Length + 1 + strHSD.Length + 1 + Link.Length + 16);
                // Printer ID
                arrHeader[6] = 0;
                // -----------------------
                // Modbus function code
                arrHeader[7] = 0x64;
                // Lenght data
                arrHeader[8] = 0;
                arrHeader[9] = System.Convert.ToByte(2 + 1 + NameFile.Length + 1 + strPcode.Length + 1 + strLOTno.Length + 1 + strHSD.Length + 1 + Link.Length + 16);
                // ST#
                arrHeader[10] = 0;
                // CMD
                arrHeader[11] = 0xCA;
                // Filename size
                arrHeader[12] = 7; // CByte(NameFile.Length)
                // File name
                arrHeader[13] = (int)('V');
                arrHeader[14] = (int)('M');
                arrHeader[15] = (int)('S');
                arrHeader[16] = (int)('.');
                arrHeader[17] = (int)('i');
                arrHeader[18] = (int)('n');
                arrHeader[19] = (int)('i');

                // size string 1
                arrHeader[20] = System.Convert.ToByte(strPcode.Length);
                // String 1 content
                for (int i = 0; i < strPcode.Length; i++)
                    arrHeader[21 + i] = (byte)(int)Convert.ToChar(strPcode.Substring(i, 1).ToString());

                // size string 2
                arrHeader[20 + strPcode.Length + 1] = System.Convert.ToByte(strLOTno.Length);
                // String 2 content
                for (int i = 0; i < strLOTno.Length; i++)
                    arrHeader[20 + strPcode.Length + 1 + 1 + i] = (byte)(int)Convert.ToChar(strLOTno.Substring(i, 1).ToString());

                arrHeader[20 + strPcode.Length + 1 + strLOTno.Length + 1] = System.Convert.ToByte(strHSD.Length);
                // String 2 content
                for (int i = 0; i < strHSD.Length; i++)
                    arrHeader[20 + strPcode.Length + 1 + strLOTno.Length + 1 + 1 + i] = (byte)(int)Convert.ToChar(strHSD.Substring(i, 1).ToString());

                arrHeader[20 + strPcode.Length + 1 + strLOTno.Length + 1 + strHSD.Length + 1] = System.Convert.ToByte(Link.Length);
                // String 2 content
                for (int i = 0; i < Link.Length; i++)
                    arrHeader[20 + strPcode.Length + 1 + strLOTno.Length + 1 + strHSD.Length + 1 + 1 + i] = (byte)(int)Convert.ToChar(Link.Substring(i, 1).ToString());
                client.SendBuffer(arrHeader);
            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,  "Send string to printer");
            //}
        }
        private void SendDocuments(string nameFile, int Number)
        {
            // Read lentgh file

            System.IO.FileStream FS = System.IO.File.Open(nameFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            // Dim FS2 As System.IO.FileStream = System.IO.File.Open("0002.ini", IO.FileMode.Open, IO.FileAccess.Read)
            long FSlength = FS.Length;
            byte[] arrF = new byte[5];
            arrF = BitConverter.GetBytes(FSlength);
            FS.Close();
            // FS2.Close()

            byte[] arr78h = new byte[19];
            arr78h[0] = 0;
            arr78h[1] = (byte)ANSER_X1.COMMAND_ANSER.SendDoc;
            arr78h[2] = 0;
            arr78h[3] = 0;
            arr78h[4] = 0;
            arr78h[5] = 0xD;
            arr78h[6] = 0;
            arr78h[7] = 0x64;
            // length
            arr78h[8] = 0;
            arr78h[9] = 0x9;
            // #st
            arr78h[10] = 0;
            // CMD
            arr78h[11] = 0x78;

            // The file's length
            arr78h[12] = arrF[3];
            arr78h[13] = arrF[2];
            arr78h[14] = arrF[1];
            arr78h[15] = arrF[0];

            // Type
            arr78h[16] = 0x8;
            // File No
            arr78h[17] = 0x0;
            arr78h[18] = (byte)(Number); // &H1
            client.SendBuffer(arr78h);

            // Send pack
            System.Threading.Thread.Sleep(500);
            SendDataPack(nameFile);
        }
        public void GhiFile(string line, string Link)
        {
            StreamWriter sw;
            sw = File.AppendText(Link);
            sw.WriteLine(line);
            sw.Close();
        }
        public void SendDataPack(string nameFile)
        {
            System.IO.FileStream FS = System.IO.File.Open(nameFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] buff = new byte[System.Convert.ToInt32(FS.Length) + 1];
            FS.Read(buff, 0, System.Convert.ToInt32(FS.Length - 1));
            FS.Close();
            int Packno = System.Convert.ToInt32(buff.Length / (double)4096);
            int i = 0;
            // ----------- pack -------------
            for (var j = 0; j <= Packno; j++)
            {
                byte[] arr7Eh = new byte[4110]; // =4096+14
                arr7Eh[0] = 0;
                arr7Eh[1] = (byte)ANSER_X1.COMMAND_ANSER.SendPack;
                arr7Eh[2] = 0;
                arr7Eh[3] = 0;
                arr7Eh[4] = 0; // &H10
                arr7Eh[5] = 0; // &H8
                arr7Eh[6] = 0;
                arr7Eh[7] = 0x64;
                // length
                arr7Eh[8] = 0x10;
                arr7Eh[9] = 0x4;
                // #st
                arr7Eh[10] = 0;
                // CMD
                arr7Eh[11] = 0x7E;
                // Data pack No.
                arr7Eh[12] = 0;
                arr7Eh[13] = System.Convert.ToByte(j);

                // Content
                for (i = 0; i <= 4095; i++)
                {
                    if (System.Convert.ToInt32(i + j * 4096) < buff.Length)
                        arr7Eh[14 + i] = buff[System.Convert.ToInt32(i + j * 4096)];
                }
                using (Stream file = File.OpenWrite(FileLog + @"\" + j + ".txt"))
                {
                    file.Write(arr7Eh, 0, arr7Eh.Length);
                }
                int L = i + 8;
                arr7Eh[4] = (byte)(int)(L / 256); // &H10
                arr7Eh[5] = (byte)(L % 256); // &H8

                client.SendBuffer(arr7Eh);
                System.Threading.Thread.Sleep(1000);
            }

        }
        public void GetInputMemory()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x65, 0x00, 0x00, 0x00, 0x06, 0x00, 0x01, 0x09, 0x00, 0x00, 0x01 };

            client.Send(KhoiTao);
        }
        public void GetPrinting_ANSER()
        {
            var size = 20; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm 
            receiveBuffer[0] = 0x00;// start
            //receiveBuffer[1] = 0x10;// start
            receiveBuffer[1] = (byte)ANSER_X1.COMMAND_ANSER.GetStatus;// start

            //Protocol
            receiveBuffer[2] = 0x00;
            receiveBuffer[3] = 0x00;
            //lengt
            receiveBuffer[4] = 0x00;
            receiveBuffer[5] = 0x06;
            //Print ID
            receiveBuffer[6] = 0x00;
            receiveBuffer[7] = 0x64;
            //length data
            receiveBuffer[8] = 0x00;
            receiveBuffer[9] = 0x02;
            //ST#
            receiveBuffer[10] = 0x00;
            //CMD
            receiveBuffer[11] = 0x45;
            //DATA
            //MESS            
            client.Send(receiveBuffer);
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
        /// <summary>
        /// Tắt máy
        /// </summary>
        public void RESETCounterOFF()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x02, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0x00, 0x00 };
            client.Send(KhoiTao);
        }
        /// <summary>
        /// Mở máy
        /// </summary>
        public void RESETCounterON()
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, 0x02, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0xFF, 0x00 };
            client.Send(KhoiTao);
        }
        #endregion
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
        /*public string HamPhanLoai(byte[] byData)
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
                    doituongData.ProductID = "";
                    doituongData.TypeDevice = 0;
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
        }*/
        public string HamPhanLoai(byte[] byData)
        {
            string Trave = "";
            if (byData.Length > 10)
            {
                if ((int.Parse(byData[1].ToString())) == 8 && (int.Parse(byData[11].ToString())) == 69)
                {
                    //string chuoiHex = "";
                    ////Add the received data to a rich text box
                    ////var result = Encoding.ASCII.GetString(data);

                    //for (int i = 0; i < byData.Length; i++)
                    //{
                    //    chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    //}
                    if (byData.Length > 13)
                    {
                        txtStatusMachine.Text = "Đang in";
                        PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
                        doituongData.Id = Guid.NewGuid();
                        doituongData.Code = doituongData.Id.ToString();
                        doituongData.DeviceCode = doituong.header.Code;
                        doituongData.IDName = doituong.header.Name;
                        doituongData.LineProcess = doituong.line.Code;
                        doituongData.ProductID = globalLSXDetail.ProductCode;
                        doituongData.ProductOrder = Lenhsanxuat;
                        doituongData.Quantity = 1;
                        doituongData.QuantityHex = "";
                        doituongData.Data = "S0013";
                        doituongData.Description = "PRINTING";
                        doituongData.Sorted = new PRINT_MAKING_STATUSRepository().GetMaxPRINT_MAKING_STATUS() + 1;
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
                        objData.BinaryHex = doituongData.BinaryHex;
                        objData.Sorted = doituongData.Sorted;
                        objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                        objData.Description = doituongData.Description;
                        objData.CreatorId = doituongData.CreateBy;
                        objData.CreationTime = doituongData.CreateDate;
                        objData.LastModifierId = doituongData.ModifyBy;
                        objData.LastModificationTime = doituongData.ModifyDate;
                        objData.Active = true;
                        InsertMACHINE_SYNC(objData);

                        MACHINE_STATUS objMachine = new MACHINE_STATUS();
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
                        objMachine.Sorted = new MACHINE_STATUSRepository().GetMaxMACHINE_STATUS() + 1;
                        objMachine.Description = doituongData.Description;
                        objMachine.CreateBy = objuser.Username;
                        objMachine.ModifyBy = objuser.Username;
                        objMachine.CreateDate = DateTime.Now;
                        objMachine.ModifyDate = DateTime.Now;
                        objMachine.Active = true;
                        InsertMachineTP_Status(objMachine);
                        //if (globalStatusPLC == EventDrivenTCPClient.ConnectionStatus.Connected)
                        //    SendM5ToPLC(1);
                    }
                    else
                    {
                        txtStatusMachine.Text = "Dừng in";
                        PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
                        doituongData.Id = Guid.NewGuid();
                        doituongData.Code = doituongData.Id.ToString();
                        doituongData.DeviceCode = doituong.header.Code;
                        doituongData.IDName = doituong.header.Name;
                        doituongData.LineProcess = doituong.line.Code;
                        doituongData.ProductID = globalLSXDetail.ProductCode;
                        doituongData.ProductOrder = Lenhsanxuat;
                        doituongData.Quantity = 1;
                        doituongData.QuantityHex = "";
                        doituongData.Data = "S0014";
                        doituongData.Description = "STOP_PRINT";
                        doituongData.Sorted = new PRINT_MAKING_STATUSRepository().GetMaxPRINT_MAKING_STATUS() + 1;
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
                        objData.BinaryHex = doituongData.BinaryHex;
                        objData.Sorted = doituongData.Sorted;
                        objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                        objData.Description = doituongData.Description;
                        objData.CreatorId = doituongData.CreateBy;
                        objData.CreationTime = doituongData.CreateDate;
                        objData.LastModifierId = doituongData.ModifyBy;
                        objData.LastModificationTime = doituongData.ModifyDate;
                        objData.Active = true;
                        InsertMACHINE_SYNC(objData);

                        MACHINE_STATUS objMachine = new MACHINE_STATUS();
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
                        objMachine.Sorted = new MACHINE_STATUSRepository().GetMaxMACHINE_STATUS() + 1;
                        objMachine.Description = doituongData.Description;
                        objMachine.CreateBy = objuser.Username;
                        objMachine.ModifyBy = objuser.Username;
                        objMachine.CreateDate = DateTime.Now;
                        objMachine.ModifyDate = DateTime.Now;
                        objMachine.Active = true;
                        InsertMachineTP_Status(objMachine);
                        //if (globalStatusPLC == EventDrivenTCPClient.ConnectionStatus.Connected)
                        //    SendM5ToPLC(0);
                        //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer Dừng In " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");

                    }
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.StartPrint)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer StartPrint " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                    if (chuoiHex.Contains("31|"))
                    {
                        //XtraMessageBox.Show("Lỗi lệnh Start Máy In", "Thông Báo");
                        PRINT_MAKING_ERROR doituongData = new PRINT_MAKING_ERROR();
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
                        doituongData.Description = "ERROR_START";
                        doituongData.Sorted = new PRINT_MAKING_ERRORRepository().GetMaxPRINT_MAKING_ERROR() + 1;
                        doituongData.CreateBy = objuser.Username;
                        doituongData.ModifyBy = objuser.Username;
                        doituongData.CreateDate = DateTime.Now;
                        doituongData.ModifyDate = DateTime.Now;
                        doituongData.Active = true;
                        InsertDataTP_Error(doituongData);

                        MACHINE_SYNC objData = new MACHINE_SYNC();
                        objData.KeyId = Guid.NewGuid();
                        objData.Code = doituongData.Code;
                        objData.DeviceGroupName = "PRINT_MAKING";
                        objData.StatusType = "ERROR";
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
                    }
                    else
                    {
                        PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
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
                        doituongData.Description = "START";
                        doituongData.Sorted = new PRINT_MAKING_STATUSRepository().GetMaxPRINT_MAKING_STATUS() + 1;
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
                        objData.BinaryHex = doituongData.BinaryHex;
                        objData.Sorted = doituongData.Sorted;
                        objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                        objData.Description = doituongData.Description;
                        objData.CreatorId = doituongData.CreateBy;
                        objData.CreationTime = doituongData.CreateDate;
                        objData.LastModifierId = doituongData.ModifyBy;
                        objData.LastModificationTime = doituongData.ModifyDate;
                        objData.Active = true;
                        InsertMACHINE_SYNC(objData);

                        MACHINE_STATUS objMachine = new MACHINE_STATUS();
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
                        objMachine.Sorted = new MACHINE_STATUSRepository().GetMaxMACHINE_STATUS() + 1;
                        objMachine.Description = doituongData.Description;
                        objMachine.CreateBy = objuser.Username;
                        objMachine.ModifyBy = objuser.Username;
                        objMachine.CreateDate = DateTime.Now;
                        objMachine.ModifyDate = DateTime.Now;
                        objMachine.Active = true;
                        InsertMachineTP_Status(objMachine);
                    }    
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.StopPrint)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer StopPrint " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                    if (chuoiHex.Contains("31|"))
                    {
                        //XtraMessageBox.Show("Lỗi lệnh Stop Máy In", "Thông Báo");
                        PRINT_MAKING_ERROR doituongData = new PRINT_MAKING_ERROR();
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
                        doituongData.Description = "ERROR_STOP";
                        doituongData.Sorted = new PRINT_MAKING_ERRORRepository().GetMaxPRINT_MAKING_ERROR() + 1;
                        doituongData.CreateBy = objuser.Username;
                        doituongData.ModifyBy = objuser.Username;
                        doituongData.CreateDate = DateTime.Now;
                        doituongData.ModifyDate = DateTime.Now;
                        doituongData.Active = true;
                        InsertDataTP_Error(doituongData);

                        MACHINE_SYNC objData = new MACHINE_SYNC();
                        objData.KeyId = Guid.NewGuid();
                        objData.Code = doituongData.Code;
                        objData.DeviceGroupName = "PRINT_MAKING";
                        objData.StatusType = "ERROR";
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
                    }
                    else
                    {
                        PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
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
                        doituongData.Description = "STOP";
                        doituongData.Sorted = new PRINT_MAKING_STATUSRepository().GetMaxPRINT_MAKING_STATUS() + 1;
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
                        objData.BinaryHex = doituongData.BinaryHex;
                        objData.Sorted = doituongData.Sorted;
                        objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                        objData.Description = doituongData.Description;
                        objData.CreatorId = doituongData.CreateBy;
                        objData.CreationTime = doituongData.CreateDate;
                        objData.LastModifierId = doituongData.ModifyBy;
                        objData.LastModificationTime = doituongData.ModifyDate;
                        objData.Active = true;
                        InsertMACHINE_SYNC(objData);

                        MACHINE_STATUS objMachine = new MACHINE_STATUS();
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
                        objMachine.Sorted = new MACHINE_STATUSRepository().GetMaxMACHINE_STATUS() + 1;
                        objMachine.Description = doituongData.Description;
                        objMachine.CreateBy = objuser.Username;
                        objMachine.ModifyBy = objuser.Username;
                        objMachine.CreateDate = DateTime.Now;
                        objMachine.ModifyDate = DateTime.Now;
                        objMachine.Active = true;
                        InsertMachineTP_Status(objMachine);
                    }    
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.ClearExecl)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer ClearExcel " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                    if (chuoiHex.Contains("31|"))
                    {
                        XtraMessageBox.Show("Lỗi ClearExecl Máy In", "Thông Báo");
                    }
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.LoadCoDinh)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer LoadCoDinh " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                    if (chuoiHex.Contains("31|"))
                    {
                        XtraMessageBox.Show("Lỗi LoadCoDinh Máy In", "Thông Báo");
                    }
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.GetStatus)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    //GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer GetStatus " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                    PRINT_MAKING_STATUS doituongData = new PRINT_MAKING_STATUS();
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.Quantity = 1;
                    doituongData.QuantityHex = "";
                    doituongData.Data = chuoiHex;
                    doituongData.Sorted = new PRINT_MAKING_STATUSRepository().GetMaxPRINT_MAKING_STATUS() + 1;
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
                    objData.BinaryHex = doituongData.BinaryHex;
                    objData.Sorted = doituongData.Sorted;
                    objData.SortedRecord = new MACHINE_SYNCRepository().GetMaxMACHINE_SYNC_Record() + 1;
                    objData.Description = doituongData.Description;
                    objData.CreatorId = doituongData.CreateBy;
                    objData.CreationTime = doituongData.CreateDate;
                    objData.LastModifierId = doituongData.ModifyBy;
                    objData.LastModificationTime = doituongData.ModifyDate;
                    objData.Active = true;
                    InsertMACHINE_SYNC(objData);

                    MACHINE_STATUS objMachine = new MACHINE_STATUS();
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
                    objMachine.Sorted = new MACHINE_STATUSRepository().GetMaxMACHINE_STATUS() + 1;
                    objMachine.Description = doituongData.Description;
                    objMachine.CreateBy = objuser.Username;
                    objMachine.ModifyBy = objuser.Username;
                    objMachine.CreateDate = DateTime.Now;
                    objMachine.ModifyDate = DateTime.Now;
                    objMachine.Active = true;
                    InsertMachineTP_Status(objMachine);
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.SendDoc)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer SendDoc " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                }
                else if ((int.Parse(byData[1].ToString())) == (int)ANSER_X1.COMMAND_ANSER.SendPack)
                {
                    string chuoiHex = "";
                    //Add the received data to a rich text box
                    //var result = Encoding.ASCII.GetString(data);

                    for (int i = 0; i < byData.Length; i++)
                    {
                        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                    }
                    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + "Printer SendPack " + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                }
                else if ((int.Parse(byData[11].ToString())) == (int)ANSER_X1.COMMAND_ANSER.GETCOUNTER)//get counter
                {
                    MACHINECOUNTER doituongCounter = new MACHINECOUNTER();
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 20, 21)).ToString();
                  
                    PRINT_MAKING_DATA doituongData = new PRINT_MAKING_DATA();
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.Quantity = 1;
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndexGiam(byData, 9, 6).ToString();
                    doituongData.Data = Trave;
                    doituongData.Description = txtCode.Text.Trim();
                    doituongData.Sorted = new PRINT_MAKING_DATARepository().GetMaxPRINT_MAKING_DATA() + 1;
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    if((decimal)double.Parse(Trave.ToString()) != CounterTong)
                    {
                        InsertDataTP_Data(doituongData);
                        CounterTong = (int)double.Parse(Trave.ToString());
                    }

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

                    txtCounter.Text = Trave;
                    //txtCounterTong.Text = new MACHINECOUNTEREntity().GeMACHINECOUNTER(txtLenh.Text).CountTong + "";
                }
                //else
                //{
                //    string chuoiHex = "";
                //    //Add the received data to a rich text box
                //    //var result = Encoding.ASCII.GetString(data);

                //    for (int i = 0; i < byData.Length; i++)
                //    {
                //        chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
                //    }
                //    GhiFile(String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + ":" + chuoiHex, FileLog + @"\" + "FileLog" + ".txt");
                //}
                //using (Stream file = File.OpenWrite(FileLog + @"\" + "FileLog" + ".txt"))
                //{
                //    file.Write(byData, 0, byData.Length);
                //}


            }
            return Trave;
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
        public void InsertDataTP_Data(PRINT_MAKING_DATA doituong)
        {
            new PRINT_MAKING_DATARepository().Add(doituong);
        }
        public void InsertAnser(MACHINECOUNTER doituong)
        {
            //new MACHINECOUNTEREntity().ThemMACHINECOUNTER(doituong);
        }
        public void InsertMACHINE_SYNC(MACHINE_SYNC doituong)
        {
            new MACHINE_SYNCRepository().Add(doituong);
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
            btnConnect.Enabled = true;
            client.Disconnect();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
           
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                if (lookUpEditChonBanTin.Text != "")
                {
                    LoadBanTinANSER(true, int.Parse(lookUpEditChonBanTin.GetColumnValue("ID").ToString()));
                }
                else
                {
                    lookUpEditChonBanTin.ShowPopup();
                }

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            txtStatusMachine.Text = "STOP";
            if (lookUpEditChonBanTin.Text != "")
            {
                LoadBanTinANSER(false, int.Parse(lookUpEditChonBanTin.GetColumnValue("ID").ToString()));
            }
            else
            {
                lookUpEditChonBanTin.ShowPopup();
            }


        }

        private void btnUpCode_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn nạp code mới cho máy in ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
                {
                    string[] FileArray = new FileCodeNap().GetAllFile(Pathname);// đọc toàn bộ files trong thư mục.
                    if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
                    {
                        //DOCUMENT_CHECKEntity obj = new DOCUMENT_CHECKEntity();
                        //new MACHINECOUNTEREntity().DeleteMachine(txtLenh.Text);//Xóa counter
                        LoadBanTinANSER(false, int.Parse(lookUpEditChonBanTin.GetColumnValue("ID").ToString()));
                        Thread.Sleep(2000);
                        ClearBanTinANSER(true);
                        Thread.Sleep(2000);
                        SendString();
                        Thread.Sleep(2000);
                        WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Nạp Code Gen");
                        //if (obj.GetDOCUMENT_CHECK(client.IP.ToString(), txtLenh.Text) == 0)
                        {
                            //DOCUMENT_CHECK data = new DOCUMENT_CHECK();
                            //data.KeyID = Guid.NewGuid();
                            //data.ID = txtLenh.Text;
                            //data.IP = client.IP.ToString();
                            //obj.ThemDOCUMENT_CHECK(data);//Khởi tạo lệnh
                            //ClearBanTinANSER(true);
                            for (int i = 0; i < FileArray.Length; i++)
                            {
                                SendDocuments(FileArray[i].ToString(), i + 1);
                                //SendDocuments(@"D:\Code Nap\0001.ini");
                                Thread.Sleep(1000);
                            }

                        }
                        WaitDialog.CloseWaitDialog();
                        XtraMessageBox.Show("Vui lòng chọn lại index cần in", "Thông Báo");
                        //DOCUMENT_CHECKEntity obj = new DOCUMENT_CHECKEntity();
                        //new MACHINECOUNTEREntity().DeleteMachine(txtLenh.Text);//Xóa counter
                    }
                }
            }
        }

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            //StopPrinter();
            //Thread.Sleep(500);
            //ResetCounterPrinter();
            //Thread.Sleep(500);
            //StartPrinter(6);
        }
        public void StartMay()
        {
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                if (lookUpEditChonBanTin.Text != "")
                {
                    LoadBanTinANSER(true, int.Parse(lookUpEditChonBanTin.GetColumnValue("ID").ToString()));
                }
                else
                {
                    lookUpEditChonBanTin.ShowPopup();
                }

            }
        }
        public void StopMay()
        {
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                txtStatusMachine.Text = "STOP";
                if (lookUpEditChonBanTin.Text != "")
                {
                    LoadBanTinANSER(false, int.Parse(lookUpEditChonBanTin.GetColumnValue("ID").ToString()));
                }
                else
                {
                    lookUpEditChonBanTin.ShowPopup();
                }

            }
        }
    }
}
