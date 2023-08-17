using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
    public partial class frmCompanyManagement : Form
    {
        public frmCompanyManagement()
        {
            InitializeComponent();
            DisplayData();
        }
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = gvCompany.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = gvCompany.Rows[selectedrowindex];

            txtId.Text = Convert.ToString(selectedRow.Cells["Id"].Value);
            txtName.Text = Convert.ToString(selectedRow.Cells["CompanyName"].Value);
            txtDescription.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            txtCompanyCodeNameEn.Text = Convert.ToString(selectedRow.Cells["CompanyCodeNameEn"].Value);
            txtCode.Text = Convert.ToString(selectedRow.Cells["Code"].Value);
            txtCompanyTax.Text = Convert.ToString(selectedRow.Cells["CompanyTax"].Value);
            cbActive.Checked = Convert.ToBoolean(selectedRow.Cells["Active"].Value);
        }
        private void DisplayData()
        {
            var result = _companyRepository.GetAllCompany();
            gvCompany.DataSource = result;
        }
        private void ClearData()
        {
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtCompanyCodeNameEn.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtCompanyTax.Text = string.Empty;
            cbActive.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gvCompany.DataSource = _companyRepository.Search(txtSearchCode.Text, txtSearchName.Text, txtSearchCompanyTax.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addNewModel = new Company();
            addNewModel.Id = Guid.NewGuid().ToString();
            addNewModel.Code = txtCode.Text;
            addNewModel.Name = txtName.Text;
            addNewModel.CompanyTax = txtCompanyTax.Text;
            addNewModel.Description = txtDescription.Text;
            addNewModel.CompanyCodeNameEn = txtCompanyCodeNameEn.Text;
            addNewModel.Active = cbActive.Checked;
            addNewModel.CreationTime = DateTime.UtcNow;
            addNewModel.CreatorId = "06ffe27f-5ef2-4e48-bad2-27f8276ed7b5";
            _companyRepository.Add(addNewModel);
            ClearData();
            DisplayData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var company = _companyRepository.GetByIdStr(txtId.Text);
            company.Code = txtCode.Text;
            company.Name = txtName.Text;
            company.CompanyTax = txtCompanyTax.Text;
            company.Description = txtDescription.Text;
            company.CompanyCodeNameEn = txtCompanyCodeNameEn.Text;
            company.Active = cbActive.Checked;
            company.LastModificationTime = DateTime.UtcNow;
            company.LastModifierId = "06ffe27f-5ef2-4e48-bad2-27f8276ed7b5";
            _companyRepository.Update(company);
            DisplayData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var company = _companyRepository.GetByIdStr(txtId.Text);
            _companyRepository.Delete(company);
            ClearData();
            DisplayData();
        }
    }
}
