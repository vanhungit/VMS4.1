
namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    partial class frmWorkshop
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchWorkShopName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dlSearchPlanName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dlSeachCompanyName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWorkShopId = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtWorkShopNameEn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWorkShopName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dlPlanName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dlCompanyName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Companyinfor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantInfor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkShopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkShopCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkShopNameEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearchWorkShopName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dlSearchPlanName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dlSeachCompanyName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 125);
            this.panel1.TabIndex = 0;
            // 
            // txtSearchWorkShopName
            // 
            this.txtSearchWorkShopName.Location = new System.Drawing.Point(87, 61);
            this.txtSearchWorkShopName.Name = "txtSearchWorkShopName";
            this.txtSearchWorkShopName.Size = new System.Drawing.Size(228, 20);
            this.txtSearchWorkShopName.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(240, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "tên xưởng";
            // 
            // dlSearchPlanName
            // 
            this.dlSearchPlanName.FormattingEnabled = true;
            this.dlSearchPlanName.Location = new System.Drawing.Point(87, 31);
            this.dlSearchPlanName.Name = "dlSearchPlanName";
            this.dlSearchPlanName.Size = new System.Drawing.Size(231, 21);
            this.dlSearchPlanName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "tên nhà máy";
            // 
            // dlSeachCompanyName
            // 
            this.dlSeachCompanyName.FormattingEnabled = true;
            this.dlSeachCompanyName.Location = new System.Drawing.Point(87, 4);
            this.dlSeachCompanyName.Name = "dlSeachCompanyName";
            this.dlSeachCompanyName.Size = new System.Drawing.Size(231, 21);
            this.dlSeachCompanyName.TabIndex = 1;
            this.dlSeachCompanyName.SelectedIndexChanged += new System.EventHandler(this.dlSeachCompanyName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "tên công ty";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtWorkShopId);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.cbActive);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtWorkShopNameEn);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtWorkShopName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dlPlanName);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dlCompanyName);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(380, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 146);
            this.panel2.TabIndex = 1;
            // 
            // txtWorkShopId
            // 
            this.txtWorkShopId.Location = new System.Drawing.Point(435, 67);
            this.txtWorkShopId.Name = "txtWorkShopId";
            this.txtWorkShopId.Size = new System.Drawing.Size(100, 20);
            this.txtWorkShopId.TabIndex = 22;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(467, 120);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(386, 120);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(285, 120);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(413, 67);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 19;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "trạng thái";
            // 
            // txtWorkShopNameEn
            // 
            this.txtWorkShopNameEn.Location = new System.Drawing.Point(413, 34);
            this.txtWorkShopNameEn.Name = "txtWorkShopNameEn";
            this.txtWorkShopNameEn.Size = new System.Drawing.Size(133, 20);
            this.txtWorkShopNameEn.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "tên tiếng anh của xưởng ";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(413, 5);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(133, 20);
            this.txtDescription.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(282, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "mô tả";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(79, 93);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(195, 20);
            this.txtCode.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "mã xưởng";
            // 
            // txtWorkShopName
            // 
            this.txtWorkShopName.Location = new System.Drawing.Point(79, 64);
            this.txtWorkShopName.Name = "txtWorkShopName";
            this.txtWorkShopName.Size = new System.Drawing.Size(195, 20);
            this.txtWorkShopName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "tên xưởng";
            // 
            // dlPlanName
            // 
            this.dlPlanName.FormattingEnabled = true;
            this.dlPlanName.Location = new System.Drawing.Point(79, 31);
            this.dlPlanName.Name = "dlPlanName";
            this.dlPlanName.Size = new System.Drawing.Size(195, 21);
            this.dlPlanName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "tên nhà máy";
            // 
            // dlCompanyName
            // 
            this.dlCompanyName.FormattingEnabled = true;
            this.dlCompanyName.Location = new System.Drawing.Point(79, 4);
            this.dlCompanyName.Name = "dlCompanyName";
            this.dlCompanyName.Size = new System.Drawing.Size(192, 21);
            this.dlCompanyName.TabIndex = 7;
            this.dlCompanyName.SelectedIndexChanged += new System.EventHandler(this.dlCompanyName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "tên công ty";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Companyinfor,
            this.CompanyName,
            this.PlantName,
            this.PlantCode,
            this.PlantInfor,
            this.WorkShopName,
            this.WorkShopCode,
            this.WorkShopNameEn,
            this.Description,
            this.CreationTime,
            this.Active,
            this.CompanyId,
            this.PlantId});
            this.dataGridView1.Location = new System.Drawing.Point(13, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(946, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Companyinfor
            // 
            this.Companyinfor.DataPropertyName = "Companyinfor";
            this.Companyinfor.HeaderText = "tên công ty";
            this.Companyinfor.Name = "Companyinfor";
            this.Companyinfor.ReadOnly = true;
            this.Companyinfor.Width = 150;
            // 
            // CompanyName
            // 
            this.CompanyName.HeaderText = "CompanyName";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            this.CompanyName.Visible = false;
            // 
            // PlantName
            // 
            this.PlantName.DataPropertyName = "PlantName";
            this.PlantName.HeaderText = "PlantName";
            this.PlantName.Name = "PlantName";
            this.PlantName.ReadOnly = true;
            this.PlantName.Visible = false;
            // 
            // PlantCode
            // 
            this.PlantCode.DataPropertyName = "PlantCode";
            this.PlantCode.HeaderText = "PlantCode";
            this.PlantCode.Name = "PlantCode";
            this.PlantCode.ReadOnly = true;
            this.PlantCode.Visible = false;
            // 
            // PlantInfor
            // 
            this.PlantInfor.DataPropertyName = "PlantInfor";
            this.PlantInfor.HeaderText = "tên nhà máy";
            this.PlantInfor.Name = "PlantInfor";
            this.PlantInfor.ReadOnly = true;
            this.PlantInfor.Width = 150;
            // 
            // WorkShopName
            // 
            this.WorkShopName.DataPropertyName = "Name";
            this.WorkShopName.HeaderText = "Tên xưởng";
            this.WorkShopName.Name = "WorkShopName";
            this.WorkShopName.ReadOnly = true;
            // 
            // WorkShopCode
            // 
            this.WorkShopCode.DataPropertyName = "Code";
            this.WorkShopCode.HeaderText = "xưởng code";
            this.WorkShopCode.Name = "WorkShopCode";
            this.WorkShopCode.ReadOnly = true;
            // 
            // WorkShopNameEn
            // 
            this.WorkShopNameEn.HeaderText = "tên tiếng anh";
            this.WorkShopNameEn.Name = "WorkShopNameEn";
            this.WorkShopNameEn.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // CreationTime
            // 
            this.CreationTime.DataPropertyName = "CreationTime";
            this.CreationTime.HeaderText = "ngày tạo";
            this.CreationTime.Name = "CreationTime";
            this.CreationTime.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "trạng thái";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CompanyId
            // 
            this.CompanyId.DataPropertyName = "CompanyId";
            this.CompanyId.HeaderText = "CompanyId";
            this.CompanyId.Name = "CompanyId";
            this.CompanyId.ReadOnly = true;
            this.CompanyId.Visible = false;
            // 
            // PlantId
            // 
            this.PlantId.DataPropertyName = "PlantId";
            this.PlantId.HeaderText = "PlantId";
            this.PlantId.Name = "PlantId";
            this.PlantId.ReadOnly = true;
            this.PlantId.Visible = false;
            // 
            // frmWorkshop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmWorkshop";
            this.Text = "frmWorkshop";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dlSearchPlanName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dlSeachCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtWorkShopNameEn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtWorkShopName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox dlPlanName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dlCompanyName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearchWorkShopName;
        private System.Windows.Forms.TextBox txtWorkShopId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Companyinfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantInfor;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkShopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkShopCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkShopNameEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantId;
    }
}