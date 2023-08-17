using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    public partial class frmRole : Form
    {
        public frmRole()
        {
            InitializeComponent();
            initialDropdown();
            dataGridView1.DataSource = _roleRepository.GetAll();
        }
        private readonly RoleRepository _roleRepository = new RoleRepository();
        private readonly RoleUserRepository _roleUserRepository = new RoleUserRepository();
        private readonly RoleObjectButtonMappingRepository _roleObjectButtonMappingRepository = new RoleObjectButtonMappingRepository();
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            txtRoleCode.Text = Convert.ToString(selectedRow.Cells["RoleCode"].Value);
            txtRoleName.Text = Convert.ToString(selectedRow.Cells["RoleName"].Value);
            dlCompany.SelectedValue = Convert.ToString(selectedRow.Cells["CompanyId"].Value);
            txtDescription.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            txtRoleId.Text = Convert.ToString(selectedRow.Cells["RoleId"].Value);

        }
        private void initialDropdown()
        {
            var companies = _companyRepository.CompanyDropDownList();
            dlCompany.DataSource = companies;
            dlCompany.ValueMember = "Id";
            dlCompany.DisplayMember = "DropDownListText";
            dlCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var data = new Role();
            data.Code = txtRoleCode.Text;
            data.Name = txtRoleName.Text;
            data.CompanyId = dlCompany.SelectedValue.ToString();
            data.Description = txtDescription.Text;
            data.Id = Guid.NewGuid().ToString();
            _roleRepository.Add(data);
            dataGridView1.DataSource = _roleRepository.GetAll();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = _roleRepository.GetByIdStr(txtRoleId.Text);
            data.Code = txtRoleCode.Text;
            data.Name = txtRoleName.Text;
            data.CompanyId = dlCompany.SelectedValue.ToString();
            data.Description = txtDescription.Text;
            _roleRepository.Update(data);
            dataGridView1.DataSource = _roleRepository.GetAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _roleObjectButtonMappingRepository.DeleteByCondition(x => x.RoleId == txtRoleId.Text);
            _roleUserRepository.DeleteByCondition(x => x.RoleId == txtRoleId.Text);
            _roleRepository.DeleteByCondition(x => x.Id == txtRoleId.Text);
            dataGridView1.DataSource = _roleRepository.GetAll();
        }
    }
}
