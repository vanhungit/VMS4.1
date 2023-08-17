namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
  partial class frmGetAllCompany
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
      this.dataGridViewCompany = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).BeginInit();
      this.SuspendLayout();
      // 
      // dataGridViewCompany
      // 
      this.dataGridViewCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewCompany.Location = new System.Drawing.Point(0, 1);
      this.dataGridViewCompany.Name = "dataGridViewCompany";
      this.dataGridViewCompany.Size = new System.Drawing.Size(799, 445);
      this.dataGridViewCompany.TabIndex = 0;
      // 
      // frmCompany
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.dataGridViewCompany);
      this.Name = "frmGetAllCompany";
      this.Text = "frmGetAllCompany";
      this.Load += new System.EventHandler(this.frmGetAllCompany_Load);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompany)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView dataGridViewCompany;
  }
}