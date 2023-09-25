using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;


namespace VMSCore.WindowsForms
{
    public partial class frmMapTBChaCon_ChonCon : Form
    {
        frmMapTBChaCon frmMapToRFID;
        public frmMapTBChaCon_ChonCon(frmMapTBChaCon frm)
        {
            InitializeComponent();
            frmMapToRFID = frm;
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            gridControl1.DataSource = new DeviceRepository().GetAllByCondition(x => x.Active == true);
            //InitLookUp_KhoHang();
            //HienThiChiNhanh();
        }
        //private void InitLookUp_KhoHang()
        //{
        //    GridLookUpNhom.DataSource = new GROUP_ASSETEntity().GetListGROUP_ASSET();
        //    // Specify the data source to display in the dropdown.
        //    // The field providing the editor's display text.
        //    GridLookUpNhom.DisplayMember = "NameGroup";
        //    // The field matching the edit value.
        //    GridLookUpNhom.ValueMember = "KeyID";
        //    GridLookUpNhom.BestFitMode = BestFitMode.BestFitResizePopup;

        //    // Enable auto completion search mode.
        //    // Specify the column against which to perform the search.
        //}
        //public void HienThiChiNhanh()
        //{
        //    GridLookUpCN.DataSource = new PLANTEntity().GetListPLANT();
        //    GridLookUpCN.DisplayMember = "NamePlant";
        //    GridLookUpCN.ValueMember = "KeyID";
        //    GridLookUpCN.BestFitMode = BestFitMode.BestFitResizePopup;
        //    //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        //}

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

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                string id = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString());
                Device obj = new DeviceRepository().GetByCode(id);
                frmMapToRFID.LoadData(obj);
                Close();
            }
        }
    }
}
