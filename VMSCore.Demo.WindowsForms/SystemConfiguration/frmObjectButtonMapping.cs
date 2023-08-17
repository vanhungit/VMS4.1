using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmObjectButtonMapping : Form
    {
        public frmObjectButtonMapping()
        {
            InitializeComponent();
            intial();
        }
        private readonly ButtonRepository _buttonRepository = new ButtonRepository();
        private readonly ObjectEntityRepository _objectEntityRepository = new ObjectEntityRepository();
        private readonly ObjectButtonMappingRepository _mappingRepository = new ObjectButtonMappingRepository();
        private void intial()
        {
            var listObjectEntity = _objectEntityRepository.GetAll();
            gvObjectEnity.DataSource = listObjectEntity;
            intitalDLObjects(listObjectEntity);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            gvObjectEnity.DataSource = _objectEntityRepository.GetByIdStr(dlSearchObjectEntity.SelectedValue.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var assign = new List<ObjectButtonMapping>();
            foreach (DataGridViewRow dgvr in gvButton.Rows)
            {
                var ischecked = Convert.ToBoolean(dgvr.Cells["IsChecked"].Value);
                var buttonId = Convert.ToString(dgvr.Cells["ButtonId"].Value);
                var objectMap = new ObjectButtonMapping()
                {
                    ButtonId = buttonId,
                    Active = true,
                    ObjectId = dlOjectEntity.SelectedValue.ToString(),
                    ObjectButtonMappingId = Guid.NewGuid().ToString()
                };
                if (ischecked)
                {
                    assign.Add(objectMap);
                }
            }
            _mappingRepository.DeleteByCondition(x => x.ObjectId.Equals(dlOjectEntity.SelectedValue.ToString()));
            _mappingRepository.AddRange(assign);

        }
        private void intitalDLObjects(List<ObjectEntity> objects)
        {
            var itemSearches = new List<ObjectEntity>();
            foreach (var item in objects)
            {
                itemSearches.Add(item);
            }

            dlSearchObjectEntity.DataSource = itemSearches;
            dlSearchObjectEntity.ValueMember = "ObjectId";
            dlSearchObjectEntity.DisplayMember = "ObjectName";
            dlSearchObjectEntity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlSearchObjectEntity.AutoCompleteSource = AutoCompleteSource.ListItems;

            dlOjectEntity.DataSource = objects;
            dlOjectEntity.ValueMember = "ObjectId";
            dlOjectEntity.DisplayMember = "ObjectName";
            dlOjectEntity.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            dlOjectEntity.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void gvObjectEnity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = gvObjectEnity.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = gvObjectEnity.Rows[selectedrowindex];
            var objectId = Convert.ToString(selectedRow.Cells["ObjectId"].Value);

            gvButton.DataSource = _mappingRepository.GetButton(objectId); ;
            dlOjectEntity.SelectedValue = objectId;
        }

        private void dlOjectEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dlOjectEntity.SelectedValue.ToString()))
            {
                gvButton.DataSource = _mappingRepository.GetButton(dlOjectEntity.SelectedValue.ToString());
            }
        }
    }
}
