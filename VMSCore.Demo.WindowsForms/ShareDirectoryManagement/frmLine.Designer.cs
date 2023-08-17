
namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    partial class frmLine
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchLineName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLineName = new System.Windows.Forms.TextBox();
            this.txtLineId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbActvie = new System.Windows.Forms.CheckBox();
            this.txtLineCode = new System.Windows.Forms.TextBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dlCompanyId = new System.Windows.Forms.ComboBox();
            this.dlWorkShopId = new System.Windows.Forms.ComboBox();
            this.dlPlantId = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.LineId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkshopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkshopId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchLineName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 96);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(227, 41);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchLineName
            // 
            this.txtSearchLineName.Location = new System.Drawing.Point(75, 14);
            this.txtSearchLineName.Name = "txtSearchLineName";
            this.txtSearchLineName.Size = new System.Drawing.Size(226, 20);
            this.txtSearchLineName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "tên chuyền";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtLineName);
            this.panel2.Controls.Add(this.txtLineId);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cbActvie);
            this.panel2.Controls.Add(this.txtLineCode);
            this.panel2.Controls.Add(this.TxtDescription);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.dlCompanyId);
            this.panel2.Controls.Add(this.dlWorkShopId);
            this.panel2.Controls.Add(this.dlPlantId);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(364, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(720, 203);
            this.panel2.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(496, 168);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(586, 168);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(392, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLineName
            // 
            this.txtLineName.Location = new System.Drawing.Point(93, 120);
            this.txtLineName.Name = "txtLineName";
            this.txtLineName.Size = new System.Drawing.Size(121, 20);
            this.txtLineName.TabIndex = 15;
            // 
            // txtLineId
            // 
            this.txtLineId.Location = new System.Drawing.Point(392, 120);
            this.txtLineId.Name = "txtLineId";
            this.txtLineId.Size = new System.Drawing.Size(100, 20);
            this.txtLineId.TabIndex = 14;
            this.txtLineId.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "trạng thái";
            // 
            // cbActvie
            // 
            this.cbActvie.AutoSize = true;
            this.cbActvie.Location = new System.Drawing.Point(392, 87);
            this.cbActvie.Name = "cbActvie";
            this.cbActvie.Size = new System.Drawing.Size(15, 14);
            this.cbActvie.TabIndex = 12;
            this.cbActvie.UseVisualStyleBackColor = true;
            // 
            // txtLineCode
            // 
            this.txtLineCode.Location = new System.Drawing.Point(392, 47);
            this.txtLineCode.Name = "txtLineCode";
            this.txtLineCode.Size = new System.Drawing.Size(100, 20);
            this.txtLineCode.TabIndex = 11;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Location = new System.Drawing.Point(392, 15);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(100, 20);
            this.TxtDescription.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(301, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "mã chuyền";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "mô tả";
            // 
            // dlCompanyId
            // 
            this.dlCompanyId.FormattingEnabled = true;
            this.dlCompanyId.Location = new System.Drawing.Point(93, 15);
            this.dlCompanyId.Name = "dlCompanyId";
            this.dlCompanyId.Size = new System.Drawing.Size(121, 21);
            this.dlCompanyId.TabIndex = 7;
            this.dlCompanyId.SelectedIndexChanged += new System.EventHandler(this.dlCompanyId_SelectedIndexChanged);
            // 
            // dlWorkShopId
            // 
            this.dlWorkShopId.FormattingEnabled = true;
            this.dlWorkShopId.Location = new System.Drawing.Point(93, 79);
            this.dlWorkShopId.Name = "dlWorkShopId";
            this.dlWorkShopId.Size = new System.Drawing.Size(121, 21);
            this.dlWorkShopId.TabIndex = 5;
            // 
            // dlPlantId
            // 
            this.dlPlantId.FormattingEnabled = true;
            this.dlPlantId.Location = new System.Drawing.Point(93, 45);
            this.dlPlantId.Name = "dlPlantId";
            this.dlPlantId.Size = new System.Drawing.Size(121, 21);
            this.dlPlantId.TabIndex = 4;
            this.dlPlantId.SelectedIndexChanged += new System.EventHandler(this.dlPlantId_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "tên chuyền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "tên xưởng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "tên nhà máy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "tên công ty";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineId,
            this.CompanyName,
            this.PlantName,
            this.WorkshopName,
            this.LineName,
            this.LineCode,
            this.WorkshopId,
            this.CompanyId,
            this.PlantId,
            this.Description,
            this.Active});
            this.dataGridView1.Location = new System.Drawing.Point(13, 218);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1071, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowClick);
            // 
            // LineId
            // 
            this.LineId.DataPropertyName = "LineId";
            this.LineId.HeaderText = "LineId";
            this.LineId.Name = "LineId";
            this.LineId.ReadOnly = true;
            this.LineId.Visible = false;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompanyName";
            this.CompanyName.HeaderText = "tên công ty";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // PlantName
            // 
            this.PlantName.DataPropertyName = "PlantName";
            this.PlantName.HeaderText = "tên nhà máy";
            this.PlantName.Name = "PlantName";
            this.PlantName.ReadOnly = true;
            // 
            // WorkshopName
            // 
            this.WorkshopName.DataPropertyName = "WorkShopName";
            this.WorkshopName.HeaderText = "tên xưởng";
            this.WorkshopName.Name = "WorkshopName";
            this.WorkshopName.ReadOnly = true;
            // 
            // LineName
            // 
            this.LineName.DataPropertyName = "LineName";
            this.LineName.HeaderText = "tên chuyền";
            this.LineName.Name = "LineName";
            this.LineName.ReadOnly = true;
            // 
            // LineCode
            // 
            this.LineCode.DataPropertyName = "LineCode";
            this.LineCode.HeaderText = "mã chuyền";
            this.LineCode.Name = "LineCode";
            this.LineCode.ReadOnly = true;
            // 
            // WorkshopId
            // 
            this.WorkshopId.DataPropertyName = "WorkShopId";
            this.WorkshopId.HeaderText = "WorkshopId";
            this.WorkshopId.Name = "WorkshopId";
            this.WorkshopId.ReadOnly = true;
            this.WorkshopId.Visible = false;
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
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
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
            // frmLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 479);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmLine";
            this.Text = "frmLine";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchLineName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLineName;
        private System.Windows.Forms.TextBox txtLineId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbActvie;
        private System.Windows.Forms.TextBox txtLineCode;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox dlCompanyId;
        private System.Windows.Forms.ComboBox dlWorkShopId;
        private System.Windows.Forms.ComboBox dlPlantId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkshopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkshopId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}