using DevExpress.XtraEditors;
using Newtonsoft.Json;
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
    public partial class frmCapNhatCongTy : Form
    {
        Staff objuser = new Staff();
        Company objPlant = new Company();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public frmCapNhatCongTy(string Id)
        {
            InitializeComponent();
            ReadXml_User();
            objPlant = new CompanyRepository().GetByCode(Id);
            txtMaCN.Text = objPlant.Code;
            txtTenCN.Text = objPlant.Name;
            txtGhiChu.Text = objPlant.Description;
            chkDangDung.Checked = objPlant.Active;

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
            if (MessageBox.Show("Bạn muốn thêm công ty này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                objPlant.Code = txtMaCN.Text;
                objPlant.Name = txtTenCN.Text;
                objPlant.Description = txtGhiChu.Text;
                objPlant.CompanyCodeNameEn = txtTenCN.Text;
                objPlant.CreatorId = objuser.Username;
                objPlant.LastModifierId = objuser.Username;
                objPlant.CreationTime = DateTime.Now;
                objPlant.LastModificationTime = DateTime.Now;
                objPlant.Active = chkDangDung.Checked; 
                List<Company> list = new List<Company>();
                list.Add(objPlant);

                //Company objerror = new CompanyRepository().Update(objPlant);
                Company objerror = new CompanyRepository().UpdateSyncToken(objPlant, "Company", JsonConvert.SerializeObject(list), objuser);
                if (objerror.Code != "")
                {
                    XtraMessageBox.Show("Cập nhật công ty " + txtMaCN.Text + " thành công !", "Thông Báo");
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
    }
    
}
