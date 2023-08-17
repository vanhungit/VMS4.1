using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.District
{
    public partial class frmAddDistrict : Form
    {
        public frmAddDistrict()
        {
            InitializeComponent();
        }

        BaseRepository<DistrictModel> districRepository = new BaseRepository<DistrictModel>();

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var district = new DistrictModel()
            {
                ProvinceId = Guid.Parse(textBox1ProvinceId.Text),
                OrderIndex = int.Parse(textBox6OrderIndex.Text),
                Actived = textBox7Actived.Text.Equals("1"),
                Appellation = textBox2Appellation.Text,
                DistrictCode = textBox4DistrictCode.Text,
                DistrictId = Guid.NewGuid(),
                DistrictName = textBox3DistrictName.Text,
                RegisterVAT = decimal.Parse(textBox5RegisterVAT.Text),
                VehicleRegistrationSignature = textBox8VehicleRegistrationSignature.Text
            };
            var result = districRepository.Add(district);

            if (result != null && !string.IsNullOrWhiteSpace(result.DistrictId.ToString()))
            {
                MessageBox.Show("Add district successfully");
            }
        }
    }
}
