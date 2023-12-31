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
    public partial class frmLenhSanXuat : DevExpress.XtraEditors.XtraForm
    {
        UC_LapLenhSanXuat frmLapLenh;
        UC_LenhSXCT frmLenhSXCT;
        UC_LenhSXTongHop frmLenhSXTH;
        UC_LenhSXGiaoDich frmLenhGD;
        public frmLenhSanXuat()
        {
            InitializeComponent();
            groupControl1.ResetText();
            groupControl1.Text = "Lập Lệnh Sản Xuất";
            groupControl1.Controls.Clear();
            frmLapLenh = new UC_LapLenhSanXuat(this);
            frmLapLenh.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLapLenh);//thêm user control vào panel
        }
        
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lập Lệnh Sản Xuất";
            groupControl1.Controls.Clear();
            frmLapLenh = new UC_LapLenhSanXuat(this);
            frmLapLenh.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLapLenh);//thêm user control vào panel
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Sản Xuất Chi Tiết";
            groupControl1.Controls.Clear();
            frmLenhSXCT = new UC_LenhSXCT(this);
            frmLenhSXCT.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLenhSXCT);//thêm user control vào panel
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Lệnh Sản Xuất Tổng Hợp";
            groupControl1.Controls.Clear();
            frmLenhSXTH = new UC_LenhSXTongHop(this);
            frmLenhSXTH.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLenhSXTH);//thêm user control vào panel
        }

        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            groupControl1.ResetText();
            groupControl1.Text = "Chi Tiết Giao Dịch";
            groupControl1.Controls.Clear();
            frmLenhGD = new UC_LenhSXGiaoDich(this);
            frmLenhGD.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(frmLenhGD);//thêm user control vào panel
        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

        private void navBarItem2_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            
        }

     
        
    }
}