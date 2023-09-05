using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmObjectEntity : Form
    {
        public frmObjectEntity()
        {
            InitializeComponent();
            InitDataGrid();
        }
        private readonly ObjectEntityRepository _objectEntityRepository = new ObjectEntityRepository();
        private readonly RoleObjectButtonMappingRepository _roleObjectButtonMappingRepository = new RoleObjectButtonMappingRepository();
        private readonly ObjectButtonMappingRepository _objectButtonMappingRepository = new ObjectButtonMappingRepository();
        private readonly FunctionGroupModuleObjectMappingRepository _functionGroupModuleObjectMappingRepository = new FunctionGroupModuleObjectMappingRepository();
        private void dgvObjectEntity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dgvObjectEntity.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvObjectEntity.Rows[selectedrowindex];

            txtDescription.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            txtObjectName.Text = Convert.ToString(selectedRow.Cells["ObjectName"].Value);
            txtObjectNameEn.Text = Convert.ToString(selectedRow.Cells["ObjectNameEn"].Value);
            cbActive.Checked = Convert.ToBoolean(selectedRow.Cells["Active"].Value);
            txtObjectId.Text = Convert.ToString(selectedRow.Cells["ObjectId"].Value);

        }
        private void ClearData()
        {
            txtDescription.Text = string.Empty;
            txtObjectName.Text = string.Empty;
            txtObjectNameEn.Text = string.Empty;
            cbActive.Checked = false;
        }
        private void InitDataGrid()
        {
            var objectentities = _objectEntityRepository.GetAll();
            dgvObjectEntity.DataSource = objectentities;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtObjectName.Text))
            {
                var objectEntity = new ObjectEntity()
                {
                    //ObjectId = Guid.NewGuid().ToString(),
                    ObjectId = "ded25c0f-77c0-4925-8eb3-481b9602bac8",
                    ObjectName = txtObjectName.Text,
                    ObjectNameEn = txtObjectNameEn.Text,
                    Description = txtDescription.Text,
                    Active = cbActive.Checked
                };
                _objectEntityRepository.Add(objectEntity);
                ClearData();
                InitDataGrid();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var objectEntity = _objectEntityRepository.GetByIdStr(txtObjectId.Text);
            if (objectEntity != null)
            {
                objectEntity.ObjectName = txtObjectName.Text;
                objectEntity.ObjectNameEn = txtObjectNameEn.Text;
                objectEntity.Description = txtDescription.Text;
                objectEntity.Active = cbActive.Checked;
                _objectEntityRepository.Update(objectEntity);
                InitDataGrid();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            _objectEntityRepository.DeleteByCondition(x=>x.ObjectId==txtObjectId.Text);
            _objectButtonMappingRepository.DeleteByCondition(x => x.ObjectId == txtObjectId.Text);
            _functionGroupModuleObjectMappingRepository.DeleteByCondition(x => x.ObjectId == txtObjectId.Text);
            _roleObjectButtonMappingRepository.DeleteByCondition(x => x.ObjectId == txtObjectId.Text);
            InitDataGrid();
            ClearData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvObjectEntity.DataSource = _objectEntityRepository.Search(txtSeach.Text);
        }
    }
}
