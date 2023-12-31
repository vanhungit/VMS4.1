using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Xml;
using VMSCore.Infrastructure.Features.SystemPermissionConfiguration.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.EntityModels;
using VMSCore.Extensions;

namespace VMSCore.WindowsForms
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public bool Flag = false;
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public frmDangNhap()
        {
            InitializeComponent();
            simpleButton2.Focus();
            ReadXml();
            ReadXml_User();

        }
        //SYS_USER objsysuser = new SYS_USER();
        #region Account
        public void Create_Xml_Account(string UserName, string PassWord)
        {
            XmlTextWriter writer = new XmlTextWriter("account.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("NewDataSet");
            createNode(UserName, PassWord, checkremember.Checked.ToString(), writer);
            //createNode(UserName, writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            //MessageBox.Show("XML File created ! ");

        }
        private void createNode(string UserName, string PassWord, string Type_User, XmlTextWriter writer)
        {
            writer.WriteStartElement("account");
            writer.WriteStartElement("user");
            writer.WriteString(UserName);
            writer.WriteEndElement();
            writer.WriteStartElement("pass");
            writer.WriteString(PassWord);
            writer.WriteEndElement();
            writer.WriteStartElement("Remember");
            writer.WriteString(Type_User);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
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
                if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    cboUser.Text = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    txtMatKhau.Text = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                }
            }
            fs.Close();
        }
        #endregion
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
                    MicrosoftHelper.DataProvider.ConnectionString = "Server=" + xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + ";Database=" + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + ";uid=" + xmlnode[i].ChildNodes.Item(2).InnerText.Trim() + ";pwd=" + xmlnode[i].ChildNodes.Item(3).InnerText.Trim() + "";
                }
                else if (xmlnode[i].ChildNodes.Item(4).InnerText.Trim() == "0")
                {
                    MicrosoftHelper.DataProvider.ConnectionString = "Server=" + xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + ";INITIAL CATALOG=" + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + ";INTEGRATED SECURITY=true";

                }
            }
            fs.Close();
        }
        #endregion
        public void HienThiUser()
        {
            DataTable databases = null;
            //databases = new SYS_USERController().SYS_USER_GetList();
            //foreach (DataRow datarow in databases.Rows)
            //{

            //    cboUser.Properties.Items.Add(datarow["UserName"]);
            //}
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //objsysuser = new SYS_USERController().SYS_USER_Get_By_UserName(cboUser.Text.Trim());


            //_sys_log.Created = DateTime.Now;
            //_sys_log.Action_Name = "Đăng Nhập";
            //_sys_log.Description = "Đăng Nhập Hệ Thống";
            //_sys_log.Module = "Hệ Thống";
            //_sys_log.Active = true;
            //SYS_LOGController insertlog = new SYS_LOGController();
            //insertlog.SYS_LOG_Insert(_sys_log);
            //if (objsysuser.UserName.Trim() != "")
            //{
            //    if (txtMatKhau.Text.Trim() == objsysuser.Password)
            //    {
            //        Flag = true;
            //        Create_Xml_Account(cboUser.Text, txtMatKhau.Text);
            //        Close();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Nhập Sai Mật Khẩu!!", "Thông Báo");
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("Nhập Sai User!!", "Thông Báo");
            //}
            var staff = _staffRepository.GetOneByCondition(_ => _.Username == cboUser.Text.Trim());
            if (staff == null)
            {
                MessageBox.Show("không tồn tại staff");
                return;
            }
            else if(staff.Password != new RepositoryLibrary().EncryptString(txtMatKhau.Text, "vms4.1"))
            {
                MessageBox.Show("Nhập sai mật khẩu");
                return;
            }  
            else
            {
                Flag = true;
                Create_Xml_Account(cboUser.Text, txtMatKhau.Text);
                Close();
            }    
           
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //frmCauHinhCSDL frm = new frmCauHinhCSDL();
            //frm.ShowDialog();
        }

        private void cboUser_Properties_Click(object sender, EventArgs e)
        {
            //if (cboUser.Properties.Items.Count == 0)
            {
                HienThiUser();
            }
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Flag == true)
            {
            }
            else
            {
                Application.Exit();
            }
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

    }
}