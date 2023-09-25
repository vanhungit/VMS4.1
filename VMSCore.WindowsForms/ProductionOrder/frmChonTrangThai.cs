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
    public partial class frmChonTrangThai : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        string configFile = @"XMLTimer.xml";
        public string NgonNgu = "", CodeTT = "", MaType ="", MaThietBi ="";
        DataTable dtBanTin = new DataTable();
        public frmChonTrangThai()
        {
            InitializeComponent();
            ReadXml_User();
            InitLookUpLine();
            //InitLookUp_KhoHang();

            //NgonNgu = XMLParser(configFile, "Table/Language");
            //if (NgonNgu == "EN")
            //{
            //    this.Text = "Add device";
            //    layoutControlItemMa.Text = "Device ID";
            //    layoutControlItemTen.Text = "Device name";
            //    layoutControlItemNhom.Text = "Device group";
            //    layoutControlItemCN.Text = "Branch";
            //    layoutControlItemGC.Text = "Note";
            //    chkSuDung.Text = "Use";
            //    btnDong.Text = "Exit";
            //    btnLuu.Text = "Agree";


            //}
            //else
            //{
            //    this.Text = "Thêm thiết bị";
            //    layoutControlItemMa.Text = "Mã thiết bị";
            //    layoutControlItemTen.Text = "Tên thiết bị";
            //    layoutControlItemNhom.Text = "Nhóm thiết bị";
            //    layoutControlItemCN.Text = "Chi nhánh";
            //    layoutControlItemGC.Text = "Ghi chú";
            //    chkSuDung.Text = "Sử dụng";
            //    btnDong.Text = "Thoát";
            //    btnLuu.Text = "Đồng Ý";
            //}
            dtBanTin.Columns.Add("Code", typeof(int));
            dtBanTin.Columns.Add("Name", typeof(string));
            DataRow row = dtBanTin.NewRow();
            row[0] = 0;
            row[1] = "Tạo";
            dtBanTin.Rows.Add(row);
            DataRow row1 = dtBanTin.NewRow();
            row1[0] = 1;
            row1[1] = "Chạy";
            dtBanTin.Rows.Add(row1);
            DataRow row2 = dtBanTin.NewRow();
            row2[0] = 2;
            row2[1] = "Dừng";
            dtBanTin.Rows.Add(row2);
            DataRow row3 = dtBanTin.NewRow();
            row3[0] = 3;
            row3[1] = "Hoàn Tất/Đóng";
            dtBanTin.Rows.Add(row3);
        }
        public string XMLParser(string configFile, string Tagname)
        {
            string Trave = "";
            XmlDocument xml = new XmlDocument();
            xml.Load(configFile);
            //---XPath expression 1---
            XmlNode node = xml.SelectSingleNode(Tagname);
            Trave = (node.InnerText);
            return Trave;
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
        private void InitLookUpLine()
        {
            lookUpTT.Properties.DataSource = dtBanTin;
            // Specify the data source to display in the dropdown.
            // The field providing the editor's display text.
            lookUpTT.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookUpTT.Properties.ValueMember = "Code";
            lookUpTT.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpTT.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpTT.Properties.AutoSearchColumnIndex = 1;
        }
   
        
        //private void InitLookUp_KhoHang()
        //{
        //    lookUpEditLoai.Properties.DataSource = new DeviceGroupRepository().GetAll();
        //    // Specify the data source to display in the dropdown.
        //    // The field providing the editor's display text.
        //    lookUpEditLoai.Properties.DisplayMember = "Name";
        //    // The field matching the edit value.
        //    lookUpEditLoai.Properties.ValueMember = "Code";
        //    lookUpEditLoai.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

        //    // Enable auto completion search mode.
        //    lookUpEditLoai.Properties.SearchMode = SearchMode.AutoComplete;
        //    // Specify the column against which to perform the search.
        //    lookUpEditLoai.Properties.AutoSearchColumnIndex = 1;
        //}
      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chọn line này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(lookUpTT.Text != "")
                {
                    CodeTT = lookUpTT.GetColumnValue("Code").ToString();
                    Close();
                }
                else
                {
                    lookUpTT.ShowPopup();
                }
                
                
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
