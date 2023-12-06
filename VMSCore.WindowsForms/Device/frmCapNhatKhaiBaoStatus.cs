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
    public partial class frmCapNhatKhaiBaoStatus : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        StatusConfig objPlant = new StatusConfig();

        public frmCapNhatKhaiBaoStatus(string Code)
        {
            InitializeComponent();
            ReadXml_User();
            HienThiNhaMay();
            HienThiXuong();
            objPlant = new StatusConfigRepository().GetByCode(Code);
            txtMaCN.Text = objPlant.Code;
            txtTenCN.Text = objPlant.Name;
            txtNameShow.Text = objPlant.NameShow;
            txtCodeMap.Text = objPlant.CodeMap;
            calcDecimal.Value = (int)objPlant.DecimalCode;
            lookUpLoai.EditValue = objPlant.TypeDeviceCode;
            lookUpNhom.EditValue = objPlant.DeviceGroupCode;
            chkDangDung.Checked = objPlant.Active;
        }
        public void HienThiXuong()
        {
            lookUpLoai.Properties.DataSource = new TypeDeviceRepository().GetAll();
            lookUpLoai.Properties.DisplayMember = "Name";
            lookUpLoai.Properties.ValueMember = "Code";
            lookUpLoai.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        public void HienThiNhaMay()
        {
            lookUpNhom.Properties.DataSource = new DeviceGroupRepository().GetAll();
            lookUpNhom.Properties.DisplayMember = "Name";
            lookUpNhom.Properties.ValueMember = "Code";
            lookUpNhom.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        //public void HienThiChiNhanh()
        //{
        //    lookUpCongTy.Properties.DataSource = new CompanyRepository().GetAllCompany();
        //    lookUpCongTy.Properties.DisplayMember = "Name";
        //    lookUpCongTy.Properties.ValueMember = "Code";
        //    lookUpCongTy.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
        //    //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        //}
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
                if(lookUpNhom.Text !="")
                {
                    if (lookUpLoai.Text != "")
                    {
                        if (MessageBox.Show("Bạn muốn thêm thiết bị này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            objPlant.Id = Guid.NewGuid();
                            objPlant.Code = txtMaCN.Text;
                            objPlant.Name = txtTenCN.Text;
                            objPlant.TypeDeviceCode = lookUpLoai.GetColumnValue("Code").ToString();
                            objPlant.DeviceGroupCode = lookUpNhom.GetColumnValue("Code").ToString();
                            objPlant.NameShow = txtNameShow.Text;
                            objPlant.DecimalCode = (int)calcDecimal.Value;
                            objPlant.CreatorId = objuser.Username;
                            objPlant.LastModifierId = objuser.Username;
                            objPlant.CreationTime = DateTime.Now;
                            objPlant.LastModificationTime = DateTime.Now;
                            objPlant.Active = chkDangDung.Checked;
                            StatusConfig objerror = new StatusConfigRepository().Update(objPlant);
                            if (objerror.Code != "")
                            {
                                XtraMessageBox.Show("Cập nhật khai báo trạng thái " + txtMaCN.Text + " thành công !", "Thông Báo");
                                txtMaCN.Text = "";
                                txtTenCN.Text = "";
                                txtGhiChu.Text = "";
                                txtMaCN.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show("Cập nhật thất bại " + objerror.Code + "", "Thông Báo");
                            }
                        }
                    }
                    else
                    {
                        lookUpLoai.ShowPopup();
                    }    
                } 
                else
                {
                    lookUpNhom.ShowPopup();
                }    

                
            }  
           
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
