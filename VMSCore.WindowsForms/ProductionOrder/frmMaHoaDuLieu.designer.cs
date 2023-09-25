namespace VMSCore.WindowsForms
{
    partial class frmMaHoaDuLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaHoaDuLieu));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.calcCodeDatao = new DevExpress.XtraEditors.CalcEdit();
            this.btnCodeNap = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnGenCode = new DevExpress.XtraEditors.SimpleButton();
            this.calcSoLuong = new DevExpress.XtraEditors.CalcEdit();
            this.txtLenh = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lctextLenh = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctextCodeTao = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lctextCodeDatao = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.calcCap = new DevExpress.XtraEditors.CalcEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calcCodeDatao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLenh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctextLenh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctextCodeTao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctextCodeDatao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.calcCap);
            this.layoutControl1.Controls.Add(this.btnImport);
            this.layoutControl1.Controls.Add(this.calcCodeDatao);
            this.layoutControl1.Controls.Add(this.btnCodeNap);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.btnGenCode);
            this.layoutControl1.Controls.Add(this.calcSoLuong);
            this.layoutControl1.Controls.Add(this.txtLenh);
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(396, 178, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // btnImport
            // 
            this.btnImport.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnImport.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.btnImport.StyleController = this.layoutControl1;
            this.btnImport.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // calcCodeDatao
            // 
            resources.ApplyResources(this.calcCodeDatao, "calcCodeDatao");
            this.calcCodeDatao.Name = "calcCodeDatao";
            this.calcCodeDatao.StyleController = this.layoutControl1;
            // 
            // btnCodeNap
            // 
            resources.ApplyResources(this.btnCodeNap, "btnCodeNap");
            this.btnCodeNap.Name = "btnCodeNap";
            this.btnCodeNap.StyleController = this.layoutControl1;
            this.btnCodeNap.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            // 
            // gridColumn1
            // 
            resources.ApplyResources(this.gridColumn1, "gridColumn1");
            this.gridColumn1.FieldName = "Sorted";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn5
            // 
            resources.ApplyResources(this.gridColumn5, "gridColumn5");
            this.gridColumn5.FieldName = "ProductOrder";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn2
            // 
            resources.ApplyResources(this.gridColumn2, "gridColumn2");
            this.gridColumn2.FieldName = "Code1";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            resources.ApplyResources(this.gridColumn3, "gridColumn3");
            this.gridColumn3.FieldName = "Code2";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // gridColumn4
            // 
            resources.ApplyResources(this.gridColumn4, "gridColumn4");
            this.gridColumn4.FieldName = "Active";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn6
            // 
            resources.ApplyResources(this.gridColumn6, "gridColumn6");
            this.gridColumn6.FieldName = "ID";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // btnGenCode
            // 
            resources.ApplyResources(this.btnGenCode, "btnGenCode");
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.StyleController = this.layoutControl1;
            this.btnGenCode.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // calcSoLuong
            // 
            resources.ApplyResources(this.calcSoLuong, "calcSoLuong");
            this.calcSoLuong.Name = "calcSoLuong";
            this.calcSoLuong.Properties.NullText = resources.GetString("calcSoLuong.Properties.NullText");
            this.calcSoLuong.StyleController = this.layoutControl1;
            // 
            // txtLenh
            // 
            resources.ApplyResources(this.txtLenh, "txtLenh");
            this.txtLenh.Name = "txtLenh";
            this.txtLenh.StyleController = this.layoutControl1;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lctextLenh,
            this.lctextCodeTao,
            this.emptySpaceItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem7,
            this.layoutControlItem1,
            this.lctextCodeDatao});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(999, 487);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lctextLenh
            // 
            this.lctextLenh.Control = this.txtLenh;
            this.lctextLenh.Location = new System.Drawing.Point(0, 0);
            this.lctextLenh.Name = "lctextLenh";
            this.lctextLenh.Size = new System.Drawing.Size(205, 26);
            resources.ApplyResources(this.lctextLenh, "lctextLenh");
            this.lctextLenh.TextSize = new System.Drawing.Size(81, 13);
            // 
            // lctextCodeTao
            // 
            this.lctextCodeTao.Control = this.calcSoLuong;
            this.lctextCodeTao.Location = new System.Drawing.Point(205, 0);
            this.lctextCodeTao.Name = "lctextCodeTao";
            this.lctextCodeTao.Size = new System.Drawing.Size(190, 26);
            resources.ApplyResources(this.lctextCodeTao, "lctextCodeTao");
            this.lctextCodeTao.TextSize = new System.Drawing.Size(81, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(969, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(10, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnGenCode;
            this.layoutControlItem3.Location = new System.Drawing.Point(729, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.gridControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(979, 441);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnCodeNap;
            this.layoutControlItem5.Location = new System.Drawing.Point(818, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(80, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // lctextCodeDatao
            // 
            this.lctextCodeDatao.Control = this.calcCodeDatao;
            this.lctextCodeDatao.Location = new System.Drawing.Point(395, 0);
            this.lctextCodeDatao.Name = "lctextCodeDatao";
            this.lctextCodeDatao.Size = new System.Drawing.Size(221, 26);
            resources.ApplyResources(this.lctextCodeDatao, "lctextCodeDatao");
            this.lctextCodeDatao.TextSize = new System.Drawing.Size(81, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnImport;
            this.layoutControlItem7.Location = new System.Drawing.Point(898, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(71, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // calcCap
            // 
            resources.ApplyResources(this.calcCap, "calcCap");
            this.calcCap.Name = "calcCap";
            this.calcCap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("calcEdit1.Properties.Buttons"))))});
            this.calcCap.Properties.NullText = resources.GetString("calcEdit1.Properties.NullText");
            this.calcCap.StyleController = this.layoutControl1;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.calcCap;
            this.layoutControlItem1.Location = new System.Drawing.Point(616, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(113, 26);
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(19, 13);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // frmMaHoaDuLieu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmMaHoaDuLieu";
            this.Load += new System.EventHandler(this.frmMaHoaDuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calcCodeDatao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLenh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctextLenh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctextCodeTao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lctextCodeDatao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calcCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnGenCode;
        private DevExpress.XtraEditors.CalcEdit calcSoLuong;
        private DevExpress.XtraEditors.TextEdit txtLenh;
        private DevExpress.XtraLayout.LayoutControlItem lctextLenh;
        private DevExpress.XtraLayout.LayoutControlItem lctextCodeTao;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnCodeNap;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.CalcEdit calcCodeDatao;
        private DevExpress.XtraLayout.LayoutControlItem lctextCodeDatao;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevExpress.XtraEditors.CalcEdit calcCap;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}