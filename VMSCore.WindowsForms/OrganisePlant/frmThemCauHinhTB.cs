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
    public partial class frmThemCauHinhTB : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        string configFile = @"XMLTimer.xml";
        string NgonNgu = "";
        public frmThemCauHinhTB()
        {
            InitializeComponent();
            ReadXml_User();
            InitLookUpLine();
            HienThiThietBi();
            
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
        public void HienThiThietBi()
        {
            gridLookUpThietBi.Properties.DataSource = new DeviceRepository().GetAll();
            gridLookUpThietBi.Properties.DisplayMember = "Name";
            gridLookUpThietBi.Properties.ValueMember = "Code";
            gridLookUpThietBi.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
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
            if (MessageBox.Show("Bạn muốn thêm cổng chi nhánh này?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(lookUpLine.Text != "")
                {
                    if (gridLookUpThietBi.Text != "")
                    {

                        LineDevice objPlant = new LineDevice();
                        objPlant.Id = Guid.NewGuid();
                        if(lookUpLine.Text !="")
                        {
                            objPlant.LineCode = (lookUpLine.GetColumnValue("Code").ToString());

                        }
                        if (gridLookUpThietBi.Text !="")
                        {
                            objPlant.DeviceCode = (gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns["Code"]).ToString());

                        }
                        objPlant.Description = txtGhiChu.Text;
                        objPlant.Numerical = (int)calcThuTu.Value;
                        objPlant.CreatorId = objuser.Username;
                        objPlant.LastModifierId = objuser.Username;
                        objPlant.CreationTime = DateTime.Now;
                        objPlant.LastModificationTime = DateTime.Now;
                        objPlant.IsManager = chkSuDung.Checked;
                        objPlant.IsMain = chkisman.Checked;
                        objPlant.Active = chkActive.Checked;
                        LineDevice objerror = new LineDeviceRepository().Add(objPlant);
                        if (objerror.DeviceCode != "")
                        {
                            XtraMessageBox.Show("Thêm thiết bị " + (gridLookUpEdit1View.GetRowCellValue(gridLookUpEdit1View.FocusedRowHandle, gridLookUpEdit1View.Columns["Name"]).ToString()) + " thành công !", "Thông Báo");
                           
                            txtGhiChu.Text = "";
                            chkSuDung.Checked = false;
                        }
                        else
                        {
                            XtraMessageBox.Show("Thêm thất bại " + objerror.Description + "", "Thông Báo");
                        }
                    }
                    else
                    {
                        gridLookUpThietBi.ShowPopup();
                    }
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
    }
}
