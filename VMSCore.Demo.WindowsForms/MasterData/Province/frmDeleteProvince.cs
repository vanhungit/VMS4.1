using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.Province
{
    public partial class frmDeleteProvince : Form
    {
        public frmDeleteProvince()
        {
            InitializeComponent();
        }

        BaseRepository<ProvinceModel> provinceRepository = new BaseRepository<ProvinceModel>();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1ProvinceId.Text))
            {
                var result = provinceRepository.DeleteByIdStr(textBox1ProvinceId.Text);
                if (result > 0)
                {
                    MessageBox.Show("Delete Province Successfully!");
                }
            }
        }
    }
}
