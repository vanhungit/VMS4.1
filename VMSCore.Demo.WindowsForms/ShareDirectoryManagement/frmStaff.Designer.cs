
namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    partial class frmStaff
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnStaff1 = new System.Windows.Forms.Button();
            this.btnStaff2 = new System.Windows.Forms.Button();
            this.btnStaff3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // btnStaff1
            // 
            this.btnStaff1.Location = new System.Drawing.Point(34, 28);
            this.btnStaff1.Name = "btnStaff1";
            this.btnStaff1.Size = new System.Drawing.Size(75, 23);
            this.btnStaff1.TabIndex = 3;
            this.btnStaff1.Text = "nhân viên 1";
            this.btnStaff1.UseVisualStyleBackColor = true;
            this.btnStaff1.Click += new System.EventHandler(this.btnStaff1_Click);
            // 
            // btnStaff2
            // 
            this.btnStaff2.Location = new System.Drawing.Point(132, 28);
            this.btnStaff2.Name = "btnStaff2";
            this.btnStaff2.Size = new System.Drawing.Size(75, 23);
            this.btnStaff2.TabIndex = 4;
            this.btnStaff2.Text = "nhân viên 2";
            this.btnStaff2.UseVisualStyleBackColor = true;
            this.btnStaff2.Click += new System.EventHandler(this.btnStaff2_Click);
            // 
            // btnStaff3
            // 
            this.btnStaff3.Location = new System.Drawing.Point(229, 28);
            this.btnStaff3.Name = "btnStaff3";
            this.btnStaff3.Size = new System.Drawing.Size(75, 23);
            this.btnStaff3.TabIndex = 5;
            this.btnStaff3.Text = "nhân viên 3";
            this.btnStaff3.UseVisualStyleBackColor = true;
            this.btnStaff3.Click += new System.EventHandler(this.btnStaff3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(817, 294);
            this.dataGridView1.TabIndex = 6;
            
            // 
            // frmStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 394);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnStaff3);
            this.Controls.Add(this.btnStaff2);
            this.Controls.Add(this.btnStaff1);
            this.Controls.Add(this.label3);
            this.Name = "frmStaff";
            this.Text = "frmStaff";
            this.Load += new System.EventHandler(this.frmStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStaff1;
        private System.Windows.Forms.Button btnStaff2;
        private System.Windows.Forms.Button btnStaff3;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}