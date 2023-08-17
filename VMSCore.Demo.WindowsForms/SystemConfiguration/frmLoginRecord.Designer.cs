
namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    partial class frmLoginRecord
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
            this.btnLoginedSystem = new System.Windows.Forms.Button();
            this.btnLogoutSystem = new System.Windows.Forms.Button();
            this.btnAcessToPermission = new System.Windows.Forms.Button();
            this.btnLeavePermission = new System.Windows.Forms.Button();
            this.btnAcessToChangePass = new System.Windows.Forms.Button();
            this.btnLeaveChangePass = new System.Windows.Forms.Button();
            this.txtLoginRecordId = new System.Windows.Forms.TextBox();
            this.txtUserFunctionUsagePermissionId = new System.Windows.Forms.TextBox();
            this.txtUserFunctionUsageChangePass = new System.Windows.Forms.TextBox();
            this.btnReportLoginRecord = new System.Windows.Forms.Button();
            this.btnReportFunctionRecord = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dtpcLoginDate = new System.Windows.Forms.DateTimePicker();
            this.dtpLogoutDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.txtStaffLoginName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStaffUseFunction = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoginedSystem
            // 
            this.btnLoginedSystem.Location = new System.Drawing.Point(23, 13);
            this.btnLoginedSystem.Name = "btnLoginedSystem";
            this.btnLoginedSystem.Size = new System.Drawing.Size(190, 23);
            this.btnLoginedSystem.TabIndex = 0;
            this.btnLoginedSystem.Text = "đăng nhập vào hệ thống ";
            this.btnLoginedSystem.UseVisualStyleBackColor = true;
            this.btnLoginedSystem.Click += new System.EventHandler(this.btnLoginedSystem_Click);
            // 
            // btnLogoutSystem
            // 
            this.btnLogoutSystem.Location = new System.Drawing.Point(260, 13);
            this.btnLogoutSystem.Name = "btnLogoutSystem";
            this.btnLogoutSystem.Size = new System.Drawing.Size(190, 23);
            this.btnLogoutSystem.TabIndex = 1;
            this.btnLogoutSystem.Text = "thoát khỏi hệ thống";
            this.btnLogoutSystem.UseVisualStyleBackColor = true;
            this.btnLogoutSystem.Click += new System.EventHandler(this.btnLogoutSystem_Click);
            // 
            // btnAcessToPermission
            // 
            this.btnAcessToPermission.Location = new System.Drawing.Point(23, 51);
            this.btnAcessToPermission.Name = "btnAcessToPermission";
            this.btnAcessToPermission.Size = new System.Drawing.Size(190, 23);
            this.btnAcessToPermission.TabIndex = 2;
            this.btnAcessToPermission.Text = "vào chức năng phân quyền";
            this.btnAcessToPermission.UseVisualStyleBackColor = true;
            this.btnAcessToPermission.Click += new System.EventHandler(this.btnAcessToPermission_Click);
            // 
            // btnLeavePermission
            // 
            this.btnLeavePermission.Location = new System.Drawing.Point(260, 51);
            this.btnLeavePermission.Name = "btnLeavePermission";
            this.btnLeavePermission.Size = new System.Drawing.Size(190, 23);
            this.btnLeavePermission.TabIndex = 3;
            this.btnLeavePermission.Text = "thoát khỏi chức năng phân quyền";
            this.btnLeavePermission.UseVisualStyleBackColor = true;
            this.btnLeavePermission.Click += new System.EventHandler(this.btnLeavePermission_Click);
            // 
            // btnAcessToChangePass
            // 
            this.btnAcessToChangePass.Location = new System.Drawing.Point(23, 93);
            this.btnAcessToChangePass.Name = "btnAcessToChangePass";
            this.btnAcessToChangePass.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAcessToChangePass.Size = new System.Drawing.Size(190, 23);
            this.btnAcessToChangePass.TabIndex = 4;
            this.btnAcessToChangePass.Text = "vào chức năng report";
            this.btnAcessToChangePass.UseVisualStyleBackColor = true;
            this.btnAcessToChangePass.Click += new System.EventHandler(this.btnAcessToChangePass_Click);
            // 
            // btnLeaveChangePass
            // 
            this.btnLeaveChangePass.Location = new System.Drawing.Point(260, 93);
            this.btnLeaveChangePass.Name = "btnLeaveChangePass";
            this.btnLeaveChangePass.Size = new System.Drawing.Size(190, 23);
            this.btnLeaveChangePass.TabIndex = 5;
            this.btnLeaveChangePass.Text = "thoát chức năng report";
            this.btnLeaveChangePass.UseVisualStyleBackColor = true;
            this.btnLeaveChangePass.Click += new System.EventHandler(this.btnLeaveChangePass_Click);
            // 
            // txtLoginRecordId
            // 
            this.txtLoginRecordId.Location = new System.Drawing.Point(489, 15);
            this.txtLoginRecordId.Name = "txtLoginRecordId";
            this.txtLoginRecordId.Size = new System.Drawing.Size(100, 20);
            this.txtLoginRecordId.TabIndex = 6;
            this.txtLoginRecordId.Visible = false;
            // 
            // txtUserFunctionUsagePermissionId
            // 
            this.txtUserFunctionUsagePermissionId.Location = new System.Drawing.Point(489, 54);
            this.txtUserFunctionUsagePermissionId.Name = "txtUserFunctionUsagePermissionId";
            this.txtUserFunctionUsagePermissionId.Size = new System.Drawing.Size(100, 20);
            this.txtUserFunctionUsagePermissionId.TabIndex = 7;
            this.txtUserFunctionUsagePermissionId.Visible = false;
            // 
            // txtUserFunctionUsageChangePass
            // 
            this.txtUserFunctionUsageChangePass.Location = new System.Drawing.Point(489, 96);
            this.txtUserFunctionUsageChangePass.Name = "txtUserFunctionUsageChangePass";
            this.txtUserFunctionUsageChangePass.Size = new System.Drawing.Size(100, 20);
            this.txtUserFunctionUsageChangePass.TabIndex = 8;
            this.txtUserFunctionUsageChangePass.Visible = false;
            this.txtUserFunctionUsageChangePass.WordWrap = false;
            // 
            // btnReportLoginRecord
            // 
            this.btnReportLoginRecord.Location = new System.Drawing.Point(654, 152);
            this.btnReportLoginRecord.Name = "btnReportLoginRecord";
            this.btnReportLoginRecord.Size = new System.Drawing.Size(166, 41);
            this.btnReportLoginRecord.TabIndex = 9;
            this.btnReportLoginRecord.Text = "xuất report tần xuất đăng nhập";
            this.btnReportLoginRecord.UseVisualStyleBackColor = true;
            this.btnReportLoginRecord.Click += new System.EventHandler(this.btnReportLoginRecord_Click);
            // 
            // btnReportFunctionRecord
            // 
            this.btnReportFunctionRecord.Location = new System.Drawing.Point(654, 395);
            this.btnReportFunctionRecord.Name = "btnReportFunctionRecord";
            this.btnReportFunctionRecord.Size = new System.Drawing.Size(166, 41);
            this.btnReportFunctionRecord.TabIndex = 10;
            this.btnReportFunctionRecord.Text = "xuất report tần xuất sử dụng các chức năng";
            this.btnReportFunctionRecord.UseVisualStyleBackColor = true;
            this.btnReportFunctionRecord.Click += new System.EventHandler(this.btnReportFunctionRecord_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(810, 150);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(22, 467);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(810, 150);
            this.dataGridView2.TabIndex = 12;
            // 
            // dtpcLoginDate
            // 
            this.dtpcLoginDate.Location = new System.Drawing.Point(170, 163);
            this.dtpcLoginDate.Name = "dtpcLoginDate";
            this.dtpcLoginDate.Size = new System.Drawing.Size(198, 20);
            this.dtpcLoginDate.TabIndex = 14;
            // 
            // dtpLogoutDate
            // 
            this.dtpLogoutDate.Location = new System.Drawing.Point(390, 164);
            this.dtpLogoutDate.Name = "dtpLogoutDate";
            this.dtpLogoutDate.Size = new System.Drawing.Size(198, 20);
            this.dtpLogoutDate.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "date from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "date to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 387);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "date to";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 387);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "date from";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(402, 416);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(198, 20);
            this.dtpEndDate.TabIndex = 21;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(182, 415);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(198, 20);
            this.dtpStartDate.TabIndex = 20;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToOrderColumns = true;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(22, 654);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.Size = new System.Drawing.Size(810, 150);
            this.dataGridView3.TabIndex = 25;
            // 
            // txtStaffLoginName
            // 
            this.txtStaffLoginName.Location = new System.Drawing.Point(23, 163);
            this.txtStaffLoginName.Name = "txtStaffLoginName";
            this.txtStaffLoginName.Size = new System.Drawing.Size(141, 20);
            this.txtStaffLoginName.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "tên nhân viên";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "tên nhân viên";
            // 
            // txtStaffUseFunction
            // 
            this.txtStaffUseFunction.Location = new System.Drawing.Point(22, 415);
            this.txtStaffUseFunction.Name = "txtStaffUseFunction";
            this.txtStaffUseFunction.Size = new System.Drawing.Size(141, 20);
            this.txtStaffUseFunction.TabIndex = 28;
            // 
            // frmLoginRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 816);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStaffUseFunction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStaffLoginName);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpLogoutDate);
            this.Controls.Add(this.dtpcLoginDate);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReportFunctionRecord);
            this.Controls.Add(this.btnReportLoginRecord);
            this.Controls.Add(this.txtUserFunctionUsageChangePass);
            this.Controls.Add(this.txtUserFunctionUsagePermissionId);
            this.Controls.Add(this.txtLoginRecordId);
            this.Controls.Add(this.btnLeaveChangePass);
            this.Controls.Add(this.btnAcessToChangePass);
            this.Controls.Add(this.btnLeavePermission);
            this.Controls.Add(this.btnAcessToPermission);
            this.Controls.Add(this.btnLogoutSystem);
            this.Controls.Add(this.btnLoginedSystem);
            this.Name = "frmLoginRecord";
            this.Text = "frmLoginRecord";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginedSystem;
        private System.Windows.Forms.Button btnLogoutSystem;
        private System.Windows.Forms.Button btnAcessToPermission;
        private System.Windows.Forms.Button btnLeavePermission;
        private System.Windows.Forms.Button btnAcessToChangePass;
        private System.Windows.Forms.Button btnLeaveChangePass;
        private System.Windows.Forms.TextBox txtLoginRecordId;
        private System.Windows.Forms.TextBox txtUserFunctionUsagePermissionId;
        private System.Windows.Forms.TextBox txtUserFunctionUsageChangePass;
        private System.Windows.Forms.Button btnReportLoginRecord;
        private System.Windows.Forms.Button btnReportFunctionRecord;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DateTimePicker dtpcLoginDate;
        private System.Windows.Forms.DateTimePicker dtpLogoutDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox txtStaffLoginName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStaffUseFunction;
    }
}