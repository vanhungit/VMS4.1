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
    public partial class frmCapNhatCongDoan : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        Stage objPlant = new Stage();

        public frmCapNhatCongDoan(string Code)
        {
            InitializeComponent();
            ReadXml_User();
            HienThiChiNhanh();
            objPlant = new StageRepository().GetByCode(Code);
            txtMaCN.Text = objPlant.Code;
            txtTenCN.Text = objPlant.Name;
            txtGhiChu.Text = objPlant.Description;
            lookUpCongTy.EditValue = objPlant.CompanyCode;
            chkDangDung.Checked = objPlant.Active;
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
                if (MessageBox.Show("Bạn muốn thêm công đoạn này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objPlant.Id = Guid.NewGuid();
                    objPlant.Code = txtMaCN.Text;
                    objPlant.Name = txtTenCN.Text;
                    objPlant.CompanyCode = lookUpCongTy.GetColumnValue("Code").ToString();
                    objPlant.Description = txtGhiChu.Text;
                    objPlant.NameEn = txtTenCN.Text;
                    objPlant.CreatorId = objuser.Username;
                    objPlant.LastModifierId = objuser.Username;
                    objPlant.CreationTime = DateTime.Now;
                    objPlant.LastModificationTime = DateTime.Now;
                    objPlant.Active = chkDangDung.Checked;
                    Stage objerror = new StageRepository().Add(objPlant);
                    if (objerror.Code != "")
                    {
                        XtraMessageBox.Show("Thêm công đoạn " + txtMaCN.Text + " thành công !", "Thông Báo");
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
