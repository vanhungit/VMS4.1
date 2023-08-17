using System;
using System.Linq;
using System.Windows.Forms;
using VMSCore.Common.Enums;
using VMSCore.Infrastructure.Features.SystemConfiguration.Services.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmObjectButtonPermission : Form
    {
        public frmObjectButtonPermission()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var accountId = "34f9dd24-e6f8-40ee-adcd-cb2d252022a6";
            var typeId = "36EF4072-7CD5-4693-9316-DEE10586BCCF";
            var type = (int)SystemEnum.PermissionType.Company;
            var moduleType = SystemEnum.GetEnumDescription(SystemEnum.ModuleType.DESKTOP);
            var groupType = SystemEnum.GetEnumDescription(SystemEnum.GroupType.GROUP);

            ObjectButtonPermissionService objectButtonPermissionService = new ObjectButtonPermissionService();
            var result = objectButtonPermissionService.GetAssignObjectButtonByAccount(accountId, typeId, type, moduleType, groupType);

            var objectTypes = result.Select(p => new
            {
                p.ObjectId,
                p.ObjectName,
                p.ObjectNameEn,
                p.ParentId,
                p.Level,
                p.OrderId,
                p.Owner,
                p.ModuleType,
                p.GroupType,
            }).Distinct()
              .ToList();

            var buttons = result.Select(p => new
            {
                p.ObjectId,
                p.ObjectName,
                p.ButtonId,
                p.ButtonName,
                p.ButtonNameEn,
                p.ButtonDescription,
                p.ButtonActive
            }).ToList();

            dataGridView1.DataSource = result;
            dataGridView2.DataSource = objectTypes;
            dataGridView3.DataSource = buttons;
        }

        private void frmObjectButtonPermission_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
