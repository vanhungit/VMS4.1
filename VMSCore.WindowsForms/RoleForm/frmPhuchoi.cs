using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Data.SqlClient;
using MicrosoftHelper;
using SalesManager;
using System.Xml;
namespace CartManager
{
    public partial class frmPhuchoi : DevExpress.XtraEditors.XtraForm
    {
        //SYS_LOG _sys_log = new SYS_LOG();
        string configFile = @"XMLTimer.xml";
        string NgonNgu = "";
        public frmPhuchoi()
        {
            InitializeComponent();
            NgonNgu = XMLParser(configFile, "Table/Language");
            if (NgonNgu == "EN")
            {
                this.Text = "Restore data";
                layoutControlItemTT.Text = "File restore";
                btnThucHien.Text = "OK";
                btnDong.Text = "Close";
            }
            else
            {
                this.Text = "Phục hồi dữ liệu";
                layoutControlItemTT.Text = "Tập tin phục hồi";
                btnThucHien.Text = "Thực hiện";
                btnDong.Text = "Đóng";

            }
        }
        public string XMLParser(string configFile, string Tagname)
        {
            string Trave = "";
            XmlDocument xml = new XmlDocument();
            xml.Load(configFile);
            //---XPath expression 1---
            XmlNode node = xml.SelectSingleNode(Tagname);
            Trave = (node.InnerText);
            return Trave;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (txtLink.Text != "")
            {
                //SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
                //con.Open();
                //SqlCommand cmd_insert = con.CreateCommand();
                //cmd_insert.CommandText = "USE master " +
                //                          "RESTORE DATABASE [AMP_DB] " +
                //                          "FROM DISK = '" + txtLink.Text + "'";
                //WaitDialog.CreateWaitDialog("Đang phục hồi dữ liệu ...", "Phục hồi dữ liệu");
                //try
                //{
                //    cmd_insert.ExecuteNonQuery();
                //    con.Close();
                //    _sys_log.MChine = "COMPUTER";
                //    _sys_log.IP = "COMPUTER";
                //    _sys_log.UserID = "US000001";
                //    _sys_log.Created = DateTime.Now;
                //    _sys_log.Action_Name = "Phục Hồi";
                //    _sys_log.Description = "Phục Hồi Cơ Sở Dữ Liệu Hệ Thống -" + txtLink.Text;
                //    _sys_log.Module = "Cơ Sở Dữ Liệu";
                //    _sys_log.Reference = txtLink.Text.Trim() + "," + "WM_DATABASE";
                //    _sys_log.Active = true;
                //    //SYS_LOGController insertlog = new SYS_LOGController();
                //    //insertlog.SYS_LOG_Insert(_sys_log);
                //    XtraMessageBox.Show("Phục hồi dữ liệu thành công!!", "Thông báo");
                //    //Application.Exit();

                //}
                //catch(Exception ex)
                //{
                //    XtraMessageBox.Show("Phục hồi dữ liệu thất bại!!", "Thông báo");
                //}
                //WaitDialog.CloseWaitDialog();
            }
            else
            {

            }
        }

        private void txtLink_Properties_Click(object sender, EventArgs e)
        {
            FileDialog dldlg = new OpenFileDialog();
            //dldlg.InitialDirectory = @":D\";
            //dldlg.Filter = "Text File(*.xls)|*jpg;*bmp;*gif";
            if (dldlg.ShowDialog() == DialogResult.OK)
            {
                txtLink.Text = dldlg.FileName;
            }
        }
    }
}