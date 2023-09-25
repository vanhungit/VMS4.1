using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using System.IO;

using DevExpress.XtraEditors.Controls;

using DevExpress.XtraEditors;
using System.Data.OleDb;
using DevExpress.XtraPrinting;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.EntityModels;

namespace VMSCore.WindowsForms
{
    public partial class UC_LapLenhSanXuat : UserControl
    {
        //DOCUMENT objinbound = new DOCUMENT();
        //DOCUMENT_DETAIL objinbound_detail = new DOCUMENT_DETAIL();
        DataTable dtable = new DataTable();
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        frmLenhSanXuat main_form;
        int GlobalRowSelect = 0;
        //SYS_LOG _sys_log = new SYS_LOG();
        //SYS_USER objuser = new SYS_USER();
        string FileName = "";
        int Flag = 0;
        ProductionOrder objinbound = new ProductionOrder();
        ProductionOrderDetail objinbound_detail = new ProductionOrderDetail();

        public UC_LapLenhSanXuat(frmLenhSanXuat frm)
        {
            InitializeComponent();
            ReadXml_User();
            objinbound.Id = Guid.NewGuid();
            InitLookUpLine();
            //InitLookUp_NhanVien();
            //InitLookUpKhoHang();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            dateBatDau.DateTime = DateTime.Now;
            dateKetThuc.DateTime = DateTime.Now;
            dateRelease.DateTime = DateTime.Now;
            lookUpTenNV.Properties.DataSource = new StaffRepository().GetAll();
            lookUpTenNV.Properties.DisplayMember = "Name";
            lookUpTenNV.Properties.ValueMember = "Code";
            lookUpTenNV.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            gridLookUpEdit2View.Invalidate();
            gridLookUpEdit2View.IndicatorWidth = 35;
            txtLenhSX.Text = CreatePhieuBanHang();
            dtable.Columns.Add("ProductId", typeof(string));
            dtable.Columns.Add("ProductName", typeof(string));
            dtable.Columns.Add("LotNumber", typeof(string));
            dtable.Columns.Add("BatchNumber", typeof(string));
            dtable.Columns.Add("LineId", typeof(string));
            dtable.Columns.Add("NumberTemp", typeof(string));
            dtable.Columns.Add("Unit", typeof(string));
            dtable.Columns.Add("Quantity", typeof(double));
            dtable.Columns.Add("Note1", typeof(string));
            dtable.Columns.Add("Id", typeof(string));//them vao

            //repositoryItemGridLookUpEdit1.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            //repositoryItemGridLookUpEdit1.DisplayMember = "Product_ID";
            //repositoryItemGridLookUpEdit1.ValueMember = "Product_ID";
            //repositoryItemGridLookUpEdit1.BestFitMode = BestFitMode.BestFitResizePopup;

            //repositoryItemLookUpEdit2.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            ////repositoryItemLookUpEdit2.Properties.DisplayMember = "ProductName";
            //// The field matching the edit value.
            //repositoryItemLookUpEdit2.Properties.ValueMember = "Product_Name";
            //repositoryItemLookUpEdit2.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            //repositoryItemLookUpEdit2.Properties.SearchMode = SearchMode.AutoComplete;
            //// Specify the column against which to perform the search.
            //repositoryItemLookUpEdit2.Properties.AutoSearchColumnIndex = 1;
            //gridLookUpEdit1.Properties.DataSource = new PRODUCTController().PRODUCT_GetLookupByStock_SALE();
            //gridLookUpEdit1.Properties.DisplayMember = "Product_Name";
            //gridLookUpEdit1.Properties.ValueMember = "Product_ID";
            //gridLookUpEdit1.Properties.BestFitMode = BestFitMode.None;

            //repositoryItemLookUpEdit4.Properties.DataSource = new UNITController().UNIT_GetList();
            //repositoryItemLookUpEdit4.Properties.DisplayMember = "Unit_Name";
            //// The field matching the edit value.
            //repositoryItemLookUpEdit4.Properties.ValueMember = "Unit_ID";
            //repositoryItemLookUpEdit4.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            //// Enable auto completion search mode.
            //repositoryItemLookUpEdit4.Properties.SearchMode = SearchMode.AutoComplete;
            //// Specify the column against which to perform the search.
            //repositoryItemLookUpEdit4.Properties.AutoSearchColumnIndex = 1;
            gridControl1.DataSource = dtable;
            gridView2.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(repositoryItemGridLookUpEdit1View_click);
            main_form = frm;
            Flag = 0;
            #region Load Phân Quyền
            //bbiImport.Enabled = new SYS_USER_RULEController().SYS_USER_RULE_GetbyUserID(objuser.UserID, "bbiSale").AllowAdd;
            //bbiAdd.Enabled = new SYS_USER_RULEController().SYS_USER_RULE_GetbyUserID(objuser.UserID, "bbiSale").AllowAdd;
            //bbiDelete.Enabled = new SYS_USER_RULEController().SYS_USER_RULE_GetbyUserID(objuser.UserID, "bbiSale").AllowDelete;
            //bbiPrint.Enabled = new SYS_USER_RULEController().SYS_USER_RULE_GetbyUserID(objuser.UserID, "bbiSale").AllowPrint;
            //bbiSave.Enabled = new SYS_USER_RULEController().SYS_USER_RULE_GetbyUserID(objuser.UserID, "bbiSale").AllowAccess;
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
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = _staffRepository.GetStaffByUserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }

        public bool CheckProduct(string MaHang, string Khuvuc, string Kho, double SoLuong)
        {
            bool Trave = false;
            foreach (DataRow datarow in dtable.Rows)
            {
                if ((MaHang == datarow["Product_ID"].ToString()) && (Kho == datarow["Stock_ID"].ToString()) && (Khuvuc == datarow["Section_ID"].ToString()) && (SoLuong == double.Parse(datarow["Quantity"].ToString())))
                {
                    Trave = true;
                    break;
                }
            }
            return Trave;
        }
        public bool CheckProduct(string MaHang, string Khuvuc, string Kho, double SoLuong, string Line)
        {
            bool Trave = false;
            foreach (DataRow datarow in dtable.Rows)
            {
                if ((MaHang == datarow["Product_ID"].ToString()) && (Kho == datarow["Stock_ID"].ToString()) && (Khuvuc == datarow["Section_ID"].ToString()) && (Line == datarow["Location"].ToString()) && (SoLuong == double.Parse(datarow["Quantity"].ToString())))
                {
                    Trave = true;
                    break;
                }
            }
            return Trave;
        }
        public bool CheckProduct(string MaHang, string Khuvuc, string Kho, double SoLuong, string Line, string Ca)
        {
            bool Trave = false;
            foreach (DataRow datarow in dtable.Rows)
            {
                if ((MaHang == datarow["Product_ID"].ToString()) && (Kho == datarow["Stock_ID"].ToString()) && (Khuvuc == datarow["Section_ID"].ToString()) && (Line == datarow["Location"].ToString()) && (SoLuong == double.Parse(datarow["Quantity"].ToString())) && (Ca == (datarow["Description"].ToString().Trim())))
                {
                    Trave = true;
                    break;
                }
            }
            return Trave;
        }
        public int IndexofTable(int STT, DataTable table)
        {
            int Trave = -1;
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                if (int.Parse(dtable.Rows[i]["Sorted"].ToString().Trim()) == STT)
                {
                    Trave = i;
                    break;
                }
            }
            return Trave;
        }
        public void LoadExcel()
        {
            //String ConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + txtPathName.Text.Trim() + ";" + "Extended Properties=Excel 8.0;";
            string ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;"; //Create Connection to Excel work book
            OleDbConnection ObjConnection = new OleDbConnection(ConString);
            ObjConnection.Open();
            OleDbCommand objCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", ObjConnection);
            OleDbDataAdapter MyAdapt = new OleDbDataAdapter();
            MyAdapt.SelectCommand = objCommand;
            DataSet ds = new DataSet();
            MyAdapt.Fill(ds, "[Sheet1$]");
            ObjConnection.Close();
            DataTable dt_Table = ds.Tables["[Sheet1$]"];
            ObjConnection.Close();
            foreach (DataRow datarow in dt_Table.Rows)
            {
                DataRow dr1 = dtable.NewRow();
                dr1["ProductId"] = datarow["ProductID"].ToString().Trim();
                dr1["ProductName"] = datarow["ProductName"].ToString().Trim();
                dr1["LotNumber"] = datarow["Lot"].ToString().Trim();
                dr1["BatchNumber"] = datarow["Batch"].ToString().Trim();
                dr1["LineId"] = "";
                dr1["NumberTemp"] = "0";
                dr1["Unit"] = datarow["Unit"].ToString().Trim();//Loại sản phẩm
                dr1["Quantity"] = (int)double.Parse(datarow["Quantity"].ToString().Trim());//Thùng
                dr1["Note1"] = "";
                dr1["Id"] = "";
                dtable.Rows.Add(dr1);
            }
        }
        private void InitLookUpLine()
        {
            lookUpLine.Properties.DataSource = new LineRepository().GetAll();
            // Specify the data source to display in the dropdown.
            // The field providing the editor's display text.
            lookUpLine.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookUpLine.Properties.ValueMember = "Code";
            lookUpLine.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpLine.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpLine.Properties.AutoSearchColumnIndex = 1;
        }
        //private void InitLookUp()
        //{
        //    // Specify the data source to display in the dropdown.
        //    lookupkhuvuc.Properties.DataSource = new CUSTOMER_GROUPController().LayDSCUSTOMER_GROUP();
        //    // The field providing the editor's display text.
        //    lookupkhuvuc.Properties.DisplayMember = "Customer_Group_Name";
        //    // The field matching the edit value.
        //    lookupkhuvuc.Properties.ValueMember = "Customer_Group_ID";
        //    lookupkhuvuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

        //    // Enable auto completion search mode.
        //    lookupkhuvuc.Properties.SearchMode = SearchMode.AutoComplete;
        //    // Specify the column against which to perform the search.
        //    lookupkhuvuc.Properties.AutoSearchColumnIndex = 1;
        //    lookupkhuvuc.EditValue = new CUSTOMER_GROUPController().CUSTOMER_GROUP_Top1().Customer_Group_ID;

        //}
        private void InitLookUp_NhanVien()
        {
            lookUpTenNV.Properties.DataSource = new StaffRepository().GetAll();
            // The field providing the editor's display text.
            lookUpTenNV.Properties.DisplayMember = "Customer_Group_Name";
            // The field matching the edit value.
            lookUpTenNV.Properties.ValueMember = "Customer_Group_ID";
            lookUpTenNV.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
        }
        private void InitLookUpKhoHang()
        {
            
        }
        
        public string CreatePhieuBanHang()
        {
            string PhieuBanHang="", Temp_BH, Number_PC;
            int Number = new ProductionOrderRepository().GetMaxProductionOrder() + 1;
            PhieuBanHang = "LSX" + Number.ToString().PadLeft(7, '0') ;
            ////PhieuBanHang = "IB_" + objuser.UserName + "_000001";//Trả về số phiếu thu
            //Temp_BH = "";//Số phiếu tạm
            //Number_PC = "";// Number phiếu thu
            //string _stockout_PC = new DOCUMENTController().DOCUMENT_Max();
            //Temp_BH = _stockout_PC;
            //Number_PC = _stockout_PC;
            //if (Temp_BH != "")
            //{
            //    PhieuBanHang = Number_PC;
            //    for (int i = 0; i < 10 - Number_PC.Length; i++)
            //    {
            //        PhieuBanHang = "0" + PhieuBanHang;
            //    }
            //}
            return PhieuBanHang;
        }
        private void gridLookUpEdit2View_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }

        }

        private void lookUpTenNV_EditValueChanged(object sender, EventArgs e)
        {
            txtMaNV.Text = (lookUpTenNV.Properties.GetKeyValue(gridLookUpEdit2View.FocusedRowHandle).ToString());
        }

        
      
        public void repositoryItemGridLookUpEdit1View_click(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //XtraMessageBox.Show("ok");
            GlobalRowSelect = (e.RowHandle);
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
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

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (MessageBox.Show("Bạn muốn lưu lại dữ liệu (Xác định ngày áp dụng lệnh sản xuất) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (txtMaNV.Text != "")
                {
                    {
                        if (lookUpLine.Text != "")
                        {
                            if (gridView1.RowCount > 1)
                            {
                                int rsstock = -1;
                                //if (Flag == 0)
                                //{
                                //    txtLenhSX.Text = CreatePhieuBanHang();
                                //}
                                objinbound.Code = txtLenhSX.Text;
                                objinbound.FromDate = dateBatDau.DateTime;
                                objinbound.ToDate = dateKetThuc.DateTime;
                                objinbound.Status = 0;
                                objinbound.ParentId = "";
                                objinbound.LineCode = (lookUpLine.GetColumnValue("Code").ToString());
                                objinbound.OrderString = "";
                                objinbound.StaffCode = txtMaNV.Text.Trim();
                                objinbound.ManufactureDate = dateNSX.DateTime;
                                objinbound.ExpireDate = dateHSX.DateTime;
                                objinbound.LinkWeb = memoGhiChu.Text;
                                objinbound.NumberTemp = 0;
                                objinbound.Reason = "Lệnh Sản Xuất";
                                objinbound.CreatorId = objuser.Username;
                                objinbound.LastModifierId = objuser.Username;
                                objinbound.CreationTime = DateTime.Now;
                                objinbound.LastModificationTime = DateTime.Now;
                                objinbound.Sorted = new ProductionOrderRepository().GetMaxProductionOrder() + 1;
                                objinbound.Active = true;
                                objinbound_detail.Code = txtLenhSX.Text;
                                objinbound_detail.RefType = 1;
                                {
                                    if(new ProductionOrderRepository().GetByCode(txtLenhSX.Text).Code != "")
                                    {
                                        new ProductionOrderRepository().Update(objinbound);
                                        rsstock = 1;
                                    }
                                    else
                                    {
                                        new ProductionOrderRepository().Add(objinbound);
                                        rsstock = 1;
                                    }
                                    for (int i = 0; i < gridView1.RowCount - 1; i++)
                                    {
                                        if (gridView1.GetRowCellValue(i, gridView1.Columns["Id"]).ToString() != "")
                                        {
                                            objinbound_detail = new ProductionOrderDetailRepository().GetById(new Guid(gridView1.GetRowCellValue(i, gridView1.Columns["Id"]).ToString()));
                                            objinbound_detail.ProductCode = gridView1.GetRowCellValue(i, gridView1.Columns["ProductId"]).ToString().Trim();
                                            objinbound_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns["ProductName"]).ToString().Trim();
                                            objinbound_detail.LotNumber = gridView1.GetRowCellValue(i, gridView1.Columns["LotNumber"]).ToString().Trim();
                                            objinbound_detail.BatchNumber = gridView1.GetRowCellValue(i, gridView1.Columns["BatchNumber"]).ToString().Trim();
                                            objinbound_detail.UnitCode = gridView1.GetRowCellValue(i, gridView1.Columns["Unit"]).ToString().Trim();
                                            objinbound_detail.Quantity = int.Parse(gridView1.GetRowCellValue(i, gridView1.Columns["Quantity"]).ToString());
                                            objinbound_detail.NumberTemp = objinbound_detail.Quantity;
                                            objinbound_detail.LastModificationTime = DateTime.Now;
                                            objinbound_detail.LastModifierId = objuser.Username;
                                            objinbound_detail.Active = true;
                                            ProductionOrderDetail rsstockdetail = new ProductionOrderDetailRepository().Update(objinbound_detail);
                                            if (rsstockdetail.Code == "")
                                            {
                                                XtraMessageBox.Show("Lưu Thất Bại Update", "Thông Báo");
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            objinbound_detail.Id = Guid.NewGuid();
                                            objinbound_detail.RefType = 1;
                                            objinbound_detail.ProductionOrderCode = objinbound.Code;
                                            objinbound_detail.Code = objinbound_detail.Id.ToString().Trim();
                                            objinbound_detail.ProductCode = gridView1.GetRowCellValue(i, gridView1.Columns["ProductId"]).ToString().Trim();
                                            objinbound_detail.ProductName = gridView1.GetRowCellValue(i, gridView1.Columns["ProductName"]).ToString().Trim();
                                            objinbound_detail.LotNumber = gridView1.GetRowCellValue(i, gridView1.Columns["LotNumber"]).ToString().Trim();
                                            objinbound_detail.BatchNumber = gridView1.GetRowCellValue(i, gridView1.Columns["BatchNumber"]).ToString().Trim();
                                            objinbound_detail.UnitCode = gridView1.GetRowCellValue(i, gridView1.Columns["Unit"]).ToString().Trim();
                                            objinbound_detail.Quantity = int.Parse(gridView1.GetRowCellValue(i, gridView1.Columns["Quantity"]).ToString());
                                            objinbound_detail.NumberTemp = objinbound_detail.Quantity;
                                            objinbound_detail.CreationTime = DateTime.Now;
                                            objinbound_detail.CreatorId = objuser.Username;
                                            objinbound_detail.LastModificationTime = DateTime.Now;
                                            objinbound_detail.LastModifierId = objuser.Username;
                                            objinbound_detail.Active = true;
                                            ProductionOrderDetail rsstockdetail = new ProductionOrderDetailRepository().Add(objinbound_detail);
                                            if (rsstockdetail.Code == "")
                                            {
                                                XtraMessageBox.Show("Lưu Thất Bại Update", "Thông Báo");
                                                break;
                                            }
                                        }
                                    }
                                    //_sys_log.MChine = new MobilityNetwork().GetComputerName();
                                    //_sys_log.IP = new MobilityNetwork().GetIP();
                                    //_sys_log.UserID = objuser.UserID;
                                    //_sys_log.Created = DateTime.Now;
                                    //_sys_log.Action_Name = "Thêm";
                                    //_sys_log.Description = "Thêm Lệnh Sản Xuất" + "-" + txtLenhSX.Text;
                                    //_sys_log.Reference = txtLenhSX.Text;
                                    //_sys_log.Module = "Lệnh Sản Xuất";
                                    //_sys_log.Active = true;
                                    //SYS_LOGController insertlog = new SYS_LOGController();
                                    //insertlog.SYS_LOG_Insert(_sys_log);

                                }
                                if (rsstock > -1)
                                {
                                    XtraMessageBox.Show("Lưu Thành công", "Thông Báo");
                                    txtLenhSX.Text = CreatePhieuBanHang();
                                    //InitLookUpMaKH();
                                    InitLookUp_NhanVien();
                                    ReadXml_User();
                                    InitLookUpKhoHang();
                                    dtable.Rows.Clear();
                                }
                                else
                                {
                                    XtraMessageBox.Show("Lưu dữ liệu thất bại !", "Thông Báo");

                                }
                            }
                            else
                                XtraMessageBox.Show("Chưa nhập hàng hóa", "Thông Báo");
                        }
                        else
                        {
                            XtraMessageBox.Show("Vui lòng chọn line thực hiện !", "Thông Báo");
                            lookUpLine.Focus();
                            lookUpLine.ShowPopup();
                        }
                    }
                  
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên lập phiếu !", "Thông Báo");
                    lookUpTenNV.Focus();
                    lookUpTenNV.ShowPopup();
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openFileDialog.ShowDialog();
            FileName = openFileDialog.FileName;
            if (FileName != "")
            {
                //MessageBox.Show("Tiếp tục xử lý !", "Thông Báo");
                try
                {
                    LoadExcel();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lại file !", "Thông Báo");
            }
        }

       
        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa dữ liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[14]).ToString() != "")
                //{
                //    (new DOCUMENT_DETAILController()).DOCUMENT_DETAIL_Delete(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[14]).ToString());
                //}
                gridView1.DeleteRow(gridView1.FocusedRowHandle);

            }

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            main_form.Close();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtLenhSX.Text = CreatePhieuBanHang();
            InitLookUp_NhanVien();
            ReadXml_User();
            InitLookUpKhoHang();
            dtable.Rows.Clear();
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //printingSystem1.Begin();
            //printableComponentLink1.ShowPreview();
           
        }

    }
}
