using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMSCore.WindowsForms
{
    public partial class frmTongHopMay : DevExpress.XtraEditors.XtraForm
    {
        public frmTongHopMay(string Line)
        {
            InitializeComponent();
            this.Text = Line;
            layoutControlGDayChuyen.Text = Line;
            layoutControlGAnser.Text = Line + "-" + "01" + "-" + layoutControlGAnser.Text;
            layoutControlGCam.Text = Line + "-" + "02" + "-" + layoutControlGCam.Text;
            layoutControlGBangTai.Text = Line + "-" + "03" + "-" + layoutControlGBangTai.Text;
        }

        private void pictureEdit1_DoubleClick(object sender, EventArgs e)
        {
            //frmDetailMayIn frm = new frmDetailMayIn(layoutControlGAnser.Text);
            //frm.ShowDialog();
        }

        private void pictureEdit2_DoubleClick(object sender, EventArgs e)
        {
            //frmDetailCamera frm = new frmDetailCamera(layoutControlGCam.Text);
            //frm.ShowDialog();
        }

       
    }
}
