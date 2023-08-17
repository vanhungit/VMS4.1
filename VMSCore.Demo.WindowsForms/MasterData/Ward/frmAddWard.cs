using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.Ward
{
    public partial class frmAddWard : Form
    {
        public frmAddWard()
        {
            InitializeComponent();
        }

        BaseRepository<WardModel> _wardRepository = new BaseRepository<WardModel>();
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var ward = new WardModel()
            {
                DistrictId = Guid.Parse(textBox4DistrictId.Text),
                Appellation = textBox2Appellation.Text,
                WardName = textBox3WardName.Text,
                WardCode = textBox1WardCode.Text,
                OrderIndex = int.Parse(textBox5OrderIndex.Text),
                WardId = Guid.NewGuid()
            };

            var result = _wardRepository.Add(ward);
            if (result != null && !string.IsNullOrWhiteSpace(result.WardCode))
            {
                MessageBox.Show("Add ward successfully!");
            }
        }
    }
}
