
using System.Windows.Forms;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    partial class frmProductOther
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttondelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnProductOrther = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DeleteDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.DeteleDetailCode = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buttondelete});
            this.dataGridView1.Location = new System.Drawing.Point(180, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1316, 172);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // buttondelete
            // 
            this.buttondelete.HeaderText = "delete";
            this.buttondelete.Name = "buttondelete";
            this.buttondelete.ReadOnly = true;
            this.buttondelete.Text = "xóa";
            this.buttondelete.UseColumnTextForButtonValue = true;
            // 
            // btnProductOrther
            // 
            this.btnProductOrther.Location = new System.Drawing.Point(1, 1);
            this.btnProductOrther.Name = "btnProductOrther";
            this.btnProductOrther.Size = new System.Drawing.Size(156, 23);
            this.btnProductOrther.TabIndex = 1;
            this.btnProductOrther.Text = "Tạo lệnh sản xuất";
            this.btnProductOrther.UseVisualStyleBackColor = true;
            this.btnProductOrther.Click += new System.EventHandler(this.btnProductOrther_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeleteDetail});
            this.dataGridView2.Location = new System.Drawing.Point(180, 289);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1316, 150);
            this.dataGridView2.TabIndex = 2;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellValueChanged);
            // 
            // DeleteDetail
            // 
            this.DeleteDetail.HeaderText = "xóa";
            this.DeleteDetail.Name = "DeleteDetail";
            this.DeleteDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DeleteDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DeleteDetail.Text = "xóa";
            this.DeleteDetail.UseColumnTextForButtonValue = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeteleDetailCode});
            this.dataGridView3.Location = new System.Drawing.Point(180, 528);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1316, 150);
            this.dataGridView3.TabIndex = 3;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            this.dataGridView3.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
            // 
            // DeteleDetailCode
            // 
            this.DeteleDetailCode.HeaderText = "xóa";
            this.DeteleDetailCode.Name = "DeteleDetailCode";
            this.DeteleDetailCode.ReadOnly = true;
            this.DeteleDetailCode.Text = "xóa";
            this.DeteleDetailCode.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh sách lệnh sản xuất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Danh sách lệnh sản xuất chi tiết";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 562);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Danh sách mã lệnh sản xuất chi tiết";
            // 
            // frmProductOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 800);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnProductOrther);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmProductOther";
            this.Text = "frmProductOther";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnProductOrther;
        private DataGridViewButtonColumn buttondelete;
        private DataGridView dataGridView2;
        private DataGridViewButtonColumn DeleteDetail;
        private DataGridView dataGridView3;
        private DataGridViewButtonColumn DeteleDetailCode;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}