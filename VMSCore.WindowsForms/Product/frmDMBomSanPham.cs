using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmDMBomSanPham : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        Product objProduct = new Product();
        public frmDMBomSanPham(string ProductCode)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            objProduct = new ProductRepository().GetOneByCondition(x => x.Code == ProductCode);
            gridControl1.DataSource = new MaterialProductRepository().GetViewBomByProduct(ProductCode);

        }


        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new MaterialProductRepository().GetViewBomByProduct(objProduct.Code);
        }



        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            {
                string id = objProduct.Code;
                frmThemBomSP frm = new frmThemBomSP(id);
                frm.ShowDialog();
            }
           
            //frmThemPlant frm = new frmThemPlant();
            //frm.ShowDialog();
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa nhóm này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                    string objerror = new MaterialProductRepository().DeleteUNITCONVERTeByID(id);
                    if (objerror != "")
                    {
                        XtraMessageBox.Show("Xóa thành công !", "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa " + objerror + " thất bại", "Thông Báo");
                    }
                    gridControl1.DataSource = new MaterialProductRepository().GetViewBomByProduct(objProduct.Code);
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
                frmCapNhatBomSP frm = new frmCapNhatBomSP(id);
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