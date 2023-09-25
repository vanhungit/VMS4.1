using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace CartManager
{
    public partial class frmSaoLuu : DevExpress.XtraEditors.XtraForm
    {
        //SYS_LOG _sys_log = new SYS_LOG();
        public frmSaoLuu()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = (ButtonEdit)sender;
            FolderBrowserDialog folderbrowse = new FolderBrowserDialog();
            if (editor.Properties.Buttons.IndexOf(e.Button).ToString() == "0")
            {
                folderbrowse.ShowDialog();
                txtLink.Text = folderbrowse.SelectedPath;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //int rs = -1;
            //string pathname = "";
            //pathname = txtLink.Text.Trim() + @"\"+ txtTaptin.Text.Trim() + ".bak";
            //_sys_log.MChine = "COMPUTER";
            //_sys_log.IP = "COMPUTER";
            //_sys_log.UserID = "US000001";
            //_sys_log.Created = DateTime.Now;
            //_sys_log.Action_Name = "Sao Lưu";
            //_sys_log.Description = "Sao Lưu Cơ Sở Dữ Liệu Hệ Thống -" + pathname;
            //_sys_log.Module = "Cơ Sở Dữ Liệu";
            //_sys_log.Reference = txtLink.Text.Trim() + "," + "WM_DATABASE";
            //_sys_log.Active = true;
            //SYS_LOGController insertlog = new SYS_LOGController();
            //insertlog.SYS_LOG_Insert(_sys_log);
            //rs = new SYS_USERController().BACKUP_DATABASE(pathname);
            //if (rs > 0)
            //{
            //    XtraMessageBox.Show("Sao Lưu thành công", "Thông báo");
            //}
            //else
            //{
            //    XtraMessageBox.Show("Sao Lưu thất bại", "Thông báo");
            //}

        }

        private void frmSaoLuu_Load(object sender, EventArgs e)
        {
            txtTaptin.Text = "VMS" + DateTime.Now.ToString("ddMMyyyy_HHmm");
        }

       
    }
}