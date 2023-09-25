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
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmStaffMapRole : Form
    {
        public frmStaffMapRole()
        {
            InitializeComponent();
            var staff = _staffRepository.GetAll();
            dataGridView1.DataSource = staff.Select(x =>
            new
            {
                LastName = x.LastName,
                Code = x.Code,
                Name = x.Name,
                Phone = x.Phone,
                StaffId=x.Id
            }).ToList();
            dataGridView2.DataSource = _roleUserRepository.GetRoleStaffByStaffId("");
        }
        private readonly RoleRepository _roleRepository = new RoleRepository();
        private readonly RoleUserRepository _roleUserRepository = new RoleUserRepository();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        private void button1_Click(object sender, EventArgs e)
        {
            var assign = new List<RoleUser>();
            foreach (DataGridViewRow dgvr in dataGridView2.Rows)
            {
                var inUse = Convert.ToBoolean(dgvr.Cells["InUse"].Value);
                var roleId = Convert.ToString(dgvr.Cells["RoleId"].Value);
                var roleUser = new RoleUser()
                {
                    Id= Guid.NewGuid(),
                    CreationTime=DateTime.UtcNow,
                    RoleCode=roleId,
                    UserCode=txtStaffId.Text
                };
                if (inUse)
                {
                    assign.Add(roleUser);
                }
            }
            _roleUserRepository.DeleteByCondition(x => x.UserCode.Equals(txtStaffId.Text));
            _roleUserRepository.AddRange(assign);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            var staffId= Convert.ToString(selectedRow.Cells["StaffId"].Value);
            txtStaffId.Text = staffId;
            dataGridView2.DataSource= _roleUserRepository.GetRoleStaffByStaffId(staffId);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
