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
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmThemSanPham : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        Product objPlant = new Product();

        public frmThemSanPham()
        {
            InitializeComponent();
            ReadXml_User();
            HienThiLoai();
            HienThiNhom();
            HienThiUnit();
        }
        public void HienThiLoai()
        {
            lookUpLoai.Properties.DataSource = new ProductTypeRepository().GetAll();
            lookUpLoai.Properties.DisplayMember = "Name";
            lookUpLoai.Properties.ValueMember = "Code";
            lookUpLoai.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        public void HienThiNhom()
        {
            lookUpNhom.Properties.DataSource = new ProductGroupRepository().GetAll();
            lookUpNhom.Properties.DisplayMember = "Name";
            lookUpNhom.Properties.ValueMember = "Code";
            lookUpNhom.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        public void HienThiUnit()
        {
            lookUpUnit.Properties.DataSource = new UNITRepository().GetAll();
            lookUpUnit.Properties.DisplayMember = "Name";
            lookUpUnit.Properties.ValueMember = "Code";
            lookUpUnit.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
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
            {
                if (MessageBox.Show("Bạn muốn thêm nhóm sản phẩm này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objPlant.Id = Guid.NewGuid();
                    objPlant.Code = txtMaCN.Text;
                    objPlant.Name = txtTenCN.Text;
                    objPlant.ProductTypeCode = lookUpLoai.GetColumnValue("Code").ToString();
                    objPlant.ProductGroupCode = lookUpNhom.GetColumnValue("Code").ToString();
                    objPlant.UnitCode = lookUpUnit.GetColumnValue("Code").ToString();
                    objPlant.CreatorId = objuser.Username;
                    objPlant.LastModifierId = objuser.Username;
                    objPlant.CreationTime = DateTime.Now;
                    objPlant.LastModificationTime = DateTime.Now;
                    objPlant.Active = true;
                    Product objerror = new ProductRepository().Add(objPlant);
                    if (objerror.Code != "")
                    {
                        XtraMessageBox.Show("Thêm sản phẩm " + txtMaCN.Text + " thành công !", "Thông Báo");
                        txtMaCN.Text = "";
                        txtTenCN.Text = "";
                        txtGhiChu.Text = "";
                        txtMaCN.Focus();
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm thất bại " + objerror.Code + "", "Thông Báo");
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
