
namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    partial class frmObjectButtonMapping
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
            this.dlSearchObjectEntity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtObjectId = new System.Windows.Forms.TextBox();
            this.gvButton = new System.Windows.Forms.DataGridView();
            this.buttonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dlOjectEntity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvObjectEnity = new System.Windows.Forms.DataGridView();
            this.ObjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ObjectNameEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectEnity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dlSearchObjectEntity);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 76);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(416, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dlSearchObjectEntity
            // 
            this.dlSearchObjectEntity.FormattingEnabled = true;
            this.dlSearchObjectEntity.Location = new System.Drawing.Point(89, 16);
            this.dlSearchObjectEntity.Name = "dlSearchObjectEntity";
            this.dlSearchObjectEntity.Size = new System.Drawing.Size(402, 21);
            this.dlSearchObjectEntity.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "tên màn hình";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtObjectId);
            this.panel2.Controls.Add(this.gvButton);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.dlOjectEntity);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(555, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(540, 465);
            this.panel2.TabIndex = 1;
            // 
            // txtObjectId
            // 
            this.txtObjectId.Location = new System.Drawing.Point(127, 62);
            this.txtObjectId.Name = "txtObjectId";
            this.txtObjectId.Size = new System.Drawing.Size(292, 20);
            this.txtObjectId.TabIndex = 11;
            this.txtObjectId.Visible = false;
            // 
            // gvButton
            // 
            this.gvButton.AllowUserToAddRows = false;
            this.gvButton.AllowUserToDeleteRows = false;
            this.gvButton.AllowUserToOrderColumns = true;
            this.gvButton.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvButton.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buttonId,
            this.buttonName,
            this.IsChecked});
            this.gvButton.Location = new System.Drawing.Point(125, 122);
            this.gvButton.Name = "gvButton";
            this.gvButton.Size = new System.Drawing.Size(294, 370);
            this.gvButton.TabIndex = 10;
            // 
            // buttonId
            // 
            this.buttonId.DataPropertyName = "ButtonId";
            this.buttonId.HeaderText = "";
            this.buttonId.Name = "buttonId";
            this.buttonId.Visible = false;
            this.buttonId.Width = 50;
            // 
            // buttonName
            // 
            this.buttonName.DataPropertyName = "ButtonName";
            this.buttonName.HeaderText = "tên nut";
            this.buttonName.Name = "buttonName";
            this.buttonName.ReadOnly = true;
            this.buttonName.Width = 150;
            // 
            // IsChecked
            // 
            this.IsChecked.DataPropertyName = "InUse";
            this.IsChecked.HeaderText = "sử dụng?";
            this.IsChecked.Name = "IsChecked";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "danh sách các nút";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(439, 122);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dlOjectEntity
            // 
            this.dlOjectEntity.FormattingEnabled = true;
            this.dlOjectEntity.Location = new System.Drawing.Point(127, 25);
            this.dlOjectEntity.Name = "dlOjectEntity";
            this.dlOjectEntity.Size = new System.Drawing.Size(292, 21);
            this.dlOjectEntity.TabIndex = 4;
            this.dlOjectEntity.SelectedIndexChanged += new System.EventHandler(this.dlOjectEntity_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "tên màn hình";
            // 
            // gvObjectEnity
            // 
            this.gvObjectEnity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvObjectEnity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjectId,
            this.ObjectName,
            this.ObjectNameEn,
            this.Description,
            this.Active});
            this.gvObjectEnity.Location = new System.Drawing.Point(9, 134);
            this.gvObjectEnity.Name = "gvObjectEnity";
            this.gvObjectEnity.Size = new System.Drawing.Size(494, 343);
            this.gvObjectEnity.TabIndex = 2;
            this.gvObjectEnity.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvObjectEnity_CellClick);
            // 
            // ObjectId
            // 
            this.ObjectId.DataPropertyName = "ObjectId";
            this.ObjectId.HeaderText = "";
            this.ObjectId.Name = "ObjectId";
            this.ObjectId.Visible = false;
            // 
            // ObjectName
            // 
            this.ObjectName.DataPropertyName = "ObjectName";
            this.ObjectName.HeaderText = "tên màn hình";
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.Width = 150;
            // 
            // ObjectNameEn
            // 
            this.ObjectNameEn.DataPropertyName = "ObjectNameEn";
            this.ObjectNameEn.HeaderText = "tên tiếng anh";
            this.ObjectNameEn.Name = "ObjectNameEn";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "mô tả";
            this.Description.Name = "Description";
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "trạng thái";
            this.Active.Name = "Active";
            this.Active.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Active.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmObjectButtonMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 489);
            this.Controls.Add(this.gvObjectEnity);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmObjectButtonMapping";
            this.Text = "frmObjectButtonMapping";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvObjectEnity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox dlSearchObjectEntity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox dlOjectEntity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObjectId;
        private System.Windows.Forms.DataGridView gvObjectEnity;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn buttonName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectNameEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
    }
}