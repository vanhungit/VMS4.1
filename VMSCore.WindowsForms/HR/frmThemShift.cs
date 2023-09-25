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
    public partial class frmThemShift : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public frmThemShift()
        {
            InitializeComponent();
            ReadXml_User();
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
        
            {
                if (MessageBox.Show("Bạn muốn thêm ca làm này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Shift objPlant = new Shift();
                    objPlant.Id = Guid.NewGuid();
                    objPlant.Code = txtMaCN.Text;
                    objPlant.Name = txtTenCN.Text;
                    objPlant.FromTime = TimeStart.Time;
                    objPlant.ToTime = TimeEnd.Time;
                    objPlant.Description = txtGhiChu.Text;
                    objPlant.CreatorId = objuser.Username;
                    objPlant.LastModifierId = objuser.Username;
                    objPlant.CreationTime = DateTime.Now;
                    objPlant.LastModificationTime = DateTime.Now;
                    objPlant.Active = chkDangDung.Checked;
                    Shift objerror = new ShiftRepository().Add(objPlant);
                    if (objerror.Code != "")
                    {
                        XtraMessageBox.Show("Thêm ca làm " + txtMaCN.Text + " thành công !", "Thông Báo");
                        txtMaCN.Text = "";
                        txtTenCN.Text = "";
                        txtGhiChu.Text = "";
                        txtMaCN.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm thất bại " + objerror.Description + "", "Thông Báo");
                    }
                }
            }  
           
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
