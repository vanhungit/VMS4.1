using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmDMNhaMay : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        public frmDMNhaMay(Main frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            gridControl1.DataSource = new FactoryRepository().GetAll();

        }


        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new FactoryRepository().GetAll();
        }

       

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemNhaMay frm = new frmThemNhaMay();
            frm.ShowDialog();
            //frmThemPlant frm = new frmThemPlant();
            //frm.ShowDialog();
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa nhà máy này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                    string objerror = new FactoryRepository().DeletePlantByID(id);
                    if (objerror != "")
                    {
                        XtraMessageBox.Show("Xóa nhà máy thành công !", "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa nhà máy " + objerror + "", "Thông Báo");
                    }
                    gridControl1.DataSource = new FactoryRepository().GetAll();
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
                frmCapNhatNhaMay frm = new frmCapNhatNhaMay(id);
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

        private void barLargeButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmImportPlant frm = new frmImportPlant();
            //frm.ShowDialog();
        }
    }
}