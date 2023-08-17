namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
  partial class frmGetCompanyByTaxNo
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
      this.btnFind = new System.Windows.Forms.Button();
      this.txtCompanyTax = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.dataGridViewCompanyByTax = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanyByTax)).BeginInit();
      this.SuspendLayout();
      // 
      // btnFind
      // 
      this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnFind.Location = new System.Drawing.Point(439, 1);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(121, 33);
      this.btnFind.TabIndex = 7;
      this.btnFind.Text = "Find...";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // txtCompanyTax
      // 
      this.txtCompanyTax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtCompanyTax.Location = new System.Drawing.Point(167, 6);
      this.txtCompanyTax.Name = "txtCompanyTax";
      this.txtCompanyTax.Size = new System.Drawing.Size(266, 26);
      this.txtCompanyTax.TabIndex = 6;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(39, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(122, 20);
      this.label1.TabIndex = 5;
      this.label1.Text = "Company Code:";
      // 
      // dataGridViewCompanyByTax
      // 
      this.dataGridViewCompanyByTax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewCompanyByTax.Location = new System.Drawing.Point(12, 36);
      this.dataGridViewCompanyByTax.Name = "dataGridViewCompanyByTax";
      this.dataGridViewCompanyByTax.Size = new System.Drawing.Size(778, 404);
      this.dataGridViewCompanyByTax.TabIndex = 4;
      // 
      // frmGetCompanyByTaxNo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(805, 456);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.txtCompanyTax);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.dataGridViewCompanyByTax);
      this.Name = "frmGetCompanyByTaxNo";
      this.Text = "frmGetCompanyByTaxNo";
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompanyByTax)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.TextBox txtCompanyTax;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView dataGridViewCompanyByTax;
  }
}