using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Xml;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmDMNhanVien : DevExpress.XtraEditors.XtraForm
    {
        string configFile = @"XMLTimer.xml";
        string NgonNgu = "";
        public frmDMNhanVien()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            //gridControl1.DataSource = new EMPLOYEEController().LayDSNhanVien();
     
            NgonNgu = XMLParser(configFile, "Table/Language");
            //if (NgonNgu == "EN")
            //{
            //    this.Text = "Employee";
            //    bbiAdd.Caption = "Add";
            //    bbiEdit.Caption = "Repair";
            //    bbiDelete.Caption = "Delete";
            //    bbiRefresh.Caption = "Reload";
            //    bbiExport.Caption = "Export";
            //    bbiPrint.Caption = "Print";
            //    bbiClose.Caption = "Close";
            //    gridView1.Columns["Employee_ID"].Caption = "Employee ID";
            //    gridView1.Columns["Employee_Name"].Caption = "Employee Name";
            //    gridView1.Columns["Address"].Caption = "Address";
            //    gridView1.Columns["O_Tel"].Caption = "Phone";
            //    gridView1.Columns["H_Tel"].Caption = "Mobile";
            //    gridView1.Columns["Email"].Caption = "Email";
            //    gridView1.Columns["Description"].Caption = "Description";

            //}
            //else
            //{
            //    this.Text = "Danh mục nhân viên";
            //    bbiAdd.Caption = "Thêm";
            //    bbiEdit.Caption = "Sửa chữa";
            //    bbiDelete.Caption = "Xóa";
            //    bbiRefresh.Caption = "Nạp lại";
            //    bbiExport.Caption = "Xuất";
            //    bbiPrint.Caption = "In";
            //    bbiClose.Caption = "Đóng";
            //    gridView1.Columns["Employee_ID"].Caption = "Mã nhân viên";
            //    gridView1.Columns["Employee_Name"].Caption = "Tên nhân viên";
            //    gridView1.Columns["Address"].Caption = "Địa chỉ";
            //    gridView1.Columns["O_Tel"].Caption = "Điện thoại";
            //    gridView1.Columns["H_Tel"].Caption = "Di động";
            //    gridView1.Columns["Email"].Caption = "Email";
            //    gridView1.Columns["Description"].Caption = "Ghi chú";

            //}
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

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new StaffRepository().GetAll();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Nhân Viên Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    int rs = -1;
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                    //rs = new EMPLOYEEController().XoaNhanVien(id);
                    //if (rs < 1)
                    //{
                    //    MessageBox.Show("Nhân viên không được xóa", "Thông báo");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Nhân viên đã được xóa", "Thông báo");

                    //}
                    //gridControl1.DataSource = new EMPLOYEEController().LayDSNhanVien();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }

        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemNhanVien frm = new frmThemNhanVien();
            frm.ShowDialog();

        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                //EMPLOYEE objemployee = new EMPLOYEE();
                //objemployee = new EMPLOYEEController().LayTenNhanVien(id);
                //frmCapNhatNhanVien frm = new frmCapNhatNhanVien();
                //frm.Load_Data(objemployee);
                //frm.ShowDialog();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                //EMPLOYEE objemployee = new EMPLOYEE();
                //objemployee = new EMPLOYEEController().LayTenNhanVien(id);
                //frmCapNhatNhanVien frm = new frmCapNhatNhanVien();
                //frm.Load_Data(objemployee);
                //frm.ShowDialog();
            }
        }
    }
}