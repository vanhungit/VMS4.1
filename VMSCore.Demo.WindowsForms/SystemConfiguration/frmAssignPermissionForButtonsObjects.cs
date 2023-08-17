using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmAssignPermissionForButtonsObjects : Form
    {
        private readonly ObjectButtonMappingRepository _objectButtonMappingRepository = new ObjectButtonMappingRepository();
        private readonly RoleRepository _roleRepository = new RoleRepository();
        private readonly RoleObjectButtonMappingRepository _roleObjectButtonMappingRepository = new RoleObjectButtonMappingRepository();
        public frmAssignPermissionForButtonsObjects()
        {
            InitializeComponent();
            var roles = _roleRepository.GetAll();
            dataGridView1.DataSource = roles;
            dataGridView2.DataSource = _roleObjectButtonMappingRepository.GetRoleObjectButtonMappingByRole(string.Empty);
            dlRole.DataSource = roles;
            dlRole.ValueMember = "Id";
            dlRole.DisplayMember = "Name";
            dlRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlRole.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            var roleId = Convert.ToString(selectedRow.Cells["Id"].Value);

            dataGridView2.DataSource = _roleObjectButtonMappingRepository.GetRoleObjectButtonMappingByRole(roleId); ;
            dlRole.SelectedValue = roleId;
        }
        private void dlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dlRole.SelectedValue.ToString()))
            {
                dataGridView2.DataSource = _roleObjectButtonMappingRepository.GetRoleObjectButtonMappingByRole(dlRole.SelectedValue.ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var assign = new List<RoleObjectButtonMapping>();
            foreach (DataGridViewRow dgvr in dataGridView2.Rows)
            {
                var ischecked = Convert.ToBoolean(dgvr.Cells["InUse"].Value);
                var buttonId = Convert.ToString(dgvr.Cells["ButtonId"].Value);
                var objectId = Convert.ToString(dgvr.Cells["ObjectId"].Value);
                var objectMap = new RoleObjectButtonMapping()
                {
                    ButtonId= buttonId,
                    ObjectId = objectId,
                    RoleId= dlRole.SelectedValue.ToString()
                };
                if (ischecked)
                {
                    assign.Add(objectMap);
                }
            }
            _roleObjectButtonMappingRepository.DeleteByCondition(x => x.RoleId == dlRole.SelectedValue.ToString());
            _roleObjectButtonMappingRepository.AddRange(assign);

        }
    }
}
