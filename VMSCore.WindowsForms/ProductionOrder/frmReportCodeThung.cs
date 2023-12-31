using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraEditors.Controls;

using SalesManager.Controller;
using DevExpress.XtraPrinting;
using SalesManager;

using DevExpress.XtraReports.UI;
using System.Xml;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SyncData.Implementations;
using System.IO;
using VMSCore.Infrastructure.Features.SyncData;
using Newtonsoft.Json;

namespace VMSCore.WindowsForms
{
    public partial class frmReportCodeThung : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        string NgonNgu = "";
        string configFile = @"XMLTimer.xml";
        bool Chon = false;
        DataTable dtLoai = new DataTable();
        string Pathname = @"G:\Project Company\Du an VMS\Xay Dung Tai Lieu\VMSCoreNet4_VS2019\VMSCoreNet4\VMSCore.WindowsForms\bin\Debug\Resource\CodeBuffer\ANSER_X1";

        public frmReportCodeThung(Main frm)
        {
            InitializeComponent();
            InitLookUpLine();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dateDen.DateTime = DateTime.Now;
            dateTu.DateTime = DateTime.Now;
            Pathname = XMLParser(configFile, "Table/LinkPath");
            //txtLenh.Text = new DOCUMENT_CHECKEntity().DOCUMENTMax().ID;
            NgonNgu = XMLParser(configFile, "Table/Language");

            //if (NgonNgu == "EN")
            //{
            //    this.Text = "Report compensator";
            //    bbiNapLai.Caption = "Reload";
            //    bbiPrint.Caption = "Print";
            //    bbiClose.Caption = "Close";
            //    gridView1.Columns["ProductOrder"].Caption = "Work Order";
            //    gridView1.Columns["LevelDate"].Caption = "Level";
            //    gridView1.Columns["ParentID"].Caption = "Original Command";
            //    gridView1.Columns["OrderString"].Caption = "Command String";
            //    gridView1.Columns["Code1"].Caption = "Code1";
            //    gridView1.Columns["Code2"].Caption = "Code2";
            //    gridView1.Columns["TrangThai"].Caption = "TrangThai";
            //    gridView1.Columns["CreatedDate"].Caption = "Created Date";
            //    gridView1.Columns["CreatedBy"].Caption = "User created";
            //    layoutControlItemFrom.Text = "From";
            //    layoutControlItemTo.Text = "To";
            //    btnXem.Text = "Find";
            //}
            //else
            //{
            //    this.Text = "Báo cáo lệnh bù";
            //    bbiNapLai.Caption = "Nạp Lại";
            //    bbiPrint.Caption = "In";
            //    bbiClose.Caption = "Đóng";
            //    gridView1.Columns["ProductOrder"].Caption = "Lệnh";
            //    gridView1.Columns["LevelDate"].Caption = "Cấp";
            //    gridView1.Columns["ParentID"].Caption = "Lệnh Gốc";
            //    gridView1.Columns["OrderString"].Caption = "Chuỗi lệnh";
            //    gridView1.Columns["Code1"].Caption = "Code1";
            //    gridView1.Columns["Code2"].Caption = "Code2";
            //    gridView1.Columns["TrangThai"].Caption = "TrangThai";
            //    gridView1.Columns["CreatedDate"].Caption = "Ngày tạo";
            //    gridView1.Columns["CreatedBy"].Caption = "User tạo";
            //    layoutControlItemFrom.Text = "Từ";
            //    layoutControlItemTo.Text = "Đến";
            //    btnXem.Text = "Xem";

            //}
        }
        public void LoadDataLoai()
        {
            dtLoai.Columns.Add("ID", typeof(int));
            dtLoai.Columns.Add("Name", typeof(string));
            DataRow row = dtLoai.NewRow();
            row["ID"] = 1;
            row["Name"] = "Đã tích hợp";
            dtLoai.Rows.Add(row);
            DataRow row1 = dtLoai.NewRow();
            row1["ID"] = 2;
            row1["Name"] = "Đã phân bổ";
            dtLoai.Rows.Add(row1);

        }
        private void InitLookUpLine()
        {
            LoadDataLoai();
            lookUpStatus.Properties.DataSource = dtLoai;
            // Specify the data source to display in the dropdown.
            // The field providing the editor's display text.
            lookUpStatus.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookUpStatus.Properties.ValueMember = "ID";
            lookUpStatus.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpStatus.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpStatus.Properties.AutoSearchColumnIndex = 1;
            lookUpStatus.EditValue = 1;
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
        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //main_form.LoadKhuVuc(((DataTable)gridControl1.DataSource).Copy());
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControlLichSu.DataSource = new ProductionOrderDetailCodeRepository().GetAll();
            //gridControlLichSu.DataSource = new BoxDataEntity().ReportBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime);
            //if (lookUpStatus.GetColumnValue("ID").ToString() == "1")
            //{
            //    gridControlLichSu.DataSource = new BoxDataEntity().ReportBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime);
            //}
            //else
            //{
            //    gridView1.Columns["LineDevice"].Visible = true;
            //    gridView1.Columns["TypeDevice"].Visible = true;
            //    gridControlLichSu.DataSource = new BoxDataEntity().PrintBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime, "", "");
            //}
        }

        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridControlLichSu.DataSource = new SyncDataFunction().BOXDEFINE_MAP_GetByDate(dateTu.DateTime, dateDen.DateTime);
            //TimerStart.Enabled = true;
            //if(lookUpStatus.GetColumnValue("ID").ToString() == "1" )
            //{
            //    gridControlLichSu.DataSource = new BoxDataEntity().ReportBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime);
            //}
            //else
            //{
            //    gridView1.Columns["LineDevice"].Visible = true;
            //    gridView1.Columns["TypeDevice"].Visible = true;
            //    gridControlLichSu.DataSource = new BoxDataEntity().PrintBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime,"","");
            //}
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
        public void GhiFile(long SoLuong, long CodeTao, string DuongDan)
        {
            String filepath = "";// đường dẫn của file muốn tạo
            long Bien = 0;
            long CodeNap = 0;
            if (((long)SoLuong) % 1000 > 0)
            {
                Bien = (long)SoLuong / 1000 + 1;
            }
            else
            {
                Bien = (long)SoLuong / 1000;
            }
            if (((long)CodeTao) % 1000 > 0)
            {
                CodeNap = (long)CodeTao / 1000 + 1;
            }
            else
            {
                CodeNap = (long)CodeTao / 1000;
            }
            for (int i = 1; i <= Bien; i++)
            {
                filepath = DuongDan + @"\" + String.Format("{0:0000}", i + CodeNap) + ".ini";
                //filepath = @"D:\Code Nap\" + String.Format("{0:0000}", i + CodeNap) + ".ini";

                FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
                sWriter.WriteLine("[" + 1 + "]");
                for (int j = (i - 1) * 1000; j < i * 1000; j++)
                {
                    if (j < SoLuong)
                    {
                        sWriter.WriteLine((j + (CodeTao) + 1) + "=" + gridView1.GetRowCellValue(j, gridView1.Columns["Code1"]).ToString().Trim());
                    }
                    else
                    {
                        break;
                    }
                }
                sWriter.Flush();
                fs.Close();
            }
            // Ghi và đóng file

        }
        private void barLargeButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Xuất Báo Cáo");
            GhiFile( gridView1.DataRowCount, 0, Pathname);           
            WaitDialog.CloseWaitDialog();
        }
        public List<ProductOrderDetailCodeView> SyncProductOrderCode(int levelcode)
        {
            List<ProductionOrderDetailCode> objProducttion = new List<ProductionOrderDetailCode>();
            ProductOrderDetailCodeView objview = new ProductOrderDetailCodeView();
            List<ProductOrderDetailCodeView> list = new List<ProductOrderDetailCodeView>();
            objview.code = "";
            objProducttion = new ProductionOrderDetailCodeRepository().GetAllByCondition(x => x.LevelPackage == levelcode);
            for (int i = 0; i < objProducttion.Count; i++)
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
        private void barLargeButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                int Level = int.Parse((gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["LevelPackage"]).ToString()));
                SyncDataFunction objSync = new SyncDataFunction();
                List<ProductOrderDetailCodeView> list = SyncProductOrderCode(Level);
                WaitDialog.CreateWaitDialog("Nạp " + list.Count + " code lên Cloud ...", "Thông Báo");

                var json = JsonConvert.SerializeObject(list);
                string Data = objSync.CallAPIPOSTToken("http://tenant1.api.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = objSync.CallAPIPost("http://tenant1.api.vmspms.vn/api/production-order-detail-code-desktop", objToken.access_token, json);
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


        }

        private void cbochon_SelectedIndexChanged_1(object sender, EventArgs e)
        {
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
                    dateTu.DateTime = DateTime.ParseExact("06/01/" + DateTime.Now.Year, format, null);
                    dateDen.DateTime = DateTime.ParseExact("06/" + thoigian.Enddayofmonth(6, DateTime.Now.Year) + "/" + DateTime.Now.Year.ToString(), format, null);
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

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Chon)
            {
                Chon = false;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns[0], Chon);
                }
            }
            else
            {
                Chon = true;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    gridView1.SetRowCellValue(i, gridView1.Columns[0], Chon);
                }
            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhanBoCodeThung frm = new frmPhanBoCodeThung();
            frm.ShowDialog();
            string Trave = frm.MaLine;
            string Loai = frm.MaType;
            string ThietBi = frm.MaThietBi;
            ProductionOrderDetailCode objBox = new ProductionOrderDetailCode();
            if (Trave != "" && ThietBi != "")
            {

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    //if (gridView1.GetRowCellValue(i, gridView1.Columns["Chon"]).ToString().Trim() == "True")
                    {
                        {
                            objBox = new ProductionOrderDetailCodeRepository().GetByCode(gridView1.GetRowCellValue(i, gridView1.Columns["Code"]).ToString().Trim());
                            objBox.LineCode = Trave;
                            objBox.TypeDeviceCode = Loai;
                            objBox.DeviceCode = ThietBi;
                            objBox.DeviceHandeCode = ThietBi;
                            new ProductionOrderDetailCodeRepository().Update(objBox);

                        }

                    }
                }
                //if (lookUpStatus.GetColumnValue("ID").ToString() == "1")
                //{
                //    gridControlLichSu.DataSource = new BoxDataEntity().ReportBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime);
                //}
                //else
                //{
                //    gridView1.Columns["LineDevice"].Visible = true;
                //    gridView1.Columns["TypeDevice"].Visible = true;
                //    gridControlLichSu.DataSource = new BoxDataEntity().PrintBoxData_Getlist_ByDate(dateTu.DateTime, dateDen.DateTime, "", "");
                //}
            }
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xả lock dữ liệu thùng ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductionOrderDetailCode objBox = new ProductionOrderDetailCode();

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    //if (gridView1.GetRowCellValue(i, gridView1.Columns["Chon"]).ToString().Trim() == "True")
                    {
                        {
                            objBox = new ProductionOrderDetailCodeRepository().GetByCode(gridView1.GetRowCellValue(i, gridView1.Columns["Code"]).ToString().Trim());
                            objBox.LineCode = "";
                            objBox.TypeDeviceCode = "";
                            objBox.DeviceCode = "";
                            objBox.DeviceHandeCode = "";
                            new ProductionOrderDetailCodeRepository().Update(objBox);

                        }

                    }
                }
            }
        }

        
    }
}