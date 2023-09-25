using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SalesManager.Controller;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;
using System.Globalization;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SyncData;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SyncData.Implementations;
using Newtonsoft.Json;

namespace VMSCore.WindowsForms
{
    public partial class UC_LenhSXTongHop : UserControl
    {
        frmLenhSanXuat mainform;
      
        public UC_LenhSXTongHop(frmLenhSanXuat frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            dateTu.DateTime = DateTime.Now;
            dateDen.DateTime = DateTime.Now;
           
            mainform = frm;
           
            #region Load Phân Quyền
            ReadXml_User();
            #endregion
        }
        string UserID = "";
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
                //UserID = new SYS_USERController().SYS_USER_Get_By_UserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim()).UserID;

            }
            fs.Close();
        }
        private void cbochon_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ThoiGianController thoigian = new ThoiGianController();
            string format = "MM/dd/yyyy";
            switch (cbochon.Text)
            {
                case "Hôm nay":
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
                case "Tuần này":
                    break;
                case "Tháng này":
                    dateTu.DateTime = DateTime.ParseExact(String.Format("{0:00}", DateTime.Now.Month) + "/" + String.Format("{0:00}", thoigian.Startdayofmonth(DateTime.Now.Month, DateTime.Now.Year)) + "/" + String.Format("{0:00}", DateTime.Now.Year), format, null);
                    dateDen.DateTime = DateTime.ParseExact(String.Format("{0:00}", DateTime.Now.Month) + "/" + String.Format("{0:00}", thoigian.Enddayofmonth((int)DateTime.Now.Month, (int)DateTime.Now.Year)) + "/" + String.Format("{0:00}", DateTime.Now.Year), format, null);
                    //dateDen.DateTime = DateTime.ParseExact("01" + "/" + "01" + "/" + DateTime.Now.Year.ToString(), format, null);

                    break;
                case "Quý này":
                    dateTu.DateTime = thoigian.StartDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(thoigian.Qui_Num(DateTime.Now.Month), DateTime.Now.Year);
                    break;
                case "Năm nay":
                    dateTu.DateTime = DateTime.ParseExact("01/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 1":
                    dateTu.DateTime = DateTime.ParseExact("01/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("01/" + thoigian.Enddayofmonth(1, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 2":
                    dateTu.DateTime = DateTime.ParseExact("02/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("02/" + thoigian.Enddayofmonth(2, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 3":
                    dateTu.DateTime = DateTime.ParseExact("03/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("03/" + thoigian.Enddayofmonth(3, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 4":
                    dateTu.DateTime = DateTime.ParseExact("04/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("04/" + thoigian.Enddayofmonth(4, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 5":
                    dateTu.DateTime = DateTime.ParseExact("05/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("05/" + thoigian.Enddayofmonth(5, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 6":
                    dateTu.DateTime = DateTime.Parse("06/01/" + DateTime.Now.Year);
                    dateDen.DateTime = DateTime.Parse("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString());
                    break;
                case "Tháng 7":
                    dateTu.DateTime = DateTime.ParseExact("07/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("07/" + thoigian.Enddayofmonth(7, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 8":
                    dateTu.DateTime = DateTime.ParseExact("08/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("08/" + thoigian.Enddayofmonth(8, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 9":
                    dateTu.DateTime = DateTime.ParseExact("09/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("09/" + thoigian.Enddayofmonth(9, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 10":
                    dateTu.DateTime = DateTime.ParseExact("10/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("10/" + thoigian.Enddayofmonth(10, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 11":
                    dateTu.DateTime = DateTime.ParseExact("11/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("11/" + thoigian.Enddayofmonth(11, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Tháng 12":
                    dateTu.DateTime = DateTime.ParseExact("12/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("12/" + thoigian.Enddayofmonth(12, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
                    break;
                case "Quý 1":
                    dateTu.DateTime = thoigian.StartDayofQui(1, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(1, DateTime.Now.Year);
                    break;
                case "Quý 2":
                    dateTu.DateTime = thoigian.StartDayofQui(2, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(2, DateTime.Now.Year);
                    break;
                case "Quý 3":
                    dateTu.DateTime = thoigian.StartDayofQui(3, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(3, DateTime.Now.Year);
                    break;
                case "Quý 4":
                    dateTu.DateTime = thoigian.StartDayofQui(4, DateTime.Now.Year);
                    dateDen.DateTime = thoigian.EndDayofQui(4, DateTime.Now.Year);
                    break;
                default:
                    dateTu.DateTime = DateTime.Now;
                    dateDen.DateTime = DateTime.Now;
                    break;
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


        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Lệnh Xuất Hàng này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                    new ProductionOrderDetailRepository().DeleteProductionOrderDetailByID((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString()));
                    string objerror = new ProductionOrderRepository().DeleteProductionOrderByID(id);
                    if (objerror != "")
                    {
                        XtraMessageBox.Show("Xóa khai báo thành công !", "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa khai báo " + objerror + "", "Thông Báo");
                    }
                    gridControl1.DataSource = new ProductionOrderRepository().GetAll();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new ProductionOrderRepository().GetAll();

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if ((new DOCUMENTController().DOCUMENT_GetExist(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString())) != "")
            //{
            //    if (gridView1.FocusedRowHandle >= 0)
            //    {
            //        DOCUMENT objdocument = new DOCUMENT();
            //        objdocument = new DOCUMENTController().DOCUMENT_Get(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString());
            //        mainform.CapNhatLenhXuatHang(objdocument);
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("Phiếu này không tồn tại!", "Thông Báo");
            //    gridControl1.DataSource = new DOCUMENTController().DOCUMENT_GetList_ByDate(dateTu.DateTime, dateDen.DateTime);

            //}
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                frmMaHoaDuLieu frm = new frmMaHoaDuLieu(id);
                frm.ShowDialog();
            }
        }
        public ProductOrderView SyncProductOrder(string Code)
        {
            ProductionOrder objProducttion = new ProductionOrder();
            ProductOrderView objview = new ProductOrderView();
            objview.code = "";
            objProducttion = new ProductionOrderRepository().GetByCode(Code);
            if (objProducttion.Code != null)
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
        public ProductOrderDetailView SyncProductOrderDetail(string Code)
        {
            ProductionOrderDetail objProducttion = new ProductionOrderDetail();
            ProductOrderDetailView objview = new ProductOrderDetailView();
            objview.code = "";
            objProducttion = new ProductionOrderDetailRepository().GetByCode(Code);
            if (objProducttion.Code != null)
            {
                objview.code = objProducttion.Code;
                objview.ProductionOrderCode = objProducttion.ProductionOrderCode;
                objview.ProductCode = objProducttion.ProductCode;
                objview.productName = objProducttion.ProductName;
                objview.numberTemp = (int)(objProducttion.NumberTemp);
                objview.lineId = "";
                objview.lotNumber = objProducttion.LotNumber;
                objview.batchNumber = objProducttion.BatchNumber;
                objview.unitId = objProducttion.UnitCode;
                objview.quantity = (int)objProducttion.Quantity;
                objview.note1 = objProducttion.Note1;
                objview.note2 = objProducttion.Note2;
                objview.note3 = objProducttion.Note3;
                objview.creatorId = objProducttion.CreatorId;
                objview.creationTime = objProducttion.CreationTime;
                objview.lastModifierId = objProducttion.LastModifierId;
                objview.lastModificationTime = objProducttion.LastModificationTime;
                objview.active = objProducttion.Active;

            }
            return objview;
        }
        private void barButtonItem6_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                WaitDialog.CreateWaitDialog("Đồng bộ " + " lệnh sản xuất lên Cloud ...", "Thông Báo");
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                SyncDataFunction objSync = new SyncDataFunction();
                ProductOrderView objview = SyncProductOrder(id);
                List<ProductOrderView> list = new List<ProductOrderView>();
                list.Add(objview);
                var json = JsonConvert.SerializeObject(list);
                string Data = objSync.CallAPIPOSTToken("http://tenant1.api.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = objSync.CallAPIPost("http://tenant1.api.vmspms.vn/api/production-order-desktop", objToken.access_token, json);
                StatusResponse objrp = objSync.JSONParserResponse(ds);
                if (objrp.idStatus == 1)
                {
                    //XtraMessageBox.Show(objrp.description, "Thông Báo");
                    ProductOrderDetailView objdetailview = SyncProductOrderDetail(id);
                    List<ProductOrderDetailView> listdetail = new List<ProductOrderDetailView>();
                    listdetail.Add(objdetailview);
                    var jsondetail = JsonConvert.SerializeObject(listdetail);
                    string dsdetail = objSync.CallAPIPost("http://tenant1.api.vmspms.vn/api/production-order-detail-desktop", objToken.access_token, jsondetail);
                    StatusResponse objrpdetail = objSync.JSONParserResponse(dsdetail);
                    if (objrpdetail.idStatus == 1)
                    {
                        XtraMessageBox.Show(objrpdetail.description, "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show(objrpdetail.description, "Thông Báo");
                    }
                }
                else
                {
                    XtraMessageBox.Show(objrp.description, "Thông Báo");
                }
                WaitDialog.CloseWaitDialog();


            }
        }

        private void barButtonItem7_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmChonTrangThai frm = new frmChonTrangThai();
            frm.ShowDialog();
            string Trave = frm.CodeTT;
            if (Trave != "")
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                ProductionOrder objProducttion = new ProductionOrderRepository().GetByCode(id);
                objProducttion.Status = int.Parse(Trave);
                ProductionOrder objRS = new ProductionOrderRepository().Update(objProducttion);
                if(objRS.Code != null)
                {
                    XtraMessageBox.Show("Cập nhật thành công !", "Thông Báo");
                }
                gridControl1.DataSource = new ProductionOrderRepository().GetAll();

            }
        }
    }
}
