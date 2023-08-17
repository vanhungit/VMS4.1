using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.District
{
    public partial class frmDeleteDistrict : Form
    {
        public frmDeleteDistrict()
        {
            InitializeComponent();
        }

        BaseRepository<DistrictModel> districtRepository = new BaseRepository<DistrictModel>();

        private void frmDeleteDistrict_Load(object sender, EventArgs e)
        {

        }

        private void btnDeleteDistrict_Click(object sender, EventArgs e)
        {
            var districtId = textBox1DistrictId.Text;
            if (!string.IsNullOrWhiteSpace(districtId))
            {
                var result = districtRepository.DeleteByIdStr(districtId);
                if (result > 0)
                {
                    MessageBox.Show("Delete province sucessfull!");
                }
            }
        }
    }
}
