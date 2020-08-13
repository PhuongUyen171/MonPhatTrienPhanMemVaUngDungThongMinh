using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ThietKeControl;
using BLL;
using BLL_DAL;
using System.IO;
using System.Globalization;
using GUI;
using DevExpress.XtraReports.UI;

namespace DoAn
{
    public partial class frmMain : Office2007RibbonForm
    {
        KhachHangBLL k = new KhachHangBLL();
        LoaiKhachHangBLL lkh = new LoaiKhachHangBLL();
        NhomNguoiDungBLL nnd = new NhomNguoiDungBLL();
        PhanQuyenBLL pq = new PhanQuyenBLL();
        NhanVienBLL nv = new NhanVienBLL();
        ManHinhBLL mh = new ManHinhBLL();
        ChucVuBLL cv = new ChucVuBLL();
        NhaCungCapBLL ncc = new NhaCungCapBLL();
        NhomHangHoaBLL hh = new NhomHangHoaBLL();
        NguoiDungBLL nd = new NguoiDungBLL();
        SanPhamBLL sp = new SanPhamBLL();
        PhieuNhapBLL pn = new PhieuNhapBLL();
        DangNhapBLL dn = new DangNhapBLL();
        PhieuKiemKhoBLL kk = new PhieuKiemKhoBLL();
        ThuongHieuBLL th = new ThuongHieuBLL();
        ThongKeBLL tk = new ThongKeBLL();
        QLShopDataContext data = new QLShopDataContext();

        public string tenDangNhap;

        public frmMain()
        {
            InitializeComponent();
            foreach (TabItem i in tabMain.Tabs)
                i.Visible = false;
            tabTrangChu.Visible = true;
            
        }





        //------------------------------------
        //Load data
        public void loadGiaoDienNhanVien()
        {
            pnNV.Controls.Clear();
            var tatCaNV = nv.GetNhanVien();
            foreach (var item in tatCaNV)
            {
                NhanVienButton btn = new NhanVienButton();
                btn.Text = item.TenNV;
                btn.Tag = item.MaNV;
                pnNV.Controls.Add(btn);
                btn.Click += Btn_Click;
            }
            txtTongNV.Text = "Có " + tatCaNV.Count() + " nhân viên.";

            cboTenNV.DataSource = nv.GetNhanVien();
            cboTenNV.DisplayMember = "TenNV";
            cboTenNV.ValueMember = "MaNV";

            cboNV.DataSource = nv.GetNhanVien();
            cboNV.DisplayMember = "TenNV";
            cboNV.ValueMember = "MaNV";

            cboNhanVien.DataSource = nv.GetNhanVien();
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
        }

        public void loadNhomHangHoa()
        {
            var tatca = hh.GetNhomHangHoa();
            dtgvNhomHH.DataSource = tatca;
            txtTongLoaiSP.Text = "Có "+tatca.Count()+" nhóm hàng hóa.";
        }

        public void loadPhanQuyen()
        {
            dtgvManHinhKoCQ.DataSource = mh.GetManHinhKoCQ(cboNhomND.SelectedValue.ToString());
            dtgvManHinhCQ.DataSource = mh.GetManHinhCQ(cboNhomND.SelectedValue.ToString());
        }

        public void loadNhomNguoiDung()
        {
            cboNhomND.DataSource = nnd.GetNhomNguoiDung();
            cboNhomND.DisplayMember = "TenNhom";
            cboNhomND.ValueMember = "MaNhom";


            cboNhomND2.DataSource = nnd.GetNhomNguoiDung();
            cboNhomND2.DisplayMember = "TenNhom";
            cboNhomND2.ValueMember = "MaNhom";
        }

        public void loadLoaiKH()
        {
            cboMaLoaiKH.DataSource = lkh.GetLoaiKH();
            cboMaLoaiKH.DisplayMember = "TenLoaiKH";
            cboMaLoaiKH.ValueMember = "MaLoaiKH";

            dtgvNhomKH.DataSource = lkh.GetLoaiKH();
            txtTongNhomKH.Text = "Có " + dtgvNhomKH.Rows.Count + " nhóm khách hàng.";
        }

        public void loadKhachHang()
        {
            dtgvKH.DataSource = k.GetKhachHang();
            txtTongKH.Text = "Có " + dtgvKH.Rows.Count + " khách hàng.";
        }

        public void loadChucVu()
        {
            cboChucVuNV.DataSource = cv.GetChucVu();
            cboChucVuNV.DisplayMember = "TenCV";
            cboChucVuNV.ValueMember = "MaCV";

            dtgvChucVu.DataSource = cv.GetChucVu();
            txtTongNhomCV.Text = "Có " + dtgvChucVu.Rows.Count + " chức vụ.";
        }

        public void loadNhaCungCap()
        {
            var tatca = ncc.GetNhaCungCap();
            dtgvNhaCungCap.DataSource = tatca;
            txtTongNCC.Text = tatca.Count() + "";
            txtTongChi_NCC.Text = Convert.ToInt32(tatca.Sum(t => t.TongTien)) + " VNĐ";

            cboNhaCungCap.DataSource = ncc.GetNhaCungCap();
            cboNhaCungCap.DisplayMember = "TenNCC";
            cboNhaCungCap.ValueMember = "MaNCC";
        }

        public void loadGiaoDienNhomND()
        {
            pnNguoiDung.Controls.Clear();
            var tatCaND = nv.GetNhanVienTheoDangNhap();
            foreach (var item in tatCaND)
            {
                NguoiDungButton btnNguoiDung = new NguoiDungButton();
                try
                {
                    BLL_DAL.DANG_NHAP d = dn.TimTaiKhoan(item.MaNV);
                    btnNguoiDung = new NguoiDungButton(d.TinhTrang == true);
                }
                catch (Exception)
                {
                    btnNguoiDung = new NguoiDungButton((bool)false);
                }

                btnNguoiDung.Text = item.TenNV;
                btnNguoiDung.Tag = item.MaNV;
                pnNguoiDung.Controls.Add(btnNguoiDung);
                btnNguoiDung.Click += BtnNguoiDung_Click;
            }
        }

        public void loadGiaoDienThuongHieu()
        {
            pnThuongHieu.Controls.Clear();
            var tatCa = th.GetThuongHieu();
            foreach (var item in tatCa)
            {
                ThuongHieuButton btnThuongHieu=new ThuongHieuButton();
                try
                {
                    btnThuongHieu = new ThuongHieuButton(th.TimHinhAnh(item.MaTH));
                }
                catch (Exception)
                {
                    btnThuongHieu = new ThuongHieuButton();
                }
                btnThuongHieu.Text = item.TenTH;
                btnThuongHieu.Tag = item.MaTH;
                pnThuongHieu.Controls.Add(btnThuongHieu);
                btnThuongHieu.Click += BtnThuongHieu_Click;
            }

            cboThuongHieu.DataSource = th.GetThuongHieu();
            cboThuongHieu.DisplayMember = "TenTH";
            cboThuongHieu.ValueMember = "MaTH";
        }

        public void loadNguoiDung()
        {
            var nguoiDung = nd.GetNguoiDung();
            txtTongNhomND.Text = "Có " + nguoiDung.Count() + " người dùng.";
        }

        public void loadSanPham()
        {
            var tatCaSP = sp.GetSanPham();
            dtgvSanPham.DataSource = tatCaSP;
        }

        public void loadLoaiSP()
        {
            var tatca = hh.GetNhomHangHoa();
            cboLoaiSP.DataSource = tatca;
            cboLoaiSP.DisplayMember = "TenLoaiSP";
            cboLoaiSP.ValueMember = "MaLoaiSP";
        }

        public void loadPhieuNhap()
        {
            var tatca = pn.GetPhieuNhap();
            dtgvPhieuNhap.DataSource = tatca;
            txtTongTienNhapHang.Text = string.Format("{0:0,0} VNĐ", Convert.ToInt64(tatca.Sum(t => t.TongTien)));
        }

        public void loadKiemKho()
        {
            var tatca = kk.GetPhieuKiemKho();
            dtgvKiemKho.DataSource = tatca;
        }





        //-----------------------------------------------
        //Form main
        private void frmMain_Load(object sender, EventArgs e)
        {
            loadKhachHang();
            loadLoaiKH();
            loadNhomNguoiDung();
            loadPhanQuyen();
            loadChucVu();
            loadNhomHangHoa();
            loadNhaCungCap();
            
            loadNguoiDung();
            loadSanPham();
            loadLoaiSP();
            loadPhieuNhap();
            loadKiemKho();
            loadGiaoDienThuongHieu();
            loadGiaoDienNhomND();
            loadGiaoDienNhanVien();
        }

        private void itemLogout_Click(object sender, EventArgs e)
        {
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            NhanVienButton btn = (NhanVienButton)sender as NhanVienButton;
            BLL_DAL.NHAN_VIEN item = nv.TimNhanVien(btn.Tag.ToString());
            txtCMND_NV.Text = item.CMND;
            txtEmailNV.Text = item.Email;
            txtSDT_NV.Text = item.SDT;
            txtTenNV.Text = item.TenNV;
            txtMaNV.Text = item.MaNV;
            dtmNgaySinhNV.Text = item.NgaySinh + "";
            cboChucVuNV.SelectedValue = item.MaCV;
        }

        private void BtnThuongHieu_Click(object sender, EventArgs e)
        {
            ThuongHieuButton btn = (ThuongHieuButton)sender as ThuongHieuButton;
            THUONG_HIEU item = th.TimThuongHieu(btn.Tag.ToString());
            txtMaTH.Text = item.MaTH;
            txtTenTH.Text = item.TenTH;
            if(item.Images!=null)
                picTH.Image = new Bitmap(Application.StartupPath + "\\Resource\\" + th.TimHinhAnh(item.MaTH));
            else
                picTH.Image = new Bitmap(Application.StartupPath + "\\Resource\\KoXacDinh.jpg");
            tenHinhTH = th.TimHinhAnh(item.MaTH);
        }

        private void BtnNguoiDung_Click(object sender, EventArgs e)
        {
            NguoiDungButton btn = (NguoiDungButton)sender as NguoiDungButton;
            BLL_DAL.DANG_NHAP item = dn.TimTaiKhoan(btn.Tag.ToString());
            cboNhomND2.SelectedValue = nd.GetMaNhomTheoNguoiDung(item.TaiKhoan);
            cboTenNV.SelectedValue = item.MaNV;
            txtTenDN.Text = item.TaiKhoan;
            txtMK1.Text = item.MatKhau;
            txtMK2.Text = item.MatKhau;
            if (item.TinhTrang == true)
                cbkKichHoat.Checked = true;
            else
                cbkKichHoat.Checked = false;
        }

        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            XuLyDongTabItem();
            e.Cancel = true;
        }

        void XuLyDongTabItem()
        {
            TabItem chon = tabMain.SelectedTab;
            DialogResult r = MessageBox.Show("Bạn muốn tắt trang " + chon.Text.ToLower() + " không?", "Tắt trang", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                chon.Visible = false;

        }

        private void itemGioiThieu_Click(object sender, EventArgs e)
        {
            frmGioiThieu frm = new frmGioiThieu();
            frm.Show();
        }

        void buttonItem_Click(object sender,EventArgs e)
        {
            ButtonItem btn = (ButtonItem)sender as ButtonItem;
            foreach (TabItem item in tabMain.Tabs)
            {
                if (string.Compare(item.Name, btn.Tag + "", true) == 0)
                {
                    if (item.Visible == false)
                        item.Visible = true;
                    tabMain.SelectedTab = item;
                    
                }
            }
        }

        private void itemDoiPass_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.tenDangNhap = tenDangNhap;
            frm.Show();
        }

        private void itemInfor_Click(object sender, EventArgs e)
        {
            frmThongTinSD frm = new frmThongTinSD();
            frm.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đóng ứng dụng?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void itemCuaSoBanHang_Click(object sender, EventArgs e)
        {
            frmPOS frm = new frmPOS();
            frm.NhanVien = nv.TimTaiKhoanNhanVien(tenDangNhap);
            frm.Show();
        }

        private void itemSave_Click(object sender, EventArgs e)
        {
            frmSaoLuu frm = new frmSaoLuu();
            frm.Show();
        }

        private void itemBackUp_Click(object sender, EventArgs e)
        {
            frmPhucHoi frm = new frmPhucHoi();
            frm.Show();
        }

        private void gdOffice2007Blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Blue;
        }

        private void gdOffice2007Silver_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Silver;
        }

        private void gdOffice2007Black_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Black;
        }

        private void gdOffice2010Blue_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Blue;
        }

        private void gdOffice2010Silver_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Silver;
        }

        private void gdOffice2010Black_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Black;
        }





        //--------------------------------------------
        //Form danh sách nhân viên: linq : còn excel:3 tầng
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if(nv.KiemTraKhoaChinh(txtMaNV.Text))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại.","ERROR");
                    return;
                }
                nv.ThemNhanVien(txtMaNV.Text, txtTenNV.Text, txtEmailNV.Text,txtCMND_NV.Text, txtSDT_NV.Text, dtmNgaySinhNV.Value, cboChucVuNV.SelectedValue.ToString());
                loadGiaoDienNhanVien();
                MessageBox.Show("Thêm nhân viên thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm mới nhân viên.","ERROR");
                return;
            }
        }

        private void btnClearNV_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnNhanVien.Controls)
                if (item is TextBox)
                    item.Text = string.Empty;
        }
        
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (!nv.KiemTraKhoaChinh(txtMaNV.Text))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại.", "ERROR");
                    return;
                }
                nv.XoaNhanVien(txtMaNV.Text);
                loadGiaoDienNhanVien();
                MessageBox.Show("Xóa nhân viên thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhân viên này.","ERROR");
                return;
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if(!nv.KiemTraKhoaChinh(txtMaNV.Text))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại.","ERROR");
                    return;
                }    
                nv.SuaNhanVien(txtMaNV.Text, txtTenNV.Text, txtEmailNV.Text, txtCMND_NV.Text, txtSDT_NV.Text, dtmNgaySinhNV.Value, cboChucVuNV.SelectedValue.ToString());
                loadGiaoDienNhanVien();
                MessageBox.Show("Sửa thông tin nhân viên thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể sửa thông tin nhân viên này.", "ERROR");
                return;
            }
        }

        private void btnExcelNV_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (pnNV.Controls.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<NHAN_VIEN> pList = new List<NHAN_VIEN>();
            foreach (Control item in pnNV.Controls)
            {
                NHAN_VIEN i = new NHAN_VIEN();
                i.MaNV = item.Tag.ToString();
                i.TenNV = item.Text;
                i.SDT = nv.TimNhanVien(i.MaNV).SDT;
                i.MaCV = nv.TimNhanVien(i.MaNV).MaCV;
                i.CMND = nv.TimNhanVien(i.MaNV).CMND;
                i.Email = nv.TimNhanVien(i.MaNV).Email;
                i.NgaySinh = nv.TimNhanVien(i.MaNV).NgaySinh;
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportNhanVien(pList, ref path, false);

            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }





        //------------------------------------------------
        //Form danh sách khách hàng: 3 lớp : còn excel
        private void dtgvKH_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                txtMaKH.Text = dtgvKH.CurrentRow.Cells[1].Value.ToString();
                txtTenKH.Text = dtgvKH.CurrentRow.Cells[2].Value.ToString();
                cboMaLoaiKH.SelectedValue = dtgvKH.CurrentRow.Cells[3].Value.ToString();
                dtmNgaySinh_KH.Value = Convert.ToDateTime(dtgvKH.CurrentRow.Cells[4].Value);
                dtmNDK_KH.Value = Convert.ToDateTime(dtgvKH.CurrentRow.Cells[5].Value);
                txtCMND_KH.Text = dtgvKH.CurrentRow.Cells[6].Value.ToString();
                txtSDT_KH.Text = dtgvKH.CurrentRow.Cells[7].Value.ToString();
                txtEmail_KH.Text = dtgvKH.CurrentRow.Cells[8].Value.ToString();
                txtDiaChi_KH.Text = dtgvKH.CurrentRow.Cells[9].Value.ToString();
                txtTongTien_KH.Text = Convert.ToInt32(dtgvKH.CurrentRow.Cells[10].Value) + "";
            }
            catch (Exception)
            {
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (!k.KiemTraKhoaChinh(txtMaKH.Text))
            {
                if (k.ThemKhachHang(txtMaKH.Text, txtTenKH.Text, cboMaLoaiKH.SelectedValue.ToString(), dtmNgaySinh_KH.Value, dtmNgaySinh_KH.Value, txtCMND_KH.Text, txtEmail_KH.Text, txtSDT_KH.Text, txtDiaChi_KH.Text, 0))
                {
                    loadKhachHang();
                    MessageBox.Show("Thêm khách hàng thành công.", "SUCCESSFUL");
                }
                else
                    MessageBox.Show("Lỗi không thể thêm khách hàng.", "ERROR");
                return;
            }
            else
            {
                MessageBox.Show("Mã khách hàng đã tồn tại.", "ERROR");
                return;
            }
        }

        private void btnClearKH_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnKH.Controls)
                if (item is TextBox || item is RichTextBox)
                    item.Text = string.Empty;
            txtMaKH.Focus();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (k.XoaKhachHang(dtgvKH.CurrentRow.Cells[0].Value.ToString()))
            {
                loadKhachHang();
                MessageBox.Show("Xóa khách hàng thành công.", "SUCCESSFUL");
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (k.KiemTraKhoaChinh(txtMaKH.Text))
            {
                if (k.SuaKhachHang(txtMaKH.Text, txtTenKH.Text, cboMaLoaiKH.SelectedValue.ToString(), dtmNgaySinh_KH.Value, dtmNDK_KH.Value, txtCMND_KH.Text, txtEmail_KH.Text, txtSDT_KH.Text, txtDiaChi_KH.Text, 0))
                {
                    loadKhachHang();
                    MessageBox.Show("Sửa thông tin khách hàng thành công.", "SUCCESSFUL");
                }
                else
                    MessageBox.Show("Lỗi không thể sửa thông tin khách hàng.", "ERROR");
                return;
            }
            else
            {
                MessageBox.Show("Mã khách hàng chưa đã tồn tại.", "ERROR");
                return;
            }
        }

        private void btnExcelKH_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<KHACH_HANG> pList = new List<KHACH_HANG>();
            foreach (DataGridViewRow item in dtgvKH.Rows)
            {
                KHACH_HANG i = new KHACH_HANG();
                i.MaKH = item.Cells[1].Value.ToString();
                i.TenKH = item.Cells[2].Value.ToString();
                i.MaLoaiKH= item.Cells[3].Value.ToString();
                i.NgaySinh= Convert.ToDateTime(item.Cells[4].Value.ToString());
                i.NgayDangKy= Convert.ToDateTime(item.Cells[5].Value.ToString());
                i.CMND= item.Cells[6].Value.ToString();
                i.Email= item.Cells[7].Value.ToString();
                i.SDT= item.Cells[8].Value.ToString();
                i.DiaChi= item.Cells[9].Value.ToString();
                i.TongTienMua= Convert.ToInt32(item.Cells[10].Value);
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportKhachHang(pList, ref path, false);
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }





        //----------------------------------------
        //Form danh sách nhóm hàng hóa: linq : còn excel: 3 lớp
        private void btnThemNhomHH_Click(object sender, EventArgs e)
        {
            try
            {
                if(hh.KiemTraKhoaChinh(txtMaNhomHH.Text))
                {
                    MessageBox.Show("Mã nhóm hàng hóa đã tồn tại.","ERROR");
                    return;
                }    
                hh.ThemNhomHangHoa(txtMaNhomHH.Text, txtTenNhomHH.Text);
                loadNhomHangHoa();
                MessageBox.Show("Thêm nhóm hàng hóa thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm mới nhóm hàng hóa.", "ERROR");
                return;
            }
        }

        private void btnXoaNhomHH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!hh.KiemTraKhoaChinh(txtMaNhomHH.Text))
                {
                    MessageBox.Show("Mã nhóm hàng hóa không tồn tại.", "ERROR");
                    return;
                }
                hh.XoaNhomHangHoa(txtMaNhomHH.Text);
                loadNhomHangHoa();
                MessageBox.Show("Xóa nhóm hàng hóa thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhóm hàng hóa này.", "ERROR");
                return;
            }
        }

        private void btnExcelNhomHH_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvNhomHH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<THE_LOAI_SAN_PHAM> pList = new List<THE_LOAI_SAN_PHAM>();
            foreach (DataGridViewRow item in dtgvNhomHH.Rows)
            {
                THE_LOAI_SAN_PHAM i = new THE_LOAI_SAN_PHAM();
                i.TenLoaiSP = item.Cells[1].Value.ToString();
                i.MaLoaiSP = item.Cells[0].Value.ToString();
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportNhomHangHoa(pList, ref path, false);
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void btnSuaNhomHH_Click(object sender, EventArgs e)
        {
            try
            {
                if (!hh.KiemTraKhoaChinh(txtMaNhomHH.Text))
                {
                    MessageBox.Show("Mã nhóm hàng hóa không tồn tại.", "ERROR");
                    return;
                }
                hh.SuaNhomHangHoa(txtMaNhomHH.Text, txtTenNhomHH.Text);
                MessageBox.Show("Sửa thông tin nhóm hàng hóa thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể sửa thông tin nhóm hàng hóa này.", "ERROR");
                return;
            }
        }

        private void dtgvNhomHH_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNhomHH.Text= dtgvNhomHH.CurrentRow.Cells[0].Value.ToString(); 
            txtTenNhomHH.Text = dtgvNhomHH.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnClearNhomHH_Click(object sender, EventArgs e)
        {
            txtTenNhomHH.Clear();
            txtMaNhomHH.Clear();
            txtMaNhomHH.Focus();
        }





        //---------------------------------------------------
        //Form danh sách nhóm đối tượng: 3 lớp : còn excel
        private void btnThemNhomCV_Click(object sender, EventArgs e)
        {
            frmChucVu frm = new frmChucVu();
            frm.Show();
        }

        private void btnSuaNhomCV_Click(object sender, EventArgs e)
        {
            ChucVu cv = new ChucVu(dtgvChucVu.CurrentRow.Cells[0].Value.ToString(), dtgvChucVu.CurrentRow.Cells[1].Value.ToString());
            frmChucVu frm = new frmChucVu(cv);
            frm.Show();
        }

        private void btnThemNhomKH_Click(object sender, EventArgs e)
        {
            frmNhomKhachHang frm = new frmNhomKhachHang();
            frm.Show();
        }

        private void btnSuaNhomKH_Click(object sender, EventArgs e)
        {
            NhomKhachHang lkh = new NhomKhachHang();
            lkh.MaNhomKH = dtgvNhomKH.CurrentRow.Cells[0].Value.ToString();
            lkh.TenNhomKH= dtgvNhomKH.CurrentRow.Cells[1].Value.ToString();
            lkh.GioiHanDuoi= Convert.ToInt64(dtgvNhomKH.CurrentRow.Cells[2].Value);
            lkh.GioiHanTren= Convert.ToInt64(dtgvNhomKH.CurrentRow.Cells[3].Value);
            lkh.GiamGia= Convert.ToInt16(dtgvNhomKH.CurrentRow.Cells[4].Value);
            frmNhomKhachHang frm = new frmNhomKhachHang(lkh);
            frm.Show();
        }

        private void btnXoaNhomCV_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn muốn xóa chức vụ "+dtgvChucVu.CurrentRow.Cells[1].Value.ToString()+" ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                    return;

                string ma = dtgvChucVu.CurrentRow.Cells[0].Value.ToString();
                cv.XoaChucVu(ma);
                loadChucVu();
                MessageBox.Show("Xóa nhóm chức vụ thành công.","SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhóm chức vụ.","ERROR");
                return;
            }
        }

        private void btnXoaNhomKH_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult r = MessageBox.Show("Bạn muốn xóa nhóm khách hàng " + dtgvNhomKH.CurrentRow.Cells[1].Value.ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (r == DialogResult.No)
                    return;

                string ma = dtgvNhomKH.CurrentRow.Cells[0].Value.ToString();
                lkh.XoaLoaiKH(ma);
                loadLoaiKH();
                MessageBox.Show("Xóa nhóm khách hàng thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhóm khách hàng.", "ERROR");
                return;
            }
        }

        private void btnExcelNhomCV_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvChucVu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<CHUC_VU> pList = new List<CHUC_VU>();
            foreach (DataGridViewRow item in dtgvChucVu.Rows)
            {
                CHUC_VU i = new CHUC_VU();
                i.TenCV = item.Cells[1].Value.ToString();
                //i.GioiHanDuoi = Convert.ToInt32(item.Cells[2].Value);
                //i.GioiHanTren = Convert.ToInt32(item.Cells[3].Value);
                //i.GiamGia = Convert.ToInt32(item.Cells[4].Value.ToString());
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportChucVu(pList, ref path, false);
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void btnExcelNhomKH_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvNhomKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<NhomKhachHang> pList = new List<NhomKhachHang>();
            foreach (DataGridViewRow item in dtgvNhomKH.Rows)
            {
                NhomKhachHang i = new NhomKhachHang();
                i.TenNhomKH = item.Cells[1].Value.ToString();
                i.GioiHanDuoi = Convert.ToInt32(item.Cells[2].Value);
                i.GioiHanTren = Convert.ToInt32(item.Cells[3].Value);
                i.GiamGia = Convert.ToInt32(item.Cells[4].Value.ToString());
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportNhomKH(pList, ref path, false);
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void btnTaiNhomCV_Click(object sender, EventArgs e)
        {
            loadChucVu();
        }

        private void btnTaiNhomKH_Click(object sender, EventArgs e)
        {
            loadLoaiKH();
        }





        //---------------------------------------------
        //Form phân quyền: 3 lớp:  chưa load form giao diện
        private void cboNhomND_TextChanged(object sender, EventArgs e)
        {
            loadPhanQuyen();
        }

        private void btnThemPQ_Click(object sender, EventArgs e)
        {
            if (pq.SuaPhanQuyen(cboNhomND.SelectedValue.ToString(), dtgvManHinhKoCQ.CurrentRow.Cells[0].Value.ToString(), true))
            {
                loadPhanQuyen();
                MessageBox.Show("Thêm quyền thành công.","SUCCESSFUL");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình thêm phân quyền.","ERROR");
            }    
        }

        private void btnXoaPQ_Click(object sender, EventArgs e)
        {
            if (pq.SuaPhanQuyen(cboNhomND.SelectedValue.ToString(),dtgvManHinhCQ.CurrentRow.Cells[0].Value.ToString(), false))
            {
                loadPhanQuyen();
                MessageBox.Show("Xóa quyền thành công.", "SUCCESSFUL");
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa phân quyền.", "ERROR");
            }
        }





        //---------------------------------------------
        //Form quản lý nhà cung cấp: linq : còn xuất excel:3 tầng
        private void dtgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNCC.Text = dtgvNhaCungCap.CurrentRow.Cells[1].Value.ToString();
            txtTenNCC.Text= dtgvNhaCungCap.CurrentRow.Cells[2].Value.ToString();
            txtMaSoThue.Text= dtgvNhaCungCap.CurrentRow.Cells[3].Value.ToString();
            txtDiaChiNCC.Text= dtgvNhaCungCap.CurrentRow.Cells[4].Value.ToString();
            txtEmailNCC.Text= dtgvNhaCungCap.CurrentRow.Cells[5].Value.ToString();
            txtSDT_NCC.Text= dtgvNhaCungCap.CurrentRow.Cells[6].Value.ToString();
            txtTongTienNCC.Text= Convert.ToInt32(dtgvNhaCungCap.CurrentRow.Cells[7].Value)+"";
        }

        private void btnClearNCC_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnNCC_Tren.Controls)
                if (item is TextBox)
                    item.Text = string.Empty;
            txtMaNCC.Focus();
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ncc.KiemTraKhoaChinh(txtMaNCC.Text))
                {
                    ncc.ThemNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtMaSoThue.Text, txtDiaChiNCC.Text, txtEmailNCC.Text, txtSDT_NCC.Text);
                    loadNhaCungCap();
                    MessageBox.Show("Thêm nhà cung cấp thành công.", "SUCCESSFUL");
                }
                else
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại.","ERROR");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể thêm mới nhà cung cấp.", "ERROR");
                return;
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ncc.KiemTraKhoaChinh(txtMaNCC.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp không tồn tại.", "ERROR");
                    return;
                }
                ncc.XoaNhaCungCap(txtMaNCC.Text);
                loadNhaCungCap();
                MessageBox.Show("Xóa nhà cung cấp thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhà cung cấp này.", "ERROR");
                return;
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ncc.KiemTraKhoaChinh(txtMaNCC.Text))
                {
                    MessageBox.Show("Mã nhà cung cấp không tồn tại.", "ERROR");
                    return;
                }
                ncc.SuaNhaCungCap(txtMaNCC.Text, txtTenNCC.Text, txtMaSoThue.Text, txtDiaChiNCC.Text, txtEmailNCC.Text, txtSDT_NCC.Text,Convert.ToInt64( txtTongTienNCC.Text));
                MessageBox.Show("Sửa thông tin nhà cung cấp thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể sửa thông tin nhà cung cấp này.", "ERROR");
                return;
            }
        }

        private void btnExcelNCC_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvNhaCungCap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<NHA_CUNG_CAP> pList = new List<NHA_CUNG_CAP>();
            // Đổ dữ liệu vào danh sách
            foreach (DataGridViewRow item in dtgvNhaCungCap.Rows)
            {
                NHA_CUNG_CAP i = new NHA_CUNG_CAP();
                i.TenNCC = item.Cells[2].Value.ToString();
                i.DiaChi = item.Cells[4].Value.ToString();
                i.SDT = item.Cells[6].Value.ToString();
                pList.Add(i);
            }
            string path = string.Empty;

            //SinhVien sv = svl.TimSinhVien(dtgvSV.CurrentRow.Cells[0].Value.ToString());
            excel.ExportNhaCungCap(pList, ref path, false);

            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void mnuXoaNCC_Click(object sender, EventArgs e)
        {
            btnXoaNCC.PerformClick();
        }

        private void mnuSuaNCC_Click(object sender, EventArgs e)
        {
            btnSuaNCC.PerformClick();
        }





        //------------------------------------------
        //Form quản lý người dùng: thêm, xóa, sửa, clear chưa làm

        private void btnThemND_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaND_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaND_Click(object sender, EventArgs e)
        {

        }

        private void btnClearND_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_ND_Click(object sender, EventArgs e)
        {

        }






        //--------------------------------------------------
        //Form quản lý sản phẩm
        private void dtgvSanPham_SelectionChanged(object sender, EventArgs e)
        {
            txtMaSP.Text = dtgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dtgvSanPham.CurrentRow.Cells[2].Value.ToString();
            cboLoaiSP.SelectedValue = dtgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtDVT_SP.Text = dtgvSanPham.CurrentRow.Cells[3].Value.ToString();
            txtSoLuongSP.Text = dtgvSanPham.CurrentRow.Cells[4].Value.ToString();
            txtGiaBan.Text = Convert.ToInt64(dtgvSanPham.CurrentRow.Cells[5].Value) + "";
            txtGiaNhapCuoi.Text = Convert.ToInt64(dtgvSanPham.CurrentRow.Cells[6].Value) + "";
            cboThuongHieu.SelectedValue = dtgvSanPham.CurrentRow.Cells[10].Value.ToString();
            cbkTrangThai.Checked = Convert.ToBoolean(dtgvSanPham.CurrentRow.Cells[7].Value.ToString());
            txtMoTaSP.Text = dtgvSanPham.CurrentRow.Cells[9].Value.ToString();
            //MessageBox.Show(Application.StartupPath + "\\Resource\\" + dtgvSanPham.CurrentRow.Cells[9].Value.ToString());
            Bitmap bt = new Bitmap(Application.StartupPath + "\\Resource\\" + dtgvSanPham.CurrentRow.Cells[8].Value.ToString());
            picSP.Image = bt;
        }
        string tenHinh;
        private void btnHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "(*.img)|*.img|(*.png)|*.png|(*.jpg)|*.jpg";
            if (op.ShowDialog() == DialogResult.OK)
            {
                picSP.Image = new Bitmap(op.FileName);
                tenHinh=Path.GetFileName(op.FileName);

                //StreamReader rd = new StreamReader(op.FileName);
                //MessageBox.Show(rd.ReadToEnd());
                //rd.Close();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                if(sp.KiemTraKhoaChinh(txtMaSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại.", "ERROR");
                    return;
                }
                sp.ThemSanPham(txtMaSP.Text,txtTenSP.Text,cboLoaiSP.SelectedValue.ToString(),Convert.ToInt64(txtGiaBan.Text),Convert.ToInt64(txtGiaVon.Text),int.Parse(txtSoLuongSP.Text),txtDVT_SP.Text,cbkTrangThai.Checked,tenHinh);
                loadSanPham();
                MessageBox.Show("Thêm sản phẩm thành công.","SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình thêm sản phẩm.","ERROR");
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!sp.KiemTraKhoaChinh(txtMaSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại.", "ERROR");
                    return;
                }
                sp.SuaSanPham(txtMaSP.Text, txtTenSP.Text, cboLoaiSP.SelectedValue.ToString(), Convert.ToInt64(txtGiaBan.Text), Convert.ToInt64(txtGiaVon.Text), int.Parse(txtSoLuongSP.Text), txtDVT_SP.Text, cbkTrangThai.Checked, tenHinh);
                loadSanPham();
                MessageBox.Show("Sửa thông tin sản phẩm thành công", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình sửa thông tin sản phẩm.", "ERROR");
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            try
            {
                if(!sp.KiemTraKhoaChinh(txtMaSP.Text))
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại.","ERROR");
                    return;
                }
                sp.XoaSanPham(txtMaSP.Text);
                loadSanPham();
                MessageBox.Show("Xóa sản phẩm thành công","SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa sản phẩm.","ERROR");
            }
        }

        private void btnClearSP_Click(object sender, EventArgs e)
        {
            //foreach (Control item in grThongTinSP.Controls)
            //    if (item is TextBox)
            //        item.Text = string.Empty;
            //txtMaSP.Focus();
            //picSP.ImageLocation = string.Empty;
        }

        private void btnExcelSP_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (dtgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<SAN_PHAM> pList = new List<SAN_PHAM>();
            foreach (DataGridViewRow item in dtgvSanPham.Rows)
            {
                SAN_PHAM i = new SAN_PHAM();
                i.MaSP = item.Cells[0].Value.ToString();
                i.TenSP = item.Cells[2].Value.ToString();
                i.MaTH = item.Cells[10].Value.ToString();
                i.SoLuong = Convert.ToInt32(item.Cells[4].Value.ToString());
                i.DonViTinh = item.Cells[3].Value.ToString();
                i.GiaBan = Convert.ToInt32(item.Cells[5].Value);
                i.GiaVon= Convert.ToInt32(item.Cells[6].Value); ;
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportSanPham(pList, ref path, false);
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }





        //--------------------------------------------------
        //Form quản lý nhập hàng
        private void btnTimKiemNhapHang_Click(object sender, EventArgs e)
        {
            if(dtmNgayNhap1.Value>dtmNgayNhap2.Value)
            {
                MessageBox.Show("Ngày nhập không hợp lệ","Báo lỗi");
                return;
            }
            dtgvPhieuNhap.DataSource= pn.TimPhieuNhapTheoThoiGian(dtmNgayNhap1.Value , dtmNgayNhap2.Value);
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frm = new frmPhieuNhap();
            frm.Show();
        }

        private void btnThemPN_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frm = new frmPhieuNhap();
            frm.Show();
        }

        private void btnSuaPN_Click(object sender, EventArgs e)
        {
            PHIEU_NHAP phieuNhap = pn.TimPhieuNhapTheoMaPN(dtgvPhieuNhap.CurrentRow.Cells[0].Value.ToString());
            frmPhieuNhap frm = new frmPhieuNhap(phieuNhap);
            frm.Show();
        }

        private void btnXoaPN_Click(object sender, EventArgs e)
        {
            try
            {
                if(!pn.KiemTraKhoaChinh(dtgvPhieuNhap.CurrentRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Mã phiếu nhập không tồn tại.","ERROR");
                    return;
                }
                pn.XoaPhieuNhap(dtgvPhieuNhap.CurrentRow.Cells[0].Value.ToString());
                loadPhieuNhap();
                MessageBox.Show("Xóa phiếu nhập thành công.","SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa");
            }
        }

        private void btnExcelPN_Click(object sender, EventArgs e)
        {

        }

        private void dtgvPhieuNhap_DoubleClick(object sender, EventArgs e)
        {
            BLL_DAL.PHIEU_NHAP phieuNhap = pn.TimPhieuNhapTheoMaPN(dtgvPhieuNhap.CurrentRow.Cells[0].Value.ToString());
            frmPhieuNhap frm = new frmPhieuNhap(phieuNhap);
            frm.Show();
        }







        //--------------------------------------------------
        //Form quản lý kiểm kho
        private void dtgvKiemKho_SelectionChanged(object sender, EventArgs e)
        {
            txtMaKK.Text = dtgvKiemKho.CurrentRow.Cells[0].Value.ToString();
            if (dtgvKiemKho.CurrentRow.Cells[1].Value != null)
                dtmThoiGianKK.Value= (DateTime)dtgvKiemKho.CurrentRow.Cells[1].Value;
            else
                dtmThoiGianKK.Value = DateTime.Now;
            txtTongChenhLech.Text= dtgvKiemKho.CurrentRow.Cells[2].Value.ToString();
            cboNV.SelectedValue= dtgvKiemKho.CurrentRow.Cells[3].Value.ToString();
            if (dtgvKiemKho.CurrentRow.Cells[4].Value != null)
                txtGhiChuKK.Text = dtgvKiemKho.CurrentRow.Cells[4].Value.ToString();
            else
                txtGhiChuKK.Text = "";
            cbkTrangThaiKK.Checked= (bool)dtgvKiemKho.CurrentRow.Cells[5].Value;
        }

        private void btnTaoKiemKho_Click(object sender, EventArgs e)
        {
            frmPhieuKiemKho frm = new frmPhieuKiemKho();
            frm.Show();
        }

        private void cbkTimKiemKK_CheckedChanged(object sender, EventArgs e)
        {
            grbThoiGianKK.Visible = cbkTimKiemKK.Checked;
        }

        private void dtgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            txtMaPN.Text = dtgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            cboNhanVien.SelectedValue= dtgvPhieuNhap.CurrentRow.Cells[1].Value;
            cboNhaCungCap.SelectedValue= dtgvPhieuNhap.CurrentRow.Cells[2].Value;
            dtmThoiGianPN.Value= (DateTime)dtgvPhieuNhap.CurrentRow.Cells[3].Value;
            txtGiamGiaPN.Text= dtgvPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            txtTongTienPN.Text= string.Format("{0:0,0} VNĐ",Convert.ToInt64(dtgvPhieuNhap.CurrentRow.Cells[5].Value));
        }

        private void btnTaiPN_Click(object sender, EventArgs e)
        {
            dtgvPhieuNhap.DataSource = pn.GetPhieuNhap();
        }

        private void cbkTimKiemPN_CheckedChanged(object sender, EventArgs e)
        {
            grbTimKiemPN.Visible = cbkTimKiemPN.Checked;
        }





        //------------------------------------------------------------
        //Form  quản lý thương hiệu: Excel chưa xong
        //Thêm, xóa, sửa, load hình, clear thành công
        string tenHinhTH;
        private void btnHinhTH_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "(*.img)|*.img|(*.png)|*.png|(*.jpg)|*.jpg";
            if (op.ShowDialog() == DialogResult.OK)
            {
                picTH.Image = new Bitmap(op.FileName);
                tenHinhTH = Path.GetFileName(op.FileName);

                //StreamReader rd = new StreamReader(op.FileName);
                //MessageBox.Show(rd.ReadToEnd());
                //rd.Close();
            }
        }

        private void btnThemTH_Click(object sender, EventArgs e)
        {
            if(txtMaTH.Text==""||txtTenTH.Text=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thương hiệu.","ERROR");
                return;
            }   
            try
            {
                if (th.KiemTraKhoaChinh(txtMaTH.Text))
                {
                    MessageBox.Show("Mã thương hiệu đã tồn tại.", "ERROR");
                    return;
                }
                th.ThemThuongHieu(txtMaTH.Text, txtTenTH.Text, tenHinhTH);
                loadGiaoDienThuongHieu();
                MessageBox.Show("Thêm thương hiệu thành công.", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình thêm thương hiệu.", "ERROR");
            }
        }

        private void btnXoaTH_Click(object sender, EventArgs e)
        {
            if (txtMaTH.Text == "" || txtTenTH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thương hiệu.", "ERROR");
                return;
            }
            try
            {
                if (!th.KiemTraKhoaChinh(txtMaTH.Text))
                {
                    MessageBox.Show("Mã thương hiệu không tồn tại.", "ERROR");
                    return;
                }
                th.XoaThuongHieu(txtMaTH.Text);
                loadGiaoDienThuongHieu();
                MessageBox.Show("Xóa thương hiệu thành công", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình xóa thương hiệu.", "ERROR");
            }
        }

        private void btnSuaTH_Click(object sender, EventArgs e)
        {
            if (txtMaTH.Text == "" || txtTenTH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin thương hiệu.", "ERROR");
                return;
            }
            try
            {
                if (!th.KiemTraKhoaChinh(txtMaTH.Text))
                {
                    MessageBox.Show("Mã thương hiệu không tồn tại.", "ERROR");
                    return;
                }
                th.SuaThuongHieu(txtMaTH.Text, txtTenTH.Text, tenHinhTH);
                loadGiaoDienThuongHieu();
                MessageBox.Show("Sửa thông tin thương hiệu thành công", "SUCCESSFUL");
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình sửa thông tin thương hiệu.", "ERROR");
            }
        }

        private void btnExcelTH_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            if (pnThuongHieu.Controls.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "ERROR");
                return;
            }
            List<THUONG_HIEU> pList = new List<THUONG_HIEU>();
            // Đổ dữ liệu vào danh sách
            foreach (Control item in pnThuongHieu.Controls)
            {
                THUONG_HIEU i = new THUONG_HIEU();
                i.MaTH = item.Tag.ToString();
                i.TenTH = item.Text;
                pList.Add(i);
            }
            string path = string.Empty;
            excel.ExportThuongHieu(pList, ref path, false);

            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(path) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(path);
            }
        }

        private void btnClearTH_Click(object sender, EventArgs e)
        {
            txtMaTH.Clear();
            txtTenTH.Clear();
            picTH.Image = new Bitmap(Application.StartupPath + "\\Resource\\KoXacDinh.jpg");
            tenHinhTH = "";
            txtMaTH.Focus();
        }

        public void radio_CheckedChanged(object sender, EventArgs e)
        {
            if(rdNam.Checked)
            {
                DataTable dt = new DataTable();
                dt = tk.ThongKeTheoNam(2017, DateTime.Now.Year);
                foreach (DataRow row in dt.Rows)
                {
                    int ThoiGian = int.Parse(row["NAM"].ToString());
                    int Tien = int.Parse(row["TONGTIEN"].ToString());

                    chart1.Series["Doanh thu"].Points.Add(ThoiGian,Tien);
                }
                chart1.Refresh();
                //chart1.Series["Doanh thu"].Points.Clear();
                //chart1.DataSource = tk.ThongKeTheoNam(2017,DateTime.Now.Year);
                //chart1.Series["Doanh thu"].XValueMember = "NAM";
                //chart1.Series["Doanh thu"].YValueMembers = "TONGTIEN";
                //chart1.Titles.Add("Thống kê doanh thu bán hàng");
            }   
            else if(rdThang.Checked)
            {
                //chart1.Series["Doanh thu"].Points.Clear();
                var tatca = from n in data.HOA_DONs select new {THANG = n.ThoiGian.Value.Year, tongCong = n.TongTien };
                chart1.DataSource = tatca;
                chart1.Series["Doanh thu"].XValueMember = "THANG";
                chart1.Series["Doanh thu"].YValueMembers = "TONGTIEN";
                chart1.Titles.Add("Thống kê doanh thu bán hàng");
            }   
            else
            {
                chart1.DataSource = sp.GetSanPham();
                chart1.Series["Doanh thu"].XValueMember = "TenSP";
                chart1.Series["Doanh thu"].YValueMembers = "GIAVON";
                chart1.Titles.Add("Thống kê doanh thu bán hàng");
            }    
        }

        //private void btnPhieuLuong_Click(object sender, EventArgs e)
        //{
        //    if(txtTenNV.Text==""||txtCMND_NV.Text==""||txtSDT_NV.Text==""){
        //        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.","FAILED");
        //        return;
        //    }
        //    WordExport r = new WordExport();
        //    r.ThongTinLuongNV(txtTenNV.Text, dtmNgaySinhNV.Value.ToString(), cboChucVuNV.Text, txtCMND_NV.Text, txtSDT_NV.Text, "5.000.000 VNĐ", DateTime.Now.Month + "", DateTime.Now.Year + "");
        //}

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text == "" || txtCMND_NV.Text == "" || txtSDT_NV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "FAILED");
                return;
            }
            WordExport r = new WordExport();
            r.ThongTinLuongNV(txtTenNV.Text, dtmNgaySinhNV.Value.ToString(), cboChucVuNV.Text, txtCMND_NV.Text, txtSDT_NV.Text, "5.000.000 VNĐ", DateTime.Now.Month + "", DateTime.Now.Year + "");
        }

        private void btnInTheKH_Click(object sender, EventArgs e)
        {
            rptTheKH r = new rptTheKH();
            r.DataSource = k.TimKiemKhachHang(txtMaKH.Text);
            r.ShowPreview();
        }

        private void btnMaVachSP_Click(object sender, EventArgs e)
        {
            rptMaVach r = new rptMaVach();
            r.ShowPreview();
        }
    }
}
    


