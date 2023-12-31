namespace CartManager
{
    partial class frmThayDoiMatKhau
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
            this.labelControlMKCu = new DevExpress.XtraEditors.LabelControl();
            this.txtPassOld = new DevExpress.XtraEditors.TextEdit();
            this.txtPassNew = new DevExpress.XtraEditors.TextEdit();
            this.labelControlMKMoi = new DevExpress.XtraEditors.LabelControl();
            this.txtPassMak = new DevExpress.XtraEditors.TextEdit();
            this.labelControlMKNhapLai = new DevExpress.XtraEditors.LabelControl();
            this.btnDongY = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassMak.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControlMKCu
            // 
            this.labelControlMKCu.Location = new System.Drawing.Point(13, 18);
            this.labelControlMKCu.Name = "labelControlMKCu";
            this.labelControlMKCu.Size = new System.Drawing.Size(61, 13);
            this.labelControlMKCu.TabIndex = 1;
            this.labelControlMKCu.Text = "Mật Khẩu Cũ";
            this.labelControlMKCu.UseWaitCursor = true;
            // 
            // txtPassOld
            // 
            this.txtPassOld.Location = new System.Drawing.Point(109, 15);
            this.txtPassOld.Name = "txtPassOld";
            this.txtPassOld.Properties.PasswordChar = '*';
            this.txtPassOld.Size = new System.Drawing.Size(240, 20);
            this.txtPassOld.TabIndex = 1;
            // 
            // txtPassNew
            // 
            this.txtPassNew.Location = new System.Drawing.Point(109, 41);
            this.txtPassNew.Name = "txtPassNew";
            this.txtPassNew.Properties.PasswordChar = '*';
            this.txtPassNew.Size = new System.Drawing.Size(240, 20);
            this.txtPassNew.TabIndex = 2;
            // 
            // labelControlMKMoi
            // 
            this.labelControlMKMoi.Location = new System.Drawing.Point(14, 44);
            this.labelControlMKMoi.Name = "labelControlMKMoi";
            this.labelControlMKMoi.Size = new System.Drawing.Size(64, 13);
            this.labelControlMKMoi.TabIndex = 3;
            this.labelControlMKMoi.Text = "Mật Khẩu Mới";
            this.labelControlMKMoi.UseWaitCursor = true;
            // 
            // txtPassMak
            // 
            this.txtPassMak.Location = new System.Drawing.Point(109, 67);
            this.txtPassMak.Name = "txtPassMak";
            this.txtPassMak.Properties.PasswordChar = '*';
            this.txtPassMak.Size = new System.Drawing.Size(240, 20);
            this.txtPassMak.TabIndex = 3;
            // 
            // labelControlMKNhapLai
            // 
            this.labelControlMKNhapLai.Location = new System.Drawing.Point(14, 70);
            this.labelControlMKNhapLai.Name = "labelControlMKNhapLai";
            this.labelControlMKNhapLai.Size = new System.Drawing.Size(89, 13);
            this.labelControlMKNhapLai.TabIndex = 5;
            this.labelControlMKNhapLai.Text = "Nhập Lại Mật Khẩu";
            this.labelControlMKNhapLai.UseWaitCursor = true;
            // 
            // btnDongY
            // 
            this.btnDongY.Location = new System.Drawing.Point(181, 93);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(75, 23);
            this.btnDongY.TabIndex = 4;
            this.btnDongY.Text = "Đồng Ý";
            this.btnDongY.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(274, 93);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmThayDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(361, 129);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtPassMak);
            this.Controls.Add(this.labelControlMKNhapLai);
            this.Controls.Add(this.txtPassNew);
            this.Controls.Add(this.labelControlMKMoi);
            this.Controls.Add(this.txtPassOld);
            this.Controls.Add(this.labelControlMKCu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThayDoiMatKhau";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay Đổi Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.txtPassOld.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassNew.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassMak.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControlMKCu;
        private DevExpress.XtraEditors.TextEdit txtPassOld;
        private DevExpress.XtraEditors.TextEdit txtPassNew;
        private DevExpress.XtraEditors.LabelControl labelControlMKMoi;
        private DevExpress.XtraEditors.TextEdit txtPassMak;
        private DevExpress.XtraEditors.LabelControl labelControlMKNhapLai;
        private DevExpress.XtraEditors.SimpleButton btnDongY;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}