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
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmPlantSIteMapping : Form
    {
        public frmPlantSIteMapping()
        {
            InitializeComponent();
            dataGridView1.DataSource = _plantRepository.GetAllPlant();
            dataGridView2.DataSource = _plantSiteMappingRepository.GetPlantSiteMapping("");
        }
        private readonly PlantRepository _plantRepository = new PlantRepository();
        private readonly PlantSiteMappingRepository _plantSiteMappingRepository = new PlantSiteMappingRepository();
        private readonly SiteRepository _siteRepository = new SiteRepository();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            var plantId = Convert.ToString(selectedRow.Cells["PlantId"].Value);
            dataGridView2.DataSource = _plantSiteMappingRepository.GetPlantSiteMapping(plantId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var assign = new List<PlantSiteMapping>();
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            var plantId = Convert.ToString(selectedRow.Cells["PlantId"].Value);
            
            foreach (DataGridViewRow dgvr in dataGridView2.Rows)
            {
                var assigned = Convert.ToBoolean(dgvr.Cells["Assigned"].Value);
                var siteId = Guid.Parse(dgvr.Cells["SiteId"].Value.ToString());
                var customerCode = Convert.ToString(dgvr.Cells["CustomerCode"].Value);
                var objectMap = new PlantSiteMapping()
                {
                    Id = Guid.NewGuid(),
                    SiteId = siteId,
                    PlantId = plantId,
                    CreatorId= "34f9dd24-e6f8-40ee-adcd-cb2d252022a6",
                    CustomerCode= customerCode

                };
                if (assigned)
                {
                    assign.Add(objectMap);
                }
            }
            
            _plantSiteMappingRepository.DeleteByCondition(_ => _.PlantId == plantId);
            _plantSiteMappingRepository.AddRange(assign);
            dataGridView2.DataSource = _plantSiteMappingRepository.GetPlantSiteMapping(plantId);
        }
    }
}
