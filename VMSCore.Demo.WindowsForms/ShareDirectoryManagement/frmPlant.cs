using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    public partial class frmPlant : Form
    {
        public frmPlant()
        {
            InitializeComponent();
            DisplayGridViewData();
            LoadCompanyDropDownlist();
        }

        private readonly PlantRepository _plantRepository = new PlantRepository();
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var text = dlSearchCompayName.SelectedValue != null ? dlSearchCompayName.SelectedValue.ToString() : null;
            dataGridView1.DataSource = _plantRepository.Search(text, txtSearchPlantName.Text);


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var plant = new Plant();
            var companyId = dlCompanyName.SelectedValue != null ? dlCompanyName.SelectedValue.ToString() : null;
            if ( !string.IsNullOrWhiteSpace(companyId))
            {
                plant.CompanyId = companyId;
                plant.Id = Guid.NewGuid().ToString();
                plant.Code = txtPlantCode.Text;
                plant.Name = txtPlantName.Text;
                plant.NameEn = txtPlantNameEn.Text;
                plant.Active = cbActive.Checked;
                plant.Description = txtDescription.Text;
                _plantRepository.Add(plant);
                ClearData();
                DisplayGridViewData();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPlantId.Text))
            {
                var plant = _plantRepository.GetByIdStr(txtPlantId.Text);
                plant.CompanyId = dlCompanyName.SelectedValue.ToString();
                plant.Code = txtPlantCode.Text;
                plant.Name = txtPlantName.Text;
                plant.NameEn = txtPlantNameEn.Text;
                plant.Active = cbActive.Checked;
                plant.Description = txtDescription.Text;
                _plantRepository.Update(plant);
                DisplayGridViewData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPlantId.Text))
            {
                var plant = _plantRepository.GetByIdStr(txtPlantId.Text);
                _plantRepository.Delete(plant);
                DisplayGridViewData();
                ClearData();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            txtDescription.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            txtPlantCode.Text = Convert.ToString(selectedRow.Cells["PlantCode"].Value);
            txtPlantId.Text = Convert.ToString(selectedRow.Cells["PlantId"].Value); ;
            txtPlantName.Text = Convert.ToString(selectedRow.Cells["PlantName"].Value);
            txtPlantNameEn.Text = Convert.ToString(selectedRow.Cells["PlantNameEn"].Value);
            cbActive.Checked = Convert.ToBoolean(selectedRow.Cells["Active"].Value);
            dlCompanyName.SelectedValue = Convert.ToString(selectedRow.Cells["CompanyId"].Value);
        }
        private void DisplayGridViewData()
        {
            dataGridView1.DataSource = _plantRepository.GetAllPlant();
        }

        private void LoadCompanyDropDownlist()
        {
            var companies = _companyRepository.CompanyDropDownList();
            var searchCompanies = new List<CompanyDropDownListViewModel>();
            foreach (var item in companies)
            {
                searchCompanies.Add(item);
            }

            dlSearchCompayName.DataSource = searchCompanies;
            dlSearchCompayName.ValueMember = "Id";
            dlSearchCompayName.DisplayMember = "DropDownListText";
            dlSearchCompayName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlSearchCompayName.AutoCompleteSource = AutoCompleteSource.ListItems;

            dlCompanyName.DataSource = companies;
            dlCompanyName.ValueMember = "Id";
            dlCompanyName.DisplayMember = "DropDownListText";
            dlCompanyName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlCompanyName.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void ClearData()
        {
            txtDescription.Text = string.Empty;
            txtPlantCode.Text = string.Empty;
            txtPlantId.Text = string.Empty;
            txtPlantName.Text = string.Empty;
            txtPlantNameEn.Text = string.Empty;
            cbActive.Checked = false;
        }
    }
}
