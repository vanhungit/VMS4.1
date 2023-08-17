using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.District
{
    public partial class frmUpdateDistrict : Form
    {
        public frmUpdateDistrict()
        {
            InitializeComponent();
        }

        BaseRepository<DistrictModel> districRepository = new BaseRepository<DistrictModel>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1DistrictId.Text))
            {
                var districtInDb = districRepository.GetById(Guid.Parse(textBox1DistrictId.Text));
                if (districtInDb != null)
                {
                    districtInDb.ProvinceId = Guid.Parse(textBox1ProvinceId.Text);
                    textBox2Appellation.Text = districtInDb.Appellation;
                    textBox3DistrictName.Text = districtInDb.DistrictName;
                    districtInDb.DistrictCode = textBox4DistrictCode.Text;
                    districtInDb.RegisterVAT = decimal.Parse(textBox5RegisterVAT.Text);
                    districtInDb.OrderIndex = int.Parse(textBox6OrderIndex.Text);
                    districtInDb.Actived = textBox7Active.Text == "1";

                    var result = districRepository.Update(districtInDb);
                    if (result != null)
                    {
                        MessageBox.Show("Update district successfully!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1DistrictId.Text))
            {
                var district = districRepository.GetById(Guid.Parse(textBox1DistrictId.Text));
                if (district != null)
                {
                    textBox1ProvinceId.Text = district.ProvinceId.ToString();
                    textBox2Appellation.Text = district.Appellation.ToString();
                    textBox3DistrictName.Text = district.DistrictName;
                    textBox4DistrictCode.Text = district.DistrictCode.ToString();
                    textBox5RegisterVAT.Text = district.RegisterVAT.ToString();
                    textBox6OrderIndex.Text = district.OrderIndex.ToString();
                    textBox7Active.Text = district.Actived ? "1" : "0";
                }
            }
        }
    }
}
