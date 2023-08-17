namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
    partial class frmGetCompanyByCode
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
            this.dataGridViewCompanyByCode = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanyByCode)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCompanyByCode
            // 
            this.dataGridViewCompanyByCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompanyByCode.Location = new System.Drawing.Point(12, 34);
            this.dataGridViewCompanyByCode.Name = "dataGridViewCompanyByCode";
            this.dataGridViewCompanyByCode.Size = new System.Drawing.Size(778, 404);
            this.dataGridViewCompanyByCode.TabIndex = 0;
            this.dataGridViewCompanyByCode.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCompanyByCode_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company Code:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyCode.Location = new System.Drawing.Point(167, 4);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(266, 26);
            this.txtCompanyCode.TabIndex = 2;
            this.txtCompanyCode.TextChanged += new System.EventHandler(this.txtCompanyCode_TextChanged);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(439, -1);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(121, 33);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find...";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // frmGetCompanyByCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtCompanyCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCompanyByCode);
            this.Name = "frmGetCompanyByCode";
            this.Text = "frmGetCompanyByCode";
            this.Load += new System.EventHandler(this.frmGetCompanyByCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanyByCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCompanyByCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyCode;
        private System.Windows.Forms.Button btnFind;
    }
}