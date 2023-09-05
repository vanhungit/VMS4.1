using System;
using System.Linq;
using System.Windows.Forms;
using VMSCore.Common.Enums;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Services.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class firmCreateObjectButtonMappingForAccount : Form
    {
        public firmCreateObjectButtonMappingForAccount()
        {
            InitializeComponent();
        }

        private readonly RoleUserRepository _roleUserRepo = new RoleUserRepository();
        private readonly StaffRepository _staffRepo = new StaffRepository();
        private readonly ButtonRepository _buttonRepo = new ButtonRepository();
        private readonly ObjectEntityRepository _objectEntityRepo = new ObjectEntityRepository();
        private readonly CompanyRepository _companyRepo = new CompanyRepository();
        private readonly PlantRepository _plantRepo = new PlantRepository();
        private readonly LineRepository _lineRepo = new LineRepository();
        private readonly WorkshopRepository _workshopRepo = new WorkshopRepository();
        private readonly ObjectButtonPermissionService _objectButtonPermissionService = new ObjectButtonPermissionService();

        private void firmCreateObjectButtonMappingForAccount_Load(object sender, EventArgs e)
        {
            var staffs = _staffRepo.GetAll().Select(x => x.Id).ToList();
            comboBox1.DataSource = staffs;

            var buttons = _buttonRepo.GetAll().Select(x => x.Id).ToList();
            comboBox2.DataSource = buttons;

            var objectEntities = _objectEntityRepo.GetAll().Select(x => x.ObjectId).ToList();
            comboBox3.DataSource = objectEntities;

            var parentObjectEntities = _objectEntityRepo.GetAll().Select(x => x.ObjectId).ToList();
            comboBox10.DataSource = parentObjectEntities;

            var moduleTypesList = SystemEnum.EnumToList<SystemEnum.ModuleType>();
            comboBox4.DataSource = moduleTypesList;

            var groupTypesList = SystemEnum.EnumToList<SystemEnum.GroupType>();
            comboBox5.DataSource = groupTypesList;

            var companies = _companyRepo.GetAll().Select(x => x.Id).ToList();
            comboBox6.DataSource = companies;

            var plants = _plantRepo.GetAll().Select(x => x.Id).ToList();
            comboBox7.DataSource = plants;

            var lines = _lineRepo.GetAll().Select(x => x.Id).ToList();
            comboBox9.DataSource = lines;

            var workshops = _workshopRepo.GetAll().Select(x => x.Id).ToList();
            comboBox8.DataSource = workshops;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var userId = comboBox1.SelectedItem.ToString();
                var roleUser = _roleUserRepo.GetRoleUserByUserId(userId);
                var roleId = roleUser.RoleId;
                var type = int.Parse(comboBox13.SelectedItem.ToString());

                var buttonId = comboBox2.SelectedItem.ToString();
                var objectId = comboBox3.SelectedItem.ToString();
                var parentObjectId = comboBox10.SelectedItem.ToString();
                var level = comboBox11.SelectedItem.ToString();
                var order = comboBox12.SelectedItem.ToString();

                var workshopId = comboBox8.SelectedItem.ToString();
                var lineId = comboBox9.SelectedItem.ToString();
                var plantId = comboBox7.SelectedItem.ToString();
                var companyId = comboBox6.SelectedItem.ToString();
                var groupType = comboBox5.SelectedItem.ToString();
                var moduleType = comboBox4.SelectedItem.ToString();

                var roleObjectButtonMapping = new RoleObjectButtonMapping()
                {
                    ButtonId = buttonId,
                    ObjectId = objectId,
                    RoleId = roleId
                };
                var functionGroupModuleObjectMapping = new FunctionGroupModuleObjectMapping()
                {
                    FunctionGroupModuleObjectMappingId = Guid.NewGuid().ToString(),
                    ObjectId = objectId,
                    Owner = userId,
                    Description = string.Empty,
                    ParentId = parentObjectId,
                    Level = int.Parse(level),
                    OrderId = int.Parse(order),
                    Active = true,
                    ModuleType = moduleType,
                    GroupType = groupType
                };
                //var plantRoleObjectMapping = new PlantRoleObjectMapping()
                //{
                //    PlantId = plantId,
                //    ObjectId = objectId,
                //    Active = true,
                //    AllowAccess = true,
                //    StaffId = userId
                //};
                //var companyRoleObjectMapping = new CompanyRoleObjectMapping()
                //{
                //    CompanyId = companyId,
                //    ObjectId = objectId,
                //    Active = true,
                //    AllowAccess = true,
                //    StaffId = userId
                //};
                //var lineRoleObjectMapping = new LineRoleObjectMapping()
                //{
                //    LineId = lineId,
                //    ObjectId = objectId,
                //    Active = true,
                //    AllowAccess = true,
                //    StaffId = userId
                //};
                //var workshopRoleObjectMapping = new WorkshopRoleObjectMapping()
                //{
                //    WorkShopId = workshopId,
                //    ObjectId = objectId,
                //    Active = true,
                //    AllowAccess = true,
                //    StaffId = userId
                //};

                //_objectButtonPermissionService.AssignObjectButtonForAccount(type, roleObjectButtonMapping, functionGroupModuleObjectMapping, plantRoleObjectMapping, workshopRoleObjectMapping, lineRoleObjectMapping, companyRoleObjectMapping);
                //MessageBox.Show("Thêm thành công");

            }
            catch (Exception exception)
            {
                MessageBox.Show("THÊM KHÔNG THÀNH CÔNG");
                throw exception;
            }
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = int.Parse(comboBox13.SelectedItem.ToString());
            if (item == 1)
            {
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox6.Enabled = true;
            }

            if (item == 2)
            {
                comboBox6.Enabled = false;
                comboBox8.Enabled = false;
                comboBox9.Enabled = false;
                comboBox7.Enabled = true;
            }

            if (item == 3)
            {
                comboBox7.Enabled = false;
                comboBox6.Enabled = false;
                comboBox9.Enabled = false;
                comboBox8.Enabled = true;
            }

            if (item == 4)
            {
                comboBox7.Enabled = false;
                comboBox8.Enabled = false;
                comboBox6.Enabled = false;
                comboBox9.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
