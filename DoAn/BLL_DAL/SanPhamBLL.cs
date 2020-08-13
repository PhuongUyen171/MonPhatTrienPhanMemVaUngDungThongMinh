using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class SanPhamBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public SanPhamBLL() { }

        public IQueryable<SAN_PHAM> GetSanPham()
        {
            var tatCaSP = data.SAN_PHAMs.Select(t => t);
            return tatCaSP;
        }

        public void XoaSanPham(string ma)
        {
            SAN_PHAM s = data.SAN_PHAMs.Where(t => t.MaSP == ma).FirstOrDefault();
            data.SAN_PHAMs.DeleteOnSubmit(s);
            data.SubmitChanges();
        }

        public bool KiemTraKhoaChinh(string ma)
        {
            SAN_PHAM s = data.SAN_PHAMs.Where(t => t.MaSP == ma).FirstOrDefault();
            return s != null;
        }

        public void ThemSanPham(string ma, string ten, string loaiSP, long giaBan, long giaVon, int sl,string dvt,bool trangThai,string hinh)
        {
            SAN_PHAM s = new SAN_PHAM();
            s.MaSP = ma;
            s.TenSP = ten;
            s.MaLoaiSP = loaiSP;
            s.GiaBan = giaBan;
            //s.GiaNhapCuoi = giaNhapCuoi;
            s.GiaVon = giaVon;
            s.HinhAnh = hinh;
            //s.MucTon = 10;
            s.SoLuong = sl;
            s.DonViTinh = dvt;
            s.TrangThai = trangThai;
            data.SAN_PHAMs.InsertOnSubmit(s);
            data.SubmitChanges();
        }

        public void SuaSanPham(string ma, string ten, string loaiSP, long giaBan, long giaVon, int sl, string dvt, bool trangThai, string hinh)
        {
            SAN_PHAM s = data.SAN_PHAMs.Where(t => t.MaSP == ma).FirstOrDefault();
            s.TenSP = ten;
            s.MaLoaiSP = loaiSP;
            s.GiaBan = giaBan;
            //s.GiaNhapCuoi = giaNhapCuoi;
            s.GiaVon = giaVon;
            s.HinhAnh = hinh;
            //s.MucTon = 10;
            s.SoLuong = sl;
            s.DonViTinh = dvt;
            s.TrangThai = trangThai;
            data.SubmitChanges();
        }

        public long GetGiaTheoMaSP(string ma)
        {
            SAN_PHAM sp = data.SAN_PHAMs.Where(t => t.MaSP == ma).FirstOrDefault();
            if(sp!=null)
                return Convert.ToInt64(sp.GiaBan);
            return 0;
        }

        public SAN_PHAM TimKiemSanPham(string ma)
        {
            return data.SAN_PHAMs.Where(t => t.MaSP == ma).FirstOrDefault();
        }
    }
}
