using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.ViewModels.SharedDirectoryManagement;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    public partial class frmLine : Form
    {
        private readonly PlantRepository _plantRepository = new PlantRepository();
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        private readonly WorkshopRepository _workshopRepository = new WorkshopRepository();
        private readonly LineRepository _lineRepository = new LineRepository();
        public frmLine()
        {
            InitializeComponent();
            var plantDropdownlist = _plantRepository.PlantDropDownList();
            var workshopDropdownlist = _workshopRepository.workShopDropDownList();
            var companyDropdownlist = _companyRepository.CompanyDropDownList();
            intialCompayneyDropList(companyDropdownlist);
            intialPlantDropList(plantDropdownlist);
            intialWorkShopDropList(workshopDropdownlist);
            displayGridView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _lineRepository.SearchLine(string.Empty, string.Empty, string.Empty, txtSearchLineName.Text);
        }

        private void dataGridView1_RowClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            TxtDescription.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            txtLineId.Text = Convert.ToString(selectedRow.Cells["LineId"].Value);
            dlCompanyId.SelectedValue = Convert.ToString(selectedRow.Cells["CompanyId"].Value);
            dlPlantId.SelectedValue = Convert.ToString(selectedRow.Cells["PlantId"].Value);
            dlWorkShopId.SelectedValue = Convert.ToString(selectedRow.Cells["WorkShopId"].Value);
            txtLineName.Text = Convert.ToString(selectedRow.Cells["LineName"].Value);
            txtLineCode.Text = Convert.ToString(selectedRow.Cells["LineCode"].Value);
            cbActvie.Checked = Convert.ToBoolean(selectedRow.Cells["Active"].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var data = new Line();
            data.Id = Guid.NewGuid().ToString();
            data.Code = txtLineCode.Text;
            data.Name = txtLineName.Text;
            data.Description = TxtDescription.Text;
            data.Active = cbActvie.Checked;
            data.CompanyId = dlCompanyId.SelectedValue.ToString();
            data.PlantId = dlPlantId.SelectedValue.ToString();
            data.WorkshopId = dlWorkShopId.SelectedValue.ToString();
            _lineRepository.Add(data);
            clearfield();
            displayGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = _lineRepository.GetByIdStr(txtLineId.Text);
            data.Code = txtLineCode.Text;
            data.Name = txtLineName.Text;
            data.Description = TxtDescription.Text;
            data.Active = cbActvie.Checked;
            data.CompanyId = dlCompanyId.SelectedValue.ToString();
            data.PlantId = dlPlantId.SelectedValue.ToString();
            data.WorkshopId = dlWorkShopId.SelectedValue.ToString();
            _lineRepository.Update(data);
            displayGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var data = _lineRepository.GetByIdStr(txtLineId.Text);
            _lineRepository.Delete(data);
            clearfield();
            displayGridView();
        }

        private void dlCompanyId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlCompanyId.SelectedValue != null)
            {
                var result = _plantRepository.PlantDropDownListByCompanyId(dlCompanyId.SelectedValue.ToString());
                intialPlantDropList(result);
            }
        }

        private void dlPlantId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dlPlantId.SelectedValue != null)
            {
                var result = _workshopRepository.workShopDropDownListByPlantId(dlPlantId.SelectedValue.ToString());
                intialWorkShopDropList(result);
            }
        }
        private void intialCompayneyDropList(List<CompanyDropDownListViewModel> data)
        {

            dlCompanyId.DataSource = data;
            dlCompanyId.ValueMember = "Id";
            dlCompanyId.DisplayMember = "DropDownListText";
            dlCompanyId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlCompanyId.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void intialPlantDropList(List<PlantDropDownListViewModel> data)
        {

            dlPlantId.DataSource = data;
            dlPlantId.ValueMember = "PlantId";
            dlPlantId.DisplayMember = "PlantDropDownListText";
            dlPlantId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlPlantId.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void intialWorkShopDropList(List<WorkShopDropDownListViewModel> data)
        {
            dlWorkShopId.DataSource = data;
            dlWorkShopId.ValueMember = "Id";
            dlWorkShopId.DisplayMember = "DropDownListText";
            dlWorkShopId.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlWorkShopId.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void displayGridView()
        {
            dataGridView1.DataSource = _lineRepository.GetAllLine();
        }
        private void clearfield()
        {
            txtLineId.Text = string.Empty;
            txtLineCode.Text = string.Empty;
            txtLineName.Text = string.Empty;
            TxtDescription.Text = string.Empty;
            cbActvie.Checked = false;

        }
    }
}
