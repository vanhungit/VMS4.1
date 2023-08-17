using System;
using System.Windows.Forms;
using VMSCore.Demo.WindowsForms.MasterData.District;
using VMSCore.Demo.WindowsForms.MasterData.Province;
using VMSCore.Demo.WindowsForms.MasterData.Ward;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData
{
    public partial class frmMasterData : Form
    {
        public frmMasterData()
        {
            InitializeComponent();
        }

        private readonly BaseRepository<ProvinceModel> provinceRepository = new BaseRepository<ProvinceModel>();
        private readonly BaseRepository<DistrictModel> districtRepository = new BaseRepository<DistrictModel>();
        private readonly BaseRepository<WardModel> wardRepository = new BaseRepository<WardModel>();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var provinces = provinceRepository.GetAll();
            dataGridView1.DataSource = provinces;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var districts = provinceRepository.GetAll();
            dataGridView1.DataSource = districts;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var wards = provinceRepository.GetAll();
            dataGridView1.DataSource = wards;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var provinces = provinceRepository.GetAllByCondition(p => p.ProvinceName == txtProvince.Text);
            dataGridView1.DataSource = provinces;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Guid provinceId = Guid.Parse(txtProvinceCode.Text);
            var districts = districtRepository.GetAllByCondition(d => d.ProvinceId == provinceId && d.DistrictName == txtDistrict.Text);

            dataGridView1.DataSource = districts;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Guid districtId = Guid.Parse(txtDistrictCode.Text);
            var wards = wardRepository.GetAllByCondition(w => w.DistrictId == districtId && w.WardName == txtWardName.Text);
            dataGridView1.DataSource = wards;
        }

        private void frmMasterData_Load(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmAddProvince frmAddProvince = new frmAddProvince();
            frmAddProvince.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmUpdateProvince frmUpdateProvince = new frmUpdateProvince();
            frmUpdateProvince.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmDeleteProvince frmDeleteProvince = new frmDeleteProvince();
            frmDeleteProvince.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmAddDistrict frmAddDistrict = new frmAddDistrict();
            frmAddDistrict.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmDeleteDistrict frmDeleteDistrict = new frmDeleteDistrict();
            frmDeleteDistrict.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            frmUpdateDistrict frmUpdateDistrict = new frmUpdateDistrict();
            frmUpdateDistrict.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            frmAddWard addWard = new frmAddWard();
            addWard.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmDeleteWard deleteWard = new frmDeleteWard();
            deleteWard.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            frmUpdateWard updateWard = new frmUpdateWard();
            updateWard.Show();
        }
    }
}
