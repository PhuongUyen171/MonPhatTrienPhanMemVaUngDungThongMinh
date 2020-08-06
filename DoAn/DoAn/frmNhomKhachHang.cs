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
    public partial class frmNhomKhachHang : Office2007Form
    {
        private NhomKhachHang nkh;

        LoaiKhachHangBLL l = new LoaiKhachHangBLL();
        
        public NhomKhachHang NhomKH
        {
            get { return nkh; }
            set { nkh = value; }
        }
        public frmNhomKhachHang()
        {
            InitializeComponent();
        }
        public frmNhomKhachHang(NhomKhachHang nkh)
        {
            InitializeComponent();
            txtMa.Text = nkh.MaNhomKH;
            txtTen.Text = nkh.TenNhomKH;
            txtGHduoi.Text = nkh.GioiHanDuoi + "";
            txtGHtren.Text = nkh.GioiHanTren + "";
            txtGiamGia.Text = nkh.GiamGia + "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = txtMa.Text;
                string ten = txtTen.Text;
                long tren = long.Parse(txtGHtren.Text);
                long duoi = long.Parse(txtGHduoi.Text);
                int sale = int.Parse(txtGiamGia.Text);

                if (!l.KiemTraKhoaChinh(ma))
                {
                    if (l.ThemLoaiKH(ma, ten, duoi, tren, sale))
                        MessageBox.Show("Thêm nhóm khách hàng thành công.", "SUCCESSFUL");
                    else
                        MessageBox.Show("Không thể thêm.","ERROR");
                }
                else
                {
                    if (l.SuaLoaiKH(ma, ten, duoi, tren, sale))
                        MessageBox.Show("Sửa nhóm khách hàng thành công.", "SUCCESSFUL");
                    else
                        MessageBox.Show("Không thể sửa.","ERROR");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR", "Thông báo");
                return;
            }
        }

    }
}
