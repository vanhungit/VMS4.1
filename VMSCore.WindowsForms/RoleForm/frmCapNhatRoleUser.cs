﻿using DevExpress.XtraEditors;
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
    public partial class frmCapNhatRoleUser : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        RoleUser objPlant = new RoleUser();

        public frmCapNhatRoleUser(string Code)
        {
            InitializeComponent();
            ReadXml_User();
            HienThiRole();
            HienThiNhanVien();
            objPlant = new RoleUserRepository().GetOneByCondition(x => x.Code == Code);
            lookUpRole.EditValue = objPlant.RoleCode;
            lookUpNhanvien.EditValue = objPlant.UserCode;
        }
        public void HienThiRole()
        {
            lookUpRole.Properties.DataSource = new RoleRepository().GetAll();
            lookUpRole.Properties.DisplayMember = "Name";
            lookUpRole.Properties.ValueMember = "Code";
            lookUpRole.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        public void HienThiNhanVien()
        {
            lookUpNhanvien.Properties.DataSource = new StaffRepository().GetAll();
            lookUpNhanvien.Properties.DisplayMember = "Name";
            lookUpNhanvien.Properties.ValueMember = "Code";
            lookUpNhanvien.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
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
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = _staffRepository.GetStaffByUserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if(lookUpRole.Text !="")
            {
                if (MessageBox.Show("Bạn muốn cập nhật người dùng?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objPlant.RoleCode = lookUpRole.GetColumnValue("Code").ToString();
                    objPlant.UserCode = lookUpNhanvien.GetColumnValue("Code").ToString();
                    objPlant.UserName = lookUpNhanvien.GetColumnValue("Username").ToString();
                    objPlant.CreatorId = objuser.Username;
                    objPlant.LastModifierId = objuser.Username;
                    objPlant.CreationTime = DateTime.Now;
                    objPlant.LastModificationtime = DateTime.Now;
                    objPlant.Active = chkDangDung.Checked;
                    RoleUser objerror = new RoleUserRepository().Update(objPlant);
                    if (objerror.Code != "")
                    {
                        XtraMessageBox.Show("Cập nhật thành công !", "Thông Báo");
                        txtGhiChu.Text = "";
                    }
                    else
                    {
                        XtraMessageBox.Show("Cập nhật thất bại " + objerror.UserName + "", "Thông Báo");
                    }
                }
            }  
            else
            {
                lookUpRole.ShowPopup();
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
