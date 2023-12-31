using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmDMBoPhan : DevExpress.XtraEditors.XtraForm
    {
        public frmDMBoPhan()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new DepartmentRepository().GetAll();

            //gridControl1.DataSource = new DEPARTMENTController().LayDSDEPARTMENT_GROUP();

        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new DepartmentRepository().GetAll();

        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
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

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn Muốn Xóa Phòng Ban Này?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {

                if (gridView1.RowCount > 0)
                {
                    string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                    string objerror = new DepartmentRepository().DeleteErrorConfigByID(id);
                    if (objerror != "")
                    {
                        XtraMessageBox.Show("Xóa khai báo thành công !", "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa khai báo " + objerror + "", "Thông Báo");
                    }
                    gridControl1.DataSource = new DepartmentRepository().GetAll();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");

            }
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemBoPhan frm = new frmThemBoPhan();
            frm.ShowDialog();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                frmCapNhatBoPhan frm = new frmCapNhatBoPhan(id);
                frm.ShowDialog();
            }
        }
    }
}