using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.IO;

using System.Text.RegularExpressions;

namespace CartManager
{
    public partial class frmThayDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        string configFile = @"XMLTimer.xml";
        string NgonNgu = "";
        public frmThayDoiMatKhau()
        {
            InitializeComponent();
            ReadXml_User();
            NgonNgu = XMLParser(configFile, "Table/Language");
            if (NgonNgu == "EN")
            {
                this.Text = "Change Password";
                labelControlMKMoi.Text = "New Password";
                labelControlMKCu.Text = "Old Password";
                labelControlMKNhapLai.Text = "Re-enter password";
                btnDongY.Text = "Agree";
                btnThoat.Text = "Exit";
            }
            else
            {
                this.Text = "Thay đổi mật khẩu";
                labelControlMKMoi.Text = "Mật khẩu mới";
                labelControlMKCu.Text = "Mật khẩu cũ";
                labelControlMKNhapLai.Text = "Mật khẩu nhập lại";
                btnDongY.Text = "Đồng Ý";
                btnThoat.Text = "Thoát";
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
        string UserID = "";
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
                //UserID = new SYS_USERController().SYS_USER_Get_By_UserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim()).UserID;

            }
            fs.Close();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
        static bool ValidatePassword(string passWord)
        {
            int validConditions = 0;
            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions < 2) return false;
            //if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions != 3) 
                return false;
            else if (validConditions == 3)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '!', '*' }; // or whatever    
                if (passWord.IndexOfAny(special) == -1) return false;
            }
            return true;
        }    
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //SYS_USER objsysuser = new SYS_USERController().SYS_USER_Get(UserID);
            ////EMPLOYEE objemployee = new EMPLOYEEController().LayTenNhanVien(objsysuser.PartID);
            //int rs = -1;
            //if (txtPassNew.Text.Trim().Length >= 8)
            //{
            //    if (txtPassMak.Text.Trim().Length >= 8)
            //    {
            //    //    Regex sampleRegex = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$");
            //    //    bool isStrongPassword = sampleRegex.IsMatch(txtPassNew.Text.Trim());
            //    //    string password = txtPassNew.Text.Trim();
            //    //    bool containsAtLeastOneUppercase = password.Any(char.IsUpper);
            //    //    bool containsAtLeastOneLowercase = password.Any(char.IsLower);
            //    //    bool containsAtLeastOneSpecialChar = password.Any(ch => !Char.IsLetterOrDigit(ch));
            //    //    bool containsAtLeastOneDigit = password.Any(char.IsDigit);			 
            //    //    if(isStrongPassword)
            //        bool isStrongPassword = ValidatePassword(txtPassNew.Text.Trim());
            //        if (isStrongPassword)
            //        {
            //            if (txtPassOld.Text.Trim() == objsysuser.Password)
            //            {
            //                if (txtPassNew.Text == txtPassMak.Text)
            //                {
            //                    objsysuser.Password = txtPassNew.Text.Trim();
            //                    //objsysuser.ModifyBy = UserID;
            //                    //objsysuser.ModifyDate = DateTime.Now;
            //                    //objemployee.ModifiedBy = UserID;
            //                    //objemployee.ModifiedDate = DateTime.Now;
            //                    rs = new SYS_USERController().SYS_USER_Update(objsysuser, objsysuser.UserID);
            //                    //rs = new EMPLOYEEController().CapNhatNhanVien(objemployee);
            //                    if (rs < 1)
            //                    {
            //                        MessageBox.Show("Cập Nhật Thất Bại", "Thông báo");
            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Cập Nhật Thành Công", "Thông báo");
            //                        Close();
            //                    }
            //                }
            //                else
            //                    XtraMessageBox.Show("Mật Khẩu Mới Không Khớp!!", "Thông Báo");

            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("Nhập Sai Mật Khẩu!!", "Thông Báo");
            //            }
            //        }
            //        else
            //        {
            //            XtraMessageBox.Show("Password yếu!!", "Thông Báo");
            //        }
            //    }
            //}
            //else
            //{
            //    XtraMessageBox.Show("Mật khẩu mới không phù hợp !!", "Thông Báo");
            //}
           
        }
      
    }
}