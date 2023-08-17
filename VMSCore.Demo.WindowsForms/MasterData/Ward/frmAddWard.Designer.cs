
namespace VMSCore.Demo.WindowsForms.MasterData.Ward
{
    partial class frmAddWard
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1WardCode = new System.Windows.Forms.TextBox();
            this.textBox2Appellation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3WardName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4DistrictId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5OrderIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(30, 235);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(252, 36);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "ADD";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WardCode";
            // 
            // textBox1WardCode
            // 
            this.textBox1WardCode.Location = new System.Drawing.Point(113, 21);
            this.textBox1WardCode.Name = "textBox1WardCode";
            this.textBox1WardCode.Size = new System.Drawing.Size(169, 20);
            this.textBox1WardCode.TabIndex = 2;
            // 
            // textBox2Appellation
            // 
            this.textBox2Appellation.Location = new System.Drawing.Point(113, 60);
            this.textBox2Appellation.Name = "textBox2Appellation";
            this.textBox2Appellation.Size = new System.Drawing.Size(169, 20);
            this.textBox2Appellation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appellation";
            // 
            // textBox3WardName
            // 
            this.textBox3WardName.Location = new System.Drawing.Point(113, 101);
            this.textBox3WardName.Name = "textBox3WardName";
            this.textBox3WardName.Size = new System.Drawing.Size(169, 20);
            this.textBox3WardName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WardName";
            // 
            // textBox4DistrictId
            // 
            this.textBox4DistrictId.Location = new System.Drawing.Point(113, 143);
            this.textBox4DistrictId.Name = "textBox4DistrictId";
            this.textBox4DistrictId.Size = new System.Drawing.Size(169, 20);
            this.textBox4DistrictId.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DistrictId";
            // 
            // textBox5OrderIndex
            // 
            this.textBox5OrderIndex.Location = new System.Drawing.Point(113, 185);
            this.textBox5OrderIndex.Name = "textBox5OrderIndex";
            this.textBox5OrderIndex.Size = new System.Drawing.Size(169, 20);
            this.textBox5OrderIndex.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "OrderIndex";
            // 
            // frmAddWard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 291);
            this.Controls.Add(this.textBox5OrderIndex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4DistrictId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3WardName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2Appellation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1WardCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAdd);
            this.Name = "frmAddWard";
            this.Text = "frmAddWard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1WardCode;
        private System.Windows.Forms.TextBox textBox2Appellation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3WardName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4DistrictId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5OrderIndex;
        private System.Windows.Forms.Label label5;
    }
}