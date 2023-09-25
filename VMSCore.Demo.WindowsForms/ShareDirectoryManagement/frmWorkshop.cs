using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    public partial class frmWorkshop : Form
    {
        public frmWorkshop()
        {
            InitializeComponent();
            initialDropdowlist();
            initialGridViewData();
        }
        private readonly FactoryRepository _plantRepository = new FactoryRepository();
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        private readonly WorkshopRepository _workshopRepository = new WorkshopRepository();
        private void dlSeachCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dlSearchPlanName.SelectedValue != null)
            {
                var plants = _plantRepository.PlantDropDownListByCompanyId(dlSearchPlanName.SelectedValue.ToString());
                dlSearchPlanName.DataSource = plants;
                dlSearchPlanName.ValueMember = "PlantId";
                dlSearchPlanName.DisplayMember = "PlantDropDownListText";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _workshopRepository.Search(dlSeachCompanyName.SelectedValue.ToString(), dlSearchPlanName.SelectedValue.ToString(), txtSearchWorkShopName.Text);
        }

        private void dlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlCompanyName.SelectedValue != null)
            {
                var plants = _plantRepository.PlantDropDownListByCompanyId(dlCompanyName.SelectedValue.ToString());
                if (plants.Any())
                {
                    dlPlanName.DataSource = plants;
                    dlPlanName.ValueMember = "PlantId";
                    dlPlanName.DisplayMember = "PlantDropDownListText";
                }
            }

        }
        private void initialDropdowlist()
        {
            var companies = _companyRepository.CompanyDropDownList();
            var searchCompanies = new List<CompanyDropDownListViewModel>();
            foreach (var item in companies)
            {
                searchCompanies.Add(item);
            }

            var plants = _plantRepository.PlantDropDownList();
            var searchplants = new List<PlantDropDownListViewModel>();

            foreach (var item in plants)
            {
                searchplants.Add(item);
            }

            dlSeachCompanyName.DataSource = searchCompanies;
            dlSeachCompanyName.ValueMember = "Id";
            dlSeachCompanyName.DisplayMember = "DropDownListText";

            dlCompanyName.DataSource = companies;
            dlCompanyName.ValueMember = "Id";
            dlCompanyName.DisplayMember = "DropDownListText";

            dlSearchPlanName.DataSource = searchplants;
            dlSearchPlanName.ValueMember = "PlantId";
            dlSearchPlanName.DisplayMember = "PlantDropDownListText";

            dlPlanName.DataSource = plants;
            dlPlanName.ValueMember = "PlantId";
            dlPlanName.DisplayMember = "PlantDropDownListText";

        }
        private void initialGridViewData()
        {
            dataGridView1.DataSource = _workshopRepository.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var data = new WorkShop
            {
                Id = Guid.NewGuid(),
                Code = txtCode.Text,
                Active = cbActive.Checked,
                CompanyCode = dlCompanyName.SelectedValue.ToString(),
                CreationTime = DateTime.Now,
                CreatorId = Guid.NewGuid().ToString(),
                Name = txtWorkShopName.Text,
                NameEn = txtWorkShopNameEn.Text,
                Description = txtDescription.Text,
                FactoryCode = dlPlanName.SelectedValue.ToString()
            };
            _workshopRepository.Add(data);
            initialGridViewData();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = _workshopRepository.GetByIdStr(txtWorkShopId.Text);
            data.Code = txtCode.Text;
            data.Active = cbActive.Checked;
            data.CompanyCode = dlCompanyName.SelectedValue.ToString();
            data.CreationTime = DateTime.Now;
            data.CreatorId = Guid.NewGuid().ToString();
            data.Name = txtWorkShopName.Text;
            data.NameEn = txtWorkShopNameEn.Text;
            data.Description = txtDescription.Text;
            data.FactoryCode = dlPlanName.SelectedValue.ToString();
            _workshopRepository.Update(data);
            initialGridViewData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var data = _workshopRepository.GetByIdStr(txtWorkShopId.Text);
            _workshopRepository.Delete(data);
            initialGridViewData();
            ClearData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            txtCode.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            cbActive.Checked = Convert.ToBoolean(selectedRow.Cells["Active"].Value);
            dlCompanyName.SelectedValue = Convert.ToString(selectedRow.Cells["CompanyId"].Value);
            txtWorkShopName.Text = Convert.ToString(selectedRow.Cells["WorkShopName"].Value);
            txtWorkShopNameEn.Text = Convert.ToString(selectedRow.Cells["WorkShopNameEn"].Value);
            txtDescription.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            dlPlanName.SelectedValue = Convert.ToString(selectedRow.Cells["PlantId"].Value);
            txtWorkShopId.Text = Convert.ToString(selectedRow.Cells["Id"].Value);
        }
        private void ClearData()
        {
            txtCode.Text = string.Empty;
            cbActive.Checked = false;
            txtWorkShopName.Text = string.Empty;
            txtWorkShopNameEn.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtWorkShopId.Text = string.Empty;
        }
    }
}
