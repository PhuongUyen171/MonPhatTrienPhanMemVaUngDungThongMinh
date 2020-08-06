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
using BLL_DAL;

namespace DoAn
{
    public partial class frmDoiMatKhau : Office2007Form
    {
        public string tenDangNhap;

        DangNhapBLL dangNhap = new DangNhapBLL();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtPassOld.Text==string.Empty|| txtPassNew.Text==string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","Báo lỗi");
                return;
            }
            if(txtPassOld.Text!=dangNhap.GetPassDangNhap(txtTen.Text))
            {
                MessageBox.Show("Mật khẩu cũ không đúng.\nVui lòng nhập lại.","Báo lỗi");
                return;
            }
            dangNhap.DoiMatKhau(txtTen.Text, txtPassOld.Text, txtPassNew.Text);
            MessageBox.Show("Đổi mật khẩu thành công.","SUCCESSFUL");

        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTen.Text = tenDangNhap;
        }
    }
}
