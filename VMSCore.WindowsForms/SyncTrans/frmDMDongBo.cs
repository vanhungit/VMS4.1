using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraEditors;
using Newtonsoft.Json;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SyncData;
using VMSCore.Infrastructure.Features.SyncData.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;
using Button = VMSCore.EntityModels.Button;

namespace VMSCore.WindowsForms
{
    public partial class frmDMDongBo : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public frmDMDongBo(Main frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            gridControl1.DataSource = new SyncDataFunction().sproc_GetListTableSync();
            ReadXml_User();
            //HienThiChiNhanh();
            //NhomThietBi();

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

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //main_form.LoadKhuVuc(((DataTable)gridControl1.DataSource).Copy());
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //SyncDataFunction objSync = new SyncDataFunction();
            //string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
            //DataToken objToken = objSync.JSONParserMapToken(Data);
            //DataMachineModelView objData = new DataMachineModelView();
            //objData.code = Guid.NewGuid().ToString();
            //objData.deviceGroupName = "PRINT_MAKING";
            //objData.statusType = "CONNECT";
            //objData.deviceCode = "TB001";
            //objData.lineCode = "L001";
            //objData.productionOrderCode = "LSX0000001";
            //objData.productCode = "SP08";
            //objData.data = "C0001";
            //objData.creatorId = "admin";
            //objData.creationTime = DateTime.Now;
            //objData.lastModifierId = "admin";
            //objData.lastModificationTime = DateTime.Now;
            //objData.active = true;
            //List<DataMachineModelView> doituong = new List<DataMachineModelView>();
            //doituong.Add(objData);

            //string ds = objSync.CallAPIPost("http://vms41.api.vmspms.vn/api/device-status-group-desktop", objToken.access_token, objSync.JSONToStringDataMachineList(doituong));
            //HamDongBo("MACHINE_SYNC");
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                DongBoAll(id);
            }

        }
        public void HamDongBo(string table)
        {
            if(table != "")
            {
                WaitDialog.CreateWaitDialog("Đồng bộ thực thi lên Cloud ...", "Thông Báo");
                SyncDataFunction objSync = new SyncDataFunction();
                string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                DataToken objToken = objSync.JSONParserMapToken(Data);
                List<MACHINE_SYNC> list = new MACHINE_SYNCRepository().GetAllByCondition(x => x.Sorted < 1000);
                var json = JsonConvert.SerializeObject(list);
                string ds = objSync.CallAPIPost("https://api-vms41.vmspms.vn/api/device-status-group-desktop", objToken.access_token, json);
                StatusResponse objrp = objSync.JSONParserResponse(ds);
                MACHINE_SYNC_LOG objMachineLog = new MACHINE_SYNC_LOG();
                objMachineLog.Id = Guid.NewGuid();
                objMachineLog.Code = objMachineLog.Id.ToString();
                objMachineLog.Name = table;
                objMachineLog.MethodName = "https://api-vms41.vmspms.vn/api/device-status-group-desktop";
                objMachineLog.TypeGiaoDich = "POST";
                objMachineLog.TokenCode = objToken.access_token;
                objMachineLog.JsonSend = json;
                objMachineLog.JsonReceiv = ds;
                objMachineLog.Status = objrp.idStatus.ToString();
                objMachineLog.Sorted = new MACHINE_SYNC_LOGRepository().GetMaxMACHINE_SYNC_LOG() + 1;
                objMachineLog.Description = objrp.jsonData;
                objMachineLog.UserName = objuser.Username;
                objMachineLog.CreatedBy = objuser.Username;
                objMachineLog.ModifiedBy = objuser.Username;
                objMachineLog.CreatedDate = DateTime.Now;
                objMachineLog.ModifiedDate = DateTime.Now;
                objMachineLog.Active = true;
                new MACHINE_SYNC_LOGRepository().Add(objMachineLog);
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
        }
        public void HamDongBoTable(string table, string Link, string jsonSend, DataToken objToken)
        {
            if (table != "")
            {
                string TimeStart = "", TimeEnd = "";
                TimeStart = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                WaitDialog.CreateWaitDialog("Đồng bộ "+ table +" lên Cloud ...", "Thông Báo");
                SyncDataFunction objSync = new SyncDataFunction();
                //string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                //DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = objSync.CallAPIPost(Link, objToken.access_token, jsonSend);
                TimeEnd = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                StatusResponse objrp = objSync.JSONParserResponse(ds);
                MACHINE_SYNC_LOG objMachineLog = new MACHINE_SYNC_LOG();
                objMachineLog.Id = Guid.NewGuid();
                objMachineLog.Code = objMachineLog.Id.ToString();
                objMachineLog.Name = table;
                objMachineLog.MethodName = Link;
                objMachineLog.TypeGiaoDich = "POST";
                objMachineLog.TokenCode = objToken.access_token;
                objMachineLog.JsonSend = jsonSend;
                objMachineLog.JsonReceiv = ds;
                objMachineLog.Status = objrp.idStatus.ToString();
                objMachineLog.Sorted = new MACHINE_SYNC_LOGRepository().GetMaxMACHINE_SYNC_LOG() + 1;
                objMachineLog.Description = objrp.jsonData +"|"+TimeStart+"|"+TimeEnd;
                objMachineLog.UserName = objuser.Username;
                objMachineLog.CreatedBy = objuser.Username;
                objMachineLog.ModifiedBy = objuser.Username;
                objMachineLog.CreatedDate = DateTime.Now;
                objMachineLog.ModifiedDate = DateTime.Now;
                objMachineLog.Active = true;
                new MACHINE_SYNC_LOGRepository().Add(objMachineLog);
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
        }
        public void DongBoAll(string TableName)
        {
            SyncDataFunction objSync = new SyncDataFunction();
            string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2w3E*");
            DataToken objToken = objSync.JSONParserMapToken(Data);
            switch (TableName)
            {
                case "MACHINE_SYNC":
                    List<MACHINE_SYNC> listMACHINE_SYNC = new MACHINE_SYNCRepository().GetAll();
                    var jsonMACHINE_SYNC = JsonConvert.SerializeObject(listMACHINE_SYNC);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/device-status-group-desktop", jsonMACHINE_SYNC, objToken);
                    break;
                case "Company":
                    List<Company> list = new CompanyRepository().GetAll();
                    var json = JsonConvert.SerializeObject(list);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, json, objToken);
                    break;
                case "Factory":
                    List<Factory> listFactory = new FactoryRepository().GetAll();
                    var jsonFactory = JsonConvert.SerializeObject(listFactory);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonFactory, objToken);
                    break;
                case "WorkShop":
                    List<WorkShop> listWorkShop = new WorkshopRepository().GetAllByCondition(x => x.Active == true);
                    var jsonWorkShop = JsonConvert.SerializeObject(listWorkShop);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonWorkShop, objToken);
                    break;
                case "Stage":
                    List<Stage> listStage = new StageRepository().GetAll();
                    var jsonStage = JsonConvert.SerializeObject(listStage);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonStage, objToken);
                    break;

                case "DeviceGroup":
                    List<DeviceGroup> listDeviceGroup = new DeviceGroupRepository().GetAll();
                    var jsonDeviceGroup = JsonConvert.SerializeObject(listDeviceGroup);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonDeviceGroup, objToken);
                    break;
                case "TypeDevice":
                    List<TypeDevice> listTypeDevice = new TypeDeviceRepository().GetAll();
                    var jsonTypeDevice = JsonConvert.SerializeObject(listTypeDevice);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonTypeDevice, objToken);
                    break;
                case "Device":
                    List<Device> listDevice = new DeviceRepository().GetAll();
                    var jsonDevice = JsonConvert.SerializeObject(listDevice);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonDevice, objToken);
                    break;
                case "Device_PROTOCOL":
                    List<Device_PROTOCOL> listDevice_PROTOCOL = new Device_PROTOCOLRepository().GetAll();
                    var jsonDevice_PROTOCOL = JsonConvert.SerializeObject(listDevice_PROTOCOL);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonDevice_PROTOCOL, objToken);
                    break;
                case "ConnectConfig":
                    List<ConnectConfig> listConnectConfig = new ConnectConfigRepository().GetAll();
                    var jsonConnectConfig = JsonConvert.SerializeObject(listConnectConfig);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonConnectConfig, objToken);
                    break;
                case "StatusConfig":
                    List<StatusConfig> listStatusConfig = new StatusConfigRepository().GetAll();
                    var jsonStatusConfig = JsonConvert.SerializeObject(listStatusConfig);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonStatusConfig, objToken);
                    break;
                case "ErrorConfig":
                    List<ErrorConfig> listErrorConfig = new ErrorConfigRepository().GetAll();
                    var jsonErrorConfig = JsonConvert.SerializeObject(listErrorConfig);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonErrorConfig, objToken);
                    break;
                case "WarningConfig":
                    List<WarningConfig> listWarningConfig = new WarningConfigRepository().GetAll();
                    var jsonWarningConfig = JsonConvert.SerializeObject(listWarningConfig);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonWarningConfig, objToken);
                    break;
                    ////////////////////
                case "Protocol":
                    List<Protocol> listProtocol = new ProtocolRepository().GetAll();
                    var jsonProtocol = JsonConvert.SerializeObject(listProtocol);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProtocol, objToken);
                    break;
                case "ProtocolParam":
                    List<ProtocolParam> listProtocolParam = new ProtocolParamRepository().GetAll();
                    var jsonProtocolParam = JsonConvert.SerializeObject(listProtocolParam);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProtocolParam, objToken);
                    break;
                ////////////////
                case "ProductionOrder":
                    List<ProductionOrder> listProductionOrder = new ProductionOrderRepository().GetAllByCondition(x => x.Active == true);
                    var jsonProductionOrder = JsonConvert.SerializeObject(listProductionOrder);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductionOrder, objToken);
                    break;
                case "ProductionOrderDetail":
                    List<ProductionOrderDetail> listProductionOrderDetail = new ProductionOrderDetailRepository().GetAll();
                    var jsonProductionOrderDetail = JsonConvert.SerializeObject(listProductionOrderDetail);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductionOrderDetail, objToken);
                    break;
                case "ProductionOrderDetailCode":
                    List<ProductionOrderDetailCode> listProductionOrderDetailCode = new ProductionOrderDetailCodeRepository().GetAll();
                    var jsonProductionOrderDetailCode = JsonConvert.SerializeObject(listProductionOrderDetailCode);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductionOrderDetailCode, objToken);
                    break;
                case "ProductionOrderRawDetail":
                    List<ProductionOrderRawDetail> listProductionOrderRawDetail = new ProductionOrderRawDetailRepository().GetAll();
                    var jsonProductionOrderRawDetail = JsonConvert.SerializeObject(listProductionOrderRawDetail);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductionOrderRawDetail, objToken);
                    break;
                case "ProductionOrderDetailMAP":
                    List<ProductionOrderDetailMAP> listProductionOrderDetailMAP = new ProductionOrderDetailMAPRepository().GetAll();
                    var jsonProductionOrderDetailMAP = JsonConvert.SerializeObject(listProductionOrderDetailMAP);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductionOrderDetailMAP, objToken);
                    break;
                case "ProductionOrderDetailCheck":
                    List<ProductionOrderDetailCheck> listProductionOrderDetailCheck = new ProductionOrderDetailCheckRepository().GetAll();
                    var jsonProductionOrderDetailCheck = JsonConvert.SerializeObject(listProductionOrderDetailCheck);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductionOrderDetailCheck, objToken);
                    break;
                /////////////////
                case "Line":
                    List<Line> listLine = new LineRepository().GetAll();
                    var jsonLine = JsonConvert.SerializeObject(listLine);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonLine, objToken);
                    break;
                case "LineDevice":
                    List<LineDevice> listLineDevice = new LineDeviceRepository().GetAll();
                    var jsonLineDevice = JsonConvert.SerializeObject(listLineDevice);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonLineDevice, objToken);
                    break;
                //////
                case "ProductGroup":
                    List<ProductGroup> listProductGroup = new ProductGroupRepository().GetAll();
                    var jsonProductGroup = JsonConvert.SerializeObject(listProductGroup);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductGroup, objToken);
                    break;
                case "ProductType":
                    List<ProductType> listProductType = new ProductTypeRepository().GetAll();
                    var jsonProductType = JsonConvert.SerializeObject(listProductType);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProductType, objToken);
                    break;
                case "Product":
                    List<Product> listProduct = new ProductRepository().GetAll();
                    var jsonProduct = JsonConvert.SerializeObject(listProduct);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonProduct, objToken);
                    break;
                case "UNIT":
                    List<UNIT> listUNIT = new UNITRepository().GetAll();
                    var jsonUNIT = JsonConvert.SerializeObject(listUNIT);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonUNIT, objToken);
                    break;
                case "UNITCONVERT":
                    List<UNITCONVERT> listUNITCONVERT = new UNITCONVERTRepository().GetAll();
                    var jsonUNITCONVERT = JsonConvert.SerializeObject(listUNITCONVERT);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonUNITCONVERT, objToken);
                    break;
                case "MaterialProduct":
                    List<MaterialProduct> listMaterialProduct = new MaterialProductRepository().GetAll();
                    var jsonMaterialProduct = JsonConvert.SerializeObject(listMaterialProduct);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonMaterialProduct, objToken);
                    break;
                /////
                case "Shift":
                    List<Shift> listShift = new ShiftRepository().GetAll();
                    var jsonShift = JsonConvert.SerializeObject(listShift);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonShift, objToken);
                    break;
                case "Staff":
                    List<Staff> listStaff = new StaffRepository().GetAll();
                    var jsonStaff = JsonConvert.SerializeObject(listStaff);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonStaff, objToken);
                    break;
                case "Skills":
                    List<Skills> listSkills = new SkillRepository().GetAll();
                    var jsonSkills = JsonConvert.SerializeObject(listSkills);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonSkills, objToken);
                    break;
                case "StaffSkill":
                    List<StaffSkill> listStaffSkill = new StaffSkillRepository().GetAll();
                    var jsonStaffSkill = JsonConvert.SerializeObject(listStaffSkill);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonStaffSkill, objToken);
                    break;
                case "ShiftStaff":
                    List<ShiftStaff> listShiftStaff = new ShiftStaffRepository().GetAll();
                    var jsonShiftStaff = JsonConvert.SerializeObject(listShiftStaff);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonShiftStaff, objToken);
                    break;
                case "Department":
                    List<Department> listDepartment = new DepartmentRepository().GetAll();
                    var jsonDepartment = JsonConvert.SerializeObject(listDepartment);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonDepartment, objToken);
                    break;
                case "DepartmentStaff":
                    List<DepartmentStaff> listDepartmentStaff = new DepartmentStaffRepository().GetAll();
                    var jsonDepartmentStaff = JsonConvert.SerializeObject(listDepartmentStaff);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonDepartmentStaff, objToken);
                    break;
                ////
                case "Role":
                    List<Role> listRole = new RoleRepository().GetAll();
                    var jsonRole = JsonConvert.SerializeObject(listRole);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonRole, objToken);
                    break;
                case "RoleUser":
                    List<RoleUser> listRoleDetaill = new RoleUserRepository().GetAll();
                    var jsonRoleDetaill = JsonConvert.SerializeObject(listRoleDetaill);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonRoleDetaill, objToken);
                    break;
                case "Button":
                    List<Button> listButton = new ButtonRepository().GetAll();
                    var jsonButton = JsonConvert.SerializeObject(listButton);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonButton, objToken);
                    break;
                case "ObjectEntity":
                    List<ObjectEntity> listObjectEntity = new ObjectEntityRepository().GetAll();
                    var jsonObjectEntity = JsonConvert.SerializeObject(listObjectEntity);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonObjectEntity, objToken);
                    break;
                case "RoleObjectButtonMapping":
                    List<RoleObjectButtonMapping> listRoleObjectButtonMapping = new RoleObjectButtonMappingRepository().GetAll();
                    var jsonRoleObjectButtonMapping = JsonConvert.SerializeObject(listRoleObjectButtonMapping);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonRoleObjectButtonMapping, objToken);
                    break;
                case "ObjectButtonMapping":
                    List<ObjectButtonMapping> listObjectButtonMapping = new ObjectButtonMappingRepository().GetAll();
                    var jsonObjectButtonMapping = JsonConvert.SerializeObject(listObjectButtonMapping);
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync?tableName=" + TableName, jsonObjectButtonMapping, objToken);
                    break;
            }    
        }
        public ProductOrderView SynCProductOrder(string Code)
        {
            ProductionOrder objProducttion = new ProductionOrder();
            ProductOrderView objview = new ProductOrderView();
            objview.code = "";
            objProducttion = new ProductionOrderRepository().GetByCode(Code);
            if(objProducttion.Code != null)
            {
                objview.code = objProducttion.Code;
                objview.fromDate = (DateTime)objProducttion.FromDate;
                objview.toDate = (DateTime)objProducttion.ToDate;
                objview.lineCode = objProducttion.LineCode;
                objview.numberTemp = (int)(objProducttion.NumberTemp);
                objview.status = (int)objProducttion.Status;
                objview.creatorId = objProducttion.CreatorId;
                objview.creationTime = objProducttion.CreationTime;
                objview.lastModifierId = objProducttion.LastModifierId;
                objview.lastModificationTime = objProducttion.LastModificationTime;
                objview.active = objProducttion.Active;

            }
            return objview;
        }
        public void SynCProductOrderDetail(string Code)
        {

        }
        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HamDongBo("123");
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa thiết bị này ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                    string objerror = new DeviceRepository().DeleteDeviceByID(id);
                    if (objerror != "")
                    {
                        XtraMessageBox.Show("Xóa thiết bị thành công !", "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa thiết bị " + objerror + "", "Thông Báo");
                    }
                    gridControl1.DataSource = new DeviceRepository().GetAll();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                frmCapNhatThietBi frm = new frmCapNhatThietBi(id);
                frm.ShowDialog();
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

        private void barLargeButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                frmMapTBChaCon frm = new frmMapTBChaCon(id);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                frmMapTBGiaoThuc frm = new frmMapTBGiaoThuc(id);
                frm.ShowDialog();
            }
        }

        private void barLargeButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}