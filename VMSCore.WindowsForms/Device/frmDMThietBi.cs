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
    public partial class frmDMThietBi : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        public frmDMThietBi(Main frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            gridControl1.DataSource = new DeviceRepository().GetAll();

            //gridControl1.DataSource = new EQUIP_PLANTEntity().GetListEQUIP_PLANT();
            //HienThiChiNhanh();
            //NhomThietBi();

        }
        public void NhomThietBi()
        {
            //GridLookUpNhom.DataSource = new GROUP_ASSETEntity().GetListGROUP_ASSET();
            //GridLookUpNhom.DisplayMember = "NameGroup";
            //GridLookUpNhom.ValueMember = "KeyID";
            //GridLookUpNhom.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        public void HienThiChiNhanh()
        {
            //GridLookUpCN.DataSource = new PLANTEntity().GetListPLANT();
            //GridLookUpCN.DisplayMember = "NamePlant";
            //GridLookUpCN.ValueMember = "KeyID";
            //GridLookUpCN.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }       

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //main_form.LoadKhuVuc(((DataTable)gridControl1.DataSource).Copy());
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new DeviceRepository().GetAll();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemThietBi frm = new frmThemThietBi();
            frm.ShowDialog();
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