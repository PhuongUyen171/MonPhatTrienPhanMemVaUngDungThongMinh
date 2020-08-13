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
using BLL;

namespace DoAn
{
    public partial class frmPOS : Office2007Form
    {
        public NHAN_VIEN NhanVien;

        KhachHangBLL kh = new KhachHangBLL();
        LoaiKhachHangBLL l = new LoaiKhachHangBLL();
        HoaDonBLL h = new HoaDonBLL();
        public frmPOS()
        {
            InitializeComponent();
        }

        private void txtMaKH_ButtonCustomClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = kh.TimKiemKhachHang(txtMaKH.Text);
                lbKH.Text = dr["TenKH"].ToString();
                DataRow dr2 = l.TimLoaiKH((dr["MaLoaiKH"].ToString()));
                lbGiamGia.Text = dr2["GiamGia"].ToString() + " %";
                lbLoaiThe.Text = dr2["TenLoaiKH"].ToString();
            }
            catch (Exception)
            {
                lbKH.Text = "Không có";
                lbGiamGia.Text = "0 %";
                lbLoaiThe.Text = "Đồng";
            }
            
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {
            lbThoiGian.Text = "Thời gian: " + DateTime.Now;
            lbNhanVien.Text = "Nhân viên bán hàng: " + NhanVien.TenNV;
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMaKH_ButtonCustomClick(sender, e);
        }

        private void lbTongTien_TextChanged(object sender, EventArgs e)
        {
            lbCanTra.Text =string.Format("{0:0,0}", int.Parse(lbTongTien.Text) * (1 - double.Parse(lbGiamGia.Text.Remove(lbGiamGia.Text.Length - 1, 1)) / 100));
        }


        private void lbGiamGia_TextChanged(object sender, EventArgs e)
        {
            lbCanTra.Text = string.Format("{0:0,0}", int.Parse(lbTongTien.Text) * (1 - double.Parse(lbGiamGia.Text.Remove(lbGiamGia.Text.Length-1, 1)) / 100));
        }

        private void txtThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //string kq = textBox1.Text.Replace;
                int canTra = Convert.ToInt32(string.Format("{0:0}",lbCanTra.Text.Replace(",", "")));
                lbTienThua.Text = string.Format("{0:0,0}", int.Parse(txtThanhToan.Text) - canTra);
            }
        }
        int maHD;
        private void btnTaoMoiHD_Click(object sender, EventArgs e)
        {
            h.ThemHoaDon(txtMaKH.Text, NhanVien.MaNV, DateTime.Now, int.Parse(lbGiamGia.Text.Remove(lbGiamGia.Text.Length - 1, 1)));

        }
    }
}
