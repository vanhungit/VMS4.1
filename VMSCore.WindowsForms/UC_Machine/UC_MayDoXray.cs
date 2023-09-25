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
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class UC_MayDoXray : UserControl
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
        public UC_MayDoXray(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
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
            string Trave = "";
            if (byData.Length > 2)
            {
                if ((int.Parse(byData[1].ToString())) == (int)METAL_XRAY.COMMAND.COUNTER_TOTAL)//counter tổng
                {
                    DETECTOR_DATA doituongData = new DETECTOR_DATA();
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11)).ToString();
                    txtCounterInput.Text = Trave;
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.StatusWT = METAL_XRAY.COMMAND.COUNTER_TOTAL.ToString();
                    doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11);
                    doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                    doituongData.Sorted = new DETECTOR_DATARepository().GetMaxDETECTOR_DATA() + 1;
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Data(doituongData);

                    MACHINE_SYNC objData = new MACHINE_SYNC();
                    objData.KeyId = Guid.NewGuid();
                    objData.Code = doituongData.Code;
                    objData.DeviceGroupName = "DETECTOR";
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
                    objMachine.StatusWT = doituongData.StatusWT;
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
                }
                //else if((int.Parse(byData[1].ToString())) == (int)PRIMARY_PACKING_DEFINE.COMMAND.COUNTER_ENG)//counter NG
                else if ((int.Parse(byData[1].ToString())) == (int)METAL_XRAY.COMMAND.COUNTER_ENG)//counter NG
                {
                    DETECTOR_DATA doituongData = new DETECTOR_DATA();
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11)).ToString();
                    txtCounterNG.Text = Trave;
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.StatusWT = METAL_XRAY.COMMAND.COUNTER_ENG.ToString();
                    doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11);
                    doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                    doituongData.Sorted = new DETECTOR_DATARepository().GetMaxDETECTOR_DATA() + 1;
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Data(doituongData);

                    MACHINE_SYNC objData = new MACHINE_SYNC();
                    objData.KeyId = Guid.NewGuid();
                    objData.Code = doituongData.Code;
                    objData.DeviceGroupName = "DETECTOR";
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
                    objMachine.StatusWT = doituongData.StatusWT;
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
                }
                //else if ((int.Parse(byData[1].ToString())) == (int)PRIMARY_PACKING_DEFINE.COMMAND.STATUS_RUN)//counter NG
                //{
                //    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10)).ToString();
                //    DataRow row = dtTongStatus.NewRow();
                //    row["Counter"] = Trave;
                //    row["Timer"] = DateTime.Now;
                //    dtTongStatus.Rows.Add(row);
                //    DETECTOR_STATUS doituong = new DETECTOR_STATUS();
                //    doituong.KeyID = Guid.NewGuid();
                //    doituong.IDKey = "";
                //    doituong.IDName = client.IP.ToString();
                //    doituong.ProductID = "";
                //    doituong.TypeDevice = 3;
                //    doituong.ProductOrder = "0000000001";
                //    doituong.Quantity = (decimal)double.Parse(Trave.ToString());
                //    doituong.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10);
                //    doituong.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituong.QuantityHex.Trim());
                //    doituong.Sorted = new DETECTOR_STATUSEntity().GetMaxDETECTOR_STATUS() + 1;
                //    doituong.CreateBy = objuser.UserID;
                //    doituong.ModifyBy = objuser.UserID;
                //    doituong.CreateDate = DateTime.Now;
                //    doituong.ModifyDate = DateTime.Now;
                //    doituong.Active = true;
                //    InsertDataTP_Status(doituong);
                //}
                else if ((int.Parse(byData[1].ToString())) == (int)METAL_XRAY.COMMAND.COUNTER_TP)//counter NG
                {
                    DETECTOR_DATA doituongData = new DETECTOR_DATA();
                    Trave = new TCPProtocolClient.LibConvert().Hex_To_Integer(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11)).ToString();
                    txtCounterOut.Text = Trave;
                    doituongData.Id = Guid.NewGuid();
                    doituongData.Code = doituongData.Id.ToString();
                    doituongData.DeviceCode = doituong.header.Code;
                    doituongData.IDName = doituong.header.Name;
                    doituongData.LineProcess = doituong.line.Code;
                    doituongData.ProductID = globalLSXDetail.ProductCode;
                    doituongData.ProductOrder = Lenhsanxuat;
                    doituongData.StatusWT = METAL_XRAY.COMMAND.COUNTER_ENG.ToString();
                    doituongData.Quantity = (decimal)double.Parse(Trave.ToString());
                    doituongData.QuantityHex = new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12, 13) + new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10, 11);
                    doituongData.Data = new TCPProtocolClient.LibConvert().Hex_To_Binary(doituongData.QuantityHex.Trim());
                    doituongData.Sorted = new DETECTOR_DATARepository().GetMaxDETECTOR_DATA() + 1;
                    doituongData.CreateBy = objuser.Username;
                    doituongData.ModifyBy = objuser.Username;
                    doituongData.CreateDate = DateTime.Now;
                    doituongData.ModifyDate = DateTime.Now;
                    doituongData.Active = true;
                    InsertDataTP_Data(doituongData);

                    MACHINE_SYNC objData = new MACHINE_SYNC();
                    objData.KeyId = Guid.NewGuid();
                    objData.Code = doituongData.Code;
                    objData.DeviceGroupName = "DETECTOR";
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
                    objMachine.StatusWT = doituongData.StatusWT;
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

                }
                else if ((int.Parse(byData[1].ToString())) == (int)METAL_XRAY.COMMAND.STATUS_RUN)//Reset counter
                {
                    string Chuoi = new TCPProtocolClient.LibConvert().DaoChuoi(new TCPProtocolClient.LibConvert().Hex_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 10)).PadLeft(8, '0')) + new TCPProtocolClient.LibConvert().DaoChuoi(new TCPProtocolClient.LibConvert().Hex_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 11)).PadLeft(8, '0')) + new TCPProtocolClient.LibConvert().DaoChuoi(new TCPProtocolClient.LibConvert().Hex_To_Binary(new TCPProtocolClient.LibConvert().GiaMaResultByIndex(byData, 12)).PadLeft(8, '0'));
                    //memoStatus.Text = Chuoi + "-" + Chuoi[1];
                }
            }
            return Trave;
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
        public void InsertAnser(MACHINECOUNTER doituong)
        {
            //new MACHINECOUNTEREntity().ThemMACHINECOUNTER(doituong);
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
            client.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;
            client.Disconnect();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            StartPLC((int)METAL_XRAY.COMMAND.STOP);
            txtStatusMachine.Text = "START";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopPLC((int)METAL_XRAY.COMMAND.STOP);
            txtStatusMachine.Text = "STOP";


        }

        

        private void btnResetCounter_Click(object sender, EventArgs e)
        {
            ResetCounter((int)METAL_XRAY.COMMAND.RESET_COUNTER);

        }
        //M0
        public void SetOn_Off(int Bien, int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm  
            byte _Station = (byte)00;
            if (Bien == 0)
            {
                _Station = (byte)00;
            }
            else
            {
                _Station = (byte)0xFF;
            }
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x00, _Station, 0x00 };
            client.Send(KhoiTao);
        }
        //M1
        //
        public void StartPLC(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x01, 0xFF, 0x00 };
            client.Send(KhoiTao);
        }
        //M2
        public void StopPLC(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x02, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }
        //Set M5
        //Reset counter
        public void ResetCounter(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x05, 0x08, 0x05, 0xFF, 0x00 };

            client.Send(KhoiTao);
        }

        public void GetCounterTong(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x11, 0xFE, 0x00, 0x02 };
            //KhoiTao[1] = (int)PRIMARY_PACKING_DEFINE.COMMAND.COUNTER_TOTAL;
            client.Send(KhoiTao);
        }
        public void GetCounterTP(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x12, 0x03, 0x00, 0x02 };
            //KhoiTao[1] = (int)PRIMARY_PACKING_DEFINE.COMMAND.COUNTER_TOTAL;
            client.Send(KhoiTao);
        }

        public void GetCounterNG(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x12, 0x08, 0x00, 0x02 };
            client.Send(KhoiTao);
        }
        public void GetLenh(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x12, 0x0D, 0x00, 0x02 };
            client.Send(KhoiTao);
        }
        public void GetThietBi(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x03, 0x11, 0xF4, 0x00, 0x02 };
            client.Send(KhoiTao);
        }
        /// <summary>
        /// Get trạng thái chạy hay dừng, M256
        /// Chạy = 1; dừng = 0
        /// comand 03 là đọc thanh ghi, 01 là đọc bit, 05 ghi cuộn coil (bit), 06 ghithanh ghi
        /// </summary>
        public void RequestDataM700(int Transation)
        {
            var size = 1024; // kích thước của bộ đệm
            var receiveBuffer = new byte[size]; // mảng byte làm bộ đệm     
            //byte[] KhoiTao = new byte[] { 0x00, 0x0A, 0x00, 0x00, 0x00, 0x06, 0x00, 0x01, 0x09, 0x00, 0x00, 0x02 };
            byte[] KhoiTao = new byte[] { 0x00, (byte)Transation, 0x00, 0x00, 0x00, 0x06, 0x00, 0x01, 0x0A, 0xBC, 0x00, 0x18 };

            client.Send(KhoiTao);
        }
        public void MayDoGetStatus()
        {
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                GetCounterTong((int)METAL_XRAY.COMMAND.COUNTER_TOTAL);
                GetCounterTP((int)METAL_XRAY.COMMAND.COUNTER_TP);
                //System.Threading.Thread.Sleep(100);
                GetCounterNG((int)METAL_XRAY.COMMAND.COUNTER_ENG);
                GetThietBi((int)METAL_XRAY.COMMAND.GET_DEVICE);
            }
        }
        public void StartMay()
        {
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                StartPLC((int)METAL_XRAY.COMMAND.START);
                txtStatusMachine.Text = "START";

            }
        }
        public void StopMay()
        {
            txtStatusMachine.Text = "START";
            if (globalStatus == EventDrivenTCPClient.ConnectionStatus.Connected)
            {
                StopPLC((int)METAL_XRAY.COMMAND.STOP);
                txtStatusMachine.Text = "STOP";

            }
        }
    }
}
