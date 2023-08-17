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
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmSite : Form
    {
        public frmSite()
        {
            InitializeComponent();
            dataGridView1.DataSource = _siteRespository.GetAll();
            dataGridView1.Columns["Id"].ReadOnly = true;
            dataGridView1.Columns["Id"].Visible = false;
        }
        private readonly SiteRepository _siteRespository = new SiteRepository();
        private readonly PlantSiteMappingRepository _plantSiteMappingRespository = new PlantSiteMappingRepository();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var dataRandom = new Random().Next(1,1000);
            var data = new Site();
            data.Id = Guid.NewGuid();
            data.Code = string.Concat("Code ", dataRandom);
            data.Name = string.Concat("Name ", dataRandom);
            data.Price = dataRandom;
            data.CreatorId = "5bd7ed23-da49-43de-917e-35a7e4716f62";
            data.CreationTime = DateTime.Now;
            data.Active = true;
            _siteRespository.Add(data);
            dataGridView1.DataSource = _siteRespository.GetAll();
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                if (dataGridView.Rows[e.RowIndex].DataBoundItem is Site modifiedOrder)
                {
                    var propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
                    var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Update the modified property of the modifiedOrder object
                    var propertyInfo = typeof(Site).GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(modifiedOrder, newValue);
                        _siteRespository.Update(modifiedOrder);
                        dataGridView1.DataSource = _siteRespository.GetAll();
                    }
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            var siteId = Convert.ToString(selectedRow.Cells["Id"].Value);
            if (e.ColumnIndex == dataGridView1.Columns["buttondelete"].Index)
            {
                _siteRespository.DeleteByCondition(x => x.Id == Guid.Parse(siteId));
                _plantSiteMappingRespository.DeleteByCondition(x => x.SiteId == Guid.Parse(siteId));
                dataGridView1.DataSource = _siteRespository.GetAll();
            }
        }
    }
}
