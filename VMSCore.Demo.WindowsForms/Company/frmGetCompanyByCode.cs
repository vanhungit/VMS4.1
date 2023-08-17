using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Base.Repositories;

namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
    public partial class frmGetCompanyByCode : Form
    {
        public frmGetCompanyByCode()
        {
            InitializeComponent();
        }

        BaseRepository<Company> companyRepository = new BaseRepository<Company>();

        private void frmGetCompanyByCode_Load(object sender, EventArgs e)
        {
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyCode.Text))
            {
                dataGridViewCompanyByCode.DataSource = null;
            }
            var companyCode = txtCompanyCode.Text;
            var company = companyRepository.GetAllByCondition(c => c.Code == companyCode);

            var companies = new List<Company>();
            //companies.Add(company);
            dataGridViewCompanyByCode.DataSource = companies;
        }

        private void txtCompanyCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewCompanyByCode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
