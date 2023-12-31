using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;


namespace VMSCore.WindowsForms
{
    public partial class frmDMThietBi_GiaoThuc : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        public frmDMThietBi_GiaoThuc(Main frm)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            main_form = frm;
            //gridControl1.DataSource = new EQUIP_PLANT_PROTOCOLEntity().EQUIP_PLANT_PROTOCOL_GetList();
            //HienThiChiNhanh();
            //NhomThietBi();

        }
        //public void NhomThietBi()
        //{
        //    GridLookUpNhom.DataSource = new GROUP_ASSETEntity().GetListGROUP_ASSET();
        //    GridLookUpNhom.DisplayMember = "NameGroup";
        //    GridLookUpNhom.ValueMember = "KeyID";
        //    GridLookUpNhom.BestFitMode = BestFitMode.BestFitResizePopup;
        //    //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        //}
        //public void HienThiChiNhanh()
        //{
        //    GridLookUpCN.DataSource = new PLANTEntity().GetListPLANT();
        //    GridLookUpCN.DisplayMember = "NamePlant";
        //    GridLookUpCN.ValueMember = "KeyID";
        //    GridLookUpCN.BestFitMode = BestFitMode.BestFitResizePopup;
        //    //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        //}       

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //main_form.LoadKhuVuc(((DataTable)gridControl1.DataSource).Copy());
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gridControl1.DataSource = new EQUIP_PLANT_PROTOCOLEntity().EQUIP_PLANT_PROTOCOL_GetList();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa thiết bị này ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    Guid id = Guid.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["KeyID"]).ToString());
                    //EnumStatus objerror = new EQUIP_PLANT_COMBOEntity().DeleteEQUIP_PLANT_COMBO(id);
                    //if (objerror.IDStatus == 1)
                    //{
                    //    XtraMessageBox.Show("Xóa thiết bị thành công !", "Thông Báo");
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("Xóa thiết bị " + objerror.Description + "", "Thông Báo");
                    //}
                    //gridControl1.DataSource = new EQUIP_PLANT_COMBOEntity().EQUIP_PLANT_COMBO_GetList();
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                //MessageBox.Show(id);
                //CUSTOMER_GROUP objunit = new CUSTOMER_GROUP();
                //objunit = new CUSTOMER_GROUPController().LayTTCUSTOMER_ByID(id);
                //frmCapNhatKhuVuc frm = new frmCapNhatKhuVuc();
                //frm.Load_Data(objunit);
                //frm.ShowDialog();
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
    }
}