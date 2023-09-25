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
using VMSCore.Infrastructure.Features.SyncData.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmDashboardToTruong : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtLoi = new DataTable();
        DataTable dtdaychuyen = new DataTable();
        string ImageDefine = "ImageDefine";
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        Company objCompany = new Company();
        public frmDashboardToTruong()
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 35;
            gridView2.Invalidate();
            gridView2.IndicatorWidth = 35;
            dtLoi.Columns.Add("ID");
            dtLoi.Columns.Add("Name");
            dtLoi.Columns.Add("TTKetNoi");
            dtLoi.Columns.Add("TTMay");
            dtLoi.Columns.Add("TTLoi");
            dtLoi.Rows.Add(new Object[] { "0001", "Máy in Link", "Kết nối", "Đang in", "" });
            dtLoi.Rows.Add(new Object[] { "0002", "Máy in Anxer", "Kết nối", "Đang in", "" });
            dtLoi.Rows.Add(new Object[] { "0003", "Băng tải PLC", "Kết nối", "Đang chạy", "" });
            gridControlMayMoc.DataSource = dtLoi;
            dtdaychuyen.Columns.Add("ID");
            dtdaychuyen.Columns.Add("KH");
            dtdaychuyen.Columns.Add("TT");
            dtdaychuyen.Columns.Add("SKU");
            dtdaychuyen.Columns.Add("SLLoi");
            dtdaychuyen.Columns.Add("HT");
            dtdaychuyen.Rows.Add(new Object[] { "Dây chuyền 1", "1000 chai", "500 chai", "Pepsi", "1", "50%" });
            dtdaychuyen.Rows.Add(new Object[] { "Dây chuyền 2", "1000 chai", "1000 chai", "Sprite", "2", "100%" });
            dtdaychuyen.Rows.Add(new Object[] { "Dây chuyền 3", "1000 chai", "800 chai", "Sprite", "", "80%" });
            gridControl1.DataSource = dtdaychuyen;
            ReadXml_User();
            objCompany = new CompanyRepository().GetOneByCondition(x => x.Code == objuser.CompanyCode);
            pictureEditCompany.Image = Image.FromFile(objCompany.URLSmall);
            labelCompany.Text = objCompany.Name;
            gridControlTongQuan.DataSource = new SyncDataFunction().sproc_GetListOverView();


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
        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }
    }
}
