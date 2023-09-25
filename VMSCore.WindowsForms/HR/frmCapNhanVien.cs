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
using VMSCore.Extensions;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmCapNhanVien : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        DataTable dtBanTin = new DataTable();
        Staff objPlant = new Staff();

        public frmCapNhanVien(string Code)
        {
            InitializeComponent();
            objPlant = new StaffRepository().GetByCode(Code);
            txtMaCN.Text = objPlant.Code;
            txtTenCN.Text = objPlant.Name;

            ReadXml_User();
            HienThiChiNhanh();
            dtBanTin.Columns.Add("Code", typeof(int));
            dtBanTin.Columns.Add("Name", typeof(string));
            DataRow row = dtBanTin.NewRow();
            row[0] = 0;
            row[1] = "Nam";
            dtBanTin.Rows.Add(row);
            DataRow row1 = dtBanTin.NewRow();
            row1[0] = 1;
            row1[1] = "Nữ";
            dtBanTin.Rows.Add(row1);
            DataRow row2 = dtBanTin.NewRow();
            row2[0] = 2;
            row2[1] = "Khác";
            dtBanTin.Rows.Add(row2);
            HienThiGioiTinh();
        }
        public void HienThiChiNhanh()
        {
            lookUpCongTy.Properties.DataSource = new CompanyRepository().GetAllCompany();
            lookUpCongTy.Properties.DisplayMember = "Name";
            lookUpCongTy.Properties.ValueMember = "Code";
            lookUpCongTy.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        }
        public void HienThiGioiTinh()
        {
            lookUpGioiTinh.Properties.DataSource = dtBanTin;
            lookUpGioiTinh.Properties.DisplayMember = "Name";
            lookUpGioiTinh.Properties.ValueMember = "Code";
            lookUpGioiTinh.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
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
                if(lookUpGioiTinh.Text !="")
                {
                   {
                        
                        {
                            if (MessageBox.Show("Bạn muốn thêm nhân viên này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                RepositoryLibrary repositoryLibrary = new RepositoryLibrary();
                                objPlant.Code = txtMaCN.Text;
                                objPlant.Name = txtTenCN.Text;
                                objPlant.Address = txtAddress.Text;
                                objPlant.BirthDay = dateNgaySinh.DateTime;
                                objPlant.Gender = lookUpGioiTinh.GetColumnValue("Code").ToString();
                                objPlant.CompanyCode = lookUpCongTy.GetColumnValue("Code").ToString();
                                objPlant.KeyPassword = "vms4.1";
                                objPlant.KeyActiveEmail = "";
                                objPlant.Description = txtGhiChu.Text;
                                objPlant.CreatorId = objuser.Username;
                                objPlant.LastModifierId = objuser.Username;
                                objPlant.CreationTime = DateTime.Now;
                                objPlant.LastModificationTime = DateTime.Now;
                                objPlant.Active = chkDangDung.Checked;
                                Staff objerror = new StaffRepository().Update(objPlant);
                                if (objerror.Code != "")
                                {
                                    XtraMessageBox.Show("Thêm nhân viên " + txtMaCN.Text + " thành công !", "Thông Báo");
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
                   
                }
                else
                {
                    lookUpGioiTinh.ShowPopup();
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
