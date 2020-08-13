using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class NhanVienBLL
    {
        QLShopDataContext data = new QLShopDataContext();
        public NhanVienBLL() { }

        public void ThemNhanVien(string ma,string ten,string email,string cmnd,string dt,DateTime ngay,string chucVu)
        {
            NHAN_VIEN nv = new NHAN_VIEN();
            nv.MaNV = ma;
            nv.TenNV = ten;
            nv.Email = email;
            nv.CMND = cmnd;
            nv.SDT = dt;
            nv.NgaySinh = ngay;
            nv.MaCV = chucVu;
            data.NHAN_VIENs.InsertOnSubmit(nv);
            data.SubmitChanges();
        }

        public void SuaNhanVien(string ma, string ten, string email, string cmnd, string dt, DateTime ngay, string chucVu)
        {
            NHAN_VIEN nv = data.NHAN_VIENs.Where(t => t.MaNV == ma).FirstOrDefault();
            nv.TenNV = ten;
            nv.Email = email;
            nv.CMND = cmnd;
            nv.SDT = dt;
            nv.NgaySinh = ngay;
            nv.MaCV = chucVu;
            data.SubmitChanges();
        }

        public void XoaNhanVien(string ma)
        {
            NHAN_VIEN nv = data.NHAN_VIENs.Where(t => t.MaNV == ma).FirstOrDefault();
            data.NHAN_VIENs.DeleteOnSubmit(nv);
            data.SubmitChanges();
        }

        public IQueryable<NHAN_VIEN> GetNhanVien()
        {
            return data.NHAN_VIENs.Select(t => t);
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            NHAN_VIEN nv = data.NHAN_VIENs.Where(t => t.MaNV == ma).FirstOrDefault();
            return nv != null;
        }

        public NHAN_VIEN TimNhanVien(string ma)
        {
            NHAN_VIEN nv = data.NHAN_VIENs.Where(t => t.MaNV == ma).FirstOrDefault();
            return nv;
        }

        public IQueryable<NHAN_VIEN> GetNhanVienTheoNhomND(string nhomnd)
        {
            var tatca = from t in data.NHOM_NGUOI_DUNGs
                        from n in data.NGUOI_DUNG_NHOM_NGUOI_DUNGs
                        from a in data.DANG_NHAPs
                        from b in data.NHAN_VIENs
                        where t.MaNhom == n.MaNhom
                        where n.TaiKhoan == a.TaiKhoan
                        where a.MaNV == b.MaNV
                        where t.MaNhom == nhomnd
                        select b;
            return tatca;
        }

        public IQueryable<NHAN_VIEN> GetNhanVienTheoDangNhap()
        {
            var nhanVien=from nv in data.NHAN_VIENs
                         from dn in data.DANG_NHAPs
                         where dn.MaNV == nv.MaNV
                         select nv;
            return nhanVien;
        }

        public IQueryable<NHAN_VIEN> GetNhanVienTheoChucVu(string maCV)
        {
            var nhanVien = from nv in data.NHAN_VIENs where nv.MaCV == maCV select nv;
            return nhanVien;
        }

        public NHAN_VIEN TimTaiKhoanNhanVien(string taiKhoan)
        {
            DANG_NHAP dn = data.DANG_NHAPs.Where(t => t.TaiKhoan == taiKhoan).FirstOrDefault();
            NHAN_VIEN nv = data.NHAN_VIENs.Where(t => t.MaNV == dn.MaNV).FirstOrDefault();
            return nv;
        }
    }
}
