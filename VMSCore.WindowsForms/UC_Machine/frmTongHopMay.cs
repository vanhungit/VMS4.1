using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VMSCore.ViewModels.MasterData;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.EntityModels;

namespace VMSCore.WindowsForms
{
    public partial class frmTongHopMay : DevExpress.XtraEditors.XtraForm
    {
        EQUIP_PLANT_MAP MayTram = new EQUIP_PLANT_MAP();
        List<EQUIP_PLANT_MAP> MayInU2 = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> MayInX1 = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> MayInTTO = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> CameraCheck = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> CameraPack = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> PLCBangTai = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> PLCMayDo = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> PLCMayDoXray = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> PLCMayCan = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> MayinUBS = new List<EQUIP_PLANT_MAP>();
        List<EQUIP_PLANT_MAP> MayinPhunLinx = new List<EQUIP_PLANT_MAP>();

        List<UC_MayInAnserU2> listMHU2 = new List<UC_MayInAnserU2>();
        List<UC_MayInAnserX1> listMHX1 = new List<UC_MayInAnserX1>();
        List<UC_MayInTTO> listMHTTO = new List<UC_MayInTTO>();
        List<UC_MayCameraCheck> listMHCamCheck = new List<UC_MayCameraCheck>();
        List<UC_MayCameraPackage> listMHCamPackage = new List<UC_MayCameraPackage>();
        List<UC_PLCBangTai> listBangTai = new List<UC_PLCBangTai>();
        List<UC_MayDoKimLoai> listMayDo = new List<UC_MayDoKimLoai>();
        List<UC_MayDoXray> listMayDoXray = new List<UC_MayDoXray>();
        List<UC_WeightIntech> listMayCan = new List<UC_WeightIntech>();
        List<UC_MayInUBS> listUBS = new List<UC_MayInUBS>();
        List<UC_MayInCJLinx> listPhunLinx = new List<UC_MayInCJLinx>();
        string ChuoiLink = "";
        string configFile = @"XMLTimer.xml";
        string Pathname = "", IPPrinter, IPCAM, IPPLC, FileLog = "";
        string IPDevice = "";
        EQUIP_PLANT_MAP MayInNhan = new EQUIP_PLANT_MAP();
        ProductionOrder objLSX = new ProductionOrder();
        ProductionOrderDetail objdetail = new ProductionOrderDetail();
        //DOCUMENT objLenh = new DOCUMENT();
        //DOCUMENT_DETAIL objLenhdetail = new DOCUMENT_DETAIL();
        public frmTongHopMay(string Line)
        {
            InitializeComponent();
            IPDevice = XMLParser(configFile, "Table/IPPC");
            GetConfigDevice();
            this.Text = Line;
            layoutControlGDayChuyen.Text = Line;
            //objLenh = new DOCUMENTEntity().DOCUMENTGetByID(new DOCUMENT_CHECKEntity().DOCUMENTMax().ID);
            //objLenhdetail = new DOCUMENT_DETAILEntity().DOCUMENT_DETAILGetByID(objLenh.ID);
            //layoutControlGAnser.Text = Line + "-" + "01" + "-" + layoutControlGAnser.Text;
            //layoutControlGCam.Text = Line + "-" + "02" + "-" + layoutControlGCam.Text;
            //layoutControlGBangTai.Text = Line + "-" + "03" + "-" + layoutControlGBangTai.Text;
           
            objLSX = new ProductionOrderRepository().GetAllByCondition(x => x.Status == 1)[0];
            if (objLSX.Code != "")
            {
                txtLenh.Text = objLSX.Code;
                dateNgaySX.DateTime = (DateTime)objLSX.ManufactureDate;
                dateHSD.DateTime = (DateTime)objLSX.ExpireDate;
            }
            if (txtLenh.Text.Trim() != "")
            {
                objdetail = new ProductionOrderDetailRepository().GetByCode(objLSX.Code);
                txtMaSP.Text = objdetail.ProductCode;
                txtTenSP.Text = objdetail.ProductName;
                txtSoLo.Text = objdetail.LotNumber;
                //calcHop.Value = (decimal)(objLenhdetail.CountQR / objLenhdetail.UnitPrice);
                //calcThung.Value = (decimal)(objLenhdetail.UnitPrice / objLenhdetail.UnitConvert);

            }
            if (txtLenh.Text.Trim() != "")
            {
                //objLenhdetail = new DOCUMENT_DETAILEntity().DOCUMENT_DETAILGetByID(txtLenh.Text);
                //txtMaSP.Text = objLenhdetail.Product_ID;
                //txtSoLo.Text = objLenhdetail.Section_ID;
                //layoutControlGroup13.Text = "Lệnh sản xuất" +"|" + objLenh.ID + "|" + objLenhdetail.Product_ID;
                layoutControlGroup13.Text = "Lệnh sản xuất";
                LoadMayU2(MayInU2);
                LoadMayX1(MayInX1);
                LoadMayBangTai(PLCBangTai);
                LoadCamCheck(CameraCheck);
                LoadMayDo(PLCMayDo);
                LoadMayDoXray(PLCMayDoXray);
                LoadMayCan(PLCMayCan);
                LoadMayInUBS(MayinUBS);
                LoadMayInPhunLinx(MayinPhunLinx);
                LoadCamDongGoi(CameraPack);

            }

        }
        public void HienThiThongTin(string MaThietBi, string IP, string TrangThai)
        {
            txtStatusConnect.Text = MaThietBi + "-" + IP + "-" + TrangThai;
        }
        public void HamThucThiDuLieu(string MaThietBi, string IP, string DuLieu)
        {
            for (int i = 0; i < listMHX1.Count; i++)
            {
                if (listMHX1[i].Name == MaThietBi)
                {
                    listMHX1[i].Text = "Thiết bị " + MayInX1[i].header.Name + " " + DuLieu;
                }
            }
        }
        public void HamThucThiChucNang(EQUIP_PLANT_MAP DeviceSource, EQUIP_PLANT_MAP DeviceDest, string Command, string DuLieu)
        {
            //In phun Linx;
            //Máy X1;
            //Camera check code;
            //Máy cân;
            //Máy dò;
            //Máy Xray;
            //Camera đóng gói;
            //Máy in U2;
            //Scan tay;
            //Máy in Sato;
            if(DeviceSource.header.Code == "TB006")
            {
                for (int i = 0; i < listMHU2.Count; i++)
                {
                    if (listMHU2[i].Name.Trim() == "Máy in nhãn U2")
                    {
                        listMHU2[i].SendDataPackage(String.Format("{0:dd/MM/yyyy HH:mm:ss}", objLSX.ManufactureDate), String.Format("{0:dd/MM/yyyy}", objLSX.ExpireDate), DuLieu, DuLieu, "");
                    }
                }
            }    

        }
        public void LoadMayU2(List<EQUIP_PLANT_MAP> _MayInU2)
        {
            for(int i =0;i<_MayInU2.Count;i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _MayInU2[i].header.Code;
                    group1.Text = "Thiết bị " + _MayInU2[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayInAnserU2 _mayin = new UC_MayInAnserU2(_MayInU2[i], this, txtLenh.Text);
                    _mayin.Name = _MayInU2[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _MayInU2[i].header.Name;
                    item1.Height = 200;
                    listMHU2.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayX1(List<EQUIP_PLANT_MAP> _MayInU2)
        {
            for (int i = 0; i < _MayInU2.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _MayInU2[i].header.Code;
                    group1.Text = "Thiết bị " + _MayInU2[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayInAnserX1 _mayin = new UC_MayInAnserX1(_MayInU2[i], this, txtLenh.Text);
                    
                    _mayin.Name = _MayInU2[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _MayInU2[i].header.Name;
                    item1.Height = 200;
                    listMHX1.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayBangTai(List<EQUIP_PLANT_MAP> _PLCBangTai)
        {
            for (int i = 0; i < _PLCBangTai.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _PLCBangTai[i].header.Code;
                    group1.Text = "Thiết bị " + _PLCBangTai[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_PLCBangTai _mayin = new UC_PLCBangTai(_PLCBangTai[i], this, txtLenh.Text);
                    _mayin.Name = _PLCBangTai[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _PLCBangTai[i].header.Name;
                    item1.Height = 200;
                    listBangTai.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayDo(List<EQUIP_PLANT_MAP> _PLCBangTai)
        {
            for (int i = 0; i < _PLCBangTai.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _PLCBangTai[i].header.Code;
                    group1.Text = "Thiết bị " + _PLCBangTai[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayDoKimLoai _mayin = new UC_MayDoKimLoai(_PLCBangTai[i], this, txtLenh.Text);
                    _mayin.Name = _PLCBangTai[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _PLCBangTai[i].header.Name;
                    item1.Height = 200;
                    listMayDo.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayDoXray(List<EQUIP_PLANT_MAP> _PLCBangTai)
        {
            for (int i = 0; i < _PLCBangTai.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _PLCBangTai[i].header.Code;
                    group1.Text = "Thiết bị " + _PLCBangTai[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayDoXray _mayin = new UC_MayDoXray(_PLCBangTai[i], this, txtLenh.Text);
                    _mayin.Name = _PLCBangTai[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _PLCBangTai[i].header.Name;
                    item1.Height = 200;
                    listMayDoXray.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayCan(List<EQUIP_PLANT_MAP> _PLCBangTai)
        {
            for (int i = 0; i < _PLCBangTai.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _PLCBangTai[i].header.Code;
                    group1.Text = "Thiết bị " + _PLCBangTai[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_WeightIntech _mayin = new UC_WeightIntech(_PLCBangTai[i], this, txtLenh.Text);
                    _mayin.Name = _PLCBangTai[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _PLCBangTai[i].header.Name;
                    item1.Height = 200;
                    listMayCan.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayInUBS(List<EQUIP_PLANT_MAP> _PLCBangTai)
        {
            for (int i = 0; i < _PLCBangTai.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _PLCBangTai[i].header.Code;
                    group1.Text = "Thiết bị " + _PLCBangTai[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayInUBS _mayin = new UC_MayInUBS(_PLCBangTai[i], this, txtLenh.Text);
                    _mayin.Name = _PLCBangTai[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _PLCBangTai[i].header.Name;
                    item1.Height = 200;
                    listUBS.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadMayInPhunLinx(List<EQUIP_PLANT_MAP> _PLCBangTai)
        {
            for (int i = 0; i < _PLCBangTai.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _PLCBangTai[i].header.Code;
                    group1.Text = "Thiết bị " + _PLCBangTai[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayInCJLinx _mayin = new UC_MayInCJLinx(_PLCBangTai[i], this, txtLenh.Text);
                    _mayin.Name = _PLCBangTai[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _PLCBangTai[i].header.Name;
                    item1.Height = 200;
                    listPhunLinx.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadCamCheck(List<EQUIP_PLANT_MAP> _CamCheck)
        {
            for (int i = 0; i < _CamCheck.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _CamCheck[i].header.Code;
                    group1.Text = "Thiết bị " + _CamCheck[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayCameraCheck _mayin = new UC_MayCameraCheck(_CamCheck[i], this, txtLenh.Text);
                    _mayin.Name = _CamCheck[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _CamCheck[i].header.Name;
                    item1.Height = 200;
                    listMHCamCheck.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void LoadCamDongGoi(List<EQUIP_PLANT_MAP> _CamCheck)
        {
            for (int i = 0; i < _CamCheck.Count; i++)
            {
                layoutControl1.BeginUpdate();
                try
                {
                    // Hide the root group's border and caption.
                    layoutControl1.Root.GroupBordersVisible = false;
                    // Create a new Details group.
                    LayoutControlGroup group1 = new LayoutControlGroup();//Thêm Loại thiết bị
                    group1.Name = _CamCheck[i].header.Code;
                    group1.Text = "Thiết bị " + _CamCheck[i].header.Name;
                    group1.ExpandButtonVisible = true;
                    group1.Expanded = true;
                    group1.Height = 200;
                    // Create a layout item within the group.
                    LayoutControlItem item1 = group1.AddItem();//Thêm thiết bị
                    item1.FillControlToClientArea = false;
                    item1.SizeConstraintsType = SizeConstraintsType.Default;
                    //// Bind a control to the layout item.
                    UC_MayCameraPackage _mayin = new UC_MayCameraPackage(_CamCheck[i], this, txtLenh.Text);
                    _mayin.Name = _CamCheck[i].header.Name;
                    item1.Control = _mayin;
                    item1.TextVisible = false;
                    item1.Text = _CamCheck[i].header.Name;
                    item1.Height = 200;
                    listMHCamPackage.Add(_mayin);

                    //item1.Text = "Name";

                    //// Create a layout item that will display a date editor.
                    //DateEdit dtEdit1 = new DateEdit();
                    //dtEdit1.Name = "dtEdit1";
                    //LayoutControlItem item2 = new LayoutControlItem(layoutControl1, dtEdit1);
                    //item2.Text = "Date";
                    //// Position this item to the right of item1
                    //item2.Move(item1, InsertType.Right);
                    // Add the created group to the root group.
                    layoutControl1.Root.Add(group1);
                }
                finally
                {
                    // Unlock and update the layout control.
                    layoutControl1.EndUpdate();
                }
            }
        }
        public void GetConfigDevice()
        {
            MayTram = new DeviceRepository().GetEQUIP_PLANT_MAPByIP(IPDevice);
            for (int i = 0; i < MayTram.headercombo.Count; i++)
            {
                EQUIP_PLANT_MAP obj = new DeviceRepository().GetEQUIP_PLANT_MAPByID(MayTram.headercombo[i].KeyID_SON);
                if (obj.header.TypeDeviceCode == "T0003")
                {
                    MayInU2.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }

                else if (obj.header.TypeDeviceCode == "T0002")
                {
                    MayInX1.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0016")
                {
                    PLCBangTai.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0013")
                {
                    CameraCheck.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0009")
                {
                    CameraPack.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0018")
                {
                    PLCMayDo.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0012")
                {
                    PLCMayDoXray.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0011")
                {
                    PLCMayCan.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0005")
                {
                    MayinUBS.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
                else if (obj.header.TypeDeviceCode == "T0001")
                {
                    MayinPhunLinx.Add(new DeviceRepository().GetEQUIP_PLANT_MAPByID(obj.header.Code));
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            TimerTong.Enabled = true;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            for(int i =0;i< MayInU2.Count;i++)
            {
                if(MayInU2[i].headerptotocol.Count >0)
                {
                    listMHU2[i].client.Connect();
                    listMHU2[i].btnConnect.Enabled = false;
                }
            }
            for (int i = 0; i < MayInX1.Count; i++)
            {
                if (MayInX1[i].headerptotocol.Count > 0)
                {
                    listMHX1[i].client.Connect();
                    listMHX1[i].btnConnect.Enabled = false;
                }
            }
            for (int i = 0; i < PLCMayDo.Count; i++)
            {
                if (PLCMayDo[i].headerptotocol.Count > 0)
                {
                    listMayDo[i].client.Connect();
                    listMayDo[i].btnConnect.Enabled = false;
                }
            }
            for (int i = 0; i < PLCBangTai.Count; i++)
            {
                if (PLCBangTai[i].headerptotocol.Count > 0)
                {
                    listBangTai[i].client.Connect();
                    listBangTai[i].btnConnect.Enabled = false;
                }
            }
            for (int i = 0; i < PLCMayDoXray.Count; i++)
            {
                if (PLCMayDoXray[i].headerptotocol.Count > 0)
                {
                    listMayDoXray[i].client.Connect();
                    listMayDoXray[i].btnConnect.Enabled = false;
                }
            }
            for (int i = 0; i < PLCMayCan.Count; i++)
            {
                if (PLCMayCan[i].headerptotocol.Count > 0)
                {
                    listMayCan[i].client.Connect();
                    listMayCan[i].btnConnect.Enabled = false;
                }
            }
            for (int i = 0; i < MayinPhunLinx.Count; i++)
            {
                if (MayinPhunLinx[i].headerptotocol.Count > 0)
                {
                    listPhunLinx[i].client.Connect();
                    listPhunLinx[i].btnConnect.Enabled = false;
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < MayInU2.Count; i++)
            {
                if (MayInU2[i].headerptotocol.Count > 0)
                {
                    listMHU2[i].client.Disconnect();
                    listMHU2[i].btnConnect.Enabled = true;
                }
            }
            for (int i = 0; i < MayInX1.Count; i++)
            {
                if (MayInX1[i].headerptotocol.Count > 0)
                {
                    listMHX1[i].client.Disconnect();
                    listMHX1[i].btnConnect.Enabled = true;
                }
            }
            for (int i = 0; i < PLCMayDo.Count; i++)
            {
                if (PLCMayDo[i].headerptotocol.Count > 0)
                {
                    listMayDo[i].client.Disconnect();
                    listMayDo[i].btnConnect.Enabled = true;
                }
            }
            for (int i = 0; i < PLCBangTai.Count; i++)
            {
                if (PLCBangTai[i].headerptotocol.Count > 0)
                {
                    listBangTai[i].client.Disconnect();
                    listBangTai[i].btnConnect.Enabled = true;
                }
            }
            for (int i = 0; i < PLCMayDoXray.Count; i++)
            {
                if (PLCMayDoXray[i].headerptotocol.Count > 0)
                {
                    listMayDoXray[i].client.Disconnect();
                    listMayDoXray[i].btnConnect.Enabled = true;
                }
            }
            for (int i = 0; i < PLCMayCan.Count; i++)
            {
                if (PLCMayCan[i].headerptotocol.Count > 0)
                {
                    listMayCan[i].client.Disconnect();
                    listMayCan[i].btnConnect.Enabled = true;
                }
            }
            for (int i = 0; i < MayinPhunLinx.Count; i++)
            {
                if (MayinPhunLinx[i].headerptotocol.Count > 0)
                {
                    listPhunLinx[i].client.Disconnect();
                    listPhunLinx[i].btnConnect.Enabled = false;
                }
            }
        }

        private void TimerTong_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i < MayInU2.Count; i++)
            //{
            //    if (MayInU2[i].headerptotocol.Count > 0)
            //    {
            //        listMHU2[i].RequestDataPrinter();
            //    }
            //}
            //for (int i = 0; i < MayInX1.Count; i++)
            //{
            //    if (MayInX1[i].headerptotocol.Count > 0)
            //    {
            //        listMHX1[i].GetPrinting_ANSER();
            //    }
            //}
            for (int i = 0; i < PLCMayDo.Count; i++)
            {
                if (PLCMayDo[i].headerptotocol.Count > 0)
                {
                    listMayDo[i].MayDoGetStatus();
                }
            }
            //for (int i = 0; i < PLCMayDoXray.Count; i++)
            //{
            //    if (PLCMayDoXray[i].headerptotocol.Count > 0)
            //    {
            //        listMayDoXray[i].MayDoGetStatus();
            //    }
            //}
        }


       
    }
}
