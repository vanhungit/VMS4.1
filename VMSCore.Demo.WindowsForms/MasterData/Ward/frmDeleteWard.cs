using System;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.MasterData.Ward
{
    public partial class frmDeleteWard : Form
    {
        public frmDeleteWard()
        {
            InitializeComponent();
        }

        BaseRepository<WardModel> _wardRepository = new BaseRepository<WardModel>();

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1WardId.Text))
            {
                var result = _wardRepository.DeleteByIdStr(textBox1WardId.Text);
                if (result > 0)
                {
                    MessageBox.Show("Delete ward successfully!");
                }
            }
        }
    }
}
