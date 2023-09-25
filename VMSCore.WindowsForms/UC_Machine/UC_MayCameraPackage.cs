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
using VMSCore.Infrastructure.Features.SyncData;
using VMSCore.Infrastructure.Features.SyncData.Implementations;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;
using CartManager.Report;
using DevExpress.XtraReports.UI;

namespace VMSCore.WindowsForms
{
    public partial class UC_MayCameraPackage : UserControl
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
        DataTable dtBuffer = new DataTable();
        ProductionOrder globalLSX = new ProductionOrder();
        ProductionOrderDetail globalLSXDetail = new ProductionOrderDetail();
        int Counter = 0;
        public UC_MayCameraPackage(EQUIP_PLANT_MAP objX1, frmTongHopMay frmLine, string LenhSX)
        {
            InitializeComponent();
            frmMain = frmLine;
            dtBuffer.Columns.Add("Code", typeof(string));
            dtBuffer.Columns.Add("Timer", typeof(DateTime));
            dtTongStatus.Columns.Add("Counter", typeof(string));
            dtTongStatus.Columns.Add("Timer", typeof(DateTime));
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
            CAMERA_CONNECT doituongData = new CAMERA_CONNECT();
            doituongData.Id = Guid.NewGuid();
            doituongData.Code = doituongData.Id.ToString();
            doituongData.DeviceCode = doituong.header.Code;
            doituongData.IDName = doituong.header.Name;
            doituongData.LineProcess = doituong.line.Code;
            doituongData.ProductID = globalLSXDetail.ProductCode;
            doituongData.Sorted = new CAMERA_CONNECTRepository().GetMaxCAMERA_CONNECT() + 1;
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
            objData.DeviceGroupName = "CAMERA";
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
        }
        public void InsertMACHINE_SYNC(MACHINE_SYNC doituong)
        {
            new MACHINE_SYNCRepository().Add(doituong);
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
            var result = Encoding.ASCII.GetString(data);

            //for (int i = 0; i < byData.Length; i++)
            //{
            //    chuoiHex += (int.Parse(byData[i].ToString()) > 15 ? int.Parse(byData[i].ToString()).ToString("X") : "0" + int.Parse(byData[i].ToString()).ToString("X")) + "|";
            //}
            //memoStatus.Text = chuoiHex;//lấy byte
            txtCode.Text = result;
            HamPhanLoai(result);
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
        public string HamPhanLoai(string byData)
        {
            string Trave = "";
            KiemTraCode(byData);
            return Trave;
           
        }
        public bool CheckCode(string Code)
        {
            bool Trave = false;
            for (int i = 0; i < dtBuffer.Rows.Count; i++)
            {
                if (dtBuffer.Rows[i]["Code"].ToString() == Code)
                {
                    Trave = true;
                    break;
                }
            }
            return Trave;

        }
        public string CreateCodeCap1(int Cap)
        {
            string CodeCap1 = "";
            DataTable objTable = new SyncDataFunction().GetCodeMap(Cap, Lenhsanxuat);
            if (objTable.Rows.Count > 0)
            {
                CodeCap1 = objTable.Rows[0]["Code1"].ToString();
            }
         
            return CodeCap1;
        }
        public void KiemTraCode(string Code)
        {
            if (Code.Length > 7)
            {
                //string arr = Code.Substring(7, Code.Length - 7).ToString().Trim();
                string arr = Code;
                //string[] tach = arr.ToString().Split('/');
                if (arr.Length > 10)
                {
                    
                    string Trave = "";
                    Trave = arr.ToString();
                    if (CheckCode(Trave))
                    {
                        WaitDialog.CreateWaitDialog("Code đã quét rồi ...", "Thông Báo");
                        WaitDialog.CloseWaitDialog();
                    }
                    else
                    {
                        ModelMapCode codeCap1 = new SyncDataFunction().CodeCapGetAllModel(Trave);
                        if (codeCap1.StatusMapSon)
                        {
                            WaitDialog.CreateWaitDialog("Code đã quét rồi ...", "Thông Báo");
                            WaitDialog.CloseWaitDialog();
                        }
                        else
                        {
                            if (codeCap1.StatusCreate)
                            {
                                if (codeCap1.LevelCode == doituong.header.LevelCode)
                                {
                                    DataRow rowbuf = dtBuffer.NewRow();
                                    rowbuf["Code"] = Trave;
                                    rowbuf["Timer"] = DateTime.Now;
                                    dtBuffer.Rows.Add(rowbuf);
                                    Counter++;
                                    txtCode.Text = Code;
                                    CAMERA_DATA doituongData = new CAMERA_DATA();
                                    doituongData.Id = Guid.NewGuid();
                                    doituongData.Code = doituongData.Id.ToString();
                                    doituongData.DeviceCode = doituong.header.Code;
                                    doituongData.IDName = doituong.header.Name;
                                    doituongData.LineProcess = doituong.line.Code;
                                    doituongData.ProductOrder = Lenhsanxuat;
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
                                    txtCounter.Text = Counter + "";

                                    MACHINE_SYNC objData = new MACHINE_SYNC();
                                    objData.KeyId = Guid.NewGuid();
                                    objData.Code = doituongData.Code;
                                    objData.DeviceGroupName = "CAMERA";
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
                                }
                                else
                                {
                                    DataRow row = dtTongStatus.NewRow();
                                    row["Counter"] = Trave;
                                    row["Timer"] = DateTime.Now;
                                    dtTongStatus.Rows.Add(row);
                                    //XtraMessageBox.Show("Code không hợp lệ", "Thông Báo");
                                    WaitDialog.CreateWaitDialog("Code không hợp lệ ...", "Thông Báo");
                                    WaitDialog.CloseWaitDialog();
                                }


                            }
                            else
                            {
                                DataRow row = dtTongStatus.NewRow();
                                row["Counter"] = Trave;
                                row["Timer"] = DateTime.Now;
                                dtTongStatus.Rows.Add(row);
                                //XtraMessageBox.Show("Code không hợp lệ", "Thông Báo");
                                WaitDialog.CreateWaitDialog("Code không hợp lệ ...", "Thông Báo");
                                WaitDialog.CloseWaitDialog();
                            }

                        }
                    }

                    if (dtBuffer.Rows.Count >= 3)//Quy cách thùng
                    //if (dtBuffer.Rows.Count >= (objLenhdetail.UnitPrice/objLenhdetail.UnitConvert))//Quy cách thùng
                    {
                        //Tạo mã Pallet
                        //Đóng gói, map thùng - Pallet
                        //Clear buffer
                        string CodeCap1 = CreateCodeCap1((int)doituong.header.LevelCode + 1);
                        if (CodeCap1 != "")
                        {
                            //Map - đóng gói
                            if (dtBuffer.Rows.Count > 0)
                            {
                                bool Flag = true;
                                for (int i = 0; i < dtBuffer.Rows.Count; i++)
                                {
                                    ProductionOrderDetailMAP rsstockdetail = new ProductionOrderDetailMAP();
                                    rsstockdetail.KeyBox = "";
                                    DataRow row = dtBuffer.Rows[i];
                                    ProductionOrderDetailMAP obj = new ProductionOrderDetailMAP();
                                    obj.Id = Guid.NewGuid();
                                    obj.Code = obj.Id.ToString();
                                    obj.KeyBox = CodeCap1;
                                    obj.LevelBox = (int)doituong.header.LevelCode + 1;
                                    obj.KeyCuon = (row["Code"].ToString());
                                    obj.LevelCuon = (int)doituong.header.LevelCode;
                                    obj.ProductionOrderCode = Lenhsanxuat;
                                    obj.ProductCode = globalLSXDetail.ProductCode;
                                    obj.ProductName = globalLSXDetail.ProductName;
                                    obj.UnitCode = "";
                                    obj.Quantity = 1;
                                    obj.LOT = globalLSXDetail.LotNumber;
                                    obj.KeyDate = String.Format("{0:yyyyMMdd}", DateTime.Now);
                                    obj.KeyTime = String.Format("{0:HHmmss}", DateTime.Now);
                                    obj.Sorted = new ProductionOrderDetailMAPRepository().GetMaxProductionOrderDetailMAP() + 1;
                                    obj.Active = true;
                                    obj.Description = "";
                                    obj.CreatedBy = objuser.Username;
                                    obj.ModifiedBy = objuser.Username;
                                    obj.CreatedDate = DateTime.Now;
                                    obj.ModifiedDate = DateTime.Now;
                                    rsstockdetail = new ProductionOrderDetailMAPRepository().Add(obj);
                                    if (rsstockdetail.KeyBox != "")
                                    {

                                    }
                                    else
                                    {
                                        Flag = false;
                                        //XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                                        break;
                                    }
                                }
                                if (Flag)
                                {
                                    //PalletIDglobal = CodeCap1;
                                    ProductionOrderDetailCode objCode = new ProductionOrderDetailCodeRepository().GetOneByCondition(x => x.Code1 == CodeCap1 && x.LevelPackage == (int)doituong.header.LevelCode + 1);
                                    if (objCode.LineCode != null)
                                    {
                                        objCode.PrintCount = objCode.PrintCount + 1;
                                        objCode.Qty = 1;
                                        new ProductionOrderDetailCodeRepository().Update(objCode);
                                    }
                                    WaitDialog.CreateWaitDialog("In nhãn thùng ...", "Thông Báo");
                                    WaitDialog.CloseWaitDialog();
                                    //InTemTP(CodeCap1, 1, "");
                                    frmMain.HamThucThiChucNang(doituong, doituong, "", CodeCap1);
                                    Counter = 0;
                                    dtBuffer.Rows.Clear();
                                    txtCounter.Text = Counter + "";
                                    //gridControlBuffer.DataSource = dtBuffer;
                                }
                            }
                            else
                            {
                                //XtraMessageBox.Show("Chưa có dữ liệu ", "Thông Báo");
                            }
                        }
                        else
                        {
                            //XtraMessageBox.Show("Chưa có dữ liệu code cấp " + calcLevel.Value, "Thông Báo");

                        }

                    }
                }
              

            }

        }
        public void InTemTP(string PalletID, int Copy, string LinkPath)
        {
            dsPallet dtableBBGD = new dsPallet();
            DataTable tbsanxuat = dtableBBGD.TablePallet;
            TemPallet BBGD = new TemPallet();
            //if (LinkPath != "")
            //{
            //    BBGD.LoadLayout(LocationFile + @"\" + LinkPath);
            //}
            //else
            //{
            //    BBGD.LoadLayout(LocationFile + @"\" + "TemTP.repx");
            //}
            //tbsanxuat = new CANCUONEntity().ReportTemTP(Cuon);
            //foreach (DataRow drtableOld in tbsanxuat.Rows)
            {

                {
                    DataRow drtableOld = tbsanxuat.NewRow();
                    drtableOld["PONum"] = "";
                    drtableOld["SOTransfer"] = "";
                    drtableOld["IDBox"] = PalletID;
                    drtableOld["NgaySX"] = globalLSX.ManufactureDate;
                    drtableOld["HanSuDung"] = globalLSX.ExpireDate;
                    drtableOld["IDPallet"] = PalletID;
                    drtableOld["Item"] = globalLSXDetail.ProductCode;
                    drtableOld["ItemName"] = globalLSXDetail.ProductName;
                    drtableOld["LotNum"] = globalLSXDetail.LotNumber;
                    drtableOld["QCPallet"] = 3;
                    //drtableOld["QCBox"] = (objLenhdetail.UnitPrice / objLenhdetail.UnitConvert);
                    drtableOld["QCBox"] = dtBuffer.Rows.Count;
                    drtableOld["QCHop"] = 0;
                    drtableOld["TypeSanPham"] = "";
                    tbsanxuat.Rows.Add(drtableOld);
                }
            }
            BBGD.DataMember = "TemBich";
            BBGD.DataSource = dtableBBGD;
            //BBGD.FillDataSource();
            //BBGD.ShowPreview();
            ReportDesignTool designTool = new ReportDesignTool(BBGD);
            designTool.ShowDesignerDialog();
            //ReportPrintTool printTool = new ReportPrintTool(BBGD);
            //printTool.PrinterSettings.Copies = (Int16)Copy;
            //// Invoke the Print dialog.
            //printTool.PrintDialog();
            // Send the report to the default printer.
            //printTool.Print();
            // Send the report to the specified printer.
            //printTool.Print(PrinterName);
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
            client.Connect();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Disconnect();
        }


        
    }
}
