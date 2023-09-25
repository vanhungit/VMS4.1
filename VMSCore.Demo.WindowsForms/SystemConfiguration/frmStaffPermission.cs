using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Extensions;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemConfiguration.Services.Implementations;
using VMSCore.ViewModels.SystemConfiguration;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmStaffPermission : Form
    {
        public frmStaffPermission()
        {
            InitializeComponent();
            var staff = _staffRepository.GetAll();
            dataGridView1.DataSource = staff.Select(x =>
            new
            {
                LastName = x.LastName,
                Code = x.Code,
                Name = x.Name,
                Phone = x.Phone,
                StaffId = x.Id
            }).ToList();
            var data = _staffPermissionService.GetPermissionByAccountId("");
            dataGridView2.DataSource = data.StaffRoles;
            initPermissionForCompay(data);
        }
        private readonly StaffRepository _staffRepository = new StaffRepository();
        private readonly StaffPermissionService _staffPermissionService = new StaffPermissionService();
        private readonly RoleUserRepository _roleUserRepository = new RoleUserRepository();
        private readonly CompanyUserMappingRepository _companyUserMappingRepository = new CompanyUserMappingRepository();
        private readonly PlantUserMappingRepository _plantUserMappingRepository = new PlantUserMappingRepository();
        private readonly WorkshopUserMappingRepository _workshopUserMappingRepository = new WorkshopUserMappingRepository();
        private readonly LineUserMappingRepository _lineUserMappingRepository = new LineUserMappingRepository();
      
        public void initPermissionForCompay(StaffPermissionViewModel data)
        {
            
            
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            treeView1.CheckBoxes = true;

            if (data != null && data.StaffPermissionCompanies != null)
            {
                foreach (var company in data.StaffPermissionCompanies)
                {
                    TreeNode companyNode = new TreeNode
                    {
                        Text = company.CompanyName,
                        Tag = company.CompanyId
                    };
                    companyNode.Checked = company.IsCompanyAssigned;

                    // Level 2: Plants
                    if (data.StaffPermissionPlants != null)
                    {
                        foreach (var plant in data.StaffPermissionPlants.Where(p => p.CompanyId == company.CompanyId))
                        {
                            TreeNode plantNode = new TreeNode
                            {
                                Text = plant.PlantName,
                                Tag = plant.PlantId
                            };

                            plantNode.Checked = plant.IsPlantAssigned;
                            if (data.StaffPermissionWorkShops != null)
                            {
                                foreach (var workshop in data.StaffPermissionWorkShops.Where(p => p.PlantId == plant.PlantId))
                                {
                                    TreeNode workshopNode = new TreeNode
                                    {
                                        Text = workshop.WorkShopName,
                                        Tag = workshop.WorkShopId
                                    };

                                    // Set checkbox state based on IsPlantAssigned
                                    workshopNode.Checked = workshop.IsWorkShopAssigned;
                                    if (data.StaffPermissionLines != null)
                                    {
                                        foreach (var line in data.StaffPermissionLines.Where(p => p.WorkshopId == workshop.WorkShopId))
                                        {
                                            TreeNode lineNode = new TreeNode
                                            {
                                                Text = line.LineName,
                                                Tag = line.LineId
                                            };
                                            lineNode.Checked = line.IsLineAssigned;
                                            workshopNode.Nodes.Add(lineNode);
                                        }
                                    }
                                    plantNode.Nodes.Add(workshopNode);
                                }
                            }
                            companyNode.Nodes.Add(plantNode);
                        }
                    }
                    treeView1.Nodes.Add(companyNode);
                }
            }
            treeView1.EndUpdate();
        }
        
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // The checked node is a company node
            var leve = e.Node.Level;
            if (e.Action != TreeViewAction.Unknown)
            {
                if (e.Node.Nodes.Count > 0)
                {
                    CheckAllChildNodes(e.Node.Nodes, e.Node.Checked);
                    treeView1.EndUpdate();
                }
            }
        }

        private void CheckAllChildNodes(TreeNodeCollection nodes, bool isChecked)
        {
            foreach (TreeNode node in nodes)
            {
                node.Checked = isChecked; // Set the current node's Checked property
                CheckAllChildNodes(node.Nodes, isChecked); // Recursively check child nodes
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            var staffId = Convert.ToString(selectedRow.Cells["StaffId"].Value);
            txtStaffId.Text = staffId;
            var data = _staffPermissionService.GetPermissionByAccountId(staffId);
            dataGridView2.DataSource = data.StaffRoles;
            initPermissionForCompay(data);
        }
        private List<TreeNode> getAllChildNodes (TreeNode root)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            foreach (TreeNode child in root.Nodes)
            {
                nodes.AddRange(getAllChildNodes(child));
            }

            nodes.Add(root);

            return nodes;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var companies = new List<CompanyUserMapping>();
            var plants = new List<PlantUserMapping>();
            var workShops = new List<WorkshopUserMapping>();
            var lines = new List<LineUserMapping>();
            List<TreeNode> nodes = new List<TreeNode>();
            foreach (TreeNode node in treeView1.Nodes)
            {
                nodes.AddRange(getAllChildNodes(node));
            }
            foreach(TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    switch (node.Level)
                    {
                        case 0:
                            var company = new CompanyUserMapping()
                            {
                                CompanyId = node.Tag.ToString(),
                                Active = true,
                                ModuleId = "desktop",
                                StaffId = txtStaffId.Text
                            };
                            companies.Add(company);
                            break;
                        case 1:
                            var plant = new PlantUserMapping()
                            {
                                PlantId = node.Tag.ToString(),
                                Active = true,
                                MduleId = "desktop",
                                StaffId = txtStaffId.Text
                            };
                            plants.Add(plant);
                            break;
                        case 2:
                            var workShop = new WorkshopUserMapping()
                            {
                                WorkShopId = node.Tag.ToString(),
                                Active = true,
                                ModuleId = "desktop",
                                StaffId = txtStaffId.Text
                            };
                            workShops.Add(workShop);
                            break;
                        case 3:
                            var line = new LineUserMapping()
                            {
                                LineId = node.Tag.ToString(),
                                Active = true,
                                ModuleId = "desktop",
                                StaffId = txtStaffId.Text
                            };
                            lines.Add(line);
                            break;
                    }
                }
            }



            var assign = new List<RoleUser>();
            foreach (DataGridViewRow dgvr in dataGridView2.Rows)
            {
                var IsRoleAssigned = Convert.ToBoolean(dgvr.Cells["IsRoleAssigned"].Value);
                var roleId = Convert.ToString(dgvr.Cells["RoleId"].Value);
                var roleUser = new RoleUser()
                {
                    Id = Guid.NewGuid(),
                    CreationTime = DateTime.UtcNow,
                    RoleCode = roleId,
                    UserCode = txtStaffId.Text
                };
                if (IsRoleAssigned)
                {
                    assign.Add(roleUser);
                }
            }

            _roleUserRepository.DeleteByCondition(x => x.UserCode.Equals(txtStaffId.Text));
            _roleUserRepository.AddRange(assign);
            //_staffPermissionService.DeleteStaffPermission(txtStaffId.Text);
            _companyUserMappingRepository.DeleteByCondition(x => x.StaffId ==txtStaffId.Text);
            _plantUserMappingRepository.DeleteByCondition(x => x.StaffId == txtStaffId.Text);
            _workshopUserMappingRepository.DeleteByCondition(x => x.StaffId == txtStaffId.Text);
            _lineUserMappingRepository.DeleteByCondition(x => x.StaffId == txtStaffId.Text);

            _companyUserMappingRepository.AddRange(companies);
            _plantUserMappingRepository.AddRange(plants);
            _workshopUserMappingRepository.AddRange(workShops);
            _lineUserMappingRepository.AddRange(lines);


        }
    }

}
