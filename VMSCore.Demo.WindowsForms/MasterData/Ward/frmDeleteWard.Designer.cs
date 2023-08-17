
namespace VMSCore.Demo.WindowsForms.MasterData.Ward
{
    partial class frmDeleteWard
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1WardId = new System.Windows.Forms.TextBox();
            this.DELETE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WardId";
            // 
            // textBox1WardId
            // 
            this.textBox1WardId.Location = new System.Drawing.Point(93, 19);
            this.textBox1WardId.Name = "textBox1WardId";
            this.textBox1WardId.Size = new System.Drawing.Size(181, 20);
            this.textBox1WardId.TabIndex = 1;
            // 
            // DELETE
            // 
            this.DELETE.Location = new System.Drawing.Point(29, 55);
            this.DELETE.Name = "DELETE";
            this.DELETE.Size = new System.Drawing.Size(245, 31);
            this.DELETE.TabIndex = 2;
            this.DELETE.Text = "DELETE";
            this.DELETE.UseVisualStyleBackColor = true;
            this.DELETE.Click += new System.EventHandler(this.DELETE_Click);
            // 
            // frmDeleteWard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 98);
            this.Controls.Add(this.DELETE);
            this.Controls.Add(this.textBox1WardId);
            this.Controls.Add(this.label1);
            this.Name = "frmDeleteWard";
            this.Text = "frmDeleteWard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1WardId;
        private System.Windows.Forms.Button DELETE;
    }
}