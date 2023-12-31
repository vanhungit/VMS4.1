using DevExpress.XtraBars;
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



namespace VMSCore.WindowsForms
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static DataTable DataKhuVuc_Save;
        static DataTable DataNhaPhanPhoi_Save;
        static DataTable DataNhaPhanPhoi_Save_look;
        public Main()
        {
            InitializeComponent();
            ReadXml();
            ReadXml_User();
            barStaticItem2.Caption = String.Format("{0:HH:mm:ss}", DateTime.Now);
            barStaticItem3.Caption = String.Format("{0:dd/MM/yyyy}", DateTime.Now);
            barStaticServer.Caption = System.Environment.MachineName;
            LoadForm(new frmDashboardToTruong());
            //LoadForm(new frmMayCatCuon());
            treeList1.ExpandAll();
        }
        public void LoadKhuVuc(DataTable _table)
        {
            DataKhuVuc_Save = _table;
        }
        public void LoadNhaPhanPhoi(DataTable _table_look, DataTable _table)
        {
            DataNhaPhanPhoi_Save = _table;
            DataNhaPhanPhoi_Save_look = _table_look;
        }
        #region ReadXML
        public void ReadXml()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("Config_Data.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("ConfigCSDL");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "1")
                {
                    barStaticServer.Caption = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    barStaticItemDatabase.Caption = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
                else if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "0")
                {
                    barStaticServer.Caption = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    barStaticItemDatabase.Caption = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            fs.Close();
        }
        #endregion
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    barStaticItem1.Caption = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                }
            }
            fs.Close();
        }
        #region LoadForm function
        private void LoadForm(Form frmIsLoaded)
        {
            bool isLoaded = false;
            foreach (Form child in MdiChildren)
            {
                if (child.Text == frmIsLoaded.Text)
                {
                    isLoaded = true;
                    frmIsLoaded = child;
                    break;
                }
            }

            if (!isLoaded)
            {
                frmIsLoaded.MdiParent = this;
                frmIsLoaded.Show();
            }
            else
            {
                frmIsLoaded.Activate();
            }
        }
        #endregion
         
       
        private void barListItem1_ListItemClick(object sender, ListItemClickEventArgs e)
        {
            bg_lookandfeel.LookAndFeel.SkinName = bar_lookandfeel.Strings[bar_lookandfeel.ItemIndex].ToString();
        }

       

        private void TimerStatus_Tick(object sender, EventArgs e)
        {
            barStaticItem2.Caption = String.Format("{0:HH:mm:ss}", DateTime.Now);

        }

      

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            TimerStatus.Enabled = false;
            DialogResult ok;
            ok = XtraMessageBox.Show("Bạn Có Muốn Thoát Không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bbiCustomerGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMCongty(this));
        }

        private void bbiCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMCongDoan(this));
        }

        private void bbiProvider_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMNhomMay(this));
        }

        private void bbiStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMThietBi(this));
        }

        private void bbiUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMProduct(this));
        }

        private void bbiItemGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMGiaoThuc(this));
        }

        private void bbiMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMXuong(this));
        }

        private void bbiNganhHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmDMThietBi_Combo(this));
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmDMThietBi_GiaoThuc(this));
        }

        private void bbiVoucherManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmDMDongGoiCap1(this));
            LoadForm(new frmTongHopMay("Line 001"));
        }

        private void bbiHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmReportCodeThung frm = new frmReportCodeThung(this);
            //frm.ShowDialog();
            LoadForm(new frmDMDongGoiCap1(this));
        }

        private void bar_tonghoptonkho_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmDMKiemTraThongTin(this));
        }

        private void nbiDonMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayDongGoi(this));
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayInPhun(this));
        }

        private void navBarItem9_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayCan(this));
        }

        private void navBarItem10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayDoKimLoai(this));
        }

        private void navBarItem14_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayDanNhanThungANSER(this));
            //LoadForm(new frmDMMayDanNhanThung(this));
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayDanNhanPallet(this));

        }

        private void bbiSale_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmLenhSanXuat());
        }

        private void bbiReportSale_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmLichSuVanHanh(this));
            //LoadForm(new frmRealTimeTheoLine());
        }

        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayInLabel(this));
        }

        private void bbiReciept_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmTongHopMay("Lines - Chuyền 1"));
        }

        private void bbiPayment_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmReportCodeThung(this));

        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMMayInNhanANSER(this));
        }

        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //LoadForm(new frmDMCameraCheck(this));
        }

        private void bbiBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmSaoLuu frm = new frmSaoLuu();
            //frm.ShowDialog();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMChuyen(this));
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMCauHinhChuyen(this));
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmDMBarcode(this));
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMLoaiThietBi(this));
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMThamSoGiaoThuc(this));
        }

        private void bbiDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMBoPhan());
        }

        private void bbiEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMNhanVien());
        }

        private void bbiUserRule_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmPhanQuyen());
        }

        private void bbiChangepassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmThayDoiMatKhau frm = new frmThayDoiMatKhau();
            //frm.ShowDialog();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmDMConfigBarcode(this));
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMConfigError(this));
        }

        private void bar_Thongtin_ItemClick(object sender, ItemClickEventArgs e)
        {
            //MessageBox.Show(treeList1.FocusedNode.GetDisplayText("Group_Name"));
            //LoadForm(new frmTongHopMay(treeList1.FocusedNode.GetDisplayText("Group_Name")));
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMNhaMay(this));
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMNhomSanPham(this));
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDonVi());
        }

        private void bbiListPrice_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmRealTimeTheoMachine());
        }

        private void bbiReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmReportKeHoachSanXuatTP(this));
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmReportVanHanhLine(this));
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmReportVanHanhMay(this));
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmReportNhapTP(this));
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadForm(new frmReportNguyenLieu(this));
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            //LoadForm(new frmTongHopMay(treeList1.FocusedNode.GetDisplayText("Group_Name")));
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMShift(this));
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMSkill(this));
        }

        private void bbiRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmPhuchoi frm = new frmPhuchoi();
            //frm.ShowDialog();
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMConfigConnect(this));
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMConfigStatus(this));
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMConfigWarning(this));
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMDongBo(this));
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadForm(new frmDMLoaiSanPham(this));
        }
    }
}