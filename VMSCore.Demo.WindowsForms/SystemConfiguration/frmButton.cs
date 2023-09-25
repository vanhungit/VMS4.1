using System;
using System.Windows.Forms;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmButton : Form
    {
        public frmButton()
        {
            InitializeComponent();
            DisplayData();

        }

        private readonly ButtonRepository _buttonRepository = new ButtonRepository();
        private readonly RoleObjectButtonMappingRepository _roleObjectButtonMappingRepository = new RoleObjectButtonMappingRepository();
        private readonly ObjectButtonMappingRepository _objectButtonMappingRepository = new ObjectButtonMappingRepository();

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = listButton.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = listButton.Rows[selectedrowindex];

            idButton.Text = Convert.ToString(selectedRow.Cells["ButtonId"].Value);
            nameButtonVN.Text = Convert.ToString(selectedRow.Cells["ButtonName"].Value);
            nameButtonEN.Text = Convert.ToString(selectedRow.Cells["ButtonNameEn"].Value);
            descriptionField.Text = Convert.ToString(selectedRow.Cells["Description"].Value);
            isActive.Checked = Convert.ToBoolean(selectedRow.Cells["Active"].Value);

        }

        private void DisplayData()
        {
            var buttons = _buttonRepository.GetAll();
            listButton.DataSource = buttons;
        }

        private void addNew_Click(object sender, EventArgs e)
        {
            var addNewButton = new EntityModels.Button();
            if (!string.IsNullOrWhiteSpace(nameButtonVN.Text))
            {
                addNewButton.Name = nameButtonVN.Text;
                addNewButton.NameEn = nameButtonEN.Text;
                addNewButton.Description = descriptionField.Text;
                addNewButton.Active = isActive.Checked;
                addNewButton.Id = Guid.NewGuid();
                _buttonRepository.Add(addNewButton);

                ClearData();
                listButton.DataSource = _buttonRepository.GetAll();
            }

        }
        private void ClearData()
        {
            idButton.Text = string.Empty;
            nameButtonVN.Text = string.Empty;
            nameButtonEN.Text = string.Empty;
            descriptionField.Text = string.Empty;
            isActive.Checked = false;
        }
        private void update_Click(object sender, EventArgs e)
        {

            var updateButton = _buttonRepository.GetByIdStr(idButton.Text);
            if (updateButton != null)
            {
                updateButton.Name = nameButtonVN.Text;
                updateButton.NameEn = nameButtonEN.Text;
                updateButton.Description = descriptionField.Text;
                updateButton.Active = isActive.Checked;
                _buttonRepository.Update(updateButton);
                listButton.DataSource = _buttonRepository.GetAll();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            _objectButtonMappingRepository.DeleteByCondition(x => x.ButtonCode == idButton.Text);
            _roleObjectButtonMappingRepository.DeleteByCondition(x => x.ButtonCode == idButton.Text);
            _buttonRepository.DeleteByCondition(x => x.Code == idButton.Text);
            listButton.DataSource = _buttonRepository.GetAll();
            idButton.Text = string.Empty;
            ClearData();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var buttons = _buttonRepository.Search(searchVN.Text);
            listButton.DataSource = buttons;
        }

        private void frmButton_Load(object sender, EventArgs e)
        {

        }
    }
}
