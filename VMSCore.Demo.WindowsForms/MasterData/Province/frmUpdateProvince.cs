using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.Province
{
    public partial class frmUpdateProvince : Form
    {
        public frmUpdateProvince()
        {
            InitializeComponent();
        }


        BaseRepository<ProvinceModel> provinceRepository = new BaseRepository<ProvinceModel>();

        private void textBoxProvinceId_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Search Province
            var p = provinceRepository.GetById(Guid.Parse(textBoxProvinceId.Text));
            if (p == null) return;

            textBox1Area.Text = p.Area.ToString();
            textBox1ProvinceCode.Text = p.ProvinceCode;
            textBox1IsHasLicensePrice.Text = p.IsHasLicensePrice.HasValue ? "1" : "0";
            textBox1OrderIndex.Text = p.OrderIndex.ToString();
            textBox3ConfigPriceCode.Text = p.ConfigPriceCode.ToString();
            textBox2Actived.Text = p.Actived ? "1" : "0";
            textBox2ProvinceName.Text = p.ProvinceName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Update Province
            var provinceToUpdate = new ProvinceModel()
            {
                ProvinceId = Guid.Parse(textBoxProvinceId.Text),
                ProvinceName = textBox2ProvinceName.Text,
                Actived = int.Parse(textBox2Actived.Text) == 1,
                Area = int.Parse(textBox1Area.Text),
                ConfigPriceCode = textBox3ConfigPriceCode.Text,
                IsHasLicensePrice = int.Parse(textBox1IsHasLicensePrice.Text) == 1,
                OrderIndex = int.Parse(textBox1OrderIndex.Text),
                ProvinceCode = textBox1ProvinceCode.Text
            };
            var result = provinceRepository.Update(provinceToUpdate);
            if (result != null && !string.IsNullOrWhiteSpace(result.ProvinceName))
            {
                MessageBox.Show("Update Province Successfully!");
            }
        }
    }
}