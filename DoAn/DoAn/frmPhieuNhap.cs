using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_DAL;
using GUI;
using DevComponents.DotNetBar;

namespace DoAn
{
    public partial class frmPhieuNhap : Office2007Form
    {
        ChiTietPhieuNhapBLL ctpn = new ChiTietPhieuNhapBLL();
        SanPhamBLL sp = new SanPhamBLL();
        NhaCungCapBLL ncc = new NhaCungCapBLL();
        NhanVienBLL nv = new NhanVienBLL();
        PhieuNhapBLL pn = new PhieuNhapBLL();

        public PHIEU_NHAP phieuNhap;


        public frmPhieuNhap()
        {
            InitializeComponent();
        }

        public frmPhieuNhap(PHIEU_NHAP phNhap)
        {
            InitializeComponent();
            this.phieuNhap = phNhap;
        }

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            loadNhanVien();
            loadSanPham();
            loadNhaCungCap();
            loadPhieuNhap();

            loadCTPN(cboPhieuNhap.SelectedValue.ToString());

            if (phieuNhap != null)
            {
                cboPhieuNhap.SelectedValue = phieuNhap.MaPN;
                cboNhaCungCap.SelectedValue = phieuNhap.MaNCC;
                txtGiamGia.Text = phieuNhap.GiamGia + "";
                cboNhanVien.SelectedValue = phieuNhap.MaNV;
                dtmThoiGian.Value = (DateTime)phieuNhap.ThoiGian;
                txtTongTien.Text = phieuNhap.TongTien.ToString();
            }
        }

        public void loadCTPN(string ma)
        {
            dtgvChiTietPN.DataSource = ctpn.GetCTPN(ma);
        }

        public void loadNhanVien()
        {
            cboNhanVien.DataSource = nv.GetNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
        }

        public void loadSanPham()
        {
            cboSP.DataSource = sp.GetSanPham();
            cboSP.DisplayMember = "TenSP";
            cboSP.ValueMember = "MaSP";
        }

        public void loadNhaCungCap()
        {
            cboNhaCungCap.DataSource = ncc.GetNhaCungCap();
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        public void loadPhieuNhap()
        {
            cboPhieuNhap.DataSource = pn.GetPhieuNhap();
            cboPhieuNhap.DisplayMember = "MaPN";
            cboPhieuNhap.ValueMember = "MaPN";
        }

        private void dtgvChiTietPN_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                cboSP.SelectedValue = dtgvChiTietPN.CurrentRow.Cells[2].Value.ToString();
                txtGiaNhap.Text = Convert.ToInt64(dtgvChiTietPN.CurrentRow.Cells[3].Value) + "";
                txtGG.Text = dtgvChiTietPN.CurrentRow.Cells[4].Value.ToString();
                txtSL.Text = dtgvChiTietPN.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception)
            {
            }
            
        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            //Thêm
            if (!pn.KiemTraKhoaChinh(txtMaPN.Text))
            {
                pn.ThemPhieuNhap(txtMaPN.Text, cboNhaCungCap.SelectedValue.ToString(), cboNhanVien.SelectedValue.ToString(), dtmThoiGian.Value, int.Parse(txtGiamGia.Text));
                MessageBox.Show("Thêm phiếu nhập thành công.", "SUCCESSFUL");
                loadPhieuNhap();
            }
            else //Sửa
            {
                pn.SuaPhieuNhap(txtMaPN.Text, cboNhaCungCap.SelectedValue.ToString(), cboNhanVien.SelectedValue.ToString(), dtmThoiGian.Value, int.Parse(txtGiamGia.Text),Convert.ToInt64(txtTongTien.Text));
                MessageBox.Show("Sửa phiếu nhập thành công.", "SUCCESSFUL");
                //loadPhieuNhap();
            }
        }

        private void mnuXoaSP_Click(object sender, EventArgs e)
        {
            btnXoaCTPN.PerformClick();
        }

        private void mnuSuaSP_Click(object sender, EventArgs e)
        {
            btnSuaCTPN.PerformClick();
        }

        private void mnuInPN_Click(object sender, EventArgs e)
        {

        }

        private void btnThemCTPN_Click(object sender, EventArgs e)
        {
            if(ctpn.KiemTraKhoaChinh(cboPhieuNhap.SelectedValue.ToString(),cboSP.SelectedValue.ToString()))
            {
                MessageBox.Show("Phiếu nhập đã tồn tại sản phẩm này.","ERROR");
                return;
            }
            ctpn.ThemCTPN(cboPhieuNhap.SelectedValue.ToString(), cboSP.SelectedValue.ToString(), int.Parse(txtSL.Text), int.Parse(txtGG.Text), Convert.ToInt64(txtGiaNhap.Text));
            loadCTPN(cboPhieuNhap.SelectedValue.ToString());
            pn.SuaPhieuNhap(txtMaPN.Text, cboNhaCungCap.SelectedValue.ToString(), cboNhanVien.SelectedValue.ToString(), dtmThoiGian.Value, int.Parse(txtGiamGia.Text), ctpn.TinhTongTien(txtMaPN.Text));
            cboPhieuNhap_TextChanged(sender, e);
            MessageBox.Show("Thêm sản phẩm vào phiếu nhập thành công.","SUCCESSFUL");
        }

        private void btnXoaCTPN_Click(object sender, EventArgs e)
        {
            if (!ctpn.KiemTraKhoaChinh(cboPhieuNhap.SelectedValue.ToString(), cboSP.SelectedValue.ToString()))
            {
                MessageBox.Show("Phiếu nhập không tồn tại sản phẩm này.", "ERROR");
                return;
            }
            ctpn.XoaCTPN(cboPhieuNhap.SelectedValue.ToString(), cboSP.SelectedValue.ToString());
            loadCTPN(cboPhieuNhap.SelectedValue.ToString());
            pn.SuaPhieuNhap(txtMaPN.Text, cboNhaCungCap.SelectedValue.ToString(), cboNhanVien.SelectedValue.ToString(), dtmThoiGian.Value, int.Parse(txtGiamGia.Text), ctpn.TinhTongTien(txtMaPN.Text));
            cboPhieuNhap_TextChanged(sender, e);
            MessageBox.Show("Xóa sản phẩm trong phiếu nhập thành công.", "SUCCESSFUL");
        }

        private void btnSuaCTPN_Click(object sender, EventArgs e)
        {
            if (!ctpn.KiemTraKhoaChinh(cboPhieuNhap.SelectedValue.ToString(), cboSP.SelectedValue.ToString()))
            {
                MessageBox.Show("Phiếu nhập không tồn tại sản phẩm này.", "ERROR");
                return;
            }
            ctpn.SuaCTPN(cboPhieuNhap.SelectedValue.ToString(), cboSP.SelectedValue.ToString(), int.Parse(txtSL.Text), int.Parse(txtGG.Text), Convert.ToInt64(txtGiaNhap.Text));
            loadCTPN(cboPhieuNhap.SelectedValue.ToString());
            pn.SuaPhieuNhap(txtMaPN.Text, cboNhaCungCap.SelectedValue.ToString(), cboNhanVien.SelectedValue.ToString(), dtmThoiGian.Value, int.Parse(txtGiamGia.Text), ctpn.TinhTongTien(txtMaPN.Text));
            cboPhieuNhap_TextChanged(sender, e);
            MessageBox.Show("Sửa sản phẩm trong phiếu nhập thành công.", "SUCCESSFUL");
        }

        private void cboPhieuNhap_TextChanged(object sender, EventArgs e) 
        {
            try
            {
                txtMaPN.Text = cboPhieuNhap.Text;
                BLL_DAL.PHIEU_NHAP p = pn.TimPhieuNhapTheoMaPN(txtMaPN.Text);
                if (p != null)
                {
                    cboNhaCungCap.SelectedValue = p.MaNCC;
                    cboNhanVien.SelectedValue = p.MaNV;
                    dtmThoiGian.Value = (DateTime)p.ThoiGian;
                    txtTongTien.Text = p.TongTien + "";
                    txtGiamGia.Text = p.GiamGia + "";

                }
                loadCTPN(cboPhieuNhap.SelectedValue.ToString());
                txtTongTien.Text = ctpn.TinhTongTien(cboPhieuNhap.SelectedValue.ToString()) + "";
            }
            catch (Exception)
            {

            }

        }

        private void cboSP_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtGiaNhap.Text = sp.GetGiaTheoMaSP(cboSP.SelectedValue.ToString()) + "";
            //}
            //catch (Exception)
            //{
            //    txtGiaNhap.Text = sp.GetGiaTheoMaSP("SP001") + "";
            //}
            
        }

        private void btnXuatPhieu_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvChiTietPN.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<CHI_TIET_PHIEU_NHAP> pList = new List<CHI_TIET_PHIEU_NHAP>();
            foreach (DataGridViewRow item in dtgvChiTietPN.Rows)
            {
                CHI_TIET_PHIEU_NHAP i = new CHI_TIET_PHIEU_NHAP();
                i.MaSP = item.Cells[5].Value.ToString();
                i.MaPN = item.Cells[4].Value.ToString();
                i.SoLuong = Convert.ToInt32(item.Cells[8].Value.ToString());
                i.GiaNhap = Convert.ToInt32(item.Cells[6].Value);
                i.DonViTinh = item.Cells[3].Value.ToString();
                
                //i.DonViTinh = item.Cells[3].Value.ToString();
                //i.GiaBan = Convert.ToInt32(item.Cells[5].Value);
                //i.GiaVon = Convert.ToInt32(item.Cells[6].Value); ;
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportPhieuNhap(pList, ref path, false);
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }
    }
}
