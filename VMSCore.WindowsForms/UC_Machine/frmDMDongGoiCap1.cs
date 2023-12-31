using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraPrinting;
using SalesManager;
using System.Xml;

using System.IO;
using System.Net.Sockets;

using System.Threading;

using DevExpress.XtraReports.UI;
using System.Net;
using System.Management;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SyncData;
using VMSCore.Infrastructure.Features.SyncData.Implementations;
using Newtonsoft.Json;
using VMSCore.WindowsForms.ReportForm;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmDMDongGoiCap1 : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        DataTable dtBuffer = new DataTable();
        DataTable dtTongStatus = new DataTable();
        int CountLoi = 0;
       
        DataTable dtBanTin = new DataTable();
        //Cam
        bool On = true;
        bool startLISTENNER = true, startRead = true;
        int FlagCamStatus = 0;
        

        string ChuoiLink = "";
        string configFile = @"XMLTimer.xml";
        string Pathname = "", IPPrinter, IPCAM, IPPLC, FileLog = "";
        string IPDevice = "", NamePortCoi = "", ChuoiEncode = "";
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        ProductionOrder objLSX = new ProductionOrder();
        ProductionOrderDetail objdetail = new ProductionOrderDetail();

        bool FlagOffCam = true, FlagoffInterLock = true;
        Main frmthis;
        string NgonNgu = "";
        string PrinterName = "";
        string PalletIDglobal = "";
        int UnitconvertParent = 1;
        int UnitconverChild = 1;
        int UnitBase = 1;
        public frmDMDongGoiCap1(Main frm)
        {
            InitializeComponent();
            IPDevice = XMLParser(configFile, "Table/IPPC");
            PrinterName = XMLParser(configFile, "Table/IPPrinterC1");
            //GetConfigDevice();
            //KhoiTaoThongSo();
            Pathname = XMLParser(configFile, "Table/LinkPath");
            ReadXml_User();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            gridView10.Invalidate();
            gridView10.IndicatorWidth = 35;
            NgonNgu = XMLParser(configFile, "Table/Language");
            dtBuffer.Columns.Add("Code", typeof(string));
            dtBuffer.Columns.Add("Timer", typeof(DateTime));
            dtTongStatus.Columns.Add("Counter", typeof(string));
            dtTongStatus.Columns.Add("Timer", typeof(DateTime));
            objLSX = new ProductionOrderRepository().GetAllByCondition(x => x.Status == 1)[0];
            if(objLSX.Code !="")
            {
                txtLenh.Text = objLSX.Code;
                dateNgayCT.DateTime = (DateTime)objLSX.CreationTime;
                txtNSX.DateTime = (DateTime)objLSX.ManufactureDate;
                txtHSD.DateTime = (DateTime)objLSX.ExpireDate;
            }
            //{
            //    DOCUMENT chuoi = new DOCUMENT_CHECKEntity().DOCUMENTMax();
            //    dateNgayCT.DateTime = (DateTime)chuoi.RefDate;
            //    txtLenh.Text = chuoi.ID;
            //    txtNSX.DateTime = (DateTime)chuoi.ManufactureDate;
            //    txtHSD.DateTime = (DateTime)chuoi.ExpireDate;
            //}
            if (txtLenh.Text.Trim() != "")
            {
                objdetail = new ProductionOrderDetailRepository().GetByCode(objLSX.Code);
                txtMaSP.Text = objdetail.ProductCode;
                txtTenSP.Text = objdetail.ProductName;
                txtLOT.Text = objdetail.LotNumber;
                //calcHop.Value = (decimal)(objLenhdetail.CountQR / objLenhdetail.UnitPrice);
                //calcThung.Value = (decimal)(objLenhdetail.UnitPrice / objLenhdetail.UnitConvert);

            }
            gridControlCounterTong.DataSource = dtTongStatus;
            gridControlBuffer.DataSource = dtBuffer;
            IPDevice = XMLParser(configFile, "Table/IPPC");
            //IPAddress ipAddress = IPAddress.Parse(IPCAM);
            //ServerSocket = new TcpListener(ipAddress, 3000);
            //listenner = new Thread(ListenForRequests);
            //txtIP_Cam.Text = IPCAM;
            txtScan.Focus();
            //HamGetStatusPrinter();
            
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
        #region Code
        public string CreateCodeCap1(int Cap)
        {
            string CodeCap1 = "";
            DataTable objTable = new SyncDataFunction().GetCodeMap(Cap, txtLenh.Text.Trim());
            if(objTable.Rows.Count >0)
            {
                CodeCap1 = objTable.Rows[0]["Code1"].ToString();
            }    
            //EnumStatus rsstockdetail = new EnumStatus();
            //BOXDEFINE objCuon = new BOXDEFINE();
            //objCuon.KeyID = Guid.NewGuid();
            //objCuon.RefStatus = 1;
            //objCuon.RefType = 0;
            //objCuon.LenhSanXuat = txtLenh.Text;
            //objCuon.ProductID = txtMaSP.Text;
            //objCuon.ProductName = txtTenSP.Text;
            //objCuon.LOT = txtLOT.Text;
            //objCuon.Box_NO = "B" + txtLenh.Text + "_" + String.Format("{0:00000}", new BOXDEFINEEntity().GetMaxTRANCUONDEFINE(txtLenh.Text) + 1)+"*"+txtMaSP.Text;
            //objCuon.Unit = "";
            //objCuon.Quantity = 1;
            //objCuon.Status = 1;
            //objCuon.UnitConvert = 1;
            //objCuon.CurrentQty = 1;
            //objCuon.PrintCount = 0;
            //objCuon.NgaySanXuat = txtNSX.DateTime;
            //objCuon.Sorted = new BOXDEFINEEntity().GetMaxCUONDEFINE() + 1;
            //objCuon.SortedLenh = new BOXDEFINEEntity().GetMaxTRANCUONDEFINE(txtLenh.Text) + 1;
            //objCuon.QRCode = objCuon.Box_NO + "|" + objCuon.ProductID + "|" + objCuon.ProductName + "|" + objCuon.LOT + "|" + objCuon.Unit + "|" + (int)objCuon.Quantity + "|" + String.Format("{0:dd/MM/yyyy}", objCuon.NgaySanXuat);
            //objCuon.Description = "";
            //objCuon.CreatedBy = objuser.UserID;
            //objCuon.ModifiedBy = objuser.UserID;
            //objCuon.ModifiedDate = DateTime.Now;
            //objCuon.CreatedDate = DateTime.Now;
            //objCuon.Active = true;
            //rsstockdetail = new ProjectDAO.Controller.BOXDEFINEEntity().ThemCUONDEFINE(objCuon);
            //if (rsstockdetail.IDStatus != 1)
            //{
            //    XtraMessageBox.Show("Lưu thùng thất bại", "Thông Báo");
            //}
            //else
            //{
            //    CodeCap1 = objCuon.Box_NO;
            //}
            return CodeCap1;
        }
        
        #endregion
        #region Camera
       
       
        public bool CheckCode(string Code)
        {
            bool Trave = false;
            for (int i = 0; i < dtBuffer.Rows.Count; i++)
            {
                if(dtBuffer.Rows[i]["Code"].ToString() == Code)
                {
                    Trave = true;
                    break;
                }
            }
            return Trave;

        }
        
        public void KiemTraCode(string Code)
        {
            if(calcLevel.Value != 0)
            {
                UnitconvertParent = (int)new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value).UnitConvertValue;
                UnitconverChild = new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value - 1) != null ? (int)new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value - 1).UnitConvertValue : 1;
                if (Code.Length > 7)
                {
                    //string arr = Code.Substring(7, Code.Length - 7).ToString().Trim();
                    string arr = Code;
                    //string[] tach = arr.ToString().Split('/');
                    if (arr.Length > 10)
                    {
                        //TH chuỗi 12 ký tự
                        //string tach = arr.ToString().Substring(ChuoiLink.Length, 36);//Lấy mã Code2
                        //string tach = arr.ToString().Substring(0, 12);//Lấy mã Code2
                        //TH chuối 20 ký tự
                        //string tach = arr.ToString().Substring(ChuoiLink.Length, 20);//Lấy mã Code2
                        //memoStatus.Text = tach[5].ToString();
                        //new CodeANSIEntity().EditCodeANSIByKey(long.Parse(DecryptString(tach[5].ToString().Substring(0, 12), "1").ToString()), 1);
                        //if (new CodeANSIEntity().CheckCodeANSI(tach))
                        //{
                        //    new CodeANSIEntity().EditCodeANSI(tach, 1);
                        //    CountLoi = 0;
                        //    //txtCounLoi.Text = CountLoi + "";

                        //}
                        //else
                        //{
                        //    CountLoi++;
                        //    //txtCounLoi.Text = CountLoi + "";
                        //    new CodeANSIEntity().EditCodeANSI(tach, 2);
                        //    if (CountLoi >= 10)
                        //    {
                        //        //if (globalStatusPLC == EventDrivenTCPClient.ConnectionStatus.Connected)
                        //        //{
                        //        //    StopBangTai();
                        //        //}
                        //        XtraMessageBox.Show("Số lượng lỗi vượt 10 hộp.In xấu hoặc sensor máy in bị hỏng!", "Thông Báo");
                        //        CountLoi = 0;
                        //    }
                        //    //txtCounLoi.Text = CountLoi + "";

                        //}
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
                                    if (codeCap1.LevelCode == calcLevel.Value)
                                    {
                                        DataRow rowbuf = dtBuffer.NewRow();
                                        rowbuf["Code"] = Trave;
                                        rowbuf["Timer"] = DateTime.Now;
                                        dtBuffer.Rows.Add(rowbuf);
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
                            string CodeCap1 = CreateCodeCap1((int)calcLevel.Value + 1);
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
                                        obj.LevelBox = (int)calcLevel.Value + 1;
                                        obj.KeyCuon = (row["Code"].ToString());
                                        obj.LevelCuon = (int)calcLevel.Value;
                                        obj.ProductionOrderCode = txtLenh.Text;
                                        obj.ProductCode = txtMaSP.Text;
                                        obj.ProductName = txtTenSP.Text;
                                        obj.UnitCode = "";
                                        obj.Quantity = 1;
                                        obj.LOT = txtLOT.Text;
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
                                            XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
                                            break;
                                        }
                                    }
                                    if (Flag)
                                    {
                                        PalletIDglobal = CodeCap1;
                                        ProductionOrderDetailCode objCode = new ProductionOrderDetailCodeRepository().GetOneByCondition(x => x.Code1 == CodeCap1 && x.LevelPackage == (int)calcLevel.Value + 1);
                                        if (objCode.LineCode != null)
                                        {
                                            objCode.PrintCount = objCode.PrintCount + 1;
                                            objCode.Qty = 1;
                                            new ProductionOrderDetailCodeRepository().Update(objCode);
                                        }
                                        WaitDialog.CreateWaitDialog("In nhãn thùng ...", "Thông Báo");
                                        WaitDialog.CloseWaitDialog();
                                        InTemTP(CodeCap1, 1, "");
                                        dtBuffer.Rows.Clear();
                                        gridControlBuffer.DataSource = dtBuffer;
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("Chưa có dữ liệu ", "Thông Báo");
                                }
                            }
                            else
                            {
                                XtraMessageBox.Show("Chưa có dữ liệu code cấp " + calcLevel.Value, "Thông Báo");

                            }

                        }
                    }


                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập cấp đóng gói!", "Thông Báo");
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



        #endregion
        public List<ProductOrderDetailCodeView> SyncProductOrderCode(int levelcode)
        {
            List<ProductionOrderDetailCode> objProducttion = new List<ProductionOrderDetailCode>();
            ProductOrderDetailCodeView objview = new ProductOrderDetailCodeView();
            List<ProductOrderDetailCodeView> list = new List<ProductOrderDetailCodeView>();
            objview.code = "";
            objProducttion = new ProductionOrderDetailCodeRepository().GetAllByCondition(x => x.LevelPackage == levelcode);
            for(int i =0;i < objProducttion.Count;i++)
            {
                objview = new ProductOrderDetailCodeView();
                objview.code = objProducttion[i].Code;
                objview.code1 = objProducttion[i].Code1;
                objview.code2 = objProducttion[i].Code2;
                objview.lineCode = objProducttion[i].LineCode;
                objview.productionOrderCode = objProducttion[i].ProductionOrderCode;
                objview.levelPackage = (int)objProducttion[i].LevelPackage;
                objview.creatorId = objProducttion[i].CreatorId;
                objview.creationTime = objProducttion[i].CreationTime;
                objview.lastModifierId = objProducttion[i].LastModifierId;
                objview.lastModificationTime = objProducttion[i].LastModificationTime;
                objview.active = objProducttion[i].Active;
                list.Add(objview);
            }
            return list;
        }
        public List<ProductionOrderDetailMAPView> SyncProductOrderCodeMap(int levelcode)
        {
            List<ProductionOrderDetailMAP> objProducttion = new List<ProductionOrderDetailMAP>();
            ProductionOrderDetailMAPView objview = new ProductionOrderDetailMAPView();
            List<ProductionOrderDetailMAPView> list = new List<ProductionOrderDetailMAPView>();
            objview.code = "";
            //objProducttion = new ProductionOrderDetailMAPRepository().GetAllByCondition(x => x.LevelBox == levelcode);
            objProducttion = new ProductionOrderDetailMAPRepository().GetAll();
            for (int i = 0; i < objProducttion.Count; i++)
            {
                objview = new ProductionOrderDetailMAPView();
                objview.code = objProducttion[i].Code;
                objview.keyBox = objProducttion[i].KeyBox;
                objview.keyCuon = objProducttion[i].KeyCuon;
                objview.levelBox = (int)objProducttion[i].LevelBox;
                objview.productionOrderCode = objProducttion[i].ProductionOrderCode;
                objview.productCode= objProducttion[i].ProductCode;
                objview.lot = objProducttion[i].LOT;
                objview.quantity = 1;
                objview.unitCode = objProducttion[i].UnitCode;
                objview.sorted = (int)objProducttion[i].Sorted;
                objview.creatorId = objProducttion[i].CreatedBy;
                objview.creationTime = objProducttion[i].CreatedDate;
                objview.lastModifierId = objProducttion[i].ModifiedBy;
                objview.lastModificationTime = objProducttion[i].ModifiedDate;
                objview.active = objProducttion[i].Active;
                list.Add(objview);
            }
            return list;
        }
      

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SyncDataFunction objSync = new SyncDataFunction();
            List<ProductionOrderDetailMAPView> list = SyncProductOrderCodeMap(2);
            WaitDialog.CreateWaitDialog("Nạp " + list.Count + " code lên Cloud ...", "Thông Báo");

            var json = JsonConvert.SerializeObject(list);
            string Data = objSync.CallAPIPOSTToken("http://tenant1.api.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
            DataToken objToken = objSync.JSONParserMapToken(Data);
            string ds = objSync.CallAPIPost("http://tenant1.api.vmspms.vn/api/production-order-detail-code-map-desktop", objToken.access_token, json);
            StatusResponse objrp = objSync.JSONParserResponse(ds);
            if (objrp.idStatus == 1)
            {
                XtraMessageBox.Show(objrp.description, "Thông Báo");
            }
            else
            {
                XtraMessageBox.Show(objrp.description, "Thông Báo");
            }
            WaitDialog.CloseWaitDialog();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //main_form.LoadKhuVuc(((DataTable)gridControl1.DataSource).Copy());
            Close();
        }

        private void calcLevel_TextChanged(object sender, EventArgs e)
        {
            if (calcLevel.Value != 0)
            {
                UnitconvertParent = (int)new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value).UnitConvertValue;
                UnitconverChild = new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value - 1) != null ? (int)new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value - 1).UnitConvertValue : 1;
                if(calcLevel.Value > 2)
                {
                    UnitBase = new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value - 1) != null ? (int)new UNITCONVERTRepository().GetOneByCondition(x => x.ProductCode == txtMaSP.Text && x.LevelPackage == (int)calcLevel.Value - 2).UnitConvertValue : 1;
                }
                else
                {
                    UnitBase = 1;
                }    
                calcHop.Text = UnitconverChild/ UnitBase +"";
                calcThung.Text = UnitconvertParent / UnitconverChild + "";
            }
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //InTemTP("", 1, "");
            //string CodeCap1 = CreateCodeCap1();
            //if (CodeCap1 != "")
            //{
            //    //Map - đóng gói
            //    if (dtBuffer.Rows.Count > 0)
            //    {
            //        bool Flag = true;
            //        for (int i = 0; i < dtBuffer.Rows.Count; i++)
            //        {
            //            EnumStatus rsstockdetail = new EnumStatus();
            //            DataRow row = dtBuffer.Rows[i];
            //            BOXDEFINE_MAP obj = new BOXDEFINE_MAP();
            //            obj.KeyID = Guid.NewGuid();
            //            obj.KeyBox = CodeCap1;
            //            obj.KeyCuon = (row["Code"].ToString());
            //            obj.LenhSanXuat = txtLenh.Text;
            //            obj.ProductID = txtMaSP.Text;
            //            obj.ProductName = txtTenSP.Text;
            //            obj.Unit = "";
            //            obj.Quantity = 1;
            //            obj.LOT = txtLOT.Text;
            //            obj.KeyDate = String.Format("{0:yyyyMMdd}", DateTime.Now);
            //            obj.KeyTime = String.Format("{0:HHmmss}", DateTime.Now);
            //            obj.Sorted = new BOXDEFINE_MAPEntity().GetMaxCUONDEFINE() + 1;
            //            obj.Active = true;
            //            obj.Description = "";
            //            obj.CreatedBy = objuser.UserID;
            //            obj.ModifiedBy = objuser.UserID;
            //            obj.CreatedDate = DateTime.Now;
            //            obj.ModifiedDate = DateTime.Now;
            //            rsstockdetail = new ProjectDAO.Controller.BOXDEFINE_MAPEntity().ThemBOXDEFINE_MAP(obj);
            //            if (rsstockdetail.IDStatus != 1)
            //            {
            //                Flag = false;
            //                XtraMessageBox.Show("Lưu Thất Bại", "Thông Báo");
            //                break;
            //            }
            //        }
            //        if (Flag)
            //        {
            //            PalletIDglobal = CodeCap1;
            //            WaitDialog.CreateWaitDialog("In nhãn thùng ...", "Thông Báo");
            //            WaitDialog.CloseWaitDialog();
            //            InTemTP(CodeCap1, 1, "");
            //            dtBuffer.Rows.Clear();
            //            gridControlBuffer.DataSource = dtBuffer;
            //        }
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Chưa có dữ liệu ", "Thông Báo");
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("Chưa có dữ liệu code cấp 1", "Thông Báo");

            //}
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
                    drtableOld["NgaySX"] = txtNSX.DateTime;
                    drtableOld["HanSuDung"] = txtHSD.DateTime;
                    drtableOld["IDPallet"] = PalletID;
                    drtableOld["Item"] = txtMaSP.Text;
                    drtableOld["ItemName"] = txtTenSP.Text;
                    drtableOld["LotNum"] = txtLOT.Text;
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
        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(txtScan.Text.Trim().Length > 0)
                {
                    KiemTraCode(txtScan.Text.Trim());
                }
                txtScan.SelectAll();
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
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

        private void simpleButton16_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (listenner.ThreadState == ThreadState.Unstarted)
            //    {
            //        listenner.Start();
            //        memoStatusCam.Text = "start listening";
            //        FlagCamStatus = 1;
            //    }
            //    else if (listenner.ThreadState == ThreadState.Running | listenner.ThreadState == ThreadState.WaitSleepJoin)
            //    {
            //        listenner.Suspend();
            //        memoStatusCam.Text = "Resume Server";
            //        ServerSocket.Stop();
            //        FlagCamStatus = 2;
            //    }
            //    else
            //    {
            //        listenner.Resume();
            //        FlagCamStatus = 3;
            //        memoStatusCam.Text = "Stop listening";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void frmDMDongGoiCap1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (FlagCamStatus == 2)
            //{
            //    XtraMessageBox.Show("Vui lòng start cam chuyển sang Stop Server", "Thông Báo");
            //    e.Cancel = true;
            //}
            //else
            //{
            //    listenner.Abort(100);
            //    startLISTENNER = false;
            //    frmthis.SetBien();
            //}
        }

        private void bbiExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn in lại Thùng?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                InTemTP(PalletIDglobal, 1, "");
            }
        }


    }
}