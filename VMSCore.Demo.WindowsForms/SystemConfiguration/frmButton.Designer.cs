
namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    partial class frmButton
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
      this.components = new System.ComponentModel.Container();
      this.panel2 = new System.Windows.Forms.Panel();
      this.button2 = new System.Windows.Forms.Button();
      this.searchVN = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.isActive = new System.Windows.Forms.CheckBox();
      this.label6 = new System.Windows.Forms.Label();
      this.idButton = new System.Windows.Forms.TextBox();
      this.addNew = new System.Windows.Forms.Button();
      this.update = new System.Windows.Forms.Button();
      this.descriptionField = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.nameButtonEN = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.delete = new System.Windows.Forms.Button();
      this.nameButtonVN = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.listButton = new System.Windows.Forms.DataGridView();
      this.ButtonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ButtonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ButtonNameEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.buttonRepositoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listButton)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.buttonRepositoryBindingSource)).BeginInit();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.button2);
      this.panel2.Controls.Add(this.searchVN);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Location = new System.Drawing.Point(13, 12);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(313, 97);
      this.panel2.TabIndex = 1;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(225, 47);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 2;
      this.button2.Text = "tìm kiếm";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // searchVN
      // 
      this.searchVN.Location = new System.Drawing.Point(112, 13);
      this.searchVN.Name = "searchVN";
      this.searchVN.Size = new System.Drawing.Size(188, 20);
      this.searchVN.TabIndex = 1;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(16, 20);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(90, 13);
      this.label4.TabIndex = 0;
      this.label4.Text = "Tên nút tiếng việt";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.isActive);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Controls.Add(this.idButton);
      this.panel1.Controls.Add(this.addNew);
      this.panel1.Controls.Add(this.update);
      this.panel1.Controls.Add(this.descriptionField);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.nameButtonEN);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.delete);
      this.panel1.Controls.Add(this.nameButtonVN);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Location = new System.Drawing.Point(383, 12);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(497, 181);
      this.panel1.TabIndex = 4;
      // 
      // isActive
      // 
      this.isActive.AutoSize = true;
      this.isActive.Location = new System.Drawing.Point(131, 114);
      this.isActive.Name = "isActive";
      this.isActive.Size = new System.Drawing.Size(15, 14);
      this.isActive.TabIndex = 11;
      this.isActive.UseVisualStyleBackColor = true;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(19, 114);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(96, 13);
      this.label6.TabIndex = 10;
      this.label6.Text = "Trang thái sử dụng";
      // 
      // idButton
      // 
      this.idButton.Location = new System.Drawing.Point(23, 146);
      this.idButton.Name = "idButton";
      this.idButton.Size = new System.Drawing.Size(100, 20);
      this.idButton.TabIndex = 9;
      this.idButton.Visible = false;
      // 
      // addNew
      // 
      this.addNew.Location = new System.Drawing.Point(154, 146);
      this.addNew.Name = "addNew";
      this.addNew.Size = new System.Drawing.Size(75, 23);
      this.addNew.TabIndex = 8;
      this.addNew.Text = "thêm mới";
      this.addNew.UseVisualStyleBackColor = true;
      this.addNew.Click += new System.EventHandler(this.addNew_Click);
      // 
      // update
      // 
      this.update.Location = new System.Drawing.Point(278, 146);
      this.update.Name = "update";
      this.update.Size = new System.Drawing.Size(75, 23);
      this.update.TabIndex = 7;
      this.update.Text = "sửa";
      this.update.UseVisualStyleBackColor = true;
      this.update.Click += new System.EventHandler(this.update_Click);
      // 
      // descriptionField
      // 
      this.descriptionField.Location = new System.Drawing.Point(131, 84);
      this.descriptionField.Name = "descriptionField";
      this.descriptionField.Size = new System.Drawing.Size(335, 20);
      this.descriptionField.TabIndex = 6;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(19, 84);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(34, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Mô tả";
      // 
      // nameButtonEN
      // 
      this.nameButtonEN.Location = new System.Drawing.Point(131, 47);
      this.nameButtonEN.Name = "nameButtonEN";
      this.nameButtonEN.Size = new System.Drawing.Size(335, 20);
      this.nameButtonEN.TabIndex = 4;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(94, 13);
      this.label1.TabIndex = 3;
      this.label1.Text = "Tên nút tiếng anh ";
      // 
      // delete
      // 
      this.delete.Location = new System.Drawing.Point(392, 146);
      this.delete.Name = "delete";
      this.delete.Size = new System.Drawing.Size(75, 23);
      this.delete.TabIndex = 2;
      this.delete.Text = "xóa";
      this.delete.UseVisualStyleBackColor = true;
      this.delete.Click += new System.EventHandler(this.delete_Click);
      // 
      // nameButtonVN
      // 
      this.nameButtonVN.Location = new System.Drawing.Point(131, 13);
      this.nameButtonVN.Name = "nameButtonVN";
      this.nameButtonVN.Size = new System.Drawing.Size(335, 20);
      this.nameButtonVN.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(90, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Tên nút tiếng việt";
      // 
      // listButton
      // 
      this.listButton.AllowUserToAddRows = false;
      this.listButton.AllowUserToDeleteRows = false;
      this.listButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.listButton.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ButtonId,
            this.ButtonName,
            this.ButtonNameEn,
            this.Description,
            this.Active});
      this.listButton.Location = new System.Drawing.Point(13, 187);
      this.listButton.Name = "listButton";
      this.listButton.Size = new System.Drawing.Size(941, 150);
      this.listButton.TabIndex = 5;
      this.listButton.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
      // 
      // ButtonId
      // 
      this.ButtonId.DataPropertyName = "ButtonId";
      this.ButtonId.HeaderText = "id";
      this.ButtonId.Name = "ButtonId";
      this.ButtonId.Visible = false;
      // 
      // ButtonName
      // 
      this.ButtonName.DataPropertyName = "ButtonName";
      this.ButtonName.HeaderText = "tên nút tiếng việt";
      this.ButtonName.Name = "ButtonName";
      this.ButtonName.ReadOnly = true;
      this.ButtonName.Width = 200;
      // 
      // ButtonNameEn
      // 
      this.ButtonNameEn.DataPropertyName = "ButtonNameEn";
      this.ButtonNameEn.HeaderText = "tên nut tiếng anh";
      this.ButtonNameEn.Name = "ButtonNameEn";
      this.ButtonNameEn.ReadOnly = true;
      this.ButtonNameEn.Width = 200;
      // 
      // Description
      // 
      this.Description.DataPropertyName = "Description";
      this.Description.HeaderText = "mô tả";
      this.Description.Name = "Description";
      this.Description.ReadOnly = true;
      this.Description.Width = 400;
      // 
      // Active
      // 
      this.Active.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.Active.DataPropertyName = "Active";
      this.Active.HeaderText = "trạng thái sử dụng";
      this.Active.Name = "Active";
      this.Active.ReadOnly = true;
      this.Active.Width = 67;
      // 
      // buttonRepositoryBindingSource
      // 
      this.buttonRepositoryBindingSource.DataSource = typeof(VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations.ButtonRepository);
      // 
      // frmButton
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(978, 450);
      this.Controls.Add(this.listButton);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Name = "frmButton";
      this.Text = "Button";
      this.Load += new System.EventHandler(this.frmButton_Load);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.listButton)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.buttonRepositoryBindingSource)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox searchVN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource buttonRepositoryBindingSource;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox descriptionField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameButtonEN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox nameButtonVN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addNew;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DataGridView listButton;
        private System.Windows.Forms.TextBox idButton;
        private System.Windows.Forms.CheckBox isActive;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonNameEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}