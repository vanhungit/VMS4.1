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
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmCapNhatThietBi : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        Device objPlant = new Device();

        public frmCapNhatThietBi(string Code)
        {
            InitializeComponent();
            ReadXml_User();
            HienThiChiNhanh();
            HienThiNhaMay();
            HienThiXuong();
            objPlant = new DeviceRepository().GetByCode(Code);
            txtMaCN.Text = objPlant.Code;
            txtTenCN.Text = objPlant.Name;
            lookUpCongTy.EditValue = objPlant.CompanyCode;
            lookUpLoai.EditValue = objPlant.TypeDeviceCode;
            lookUpNhom.EditValue = objPlant.DeviceGroupCode;
            calcLevel.Value = objPlant.LevelCode != null ? (int)objPlant.LevelCode : 0;
            txtGhiChu.Text = objPlant.Description;
            chkDangDung.Checked = (bool)objPlant.Active;
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
        public void HienThiChiNhanh()
        {
            lookUpCongTy.Properties.DataSource = new CompanyRepository().GetAllCompany();
            lookUpCongTy.Properties.DisplayMember = "Name";
            lookUpCongTy.Properties.ValueMember = "Code";
            lookUpCongTy.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
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
            if(lookUpCongTy.Text !="")
            {
                if(lookUpNhom.Text !="")
                {
                    if (lookUpLoai.Text != "")
                    {
                        if (MessageBox.Show("Bạn muốn thêm thiết bị này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            objPlant.Code = txtMaCN.Text;
                            objPlant.Name = txtTenCN.Text;
                            objPlant.TypeDeviceCode = lookUpLoai.GetColumnValue("Code").ToString();
                            objPlant.CompanyCode = lookUpCongTy.GetColumnValue("Code").ToString();
                            objPlant.DeviceGroupCode = lookUpNhom.GetColumnValue("Code").ToString();
                            objPlant.LevelCode = (int)calcLevel.Value;
                            objPlant.Description = txtGhiChu.Text;
                            objPlant.CreatorId = objuser.Username;
                            objPlant.LastModifierId = objuser.Username;
                            objPlant.CreationTime = DateTime.Now;
                            objPlant.LastModificationTime = DateTime.Now;
                            objPlant.Active = chkDangDung.Checked;
                            Device objerror = new DeviceRepository().Update(objPlant);
                            if (objerror.Code != "")
                            {
                                XtraMessageBox.Show("Cập nhật thiết bị " + txtMaCN.Text + " thành công !", "Thông Báo");
                                txtMaCN.Text = "";
                                txtTenCN.Text = "";
                                txtGhiChu.Text = "";
                                txtMaCN.Focus();
                            }
                            else
                            {
                                XtraMessageBox.Show("Cập nhật thất bại " + objerror.Description + "", "Thông Báo");
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
            else
            {
                lookUpCongTy.ShowPopup();
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
