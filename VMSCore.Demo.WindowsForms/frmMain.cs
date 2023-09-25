using System;
using System.Windows.Forms;
using VMSCore.Demo.WindowsForms.CompanyManagement;
using VMSCore.Demo.WindowsForms.MasterData;
using VMSCore.Demo.WindowsForms.Report;
using VMSCore.Demo.WindowsForms.ShareDirectoryManagement;
using VMSCore.Demo.WindowsForms.SystemConfiguration;
using VMSCore.Extensions;

namespace VMSCore.Demo.WindowsForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmGetAllCompany company = new frmGetAllCompany();
            company.Show();
        }

        private void getByCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetCompanyByCode company = new frmGetCompanyByCode();
            company.Show();
        }

        private void getByTaxNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGetCompanyByTaxNo company = new frmGetCompanyByTaxNo();
            company.Show();
        }

        private void masterDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMasterData masterData = new frmMasterData();
            masterData.Show();
        }

        private void buttonConfigPage_Click(object sender, EventArgs e)
        {
            var frmButton = new frmButton();
            frmButton.Show();
        }

        private void btnConfigObjectEntity_Click(object sender, EventArgs e)
        {
            var frm = new frmObjectEntity();
            frm.Show();
        }

        private void btnCompanyConfig_Click(object sender, EventArgs e)
        {
            var frm = new frmCompanyManagement();
            frm.Show();
        }

        private void btnPlant_Click(object sender, EventArgs e)
        {
            var frm = new frmPlant();
            frm.Show();
        }

        private void btnWorkShop_Click(object sender, EventArgs e)
        {
            var frm = new frmWorkshop();
            frm.Show();
        }

        private void btnObjectBtnMap_Click(object sender, EventArgs e)
        {
            var frm = new frmObjectButtonMapping();
            frm.Show();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            var frm = new frmLine();
            frm.Show();
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            var frm = new frmRole();
            frm.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            var frm = new frmStaff();
            frm.Show();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            var frm = new fmrReport();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmObjectButtonPermission frmPermission = new frmObjectButtonPermission();
            frmPermission.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            firmCreateObjectButtonMappingForAccount frmCreateObjectbutton = new firmCreateObjectButtonMappingForAccount();
            frmCreateObjectbutton.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var frm = new frmAssignPermissionForButtonsObjects();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var frm = new frmStaffMapRole();
            frm.Show();
        }

        private void btnStaffPermission_Click(object sender, EventArgs e)
        {
            var frm = new frmStaffPermission();
            frm.Show();
        }

        private void btnProductOther_Click(object sender, EventArgs e)
        {
            //var frm = new frmProductOther();
            //frm.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            var frm = new frmChangePassword();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var frm = new frmLoginRecord();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var frm = new frmSite();
            frm.Show();
        }

        private void btnPlantSiteMapping_Click(object sender, EventArgs e)
        {
            var frm = new frmPlantSIteMapping();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RepositoryLibrary repositoryLibrary = new RepositoryLibrary();
            string Chuoi = repositoryLibrary.EncryptString("123A@", "vms4.1");
            MessageBox.Show(repositoryLibrary.EncryptString("123A@", "vms4.1"));
        }
    }
}
