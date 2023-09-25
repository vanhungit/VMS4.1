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
    public partial class frmMapTBChaCon : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        Device objCart = new Device();
        DataTable dtable = new DataTable();
        public frmMapTBChaCon(string id)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            objCart = new DeviceRepository().GetByCode(id);
            txtMa.Text = objCart.Code;
            txtBarcode.Text = objCart.Name;
            dtable.Columns.Add("IDEQUIP", typeof(string));
            dtable.Columns.Add("KeyID_SON", typeof(string));
            dtable.Columns.Add("NameSon", typeof(string));
            dtable.Columns.Add("KeyPlant", typeof(string));
            dtable.Columns.Add("KeyID_DAD", typeof(string));
            dtable.Columns.Add("KeyID", typeof(string));
            if (objCart.Code.ToString() != "")
            {
                List<Device_Combo> obj = new Device_ComboRepository().GetAllByCondition(x => x.KeyID_DAD == objCart.Code);
                for (int i = 0; i < obj.Count; i++)
                {
                    ThemLoadData(obj[i]);
                }
            }
            gridControl1.DataSource = dtable;
            ReadXml_User();
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

        public void LoadData(Device obj)
        {
            DataRow row = dtable.NewRow();
            row["IDEQUIP"] = obj.Code;
            row["KeyID_SON"] = obj.Code;
            row["NameSon"] = obj.Name;
            row["KeyPlant"] = obj.CompanyCode;
            row["KeyID_DAD"] = objCart.Code;
            row["KeyID"] = "";
            dtable.Rows.Add(row);
        }
        public void ThemLoadData(Device_Combo obj)
        {
            DataRow row = dtable.NewRow();
            row["IDEQUIP"] = obj.KeyID_SON;
            row["KeyID_SON"] = obj.KeyID_SON;
            row["NameSon"] = new DeviceRepository().GetByCode(obj.KeyID_SON).Name;
            row["KeyPlant"] = new DeviceRepository().GetByCode(obj.KeyID_SON).CompanyCode;
            row["KeyID_DAD"] = obj.KeyID_DAD;
            row["KeyID"] = obj.KeyID_DAD;
            dtable.Rows.Add(row);
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmMapTBChaCon_ChonCon frm = new frmMapTBChaCon_ChonCon(this);
            frm.ShowDialog();
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn map thiết bị với sản phẩm con ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Nhập danh mục");

                Device_Combo jobCartdetail = new Device_Combo();
                {
                    if (dtable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtable.Rows.Count; i++)
                        {
                            DataRow row = dtable.Rows[i];
                            jobCartdetail = new Device_Combo();
                            jobCartdetail.KeyID_SON = "";
                            if (row["KeyID"].ToString().Trim() == "")
                            {
                                jobCartdetail.Id = Guid.NewGuid();
                                jobCartdetail.KeyID_DAD = objCart.Code;
                                jobCartdetail.KeyID_SON = (row["KeyID_SON"].ToString().Trim());
                                jobCartdetail.Sorted = 1;
                                jobCartdetail.Description = "";
                                jobCartdetail.CreateBy = objuser.Username;
                                jobCartdetail.ModifyBy = objuser.Username;
                                jobCartdetail.CreateDate = DateTime.Now;
                                jobCartdetail.ModifyDate = DateTime.Now;
                                jobCartdetail.Active = true;
                                Device_Combo objEnumdetail = new Device_ComboRepository().Add(jobCartdetail);
                                if (objEnumdetail.KeyID_SON == "")
                                {
                                    XtraMessageBox.Show("Thêm thiết bị con thất bại thứ  " + i + " " + objEnumdetail.Description, "Thông Báo");
                                    break;
                                }
                            }


                        }
                    }
                }

                WaitDialog.CloseWaitDialog();

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn muốn xóa thiết bị con này ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    new Device_ComboRepository().DeleteByCondition(x => x.KeyID_DAD == objCart.Code);
                   
                    dtable.Clear();
                    List<Device_Combo> obj = new Device_ComboRepository().GetAllByCondition(x => x.KeyID_DAD == objCart.Code);
                    for (int i = 0; i < obj.Count; i++)
                    {
                        ThemLoadData(obj[i]);
                    }
                }
                else
                    MessageBox.Show("Dữ liệu không tồn tại", "Thông báo");
            }
        }
    }
}
