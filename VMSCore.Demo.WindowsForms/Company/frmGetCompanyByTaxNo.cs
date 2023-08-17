using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.CompanyManagement
{
    public partial class frmGetCompanyByTaxNo : Form
    {
        public frmGetCompanyByTaxNo()
        {
            InitializeComponent();
        }

        CompanyRepository companyRepository = new CompanyRepository();

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCompanyTax.Text))
            {
                dataGridViewCompanyByTax.DataSource = null;
            }

            var companies = companyRepository.GetAllByCondition(c => c.CompanyTax == txtCompanyTax.Text).ToList();
            dataGridViewCompanyByTax.DataSource = companies;
        }
    }
}
