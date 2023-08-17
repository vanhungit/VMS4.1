using System;
using System.Windows.Forms;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
    public partial class frmGetAllCompany : Form
    {
        public frmGetAllCompany()
        {
            InitializeComponent();
        }

        CompanyRepository CompanyRepository = new CompanyRepository();

        private void frmGetAllCompany_Load(object sender, EventArgs e)
        {
            var companies = CompanyRepository.GetAllCompany();
            dataGridViewCompany.DataSource = companies;
        }
    }
}
