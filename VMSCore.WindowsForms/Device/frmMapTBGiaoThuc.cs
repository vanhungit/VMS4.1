using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using SalesManager;
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
    public partial class frmMapTBGiaoThuc : Form
    {
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        Device objCart = new Device();
        DataTable dtable = new DataTable();
        public frmMapTBGiaoThuc(string id)
        {
            InitializeComponent();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            objCart = new DeviceRepository().GetByCode(id);
            txtMa.Text = objCart.Code;
            txtBarcode.Text = objCart.Name;
            dtable.Columns.Add("ID", typeof(string));
            dtable.Columns.Add("Data", typeof(string));
            dtable.Columns.Add("KeyProtocol", typeof(string));
            dtable.Columns.Add("Name", typeof(string));
            dtable.Columns.Add("KeyEquip", typeof(string));
            dtable.Columns.Add("KeyID", typeof(string));
            if (objCart.Code.ToString() != "")
            {
                List<Device_PROTOCOL> obj = new Device_PROTOCOLRepository().GetAllByCondition(x =>x.DeviceCode == objCart.Code);
                for (int i = 0; i < obj.Count; i++)
                {
                    ThemLoadData(obj[i]);
                }
            }
            gridControl1.DataSource = dtable;
            //HienThiChiNhanhHold();
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
        //public void HienThiChiNhanhHold()
        //{
        //    GridLookUpCN.DataSource = new PLANTEntity().GetListPLANT();
        //    GridLookUpCN.DisplayMember = "NamePlant";
        //    GridLookUpCN.ValueMember = "KeyID";
        //    GridLookUpCN.BestFitMode = BestFitMode.BestFitResizePopup;
        //    //gridLookUpChiNhanh.EditValue = gridLookUpChiNhanh.Properties.GetKeyValue(0);// chọn phần tử thứ nhấ
        //}
        public void LoadData(ProtocolParam obj)
        {
            DataRow row = dtable.NewRow();
            row["ID"] = obj.Code;
            row["Data"] = "";
            row["KeyProtocol"] = new ProtocolRepository().GetByCode(obj.ProtocolCode).Code;
            row["Name"] = new ProtocolRepository().GetByCode(obj.ProtocolCode).Name;
            row["KeyEquip"] = objCart.Code;
            row["KeyID"] = "";
            dtable.Rows.Add(row);
        }
        public void ThemLoadData(Device_PROTOCOL obj)
        {
            DataRow row = dtable.NewRow();
            row["ID"] = obj.ProtocolParamCode;
            row["Data"] = obj.Data;
            row["KeyProtocol"] = obj.ProtocolCode;
            row["Name"] = new ProtocolRepository().GetByCode(obj.ProtocolCode).Name;
            row["KeyEquip"] = obj.DeviceCode;
            row["KeyID"] = obj.Id;
            dtable.Rows.Add(row);
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            frmMapTBGiaoThuc_ChonGT frm = new frmMapTBGiaoThuc_ChonGT(this);
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
            if (XtraMessageBox.Show("Bạn muốn map thiết bị với giao thức ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Nhập danh mục");

                Device_PROTOCOL jobCartdetail = new Device_PROTOCOL();
                {
                    if(dtable.Rows.Count > 0)
                    {
                        for(int i =0;i < dtable.Rows.Count;i++)
                        {
                            DataRow row = dtable.Rows[i];
                            jobCartdetail = new Device_PROTOCOL();
                            if (row["KeyID"].ToString().Trim() == "")                            
                            {
                                jobCartdetail.Id = Guid.NewGuid();
                                jobCartdetail.DeviceCode = objCart.Code;
                                jobCartdetail.ProtocolCode = (row["KeyProtocol"].ToString().Trim());
                                jobCartdetail.Sorted =  1;
                                jobCartdetail.ProtocolParamCode = row["ID"].ToString().Trim();
                                jobCartdetail.Data = row["Data"].ToString().Trim();
                                jobCartdetail.Description = "";
                                jobCartdetail.CreatorId = objuser.Username;
                                jobCartdetail.LastModifierId = objuser.Username;
                                jobCartdetail.CreationTime = DateTime.Now;
                                jobCartdetail.LastModificationTime = DateTime.Now;
                                jobCartdetail.Active = true;
                                Device_PROTOCOL objEnumdetail = new Device_PROTOCOLRepository().Add(jobCartdetail);
                                if (objEnumdetail.DeviceCode == "")
                                {
                                    XtraMessageBox.Show("Thêm giao thức thất bại thứ  " + i + " " + objEnumdetail.Description, "Thông Báo");
                                    break;
                                }
                            }
                            else
                            {
                                jobCartdetail = new Device_PROTOCOLRepository().GetById(Guid.Parse(row["KeyID"].ToString().Trim()));
                                jobCartdetail.ProtocolParamCode = row["ID"].ToString().Trim();
                                jobCartdetail.Data = row["Data"].ToString().Trim();
                                Device_PROTOCOL objEnumdetail = new Device_PROTOCOLRepository().Update(jobCartdetail);
                                if (objEnumdetail.DeviceCode == "")
                                {
                                    XtraMessageBox.Show("Thêm giao thức thất bại thứ  " + i + " " + objEnumdetail.Description, "Thông Báo");
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
            if (XtraMessageBox.Show("Bạn muốn xóa giao thức này ?", "Cảnh Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (gridView1.RowCount > 0)
                {
                    new Device_PROTOCOLRepository().DeleteByCondition(x => x.DeviceCode == objCart.Code);
                    
                    dtable.Clear();
                    List<Device_PROTOCOL> obj = new Device_PROTOCOLRepository().GetAllByCondition(x => x.DeviceCode == objCart.Code);
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
