using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;

using DevExpress.XtraEditors;
using System.Data.SqlClient;
using MicrosoftHelper;
using System.Xml;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmCapNhatVaiTro : Form
    {
        DataTable dtable = new DataTable();
        //SYS_GROUP objSYS_GROUP = new SYS_GROUP();
        string configFile = @"XMLTimer.xml";
        string NgonNgu = "";
        frmPhanQuyen main;
        EntityDataContext _context = new EntityDataContext();
        Role objRole = new Role();
        DataSet dataSet11 = new DataSet();
        string globalRole = "";
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public frmCapNhatVaiTro(frmPhanQuyen frm, string RoleCode)
        {
            InitializeComponent();
            main = frm;
            objRole = new RoleRepository().GetOneByCondition(x => x.Code == RoleCode);
            InitPhanQuyenButton(RoleCode);
            globalRole = RoleCode;
            gridView4.Invalidate();
            gridView4.IndicatorWidth = 30;
            gridView3.Invalidate();
            gridView3.IndicatorWidth = 30;
            txtRoleCode.Text = objRole.Code;
            txtRoleName.Text = objRole.Name;
            txtRole_Description.Text = objRole.Description;
            //NgonNgu = XMLParser(configFile, "Table/Language");
            //if (NgonNgu == "EN")
            //{
            //    this.Text = "Add Role";
            //    NhomVT.Text = "Role Information";
            //    layoutControlItemMa.Text = "Code";
            //    layoutControlItemTen.Text = "Name";
            //    chk_Active.Text = "Activate";
            //    NhomQuyen.Text = "Authority";
            //    treeList1.Columns["Chức Năng"].Caption = "Function";
            //    treeList1.Columns["Truy Cập"].Caption = "Access";
            //    btnLuu.Text = "Save";
            //    btnDong.Text = "Close";
            //    layoutControlItemDienGiai.Text = "Description";


            //}
            //else
            //{
            //    this.Text = "Thêm Vai Trò";
            //    NhomVT.Text = "Thông Tin Vai Trò";
            //    layoutControlItemMa.Text = "Mã";
            //    layoutControlItemTen.Text = "Tên";
            //    chk_Active.Text = "Kích hoạt";
            //    NhomQuyen.Text = "Quyền Hạn";
            //    treeList1.Columns["Chức Năng"].Caption = "Chức Năng";
            //    treeList1.Columns["Truy Cập"].Caption = "Truy Cập";
            //    btnLuu.Text = "Lưu";
            //    btnDong.Text = "Đóng";
            //    layoutControlItemDienGiai.Text = "Diễn giải";

            //}
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
        public void InitPhanQuyenButton(string Role)
        {
            gridControlChucNang.RefreshDataSource();
            SqlDataAdapter AdapterGroupUser = new SqlDataAdapter("select RoleObjectButtonMapping.ObjectCode, ObjectEntity.Name, RoleObjectButtonMapping.RoleCode, RoleObjectButtonMapping.Active  from RoleObjectButtonMapping left join ObjectEntity on RoleObjectButtonMapping.ObjectCode = ObjectEntity.Code " +
            " where RoleObjectButtonMapping.Active = 1 and RoleCode ='" + Role + "' group by RoleObjectButtonMapping.ObjectCode, ObjectEntity.Name, RoleObjectButtonMapping.RoleCode, RoleObjectButtonMapping.Active", _context.Database.Connection.ConnectionString);
            SqlDataAdapter AdapterUser = new SqlDataAdapter("select Id, Code, ObjectCode, ButtonCode, RoleCode, Active from RoleObjectButtonMapping where RoleCode ='" + Role + "'", _context.Database.Connection.ConnectionString);
            AdapterGroupUser.Fill(dataSet11, "SYS_GROUP");
            AdapterUser.Fill(dataSet11, "SYS_USER");
            DataColumn keyColumn = dataSet11.Tables["SYS_GROUP"].Columns["ObjectCode"];
            DataColumn foreignKeyColumn = dataSet11.Tables["SYS_USER"].Columns["ObjectCode"];
            dataSet11.Relations.Add("Detail", keyColumn, foreignKeyColumn);
            gridControlChucNang.DataSource = dataSet11.Tables["SYS_GROUP"];
            gridControlChucNang.ForceInitialize();
            gridControlChucNang.LevelTree.Nodes.Add("Detail", gridView4);
            gridView4.PopulateColumns(dataSet11.Tables["SYS_USER"]);
            gridView4.Columns["ObjectCode"].VisibleIndex = -1;
            gridView4.Columns["ObjectCode"].Caption = "Mã Nhóm";
            //gridView4.Columns["Name"].Caption = "Tên Đăng Nhập";
            gridView4.Columns["RoleCode"].Caption = "Vai Trò";
            //gridView2.Columns["Description"].Caption = "Diễn Giải";
            //gridView2.Columns["Active"].Caption = "Kích Hoạt";
            gridControlChucNang.Refresh();
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
        public void HienThiVaiTro(TreeList tl)
        {
            tl.BeginUnboundLoad();
            string noderoot_0 = "";
            string noderoot_1 = "";
            string noderoot_2 = "";
            TreeListNode parentForRootNodes = null;
            //DataTable TableGroupUser = new SYS_USER_RULEController().SYS_GetbyLevel("admin", "", 0);
            //foreach (DataRow datarow in TableGroupUser.Rows)
            //{
            //    noderoot_0 = datarow["Object_Name"].ToString();
            //    TreeListNode rootNode = tl.AppendNode(new object[] { noderoot_0, true, true, true, true, true, true, true, datarow["Object_ID"].ToString() }, parentForRootNodes);
            //    DataTable TableUser = new SYS_USER_RULEController().SYS_GetbyLevel("admin", datarow["Object_ID"].ToString(), 1);
            //    foreach (DataRow datarowchild in TableUser.Rows)
            //    {
            //        noderoot_1 = datarowchild["Object_Name"].ToString();
            //        TreeListNode rootNode1 = tl.AppendNode(new object[] { noderoot_1, true, true, true, true, true, true, true, datarowchild["Object_ID"].ToString() }, rootNode);
            //        DataTable Tablechild = new SYS_USER_RULEController().SYS_GetbyLevel("admin", datarowchild["Object_ID"].ToString(), 2);
            //        foreach (DataRow rowchild in Tablechild.Rows)
            //        {
            //            noderoot_2 = rowchild["Object_Name"].ToString();
            //            TreeListNode rootNode2 = tl.AppendNode(new object[] { noderoot_2, true, true, true, true, true, true, true, rowchild["Object_ID"].ToString() }, rootNode1);
            //            DataTable Tablechild2 = new SYS_USER_RULEController().SYS_GetbyLevel("admin", rowchild["Object_ID"].ToString(), 3);
            //            foreach (DataRow rowchild2 in Tablechild2.Rows)
            //            {
            //                tl.AppendNode(new object[] { rowchild2["Object_Name"].ToString(), true, true, true, true, true, true, true, rowchild2["Object_ID"].ToString() }, rootNode2);
            //            }
            //            tl.EndUnboundLoad();
            //        }
            //    }

            //}

        }
        //public void InsertUserRule(SYS_USER_RULE obj)
        //{
        //    SqlConnection con = new SqlConnection(DataProvider.ConnectionString);
        //    con.Open();
        //    SqlCommand sqlcmd = con.CreateCommand();
        //    sqlcmd.CommandText = "Insert Into SYS_USER_RULE ( Goup_ID, Object_ID, Rule_ID, AllowAdd, AllowDelete, AllowEdit, AllowAccess, AllowPrint, AllowExport, AllowImport, Active ) values ( @Goup_ID, @Object_ID, @Rule_ID, @AllowAdd, @AllowDelete, @AllowEdit, @AllowAccess, @AllowPrint, @AllowExport, @AllowImport, @Active) ";
        //    sqlcmd.Parameters.Add("@Goup_ID", SqlDbType.VarChar,20).Value = obj.Goup_ID;
        //    sqlcmd.Parameters.Add("@Object_ID", SqlDbType.VarChar, 50).Value = obj.Object_ID;
        //    sqlcmd.Parameters.Add("@Rule_ID", SqlDbType.VarChar, 20).Value = obj.Rule_ID;
        //    sqlcmd.Parameters.Add("@AllowAdd", SqlDbType.Bit).Value = obj.AllowAdd;
        //    sqlcmd.Parameters.Add("@AllowDelete", SqlDbType.Bit).Value = obj.AllowDelete;
        //    sqlcmd.Parameters.Add("@AllowEdit", SqlDbType.Bit).Value = obj.AllowEdit;
        //    sqlcmd.Parameters.Add("@AllowAccess", SqlDbType.Bit).Value = obj.AllowAccess;
        //    sqlcmd.Parameters.Add("@AllowPrint", SqlDbType.Bit).Value = obj.AllowPrint;
        //    sqlcmd.Parameters.Add("@AllowExport", SqlDbType.Bit).Value = obj.AllowExport;
        //    sqlcmd.Parameters.Add("@AllowImport", SqlDbType.Bit).Value = obj.AllowImport;
        //    sqlcmd.Parameters.Add("@Active", SqlDbType.Bit).Value = obj.Active;
        //    sqlcmd.ExecuteNonQuery();
        //    con.Close();
        //}
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            objRole.Code = txtRoleCode.Text;
            objRole.Name = txtRoleName.Text;
            objRole.Description = txtRole_Description.Text;
            objRole.CreatorId = objuser.Username;
            objRole.CreationTime = DateTime.Now;
            objRole.LastModifierId = objuser.Username;
            objRole.LastModificationTime = DateTime.Now;
            objRole.Active = chk_Active.Checked;
            Role rsrole = new RoleRepository().Update(objRole);
            if (rsrole.Code != null)
            {
                List<RoleObjectButtonMapping> listdetail = new List<RoleObjectButtonMapping>();
                RoleObjectButtonMapping detail = new RoleObjectButtonMapping();
                for (int i = 0; i < dataSet11.Tables["SYS_USER"].Rows.Count; i++)
                {
                    detail = new RoleObjectButtonMapping();
                    detail.Id = new Guid(dataSet11.Tables["SYS_USER"].Rows[i]["Id"].ToString());
                    detail.Code = dataSet11.Tables["SYS_USER"].Rows[i]["Code"].ToString();
                    detail.RoleCode = objRole.Code;
                    detail.ObjectCode = dataSet11.Tables["SYS_USER"].Rows[i]["ObjectCode"].ToString();
                    detail.ButtonCode = dataSet11.Tables["SYS_USER"].Rows[i]["ButtonCode"].ToString();
                    detail.CreatorId = objuser.Username;
                    detail.CreationTime = DateTime.Now;
                    detail.LastModifierId = objuser.Username;
                    detail.LastModificationTime = DateTime.Now;
                    detail.Active = bool.Parse(dataSet11.Tables["SYS_USER"].Rows[i]["Active"].ToString());
                    new RoleObjectButtonMappingRepository().Update(detail);
                    //listdetail.Add(detail);
                }
                if (listdetail.Count > 0)
                {
                    //string rslist = new RoleObjectButtonMappingRepository().Update(listdetail);
                    //if (rslist == "1")
                    {
                        XtraMessageBox.Show("Thêm phân quyền thành công !", "Thông Báo");
                    }
                }
            }
            //for (int i = 0; i < dataSet11.Tables["SYS_USER"].Rows.Count; i++)
            //{
            //    XtraMessageBox.Show(dataSet11.Tables["SYS_USER"].Rows[i]["ButtonCode"].ToString() +"-"+ dataSet11.Tables["SYS_USER"].Rows[i]["Active"].ToString(), "Thông Báo");
            //}
            ////dataSet11.Tables["SYS_USER"].Select("ButtonCode = edit").SetField("Actice", 1);
            ////IEnumerable<DataRow> rows = dataSet11.Tables["SYS_USER"].Rows.Cast<DataRow>().Where(r => r["ButtonCode"].ToString() == "edit");
            ////// Loop through the rows and change the name.
            ////rows.ToList().ForEach(r => r.SetField("Active", false));
            ////gridControlChucNang.Refresh();
            ////InitPhanQuyenButton(globalRole);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView3_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }

       
      

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //txtRole_Description.Text = gridView3.FocusedRowHandle.ToString();
            //if (gridView3.FocusedRowHandle >= 0)
            //{
            //    string id = (gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Active"]).ToString());
            //    txtRole_Description.Text = id;

            //}
            //IEnumerable<DataRow> rows = dataSet11.Tables["SYS_USER"].Rows.Cast<DataRow>().Where(r => r["ButtonCode"].ToString() == "edit");
            //// Loop through the rows and change the name.
            //rows.ToList().ForEach(r => r.SetField("Active", false));
            //gridControlChucNang.Refresh();

        }

        private void gridView4_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            txtRole_Description.Text = gridView4.FocusedRowHandle.ToString();

        }

       
        private void gridView3_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            GridView view = sender as GridView;
            string cellValue = e.RowHandle + " " + view.GetRowCellValue(e.RowHandle, view.Columns["Active"]).ToString();
            txtRole_Description.Text = cellValue;
            if (e.Button == MouseButtons.Left)
            {
                this.Text = string.Format("Cell value: {0}", view.GetRowCellValue(e.RowHandle, e.Column));
            }
        }



        //private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    string cellValue = e.RowHandle + " " + view.GetRowCellValue(e.RowHandle, view.Columns["Active"]).ToString();
        //    txtRole_Description.Text = cellValue;
        //}

        //private void gridView3_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    GridView view = sender as GridView;
        //    string cellValue = e.Value.ToString() + " " + view.GetRowCellValue(e.RowHandle, view.Columns["Active"]).ToString();
        //    txtRole_Description.Text = cellValue;
        //}
    }
}
