namespace VMSCore.Demo.WindowsForms
{
    partial class frmMain
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.systemCRUDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.getByCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getByTaxNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonConfigPage = new System.Windows.Forms.Button();
            this.btnConfigObjectEntity = new System.Windows.Forms.Button();
            this.btnCompanyConfig = new System.Windows.Forms.Button();
            this.btnPlant = new System.Windows.Forms.Button();
            this.btnWorkShop = new System.Windows.Forms.Button();
            this.btnObjectBtnMap = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnRole = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPlantSiteMapping = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnProductOther = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnStaffPermission = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemCRUDToolStripMenuItem,
            this.masterDataToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(737, 33);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // systemCRUDToolStripMenuItem
            // 
            this.systemCRUDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.systemCRUDToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemCRUDToolStripMenuItem.Name = "systemCRUDToolStripMenuItem";
            this.systemCRUDToolStripMenuItem.Size = new System.Drawing.Size(186, 29);
            this.systemCRUDToolStripMenuItem.Text = "Quản Lý Đối Tượng";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.getByCodeToolStripMenuItem,
            this.getByTaxNoToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(164, 30);
            this.toolStripMenuItem2.Text = "Company";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(197, 30);
            this.toolStripMenuItem3.Text = "Get All";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // getByCodeToolStripMenuItem
            // 
            this.getByCodeToolStripMenuItem.Name = "getByCodeToolStripMenuItem";
            this.getByCodeToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.getByCodeToolStripMenuItem.Text = "Get By Code";
            this.getByCodeToolStripMenuItem.Click += new System.EventHandler(this.getByCodeToolStripMenuItem_Click);
            // 
            // getByTaxNoToolStripMenuItem
            // 
            this.getByTaxNoToolStripMenuItem.Name = "getByTaxNoToolStripMenuItem";
            this.getByTaxNoToolStripMenuItem.Size = new System.Drawing.Size(197, 30);
            this.getByTaxNoToolStripMenuItem.Text = "Get By TaxNo";
            this.getByTaxNoToolStripMenuItem.Click += new System.EventHandler(this.getByTaxNoToolStripMenuItem_Click);
            // 
            // masterDataToolStripMenuItem
            // 
            this.masterDataToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            this.masterDataToolStripMenuItem.Size = new System.Drawing.Size(200, 29);
            this.masterDataToolStripMenuItem.Text = "Quản Lý Master Data";
            this.masterDataToolStripMenuItem.Click += new System.EventHandler(this.masterDataToolStripMenuItem_Click);
            // 
            // buttonConfigPage
            // 
            this.buttonConfigPage.Location = new System.Drawing.Point(12, 61);
            this.buttonConfigPage.Name = "buttonConfigPage";
            this.buttonConfigPage.Size = new System.Drawing.Size(103, 23);
            this.buttonConfigPage.TabIndex = 1;
            this.buttonConfigPage.Text = "Cài đặt nút ";
            this.buttonConfigPage.UseVisualStyleBackColor = true;
            this.buttonConfigPage.Click += new System.EventHandler(this.buttonConfigPage_Click);
            // 
            // btnConfigObjectEntity
            // 
            this.btnConfigObjectEntity.Location = new System.Drawing.Point(13, 91);
            this.btnConfigObjectEntity.Name = "btnConfigObjectEntity";
            this.btnConfigObjectEntity.Size = new System.Drawing.Size(102, 23);
            this.btnConfigObjectEntity.TabIndex = 2;
            this.btnConfigObjectEntity.Text = "Cài đặt màn hình";
            this.btnConfigObjectEntity.UseVisualStyleBackColor = true;
            this.btnConfigObjectEntity.Click += new System.EventHandler(this.btnConfigObjectEntity_Click);
            // 
            // btnCompanyConfig
            // 
            this.btnCompanyConfig.Location = new System.Drawing.Point(13, 120);
            this.btnCompanyConfig.Name = "btnCompanyConfig";
            this.btnCompanyConfig.Size = new System.Drawing.Size(102, 23);
            this.btnCompanyConfig.TabIndex = 3;
            this.btnCompanyConfig.Text = "Cài đặt công ty";
            this.btnCompanyConfig.UseVisualStyleBackColor = true;
            this.btnCompanyConfig.Click += new System.EventHandler(this.btnCompanyConfig_Click);
            // 
            // btnPlant
            // 
            this.btnPlant.Location = new System.Drawing.Point(12, 149);
            this.btnPlant.Name = "btnPlant";
            this.btnPlant.Size = new System.Drawing.Size(102, 23);
            this.btnPlant.TabIndex = 4;
            this.btnPlant.Text = "Cài đặt nhà máy";
            this.btnPlant.UseVisualStyleBackColor = true;
            this.btnPlant.Click += new System.EventHandler(this.btnPlant_Click);
            // 
            // btnWorkShop
            // 
            this.btnWorkShop.Location = new System.Drawing.Point(13, 178);
            this.btnWorkShop.Name = "btnWorkShop";
            this.btnWorkShop.Size = new System.Drawing.Size(102, 23);
            this.btnWorkShop.TabIndex = 5;
            this.btnWorkShop.Text = "Cài đặt xưởng";
            this.btnWorkShop.UseVisualStyleBackColor = true;
            this.btnWorkShop.Click += new System.EventHandler(this.btnWorkShop_Click);
            // 
            // btnObjectBtnMap
            // 
            this.btnObjectBtnMap.Location = new System.Drawing.Point(13, 241);
            this.btnObjectBtnMap.Name = "btnObjectBtnMap";
            this.btnObjectBtnMap.Size = new System.Drawing.Size(102, 23);
            this.btnObjectBtnMap.TabIndex = 6;
            this.btnObjectBtnMap.Text = "Cài đặt màn hình nút";
            this.btnObjectBtnMap.UseVisualStyleBackColor = true;
            this.btnObjectBtnMap.Click += new System.EventHandler(this.btnObjectBtnMap_Click);
            // 
            // btnLine
            // 
            this.btnLine.Location = new System.Drawing.Point(13, 207);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(102, 23);
            this.btnLine.TabIndex = 7;
            this.btnLine.Text = "Cài đặt chuyền";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnRole
            // 
            this.btnRole.Location = new System.Drawing.Point(18, 13);
            this.btnRole.Name = "btnRole";
            this.btnRole.Size = new System.Drawing.Size(102, 23);
            this.btnRole.TabIndex = 8;
            this.btnRole.Text = "Cài đặt chức vụ";
            this.btnRole.UseVisualStyleBackColor = true;
            this.btnRole.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPlantSiteMapping);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnChangePassword);
            this.panel1.Controls.Add(this.btnProductOther);
            this.panel1.Controls.Add(this.btnreport);
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Controls.Add(this.btnRole);
            this.panel1.Location = new System.Drawing.Point(186, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 204);
            this.panel1.TabIndex = 9;
            // 
            // btnPlantSiteMapping
            // 
            this.btnPlantSiteMapping.Location = new System.Drawing.Point(147, 147);
            this.btnPlantSiteMapping.Name = "btnPlantSiteMapping";
            this.btnPlantSiteMapping.Size = new System.Drawing.Size(116, 23);
            this.btnPlantSiteMapping.TabIndex = 15;
            this.btnPlantSiteMapping.Text = "tạo nhà máy liên kết site";
            this.btnPlantSiteMapping.UseVisualStyleBackColor = true;
            this.btnPlantSiteMapping.Click += new System.EventHandler(this.btnPlantSiteMapping_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(147, 103);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(116, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "cài đặt site";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(147, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "quản lý đăng nhập";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(147, 13);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(102, 23);
            this.btnChangePassword.TabIndex = 12;
            this.btnChangePassword.Text = "Thay đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = true;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnProductOther
            // 
            this.btnProductOther.Location = new System.Drawing.Point(18, 118);
            this.btnProductOther.Name = "btnProductOther";
            this.btnProductOther.Size = new System.Drawing.Size(102, 23);
            this.btnProductOther.TabIndex = 11;
            this.btnProductOther.Text = "Cài đặt vận hành";
            this.btnProductOther.UseVisualStyleBackColor = true;
            this.btnProductOther.Click += new System.EventHandler(this.btnProductOther_Click);
            // 
            // btnreport
            // 
            this.btnreport.Location = new System.Drawing.Point(18, 71);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(102, 23);
            this.btnreport.TabIndex = 10;
            this.btnreport.Text = "Xuất báo cáo";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(18, 42);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(102, 23);
            this.btnStaff.TabIndex = 9;
            this.btnStaff.Text = "Tạo nhân viên";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 61);
            this.button1.TabIndex = 10;
            this.button1.Text = "Phân quyền nút bấm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 285);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 54);
            this.button2.TabIndex = 11;
            this.button2.Text = "Tạo phần quyền nút bấm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(301, 285);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 54);
            this.button3.TabIndex = 12;
            this.button3.Text = "Phân quyền chức vụ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(451, 286);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 54);
            this.button4.TabIndex = 13;
            this.button4.Text = "Phân quyền nhân viên chức vụ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnStaffPermission
            // 
            this.btnStaffPermission.Location = new System.Drawing.Point(13, 359);
            this.btnStaffPermission.Name = "btnStaffPermission";
            this.btnStaffPermission.Size = new System.Drawing.Size(119, 54);
            this.btnStaffPermission.TabIndex = 14;
            this.btnStaffPermission.Text = "Phân quyền nhân viên";
            this.btnStaffPermission.UseVisualStyleBackColor = true;
            this.btnStaffPermission.Click += new System.EventHandler(this.btnStaffPermission_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(737, 499);
            this.Controls.Add(this.btnStaffPermission);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.btnObjectBtnMap);
            this.Controls.Add(this.btnWorkShop);
            this.Controls.Add(this.btnPlant);
            this.Controls.Add(this.btnCompanyConfig);
            this.Controls.Add(this.btnConfigObjectEntity);
            this.Controls.Add(this.buttonConfigPage);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem cRUDToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem getAllToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.MenuStrip menuStrip2;
    private System.Windows.Forms.ToolStripMenuItem systemCRUDToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    private System.Windows.Forms.ToolStripMenuItem getByCodeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem getByTaxNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterDataToolStripMenuItem;
        private System.Windows.Forms.Button buttonConfigPage;
        private System.Windows.Forms.Button btnConfigObjectEntity;
        private System.Windows.Forms.Button btnCompanyConfig;
        private System.Windows.Forms.Button btnPlant;
        private System.Windows.Forms.Button btnWorkShop;
        private System.Windows.Forms.Button btnObjectBtnMap;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnRole;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button btnreport;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnStaffPermission;
        private System.Windows.Forms.Button btnProductOther;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnPlantSiteMapping;
    }
}

