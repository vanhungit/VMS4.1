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
    public partial class frmCapNhatThamSoGiaoThuc : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        ProtocolParam objPlant = new ProtocolParam();

        public frmCapNhatThamSoGiaoThuc(string Code)
        {
            InitializeComponent();
            ReadXml_User();
            HienThiChiNhanh();
            objPlant = new ProtocolParamRepository().GetByCode(Code);
            txtMaCN.Text = objPlant.Code;
            txtTenCN.Text = objPlant.Name;
            cboLoai.Text = objPlant.DataType;
            lookUpGiaoThuc.EditValue = objPlant.ProtocolCode;
            chkDangDung.Checked = (bool)objPlant.Active;
        }
        public void HienThiChiNhanh()
        {
            lookUpGiaoThuc.Properties.DataSource = new ProtocolRepository().GetAll();
            lookUpGiaoThuc.Properties.DisplayMember = "Name";
            lookUpGiaoThuc.Properties.ValueMember = "Code";
            lookUpGiaoThuc.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
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
            if(lookUpGiaoThuc.Text !="")
            {
                if (MessageBox.Show("Bạn muốn thêm tham số giao thức này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objPlant.Code = txtMaCN.Text;
                    objPlant.Name = txtTenCN.Text;
                    objPlant.DataType = cboLoai.Text;
                    objPlant.ProtocolCode = lookUpGiaoThuc.GetColumnValue("Code").ToString();
                    objPlant.Description = txtGhiChu.Text;
                    objPlant.CreatorId = objuser.Username;
                    objPlant.LastModifierId = objuser.Username;
                    objPlant.CreationTime = DateTime.Now;
                    objPlant.LastModificationTime = DateTime.Now;
                    objPlant.Active = chkDangDung.Checked;
                    ProtocolParam objerror = new ProtocolParamRepository().Update(objPlant);
                    if (objerror.Code != "")
                    {
                        XtraMessageBox.Show("Thêm tham số " + txtMaCN.Text + " thành công !", "Thông Báo");
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
                lookUpGiaoThuc.ShowPopup();
            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    
}
