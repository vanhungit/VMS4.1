
namespace VMSCore.Demo.WindowsForms.MasterData.District
{
    partial class frmDeleteDistrict
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
            this.btnDeleteDistrict = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1DistrictId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnDeleteDistrict
            // 
            this.btnDeleteDistrict.Location = new System.Drawing.Point(15, 66);
            this.btnDeleteDistrict.Name = "btnDeleteDistrict";
            this.btnDeleteDistrict.Size = new System.Drawing.Size(235, 27);
            this.btnDeleteDistrict.TabIndex = 0;
            this.btnDeleteDistrict.Text = "DELETE";
            this.btnDeleteDistrict.UseVisualStyleBackColor = true;
            this.btnDeleteDistrict.Click += new System.EventHandler(this.btnDeleteDistrict_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DistrictId";
            // 
            // textBox1DistrictId
            // 
            this.textBox1DistrictId.Location = new System.Drawing.Point(80, 25);
            this.textBox1DistrictId.Name = "textBox1DistrictId";
            this.textBox1DistrictId.Size = new System.Drawing.Size(170, 20);
            this.textBox1DistrictId.TabIndex = 2;
            // 
            // frmDeleteDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 105);
            this.Controls.Add(this.textBox1DistrictId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteDistrict);
            this.Name = "frmDeleteDistrict";
            this.Text = "frmDeleteDistrict";
            this.Load += new System.EventHandler(this.frmDeleteDistrict_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteDistrict;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1DistrictId;
    }
}