using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_DAL
{
    public class PhieuNhapBLL
    {
        QLShopDataContext data = new QLShopDataContext();

        public PhieuNhapBLL() { }

        public IQueryable<PHIEU_NHAP> GetPhieuNhap()
        {
            return data.PHIEU_NHAPs.Select(t => t);
        }

        public bool KiemTraKhoaChinh(string mapn)
        {
            PHIEU_NHAP pn = data.PHIEU_NHAPs.Where(t => t.MaPN == mapn).FirstOrDefault();
            return pn != null;
        }

        public void ThemPhieuNhap(string mapn,string mancc,string manv,DateTime thGian,int giamGia)
        {
            PHIEU_NHAP pn = new PHIEU_NHAP();
            pn.MaPN = mapn;
            pn.MaNV = manv;
            pn.MaNCC = mancc;
            pn.ThoiGian = thGian;
            pn.GiamGia = giamGia;
            pn.TongTien = 0;
            data.PHIEU_NHAPs.InsertOnSubmit(pn);
            data.SubmitChanges();
        }

        public void XoaPhieuNhap(string mapn)
        {
            PHIEU_NHAP pn = data.PHIEU_NHAPs.Where(t => t.MaPN == mapn).FirstOrDefault();
            data.PHIEU_NHAPs.DeleteOnSubmit(pn);
            data.SubmitChanges();
        }

        public void SuaPhieuNhap(string mapn, string mancc, string manv, DateTime thGian, int giamGia, long tongTien)
        {
            PHIEU_NHAP pn = data.PHIEU_NHAPs.Where(t => t.MaPN == mapn).FirstOrDefault();
            pn.MaNV = manv;
            pn.MaNCC = mancc;
            pn.ThoiGian = thGian;
            pn.GiamGia = giamGia;
            pn.TongTien = tongTien;
            data.SubmitChanges();
        }

        public IQueryable<PHIEU_NHAP> TimPhieuNhapTheoThoiGian(DateTime tgBD,DateTime tgKT)
        {
            var pn = from tt in data.PHIEU_NHAPs
                     where tt.ThoiGian >= tgBD
                     where tt.ThoiGian <= tgKT
                     select tt;
            return pn;
        }

        public PHIEU_NHAP TimPhieuNhapTheoMaPN(string ma)
        {
            PHIEU_NHAP pn = data.PHIEU_NHAPs.Where(t => t.MaPN == ma).FirstOrDefault();
            return pn;
        }
    }
}
