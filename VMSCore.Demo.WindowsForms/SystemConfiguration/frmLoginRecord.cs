using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Extensions;
using VMSCore.Infrastructure.Features.SystemPermissionConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmLoginRecord : Form
    {
        public frmLoginRecord()
        {
            InitializeComponent();
            dtpcLoginDate.CustomFormat="YYYY-MM-DD";
            dtpcLoginDate.Value = dtpcLoginDate.MinDate;
            dtpLogoutDate.CustomFormat = "YYYY-MM-DD";
            dtpLogoutDate.Value = dtpLogoutDate.MinDate;
            dtpEndDate.CustomFormat = "YYYY-MM-DD";
            dtpEndDate.Value = dtpEndDate.MinDate;
            dtpStartDate.CustomFormat = "YYYY-MM-DD";
            dtpStartDate.Value = dtpStartDate.MinDate;
        }
        private readonly LoginRecordRepository _loginRecordRepository = new LoginRecordRepository();
        private readonly UserFunctionUsageRepository _userFunctionUsageRepository = new UserFunctionUsageRepository();

        private void btnLoginedSystem_Click(object sender, EventArgs e)
        {
            var login = new LoginRecord();
            login.StaffId = "00d7c553-c76d-4f76-acc6-bc931d3665c1";
            login.Id = Guid.NewGuid();
            login.LoginTime = DateTime.Now.AddMinutes(-30);
            var loginedSave =_loginRecordRepository.Add(login);
            txtLoginRecordId.Text = loginedSave.Id.ToString();
        }

        private void btnLogoutSystem_Click(object sender, EventArgs e)
        {
            var  loginedSave = _loginRecordRepository.GetById(Guid.Parse(txtLoginRecordId.Text) );
            loginedSave.LogoutTime = DateTime.Now;
            TimeSpan time = (TimeSpan)(DateTime.Now - loginedSave.LoginTime);
            loginedSave.SessionDuration = (decimal)time.TotalHours;
            _loginRecordRepository.Update(loginedSave);

        }

        private void btnAcessToPermission_Click(object sender, EventArgs e)
        {
            var data = new UserFunctionUsage();
            data.StaffId = "00d7c553-c76d-4f76-acc6-bc931d3665c1";
            data.Id = Guid.NewGuid();
            data.StartTime = DateTime.Now.AddMinutes(-30);
            data.ObjectId = "menuPermission";
            var save =_userFunctionUsageRepository.Add(data);
            txtUserFunctionUsagePermissionId.Text = save.Id.ToString();
        }

        private void btnLeavePermission_Click(object sender, EventArgs e)
        {
            var data = _userFunctionUsageRepository.GetById(Guid.Parse(txtUserFunctionUsagePermissionId.Text));
            data.EndTime = DateTime.Now.AddMinutes(-30);
            TimeSpan time = (TimeSpan)(DateTime.Now - data.StartTime);
            data.SessionDuration = (decimal)time.TotalMinutes;
            _userFunctionUsageRepository.Update(data);
        }

        private void btnAcessToChangePass_Click(object sender, EventArgs e)
        {
            var data = new UserFunctionUsage();
            data.StaffId = "00d7c553-c76d-4f76-acc6-bc931d3665c1";
            data.Id = Guid.NewGuid();
            data.StartTime = DateTime.Now.AddMinutes(-30);
            data.ObjectId = "menuReport";
            var save = _userFunctionUsageRepository.Add(data);
            txtUserFunctionUsageChangePass.Text = save.Id.ToString();
        }

        private void btnLeaveChangePass_Click(object sender, EventArgs e)
        {
            var data = _userFunctionUsageRepository.GetById(Guid.Parse(txtUserFunctionUsageChangePass.Text));
            data.EndTime = DateTime.Now.AddMinutes(-30);
            TimeSpan time = (TimeSpan)(DateTime.Now - data.StartTime);
            data.SessionDuration = (decimal)time.TotalMinutes;
            _userFunctionUsageRepository.Update(data);
        }

        private void btnReportLoginRecord_Click(object sender, EventArgs e)
        {
            var dbUtil = new DatabaseUtil("VMSCoreDb");
            var dateFrom = dtpcLoginDate.Value.Date != dtpcLoginDate.MinDate ? (DateTime?)dtpcLoginDate.Value.Date : null;
            var dateTo = dtpLogoutDate.Value.Date != dtpLogoutDate.MinDate ? (DateTime?)dtpLogoutDate.Value.Date : null;
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@staffName", txtStaffLoginName.Text},
                { "@dateFrom", dateFrom },
                { "@dateTo", dateTo }
            };

            var dataSet = dbUtil.GetDataSetFromStoredProcedure("sproc_ReportLoginRecord", parameters);
            if (dataSet.Tables.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void btnReportFunctionRecord_Click(object sender, EventArgs e)
        {
            var dbUtil = new DatabaseUtil("VMSCoreDb");
            var dateFrom = dtpStartDate.Value.Date != dtpStartDate.MinDate ? (DateTime?)dtpStartDate.Value.Date : null;
            var dateTo = dtpEndDate.Value.Date != dtpEndDate.MinDate ? (DateTime?)dtpEndDate.Value.Date : null;
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@staffName", txtStaffLoginName.Text},
                { "@dateFrom", dateFrom },
                { "@dateTo", dateTo }
            };

            var dataSet1 = dbUtil.GetDataSetFromStoredProcedure("sproc_ReportUserFunctionalUsage", parameters);
            var dataSet2 = dbUtil.GetDataSetFromStoredProcedure("sproc_ReportFrequencyUserLogin", parameters);
            if (dataSet1.Tables.Count > 0)
            {
                dataGridView3.DataSource = dataSet1.Tables[0];
            }
            if (dataSet2.Tables.Count > 0)
            {
                dataGridView2.DataSource = dataSet2.Tables[0];
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
