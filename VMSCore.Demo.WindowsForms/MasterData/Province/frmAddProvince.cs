using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.Province
{
    public partial class frmAddProvince : Form
    {
        public frmAddProvince()
        {
            InitializeComponent();
        }

        BaseRepository<ProvinceModel> provinceRepository = new BaseRepository<ProvinceModel>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var province = new ProvinceModel()
            {
                Actived = int.Parse(textBox4Actived.Text) == 1,
                Area = int.Parse(textBox2Area.Text),
                ConfigPriceCode = textBox5ConfigPriceCode.Text,
                ProvinceName = textBox1ProvinceName.Text,
                IsHasLicensePrice = int.Parse(textBox6IsHasLicensePrice.Text) == 1,
                OrderIndex = int.Parse(textBox3OrderIndex.Text),
                ProvinceCode = textBox5ConfigPriceCode.Text,
                ProvinceId = Guid.NewGuid()
            };

            var result = provinceRepository.Add(province);
            if (result != null && !string.IsNullOrWhiteSpace(result.ProvinceName))
            {
                MessageBox.Show("Add Province Successfully!");
            }
        }

        private void frmAddProvince_Load(object sender, EventArgs e)
        {

        }
    }
}
