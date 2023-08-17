
namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    partial class frmPlant
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
            this.label2 = new System.Windows.Forms.Label();
            this.dlSearchCompayName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPlantId = new System.Windows.Forms.TextBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPlantNameEn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlantName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtPlantCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearchPlantName = new System.Windows.Forms.TextBox();
            this.PlantId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlantNameEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CompanyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlCompanyName = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtSearchPlantName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dlSearchCompayName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 111);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(178, 76);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "tên nhà máy";
            // 
            // dlSearchCompayName
            // 
            this.dlSearchCompayName.FormattingEnabled = true;
            this.dlSearchCompayName.Location = new System.Drawing.Point(106, 17);
            this.dlSearchCompayName.Name = "dlSearchCompayName";
            this.dlSearchCompayName.Size = new System.Drawing.Size(147, 21);
            this.dlSearchCompayName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "tên công ty";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dlCompanyName);
            this.panel2.Controls.Add(this.txtPlantCode);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtPlantId);
            this.panel2.Controls.Add(this.cbActive);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtDescription);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtPlantNameEn);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtPlantName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(275, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 137);
            this.panel2.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(506, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(425, 111);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(344, 111);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.Text = "thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPlantId
            // 
            this.txtPlantId.Location = new System.Drawing.Point(377, 74);
            this.txtPlantId.Name = "txtPlantId";
            this.txtPlantId.Size = new System.Drawing.Size(205, 20);
            this.txtPlantId.TabIndex = 10;
            this.txtPlantId.Visible = false;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(346, 78);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 9;
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "trạng thái";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(346, 45);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(236, 20);
            this.txtDescription.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(266, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "mô tả";
            // 
            // txtPlantNameEn
            // 
            this.txtPlantNameEn.Location = new System.Drawing.Point(137, 76);
            this.txtPlantNameEn.Name = "txtPlantNameEn";
            this.txtPlantNameEn.Size = new System.Drawing.Size(121, 20);
            this.txtPlantNameEn.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "tên xưởng tiếng anh";
            // 
            // txtPlantName
            // 
            this.txtPlantName.Location = new System.Drawing.Point(137, 45);
            this.txtPlantName.Name = "txtPlantName";
            this.txtPlantName.Size = new System.Drawing.Size(121, 20);
            this.txtPlantName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "tên nhà máy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "tên công ty";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlantId,
            this.CompanyName,
            this.PlantName,
            this.PlantCode,
            this.PlantNameEn,
            this.Description,
            this.Active,
            this.CompanyId});
            this.dataGridView1.Location = new System.Drawing.Point(13, 184);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(847, 254);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtPlantCode
            // 
            this.txtPlantCode.Location = new System.Drawing.Point(346, 10);
            this.txtPlantCode.Name = "txtPlantCode";
            this.txtPlantCode.Size = new System.Drawing.Size(236, 20);
            this.txtPlantCode.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Mã nhà máy";
            // 
            // txtSearchPlantName
            // 
            this.txtSearchPlantName.Location = new System.Drawing.Point(106, 52);
            this.txtSearchPlantName.Name = "txtSearchPlantName";
            this.txtSearchPlantName.Size = new System.Drawing.Size(147, 20);
            this.txtSearchPlantName.TabIndex = 5;
            // 
            // PlantId
            // 
            this.PlantId.DataPropertyName = "PlantId";
            this.PlantId.HeaderText = "";
            this.PlantId.Name = "PlantId";
            this.PlantId.Visible = false;
            // 
            // CompanyName
            // 
            this.CompanyName.DataPropertyName = "CompayInfor";
            this.CompanyName.HeaderText = "tên công ty";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Width = 150;
            // 
            // PlantName
            // 
            this.PlantName.DataPropertyName = "PlantName";
            this.PlantName.HeaderText = "tên nhà máy";
            this.PlantName.Name = "PlantName";
            this.PlantName.Width = 150;
            // 
            // PlantCode
            // 
            this.PlantCode.DataPropertyName = "PlantCode";
            this.PlantCode.HeaderText = "mã nhà máy";
            this.PlantCode.Name = "PlantCode";
            // 
            // PlantNameEn
            // 
            this.PlantNameEn.DataPropertyName = "PlantNameEn";
            this.PlantNameEn.HeaderText = "tên tiếng anh nhà máy";
            this.PlantNameEn.Name = "PlantNameEn";
            this.PlantNameEn.Width = 150;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "mô tả";
            this.Description.Name = "Description";
            this.Description.Width = 150;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "trạng thái";
            this.Active.Name = "Active";
            // 
            // CompanyId
            // 
            this.CompanyId.DataPropertyName = "CompanyId";
            this.CompanyId.HeaderText = "";
            this.CompanyId.Name = "CompanyId";
            this.CompanyId.Visible = false;
            // 
            // dlCompanyName
            // 
            this.dlCompanyName.FormattingEnabled = true;
            this.dlCompanyName.Location = new System.Drawing.Point(137, 9);
            this.dlCompanyName.Name = "dlCompanyName";
            this.dlCompanyName.Size = new System.Drawing.Size(121, 21);
            this.dlCompanyName.TabIndex = 16;
            // 
            // frmPlant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPlant";
            this.Text = "frmPlant";
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dlSearchCompayName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPlantId;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPlantNameEn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlantName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtPlantCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearchPlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlantNameEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyId;
        private System.Windows.Forms.ComboBox dlCompanyName;
    }
}