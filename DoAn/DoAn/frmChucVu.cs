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
using BLL;

namespace DoAn
{
    public partial class frmChucVu : Office2007Form
    {
        private ChucVu cv;
        ChucVuBLL c = new ChucVuBLL();
        public ChucVu chucVu
        {
            get { return cv; }
            set { cv = value; }
        }
        public frmChucVu()
        {
            InitializeComponent();
        }
        public frmChucVu( ChucVu cv)
        {
            InitializeComponent();
            txtMa.Text = cv.MaChucVu;
            txtTen.Text = cv.TenChucVu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtMa.Text)||string.IsNullOrEmpty(txtTen.Text))
                {
                    MessageBox.Show("Mã chức vụ và tên chức vụ không được để trống","ERROR");
                    return;
                }    
                if (!c.KiemTraKhoaChinh(txtMa.Text))
                {
                    c.ThemChucVu(txtMa.Text, txtTen.Text);
                    MessageBox.Show("Thêm nhóm chức vụ thành công.", "SUCCESSFUL");
                }
                else
                {
                    c.SuaChucVu(txtMa.Text, txtTen.Text);
                    MessageBox.Show("Sửa nhóm chức vụ thành công.", "SUCCESSFUL");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình thao tác", "ERROR");
                return;
            }
        }


    }
}
