namespace VMSCore.WindowsForms
{
    partial class frmThemVaiTro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemVaiTro));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.chk_Active = new DevExpress.XtraEditors.CheckEdit();
            this.txtRoleName = new DevExpress.XtraEditors.TextEdit();
            this.txtRole_Description = new DevExpress.XtraEditors.TextEdit();
            this.txtRoleCode = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.NhomVT = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItemMa = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemDienGiai = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItemTen = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.NhomQuyen = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.gridControlChucNang = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Active.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRole_Description.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhomVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDienGiai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhomQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlChucNang);
            this.layoutControl1.Controls.Add(this.btnDong);
            this.layoutControl1.Controls.Add(this.btnLuu);
            this.layoutControl1.Controls.Add(this.chk_Active);
            this.layoutControl1.Controls.Add(this.txtRoleName);
            this.layoutControl1.Controls.Add(this.txtRole_Description);
            this.layoutControl1.Controls.Add(this.txtRoleCode);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnDong.Appearance.Font")));
            this.btnDong.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnDong, "btnDong");
            this.btnDong.Name = "btnDong";
            this.btnDong.StyleController = this.layoutControl1;
            this.btnDong.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnLuu.Appearance.Font")));
            this.btnLuu.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnLuu, "btnLuu");
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.StyleController = this.layoutControl1;
            this.btnLuu.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // chk_Active
            // 
            resources.ApplyResources(this.chk_Active, "chk_Active");
            this.chk_Active.Name = "chk_Active";
            this.chk_Active.Properties.Caption = resources.GetString("chk_Active.Properties.Caption");
            this.chk_Active.StyleController = this.layoutControl1;
            // 
            // txtRoleName
            // 
            resources.ApplyResources(this.txtRoleName, "txtRoleName");
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.StyleController = this.layoutControl1;
            // 
            // txtRole_Description
            // 
            resources.ApplyResources(this.txtRole_Description, "txtRole_Description");
            this.txtRole_Description.Name = "txtRole_Description";
            this.txtRole_Description.StyleController = this.layoutControl1;
            // 
            // txtRoleCode
            // 
            resources.ApplyResources(this.txtRoleCode, "txtRoleCode");
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.StyleController = this.layoutControl1;
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.NhomVT,
            this.NhomQuyen});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(739, 552);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // NhomVT
            // 
            resources.ApplyResources(this.NhomVT, "NhomVT");
            this.NhomVT.ExpandButtonVisible = true;
            this.NhomVT.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItemMa,
            this.layoutControlItemDienGiai,
            this.layoutControlItemTen,
            this.layoutControlItem4});
            this.NhomVT.Location = new System.Drawing.Point(0, 0);
            this.NhomVT.Name = "NhomVT";
            this.NhomVT.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.NhomVT.Size = new System.Drawing.Size(719, 85);
            // 
            // layoutControlItemMa
            // 
            this.layoutControlItemMa.Control = this.txtRoleCode;
            resources.ApplyResources(this.layoutControlItemMa, "layoutControlItemMa");
            this.layoutControlItemMa.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItemMa.Name = "layoutControlItemMa";
            this.layoutControlItemMa.Size = new System.Drawing.Size(351, 24);
            this.layoutControlItemMa.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemMa.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItemDienGiai
            // 
            this.layoutControlItemDienGiai.Control = this.txtRole_Description;
            resources.ApplyResources(this.layoutControlItemDienGiai, "layoutControlItemDienGiai");
            this.layoutControlItemDienGiai.Location = new System.Drawing.Point(351, 0);
            this.layoutControlItemDienGiai.Name = "layoutControlItemDienGiai";
            this.layoutControlItemDienGiai.Size = new System.Drawing.Size(352, 24);
            this.layoutControlItemDienGiai.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemDienGiai.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItemTen
            // 
            this.layoutControlItemTen.Control = this.txtRoleName;
            resources.ApplyResources(this.layoutControlItemTen, "layoutControlItemTen");
            this.layoutControlItemTen.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItemTen.Name = "layoutControlItemTen";
            this.layoutControlItemTen.Size = new System.Drawing.Size(351, 24);
            this.layoutControlItemTen.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItemTen.TextSize = new System.Drawing.Size(41, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.chk_Active;
            resources.ApplyResources(this.layoutControlItem4, "layoutControlItem4");
            this.layoutControlItem4.Location = new System.Drawing.Point(351, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(352, 24);
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // NhomQuyen
            // 
            resources.ApplyResources(this.NhomQuyen, "NhomQuyen");
            this.NhomQuyen.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.NhomQuyen.Location = new System.Drawing.Point(0, 85);
            this.NhomQuyen.Name = "NhomQuyen";
            this.NhomQuyen.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.NhomQuyen.Size = new System.Drawing.Size(719, 447);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnLuu;
            resources.ApplyResources(this.layoutControlItem6, "layoutControlItem6");
            this.layoutControlItem6.Location = new System.Drawing.Point(459, 377);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(124, 33);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(124, 33);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(124, 33);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnDong;
            resources.ApplyResources(this.layoutControlItem7, "layoutControlItem7");
            this.layoutControlItem7.Location = new System.Drawing.Point(583, 377);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(61, 33);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(120, 33);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Left;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            resources.ApplyResources(this.emptySpaceItem1, "emptySpaceItem1");
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 377);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(459, 33);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // gridControlChucNang
            // 
            gridLevelNode1.LevelTemplate = this.gridView4;
            gridLevelNode1.RelationName = "Level1";
            this.gridControlChucNang.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            resources.ApplyResources(this.gridControlChucNang, "gridControlChucNang");
            this.gridControlChucNang.MainView = this.gridView3;
            this.gridControlChucNang.Name = "gridControlChucNang";
            this.gridControlChucNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3,
            this.gridView4});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView3.GridControl = this.gridControlChucNang;
            this.gridView3.Name = "gridView3";
            this.gridView3.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView3_CustomDrawRowIndicator);
            // 
            // gridColumn5
            // 
            resources.ApplyResources(this.gridColumn5, "gridColumn5");
            this.gridColumn5.FieldName = "ObjectCode";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            resources.ApplyResources(this.gridColumn6, "gridColumn6");
            this.gridColumn6.FieldName = "Name";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            resources.ApplyResources(this.gridColumn7, "gridColumn7");
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            resources.ApplyResources(this.gridColumn8, "gridColumn8");
            this.gridColumn8.FieldName = "Active";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView4.GridControl = this.gridControlChucNang;
            this.gridView4.Name = "gridView4";
            this.gridView4.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView4_CustomDrawRowIndicator);
            // 
            // gridColumn9
            // 
            resources.ApplyResources(this.gridColumn9, "gridColumn9");
            this.gridColumn9.FieldName = "ButtonCode";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            resources.ApplyResources(this.gridColumn10, "gridColumn10");
            this.gridColumn10.FieldName = "ButtonCode";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn11
            // 
            resources.ApplyResources(this.gridColumn11, "gridColumn11");
            this.gridColumn11.FieldName = "ObjectCode";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn12
            // 
            resources.ApplyResources(this.gridColumn12, "gridColumn12");
            this.gridColumn12.FieldName = "RoleCode";
            this.gridColumn12.Name = "gridColumn12";
            // 
            // gridColumn13
            // 
            resources.ApplyResources(this.gridColumn13, "gridColumn13");
            this.gridColumn13.FieldName = "Active";
            this.gridColumn13.Name = "gridColumn13";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControlChucNang;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(703, 377);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // frmThemVaiTro
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.MinimizeBox = false;
            this.Name = "frmThemVaiTro";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_Active.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRole_Description.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhomVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemDienGiai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItemTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NhomQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup NhomVT;
        private DevExpress.XtraEditors.CheckEdit chk_Active;
        private DevExpress.XtraEditors.TextEdit txtRoleName;
        private DevExpress.XtraEditors.TextEdit txtRole_Description;
        private DevExpress.XtraEditors.TextEdit txtRoleCode;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemMa;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemDienGiai;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItemTen;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlGroup NhomQuyen;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl gridControlChucNang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}