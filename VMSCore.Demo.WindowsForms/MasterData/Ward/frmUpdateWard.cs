using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.Ward
{
    public partial class frmUpdateWard : Form
    {
        public frmUpdateWard()
        {
            InitializeComponent();
        }

        BaseRepository<WardModel> _wardRepository = new BaseRepository<WardModel>();

        private void button1_Click(object sender, EventArgs e)
        {
            // Search ward
            var w = _wardRepository.GetById(Guid.Parse(textBox1WardId.Text));
            if (w == null) return;
            textBox1WardCode.Text = w.WardCode;
            textBox2Appellation.Text = w.Appellation;
            textBox3WardName.Text = w.WardName;
            textBox4DistrictId.Text = w.DistrictId.ToString();
            textBox5OrderIndex.Text = w.OrderIndex.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // Update ward
            var wardToUpdate = new WardModel()
            {
                WardCode = textBox1WardCode.Text,
                Appellation = textBox2Appellation.Text,
                OrderIndex = int.Parse(textBox5OrderIndex.Text),
                WardName = textBox3WardName.Text,
                DistrictId = Guid.Parse(textBox4DistrictId.Text),
                WardId = Guid.Parse(textBox1WardId.Text)
            };

            var result = _wardRepository.Update(wardToUpdate);
            if (result != null && !string.IsNullOrWhiteSpace(result.WardName))
            {
                MessageBox.Show("Update Ward Successfully!");
            }
        }
    }
}
