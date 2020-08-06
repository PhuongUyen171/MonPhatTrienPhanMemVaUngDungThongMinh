using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace DoAn
{
    public partial class frmDangNhap : Office2007Form
    {
        NguoiDung CauHinh = new NguoiDung();
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCauHinh_Click(object sender, EventArgs e)
        {
            frmCauHinh frm = new frmCauHinh();
            frm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbTen.Text.ToLower());
                txtTen.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbPass.Text.ToLower());
                txtPass.Focus();
                return;
            }
            int kq = CauHinh.CheckConfig();
            if (kq == 0)
                ProcessConfig();
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại.");
                ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp.");
                ProcessConfig();
            }
        }

        public void ProcessConfig()
        {
            LoginResult kq;
            kq = CauHinh.CheckUser(txtTen.Text, txtPass.Text);
            if (kq == LoginResult.Invalid)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.");
                return;
            }
            else if (kq == LoginResult.Disable)
            {
                MessageBox.Show("Tài khoản bị khóa.");
                return;
            }
            if (Program.mainForm == null || Program.mainForm.IsDisposed)
                Program.mainForm = new frmMain();
            this.Visible = false;
            Program.mainForm.tenDangNhap = txtTen.Text;
            Program.mainForm.Show();
        }

    }
}
