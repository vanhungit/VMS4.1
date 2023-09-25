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
    public partial class frmPhanBoCodeThung : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        string configFile = @"XMLTimer.xml";
        public string NgonNgu = "", MaLine ="", MaType ="", MaThietBi ="";
        public frmPhanBoCodeThung()
        {
            InitializeComponent();
            ReadXml_User();
            InitLookUpLine();
            //InitLookUp_KhoHang();
            InitLookUp_ThietBi();
           
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
            lookUpLine.Properties.DataSource = new LineRepository().GetAll();
            // Specify the data source to display in the dropdown.
            // The field providing the editor's display text.
            lookUpLine.Properties.DisplayMember = "Name";
            // The field matching the edit value.
            lookUpLine.Properties.ValueMember = "Code";
            lookUpLine.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpLine.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpLine.Properties.AutoSearchColumnIndex = 1;
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
        private void InitLookUp_ThietBi()
        {
            lookUpDevice.Properties.DataSource = new LineDeviceRepository().GetAll();
            // Specify the data source to display in the dropdown.
            // The field providing the editor's display text.
            lookUpDevice.Properties.DisplayMember = "DeviceCode";
            // The field matching the edit value.
            lookUpDevice.Properties.ValueMember = "DeviceCode";
            lookUpDevice.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            // Enable auto completion search mode.
            lookUpDevice.Properties.SearchMode = SearchMode.AutoComplete;
            // Specify the column against which to perform the search.
            lookUpDevice.Properties.AutoSearchColumnIndex = 1;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn chọn line này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(lookUpLine.Text != "")
                {
                    MaLine = lookUpLine.GetColumnValue("Code").ToString();
                    MaType = "";
                    MaThietBi = lookUpDevice.GetColumnValue("DeviceCode").ToString();
                    Close();
                }
                else
                {
                    lookUpLine.ShowPopup();
                }
                
                
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lookUpLine_EditValueChanged(object sender, EventArgs e)
        {
            lookUpDevice.Properties.DataSource = new LineDeviceRepository().GetAllByCondition(x => x.LineCode == lookUpLine.GetColumnValue("Code").ToString());
        }
    }
}
