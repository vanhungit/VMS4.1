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
    public partial class frmDMCongDoan : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        public frmDMCongDoan(Main frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            gridControl1.DataSource = new StageRepository().GetAll();

        }


        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new StageRepository().GetAll();
        }

       

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemCongDoan frm = new frmThemCongDoan();
            frm.ShowDialog();
            //frmThemPlant frm = new frmThemPlant();
            //frm.ShowDialog();
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa chi nhánh này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    Guid id = Guid.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                    
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
                frmCapNhatCongDoan frm = new frmCapNhatCongDoan(id);
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