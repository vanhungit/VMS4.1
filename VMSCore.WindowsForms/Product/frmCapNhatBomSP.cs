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
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmCapNhatBomSP : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        MaterialProduct objPlant = new MaterialProduct();
        Product objProduct = new Product();

        public frmCapNhatBomSP(string Code)
        {
            InitializeComponent();
            ReadXml_User();
            HienThiUnitCha();
            objPlant = new MaterialProductRepository().GetOneByCondition(x => x.Code == Code);
            objProduct = new ProductRepository().GetOneByCondition(x => x.Code == objPlant.ProductCode);
            txtMaCN.Text = objProduct.Code;
            txtTenCN.Text = objProduct.Name;
            lookUpNL.EditValue = objPlant.MaterialCode;
        }
       
        public void HienThiUnitCha()
        {
            lookUpNL.Properties.DataSource = new ProductRepository().GetAll();
            lookUpNL.Properties.DisplayMember = "Name";
            lookUpNL.Properties.ValueMember = "Code";
            lookUpNL.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
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
                if (MessageBox.Show("Bạn muốn thêm bom sản phẩm này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    objPlant.ProductCode = txtMaCN.Text;
                    objPlant.MaterialCode = lookUpNL.GetColumnValue("Code").ToString();
                    objPlant.CreatorId = objuser.Username;
                    objPlant.CreationTime = DateTime.Now;
                    objPlant.Active = true;
                    MaterialProduct objerror = new MaterialProductRepository().Update(objPlant);
                    if (objerror.Code != "")
                    {
                        XtraMessageBox.Show("Thêm bom " + txtMaCN.Text + " thành công !", "Thông Báo");
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
