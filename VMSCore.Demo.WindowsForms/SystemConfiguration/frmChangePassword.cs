using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMSCore.Extensions;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.SystemConfiguration
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        private readonly StaffRepository _staffRepository = new StaffRepository();
        private readonly RoleUserRepository _roleUserRepository = new RoleUserRepository();
        private void button1_Click(object sender, EventArgs e)
        {
            txtUserRole.Text = "admin";
            txtOldPass.Visible = false;
            lbOldPass.Visible = false;
            txtUserNameLogined.Text = "emilyjohnson";
            txtUserNameLogined.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUserRole.Text = "staff";
            txtOldPass.Visible = true;
            lbOldPass.Visible = true;
            txtUserNameLogined.Text = "emilyjohnson1";
            txtUserNameLogined.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var staff=_staffRepository.GetOneByCondition(_ => _.Username == txtUserName.Text);
            
            if (txtUserRole.Text== "admin")
            {
                if (staff == null)
                {
                    MessageBox.Show("không tồn tại staff");
                    return;
                }
                staff.Password = RepositoryLibrary.GetMd5Sum(txtNewPass.Text);
                _staffRepository.Update(staff);
                MessageBox.Show("thành công ");
            }
            else
            {
                if (txtUserName.Text != txtUserNameLogined.Text)
                {
                    MessageBox.Show("bạn khổng đổi tài khoản này được");
                    return;
                }
                if (staff == null)
                {
                    MessageBox.Show("không tồn tại staff");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtOldPass.Text))
                {
                    MessageBox.Show("nhập mất khẩu cũ");
                    return;
                }
                if (staff.Password != RepositoryLibrary.GetMd5Sum(txtOldPass.Text))
                {
                    MessageBox.Show("nhập mất khẩu cũ không đúng");
                    return;
                }
                staff.Password = RepositoryLibrary.GetMd5Sum(txtNewPass.Text);
                MessageBox.Show("thành công ");
                _staffRepository.Update(staff);
            }
           //function check admin for user.
          // var isAdmin= _roleUserRepository.IsAdminRole()
        }
        
    }
}
