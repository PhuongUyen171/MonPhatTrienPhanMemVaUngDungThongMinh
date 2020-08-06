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
using DevComponents.DotNetBar;

namespace DoAn
{
    public partial class frmPhieuKiemKho : Office2007Form
    {
        SanPhamBLL sp = new SanPhamBLL();
        PhieuKiemKhoBLL kk = new PhieuKiemKhoBLL();
        ChiTietKiemKhoBLL ct = new ChiTietKiemKhoBLL();
        NhanVienBLL nv = new NhanVienBLL();


        public frmPhieuKiemKho()
        {
            InitializeComponent();
        }

        public void loadSP()
        {
            cboSanPham.DataSource = sp.GetSanPham();
            cboSanPham.DisplayMember = "TenSP";
            cboSanPham.ValueMember = "MaSP";
        }

        public void loadKiemKho()
        {
            cboKiemKho.DataSource = kk.GetPhieuKiemKho();
            cboKiemKho.DisplayMember = "MaKiemKho";
            cboKiemKho.ValueMember = "MaKiemKho";
        }

        public void loadCTKK(string makk)
        {
            dtgvKiemKho.DataSource = ct.GetPhieuKiemKho(makk);
        }

        public void loadNV()
        {
            cboNV.DataSource = nv.GetNhanVien();
            cboNV.DisplayMember = "TenNV";
            cboNV.ValueMember = "MaNV";
        }

        private void frmPhieuKiemKho_Load(object sender, EventArgs e)
        {
            loadNV();
            loadSP();
            loadKiemKho();
            loadCTKK(cboKiemKho.SelectedValue.ToString());
        }

        private void dtgvKiemKho_SelectionChanged(object sender, EventArgs e)
        {
            cboKiemKho.SelectedValue = dtgvKiemKho.CurrentRow.Cells[0].Value;
            cboSanPham.SelectedValue = dtgvKiemKho.CurrentRow.Cells[1].Value;
            txtSL.Text = dtgvKiemKho.CurrentRow.Cells[2].Value.ToString();
            txtSLThucTe.Text= dtgvKiemKho.CurrentRow.Cells[3].Value.ToString();
            txtChenhLech.Text= dtgvKiemKho.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
