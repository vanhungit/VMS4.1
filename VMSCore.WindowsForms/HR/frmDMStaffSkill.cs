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
    public partial class frmDMStaffSkill : DevExpress.XtraEditors.XtraForm
    {
        Main main_form;
        Staff objProduct = new Staff();
        public frmDMStaffSkill(string StaffCode)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            objProduct = new StaffRepository().GetOneByCondition(x => x.Code == StaffCode);
            gridControl1.DataSource = new StaffSkillRepository().GetAllByCondition(x => x.StaffCode == StaffCode);

        }


        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = new StaffSkillRepository().GetAll();
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
                    string objerror = new StaffSkillRepository().DeleteStaffSkillByID(id);
                    if (objerror != "")
                    {
                        XtraMessageBox.Show("Xóa thành công !", "Thông Báo");
                    }
                    else
                    {
                        XtraMessageBox.Show("Xóa " + objerror + " thất bại", "Thông Báo");
                    }
                    gridControl1.DataSource = new StaffSkillRepository().GetAll();
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